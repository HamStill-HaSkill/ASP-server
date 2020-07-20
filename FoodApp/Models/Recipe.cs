using System;
using System.ComponentModel.DataAnnotations;


namespace FoodApp.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string ImageName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Likes { get; set; }

    }
}
        // "id":10,
        // "name":"Cappuccino",
        // "imageName":"https://media-cdn.tripadvisor.com/media/photo-s/10/c4/18/a3/cappiccino.jpg",
        // "type":"basic",
        // "description":"Outside of Italy, cappuccino is a coffee drink that today is typically composed of double espresso and hot milk, with the surface topped with foamed milk. Cappuccinos are most often prepared with an espresso macchine. The double espreso os poured into the bottomof the cip, followed by a similar amount of hot milk, which is prepared by heating and texturing the milk using the espresso machine steam wand. The top third of th drink consistes of milk foam; this foam can be decorated with artisticc drawings made with the same milk, called latte art.",
        // "category":"drink",
        // "likes":15