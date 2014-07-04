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
    public enum AllergyType
    {
        [Display(Name = "Thuốc")]
        Medication = 0,

        [Display(Name = "Thức Ăn")]
        Food = 1,

        [Display(Name = "Môi Trường")]
        Environmental = 2,

        [Display(Name = "Khác")]
        Other = 4
    };

    [Table("Allergy")]
    public class Allergy
    {   
        [Key]
        public int AllergyId { get; set; }

        [ForeignKey("MedicalProfile")]
        public int MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }

        [Display(Name = "Tên dị ứng")]
        public string Name { get; set; }

        [Display(Name = "Loại dị ứng")]
        public AllergyType AllergyType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày bị dị ứng gần nhất")]
        public DateTime DateLastOccurred { get; set; }

        [Display(Name = "Phản ứng")]
        public string Reaction { get; set; }
        public string Note { get; set; }
    }
}
