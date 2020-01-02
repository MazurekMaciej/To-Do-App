using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common.Exceptions
{
    public class TaskListItemException : Exception
    {
        public TaskListItem taskListItem { get; set; }

        public TaskListItemException() { }

        public TaskListItemException(string message)
        : base(message) { }

        public TaskListItemException(string message, Exception inner)
      : base(message, inner) { }

        public TaskListItemException(string message, TaskListItem _taskListItem)
            : this(message)
        {
            taskListItem = _taskListItem;
        }
    }
}
