using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Application.Events
{
    public class UserVictoryEventArgs : EventArgs
    {

    }

    public delegate void UserVictoryEventHandler(Object sender, UserVictoryEventArgs e);
}
