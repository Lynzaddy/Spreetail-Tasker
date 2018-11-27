namespace SpreetailTaskManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatePriorityTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Priorities (Id, Name) VALUES (1, 'High')");
            Sql("INSERT INTO Priorities (Id, Name) VALUES (2, 'Medium')");
            Sql("INSERT INTO Priorities (Id, Name) VALUES (3, 'Low')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Priority WHERE Id IN (1,2,3,4");
        }
    }
}
