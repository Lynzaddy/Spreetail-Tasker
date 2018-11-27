namespace SpreetailTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCompleteField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevTasks", "isComplete", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DevTasks", "isComplete");
        }
    }
}
