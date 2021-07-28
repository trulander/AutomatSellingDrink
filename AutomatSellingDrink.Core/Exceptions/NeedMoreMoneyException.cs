using System;

namespace AutomatSellingDrink.Core.Exceptions
{
    public class NeedMoreMoneyException : Exception
    {
        public NeedMoreMoneyException(string message) : base(message)
        {
        }

        public NeedMoreMoneyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}