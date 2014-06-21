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

            var rolePatient = context.Roles.Where(role => role.RoleName.Equals("User")).FirstOrDefault();

            Patient danhtran = new Patient
            {
                FirstName = "Danh", LastName = "Trần Cao", Username = "danhtran", Email = "caodanh@gmail.com", Password = "123456",
                IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "M", Birthday = new DateTime(1992, 2, 19),
                Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
            };

            PersonalHealthRecord danhtranHealthRecord = new PersonalHealthRecord
            {
                Patient = danhtran, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
            };

            Patient tuanMai = new Patient
            {
                FirstName = "Tuấn", LastName = "Mai Anh", Username = "tuanmai", Email = "tuanmai@gmail.com", Password = "123456",
                IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "M", Birthday = new DateTime(1992, 2, 19),
                Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
            };

            PersonalHealthRecord tuanMaiHealthRecord = new PersonalHealthRecord
            {
                Patient = tuanMai, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
            };

            Patient nguonNguyen = new Patient
            {
                FirstName = "Nguồn", LastName = "Nguyễn Hồng Ngọc", Username = "nguonnguyen", Email = "nguonnguyen@gmail.com", Password = "123456",
                IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "F", Birthday = new DateTime(1992, 2, 19),
                Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
            };

            PersonalHealthRecord nguonNguyenHealthRecord = new PersonalHealthRecord
            {
                Patient = nguonNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
            };

            Patient nhanNguyen = new Patient
            {
                FirstName = "Nhân", LastName = "Nguyễn Toàn", Username = "nhannguyen", Email = "nhannguyen@gmail.com", Password = "123456",
                IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "F", Birthday = new DateTime(1992, 2, 19),
                Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
            };

            PersonalHealthRecord nhanNguyenHealthRecord = new PersonalHealthRecord
            {
                Patient = nhanNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
            };
            
            Patient linhNguyen = new Patient
            {
                FirstName = "Lịnh", LastName = "Nguyễn Nhật", Username = "linhnguyen", Email = "linhnguyen@gmail.com", Password = "123456",
                IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "M", Birthday = new DateTime(1992, 2, 19),
                Phone = "0933056722", PrimaryAddress = "Quảng Ngãi", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                Job = "Sinh Vien", WhereToWork = "F Soft", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
            };

            PersonalHealthRecord linhNguyenHealthRecord = new PersonalHealthRecord
            {
                Patient = linhNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
            };

            context.PersonalHealthRecords.Add(danhtranHealthRecord);
            danhtran.Roles.Add(rolePatient);
            context.Patients.Add(danhtran);

            tuanMai.Roles.Add(rolePatient);
            context.Patients.Add(tuanMai);
            context.PersonalHealthRecords.Add(tuanMaiHealthRecord);

            nguonNguyen.Roles.Add(rolePatient);
            context.Patients.Add(nguonNguyen);
            context.PersonalHealthRecords.Add(nguonNguyenHealthRecord);

            linhNguyen.Roles.Add(rolePatient);
            context.Patients.Add(linhNguyen);
            context.PersonalHealthRecords.Add(linhNguyenHealthRecord);

            nhanNguyen.Roles.Add(rolePatient);
            context.Patients.Add(nhanNguyen);
            context.PersonalHealthRecords.Add(nhanNguyenHealthRecord);

            if (Admin == null)
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
                    CreatedDate = DateTime.UtcNow,
                    Roles = new List<Role>(),
                    Gender = "M",
                    Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722",
                    PrimaryAddress = "Thôn 1, xa CuEbur, Buôn Ma Thuột",
                    SecondaryAddress = "201/9 Đường Số 9, Gò Vấp",
                    Ethnicity = "Kinh",
                    Nationality = "Việt Nam",
                    Job = "Lập trình viên",
                    WhereToWork = "39B Trường Sơn, Tân Bình",
                    ContactPerson = "Mỹ Linh",
                    ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD",
                    HealthInsuranceIssued = new DateTime(2013, 1, 1),
                    HealthInsuranceDateExpired = new DateTime(2014, 1, 1)
                };

                PersonalHealthRecord sutranHealthRecord = new PersonalHealthRecord
                {
                    Patient = suTran,
                    Height = 170,
                    Weight = 70.5,
                    EyeColor = "Đen",
                    HairColor = "Đen",
                    BloodType = "B",
                    AlcoholPerWeek = 1.2,
                    AlcoholNumOfYear = 4,
                    IsBeer = true,
                    SmokePackPerWeek = 1,
                    SmokeNumOfYear = 2,
                    SportName = "Đá banh",
                    SportPerWeek = 4,
                    ExerciseType = "Yoga",
                    ExercisePerWeek = 2
                };
                context.PersonalHealthRecords.Add(sutranHealthRecord);

                context.MedicalProfileTemplates.Add(mauCoSan);
                admin.Roles.Add(role0);
                suTran.Roles.Add(role2);
                user3.Roles.Add(role3);
                context.Users.Add(admin);
                context.Users.Add(user3);
                context.Patients.Add(suTran);

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