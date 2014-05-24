using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OMCS.DAL.Model
{
    public class OMCSDBContext : DbContext
    {

        public OMCSDBContext()
            : base("DefaultConnection")
         {
 
         }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users)
            .Map(m =>
            {
                m.ToTable("UserRole");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });

            modelBuilder.Entity<DiseaseHistory>()
            .HasRequired(c => c.Patient)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<OnlineSession>()
            .HasRequired(c => c.Doctor)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Role> Roles { get; set; }
         public DbSet<Allergy> Allergies { get; set; }
         public DbSet<DiseaseType> DiseaseTypes { get; set; }
         public DbSet<QualifyingDegree> QualifyingDegree { get; set; }
         public DbSet<SpecialtyField> SpecialtyField { get; set; }
         public DbSet<Doctor> Doctors { get; set; }
         public DbSet<DynamicField> DynamicFields { get; set; }
         public DbSet<FilmDocument> FilmDocuments { get; set; }
         public DbSet<FilmType> FilmTypes { get; set; }
         public DbSet<Immunization> Immunizations { get; set; }
         public DbSet<MedicalRecord> MedicalRecords { get; set; }
         public DbSet<MedicalRecordTemplate> MedicalRecordTemplates { get; set; }
         public DbSet<MedicalRecordType> MedicalRecordTypes { get; set; }
         public DbSet<OnlineSession> OnlineSessions { get; set; }
         public DbSet<Patient> Patients { get; set; }
         public DbSet<DiseaseHistory> DiseaseHistories { get; set; }
         public DbSet<PersonalHealthRecord> PersonalHealthRecords { get; set; }
    }

    
}