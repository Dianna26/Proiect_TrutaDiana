using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class NutritionalValuesRepository
    {
        public NutritionalValues GetNutritionalValues(Guid recipeID, CookBookContext context)
        {
            return context.NutritionalValues.Where(i => i.RecipeID == recipeID).FirstOrDefault();
        }

        public void AddNutritionalValues(NutritionalValues nutritionalValues, CookBookContext context)
        {
            context.NutritionalValues.Add(nutritionalValues);
        }
    }
}
