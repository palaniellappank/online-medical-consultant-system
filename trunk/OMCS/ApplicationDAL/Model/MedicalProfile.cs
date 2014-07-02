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

        [Display(Name = "Mã Bệnh Án")]
        public String MedicalProfileKey { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày Tạo")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("MedicalProfileTemplate")]
        public int MedicalProfileTemplateId { get; set; }
        public virtual MedicalProfileTemplate MedicalProfileTemplate { get; set; }
    }
}
