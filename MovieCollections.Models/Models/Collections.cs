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

        public string UserId { get; set; }

        [Display(Name = "Collection Name")]
        public string CollectionName { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
