using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class NotAllowCoinException : Exception
    {
        public NotAllowCoinException(string message) : base(message)
        {
        }

        public NotAllowCoinException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}