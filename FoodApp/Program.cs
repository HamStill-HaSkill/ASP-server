using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FoodApp.Models;


namespace FoodApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new RecipeContext()) {

                //The line below clears and resets the databse.
                context.Database.EnsureDeleted();

                // Create the database if it does not exist
                context.Database.EnsureCreated ();

                // Add some video games. 
                //Note that the Id field is autoincremented by default
                context.Add( new Recipe { Name = "Несквик с пивом", ImageName = "https://memepedia.ru/wp-content/uploads/2019/01/neskvik-s-pivom-mem.jpg", 
                                        Type = "basic",  Description = "Вкусно", Category = "drink", Likes = 10});
                context.Add( new Recipe { Name = "Вода", ImageName = "https://habrastorage.org/webt/dr/t2/0d/drt20dqcbde8mixwozur-22if2e.jpeg", 
                                        Type = "basic",  Description = "Очень вкусно", Category = "drink", Likes = 23});
                context.Add( new Recipe { Name = "Сок", ImageName = "https://www.koolinar.ru/all_image/recipes/140/140004/recipe_4ef47f29-51b7-466e-a7fb-b587a6aa4beb_large.jpg", 
                                        Type = "basic",  Description = "Не вкусно", Category = "drink", Likes = 19});
                
                context.Add( new Recipe { Name = "Курица", ImageName = "https://images11.domashnyochag.ru/upload/img_cache/7ba/7ba76875cfb0a438f97f603b7b6bcfad_cropped_740x537.jpg", 
                                        Type = "basic",  Description = "Сойдет", Category = "food", Likes = 5});
                context.Add( new Recipe { Name = "Пирог", ImageName = "https://e2.edimdoma.ru/data/recipes/0000/4786/4786-ed4_wide.jpg?1484599305", 
                                        Type = "basic",  Description = "Норм", Category = "food", Likes = 15});
                context.Add( new Recipe { Name = "Торт", ImageName = "https://static.1000.menu/img/content/36945/sochnyi-biskvitnyi-tort_1563566405_9_max.jpg", 
                                        Type = "basic",  Description = "Есть пробитие", Category = "food", Likes = 6});
                context.SaveChanges();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
