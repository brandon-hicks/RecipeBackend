using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeBackend.Models;

namespace RecipeBackend.Repositories
{
    public interface IRecipeRepository
    { 
        Task<RecipeItems> StoreRecipe(RecipeItems items);

        Task<List<RecipeItems>> GetRecipes();
    }
}