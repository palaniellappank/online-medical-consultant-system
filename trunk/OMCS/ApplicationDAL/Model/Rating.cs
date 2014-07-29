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
    public enum RatingType
    {
        Doctor = 0
    };

    [Table("Rating")]
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public double RatingPoint { get; set; }
        public RatingType RatingFor { get; set; }
        public int ObjectId { get; set; }
    }
}
