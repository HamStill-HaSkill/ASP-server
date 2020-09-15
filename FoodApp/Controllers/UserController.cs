using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodApp.Data;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using FoodApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace FoodApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;
        
        public UserController(UserManager<IdentityUser> manager)
        {
            _userManager = manager;
        }
        [HttpGet]
        public JsonResult AllUsers()
        {            
            var lis = _userManager.Users.ToList();
            return Json(lis);
        }

        [HttpGet]
        public async void AddUser()
        {
            //  using (var context = new ApplicationDbContext()) {

            //     //The line below clears and resets the databse.
            //     context.Database.EnsureDeleted();
            //     UserStore<IdentityUser> store = new UserStore<IdentityUser>(context);
            //     //UserManager<IdentityUser> manager = new UserManager<IdentityUser>(store, new IdentityOptions(), new PasswordHasher<IdentityUser>());

            //     // Create the database if it does not exist
            //     context.Database.EnsureCreated ();

            //     // Add some video games.
            //     //Note that the Id field is autoincremented by default
            //     context.SaveChanges();

            //     //var allRecipes = context.Recipes.ToList();
            // }
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            //IdentityUser user = JsonConvert.DeserializeObject<IdentityUser>(body);
            IdentityUser user = new IdentityUser { Email = "model.Email", UserName = "model.Email"};
            await _userManager.CreateAsync(user, "asdasd23323SAaS!!as");

        }
    }

}