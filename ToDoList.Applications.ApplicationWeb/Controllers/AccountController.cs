using System;
using System.Web.Mvc;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWeb.Controllers
{
    public class AccountController : Controller
    {
        ISecurityManager _securityManager;
        IAccountManager _accountManager;

        public AccountController(ISecurityManager securityManager, IAccountManager accountManager)
        {
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        }
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginUser(string name, string password)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(password.Trim()))
            {
                ModelState.AddModelError("username", "Name and password are required fields.");
                return View("~/Views/Account/Index.cshtml");
            }
            else
            {
                try
                {
                    _securityManager.Login(name, password);

                    Session["Logged"] = "LoggedIn";
                    return RedirectToAction("GetTaskLists", "TaskList", new { currentPageIndex = 1 });

                }
                catch (UserNameNotFoundException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                catch (PasswordInvalidException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                return View("~/Views/Account/Index.cshtml");
            }
            // return View("~/Views/Account/Index.cshtml");

            //string apiUrl = "http://localhost:51004/Login/";

            //if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(password.Trim()))
            //{
            //    ModelState.AddModelError("username", "Name and password are required fields.");
            //    return View("~/Views/Account/Index.cshtml");
            //}
            //else
            //{

            //    using (HttpClient client = new HttpClient())
            //    {

            //        client.BaseAddress = new Uri(apiUrl);
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //        // client.PostAsJsonAsync("Login/", new { Name = name, Password = password });
            //        var parameters = new Dictionary<string, string> { { "name", name }, { "password", password } };
            //        var encodedContent = new FormUrlEncodedContent(parameters);

            //        var postTask = client.PostAsJsonAsync(apiUrl + name + "/" + password, parameters);

            //        postTask.Wait();

            //        var result = postTask.Result;
            //        if (result.IsSuccessStatusCode)
            //        {
            //            Session["uname"] = name;
            //            Session.Timeout = 10;
            //            return RedirectToAction("GetTaskLists", "TaskList");
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", result.ReasonPhrase);
            //            return View("~/Views/Account/Index.cshtml");
            //        }

            //    }
            //}
        }

        public ActionResult RegisterView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string name, string password)
        {
            if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(password.Trim()))
            {
                ModelState.AddModelError("", "Username and password are required fields.");
                return View("~/Views/Account/RegisterView.cshtml");
            }
            else
            {
                User user = new User
                {
                    Username = name,
                    Password = password
                };

                try
                {
                    _accountManager.Register(user);

                    return View("~/Views/Account/Index.cshtml");

                }
                catch (RegistrationException e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View("~/Views/Account/RegisterView.cshtml");
                }

            }

            //string apiUrl = "http://localhost:51004/Register/";

            //if (String.IsNullOrEmpty(name.Trim()) || String.IsNullOrEmpty(password.Trim()))
            //{
            //    ModelState.AddModelError("", "Name and password are required fields.");
            //    return View("~/Views/Account/RegisterView.cshtml");
            //}
            //else
            //{

            //    using (HttpClient client = new HttpClient())
            //    {

            //        client.BaseAddress = new Uri(apiUrl);
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //        // client.PostAsJsonAsync("Login/", new { Name = name, Password = password });
            //        var parameters = new Dictionary<string, string> { { "name", name }, { "password", password } };
            //        var encodedContent = new FormUrlEncodedContent(parameters);

            //        var postTask = client.PostAsJsonAsync(apiUrl + name + "/" + password, parameters);

            //        postTask.Wait();

            //        var result = postTask.Result;
            //        if (result.IsSuccessStatusCode)
            //        {
            //            Session["registered"] = name;
            //            return RedirectToAction("Index", "Account");
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", result.ReasonPhrase);
            //            return View("~/Views/Account/RegisterView.cshtml");
            //        }

            //    }
            //}
        }

        // [Authorize]
        public ActionResult LogOut()
        {
            try
            {
                _securityManager.Logout(_securityManager.GetLoggedUser());
                Session.Remove("Logged");
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("~/Views/Home/Index.cshtml");
                //
            }

            // string apiUrl = "http://localhost:51004/Logout";
            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    // client.PostAsJsonAsync("Login/", new { Name = name, Password = password });
            //   // var parameters = new Dictionary<string, string> { { "name", name }, { "password", password } };
            //    //var encodedContent = new FormUrlEncodedContent(parameters);

            //    var postTask = client.PostAsJsonAsync(apiUrl, "");

            //    postTask.Wait();

            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        Session.Remove("uname");
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", result.ReasonPhrase);
            //        return View("~/Views/Home/Index.cshtml");
            //    }

            //}
        }
    }
}