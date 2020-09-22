using System.Collections.Generic;
using System.Linq;

namespace Battleships.Application.Entities
{
    public class Radar
    {
        private List<Ship> _ships = new List<Ship>();

        public void TrackShip(Ship s)
        {
            _ships.Add(s);
        }

        public Ship FindShip(Coordinates coordinates)
        {
            var ship = _ships.FirstOrDefault(s => s.Compartiments.Any(c => c.Location == coordinates));

            return ship;
        }

        public bool AnyShipAlive()
        {
            return _ships.Any(s => s.Status == Enums.ShipStatus.Healthy);
        }
    }
}
