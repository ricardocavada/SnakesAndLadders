namespace SnakesAndLadders.Entities
{
    public class Token
    {
        public Guid Id { get; }

        public Square CurrentSquare { get; set; }
        public Token(Guid id)
        {
            Id = id;
            CurrentSquare = new Square(1);
        }
        public void UpdateSquare(Square currentSquare)
        {
            CurrentSquare = currentSquare;
        }
    }
}
