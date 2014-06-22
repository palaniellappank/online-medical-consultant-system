using OMCS.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMCS.Web.DTO
{
    public class PatientInformation
    {
        public Patient Patient { get; set; }
        public PersonalHealthRecord PersonalHealthRecord { get; set; }
        public List<MedicalProfile> MedicalProfiles { get; set; }
    }
}