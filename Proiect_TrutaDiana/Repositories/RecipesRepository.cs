using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class RecipesRepository
    {
        public async Task<Recipe> GetRecipe(Guid recipeID, CookBookContext context)
        {
            return await context.Recipes.Where(i => i.ID == recipeID)
                .Include(r => r.NutritionalValues)
                .Include(r => r.Ingredients)
                .Include(r => r.Difficulty)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<Recipe>> GetRecipes(CookBookContext context)
        {
            return await context.Recipes
                .Include(r => r.NutritionalValues)
                .Include(r => r.Ingredients)
                .Include(r => r.Difficulty)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddRecipe(Recipe recipe, IngredientsRepository ingredientsRepository, NutritionalValuesRepository nutritionalValuesRepository, CookBookContext context)
        {
            recipe.ID = Guid.NewGuid();

            await context.Recipes.AddAsync(recipe);

            var ingredientList = recipe.Ingredients.ToList();

            foreach (var ingredient in ingredientList)
            {
                ingredient.RecipeID = recipe.ID;
            }

            recipe.NutritionalValues.RecipeID = recipe.ID;

            await ingredientsRepository.AddIngredients(ingredientList, context);
            await nutritionalValuesRepository.AddNutritionalValues(recipe.NutritionalValues, context);
        }

        public async Task UpdateRecipe(Recipe recipe, Recipe updated, CookBookContext context)
        {
            recipe.Name = updated.Name;
            recipe.Steps = updated.Steps;
            recipe.DifficultyID = updated.DifficultyID;
            recipe.Portions = updated.Portions;

            context.Recipes.Update(recipe);
            await context.SaveChangesAsync();
        }

        public async Task DeleteRecipe(Recipe recipe, CookBookContext context)
        {
            context.Recipes.Remove(recipe);
            await context.SaveChangesAsync();
        }
    }
}