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
    public enum TreatmentHistoryType
    {
        [Description("Qua mạng internet")]
        Online = 0,

        [Description("Trực tiếp")]
        Offline = 1
    };

    [Table("TreatmentHistory")]
    public class TreatmentHistory
    {
        [Key]
        public int TreatmentHistoryId { get; set; }

        [ForeignKey("MedicalProfile")]
        public int MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("DiseaseType")]
        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày khám")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày phát bệnh")]
	    public DateTime OnSetDate { get; set; }

	    public string Note { get; set; }
    }
}
