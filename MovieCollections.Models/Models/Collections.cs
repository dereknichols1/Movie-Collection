﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieCollections.Models
{
    public class Collections
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
    }
}