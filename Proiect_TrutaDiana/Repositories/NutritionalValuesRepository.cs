using Microsoft.EntityFrameworkCore;
using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class NutritionalValuesRepository
    {
        public async Task<NutritionalValues> GetNutritionalValues(Guid recipeID, CookBookContext context)
        {
            return await context.NutritionalValues.Where(i => i.RecipeID == recipeID).FirstOrDefaultAsync();
        }

        public async Task AddNutritionalValues(NutritionalValues nutritionalValues, CookBookContext context)
        {
            await context.NutritionalValues.AddAsync(nutritionalValues);
        }

        public async Task<NutritionalValues> UpdateNutritionalValues(NutritionalValues nutritionalValues, CookBookContext context)
        {
            context.NutritionalValues.Update(nutritionalValues);

            return await GetNutritionalValues(nutritionalValues.RecipeID, context);
        }

        public void DeleteNutritionalValues(NutritionalValues nutritionalValues, CookBookContext context)
        {
            context.NutritionalValues.Remove(nutritionalValues);
        }
    }
}