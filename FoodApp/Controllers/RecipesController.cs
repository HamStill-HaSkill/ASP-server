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
    [Route("[controller]/[action]")]
    public class RecipesController : Controller
    {
        // создаем контекст данных
        readonly IRecipeContext db;
        public RecipesController(IRecipeContext context)
        {
            db = context;
        }

        //[Route("Recipes/AllRecipes")]
        [HttpGet]
        public JsonResult AllRecipes()
        {                
            return Json(db.Recipes.ToList());
        }

        //[Route("Recipes/TopRecipes")]
        [HttpGet]
        public JsonResult TopRecipes(int count = -1)
        {   
            var allRecipes = db.Recipes.ToList();
            if (count == -1)
                count = allRecipes.Count();
            return Json(allRecipes.OrderByDescending(u => u.Likes).Take(count));
        }

        //[Route("Recipes/AllKind")]
        [HttpGet]
        public JsonResult AllKind(string kind)
        {                
            return Json(db.Recipes.ToList().Where(u => u.Category == kind));
        }
        
        //[Route("Recipes/AllKind")]
        [HttpGet]
        public JsonResult TopKind(int count = -1, string kind = "food")
        {
            var allRecipes = db.Recipes.ToList().Where(u => u.Category == kind);
            if (count == -1)
                count = allRecipes.Count();
            return Json(allRecipes.OrderByDescending(u => u.Likes).Take(count));
        }

        [HttpPost]
        public void AddRecipes()
        {
        }
    }
}