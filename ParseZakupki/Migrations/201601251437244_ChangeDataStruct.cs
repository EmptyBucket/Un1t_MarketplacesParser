namespace ParseZakupki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataStruct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseInformation", "DateCreated", c => c.String());
            AddColumn("dbo.PurchaseInformation", "DateUpdated", c => c.String());
            AddColumn("dbo.PurchaseInformation", "DateFilling", c => c.String());
            AddColumn("dbo.PurchaseInformation", "SourceLink", c => c.String());
            AddColumn("dbo.PurchaseInformation", "Code", c => c.String());
            DropColumn("dbo.PurchaseInformation", "Created");
            DropColumn("dbo.PurchaseInformation", "Updated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseInformation", "Updated", c => c.String());
            AddColumn("dbo.PurchaseInformation", "Created", c => c.String());
            DropColumn("dbo.PurchaseInformation", "Code");
            DropColumn("dbo.PurchaseInformation", "SourceLink");
            DropColumn("dbo.PurchaseInformation", "DateFilling");
            DropColumn("dbo.PurchaseInformation", "DateUpdated");
            DropColumn("dbo.PurchaseInformation", "DateCreated");
        }
    }
}
