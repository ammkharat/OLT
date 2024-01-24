using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    /// <summary>
    ///     Exception thrown when asking for a registered implementation from the registry and none has been registered
    /// </summary>
    [Serializable]
    public class NoRegisteredImplementationException : OLTException
    {
        /// <summary>
        ///     No args constructor that passes in the default message for the exception
        /// </summary>
        public NoRegisteredImplementationException() : base("No registered implementation was found.")
        {
        }

        /// <summary>
        ///     Constructor that takes a string as the message of the exception
        /// </summary>
        /// <param name="message">the message explaining the exception</param>
        public NoRegisteredImplementationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Constructor that takes the inner exception as well as a message
        /// </summary>
        /// <param name="message">the message explaining the exception</param>
        /// <param name="innerException">the exception that caused this exception</param>
        public NoRegisteredImplementationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NoRegisteredImplementationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}