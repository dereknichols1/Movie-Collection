using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieCollections.Models
{
    public class UserMovie
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
