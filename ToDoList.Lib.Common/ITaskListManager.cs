using System.Collections.Generic;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common
{
    public interface ITaskListManager
    {
        void CreateTaskList(TaskList taskList);
        void UpdateTaskList(TaskList taskList);
        void DeleteTaskList(TaskList taskList);
        List<TaskList> ListTaskLists(User user);
        TaskList GetTaskList(int Id);

        void CreateTaskListItem(TaskListItem taskListItem);
        void UpdateTaskListItem(TaskListItem taskListItem); 
        void DeleteTaskListItem(TaskListItem taskListItem);
        List<TaskListItem> ListTaskListItems(TaskList taskList);

    }
}
