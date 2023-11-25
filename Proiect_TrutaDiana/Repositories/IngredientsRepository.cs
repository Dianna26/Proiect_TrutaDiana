using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class IngredientsRepository
    {
        public List<Ingredient> GetIngredients(Guid recipeID, CookBookContext context)
        {
            return context.Ingredients.Where(i => i.RecipeID == recipeID).ToList();
        }

        public void AddIngredients(Ingredient ingredients, CookBookContext context)
        {
            context.Ingredients.Add(ingredients);
        }
    }
}
