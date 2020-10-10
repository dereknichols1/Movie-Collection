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

        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        [ForeignKey("MovieItemId")]
        public virtual MovieItem MovieItem { get; set; }

    }
}
