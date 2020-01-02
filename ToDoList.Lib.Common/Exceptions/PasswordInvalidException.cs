using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Lib.Common.Exceptions
{
    public class PasswordInvalidException : Exception
    {
        public string Password { get; }

        public PasswordInvalidException() { }

        public PasswordInvalidException(string message)
        : base(message) { }

        public PasswordInvalidException(string message, Exception inner)
      : base(message, inner) { }

        public PasswordInvalidException(string message, string password)
            : this(message)
        {
            Password = password;
        }
    }
}
