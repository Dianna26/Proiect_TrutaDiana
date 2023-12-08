using Microsoft.EntityFrameworkCore;
using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class IngredientsRepository
    {
        public async Task<List<Ingredient>> GetIngredients(Guid recipeID, CookBookContext context)
        {
            return await context.Ingredients.Where(i => i.RecipeID == recipeID).ToListAsync();
        }
        public async Task<Ingredient> GetIngredient(Guid ingredientID, CookBookContext context)
        {
            return await context.Ingredients.Where(i => i.ID == ingredientID).FirstOrDefaultAsync();
        }

        public async Task AddIngredients(List<Ingredient> ingredients, CookBookContext context)
        {
            await context.Ingredients.AddRangeAsync(ingredients);
        }

        public async Task UpdateIngredient(Ingredient ingredient, Ingredient updated, CookBookContext context)
        {
            ingredient.Name = updated.Name;
            ingredient.IsLiquid = updated.IsLiquid;
            ingredient.Amount = updated.Amount;

            context.Ingredients.Update(ingredient);
            await context.SaveChangesAsync();
        }

        public void DeleteIngredient(Ingredient ingredient, CookBookContext context)
        {
            context.Ingredients.Remove(ingredient);
        }
    }
}