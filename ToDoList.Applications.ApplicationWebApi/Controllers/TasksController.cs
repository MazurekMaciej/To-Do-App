using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoList.Applications.ApplicationWebApi.Authorize;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWebApi.Controllers
{
    public class TasksController : ApiController
    {
        ITaskListManager _taskListManager;

        public TasksController(ITaskListManager taskListManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
        }

        [CustomAutorization]
        [Route("TaskList/Tasks/{taskListId}")]
        [HttpGet]
        public IHttpActionResult GetTasks(int taskListId) //public <-> private
        {
            try
            {
                var taskList = _taskListManager.GetTaskList(taskListId);
                try
                {
                    List<TaskListItem> taskListItems = _taskListManager.ListTaskListItems(taskList);
                    return Ok(taskListItems);
                }
                catch
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tasks not found"));
                }
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskList/Tasks/{taskListId}/{taskId}")]
        [HttpGet]
        public IHttpActionResult GetTask(int taskListId, int taskId)
        {
            try
            {
                var taskList = _taskListManager.GetTaskList(taskListId);
                try
                {
                    List<TaskListItem> taskListItems = _taskListManager.ListTaskListItems(taskList);
                    var task = taskListItems.Where(n => n.Id == taskId).SingleOrDefault();
                    if (task != null)
                        return Ok(task);
                    else
                        return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not found"));
                }
                catch
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not found"));
                }
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskList/Tasks/Add/{taskListId}/{text}/{isCompleted}")]
        [HttpPost]
        public IHttpActionResult PostNewTask(int taskListId, string text, bool isCompleted)
        {
            try
            {
                var taskList = _taskListManager.GetTaskList(taskListId);
                TaskListItem task = new TaskListItem { Text = text, IsCompleted = isCompleted, TaskList = taskList };
                _taskListManager.CreateTaskListItem(task);
                return Ok("Task: " + text + " IsCompleted: " + isCompleted + " created");
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskList/Tasks/Update/{taskListId}/{taskId}/{text}/{isCompleted}")]
        [HttpPut]
        public IHttpActionResult PutTask(int taskListId, int taskId, string text, bool isCompleted)
        {
            try
            {
                var taskList = _taskListManager.GetTaskList(taskListId);
                TaskListItem task = new TaskListItem { Id = taskId, Text = text, IsCompleted = isCompleted, TaskList = taskList };
                try
                {
                    _taskListManager.UpdateTaskListItem(task);
                    return Ok("Task Id: " + taskId + " text: " + text + " Is it compelted: " + isCompleted + " updated");
                }
                catch
                {
                    return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not updated"));
                }
            }
            catch (TaskListNotFoundException e)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message));
            }
        }

        [CustomAutorization]
        [Route("TaskList/Tasks/Delete/{taskListId}/{taskId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int taskListId, int taskId)
        {
            var taskList = _taskListManager.GetTaskList(taskListId);
            TaskListItem task = new TaskListItem { Id = taskId, TaskList = taskList };
            try
            {
                _taskListManager.DeleteTaskListItem(task);
                return Ok("Task with Id: " + taskId + " deleted");
            }
            catch
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not deleted"));
            }
        }
    }
}
