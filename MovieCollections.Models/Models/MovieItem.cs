using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieCollections.Models
{
    public class MovieItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }

        [Display(Name = "Movie Format")]
        public string MovieFormat { get; set; }
    }
}
