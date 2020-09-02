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
            return Json(_userManager.Users.ToList());
        }

        [HttpPost]
        public async void AddUser()
        {
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            //IdentityUser user = JsonConvert.DeserializeObject<IdentityUser>(body);
            IdentityUser user  = new IdentityUser();
            user.Email = "qwerty";
            await _userManager.CreateAsync(user);
        }
    }

}