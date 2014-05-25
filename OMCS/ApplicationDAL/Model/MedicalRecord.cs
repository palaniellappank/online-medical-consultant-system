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
    [Table("MedicalRecord")]
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }

        [ForeignKey("DiseaseType")]
        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }

        [ForeignKey("MedicalRecordTemplate")]
        public int MedicalRecordTemplateId { get; set; }
        public virtual MedicalRecordTemplate MedicalRecordTemplate { get; set; }

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
