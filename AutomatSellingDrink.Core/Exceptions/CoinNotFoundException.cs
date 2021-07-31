using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class CoinNotFoundException : Exception
    {
        public CoinNotFoundException(string message) : base(message)
        {
        }

        public CoinNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}