using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("QualifyingDegree")]
    public class QualifyingDegree
    {
        [Key]
        public int QualifyingDegreeId { get; set; }
	    public string Abbrv { get; set; }
        public string Name { get; set; }
    }
}
