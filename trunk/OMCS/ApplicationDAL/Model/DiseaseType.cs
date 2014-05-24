using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("DiseaseType")]
    public class DiseaseType
    {
        [Key]
        public int DiseaseTypeId { get; set; }

        public string Name { get; set; }
    }
}
