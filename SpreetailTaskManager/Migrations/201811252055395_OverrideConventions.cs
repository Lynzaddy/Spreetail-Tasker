namespace SpreetailTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DevTasks", "Developer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DevTasks", "Priority_Id", "dbo.Priorities");
            DropIndex("dbo.DevTasks", new[] { "Developer_Id" });
            DropIndex("dbo.DevTasks", new[] { "Priority_Id" });
            AlterColumn("dbo.DevTasks", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.DevTasks", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.DevTasks", "Developer_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DevTasks", "Priority_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Priorities", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.DevTasks", "Developer_Id");
            CreateIndex("dbo.DevTasks", "Priority_Id");
            AddForeignKey("dbo.DevTasks", "Developer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DevTasks", "Priority_Id", "dbo.Priorities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DevTasks", "Priority_Id", "dbo.Priorities");
            DropForeignKey("dbo.DevTasks", "Developer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DevTasks", new[] { "Priority_Id" });
            DropIndex("dbo.DevTasks", new[] { "Developer_Id" });
            AlterColumn("dbo.Priorities", "Name", c => c.String());
            AlterColumn("dbo.DevTasks", "Priority_Id", c => c.Byte());
            AlterColumn("dbo.DevTasks", "Developer_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.DevTasks", "Description", c => c.String());
            AlterColumn("dbo.DevTasks", "Title", c => c.String());
            CreateIndex("dbo.DevTasks", "Priority_Id");
            CreateIndex("dbo.DevTasks", "Developer_Id");
            AddForeignKey("dbo.DevTasks", "Priority_Id", "dbo.Priorities", "Id");
            AddForeignKey("dbo.DevTasks", "Developer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
