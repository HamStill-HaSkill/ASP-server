using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
 
namespace FoodApp.Models
{
    [NotMapped]
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}