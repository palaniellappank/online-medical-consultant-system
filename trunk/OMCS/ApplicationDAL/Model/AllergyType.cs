using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OMCS.DAL.Model
{

    [Table("AllergyType")]
    public class AllergyType
    {
        [Key]
        public int AllergyTypeId { get; set; }

        [Display(Name = "Loại dị ứng")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
