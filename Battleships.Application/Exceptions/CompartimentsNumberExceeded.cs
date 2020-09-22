using System;

namespace Battleships.Application.Exceptions
{
    public class CompartimentsNumberExceededException : Exception
    {
        public CompartimentsNumberExceededException(int num)
          : base($"Ship cannot have more than \"{num}\" compartiments.", new Exception())
        {
        }
    }
}
