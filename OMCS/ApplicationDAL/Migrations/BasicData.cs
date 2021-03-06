﻿namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class BasicData
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            #region HospitalInformation
            var hopsital = new HospitalInformation
            {
                Name = "FPT Hospital",
                Address = "Công viên phần mềm Quang Trung",
                Email = "contact@fpt.edu.vn",
                Fax = "08.53453465",
                Phone = "08.423423434",
                Logo = ""
            };
            _db.HospitalInformations.AddOrUpdate(p => p.Name, hopsital);
            _db.SaveChanges();
            #endregion HospitalInformation

            #region Role

            var roles = new List<Role> {
                new Role { RoleName = "Admin" },
                new Role { RoleName = "User" },
                new Role { RoleName = "Doctor" }
            };
            roles.ForEach(s => _db.Roles.AddOrUpdate(p => p.RoleName, s));
            _db.SaveChanges();

            Role roleAdmin = _db.Roles.Where(x => x.RoleName == "Admin").Single();
            Role roleUser = _db.Roles.Where(x => x.RoleName == "User").Single();
            Role roleDoctor = _db.Roles.Where(x => x.RoleName == "Doctor").Single();

            #endregion Role

            #region SpecialtyField

            var specialtyFieldParents = new List<SpecialtyField>
            {
                new SpecialtyField { Name = "Ngoại khoa" },
                new SpecialtyField { Name = "Nội khoa" },
                new SpecialtyField { Name = "Nhi Khoa" }
            };

            specialtyFieldParents.ForEach(s => _db.SpecialtyFields.AddOrUpdate(p => p.Name, s));
            _db.SaveChanges();
            SpecialtyField NgoaiKhoa = _db.SpecialtyFields.Where(x=>x.Name=="Ngoại khoa").Single();
            SpecialtyField NoiKhoa = _db.SpecialtyFields.Where(x => x.Name == "Nội khoa").Single();

            var specialtyFields = new List<SpecialtyField>
            {
                new SpecialtyField { Name = "Ngoại tim mạch", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Ngoại lồng ngực", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Ngoại tiêu hóa", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Phẫu thuật mắt", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Ngoại tổng quát", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Ngoại thần kinh", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Phẫu thuật miệng & hàm mặt", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Chấn thương chỉnh hình", ParentId = NgoaiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Dị ứng", ParentId = NoiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Miễn dịch học", ParentId = NoiKhoa.SpecialtyFieldId },
                new SpecialtyField { Name = "Nội tim mạch", ParentId = NoiKhoa.SpecialtyFieldId }
            };

            specialtyFields.ForEach(s => _db.SpecialtyFields.AddOrUpdate(p => p.Name, s));
            _db.SaveChanges();

            var NhiKhoa = _db.SpecialtyFields.Where(x=>x.Name=="Nhi Khoa").Single();

            #endregion SpecialtyField

            #region User

            var users = new List<User>
            {
                new User
                {
                    Email = "admin@mail.com", FirstName = "Admin",
                    Password = "123456", IsActive = true, Birthday = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow, Roles = new List<Role>() {roleAdmin},
                    ProfilePicture = "photo.jpg"
                }
            };
            
            users.ForEach(s => _db.Users.AddOrUpdate(p => p.Email, s));
            _db.SaveChanges();

            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Email = "doctor@mail.com", FirstName = "Doctor 1",
                    Password = "123456", IsActive = true, Birthday = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow, SpecialtyField = NhiKhoa,
                    Roles = new List<Role>() {roleDoctor}, ProfilePicture = "photo.jpg"
                },
                new Doctor
                {
                    Email = "vana@gmail.com", FirstName = "A",
                    LastName = "Nguyễn Văn", Password = "123456", IsActive = true,
                    Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow,
                    SpecialtyField = NhiKhoa, Roles = new List<Role>() {roleDoctor},
                    ProfilePicture = "photo.jpg"
                },
                new Doctor
                {
                    Email = "tonthattung@gmail.com", 
                    FirstName = "Tùng", LastName = "Tôn Thất", Password = "123456", 
                    IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                    SpecialtyField = NhiKhoa, Roles = new List<Role>() {roleDoctor},
                    ProfilePicture = "photo.jpg"
                },
                new Doctor
                {
                    Email = "hodacdi@gmail.com", 
                    FirstName = "Di", LastName = "Hồ Đắc", Password = "123456", 
                    IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                    SpecialtyField = NhiKhoa, Roles = new List<Role>() {roleDoctor},
                    ProfilePicture = "photo.jpg"
                },
                new Doctor
                {
                    Email = "dangvanngu@gmail.com", 
                    FirstName = "Ngữ", LastName = "Đặng Văn", Password = "123456", 
                    IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                    SpecialtyField = NhiKhoa, Roles = new List<Role>() {roleDoctor},
                    ProfilePicture = "photo.jpg"
                }

            };
            foreach (var doctor in doctors)
            {
                var existOne = _db.Doctors.Where(x => x.Email.Equals(doctor.Email)).FirstOrDefault();
                if (existOne == null) _db.Doctors.Add(doctor);
            }
            _db.SaveChanges();

            #endregion User
        }
    }
}
