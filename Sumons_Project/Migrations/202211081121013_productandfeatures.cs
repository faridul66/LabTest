namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productandfeatures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feature_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_type = c.Int(nullable: false),
                        type_code = c.String(),
                        type_name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Feature_Typeid = c.Int(nullable: false),
                        feature_code = c.String(),
                        feature_name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Feature_Type", t => t.Feature_Typeid, cascadeDelete: true)
                .Index(t => t.Feature_Typeid);
            
            CreateTable(
                "dbo.Product_Type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_type = c.Int(nullable: false),
                        type_code = c.String(),
                        type_name = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product_Typeid = c.Int(nullable: false),
                        product_serial = c.String(),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Product_Type", t => t.Product_Typeid, cascadeDelete: true)
                .Index(t => t.Product_Typeid);
            
            CreateTable(
                "dbo.Unit_Measurement",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        parent_id = c.Int(nullable: false),
                        code = c.String(),
                        name = c.String(),
                        parent_sum = c.Int(nullable: true),
                        status = c.String(),
                        chged_by = c.String(),
                        chgd_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Product_Typeid", "dbo.Product_Type");
            DropForeignKey("dbo.Features", "Feature_Typeid", "dbo.Feature_Type");
            DropIndex("dbo.Products", new[] { "Product_Typeid" });
            DropIndex("dbo.Features", new[] { "Feature_Typeid" });
            DropTable("dbo.Unit_Measurement");
            DropTable("dbo.Products");
            DropTable("dbo.Product_Type");
            DropTable("dbo.Features");
            DropTable("dbo.Feature_Type");
        }
    }
}
