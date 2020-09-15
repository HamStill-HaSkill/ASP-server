using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FoodApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using FoodApp.Data;
public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Ensure that the database exists and all pending migrations are applied.
        //context.Database.Migrate();

        // Create admin user
        await userManager.CreateAsync(new IdentityUser() { UserName = "info@example.com", Email = "info@example.com"}, "asdasd23323SAaS!!as");

        // Ensure admin privileges
        //IdentityUser admin = await userManager.FindByEmailAsync("info@example.com");
    }
}