using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Lib.Common.Exceptions
{
    //[Serializable]
    public class UserNameNotFoundException : Exception
    {
        public string UserName { get; }

        public UserNameNotFoundException() { }

        public UserNameNotFoundException(string message)
        : base(message) { }

        public UserNameNotFoundException(string message, Exception inner)
      : base(message, inner) { }

        public UserNameNotFoundException(string message, string userName)
            : this(message)
        {
            UserName = userName;
        }

    }
}
