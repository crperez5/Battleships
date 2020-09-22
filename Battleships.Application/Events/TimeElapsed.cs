using System;

namespace Battleships.Application.Events
{
    public class TimeElapsedEventArgs : EventArgs
    {
        public int SecondsLeft { get; set; }
    }

    public delegate void TimeElapsedEventHandler(Object sender, TimeElapsedEventArgs e);

}
