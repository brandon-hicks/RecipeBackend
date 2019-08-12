using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecipeBackend.Models
{
    public class RecipeItems    
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public string Name { get; set; }
        public List<Ingrediance> Ingrediants { get; set; }
        public List<string> Directions { get; set; }
        
        public RecipeItems()
        {
            Name = "";
            Ingrediants = new List<Ingrediance>();
            Directions = new List<string>();
        }
    }
}