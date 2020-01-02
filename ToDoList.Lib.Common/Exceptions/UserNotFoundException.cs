using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Lib.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserName { get; }

        public UserNotFoundException() { }

        public UserNotFoundException(string message)
        : base(message) { }

        public UserNotFoundException(string message, Exception inner)
      : base(message, inner) { }

        public UserNotFoundException(string message, string userName)
            : this(message)
        {
            UserName = userName;
        }
    }
}
