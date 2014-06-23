namespace OMCS.DAL
{
    using OMCS.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class DataMedicalRecord
    {
        public static void Seed(OMCS.DAL.Model.OMCSDBContext _db)
        {
            Patient suTran = _db.Patients.Where(pt => pt.Username.Equals("sutran")).Single();


            MedicalProfileType loaiBenhAnNgoaiDa = _db.MedicalProfileTypes.Where(
                mp => mp.Name.Contains("Bệnh án Ngoài Da")
            ).Single();

            MedicalProfileTemplate benhAnNgoaiDa1 = _db.MedicalProfileTemplates.Where(
                mp => mp.MedicalProfileTypeId == loaiBenhAnNgoaiDa.MedicalProfileTypeId
            ).FirstOrDefault();

            MedicalProfile suTranMedicalProfile1 = new MedicalProfile
            {
                Patient = suTran,
                CreatedDate = DateTime.UtcNow,
                MedicalProfileTemplate = benhAnNgoaiDa1,
                MedicalProfileKey = "OMCS.0000001.01"
            };

            MedicalProfile suTranMedicalProfile2 = new MedicalProfile
            {
                Patient = suTran,
                CreatedDate = DateTime.Today.AddDays(-10),
                MedicalProfileTemplate = benhAnNgoaiDa1,
                MedicalProfileKey = "OMCS.0000001.02"
            };

            MedicalProfile suTranMedicalProfile3 = new MedicalProfile
            {
                Patient = suTran,
                CreatedDate = DateTime.Today.AddDays(10),
                MedicalProfileTemplate = benhAnNgoaiDa1,
                MedicalProfileKey = "OMCS.0000001.03"
            };

            _db.MedicalProfiles.Add(suTranMedicalProfile1);
            _db.MedicalProfiles.Add(suTranMedicalProfile2);
            _db.MedicalProfiles.Add(suTranMedicalProfile3);
            _db.SaveChanges();
        }
    }
}
