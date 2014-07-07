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

            BasicData.Seed(context);

            if (Admin == null)
            {
                DataPatientInformation.Seed(context);
                DataMedicalRecord.Seed(context);
                DataTreatmentHistory.Seed(context);
            }
        }
    }
}