using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
 
namespace FoodApp.Models
{
    public class RecipeContext : DbContext, IRecipeContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recipesdb;Username=postgres;Password=admin");
            //optionsBuilder.UseNpgsql("Host=ec2-34-248-165-3.eu-west-1.compute.amazonaws.com;Port=5432;Database=d42j281e5r55i1;Username=mmxijvzarxyhhr;Password=25d2409423549477e113c0dd7793ca0a84ecf6fa157e790f112af79dd56bae8b;Trust Server Certificate=True;sslmode=require");
        }
    }
}