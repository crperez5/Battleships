using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships.Application.Events
{
    public class TargetHitEventArgs : EventArgs
    {
    }

    public delegate void TargetHitEventHandler(Object sender, TargetHitEventArgs e);
}
