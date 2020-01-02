using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Business.Managers;
using ToDoList.Lib.Common;
using Unity;

namespace ToDoList.Applications.ApplicationConsole
{
    class MenuOption
    {
        ConsoleTaskList _taskList = DependencyResolver.Container.Resolve<ConsoleTaskList>();
        ConsoleTaskListItem _taskListItem = DependencyResolver.Container.Resolve<ConsoleTaskListItem>();

        public MenuOption(string itemText, Action itemHandler)
        {
            ItemText = itemText;
            ItemHandler = itemHandler;
        }

        public MenuOption()
        { }

        private string ItemText { get; }
        private Action ItemHandler { get; }
        private bool IsExitOption { get; }

        private List<MenuOption> BuildMainMenu()
        {
            return new List<MenuOption> {
                          new MenuOption("List available task lists.", _taskList.ListTaskLists),
                          new MenuOption("Log out", Exit) };
        }

        private static void DisplayMainMenu(List<MenuOption> options)
        {
            Console.WriteLine("");
            Console.WriteLine("What do you want to do?");
            int optionCount = 1;
            foreach (var option in options)
            {
                Console.WriteLine($"{optionCount++}.{option.ItemText}");
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Good bye");
            Environment.Exit(0);

        }
        private static MenuOption GetMenuSelection(List<MenuOption> options)
        {
            do
            {
                string userChoice = Console.ReadLine();
                if (int.TryParse(userChoice, out int selection) &&
                    selection > 0 &&
                    selection <= options.Count)
                {
                    return options[selection - 1];
                }
                Console.WriteLine("Sorry, Try again");
            }
            while (true);
        }

        public static void MainMenu()
        {
            MenuOption menuOption = new MenuOption();
            var menu = menuOption.BuildMainMenu();
            DisplayMainMenu(menu);
            var menuChoice = GetMenuSelection(menu);
            menuChoice.ItemHandler();

        }

        public static void TaskListMenu()
        {
            MenuOption menuOption = new MenuOption();
            var menu = menuOption.BuildConsoleTaskListMenu();
            DisplayMainMenu(menu);

            var menuChoice = GetMenuSelection(menu);
            menuChoice.ItemHandler();
        }

        public static void TaskMenu()
        {
            MenuOption menuOption = new MenuOption();
            var menu = menuOption.BuildTaskMenu();
            DisplayMainMenu(menu);

            var menuChoice = GetMenuSelection(menu);
            menuChoice.ItemHandler();
        }
        private List<MenuOption> BuildConsoleTaskListMenu()
        {

            return new List<MenuOption> {
                                          new MenuOption("Create a task list.", _taskList.CreateTaskList),
                                          new MenuOption("Update a task list.", _taskList.UpdateTaskList),
                                          new MenuOption("Delete a task list.", _taskList.DeleteTaskList),
                                          new MenuOption("Open Task List", _taskListItem.ShowItemsInTaskList),
                                          new MenuOption("Return to the main menu.", ReturnToTheMainMenu), };

        }

        private List<MenuOption> BuildTaskMenu()
        {
            return new List<MenuOption> {
                                          new MenuOption("Add a new task.", _taskListItem.CreateTaskListItem),
                                          new MenuOption("Update a task.", _taskListItem.UpdateTaskListItem),
                                          new MenuOption("Delete a task.", _taskListItem.DeleteTaskListItem),
                                          new MenuOption("Return to the Task List menu.", ReturnToTaskListMenu), };
        }

        private static void ReturnToTheMainMenu()
        {
            Console.Clear();
            MainMenu();
        }

        private void ReturnToTaskListMenu()
        {
            Console.Clear();
            _taskList.ListTaskLists();
            TaskListMenu();
        }

    }
}
