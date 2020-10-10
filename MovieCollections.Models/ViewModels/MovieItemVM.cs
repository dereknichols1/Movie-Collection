using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.Models.ViewModels
{
    public class MovieItemVM
    {
        public MovieItem MovieItem { get; set; }

        public IEnumerable<SelectListItem> MovieList { get; set; }
        public IEnumerable<SelectListItem> CollectionsList { get; set; }
    }
}
