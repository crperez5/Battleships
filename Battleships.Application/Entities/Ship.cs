using Battleships.Application.Enums;
using Battleships.Application.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Application.Entities
{
    public abstract class Ship
    {
        private HashSet<ShipCompartiment> _shotCompartiments = new HashSet<ShipCompartiment>();
        private List<ShipCompartiment> _compartiments = new List<ShipCompartiment>();
        public IReadOnlyCollection<ShipCompartiment> Compartiments => _compartiments.AsReadOnly();

        public ShipStatus Status { get; private set; }
        public Ship()
        {
            Status = ShipStatus.Healthy;
            _compartiments = new List<ShipCompartiment>();
        }

        public abstract int CompartimentsNumber { get; }

        public void AddCompartiment(Coordinates location)
        {
            if (CompartimentsNumber <= _compartiments.Count)
            {
                throw new CompartimentsNumberExceededException(CompartimentsNumber);
            }

            _compartiments.Add(new ShipCompartiment(location));
        }

        public void GetShot(Coordinates coordinates) 
        {
            var compartiment = _compartiments.First(c => c.Location == coordinates);

            _shotCompartiments.Add(compartiment);

            if(_shotCompartiments.Count == _compartiments.Count)
            {
                Status = ShipStatus.Sunk;
            }
        }
    }
}
