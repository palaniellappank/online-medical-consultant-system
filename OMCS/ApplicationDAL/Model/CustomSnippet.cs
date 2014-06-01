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
    [Table("CustomSnippet")]
    public class CustomSnippet
    {
        [Key]
        public int CustomSnippetId { get; set; }

        [ForeignKey("MedicalProfileTemplate")]
        public int MedicalProfileTemplateId { get; set; }
        public virtual MedicalProfileTemplate MedicalProfileTemplate { get; set; }

	    public string Title { get; set; }

        public virtual ICollection<CustomSnippetField> CustomSnippetFields { get; set; }
    }
}
