using Microsoft.AspNetCore.Mvc;
using Proiect_TrutaDiana.DTOs;
using Proiect_TrutaDiana.Models;
using Proiect_TrutaDiana.Repositories;

namespace Proiect_TrutaDiana.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class NutritionalValuesController : ControllerBase
    {
        private readonly CookBookContext _context;
        private RecipesRepository _recipesRepository;
        private NutritionalValuesRepository _nutritionalValuesRepository;

        public NutritionalValuesController(CookBookContext context, RecipesRepository recipesRepository, NutritionalValuesRepository nutritionalValuesRepository)
        {
            _context = context;
            _recipesRepository = recipesRepository;
            _nutritionalValuesRepository = nutritionalValuesRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NutritionalValues>> GetNutritionalValues(Guid id)
        {
            if (_context == null || _nutritionalValuesRepository == null)
            {
                return Problem("Context and/or Repository not initialized");
            }

            return await _nutritionalValuesRepository.GetNutritionalValues(id, _context);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNutritionalValues(Guid id, NutritionalValuesDTO NutritionalValuesDTO)
        {
            var NutritionalValuesToUpdate = await _nutritionalValuesRepository.GetNutritionalValues(id, _context);

            await _nutritionalValuesRepository.UpdateNutritionalValues(NutritionalValuesToUpdate, NutritionalValuesDTO.ToNutritionalValues(), _context);

            var updated = await _nutritionalValuesRepository.GetNutritionalValues(id, _context);

            return Ok(updated);
        }

    }
}

