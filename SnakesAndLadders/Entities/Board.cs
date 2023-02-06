namespace SnakesAndLadders.Entities
{
    public class Board
    {
        public ICollection<Square> Squares;
        private int _numberOfSquares;
        public Board(int numberOfSquares)
        {
            _numberOfSquares = numberOfSquares;
            Squares = new List<Square>();
            for (int index = 1; index <= _numberOfSquares; index++)
            {
                Squares.Add(new Square(index));
            }
        }

        public Square GetSquare(int index)
        {
            return Squares.First(f => f.Number.Equals(index));
        }

        public int GetNumberOfSquares()
        {
            return _numberOfSquares;
        }
    }
}
