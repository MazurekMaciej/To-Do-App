using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using ToDoList.Lib.Common.DomainModel;
using Unity;

namespace ToDoList.Applications.ApplicationConsole
{
    public class ConsoleTaskList
    {
        ISecurityManager _securityManager;
        ITaskListManager _taskListManager;

        public ConsoleTaskList(ITaskListManager taskListManager, ISecurityManager securityManager)
        {
            _taskListManager = taskListManager ?? throw new ArgumentNullException(nameof(taskListManager));
            _securityManager = securityManager ?? throw new ArgumentNullException(nameof(securityManager));
        }

        public void ListTaskLists()
        {
            User user = _securityManager.GetLoggedUser();
            Console.Clear();
            Console.WriteLine("Listing available Task Lists: ");
            Console.WriteLine("");
            List<TaskList> listTaskList = _taskListManager.ListTaskLists(user);

            foreach (var row in listTaskList)
            {
                Console.WriteLine(row.Id + " " + row.Name);
            }
            Console.WriteLine("Done");
            MenuOption.TaskListMenu();
        }

        public void CreateTaskList()
        {
            Console.WriteLine("Write a name for your Task List");
            string name = Console.ReadLine();
            TaskList taskList = new TaskList
            {
                Name = name,
                User = _securityManager.GetLoggedUser(),                         
            };
            try
            {
                _taskListManager.CreateTaskList(taskList);
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("Task List not created, you did something wrong");
            }
            System.Threading.Thread.Sleep(1000);
            ListTaskLists();
        }

        public void UpdateTaskList()
        {
            Console.WriteLine("Write an ID of Task List you want to update");
            int id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write a new name for your Task List");
            string name = Console.ReadLine();

            TaskList taskList = new TaskList
            {
                Id = id,
                Name = name,
            };
            try
            {
                _taskListManager.UpdateTaskList(taskList);
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("Task List not updated, you did something wrong");
            }
            System.Threading.Thread.Sleep(1000);
            
            ListTaskLists();
        }

        public void DeleteTaskList()
        {
            Console.WriteLine("Write an ID of Task List you want to delete");
            int id = Int32.Parse(Console.ReadLine());
            TaskList taskList = new TaskList
            {
                Id = id,
                User = _securityManager.GetLoggedUser()
            };

            try
            {
                _taskListManager.DeleteTaskList(taskList);
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("There is no such a Task List ");
            }
            System.Threading.Thread.Sleep(1000);
            ListTaskLists();
        }

    }
}
