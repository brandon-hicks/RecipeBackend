using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Models;

namespace RecipeBackend.services
{
    public interface IRecipeServices
    {
        Task<RecipeItems> AddRecipe(RecipeItems items);
        
        Task<List<RecipeItems>> GetRecipeItems();
    }
}