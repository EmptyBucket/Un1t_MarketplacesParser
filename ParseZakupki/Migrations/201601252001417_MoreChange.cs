namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MoreChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostFrom = c.Long(nullable: false),
                        CostTo = c.Long(nullable: false),
                        PageNumber = c.Int(nullable: false),
                        PublishDateFrom = c.DateTime(nullable: false),
                        PublishDateTo = c.DateTime(nullable: false),
                        RecordsPerPage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ZakupkiParameters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ZakupkiParameters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RecordsPerPage = c.Int(nullable: false),
                        CostFrom = c.Long(nullable: false),
                        CostTo = c.Long(nullable: false),
                        PublishDateFrom = c.String(),
                        PublishDateTo = c.String(),
                        Fz44 = c.Boolean(nullable: false),
                        Fz223 = c.Boolean(nullable: false),
                        Fz94 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Parameters");
        }
    }
}
