using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASP.Models;
using Newtonsoft.Json;

namespace ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        // создаем контекст данных
        //readonly RecipeContext db = new RecipeContext();

        [HttpGet]
        public string Buy()
        {
            // db.Recipes.Add(new Recipe { Name = "Несквик с пивом", Author = "Костя", Energy = 220 });
            // db.Recipes.Add(new Recipe { Name = "Космостарс с водкой", Author = "Женя", Energy = 180 });
            // db.Recipes.Add(new Recipe { Name = "Гречка с чаем", Author = "Миша", Energy = 150 });
            // // получаем из бд все объекты Recipe
            // IEnumerable<Recipe> recipes = db.Recipes;

            // возвращаем json
            return JsonConvert.SerializeObject(new Recipe { Name = "Несквик с пивом", Author = "Костя", Energy = 220 });
        }
        [HttpPost]
        public string Buy(FoodOrder order)
        {
            order.Date = DateTime.Now;
            // добавляем информацию о покупке в базу данных
            // db.Orders.Add(order);
            // // сохраняем в бд все изменения
            // db.SaveChanges();
            return "Спасибо, за заказ!";
        }
    }
}
