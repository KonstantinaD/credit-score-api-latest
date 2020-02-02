using System;

namespace Services
{
    public class ScoreService : IScoreService
    {
        public int GetScore(string name)
        {
                Random rng = new Random();
                int num = rng.Next(0, 999);
                return num;
        }
    }
}
