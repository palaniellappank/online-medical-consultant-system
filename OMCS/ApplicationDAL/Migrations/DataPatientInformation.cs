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
                    FirstName = "Su", LastName = "Tran", Email = "trannguyentiensu@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, 
                    Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Thôn 1, xa CuEbur, Buôn Ma Thuột", SecondaryAddress = "201/9 Đường Số 9, Gò Vấp",
                    Ethnicity = "Kinh", Nationality = "Việt Nam", Job = "Lập trình viên", WhereToWork = "39B Trường Sơn, Tân Bình",
                    ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt", HealthInsuranceId = "234234VSD",
                    HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "Su.JPG"
                },
                new Patient {
                    FirstName = "Danh", LastName = "Trần Cao", Email = "caodanh@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, 
                    Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Tuấn", LastName = "Mai Anh", Email = "tuanmai@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Lập trình viên", WhereToWork = "FPT Software", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Nguồn", LastName = "Nguyễn Hồng Ngọc", Email = "nguonnguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, Gender = "F", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Nhân", LastName = "Nguyễn Toàn", Email = "nhannguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, Gender = "F", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Tiền gian", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "Hoa Sen", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                },
                new Patient {
                    FirstName = "Lịnh", LastName = "Nguyễn Nhật", Email = "linhnguyen@gmail.com", Password = "123456",
                    IsActive = true, CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {rolePatient}, Gender = "M", Birthday = new DateTime(1992, 2, 19),
                    Phone = "0933056722", PrimaryAddress = "Quảng Ngãi", SecondaryAddress = "Quận 12", Ethnicity = "Kinh", Nationality = "Việt Nam",
                    Job = "Sinh Vien", WhereToWork = "F Soft", ContactPerson = "Mỹ Linh", ContactPersonAddress = "1 Lý Thường Kiệt",
                    HealthInsuranceId = "234234VSD", HealthInsuranceIssued = new DateTime(2013, 1, 1), HealthInsuranceDateExpired = new DateTime(2014, 1, 1),
                    ProfilePicture = "photo.jpg"
                }
            };

            patients.ForEach(s => _db.Patients.AddOrUpdate(p => (p.Email), s));
            _db.SaveChanges();
            Patient suTran = _db.Patients.Where(x => x.Email == "trannguyentiensu@gmail.com").Single();
            Patient danhtran = _db.Patients.Where(x => x.Email == "caodanh@gmail.com").Single();
            Patient tuanMai = _db.Patients.Where(x => x.Email == "tuanmai@gmail.com").Single();
            Patient nguonNguyen = _db.Patients.Where(x => x.Email == "nguonnguyen@gmail.com").Single();
            Patient nhanNguyen = _db.Patients.Where(x => x.Email == "nhannguyen@gmail.com").Single();
            Patient linhNguyen = _db.Patients.Where(x => x.Email == "linhnguyen@gmail.com").Single();

            var personalHealthRecords = new List<PersonalHealthRecord>
            {
                new PersonalHealthRecord
                {
                    PatientId = suTran.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B", AlcoholPerWeek = 1.2,
                    AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2, SportName = "Đá banh", SportPerWeek = 4,
                    ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    PatientId = danhtran.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    PatientId = tuanMai.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Đá banh", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    PatientId = nguonNguyen.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    PatientId = nhanNguyen.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                },
                new PersonalHealthRecord
                {
                    PatientId = linhNguyen.UserId, Height = 170, Weight = 70.5, EyeColor = "Đen", HairColor = "Đen", BloodType = "B",
                    AlcoholPerWeek = 1.2, AlcoholNumOfYear = 4, IsBeer = true, SmokePackPerWeek = 1, SmokeNumOfYear = 2,
                    SportName = "Cầu Lông", SportPerWeek = 4, ExerciseType = "Yoga", ExercisePerWeek = 2
                }
            };

            personalHealthRecords.ForEach(s => _db.PersonalHealthRecords.AddOrUpdate(p => (p.PatientId), s));
            _db.SaveChanges();
        }
    }
}
