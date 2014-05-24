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
    [Table("DiseaseHistory")]
    public class DiseaseHistory
    {
        [Key]
        public int DiseaseHistoryId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("DiseaseType")]
        public int DiseaseTypeId { get; set; }
        public virtual DiseaseType DiseaseType { get; set; }

        public string DateCreated { get; set; }

        [Description("Ngày bắt đầu")]
	    public string OnSetDate { get; set; }
	    public string Note { get; set; }
    }
}
