using System;

namespace Battleships.Application.Events
{
    public class ShipSunkEventArgs : EventArgs
    {
        public ShipSunkEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public delegate void ShipSunkEventHandler(Object sender, ShipSunkEventArgs e);
}
