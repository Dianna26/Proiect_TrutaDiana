using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class RecipesRepository
    {
        public Recipe GetRecipe(Guid recipeID, CookBookContext context)
        {
            return context.Recipes.Where(i => i.ID == recipeID).FirstOrDefault();
        }

        public void AddRecipe(Recipe recipe, CookBookContext context)
        {
            context.Recipes.Add(recipe);
        }
    }
}
