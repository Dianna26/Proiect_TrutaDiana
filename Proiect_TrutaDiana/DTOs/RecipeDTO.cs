using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.DTOs
{
    public class RecipeDTO
    {
        public string Name { get; set; }
        public IEnumerable<IngredientDTO> Ingredients { get; set; }
        public string Steps { get; set; }
        public NutritionalValuesDTO NutritionalValues { get; set; }
        public int Portions { get; set; }
        public int DifficultyID { get; set; }

        public Recipe ToRecipe()
        {
            var ingredients = new List<Ingredient>();

            foreach (var ingredient in Ingredients)
            {
                ingredients.Add(ingredient.ToIngredient());
            }

            return new Recipe
            {
                Name = Name,
                Ingredients = ingredients,
                Steps = Steps,
                NutritionalValues = NutritionalValues.ToNutritionalValues(),
                Portions = Portions,
                DifficultyID = DifficultyID
            };
        }
    }

    public class RecipeUpdateDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Steps { get; set; }
        public int Portions { get; set; }
        public int DifficultyID { get; set; }

        public Recipe ToRecipe()
        {
            return new Recipe
            {
                ID = ID,
                Name = Name,
                Steps = Steps,
                Portions = Portions,
                DifficultyID = DifficultyID
            };
        }

        public RecipeUpdateDTO ToRecipeUpdateDTO(Recipe recipe)
        {
            return new RecipeUpdateDTO
            {
                ID = recipe.ID,
                Name = recipe.Name,
                Steps = recipe.Steps,
                Portions = recipe.Portions,
                DifficultyID = recipe.DifficultyID
            };
        }
    }

    public class RecipeEditDTO
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Steps { get; set; }
        public int Portions { get; set; }
        public int DifficultyID { get; set; }

        public Recipe ToRecipe(Recipe existingRecipe)
        {

            existingRecipe.Name = Name;
            existingRecipe.Steps = Steps;
            existingRecipe.Portions = Portions;
            existingRecipe.DifficultyID = DifficultyID;
         
            return existingRecipe;
        }

        public RecipeEditDTO ToRecipeEditDTO(Recipe recipe)
        {

            return new RecipeEditDTO
            {
                ID = recipe.ID,
                Name = recipe.Name,
                Steps = recipe.Steps,
                Portions = recipe.Portions,
                DifficultyID = recipe.DifficultyID

            };
        }
    }
}