namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctor", "QualifyingDegreeId", "dbo.QualifyingDegree");
            DropIndex("dbo.Doctor", new[] { "QualifyingDegreeId" });
            DropColumn("dbo.Doctor", "QualifyingDegreeId");
            DropTable("dbo.QualifyingDegree");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QualifyingDegree",
                c => new
                    {
                        QualifyingDegreeId = c.Int(nullable: false, identity: true),
                        Abbrv = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QualifyingDegreeId);
            
            AddColumn("dbo.Doctor", "QualifyingDegreeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctor", "QualifyingDegreeId");
            AddForeignKey("dbo.Doctor", "QualifyingDegreeId", "dbo.QualifyingDegree", "QualifyingDegreeId", cascadeDelete: true);
        }
    }
}
