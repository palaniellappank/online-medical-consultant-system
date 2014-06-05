using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Immunization")]
    public class Immunization
    {
        [Key]
        public int ImmunizationId { get; set; }

        [ForeignKey("MedicalProfile")]
        public int MedicalProfileId { get; set; }
        public virtual MedicalProfile MedicalProfile { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tiêm chủng")]
        public DateTime DateImmunized { get; set; }

        [Display(Name = "Lần tiêm chủng")]
        public int BoosterTime { get; set; }
    }
}
