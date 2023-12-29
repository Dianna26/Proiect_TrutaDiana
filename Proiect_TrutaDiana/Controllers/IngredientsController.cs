using Microsoft.AspNetCore.Mvc;
using Proiect_TrutaDiana.DTOs;
using Proiect_TrutaDiana.Models;
using Proiect_TrutaDiana.Repositories;

namespace Proiect_TrutaDiana.Controllers
{

    [Route("/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly CookBookContext _context;
        private RecipesRepository _recipesRepository;
        private IngredientsRepository _ingredientsRepository;

        public IngredientsController(CookBookContext context, RecipesRepository recipesRepository, IngredientsRepository ingredientsRepository)
        {
            _context = context;
            _recipesRepository = recipesRepository;
            _ingredientsRepository = ingredientsRepository;
        }

        [HttpGet("ingredients/{recipeId}")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredients(Guid recipeId)
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var ingredients = await _ingredientsRepository.GetIngredients(recipeId, _context);

            if (ingredients == null)
            {
                return NotFound();
            }

            var result = new List<IngredientDTO>();

            foreach (var ingredient in ingredients)
            {
                result.Add(ingredient.ToIngredientDTO());
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDTO>> GetIngredient(Guid id)
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var ingredient = await _ingredientsRepository.GetIngredient(id, _context);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient.ToIngredientDTO();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(Guid id, IngredientDTO ingredientDTO)
        {

            var ingredient = await _ingredientsRepository.GetIngredient(id, _context);

            await _ingredientsRepository.UpdateIngredient(ingredient, ingredientDTO.ToIngredient(), _context);

            var updated = await _ingredientsRepository.GetIngredients(id, _context);

            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Ingredient>> AddIngredient(IngredientDTO ingredientDTO, Guid id)
        {
            if (_context == null || _ingredientsRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var ingredient = ingredientDTO.ToIngredient();
            ingredient.RecipeID = id;

            await _ingredientsRepository.AddIngredient(ingredient, _context);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredient", new { id = ingredient.ID }, ingredient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
