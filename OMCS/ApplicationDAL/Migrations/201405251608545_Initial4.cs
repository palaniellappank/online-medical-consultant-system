namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicalRecordTemplate", "HospitalId", c => c.Int(nullable: false));
            AddForeignKey("dbo.MedicalRecordTemplate", "HospitalId", "dbo.Hospital", "HospitalId", cascadeDelete: true);
            CreateIndex("dbo.MedicalRecordTemplate", "HospitalId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MedicalRecordTemplate", new[] { "HospitalId" });
            DropForeignKey("dbo.MedicalRecordTemplate", "HospitalId", "dbo.Hospital");
            DropColumn("dbo.MedicalRecordTemplate", "HospitalId");
        }
    }
}
