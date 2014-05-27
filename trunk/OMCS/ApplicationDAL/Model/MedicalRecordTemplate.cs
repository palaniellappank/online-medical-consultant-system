using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("MedicalRecordTemplate")]
    public class MedicalRecordTemplate
    {
        [Key]
        public int MedicalRecordTemplateId { get; set; }

        public bool IsDefault { get; set; }

        [ForeignKey("MedicalRecordType")]
        public int MedicalRecordTypeId { get; set; }
        public MedicalRecordType MedicalRecordType { get; set; }
    }
}
