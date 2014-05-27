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

            modelBuilder.Entity<Conversation>()
            .HasRequired(c => c.Doctor)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<TreatmentHistory>()
            .HasRequired(c => c.DiseaseType)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
         public DbSet<User> Users { get; set; }
         public DbSet<Role> Roles { get; set; }
         public DbSet<Allergy> Allergies { get; set; }
         public DbSet<Conversation> Conversations { get; set; }
         public DbSet<ConversationDetail> ConversationDetails { get; set; }
         public DbSet<TreatmentHistory> TreatmentHistories { get; set; }
         public DbSet<DiseaseType> DiseaseTypes { get; set; }
         public DbSet<Doctor> Doctors { get; set; }
         public DbSet<DynamicField> DynamicFields { get; set; }
         public DbSet<FilmDocument> FilmDocuments { get; set; }
         public DbSet<FilmType> FilmTypes { get; set; }
         public DbSet<Immunization> Immunizations { get; set; }
         public DbSet<MedicalProfile> MedicalProfiles { get; set; }
         public DbSet<MedicalRecordTemplate> MedicalRecordTemplates { get; set; }
         public DbSet<MedicalRecordType> MedicalRecordTypes { get; set; }
         public DbSet<Patient> Patients { get; set; }
         public DbSet<PersonalHealthRecord> PersonalHealthRecords { get; set; }
         public DbSet<SpecialtyField> SpecialtyFields { get; set; }
    }    
}