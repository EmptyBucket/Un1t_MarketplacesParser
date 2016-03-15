namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemColumsParameters : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Parameters", "PageNumber");
            DropColumn("dbo.Parameters", "RecordsPerPage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parameters", "RecordsPerPage", c => c.Int(nullable: false));
            AddColumn("dbo.Parameters", "PageNumber", c => c.Int(nullable: false));
        }
    }
}
