using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Lib.Common.DomainModel;

namespace ToDoList.Lib.Common.Exceptions
{
    public class TaskListNotFoundException : TaskListException
    {
        public TaskListNotFoundException() { }

        public TaskListNotFoundException(string message)
        : base(message) { }

        public TaskListNotFoundException(string message, Exception inner)
      : base(message, inner) { }

        public TaskListNotFoundException(string message, TaskList _taskList)
            : this(message)
        {
            taskList = _taskList;
        }
    }
}
