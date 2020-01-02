using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Applications.ApplicationWebApi.Authorize;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWebApi.Controllers
{
    public class UsersController : ApiController
    {
        ISecurityManager _securityManager;
        IAccountManager _accountManager;

        public UsersController(ISecurityManager securityManager, IAccountManager accountManager)
        {
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }

        [AllowAnonymous]
        [Route("Login/{username}/{password}")]
        [HttpPost]
        public string LogIn(string username, string password) //public <-> private
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                return _securityManager.Login(username, password);
            }
            catch (UserNameNotFoundException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No user with username = {0}", username)),
                    ReasonPhrase = "User not found"
                };
                throw new HttpResponseException(response);
            }
            catch (PasswordInvalidException)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Invalid password for username = {0}", username)),
                    ReasonPhrase = "Invalid password"
                };
                throw new HttpResponseException(response);
            }
            catch (LoginException e)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("Login error")),
                    ReasonPhrase = e.Message
                };
                throw new HttpResponseException(response);
            }
        }

        [Route("Register/{username}/{password}")]
        [HttpPost]
        public User Register([FromUri]User user)
        {
            if (_securityManager.IsLoggedIn() == false)
            {
                try
                {
                    _accountManager.Register(user);
                    return user;
                }
                catch (RegistrationException)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("User with username = {0} already exists", user.Username)),
                        ReasonPhrase = "User already exists"
                    };
                    throw new HttpResponseException(response);
                }
                catch
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent(string.Format("Registration error")),
                        ReasonPhrase = "Registration error"
                    };
                    throw new HttpResponseException(response);
                }
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(string.Format("You cannot register when user is logged in")),
                    ReasonPhrase = "You cannot register when user is logged in"
                };
                throw new HttpResponseException(response);
            }
        }

        [CustomAutorization]
        [Route("Logout")]
        [HttpPost]
        public IHttpActionResult LogOut()
        {
            if (_securityManager.IsLoggedIn() == true)
            {
                _securityManager.Logout(_securityManager.GetLoggedUser());
                return Ok("User logged out");
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(string.Format("No user is logged in")),
                    ReasonPhrase = "No user is logged in"
                };
                throw new HttpResponseException(response);
            }
        }
    }
}
