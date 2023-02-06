namespace SnakesAndLadders.Services.Interfaces
{
    public interface IDieService
    {
        /// <summary>
        /// Roll the die
        /// </summary>
        /// <returns>Number of movements</returns>
        int Roll();
    }
}