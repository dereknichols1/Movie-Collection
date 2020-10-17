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

        public int MovieId { get; set; }

        public int CollectionsId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Movie Format")]
        public string MovieFormat { get; set; }

        [Display(Name = "Item Condition")]
        public string ItemCondition { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [ForeignKey("CollectionsId")]
        public virtual Collections Collections { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
