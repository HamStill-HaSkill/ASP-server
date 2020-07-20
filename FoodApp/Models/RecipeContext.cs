using Microsoft.EntityFrameworkCore;
 
namespace FoodApp.Models
{
    public class RecipeContext : DbContext, IRecipeContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Specify the path of the database here
            optionsBuilder.UseSqlite("Filename=./sqlite.sqlite");
        }
    }
}