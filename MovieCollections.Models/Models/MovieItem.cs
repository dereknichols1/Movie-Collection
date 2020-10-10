using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieCollections.Models
{
    public class MovieItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        [Display(Name = "Movie Format")]
        public string MovieFormat { get; set; }

        [Display(Name = "Item Condition")]
        public int ItemCondition { get; set; }

        [Display(Name = "My Rating")]
        public int MyRating { get; set; }

        [Display(Name = "My Comments")]
        public int MyComments { get; set; }

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
