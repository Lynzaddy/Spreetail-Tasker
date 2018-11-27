namespace SpreetailTaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevTasks", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DevTasks", "ParentId");
        }
    }
}
