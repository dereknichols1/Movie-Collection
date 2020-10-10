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

        [Display(Name = "Movie")]
        public int MovieId { get; set; }

        [Display(Name = "Collections")]
        public int CollectionsId { get; set; }

        [Display(Name = "Movie Format")]
        public string MovieFormat { get; set; }

        [Display(Name = "Item Condition")]
        public string ItemCondition { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [ForeignKey("CollectionsId")]
        public virtual Collections Collections { get; set; }

        [Display(Name = "Users")]
        public string UserId { get; set; }

        public virtual ICollection<UserMovie> UserMovie { get; set; }
    }
}
