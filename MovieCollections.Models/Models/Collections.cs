using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieCollections.Models
{
    public class Collections
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Movie Item")]
        public int MovieItemId { get; set; }

        [Display(Name = "Item Condition")]
        public int ItemCondition { get; set; }

        [Display(Name = "My Rating")]
        public int MyRating { get; set; }

        [Display(Name = "My Comments")]
        public int MyComments { get; set; }

        [ForeignKey("MovieItemId")]
        public virtual MovieItem MovieItem { get; set; }

    }
}
