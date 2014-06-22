namespace OMCS.DAL
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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OMCS.DAL.Model.OMCSDBContext context)
        {
            var Admin = context.Roles.Where(
                role => (role.RoleName.Equals("Admin"))
            ).FirstOrDefault();
            
            DataMedicalRecord.Seed(context);

            if (Admin == null)
            {
                DataPatientInformation dataPatientInformation = new DataPatientInformation();
                dataPatientInformation.Seed(context);
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

                User admin = new User
                {
                    Username = "admin",
                    Email = "admin@ymail.com",
                    FirstName = "Admin",
                    Password = "123456",
                    IsActive = true,
                    Birthday = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    Roles = new List<Role>()
                };

                Doctor user3 = new Doctor
                {
                    Username = "doctor1",
                    Email = "doctor1@ymail.com",
                    FirstName = "Doctor 1",
                    Password = "123456",
                    IsActive = true,
                    Birthday = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    SpecialtyField = NhiKhoa,
                    Roles = new List<Role>()
                };

                MedicalProfileType loaiBenhAnNgoaiDa2 = new MedicalProfileType { Name = "Bệnh án Ngoài Da" };
                MedicalProfileTemplate mauCoSan = new MedicalProfileTemplate { IsDefault = true, MedicalProfileType = loaiBenhAnNgoaiDa2 };

                MedicalProfileTemplate benhAnNgoaiDa = new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Ngoài Da - BV Da Liễu",
                    MedicalProfileType = loaiBenhAnNgoaiDa2
                };
                context.MedicalProfileTemplates.Add(benhAnNgoaiDa);

                context.MedicalProfileTemplates.Add(mauCoSan);
                admin.Roles.Add(role0);
                
                user3.Roles.Add(role3);
                context.Users.Add(admin);
                context.Users.Add(user3);

                MedicalProfileTemplate benhAnTruyenNhiem = new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Truyền Nhiễm"
                };
                MedicalProfileTemplate benhAnNoiKhoa = new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Nội Khoa"
                };
                context.MedicalProfileTemplates.Add(benhAnNoiKhoa);
                context.MedicalProfileTemplates.Add(benhAnTruyenNhiem);
            }
        }
    }
}