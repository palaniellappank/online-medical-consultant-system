﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMCS.DAL.Model
{
    [Table("CustomSnippetField")]
    public class CustomSnippetField
    {
        [Key]
        public int CustomSnippetFieldId { get; set; }

        [ForeignKey("CustomSnippet")]
        public int CustomSnippetId { get; set; }
        public virtual CustomSnippet CustomSnippet { get; set; }

        public string FieldId { get; set; }

        public string FieldName { get; set; }

        public string Type { get; set; }

        public string Label { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }
    }
}
