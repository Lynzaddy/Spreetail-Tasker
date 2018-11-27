namespace SpreetailTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTaskTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Developer_Id = c.String(maxLength: 128),
                        Priority_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Developer_Id)
                .ForeignKey("dbo.Priorities", t => t.Priority_Id)
                .Index(t => t.Developer_Id)
                .Index(t => t.Priority_Id);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DevTasks", "Priority_Id", "dbo.Priorities");
            DropForeignKey("dbo.DevTasks", "Developer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DevTasks", new[] { "Priority_Id" });
            DropIndex("dbo.DevTasks", new[] { "Developer_Id" });
            DropTable("dbo.Priorities");
            DropTable("dbo.DevTasks");
        }
    }
}
