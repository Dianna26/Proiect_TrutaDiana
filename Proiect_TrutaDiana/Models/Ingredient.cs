using System.Reflection;

namespace Proiect_TrutaDiana.Models
{
    public class Ingredient
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public bool IsLiquid { get; set; }
        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }


    }
}
