using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class CoinExistException : Exception
    {
        public CoinExistException(string message) : base(message)
        {
        }

        public CoinExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}