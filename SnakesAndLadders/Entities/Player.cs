namespace SnakesAndLadders.Entities
{
    public class Player
    {
        public bool Started
        {
            get
            {
                return _token.CurrentSquare.Number >= 1;
            }
        }
        private Token _token { get; set; }
        public bool Winner { get; private set; }
        public Player(Token token)
        {
            _token = token;
        }

        public void UpdateTokenPosition(int numberOfMoviments, Board board)
        {
            var position = _token.CurrentSquare.Number + numberOfMoviments;
            if (position <= board.GetNumberOfSquares())
            {
                _token.CurrentSquare = board.GetSquare(position);
            }
        }

        public int GetCurrentSquare()
        {
            return _token.CurrentSquare.Number;
        }

        public Player MarkAsWinner()
        {
            Winner = true;
            return this;
        }
    }
}