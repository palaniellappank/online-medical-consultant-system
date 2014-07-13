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
            BasicData.Seed(context);
            DataPatientInformation.Seed(context);
            DataMedicalRecord.Seed(context);
            DataTreatmentHistory.Seed(context);
        }
    }
}