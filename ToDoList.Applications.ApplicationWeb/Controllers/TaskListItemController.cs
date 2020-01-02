using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToDoList.Applications.ApplicationWeb.Authorization;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWeb.Controllers
{
    [CustomAutorize]
    public class TaskListItemController : Controller
    {
        ITaskListManager _taskListManager;

        public TaskListItemController(ITaskListManager taskListManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
        }
        // GET: TaskListItem
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTaskListItems(int Id)
        {
            Session["TaskListId"] = Id.ToString();
            TaskList taskList = _taskListManager.GetTaskList(Id);
            var taskListItems = _taskListManager.ListTaskListItems(taskList);
            var taskListName = taskList.Name;
            ViewBag.TaskListName = taskListName;

            return View(taskListItems);
            // string apiUrl = "http://localhost:51004/TaskList/Tasks/";
            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl + Id.ToString());
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsStringAsync();
            //        // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
            //        List<TaskListItem> taskListItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TaskListItem>>(data);
            //        return View(taskListItems);
            //    }
            //}
        }

        public ActionResult CreateTaskListItemView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTaskListItem(string text, bool isCompleted)
        {
            int id = int.Parse(Session["TaskListId"].ToString());
            try
            {
                TaskList taskList = _taskListManager.GetTaskList(id);
                TaskListItem taskListItem = new TaskListItem { Text = text, IsCompleted = isCompleted, TaskList = taskList };
                _taskListManager.CreateTaskListItem(taskListItem);
                TempData["ConfirmationMessage"] = "Task created successfully";
                return RedirectToAction("CreateTaskListItemView", "TaskListItem");
            }
            catch(TaskListItemException e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task not created";
                return RedirectToAction("CreateTaskListItemView", "TaskListItem");
            }

            //string apiUrl = "http://localhost:51004/TaskList/Tasks/Add/";

            //using (HttpClient client = new HttpClient())
            //{
            //    string _isCompleted = isCompleted.ToString();
            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    var parameters = new Dictionary<string, string> { { "name", text }, { "isCompleted", _isCompleted } };
            //    var encodedContent = new FormUrlEncodedContent(parameters);

            //    var postTask = client.PostAsJsonAsync(apiUrl + id + "/"+ text + "/" + isCompleted, parameters);

            //    postTask.Wait();
            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("CreateTaskListItemView", "TaskListItem");
            //    }

            //    return RedirectToAction("CreateTaskListItemView", "TaskListItem");
            //}
        }

        public ActionResult DeleteTaskListItem(int id)
        {
            int taskListId = int.Parse(Session["TaskListId"].ToString());

            try
            {
                TaskList taskList = _taskListManager.GetTaskList(taskListId);
                TaskListItem task = new TaskListItem { Id = id, TaskList = taskList };
                _taskListManager.DeleteTaskListItem(task);
                TempData["ConfirmationMessage"] = "Task deleted successfully";
                return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task not deleted";
                return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            }


            //string apiUrl = "http://localhost:51004/TaskList/Tasks/Delete/";
            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    var deleteTask = client.DeleteAsync(apiUrl + TaskListId +"/"+ Id);

            //    deleteTask.Wait();
            //    var result = deleteTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            //    }

            //    return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            //}
        }

        public ActionResult EditTaskListItem(int id)
        {
            var taskList = _taskListManager.GetTaskList(int.Parse(Session["TaskListId"].ToString()));
            var taskListItem = taskList.Items.Where(i => i.Id == id).SingleOrDefault();
            return View("~/Views/TaskListItem/EditTaskListItem.cshtml", taskListItem);
        }

         [HttpPost]
        public ActionResult EditTaskListItem(int id, string text, bool isCompleted)
        {
            TaskListItem emptyTaskListItem = null;
            int taskListId = int.Parse(Session["TaskListId"].ToString());
            TaskList taskList = _taskListManager.GetTaskList(taskListId);
            TaskListItem taskListItem = new TaskListItem { Id = id, Text = text, IsCompleted = isCompleted, TaskList = taskList };

            try
            {
                _taskListManager.UpdateTaskListItem(taskListItem);
                TempData["ConfirmationMessage"] = "Task edited successfully";
                return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            }
            catch (TaskListItemException e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task not edited";
                return View(emptyTaskListItem);
            }


            //string apiUrl = "http://localhost:51004/TaskList/Tasks/Update/";
            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    var parameters = new Dictionary<string, string> { { "id", Id }, { "text", text }, { "isCompleted", _isCompleted} };
            //    var encodedContent = new FormUrlEncodedContent(parameters);

            //    var putTask = client.PutAsJsonAsync(apiUrl + TaskListId +"/" +Id + "/" + text + "/" + _isCompleted, parameters);

            //    putTask.Wait();
            //    var result = putTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("GetTaskListItems", "TaskListItem", new { Id = Session["TaskListId"] });
            //    }

            //    return View(taskListItem);
            //}
        }

    }
}