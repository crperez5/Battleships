using Battleships.Application.Common;
using Battleships.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Application.Entities
{
    public class GameBoard
    {
        private readonly HashSet<Square> _parkingSpaces = new HashSet<Square>();

        public Square[,] Board { get; set; }

        public int Columns => Constants.DefaultColumnNumber;

        public int Rows => Constants.DefaultRowNumber;


        public GameBoard()
        {
            Board = new Square[Columns, Rows];


            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Board[i, j] = new Square(new Coordinates(i, j));
                }
            }
        }

        public List<Square> GetParkingSpace(int size)
        {
            var squares = new List<Square>();

            var orientation = GetParkingOrientation();
            var (x, y) = GetParkingStartPosition();
  
            squares.Add(Board[x, y]);

            var pendingSquares = size - 1;
            if (orientation == ParkingOrientation.Horizontal)
            {
                var currentIndex = x;
                while (pendingSquares > 0)
                {
                    var square = Board[Constants.DefaultColumnNumber - x + 1 > size ? ++currentIndex : --currentIndex, y];
                    squares.Add(square);
                    pendingSquares -= 1;
                }
            }
            else
            {
                var currentIndex = y;
                while (pendingSquares > 0)
                {
                    var square = Board[x, Constants.DefaultRowNumber - y + 1 > size ? ++currentIndex : --currentIndex];
                    squares.Add(square);
                    pendingSquares -= 1;
                }
            }

            if (squares.Any(s => _parkingSpaces.Contains(s)))
            {
                return GetParkingSpace(size);
            }

            foreach (var square in squares)
            {
                _parkingSpaces.Add(square);
            }

            return squares;
        }

        private (int x, int y) GetParkingStartPosition()
        {
            Random rnd = new Random();
            var x = rnd.Next(0, Constants.DefaultColumnNumber);
            var y = rnd.Next(0, Constants.DefaultRowNumber);
            return (x, y);
        }

        private ParkingOrientation GetParkingOrientation()
        {
            Random random = new Random();

            Type type = typeof(ParkingOrientation);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);

            return (ParkingOrientation)values.GetValue(index);
        }

    }
}
