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
        SignInManager<IdentityUser> _signInManager;
        private String GetStatusCode()
        {
            return "401";
        }
        
        public UserController(UserManager<IdentityUser> manager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public JsonResult AllUsers()
        {            
            var lis = _userManager.Users.ToList();
            return Json(lis);
        }

        [HttpPost]
        public async Task<IActionResult> Register()
        {
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            IdentityUser user = JsonConvert.DeserializeObject<IdentityUser>(body);
            var result = await _userManager.CreateAsync( user, "asdasd23323SAaS!!as");
            if (result.Succeeded)
            {
                return StatusCode(200);
            }
            else 
            {
                return StatusCode(403);  
            }

        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string body = "";
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                body = await reader.ReadToEndAsync();
            }
            IdentityUser user = JsonConvert.DeserializeObject<IdentityUser>(body);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, "asdasd23323SAaS!!as", false, false);
            if (result.Succeeded)
            {
                return StatusCode(200);
            }
            else 
            {
                return StatusCode(401);  
            }
        }
    }

}