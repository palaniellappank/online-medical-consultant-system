using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("OnlineSession")]
    public class OnlineSession
    {
        [Key]
        public int OnlineSessionId { get; set; }

        [ForeignKey("DiseaseHistory")]
        public int DiseaseHistoryId { get; set; }
        public virtual DiseaseHistory DiseaseHistory { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public string DateConsulted { get; set; }
        public string HealthProblem { get; set; }
        public string ConditionStatus { get; set; }
        public string Note { get; set; }
    }
}
