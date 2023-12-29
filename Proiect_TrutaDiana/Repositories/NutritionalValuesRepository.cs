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
            await context.SaveChangesAsync();
        }

        public async Task<NutritionalValues> UpdateNutritionalValues(NutritionalValues nutritionalValues, NutritionalValues updated, CookBookContext context)
        {
            nutritionalValues.Calories = updated.Calories;
            nutritionalValues.Proteins = updated.Proteins;
            nutritionalValues.Carbohydrates = updated.Carbohydrates;
            nutritionalValues.Fats = updated.Fats;

            context.NutritionalValues.Update(nutritionalValues);
            await context.SaveChangesAsync();
            return await GetNutritionalValues(nutritionalValues.RecipeID, context);

        }

        public async Task DeleteNutritionalValues(NutritionalValues nutritionalValues, CookBookContext context)
        {
            context.NutritionalValues.Remove(nutritionalValues);
            await context.SaveChangesAsync();
        }
    }
}