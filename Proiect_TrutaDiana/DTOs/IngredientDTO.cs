using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.DTOs
{
    public class IngredientDTO
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public bool IsLiquid { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                Name = Name,
                Amount = Amount,
                IsLiquid = IsLiquid,
            };
        }
    }
}