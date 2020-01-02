namespace ToDoList.Lib.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ToDoAppDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        TaskList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TaskLists", t => t.TaskList_Id)
                .Index(t => t.TaskList_Id);
            
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskLists", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TaskListItems", "TaskList_Id", "dbo.TaskLists");
            DropIndex("dbo.TaskLists", new[] { "User_Id" });
            DropIndex("dbo.TaskListItems", new[] { "TaskList_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.TaskLists");
            DropTable("dbo.TaskListItems");
        }
    }
}
