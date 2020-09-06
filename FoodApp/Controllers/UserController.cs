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
            return Json("sad");
        }

        [HttpGet]
        public async void AddUser()
        {
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