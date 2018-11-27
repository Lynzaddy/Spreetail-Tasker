namespace SpreetailTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeighnKeyProperties : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DevTasks", name: "Developer_Id", newName: "DeveloperId");
            RenameColumn(table: "dbo.DevTasks", name: "Priority_Id", newName: "PriorityId");
            RenameIndex(table: "dbo.DevTasks", name: "IX_Developer_Id", newName: "IX_DeveloperId");
            RenameIndex(table: "dbo.DevTasks", name: "IX_Priority_Id", newName: "IX_PriorityId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DevTasks", name: "IX_PriorityId", newName: "IX_Priority_Id");
            RenameIndex(table: "dbo.DevTasks", name: "IX_DeveloperId", newName: "IX_Developer_Id");
            RenameColumn(table: "dbo.DevTasks", name: "PriorityId", newName: "Priority_Id");
            RenameColumn(table: "dbo.DevTasks", name: "DeveloperId", newName: "Developer_Id");
        }
    }
}
