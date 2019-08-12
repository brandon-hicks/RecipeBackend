using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Models;
using RecipeBackend.Repositories;

namespace RecipeBackend.services
{
    public class RecipeServices : IRecipeServices
    {

        private readonly IRecipeRepository _repository;

        public RecipeServices(IRecipeRepository repository)
        {
            _repository = repository;
        }
            
        public async Task<RecipeItems> AddRecipe(RecipeItems items)
        {
            return await _repository.StoreRecipe(items);
            
        }

        public async Task<List<RecipeItems>> GetRecipeItems()
        {
            return await _repository.GetRecipes();
        }
    }
}