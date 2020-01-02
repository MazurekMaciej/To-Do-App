using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common.Exceptions
{
    public class TaskListException : Exception
    {
        public TaskList taskList { get; set; }

        public TaskListException() { }

        public TaskListException(string message)
        : base(message) { }

        public TaskListException(string message, Exception inner)
      : base(message, inner) { }

        public TaskListException(string message, TaskList _taskList)
            : this(message)
        {
            taskList = _taskList;
        }
    }
}
