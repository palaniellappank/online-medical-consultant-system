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

    [Table("FilmType")]
    public class FilmType
    {
        [Key]
        public int FilmTypeId { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập thông tin này", AllowEmptyStrings = true)]
        [Display(Name = "Tên")]
        public string Name { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
