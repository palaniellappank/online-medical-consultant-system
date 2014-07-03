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

        [ForeignKey("TreatmentHistory")]
        public int TreatmentHistoryId { get; set; }
        public virtual TreatmentHistory TreatmentHistory { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("FilmType")]
        public int FilmTypeId { get; set; }
        public virtual FilmType FilmType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Kết luận")]
        public string Conclusion { get; set; }

        public int FilmTypePosition { get; set; }

        public string ImagePath { get; set; }
    }
}
