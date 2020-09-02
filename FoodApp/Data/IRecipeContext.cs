using Microsoft.EntityFrameworkCore;
using FoodApp.Models;

public interface IRecipeContext
{
    DbSet<Recipe> Recipes { get; set; }

}