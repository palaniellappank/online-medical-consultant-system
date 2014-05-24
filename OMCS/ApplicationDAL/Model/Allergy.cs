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
        public int DiUngId { get; set; }

        public AllergyType AllergyType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateLastOccurred { get; set; }
        public string Reaction { get; set; }
        public string Note { get; set; }
    }
}
