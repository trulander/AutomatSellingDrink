using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class DrinkNotFoundException : Exception
    {
        public DrinkNotFoundException(string message) : base(message)
        {
        }

        public DrinkNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}