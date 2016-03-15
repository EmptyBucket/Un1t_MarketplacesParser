namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataStruct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marketplace", "DateCreated", c => c.String());
            AddColumn("dbo.Marketplace", "DateUpdated", c => c.String());
            AddColumn("dbo.Marketplace", "DateFilling", c => c.String());
            AddColumn("dbo.Marketplace", "SourceLink", c => c.String());
            AddColumn("dbo.Marketplace", "Code", c => c.String());
            DropColumn("dbo.Marketplace", "Created");
            DropColumn("dbo.Marketplace", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marketplace", "Updated", c => c.String());
            AddColumn("dbo.Marketplace", "Created", c => c.String());
            DropColumn("dbo.Marketplace", "Code");
            DropColumn("dbo.Marketplace", "SourceLink");
            DropColumn("dbo.Marketplace", "DateFilling");
            DropColumn("dbo.Marketplace", "DateUpdated");
            DropColumn("dbo.Marketplace", "DateCreated");
        }
    }
}
