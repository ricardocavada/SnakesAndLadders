using SnakesAndLadders.Entities;
using SnakesAndLadders.Services.Interfaces;

namespace SnakesAndLadders.Services
{
    public class GameService : IGameService
    {
        public IDieService DieService { get; }
        public Game game;

        public GameService(IDieService dieService) => DieService = dieService;

        public Game StartGame(int numberOfSquares, int numberOfPlayers)
        {
            game = new(numberOfSquares, numberOfPlayers);
            return game;
        }

        public int MovePlayer(Player player)
        {
            player.UpdateTokenPosition(DieService.Roll(), game.Board);
            int currentSquare = player.GetCurrentSquare();

            IsThePlayerWinnerOfGame(player, currentSquare);
            return currentSquare;
        }

        private void IsThePlayerWinnerOfGame(Player player, int currentSquare)
        {
            if (currentSquare.Equals(game.Board.GetNumberOfSquares()))
            {
                player.MarkAsWinner();
            }
        }
    }
}
