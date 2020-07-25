using System;
using System.IO;
using System.Text;
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
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        // создаем контекст данных
        readonly IRecipeContext db;
        public SearchController(IRecipeContext context)
        {
            db = context;
        }

        [HttpPost]
        [Route("Search/JsonStringBody")]
        public string JsonStringBody(string content)
        {
            return content;
        }

        [HttpGet]
        public async Task<JsonResult> Search()
        {   
            var allRecipes = db.Recipes.ToList();

            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            
            var words = body.Split(" ").Where(p => p.Length > 0);
            
            Func<string, bool> IsContains = delegate(string description) 
            { 
                foreach (var word in words)
                {
                    if (description.ToLower().Contains(word.ToLower()))
                        return true;
                }
                return false;
            };

            var suitableRecipes = allRecipes.Where(p => IsContains(p.Description) || IsContains(p.Name));

            Func<Recipe, int> Compare = delegate (Recipe recipe)
            {
                int counter = 0;

                foreach (var word in words)
                {
                    counter += (recipe.Name.Length - recipe.Name.Replace(word, "").Length) / word.Length;
                    counter += (recipe.Description.Length - recipe.Description.Replace(word, "").Length) / word.Length;
                }
                return counter;
            };

            return Json(suitableRecipes.OrderBy(Compare).ToList());
        }

        [HttpGet]
        public JsonResult TopRecipes(int count = -1)
        {   
            var allRecipes = db.Recipes.ToList();
            if (count == -1)
                count = allRecipes.Count();
            return Json(allRecipes.OrderByDescending(u => u.Likes).Take(count));
        }
    }
}