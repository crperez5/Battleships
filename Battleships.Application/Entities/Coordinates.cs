using System;

namespace Battleships.Application.Entities
{
    public class Coordinates : IEquatable<Coordinates>
    {
        private string[] _letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        public Coordinates(int column, int row)
        {
            Column = column;
            Row = row;
        }

        public int Column { get; }
        public int Row { get; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates c)
        {
            if (ReferenceEquals(c, null))
            {
                return false;
            }

            if (ReferenceEquals(this, c))
            {
                return true;
            }

            if (GetType() != c.GetType())
            {
                return false;
            }

            return (Row == c.Row) && (Column == c.Column);
        }

        public override int GetHashCode()
        {
            return Row * 0x00010000 + Column;
        }

        public static bool operator ==(Coordinates c1, Coordinates c2)
        {
            if (ReferenceEquals(c1, null))
            {
                if (ReferenceEquals(c2, null))
                {
                    return true;
                }
                return false;
            }


            return c1.Equals(c2);
        }

        public static bool operator !=(Coordinates c1, Coordinates c2)
        {
            return !(c1 == c2);
        }

        public override string ToString()
        {
            return _letters[Column] + (Row + 1);
        }
    }
}
