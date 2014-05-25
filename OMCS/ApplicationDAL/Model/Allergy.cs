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
        [Description("Thuốc")]
        Medication = 0,

        [Description("Thức Ăn")]
        Food = 1,

        [Description("Môi Trường")]
        Environmental = 2,

        [Description("Khác")]
        Other = 4
    };

    [Table("Allergy")]
    public class Allergy
    {   
        [Key]
        public int AllergyTypeId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

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
