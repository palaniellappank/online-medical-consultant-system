using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [ForeignKey("SpecialtyField")]
        public int SpecialtyFieldId { get; set; }
        public virtual SpecialtyField SpecialtyField { get; set; }

        [ForeignKey("QualifyingDegree")]
        public int QualifyingDegreeId { get; set; }
        public virtual QualifyingDegree QualifyingDegree { get; set; }
    }
}
