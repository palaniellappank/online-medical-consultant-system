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
            Patient suTran = _db.Patients.Where(pt => pt.Username.Equals("sutran")).Single();
            Doctor doctor1 = _db.Doctors.Where(pt => pt.Username.Equals("doctor1")).Single();
            MedicalProfile suTranMedicalProfile = _db.MedicalProfiles.Where(
                mp => mp.MedicalProfileKey.Equals("OMCS.0000001.01")).FirstOrDefault();

            var diseaseTypes = new List<DiseaseType> 
            {
                new DiseaseType {
                    Name = "Đau lưng"
                },
                new DiseaseType {
                    Name = "Nhức Đầu"
                }
            };
            var diseaseType = diseaseTypes.ElementAt(0);
            diseaseTypes.ForEach(s => _db.DiseaseTypes.AddOrUpdate(p => p.Name, s));
            _db.SaveChanges();
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
            treatmentHistories.ForEach(s => _db.TreatmentHistories.AddOrUpdate(p => p.OnSetDate, s));
            _db.SaveChanges();
        }
    }
}
