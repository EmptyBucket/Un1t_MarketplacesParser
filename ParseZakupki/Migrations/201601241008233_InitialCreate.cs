namespace ParseZakupki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseInformation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        Created = c.String(),
                        Updated = c.String(),
                        Cost = c.String(),
                        Description = c.String(),
                        SiteId = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchaseInformation");
        }
    }
}
