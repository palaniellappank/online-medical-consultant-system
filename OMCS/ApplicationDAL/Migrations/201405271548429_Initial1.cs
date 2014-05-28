namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicalProfile", "DiseaseTypeId", "dbo.DiseaseType");
            DropIndex("dbo.MedicalProfile", new[] { "DiseaseTypeId" });
            DropColumn("dbo.MedicalProfile", "DiseaseTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicalProfile", "DiseaseTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.MedicalProfile", "DiseaseTypeId");
            AddForeignKey("dbo.MedicalProfile", "DiseaseTypeId", "dbo.DiseaseType", "DiseaseTypeId", cascadeDelete: true);
        }
    }
}
