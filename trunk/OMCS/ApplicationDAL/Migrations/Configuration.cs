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

            SpecialtyField NgoaiKhoa = new SpecialtyField { Name = "Ngoại khoa" };
            SpecialtyField NgoaiTimMach = new SpecialtyField { Name = "Ngoại tim mạch", Parent = NgoaiKhoa };
            SpecialtyField NgoaiLongNguc = new SpecialtyField { Name = "Ngoại lồng ngực", Parent = NgoaiKhoa };
            SpecialtyField NgoaiTieuHoa = new SpecialtyField { Name = "Ngoại tiêu hóa", Parent = NgoaiKhoa };
            SpecialtyField PhauThuaMat = new SpecialtyField { Name = "Phẫu thuật mắt", Parent = NgoaiKhoa };
            SpecialtyField NgoaiTongQuat = new SpecialtyField { Name = "Ngoại tổng quát", Parent = NgoaiKhoa };
            SpecialtyField NgoaiThanKinh = new SpecialtyField { Name = "Ngoại thần kinh", Parent = NgoaiKhoa };
            SpecialtyField PhauThuatMieng = new SpecialtyField { Name = "Phẫu thuật miệng & hàm mặt", Parent = NgoaiKhoa };
            SpecialtyField ChanThuong = new SpecialtyField { Name = "Chấn thương chỉnh hình", Parent = NgoaiKhoa };
            SpecialtyField NoiKhoa = new SpecialtyField { Name = "Nội khoa" };
            SpecialtyField DiUng = new SpecialtyField { Name = "Dị ứng", Parent = NoiKhoa };
            SpecialtyField MienDich = new SpecialtyField { Name = "Miễn dịch học", Parent = NoiKhoa };
            SpecialtyField NoiTimMach = new SpecialtyField { Name = "Nội tim mạch", Parent = NoiKhoa };
            context.SpecialtyFields.Add(NgoaiKhoa);
            context.SpecialtyFields.Add(NgoaiTimMach);
            context.SpecialtyFields.Add(NgoaiLongNguc);
            context.SpecialtyFields.Add(NgoaiTieuHoa);
            context.SpecialtyFields.Add(PhauThuaMat);
            context.SpecialtyFields.Add(NgoaiTongQuat);
            context.SpecialtyFields.Add(NgoaiThanKinh);
            context.SpecialtyFields.Add(PhauThuatMieng);
            context.SpecialtyFields.Add(ChanThuong);
            context.SpecialtyFields.Add(NoiKhoa);
            context.SpecialtyFields.Add(DiUng);
            context.SpecialtyFields.Add(MienDich);
            context.SpecialtyFields.Add(NoiTimMach);

            SpecialtyField NhiKhoa = new SpecialtyField { Name = "Nhi Khoa" };

            User admin = new User { Username = "admin", Email = "admin@ymail.com", FirstName = "Admin", 
                Password = "123456", IsActive = true, Birthday = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow, Roles = new List<Role>() };

            User user2 = new User { Username = "user1", Email = "user1@ymail.com", FirstName = "User1", 
                Password = "123456", IsActive = true, Birthday = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow, Roles = new List<Role>() };
            Doctor user3 = new Doctor { Username = "doctor1", Email = "doctor1@ymail.com", FirstName = "Doctor 1", 
                Password = "123456", IsActive = true, Birthday = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow, SpecialtyField = NhiKhoa,
                Roles = new List<Role>() };

            MedicalProfileType benhAnNgoaiDa = new MedicalProfileType { Name = "Bệnh án Ngoài Da" };
            MedicalProfileTemplate mauCoSan = new MedicalProfileTemplate { IsDefault = true, MedicalProfileType = benhAnNgoaiDa };

            Patient suTran = new Patient
            {
                FirstName = "Su",
                LastName = "Tran",
                Username = "sutran",
                Email = "trannguyentiensu@gmail.com",
                Password = "123456",
                IsActive = true,
                Birthday = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                Roles = new List<Role>(),
                HealthInsuranceDateExpired = DateTime.UtcNow
            };

            context.MedicalProfileTemplates.Add(mauCoSan);
            admin.Roles.Add(role0);
            user2.Roles.Add(role2);
            suTran.Roles.Add(role2);
            user3.Roles.Add(role3);
            context.Users.Add(admin);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Patients.Add(suTran);
        }
    }
}