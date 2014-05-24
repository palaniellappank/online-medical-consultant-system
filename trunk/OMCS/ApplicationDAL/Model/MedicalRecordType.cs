using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("MedicalRecordType")]
    public class MedicalRecordType
    {
        [Key]
        public int MedicalRecordTypeId { get; set; }

        public string Name { get; set; }

    }
}
