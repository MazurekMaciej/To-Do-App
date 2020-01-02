using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Lib.Common.DomainModel
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Username cannot be longer than 30 characters")]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<TaskList> Items { get; set; }
    }
}
