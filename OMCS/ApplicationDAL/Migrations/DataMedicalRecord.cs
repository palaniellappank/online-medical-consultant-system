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

            List<MedicalProfileType> medicalProfileTypes = new List<MedicalProfileType>{
                new MedicalProfileType
                {
                    Name = "Bệnh án Ngoài Da"
                }
            };

            medicalProfileTypes.ForEach(s => _db.MedicalProfileTypes.AddOrUpdate(p => (p.Name), s));
            _db.SaveChanges();

            MedicalProfileType loaiBenhAnNgoaiDa2 = _db.MedicalProfileTypes.FirstOrDefault();


            List<MedicalProfileTemplate> medicalProfileTemplates = new List<MedicalProfileTemplate>{
                //Default medical profile
                new MedicalProfileTemplate
                {
                    IsDefault = true, MedicalProfileType = loaiBenhAnNgoaiDa2,
                    MedicalProfileTemplateName = "Bệnh Án Mẫu"
                },
                new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Ngoài Da - BV Da Liễu",
                    MedicalProfileType = loaiBenhAnNgoaiDa2
                },
                new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Truyền Nhiễm"
                },
                new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Nội Khoa"
                },
                
            };

            medicalProfileTemplates.ForEach(s => _db.MedicalProfileTemplates.
                AddOrUpdate(p => (p.MedicalProfileTemplateName), s));
            _db.SaveChanges();


            #endregion MedicalProfile

            Patient suTran = _db.Patients.Where(pt => pt.Email.Equals("trannguyentiensu@gmail.com")).Single();

            Doctor doctor1 = _db.Doctors.Where(pt => pt.Email.Equals("doctor@mail.com")).Single();

            MedicalProfileTemplate benhAnNgoaiDa1 = _db.MedicalProfileTemplates.Find(1);

            List<MedicalProfile> medicalProfiles = new List<MedicalProfile>{
                new MedicalProfile
                {
                    PatientId = suTran.UserId,
                    DoctorId = doctor1.UserId,
                    CreatedDate = DateTime.UtcNow,
                    MedicalProfileTemplateId = benhAnNgoaiDa1.MedicalProfileTemplateId,
                    MedicalProfileKey = "OMCS.0000001.01"
                },
                new MedicalProfile
                {
                    PatientId = suTran.UserId,
                    DoctorId = doctor1.UserId,
                    CreatedDate = DateTime.Today.AddDays(-10),
                    MedicalProfileTemplateId = benhAnNgoaiDa1.MedicalProfileTemplateId,
                    MedicalProfileKey = "OMCS.0000001.02"
                },
                new MedicalProfile
                {
                    PatientId = suTran.UserId,
                    DoctorId = doctor1.UserId,
                    CreatedDate = DateTime.Today.AddDays(-5),
                    MedicalProfileTemplateId = benhAnNgoaiDa1.MedicalProfileTemplateId,
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

            var allergyTypes = new List<AllergyType>
            {
                new AllergyType {
                    Name = "Thuốc",
                    Description = "Dị ứng với các loại thuốc"
                },
                new AllergyType {
                    Name = "Thức Ăn"
                },
                new AllergyType {
                    Name = "Môi Trường"
                },
                new AllergyType {
                    Name = "Khác"
                }
            };

            allergyTypes.ForEach(s => _db.AllergyTypes.AddOrUpdate(p => (p.Name), s));
            _db.SaveChanges();

            var allergyTypeThuoc = allergyTypes.Where(x => x.Name == "Thuốc").Single();

            var allergies = new List<Allergy> {
                new Allergy {
                    Name = "Thuốc kháng sinh",
                    MedicalProfileId = suTranMedicalProfile.MedicalProfileId,
                    AllergyTypeId = allergyTypeThuoc.AllergyTypeId,
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
