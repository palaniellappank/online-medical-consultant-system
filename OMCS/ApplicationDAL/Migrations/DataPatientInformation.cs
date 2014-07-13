using OMCS.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace OMCS.DAL
{
    class DataPatientInformation
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            var rolePatient = _db.Roles.Where(role => role.RoleName.Equals("User")).FirstOrDefault();

            var patients = new List<Patient> 
            {
                new Patient {
                    FirstName = "Su", LastName = "Tran", Username = "sutran", Email = "trannguyentiensu@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, 
                    Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Thôn 1, xa CuEbur, Buôn Ma Thuột", SecondaryAddress = "201/9 Đường Số 9, Gò Vấp",
                    Ethnicity = "Kinh", Nationality = "Việt Nam", Job = "Lập trình viên", WhereToWork = "39B Trường Sơn, Tân Bình",
                    ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt", HealthInsuranceId = "234234VSD",
                    HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "Su.JPG"
                },
                new Patient {
                    FirstName = "Danh", LastName = "Trần Cao", Username = "danhtran", Email = "caodanh@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, 
                    Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Tuấn", LastName = "Mai Anh", Username = "tuanmai", Email = "tuanmai@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Nguồn", LastName = "Nguyễn Hồng Ngọc", Username = "nguonnguyen", Email = "nguonnguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "F", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Nhân", LastName = "Nguyễn Toàn", Username = "nhannguyen", Email = "nhannguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "F", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Lịnh", LastName = "Nguyễn Nhật", Username = "linhnguyen", Email = "linhnguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>(), Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Quảng Ngãi", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "F Soft", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                }
            };

            patients.ForEach(s => _db.Patients.AddOrUpdate(p => (p.Username), s));
            _db.SaveChanges();
            Patient suTran = patients.Where(x => x.Username == "sutran").Single();
            Patient danhtran = patients.Where(x => x.Username == "danhtran").Single();
            Patient tuanMai = patients.Where(x => x.Username == "tuanmai").Single();
            Patient nguonNguyen = patients.Where(x => x.Username == "nguonnguyen").Single();
            Patient nhanNguyen = patients.Where(x => x.Username == "nhannguyen").Single();
            Patient linhNguyen = patients.Where(x => x.Username == "linhnguyen").Single();

            var personalHealthRecords = new List<PersonalHealthRecord>
            {
                new PersonalHealthRecord
                {
                    Patient = suTran, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B", AlcoholPerWeek = 1.2,
                    AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2, SportName = "Đá banh", SportPerWeek = 4,
                    ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    Patient = danhtran, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    Patient = tuanMai, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    Patient = nguonNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    Patient = nhanNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    Patient = linhNguyen, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                }
            };

            personalHealthRecords.ForEach(s => _db.PersonalHealthRecords.AddOrUpdate(p => (p.PatientId), s));
            _db.SaveChanges();
        }
    }
}
