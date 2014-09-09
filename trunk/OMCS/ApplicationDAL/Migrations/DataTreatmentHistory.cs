namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class DataTreatmentHistory
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            Patient suTran = _db.Patients.Where(pt => pt.Email.Equals("trannguyentiensu@gmail.com")).Single();
            Doctor doctor1 = _db.Doctors.Where(pt => pt.Email.Equals("vana@gmail.com")).Single();

            MedicalProfile suTranMedicalProfile = _db.MedicalProfiles.Where(
                mp => mp.MedicalProfileKey.Equals("OMCS.0000001.01")).FirstOrDefault();

            #region TreatmentHistory

            var treatmentHistories = new List<TreatmentHistory>
            {
                new TreatmentHistory { 
                    DateCreated = DateTime.Now,
                    DoctorId = doctor1.UserId,
                    MedicalProfileId = suTranMedicalProfile.MedicalProfileId,
                    Note = "Bệnh năng",
                    OnSetDate = new DateTime(2014, 5, 1, 8, 20, 40)
                },
                    
                new TreatmentHistory { 
                    DateCreated = DateTime.Now,
                    DoctorId = doctor1.UserId,
                    MedicalProfileId = suTranMedicalProfile.MedicalProfileId,
                    Note = "Bệnh tiến triển bình thường",
                    OnSetDate = new DateTime(2014, 6, 1, 8, 20, 40)
                }
            };
            treatmentHistories.ForEach(s => _db.TreatmentHistories.AddOrUpdate(p => p.DateCreated, s));
            _db.SaveChanges();
            #endregion TreatmentHistory

            var treatmentOne = treatmentHistories.ElementAt(0);

            #region FilmType

            var filmTypes = new List<FilmType>
            {
                new FilmType {
                    Name = "Webcam"
                },
                new FilmType {
                    Name = "X-quang"
                },
                new FilmType {
                    Name = "CT-Scanner"
                },
                new FilmType {
                    Name = "Siêu âm"
                },
                new FilmType {
                    Name = "Nội soi"
                },
                new FilmType {
                    Name = "Xét nghiệm"
                },
                new FilmType {
                    Name = "Khác"
                }
            };
            filmTypes.ForEach(s => _db.FilmTypes.AddOrUpdate(p => p.Name, s));
            var filmTypeOne = filmTypes.ElementAt(0);
            _db.SaveChanges();

            #endregion FilmType

            #region FilmDocument

            var filmDocuments = new List<FilmDocument>
            {
                new FilmDocument {
                    TreatmentHistory = treatmentOne,
                    FilmTypeId = filmTypeOne.FilmTypeId,
                    ImagePath = "viemphoidotucau.gif",
                    Conclusion = "Viêm phổi tụ cầu",
                    DoctorId = doctor1.UserId,
                    DateCreated = DateTime.Now,
                    Description = "Hình ảnh viêm phổi"
                },
                new FilmDocument {
                    TreatmentHistory = treatmentOne,
                    FilmTypeId = filmTypeOne.FilmTypeId,
                    ImagePath = "viem_amydal_cap.jpg",
                    Conclusion = "Viêm amydal cấp",
                    DoctorId = doctor1.UserId,
                    DateCreated = DateTime.Now,
                    Description = "Bệnh nhân bị amydal"
                }
            };

            filmDocuments.ForEach(s => _db.FilmDocuments.AddOrUpdate(p => p.ImagePath, s));

            #endregion FilmDocument

            _db.SaveChanges();
        }
    }
}
