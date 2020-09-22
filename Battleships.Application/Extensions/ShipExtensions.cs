using Battleships.Application.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Application.Extensions
{
    public static class ShipExtensions
    {
        public static void AddCompartiments(this Ship ship, IEnumerable<Square> squares)
        {
            var coordinatesList = squares.Select(p => p.Coordinates);
            foreach(var coordindate in coordinatesList)
            {
                ship.AddCompartiment(coordindate);
            }
        }
    }
}
