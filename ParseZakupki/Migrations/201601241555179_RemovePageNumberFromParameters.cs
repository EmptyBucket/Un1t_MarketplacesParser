namespace ParseZakupki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePageNumberFromParameters : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ZakupkiParameters", "PageNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ZakupkiParameters", "PageNumber", c => c.Int(nullable: false));
        }
    }
}
