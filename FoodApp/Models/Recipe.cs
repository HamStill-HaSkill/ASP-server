using System;
using System.ComponentModel.DataAnnotations;


namespace FoodApp.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string ImageName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Likes { get; set; }

    }
}
