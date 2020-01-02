using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common.Exceptions
{
    public class TaskListItemNotFoundException : TaskListItemException
    {

        public TaskListItemNotFoundException() { }

        public TaskListItemNotFoundException(string message)
        : base(message) { }

        public TaskListItemNotFoundException(string message, Exception inner)
      : base(message, inner) { }

        public TaskListItemNotFoundException(string message, TaskListItem _taskListItem)
            : this(message)
        {
            taskListItem = _taskListItem;
        }
    }
}
