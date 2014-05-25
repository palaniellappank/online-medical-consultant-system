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
    [Table("Hospital")]
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ImageLogo { get; set; }
    }
}
