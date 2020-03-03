using System;
using System.Runtime.Serialization;

namespace Vending.Common.Exceptions
{
    public class InvalidCoinCombinationException : Exception
    {
        public InvalidCoinCombinationException()
        {
        }

        public InvalidCoinCombinationException(string message) : base(message)
        {
        }

        public InvalidCoinCombinationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCoinCombinationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
