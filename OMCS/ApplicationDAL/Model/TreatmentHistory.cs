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
        [Display(Name = "Online")]
        Online = 0,

        [Display(Name = "Trực tiếp")]
        Offline = 1
    };

    [Table("TreatmentHistory")]
    public class TreatmentHistory
    {
        [Key]
        public int TreatmentHistoryId { get; set; }

        [ForeignKey("MedicalProfile")]
        public int? MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public TreatmentHistoryType TreatmentHistoryType { get; set; }

        [ForeignKey("Doctor")]
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Display(Name = "Triệu chứng")]
        public string Symptom { get; set; }

        [Display(Name = "Chẩn đoán")]
        public string Diagnosis { get; set; }

        [Display(Name = "Phương pháp điều trị")]
        public string Treatment { get; set; }

        [Display(Name = "Tình trạng điều trị")]
        public string Condition { get; set; }
        
        [Display(Name = "Nhịp tim")]
        public string HeartRate { get; set; }

        [Display(Name = "Thân Nhiệt")]
        public string Temperature { get; set; }

        [Display(Name = "Huyết Áp")]
        public string BloodPressure { get; set; }

        [Display(Name = "Nhịp Thở")]
        public string BreathingRate { get; set; }
        

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày khám")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày phát bệnh")]
	    public DateTime OnSetDate { get; set; }

        [Display(Name = "Ghi chú")]
	    public string Note { get; set; }

        public virtual ICollection<FilmDocument> FilmDocuments { get; set; }
    }
}
