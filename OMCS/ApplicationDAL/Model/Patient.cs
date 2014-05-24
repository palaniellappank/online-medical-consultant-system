using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string Ethnicity { get; set; }
        public string Nationality { get; set; }
        public string Job { get; set; }
	    public string WhereToWork { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonAddress { get; set; }

        public virtual ICollection<DiseaseHistory> DiseaseHistories { get; set; }
    }
}
