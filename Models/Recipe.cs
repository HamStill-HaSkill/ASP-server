using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class Recipe
    {
        // ID рецепта
        [Key]
        public int Id { get; set; }
        // название рецепта
        public string Name { get; set; }
        // автор рецепта
        public string Author { get; set; }
        // Кол-во Ккал
        public int Energy { get; set; }
        // Тест рецепта
        public string Content { get; set; }
    }
}