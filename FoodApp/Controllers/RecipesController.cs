using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using FoodApp.Models;
using System.Web;
using Newtonsoft.Json;


namespace FoodApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : Controller
    {
        // создаем контекст данных
        readonly IRecipeContext db;
        public RecipesController(IRecipeContext context)
        {
            db = context;
        }
        [HttpGet]
        public IEnumerable<Recipe> TopRate(int count)
        {                
            var allRecipes = db.Recipes.ToList();
            if (count <= allRecipes.Count())
            {
                var sortedRecipes = allRecipes.OrderByDescending(u => u.Likes);
                string answer = JsonConvert.SerializeObject(sortedRecipes.Take(count));
                return sortedRecipes.Take(count);
            }
            else 
            {
                return allRecipes.Take(0);
            }
        }

        [HttpPost]
        public string AddRecipes()
        {
            // db.SaveChangesAsync();
            return "OK";
        }
    }
}
