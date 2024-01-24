using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    /// <summary>
    ///     Exception thrown if more than one object is found when only expecting one
    /// </summary>
    [Serializable]
    public class MoreThanOneRecordFoundException : OLTException
    {
        /// <summary>
        ///     No args constructor which takes a default message for the exception
        /// </summary>
        public MoreThanOneRecordFoundException() : base("More than one record found.")
        {
        }

        /// <summary>
        ///     Constructor which takes a message explaining the exception
        /// </summary>
        /// <param name="message">the message about this exception</param>
        public MoreThanOneRecordFoundException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Constructor taking a inner exception as well as a message explaining it
        /// </summary>
        /// <param name="message">the message about the exception</param>
        /// <param name="innerException">the exception which caused this exception to happen</param>
        public MoreThanOneRecordFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MoreThanOneRecordFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}