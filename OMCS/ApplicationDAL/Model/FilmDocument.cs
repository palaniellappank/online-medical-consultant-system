using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("FilmDocument")]
    public class FilmDocument
    {
        [Key]
        public int FilmDocumentId { get; set; }

        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("FilmType")]
        public int FilmTypeId { get; set; }
        public virtual FilmType FilmType { get; set; }

        public int FilmTypePosition { get; set; }

        public string ImagePath { get; set; }
    }
}
