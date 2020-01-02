using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;
using ToDoList.Applications.ApplicationWebApi.Authorize;

namespace ToDoList.Applications.ApplicationWebApi.Controllers
{
    public class TaskListsController : ApiController
    {
        ITaskListManager _taskListManager;
        ISecurityManager _securityManager;

        public TaskListsController(ITaskListManager taskListManager, ISecurityManager securityManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        [CustomAutorization]
        [Route("TaskLists")]
        [HttpGet]
        public IHttpActionResult GetTaskLists() 
        {
            User user = _securityManager.GetLoggedUser();
            try
            {
                List<TaskList> taskLists = _taskListManager.ListTaskLists(user);
                return Ok(taskLists);
            }
            catch (TaskListException)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Operation failed"));
            }
        }

        [CustomAutorization]
        [Route("TaskLists/{taskListId}")]
        [HttpGet]
        public IHttpActionResult GetTaskList(int taskListId)
        {
            try
            {
                var taskList = _taskListManager.GetTaskList(taskListId);
                return Ok(taskList);
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskLists/Add/{name}")]
        [HttpPost]
        public IHttpActionResult PostNewTaskList(string name)
        {
            User user = _securityManager.GetLoggedUser();
            TaskList taskList = new TaskList { Name = name, User = user };
            try
            {
                _taskListManager.CreateTaskList(taskList);
                return Ok("Task List " + name + " created");
            }
            catch (TaskListException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskLists/Update/{id}/{name}")]
        [HttpPut]
        public IHttpActionResult PutTaskList(int id, string name)
        {
            User user = _securityManager.GetLoggedUser();
            TaskList taskList = new TaskList { Id = id, Name = name, User = user };
            try
            {
                _taskListManager.UpdateTaskList(taskList);
                return Ok("Task List Id: " + id + " New name: " + name + " updated");
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskLists/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTaskList(int id)
        {
            TaskList taskList = new TaskList { Id = id };
            try
            {
                _taskListManager.DeleteTaskList(taskList);
                return Ok("Task List with Id: " + id + " deleted");
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }
    }
}
