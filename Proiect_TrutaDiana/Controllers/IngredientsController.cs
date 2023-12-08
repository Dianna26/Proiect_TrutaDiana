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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<IngredientDTO>>> GetIngredients(Guid id)
        {
            if (_context == null || _recipesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            var ingredients = await _ingredientsRepository.GetIngredients(id, _context);

            if (ingredients == null)
            {
                return NotFound();
            }

            var result = new List<IngredientDTO>();
            
            foreach(var ingredient in ingredients)
            {
                result.Add(ingredient.ToIngredientDTO());
            }

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredients(Guid id, List<IngredientDTO> ingredientDTOList)
        {
            var ingredientList = await _ingredientsRepository.GetIngredients(id, _context);

            foreach(var ingredient in ingredientDTOList.Zip(ingredientList, (dto, item) => (Dto: dto, Item: item)))
            {
                await _ingredientsRepository.UpdateIngredient(ingredient.Item, ingredient.Dto.ToIngredient(), _context);
            }


            var updated = await _ingredientsRepository.GetIngredients(id, _context);

            return Ok();
        }
    }
}
