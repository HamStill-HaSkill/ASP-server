using System;
using System.IO;
using System.Text;
using System.Text.Json;
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
        public async Task<JsonResult> Search()
        {   
            var allRecipes = db.Recipes.ToList();
            
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            
            Filters filters = JsonConvert.DeserializeObject<Filters>(body);

            var words = new List<string>();
            
            foreach (var item in filters.RequestInfos)
                words.AddRange(item.Words);

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
                    counter += ((recipe.Name.Length - recipe.Name.Replace(word, "").Length) / word.Length) * 5;
                    counter += (recipe.Description.Length - recipe.Description.Replace(word, "").Length) / word.Length;
                }
                return counter;
            };

            return Json(suitableRecipes.OrderBy(Compare).ToList());
        }
    }
}