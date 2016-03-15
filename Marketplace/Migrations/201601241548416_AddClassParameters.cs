namespace ParseZakupki.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddClassParameters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ZakupkiParameters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PageNumber = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ZakupkiParameters");
        }
    }
}
