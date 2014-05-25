namespace ApplicationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ProfilePicture = c.String(),
                        Gender = c.String(),
                        Birthday = c.String(),
                        Phone = c.String(),
                        PrimaryAddress = c.String(),
                        TemporaryAddress = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Hospital",
                c => new
                    {
                        HospitalId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ImageLogo = c.String(),
                    })
                .PrimaryKey(t => t.HospitalId);
            
            CreateTable(
                "dbo.SpecialtyField",
                c => new
                    {
                        SpecialtyFieldId = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SpecialtyFieldId)
                .ForeignKey("dbo.SpecialtyField", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.QualifyingDegree",
                c => new
                    {
                        QualifyingDegreeId = c.Int(nullable: false, identity: true),
                        Abbrv = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.QualifyingDegreeId);
            
            CreateTable(
                "dbo.DiseaseHistory",
                c => new
                    {
                        DiseaseHistoryId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DiseaseTypeId = c.Int(nullable: false),
                        DateCreated = c.String(),
                        OnSetDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Patient_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.DiseaseHistoryId)
                .ForeignKey("dbo.Patient", t => t.PatientId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.DiseaseType", t => t.DiseaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Patient", t => t.Patient_UserId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.DiseaseTypeId)
                .Index(t => t.Patient_UserId);
            
            CreateTable(
                "dbo.DiseaseType",
                c => new
                    {
                        DiseaseTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DiseaseTypeId);
            
            CreateTable(
                "dbo.Allergy",
                c => new
                    {
                        AllergyTypeId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        AllergyType = c.Int(nullable: false),
                        DateLastOccurred = c.DateTime(nullable: false),
                        Reaction = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.AllergyTypeId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.Conversation",
                c => new
                    {
                        ConversationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DateConsulted = c.DateTime(nullable: false),
                        HealthProblem = c.String(),
                        ConditionStatus = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ConversationId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Doctor", t => t.DoctorId)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.ConversationDetail",
                c => new
                    {
                        ConversationDetailId = c.Int(nullable: false, identity: true),
                        ConversationId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConversationDetailId)
                .ForeignKey("dbo.Conversation", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.ConversationId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.DynamicField",
                c => new
                    {
                        DynamicFieldId = c.Int(nullable: false, identity: true),
                        MedicalRecordTemplateId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        FieldType = c.Int(nullable: false),
                        Name = c.String(),
                        Parent_DynamicFieldId = c.Int(),
                    })
                .PrimaryKey(t => t.DynamicFieldId)
                .ForeignKey("dbo.MedicalRecordTemplate", t => t.MedicalRecordTemplateId, cascadeDelete: true)
                .ForeignKey("dbo.DynamicField", t => t.Parent_DynamicFieldId)
                .Index(t => t.MedicalRecordTemplateId)
                .Index(t => t.Parent_DynamicFieldId);
            
            CreateTable(
                "dbo.MedicalRecordTemplate",
                c => new
                    {
                        MedicalRecordTemplateId = c.Int(nullable: false, identity: true),
                        IsDefault = c.Boolean(nullable: false),
                        MedicalRecordTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicalRecordTemplateId)
                .ForeignKey("dbo.MedicalRecordType", t => t.MedicalRecordTypeId, cascadeDelete: true)
                .Index(t => t.MedicalRecordTypeId);
            
            CreateTable(
                "dbo.MedicalRecordType",
                c => new
                    {
                        MedicalRecordTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MedicalRecordTypeId);
            
            CreateTable(
                "dbo.FilmDocument",
                c => new
                    {
                        FilmDocumentId = c.Int(nullable: false, identity: true),
                        MedicalRecordId = c.Int(nullable: false),
                        FilmTypeId = c.Int(nullable: false),
                        FilmTypePosition = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.FilmDocumentId)
                .ForeignKey("dbo.MedicalRecord", t => t.MedicalRecordId, cascadeDelete: true)
                .ForeignKey("dbo.FilmType", t => t.FilmTypeId, cascadeDelete: true)
                .Index(t => t.MedicalRecordId)
                .Index(t => t.FilmTypeId);
            
            CreateTable(
                "dbo.MedicalRecord",
                c => new
                    {
                        MedicalRecordId = c.Int(nullable: false, identity: true),
                        DiseaseTypeId = c.Int(nullable: false),
                        MedicalRecordTemplateId = c.Int(nullable: false),
                        HeartRate = c.String(),
                        Temperature = c.String(),
                        BloodPressure = c.String(),
                        BreathingRate = c.String(),
                        Weight = c.String(),
                        Height = c.String(),
                    })
                .PrimaryKey(t => t.MedicalRecordId)
                .ForeignKey("dbo.DiseaseType", t => t.DiseaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalRecordTemplate", t => t.MedicalRecordTemplateId, cascadeDelete: true)
                .Index(t => t.DiseaseTypeId)
                .Index(t => t.MedicalRecordTemplateId);
            
            CreateTable(
                "dbo.FilmType",
                c => new
                    {
                        FilmTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FilmTypeId);
            
            CreateTable(
                "dbo.Immunization",
                c => new
                    {
                        ImmunizationId = c.Int(nullable: false, identity: true),
                        PatientId = c.Int(nullable: false),
                        Name = c.String(),
                        DateImmunized = c.DateTime(nullable: false),
                        BoosterTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImmunizationId)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.PersonalHealthRecord",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                        EyeColor = c.String(),
                        HairColor = c.String(),
                        BloodType = c.String(),
                        AlcoholPerWeek = c.String(),
                        AlcoholNumOfYear = c.String(),
                        SmokePackPerDay = c.String(),
                        SmokeNumOfYear = c.String(),
                        SportName = c.String(),
                        SportPerWeek = c.String(),
                        ExerciseType = c.String(),
                        ExerciseDayPerWeek = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Patient", t => t.PatientId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        SpecialtyFieldId = c.Int(nullable: false),
                        QualifyingDegreeId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.SpecialtyField", t => t.SpecialtyFieldId, cascadeDelete: true)
                .ForeignKey("dbo.QualifyingDegree", t => t.QualifyingDegreeId, cascadeDelete: true)
                .ForeignKey("dbo.Hospital", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SpecialtyFieldId)
                .Index(t => t.QualifyingDegreeId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.HospitalAdmin",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        HospitalAdminId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Hospital", t => t.HospitalId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                        Ethnicity = c.String(),
                        Nationality = c.String(),
                        Job = c.String(),
                        WhereToWork = c.String(),
                        ContactPerson = c.String(),
                        ContactPersonAddress = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patient", new[] { "UserId" });
            DropIndex("dbo.HospitalAdmin", new[] { "HospitalId" });
            DropIndex("dbo.HospitalAdmin", new[] { "UserId" });
            DropIndex("dbo.Doctor", new[] { "HospitalId" });
            DropIndex("dbo.Doctor", new[] { "QualifyingDegreeId" });
            DropIndex("dbo.Doctor", new[] { "SpecialtyFieldId" });
            DropIndex("dbo.Doctor", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.PersonalHealthRecord", new[] { "PatientId" });
            DropIndex("dbo.Immunization", new[] { "PatientId" });
            DropIndex("dbo.MedicalRecord", new[] { "MedicalRecordTemplateId" });
            DropIndex("dbo.MedicalRecord", new[] { "DiseaseTypeId" });
            DropIndex("dbo.FilmDocument", new[] { "FilmTypeId" });
            DropIndex("dbo.FilmDocument", new[] { "MedicalRecordId" });
            DropIndex("dbo.MedicalRecordTemplate", new[] { "MedicalRecordTypeId" });
            DropIndex("dbo.DynamicField", new[] { "Parent_DynamicFieldId" });
            DropIndex("dbo.DynamicField", new[] { "MedicalRecordTemplateId" });
            DropIndex("dbo.ConversationDetail", new[] { "DoctorId" });
            DropIndex("dbo.ConversationDetail", new[] { "ConversationId" });
            DropIndex("dbo.Conversation", new[] { "DoctorId" });
            DropIndex("dbo.Conversation", new[] { "PatientId" });
            DropIndex("dbo.Allergy", new[] { "PatientId" });
            DropIndex("dbo.DiseaseHistory", new[] { "Patient_UserId" });
            DropIndex("dbo.DiseaseHistory", new[] { "DiseaseTypeId" });
            DropIndex("dbo.DiseaseHistory", new[] { "DoctorId" });
            DropIndex("dbo.DiseaseHistory", new[] { "PatientId" });
            DropIndex("dbo.SpecialtyField", new[] { "ParentId" });
            DropForeignKey("dbo.Patient", "UserId", "dbo.User");
            DropForeignKey("dbo.HospitalAdmin", "HospitalId", "dbo.Hospital");
            DropForeignKey("dbo.HospitalAdmin", "UserId", "dbo.User");
            DropForeignKey("dbo.Doctor", "HospitalId", "dbo.Hospital");
            DropForeignKey("dbo.Doctor", "QualifyingDegreeId", "dbo.QualifyingDegree");
            DropForeignKey("dbo.Doctor", "SpecialtyFieldId", "dbo.SpecialtyField");
            DropForeignKey("dbo.Doctor", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.PersonalHealthRecord", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Immunization", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.MedicalRecord", "MedicalRecordTemplateId", "dbo.MedicalRecordTemplate");
            DropForeignKey("dbo.MedicalRecord", "DiseaseTypeId", "dbo.DiseaseType");
            DropForeignKey("dbo.FilmDocument", "FilmTypeId", "dbo.FilmType");
            DropForeignKey("dbo.FilmDocument", "MedicalRecordId", "dbo.MedicalRecord");
            DropForeignKey("dbo.MedicalRecordTemplate", "MedicalRecordTypeId", "dbo.MedicalRecordType");
            DropForeignKey("dbo.DynamicField", "Parent_DynamicFieldId", "dbo.DynamicField");
            DropForeignKey("dbo.DynamicField", "MedicalRecordTemplateId", "dbo.MedicalRecordTemplate");
            DropForeignKey("dbo.ConversationDetail", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.ConversationDetail", "ConversationId", "dbo.Conversation");
            DropForeignKey("dbo.Conversation", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Conversation", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.Allergy", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.DiseaseHistory", "Patient_UserId", "dbo.Patient");
            DropForeignKey("dbo.DiseaseHistory", "DiseaseTypeId", "dbo.DiseaseType");
            DropForeignKey("dbo.DiseaseHistory", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.DiseaseHistory", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.SpecialtyField", "ParentId", "dbo.SpecialtyField");
            DropTable("dbo.Patient");
            DropTable("dbo.HospitalAdmin");
            DropTable("dbo.Doctor");
            DropTable("dbo.UserRole");
            DropTable("dbo.PersonalHealthRecord");
            DropTable("dbo.Immunization");
            DropTable("dbo.FilmType");
            DropTable("dbo.MedicalRecord");
            DropTable("dbo.FilmDocument");
            DropTable("dbo.MedicalRecordType");
            DropTable("dbo.MedicalRecordTemplate");
            DropTable("dbo.DynamicField");
            DropTable("dbo.ConversationDetail");
            DropTable("dbo.Conversation");
            DropTable("dbo.Allergy");
            DropTable("dbo.DiseaseType");
            DropTable("dbo.DiseaseHistory");
            DropTable("dbo.QualifyingDegree");
            DropTable("dbo.SpecialtyField");
            DropTable("dbo.Hospital");
            DropTable("dbo.Role");
            DropTable("dbo.User");
        }
    }
}
