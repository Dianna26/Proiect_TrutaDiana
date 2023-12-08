using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.DTOs
{
    public class NutritionalValuesDTO
    {
        public int Calories { get; set; }
        public int Proteins { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }

        public NutritionalValues ToNutritionalValues()
        {
            return new NutritionalValues
            {
                Calories = Calories,
                Proteins = Proteins,
                Carbohydrates = Carbohydrates,
                Fats = Fats
            };
        }
    }
}