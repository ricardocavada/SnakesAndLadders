using SnakesAndLadders.Entities;
using SnakesAndLadders.Services.Interfaces;

namespace SnakesAndLadders.Services
{
    public class DieService : IDieService
    {
        public int Roll()
        {
            Random rnd = new();
            int maximumDieValue = Die.GetMaximumValue() + 1;
            return rnd.Next(Die.GetMinumumValue(), maximumDieValue);
        }
    }
}
