using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBackend.Models;
using RecipeBackend.services;

namespace RecipeBackend.Controllers
{
    public class Recipe : Controller
    {
        private readonly IRecipeServices _services;

        public Recipe(IRecipeServices services)
        {
            _services = services;
        }
        
        // Post
        [HttpPost("AddRecipeItems")]
        public async Task<ActionResult<RecipeItems>> AddRecipeItems([FromBody] RecipeItems items)
        {
            if (items == null)
            {
                return NotFound();
            }
            var recipe = _services.AddRecipe(items);
            return await recipe;
        }
        
        // Get
        [HttpGet]
        [Route("GetRecipeItems")]
        public async Task<ActionResult<List<RecipeItems>>> GetRecipeItems()
        {
            var recipe = _services.GetRecipeItems();

            if (recipe == null)
            {
                return NotFound();
            }
            return await recipe;
        }
    }
}