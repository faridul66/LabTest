namespace BJProduction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class macchineupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "Machine_Typeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Machines", "Machine_Typeid");
            AddForeignKey("dbo.Machines", "Machine_Typeid", "dbo.Machine_Type", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Machines", "Machine_Typeid", "dbo.Machine_Type");
            DropIndex("dbo.Machines", new[] { "Machine_Typeid" });
            DropColumn("dbo.Machines", "Machine_Typeid");
        }
    }
}
