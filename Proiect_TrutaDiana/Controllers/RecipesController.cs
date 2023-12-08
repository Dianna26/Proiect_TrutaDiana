using Microsoft.AspNetCore.Mvc;
using Proiect_TrutaDiana.DTOs;
using Proiect_TrutaDiana.Models;
using Proiect_TrutaDiana.Repositories;

namespace Proiect_TrutaDiana.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly CookBookContext _context;
        private RecipesRepository _recipesRepository;
        private IngredientsRepository _ingredientsRepository;
        private NutritionalValuesRepository _nutritionalValuesRepository;

        public RecipesController(CookBookContext context, RecipesRepository recipesRepository, IngredientsRepository ingredientsRepository, NutritionalValuesRepository nutritionalValuesRepository)
        {
            _context = context;
            _recipesRepository = recipesRepository;
            _ingredientsRepository = ingredientsRepository;
            _nutritionalValuesRepository = nutritionalValuesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipes()
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            return await _recipesRepository.GetRecipes(_context);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(Guid id)
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var recipe = await _recipesRepository.GetRecipe(id, _context);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, RecipeUpdateDTO recipeUpdateDTO)
        {
            var recipeToUpdate = await _recipesRepository.GetRecipe(id, _context);

            await _recipesRepository.UpdateRecipe(recipeToUpdate, recipeUpdateDTO.ToRecipe(), _context);

            var updated = await _recipesRepository.GetRecipe(id, _context);

            return Ok(recipeUpdateDTO.ToRecipeUpdateDTO(updated));
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe(RecipeDTO recipeDTO)
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var recipe = recipeDTO.ToRecipe();

            await _recipesRepository.AddRecipe(recipe, _ingredientsRepository, _nutritionalValuesRepository, _context);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipe.ID }, recipe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}