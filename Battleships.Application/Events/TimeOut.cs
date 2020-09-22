using System;

namespace Battleships.Application.Events
{
    public class TimeOutEventArgs : EventArgs
    {

    }

    public delegate void TimeOutEventHandler(Object sender, TimeOutEventArgs e);

}
