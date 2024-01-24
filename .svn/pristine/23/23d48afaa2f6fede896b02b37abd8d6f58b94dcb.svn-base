using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    /// <summary>
    ///     Exception thrown if no data was found when expecting data
    /// </summary>
    [Serializable]
    public class NoDataFoundException : OLTException
    {
        /// <summary>
        ///     No args constructor using the default message
        /// </summary>
        public NoDataFoundException() : base("No data found.")
        {
        }

        /// <summary>
        ///     Constructor that allows you to specify the message which caused this exception
        /// </summary>
        /// <param name="message"></param>
        public NoDataFoundException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Constructor taking in a message and the exception that caused it
        /// </summary>
        /// <param name="message">the message explaining the cause of this exception</param>
        /// <param name="innerException">the exception that caused this exception to be thrown</param>
        public NoDataFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NoDataFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}