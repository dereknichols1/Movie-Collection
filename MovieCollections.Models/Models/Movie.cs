using MovieCollections.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieCollections.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public string Image { get; set; }

        [Display(Name = "Genre")]
        public string Genre { get; set; }

        [Display(Name = "Length")]
        public string Length { get; set; }

        [Display(Name = "MPAA Rating")]
        public string Rating { get; set; }

        [Display(Name = "Users")]
        public string UserId { get; set; }

        public virtual ICollection<UserMovie> UserMovie { get; set; }
    }
}
