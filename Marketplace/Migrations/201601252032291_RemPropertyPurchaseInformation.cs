namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemPropertyMarketplace : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Marketplace", "DateUpdated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marketplace", "DateUpdated", c => c.String());
        }
    }
}
