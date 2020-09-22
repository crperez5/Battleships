using Battleships.Application.Enums;

namespace Battleships.Application.Entities
{
    public class ShipCompartiment
    {
        public Coordinates Location { get; }

        public ShipCompartiment(Coordinates location)
        {
            Location = location;
        }
    }
}
