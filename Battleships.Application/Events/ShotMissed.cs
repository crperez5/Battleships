using System;

namespace Battleships.Application.Events
{
    public class ShotMissedEventArgs : EventArgs
    {
    }

    public delegate void ShotMissedEventHandler(Object sender, ShotMissedEventArgs e);
}
