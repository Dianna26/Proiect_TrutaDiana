﻿using Proiect_TrutaDiana.DTOs;

namespace Proiect_TrutaDiana.Models
{
    public class Recipe
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public string Steps { get; set; }
        public Guid NutritionalValuesID { get; set; }
        public NutritionalValues NutritionalValues { get; set; }
        public int Portions { get; set; }
        public int DifficultyID { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
