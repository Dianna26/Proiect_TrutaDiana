namespace Proiect_TrutaDiana.Models
{
    public class NutritionalValues
    {
        public Guid ID { get; set; }
        public int Calories { get; set; }
        public int Proteins { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public Guid RecipeID { get; set; }
        public Recipe Recipe { get; set; }   
    

    }
}
