namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Int_Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_Code = c.String(),
                        Company_Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Chged_by = c.String(),
                        Chged_DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Int_Company");
        }
    }
}
