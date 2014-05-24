using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("SpecialtyField")]
    public class SpecialtyField
    {
        [Key]
        public int SpecialtyFieldId { get; set; }

        [ForeignKey("Parent")]
        public int ParentId { get; set; }
        public SpecialtyField Parent { get; set; }

        public string Name { get; set; }
    }
}
