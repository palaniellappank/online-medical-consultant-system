namespace ApplicationDAL.Migrations
{
    using OMCS.DAL.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<OMCS.DAL.Model.OMCSDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OMCS.DAL.Model.OMCSDBContext context)
        {
            Role role0 = new Role { RoleName = "Admin" };
            Role role1 = new Role { RoleName = "HospitalAdmin" };
            Role role2 = new Role { RoleName = "User" };
            Role role3 = new Role { RoleName = "Doctor" };

            QualifyingDegree BacSi = new QualifyingDegree { Abbrv = "BS.", Name = "Bác Sĩ" };

            Hospital ChoRay = new Hospital { Address = "201B Nguyễn Chí Thanh, Quận 5, TP.HCM", Name = "Bệnh viện Chợ Rẫy" };

            SpecialtyField NhiKhoa = new SpecialtyField { Name = "Nhi Khoa" };

            User user1 = new User { Username = "admin", Email = "admin@ymail.com", FirstName = "Admin", Password = "123456", IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() };
            User user2 = new User { Username = "user1", Email = "user1@ymail.com", FirstName = "User1", Password = "123456", IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() };
            Doctor user3 = new Doctor { Username = "doctor1", Email = "doctor1@ymail.com", FirstName = "Doctor 1", 
                Password = "123456", IsActive = true, 
                Hospital = ChoRay,
                CreatedDate = DateTime.UtcNow, QualifyingDegree = BacSi, SpecialtyField = NhiKhoa,
                Roles = new List<Role>() };
            user1.Roles.Add(role1);
            user2.Roles.Add(role2);
            user3.Roles.Add(role3);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
        }
    }
}
