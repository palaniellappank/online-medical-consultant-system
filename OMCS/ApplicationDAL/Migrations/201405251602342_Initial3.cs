namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Doctor", "DoctorId");
            DropColumn("dbo.HospitalAdmin", "HospitalAdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalAdmin", "HospitalAdminId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "DoctorId", c => c.Int(nullable: false));
        }
    }
}
