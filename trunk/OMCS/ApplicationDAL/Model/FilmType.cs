using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{

    [Table("FilmType")]
    public class FilmType
    {        
        [Key]
        public int FilmTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
