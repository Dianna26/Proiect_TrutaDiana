using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.DTOs
{
    public class IngredientDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public bool IsLiquid { get; set; }

        public Ingredient ToIngredient()
        {
            return new Ingredient
            {
                ID = ID,
                Name = Name,
                Amount = Amount,
                IsLiquid = IsLiquid,
            };
        }
    }
}