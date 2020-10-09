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

        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
