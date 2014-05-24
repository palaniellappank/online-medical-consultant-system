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

        [Description("Nhịp tim")]
        public string HeartRate { get; set; }

        [Description("Thân Nhiệt")]
        public string Temperature { get; set; }

        [Description("Huyết Áp")]
        public string BloodPressure { get; set; }

        [Description("Nhịp Thở")]
        public string BreathingRate { get; set; }

        [Description("Cân Nặng")]
        public string Weight { get; set; }

        [Description("Chiều Cao")]
        public string Height { get; set; }
    }
}
