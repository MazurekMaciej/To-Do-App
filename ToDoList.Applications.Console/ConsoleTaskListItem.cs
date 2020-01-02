using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using Unity;

namespace ToDoList.Applications.ApplicationConsole
{
    public class ConsoleTaskListItem
    {
        ITaskListManager _taskListManager;
        ConsoleTaskList _consoleTaskList = DependencyResolver.Container.Resolve<ConsoleTaskList>();
        public static int ACTUAL_TASK_LIST_ID { get; set; }

        public ConsoleTaskListItem(ITaskListManager taskListManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
        }

        public void ListTaskListItems()
        {
            try
            {
                TaskList taskList = _taskListManager.GetTaskList(ACTUAL_TASK_LIST_ID);
                List<TaskListItem> listTaskListItems = _taskListManager.ListTaskListItems(taskList);
                Console.Clear();
                Console.WriteLine("Listing available Task List Items: ");
                Console.WriteLine("");
                foreach (var row in listTaskListItems)
                {
                    Console.WriteLine(row.Id + " " + row.Text + " " + row.IsCompleted);
                }
                Console.WriteLine("Done");
                MenuOption.TaskMenu();
            }
            catch
            {
                Console.WriteLine("There is no such a Task List");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                _consoleTaskList.ListTaskLists();
            }
        }

        public void ShowItemsInTaskList()
        {
            Console.WriteLine("Write an ID of Task List you want to open");
            bool input = Int32.TryParse(Console.ReadLine(), out int id);
            ACTUAL_TASK_LIST_ID = id;

            ListTaskListItems();
        }

        public void CreateTaskListItem()
        {
            Console.WriteLine("Write a name for your Task List Item");
            string text = Console.ReadLine();
            Console.WriteLine("Is it Completed? Write yes or no");
            string textCompleted = Console.ReadLine();
            bool Completed = textCompleted.Equals("yes") ? true : false;
            TaskList taskList = _taskListManager.GetTaskList(ACTUAL_TASK_LIST_ID);
            TaskListItem taskListItem = new TaskListItem
            {
                Text = text,
                IsCompleted = Completed,
                TaskList = taskList              
            };
            _taskListManager.CreateTaskListItem(taskListItem);
            Console.WriteLine("Done");
            ListTaskListItems();
        }

        public void UpdateTaskListItem()
        {
            Console.WriteLine("Write an ID of Task Item you want to update");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write a new text for your Task List");
            string text = Console.ReadLine();
            Console.WriteLine("Is it Completed? Write yes or no");
            string textCompleted = Console.ReadLine();
            bool Completed = textCompleted.Equals("yes") ? true : false;
            TaskList taskList = _taskListManager.GetTaskList(ACTUAL_TASK_LIST_ID);
            TaskListItem taskListItem = new TaskListItem
            {
                Id = id,
                Text = text,
                IsCompleted = Completed,
                TaskList = taskList
            };
            try
            {
                _taskListManager.UpdateTaskListItem(taskListItem);
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("There is no such a Task List Item");
            }
            System.Threading.Thread.Sleep(1000);
            ListTaskListItems();
        }

        public void DeleteTaskListItem()
        {
            Console.WriteLine("Write an ID of Task Item you want to delete");
            int id = Int32.Parse(Console.ReadLine());
            TaskList taskList = _taskListManager.GetTaskList(ACTUAL_TASK_LIST_ID);
            TaskListItem taskListItem = new TaskListItem
            {
                Id = id,
                TaskList = taskList
            };
            try
            {
                _taskListManager.DeleteTaskListItem(taskListItem);
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("There is no such a Task List Item");
            }
            System.Threading.Thread.Sleep(1000);
            ListTaskListItems();
        }
    }
}
