using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class FoodOrder
    {
        // ID пользователя
        [Key]
        public int UserId { get; set; }
        // имя и фамилия покупателя
        public string Person { get; set; }
        // адрес покупателя
        public string Address { get; set; }
        // ID рецепта
        public int RecipeId { get; set; }
        // Доставка delivery club, яндекс еда и т.д.
        public string Delivery { get; set; }
        // дата покупки
        public DateTime Date { get; set; }
    }
}