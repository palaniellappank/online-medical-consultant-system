namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;
    using System.Text;
    using System.Threading.Tasks;
    class DataMedicalRecord
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            #region MedicalProfile

            MedicalProfileType loaiBenhAnNgoaiDa2 = new MedicalProfileType { Name = "Bệnh án Ngoài Da" };
            MedicalProfileTemplate mauCoSan = new MedicalProfileTemplate { IsDefault = true, MedicalProfileType = loaiBenhAnNgoaiDa2 };

            MedicalProfileTemplate benhAnNgoaiDa = new MedicalProfileTemplate
            {
                IsDefault = false,
                MedicalProfileTemplateName = "Bệnh Án Ngoài Da - BV Da Liễu",
                MedicalProfileType = loaiBenhAnNgoaiDa2
            };
            _db.MedicalProfileTemplates.Add(benhAnNgoaiDa);

            _db.MedicalProfileTemplates.Add(mauCoSan);


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
            _db.MedicalProfileTemplates.Add(benhAnNoiKhoa);
            _db.MedicalProfileTemplates.Add(benhAnTruyenNhiem);
            _db.SaveChanges();


            #endregion MedicalProfile

            Patient suTran = _db.Patients.Where(pt => pt.Username.Equals("sutran")).Single();


            MedicalProfileType loaiBenhAnNgoaiDa = _db.MedicalProfileTypes.Where(
                mp => mp.Name.Contains("Bệnh án Ngoài Da")
            ).Single();

            MedicalProfileTemplate benhAnNgoaiDa1 = _db.MedicalProfileTemplates.Where(
                mp => mp.MedicalProfileTypeId == loaiBenhAnNgoaiDa.MedicalProfileTypeId
            ).FirstOrDefault();

            List<MedicalProfile> medicalProfiles = new List<MedicalProfile>{
                new MedicalProfile
                {
                    Patient = suTran,
                    CreatedDate = DateTime.UtcNow,
                    MedicalProfileTemplate = benhAnNgoaiDa1,
                    MedicalProfileKey = "OMCS.0000001.01"
                },
                new MedicalProfile
                {
                    Patient = suTran,
                    CreatedDate = DateTime.Today.AddDays(-10),
                    MedicalProfileTemplate = benhAnNgoaiDa1,
                    MedicalProfileKey = "OMCS.0000001.02"
                },
                new MedicalProfile
                {
                    Patient = suTran,
                    CreatedDate = DateTime.Today.AddDays(-5),
                    MedicalProfileTemplate = benhAnNgoaiDa1,
                    MedicalProfileKey = "OMCS.0000001.03"
                }
            };

            medicalProfiles.ForEach(s => _db.MedicalProfiles.AddOrUpdate(p => (p.MedicalProfileKey), s));
            _db.SaveChanges();

            var suTranMedicalProfile = medicalProfiles.ElementAt(0);

            #region Immunization

            var imunizations = new List<Immunization> {
                new Immunization {
                    BoosterTime = 1,
                    MedicalProfileId = suTranMedicalProfile.MedicalProfileId,
                    DateImmunized = new DateTime(1992, 3, 15),
                    Name = "Sởi"
                }
            };

            imunizations.ForEach(s => _db.Immunizations.AddOrUpdate(p => (p.Name), s));
            _db.SaveChanges();
            #endregion Immunization

            #region Allergy

            var allergies = new List<Allergy> {
                new Allergy {
                    Name = "Thuốc kháng sinh",
                    MedicalProfileId = suTranMedicalProfile.MedicalProfileId,
                    AllergyType = AllergyType.Medication,
                    Reaction = "Đau bụng nhẹ",
                    DateLastOccurred = new DateTime(2013,1,1)
                }
            };

            allergies.ForEach(s => _db.Allergies.AddOrUpdate(p => (p.Name), s));
            _db.SaveChanges();
            #endregion Allergy
        }
    }
}
