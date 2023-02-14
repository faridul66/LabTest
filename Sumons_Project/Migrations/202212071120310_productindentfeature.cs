namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class productindentfeature : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product_Indent_Feature",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Production_Indentid = c.Int(nullable: false),
                    Featureid = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Features", t => t.Featureid, cascadeDelete: false)
                .ForeignKey("dbo.Production_Indent", t => t.Production_Indentid, cascadeDelete: false)
                .Index(t => t.Production_Indentid)
                .Index(t => t.Featureid);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Product_Indent_Feature", "Production_Indentid", "dbo.Production_Indent");
            DropForeignKey("dbo.Product_Indent_Feature", "Featureid", "dbo.Features");
            DropIndex("dbo.Product_Indent_Feature", new[] { "Featureid" });
            DropIndex("dbo.Product_Indent_Feature", new[] { "Production_Indentid" });
            DropTable("dbo.Product_Indent_Feature");
        }
    }
}
