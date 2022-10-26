using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MVC_test.Models
{
    public class MouseRatingViewModel
    {
        public List<Mice>? Mice { get; set; }
        public SelectList? Ratings { get; set; } 
        public string? MouseRating { get; set; }
        public string? SearchString { get; set; }


    }
}
