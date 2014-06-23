namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class BasicData
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            Role roleAdmin = new Role { RoleName = "Admin" };
            Role roleUser = new Role { RoleName = "User" };
            Role roleDoctor = new Role { RoleName = "Doctor" };

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
            _db.SpecialtyFields.Add(NgoaiKhoa);
            _db.SpecialtyFields.Add(NgoaiTimMach);
            _db.SpecialtyFields.Add(NgoaiLongNguc);
            _db.SpecialtyFields.Add(NgoaiTieuHoa);
            _db.SpecialtyFields.Add(PhauThuaMat);
            _db.SpecialtyFields.Add(NgoaiTongQuat);
            _db.SpecialtyFields.Add(NgoaiThanKinh);
            _db.SpecialtyFields.Add(PhauThuatMieng);
            _db.SpecialtyFields.Add(ChanThuong);
            _db.SpecialtyFields.Add(NoiKhoa);
            _db.SpecialtyFields.Add(DiUng);
            _db.SpecialtyFields.Add(MienDich);
            _db.SpecialtyFields.Add(NoiTimMach);

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

            Doctor bsNguyenVanA = new Doctor
            {
                Username = "nguyenvana",
                Email = "vana@gmail.com",
                FirstName = "A",
                LastName = "Nguyễn Văn",
                Password = "123456",
                IsActive = true,
                Birthday = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                SpecialtyField = NhiKhoa,
                Roles = new List<Role>()
            };

            Doctor bsTonThatTung = new Doctor
            {
                Username = "tonthattung", Email = "tonthattung@gmail.com", 
                FirstName = "Tùng", LastName = "Tôn Thất", Password = "123456", 
                IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                SpecialtyField = NhiKhoa, Roles = new List<Role>()
            };

            Doctor bsHoDacDi = new Doctor
            {
                Username = "hodacdi", Email = "tonthattung@gmail.com", 
                FirstName = "Di", LastName = "Hồ Đắc", Password = "123456", 
                IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                SpecialtyField = NhiKhoa, Roles = new List<Role>()
            };

            Doctor bsDangVanNgu = new Doctor
            {
                Username = "dangvanngu", Email = "dangvanngu@gmail.com", 
                FirstName = "Ngữ", LastName = "Đặng Văn", Password = "123456", 
                IsActive = true, Birthday = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, 
                SpecialtyField = NhiKhoa, Roles = new List<Role>()
            };

            admin.Roles.Add(roleAdmin);

            user3.Roles.Add(roleDoctor);
            bsNguyenVanA.Roles.Add(roleDoctor);
            bsDangVanNgu.Roles.Add(roleDoctor);
            bsHoDacDi.Roles.Add(roleDoctor);
            bsTonThatTung.Roles.Add(roleDoctor);

            _db.Doctors.Add(user3);
            _db.Doctors.Add(bsNguyenVanA);
            _db.Doctors.Add(bsDangVanNgu);
            _db.Doctors.Add(bsHoDacDi);
            _db.Doctors.Add(bsTonThatTung);

            _db.Users.Add(admin);
            _db.Roles.Add(roleAdmin);
            _db.Roles.Add(roleDoctor);
            _db.Roles.Add(roleUser);
            _db.SaveChanges();
        }
    }
}
