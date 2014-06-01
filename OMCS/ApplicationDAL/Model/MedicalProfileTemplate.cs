using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("MedicalProfileTemplate")]
    public class MedicalProfileTemplate
    {
        [Key]
        public int MedicalProfileTemplateId { get; set; }

        public bool IsDefault { get; set; }

        [ForeignKey("MedicalProfileType")]
        public int MedicalProfileTypeId { get; set; }
        public MedicalProfileType MedicalProfileType { get; set; }
    }
}
