using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using ToDoList.Lib.Common.Exceptions;
using ToDoList.Lib.Data;

namespace ToDoList.Lib.Business.Managers
{
    public class TaskListManager : ITaskListManager
    {
        ISecurityManager _securityManager;
        ILog _logManager;

        public TaskListManager(ILog logManager, ISecurityManager securityManager)
        {
            _logManager = logManager ?? throw new ArgumentNullException(nameof(logManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public List<TaskList> ListTaskLists(User user)
        {
            List<TaskList> listTaskList = new List<TaskList>();
            ToDoContext dbContext = new ToDoContext();

            int? id = _securityManager.GetLoggedUserId();
            List<TaskList> taskLists = dbContext.TaskLists.Where(u => u.User.Id == id.Value).ToList();

            if (taskLists?.Any() == true)
            {
                foreach (TaskList taskList in taskLists)
                {
                    listTaskList.Add(taskList);
                    _logManager.Info("Task List displayed successfully " + taskList.Id + " " + taskList.Name);
                }
                return listTaskList;
            }
            else
            {
                _logManager.Info("Empty Task Lists");
                return listTaskList;
            }
        }

        public List<TaskListItem> ListTaskListItems(TaskList taskList)
        {
            List<TaskListItem> listTaskListItems = new List<TaskListItem>();
            ToDoContext dbContext = new ToDoContext();
            var taskListFromDb = dbContext.TaskLists.Where(i => i.Id == taskList.Id).SingleOrDefault();
            List<TaskListItem> taskListItems = dbContext.TaskListItems.Where(n => n.TaskList.Id == taskList.Id).ToList();

            if (taskListItems != null && taskListFromDb.User.Id == _securityManager.GetLoggedUserId())
            {
                _logManager.Info("Listing Tasks in Task List");
                foreach (TaskListItem taskListItem in taskListItems)
                {
                    listTaskListItems.Add(taskListItem);
                }
                return listTaskListItems;
            }
            else
            {
                _logManager.Error("Task List Items not displayed");
                _logManager.Debug("User info who failed listing: " + taskList.Id + " " + taskList.Name);
                return listTaskListItems;
            }
        }

        public void CreateTaskList(TaskList taskList)
        {
            ToDoContext dbContext = new ToDoContext();
            int? id = _securityManager.GetLoggedUserId();
            var actualUser = dbContext.Users.Where(n => n.Id == id).Single();
            TaskList tList = new TaskList { Name = taskList.Name, User = actualUser };
            if (taskList.User.Id == _securityManager.GetLoggedUserId())
            {
                dbContext.TaskLists.Add(tList);
                try
                {
                    dbContext.SaveChanges();
                    _logManager.Info("Task List added");
                }
                catch (TaskListException)
                {
                    _logManager.Error("Task List cannot be created. Information: " + taskList.Id + taskList.Name + taskList.User.Username);
                    throw new TaskListException("Task List cannot be created");
                }
            }
            else
            {
                throw new TaskListException("Task List cannot be created");
            }
        }

        public void CreateTaskListItem(TaskListItem taskListItem)
        {
            ToDoContext dbContext = new ToDoContext();
            int id = taskListItem.TaskList.Id;
            var actualTasklist = dbContext.TaskLists.Where(u => u.Id == id).SingleOrDefault();
            TaskListItem tListItem = new TaskListItem
            {
                Id = taskListItem.Id,
                Text = taskListItem.Text,
                IsCompleted = taskListItem.IsCompleted,
                TaskList = actualTasklist
            };
            if (tListItem.TaskList.User.Id == _securityManager.GetLoggedUserId())
            {
                dbContext.TaskListItems.Add(tListItem);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    _logManager.Error("Task List Item cannot be created. Information: " + taskListItem.Id + taskListItem.Text + taskListItem.TaskList.Name);
                    throw new TaskListItemException("Task List Item cannot be created");
                }
            }
            else
            {
                throw new TaskListItemException("Task List Item cannot be created. Current user doesn't have such a a Task");
            }
        }

        public void DeleteTaskList(TaskList taskList)
        {
            ToDoContext dbContext = new ToDoContext();
            var itemToDelete = dbContext.TaskLists.Where(t => t.Id == taskList.Id).SingleOrDefault();
            int id = itemToDelete.Id;
            List<TaskListItem> taskListItems = dbContext.TaskListItems.Where(n => n.TaskList.Id == id).ToList();

            if (itemToDelete != null && itemToDelete.User.Id == _securityManager.GetLoggedUserId())
            {
                try
                {
                    if (taskListItems != null)
                    {
                        foreach (var row in taskListItems)
                        {
                            dbContext.TaskListItems.Remove(row);
                            dbContext.SaveChanges();
                            _logManager.Info("Task List Item from this Task List deleted" + row.Id);
                        }
                    }
                    dbContext.TaskLists.Remove(itemToDelete);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    _logManager.Error("Task List not deleted");
                    _logManager.Debug("Error task list info: " + itemToDelete.Id + " " + itemToDelete.Name + " " + itemToDelete.User.Id);
                    throw new TaskListException("Task List cannot be deleted");
                }
            }
            else
            {
                throw new TaskListNotFoundException("Task List cannot be deleted. There is no such a a task list or it isn't property of user.");
            }
        }

        public void DeleteTaskListItem(TaskListItem taskListItem)
        {
            ToDoContext dbContext = new ToDoContext();
            int id = taskListItem.Id;
            TaskListItem itemToDelete = dbContext.TaskListItems.Include("TaskList").Where(i => i.Id == id).SingleOrDefault();

            int taskListId = taskListItem.TaskList.Id;
            List<TaskListItem> taskListItems = dbContext.TaskListItems.Where(n => n.TaskList.Id == taskListId).ToList();

            if (taskListItems.Contains(itemToDelete))
            {
                try
                {
                    dbContext.TaskListItems.Remove(itemToDelete);
                    dbContext.SaveChanges();
                    _logManager.Info("Task List Item from this Task List deleted" + itemToDelete.Id);
                }
                catch (Exception)
                {
                    _logManager.Debug("Error task list info: " + itemToDelete.Id + " " + itemToDelete.Text + " " + itemToDelete.TaskList.Id);
                    throw new TaskListItemException("Task List Item cannot be deleted");
                }
            }
            else
            {
                _logManager.Error("Current User doesnt have a Task he wants to delete");
                throw new TaskListItemNotFoundException("Task List Item cannot be deleted. Current user doesnt have specified Task");
            }
        }

        public void UpdateTaskList(TaskList taskList)
        {
            ToDoContext dbContext = new ToDoContext();
            int id = taskList.Id;
            TaskList taskListToUpdate = dbContext.TaskLists.Where(t => t.Id == id).SingleOrDefault();

            if (taskListToUpdate != null && taskListToUpdate.User.Id == _securityManager.GetLoggedUserId())
            {
                try
                {
                    taskListToUpdate.Name = taskList.Name;
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    _logManager.Error("Error updating database with given TaskList");
                    throw new TaskListException("Task List cannot be updated");
                }
            }
            else
            {
                _logManager.Error("Current User doesnt have Task List he wants to update");
                _logManager.Debug("User info: " + _securityManager.GetLoggedUser().Id + " Task List info: " + taskList.Id + " TaskList appropriate User " + _securityManager.GetLoggedUser().Id);
                throw new TaskListNotFoundException("Task List cannot be updated. There is no such a a task list or it isn't property of user. ");
            }
        }

        public void UpdateTaskListItem(TaskListItem taskListItem)
        {
            ToDoContext dbContext = new ToDoContext();

            int id = taskListItem.Id;
            TaskListItem itemToUpdate = dbContext.TaskListItems.Include("TaskList").Where(i => i.Id == id).SingleOrDefault();
            int taskListId = taskListItem.TaskList.Id;
            List<TaskListItem> taskListItems = dbContext.TaskListItems.Where(n => n.TaskList.Id == taskListId).ToList();

            if (taskListItems.Contains(itemToUpdate))
            {
                try
                {
                    itemToUpdate.Text = taskListItem.Text;
                    itemToUpdate.IsCompleted = taskListItem.IsCompleted;
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    _logManager.Error("Error updating database with given Task");
                    throw new TaskListItemException("Task List Item cannot be updated");
                }
            }
            else
            {
                _logManager.Error("Current User doesnt have a Task he wants to update");
                _logManager.Debug("User info: " + _securityManager.GetLoggedUser().Id + " Task List info: " + taskListItem.Id + " TaskList appropriate User " + _securityManager.GetLoggedUser().Id);
                throw new TaskListItemNotFoundException("Task List Item cannot be updated. There is no provided item in this Task List");
            }
        }

        public TaskList GetTaskList(int Id)
        {
            ToDoContext dbContext = new ToDoContext();
            TaskList taskList = dbContext.TaskLists.Include("Items").Where(t => t.Id == Id).SingleOrDefault();
            if (taskList != null && taskList.User.Id == _securityManager.GetLoggedUserId())
            {
                _logManager.Info("Task List returned succesfully");
                return taskList;
            }
            else
            {
                _logManager.Error("Task List Items not returned, there are no Task List Items or it isn't property of actual user");
                throw new TaskListNotFoundException("Task List not found");
            }
        }
    }
}
