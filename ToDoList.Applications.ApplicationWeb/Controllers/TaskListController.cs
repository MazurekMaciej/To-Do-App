using System;
using System.Linq;
using System.Web.Mvc;
using ToDoList.Applications.ApplicationWeb.Authorization;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;

namespace ToDoList.Applications.ApplicationWeb.Controllers
{
    [CustomAutorize]
    public class TaskListController : Controller
    {
        ITaskListManager _taskListManager;
        ISecurityManager _securityManager;

        public TaskListController(ITaskListManager taskListManager, ISecurityManager securityManager)
        { 
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public ActionResult Index()
        {
            return View(this.GetTaskLists(1));
        }

        // GET: TaskList
        public ActionResult GetTaskLists(int currentPageIndex)
        {
            int maxRows = 10;
            try
            {
                User user = _securityManager.GetLoggedUser();
                if (user == null)
                    return RedirectToAction("NotFound", "Errors");
                else
                {
                    var taskList = _taskListManager.ListTaskLists(user);

                    var filteredList = (from item in taskList
                                        select item)
                        .OrderBy(item => item.Id)
                        .Skip((currentPageIndex - 1) * maxRows)
                        .Take(maxRows).ToList();

                    double pageCount = (double)((decimal)taskList.Count() / Convert.ToDecimal(maxRows));
                    pageCount = (int)Math.Ceiling(pageCount);
                    ViewBag.PageCount = pageCount;
                    
                    ViewBag.CurrentPage = currentPageIndex;

                    return View(filteredList);
                }
            }
            catch(Exception e)
            {
                return RedirectToAction("NotFound", "Errors");
            }

            //string apiUrl = "http://localhost:51004/Tasklists";

            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsStringAsync();
            //       // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
            //        List<TaskList> taskLists = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TaskList>>(data);
            //        return View(taskLists);
            //    }
            //}
        }

        public ActionResult CreateTaskListView()
        {
            return View();
        }
        
       [HttpPost]
        public ActionResult CreateTaskList(string name)
        {
            User user = _securityManager.GetLoggedUser();
            TaskList taskList = new TaskList { Name = name, User = user };
            try 
            {
                _taskListManager.CreateTaskList(taskList);
                TempData["ConfirmationMessage"] = "Task List created successfully";
                return RedirectToAction("CreateTaskListView", "TaskList");
            }
            catch (TaskListException e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task List not created";
                return RedirectToAction("CreateTaskListView", "TaskList");
            }

            //string apiUrl = "http://localhost:51004/Tasklists/Add/";

            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    var parameters = new Dictionary<string, string> { { "name", Name } };
            //    var encodedContent = new FormUrlEncodedContent(parameters);

            //    var postTask = client.PostAsJsonAsync(apiUrl + Name, parameters);

            //    postTask.Wait();
            //    var result = postTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("CreateTaskListView", "TaskList");
            //    }

            //    return RedirectToAction("CreateTaskListView", "TaskList");
            //}
        }


      //  [HttpDelete] //not working with
        public ActionResult DeleteTaskList(int id)
        {
            User user = _securityManager.GetLoggedUser();
            TaskList taskList = _taskListManager.GetTaskList(id);
            try
            {
                _taskListManager.DeleteTaskList(taskList);
                TempData["ConfirmationMessage"] = "Task List deleted successfully";
                return RedirectToAction("GetTaskLists", "TaskList", new { currentPageIndex = 1 });
            }
            catch (TaskListException e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task List not deleted";
                return RedirectToAction("GetTaskLists", "TaskList", new { currentPageIndex = 1 });
            }


            //string apiUrl = "http://localhost:51004/Tasklists/Delete/";

            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    var deleteTask = client.DeleteAsync(apiUrl + Id);

            //    deleteTask.Wait();
            //    var result = deleteTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("GetTaskLists", "TaskList");
            //    }

            //    return RedirectToAction("GetTaskLists", "TaskList");
            //}
        }

        //public ActionResult EditTaskList(int id)
        //{
        //   // TaskList taskList = null;
        //    TaskList taskList = _taskListManager.GetTaskList(id);
        //    try
        //    {
        //        _taskListManager.UpdateTaskList(taskList);
        //        return View();
        //    }
        //    catch (TaskListException e)
        //    {
        //        ModelState.AddModelError("", e.Message);
        //        return View();
        //    }

        //string Id = id.ToString();
        //string apiUrl = "http://localhost:51004/Tasklists/";

        //using (HttpClient client = new HttpClient())
        //{

        //    client.BaseAddress = new Uri(apiUrl);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        //    //  var parameters = new Dictionary<string, string> { { "id", Id } };
        //    // var encodedContent = new FormUrlEncodedContent(parameters);

        //    var editTask = client.GetAsync(apiUrl + Id);

        //    editTask.Wait();
        //    var result = editTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<TaskList>();
        //        readTask.Wait();
        //        taskList = readTask.Result;
        //    }

        //    return View(taskList);
        //}
        // }

        public ActionResult EditTaskListView(int id)
        {
            //return RedirectToAction("EditTaskList", "TaskList", new { id });
            var taskList = _taskListManager.GetTaskList(id);

            return View("~/Views/TaskList/EditTaskList.cshtml", taskList);
        }


        [HttpPost]
        public ActionResult EditTaskList(int id, string name)
        {
            TaskList taskList = _taskListManager.GetTaskList(id);
            taskList.Name = name;
            try
            {
                _taskListManager.UpdateTaskList(taskList);
                TempData["ConfirmationMessage"] = "Task List edited successfully";
                return RedirectToAction("GetTaskLists", "TaskList", new { currentPageIndex = 1 });
            }
            catch (TaskListException e)
            {
                ModelState.AddModelError("", e.Message);
                TempData["ConfirmationMessage"] = "Task List not edited";
                return View(taskList);
            }

            //TaskList taskList = null;
            //string Id = id.ToString();
            //string apiUrl = "http://localhost:51004/Tasklists/Update/";

            //using (HttpClient client = new HttpClient())
            //{

            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //      var parameters = new Dictionary<string, string> { { "id", Id }, { "name", name } };
            //      var encodedContent = new FormUrlEncodedContent(parameters);

            //    var putTask = client.PutAsJsonAsync(apiUrl + Id + "/" + name, parameters);

            //    putTask.Wait();
            //    var result = putTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("GetTaskLists", "TaskList");
            //    }

            //    return View(taskList);
            //}
        }      
    }
}