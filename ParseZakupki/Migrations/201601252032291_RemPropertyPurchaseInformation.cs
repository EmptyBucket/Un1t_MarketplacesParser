namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemPropertyPurchaseInformation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseInformation", "DateUpdated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseInformation", "DateUpdated", c => c.String());
        }
    }
}
