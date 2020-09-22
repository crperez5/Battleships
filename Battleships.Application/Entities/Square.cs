using Battleships.Application.Enums;

namespace Battleships.Application.Entities
{
    public class Square
    {
        public SquareStatus Status { get; private set; }

        public Coordinates Coordinates { get; private set; }

        public Square(Coordinates coordinates)
        {
            Status = SquareStatus.Untouched;
            Coordinates = coordinates;
        }

        public void MarkAsMissed()
        {
            Status = SquareStatus.Miss;
        }

        public void MarkAsHit()
        {
            Status = SquareStatus.Hit;
        }

    }
}
