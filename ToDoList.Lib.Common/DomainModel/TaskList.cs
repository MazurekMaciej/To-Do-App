using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Lib.Common.DomainModel
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
        public IList<TaskListItem> Items { get; set; }

    }
}
