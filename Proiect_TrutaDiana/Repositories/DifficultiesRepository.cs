using Proiect_TrutaDiana.Models;

namespace Proiect_TrutaDiana.Repositories
{
    public class DifficultiesRepository
    {
        public Difficulty GetDifficulty(int difficultyID, CookBookContext context)
        {
            return context.Difficulties.Where(i => i.ID == difficultyID).FirstOrDefault();
        }

        public List<Difficulty> GetDifficulties (CookBookContext context)
        {
            return context.Difficulties.ToList();
        }
    }
}
