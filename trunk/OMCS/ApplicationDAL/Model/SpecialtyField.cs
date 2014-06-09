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
        [Display(Name="Tên Khoa")]
        public int? ParentId { get; set; }
        public virtual SpecialtyField Parent { get; set; }

        [Display(Name = "Tên Chuyên Khoa")]
        public string Name { get; set; }
    }
}
