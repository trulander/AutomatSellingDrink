using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class DrinkExistException : Exception
    {
        public DrinkExistException(string message) : base(message)
        {
        }

        public DrinkExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}