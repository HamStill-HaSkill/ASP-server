using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
 
namespace FoodApp.Models
{
    public class RecipeContext : DbContext, IRecipeContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recipesdb;Username=postgres;Password=Filthgrinder666");
        }
    }
}