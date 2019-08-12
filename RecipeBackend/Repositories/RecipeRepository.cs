using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using RecipeBackend.Models;

namespace RecipeBackend.Repositories
{
    public class RecipeRepository : IRecipeRepository

    {
        private readonly IMongoCollection<RecipeItems> _recipes;

        public RecipeRepository(IMongoDatabase mongoDatabase)
        {
            _recipes = mongoDatabase.GetCollection<RecipeItems>("Recipes");
        }

        public async Task<RecipeItems> StoreRecipe(RecipeItems item)
        {
            await _recipes.InsertOneAsync(item);
            
            return item;
        }

        public async Task<List<RecipeItems>> GetRecipes()
        {
            return await _recipes.Find(_ => true).ToListAsync();
        }
    }
}