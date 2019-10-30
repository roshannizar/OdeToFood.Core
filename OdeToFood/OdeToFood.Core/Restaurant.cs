using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}