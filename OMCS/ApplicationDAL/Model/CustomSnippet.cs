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
    public enum SnippetType
    {
        Custom = 0,

        User = 1,

        Patient = 2,

        PersonalHealthRecord = 3
    };

    [Table("CustomSnippet")]
    public class CustomSnippet
    {
        [Key]
        public int CustomSnippetId { get; set; }

        [ForeignKey("MedicalProfileTemplate")]
        public int MedicalProfileTemplateId { get; set; }
        public virtual MedicalProfileTemplate MedicalProfileTemplate { get; set; }

	    public string Title { get; set; }

        public int Position { get; set; }

        public SnippetType SnippetType { get; set; }

        public int SnippetFieldName { get; set; }

        public virtual ICollection<CustomSnippetField> CustomSnippetFields { get; set; }
    }
}
