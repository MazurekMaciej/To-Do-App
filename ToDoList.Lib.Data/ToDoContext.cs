using ToDoList.Lib.Common.DomainModel;
using System.Data.Entity;

namespace ToDoList.Lib.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=ToDoDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ToDoContext, Migrations.Configuration>());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }
        public virtual DbSet<TaskListItem> TaskListItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
