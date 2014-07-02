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

            DataTreatmentHistory.Seed(context);
            
            if (Admin == null)
            {
                BasicData.Seed(context);

                MedicalProfileType loaiBenhAnNgoaiDa2 = new MedicalProfileType { Name = "Bệnh án Ngoài Da" };
                MedicalProfileTemplate mauCoSan = new MedicalProfileTemplate { IsDefault = true, MedicalProfileType = loaiBenhAnNgoaiDa2 };

                MedicalProfileTemplate benhAnNgoaiDa = new MedicalProfileTemplate
                {
                    IsDefault = false,
                    MedicalProfileTemplateName = "Bệnh Án Ngoài Da - BV Da Liễu",
                    MedicalProfileType = loaiBenhAnNgoaiDa2
                };
                context.MedicalProfileTemplates.Add(benhAnNgoaiDa);

                context.MedicalProfileTemplates.Add(mauCoSan);
                

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
                context.SaveChanges();
                DataPatientInformation.Seed(context);
                DataMedicalRecord.Seed(context);
            }
        }
    }
}