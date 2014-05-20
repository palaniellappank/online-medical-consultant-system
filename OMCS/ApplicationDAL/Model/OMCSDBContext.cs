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
         }
         public DbSet<User> Users { get; set; }
         public DbSet<Role> Roles { get; set; }
    }

    
}