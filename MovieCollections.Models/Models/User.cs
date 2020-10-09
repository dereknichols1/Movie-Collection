using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MovieCollections.Models.Models;

namespace MovieCollections.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Movies")]
        public int MovieId { get; set; }

        public virtual ICollection<UserMovie> UserMovie { get; set; }
    }
}
