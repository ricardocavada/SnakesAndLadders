namespace SnakesAndLadders.Entities
{
    public class Game
    {
        public Board Board { get; }
        private ICollection<Player> players = new List<Player>();

        public Game(int numberOfSquares, int numberOfPlayers)
        {
            Board = new(numberOfSquares);
            AddPlayers(numberOfPlayers);
        }

        public ICollection<Player> Players => players.ToList();
        private void AddPlayers(int numberOfPlayers)
        {
            players = new List<Player>();
            for (int player = 0; player < numberOfPlayers; player++)
            {
                players.Add(new Player(new Token(Guid.NewGuid())));
            }
        }
    }
}
