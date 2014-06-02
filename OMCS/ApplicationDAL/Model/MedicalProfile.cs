using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("MedicalProfile")]
    public class MedicalProfile
    {
        [Key]
        public int MedicalProfileId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("MedicalProfileTemplate")]
        public int MedicalProfileTemplateId { get; set; }
        public virtual MedicalProfileTemplate MedicalProfileTemplate { get; set; }

        [Display(Name = "Nhịp tim")]
        public string HeartRate { get; set; }

        [Display(Name = "Thân Nhiệt")]
        public string Temperature { get; set; }

        [Display(Name = "Huyết Áp")]
        public string BloodPressure { get; set; }

        [Display(Name = "Nhịp Thở")]
        public string BreathingRate { get; set; }

        [Display(Name = "Cân Nặng")]
        public string Weight { get; set; }

        [Display(Name = "Chiều Cao")]
        public string Height { get; set; }
    }
}
