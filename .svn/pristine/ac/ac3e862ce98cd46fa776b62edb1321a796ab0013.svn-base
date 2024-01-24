using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class NoShiftAssignmentFoundException : OLTException
    {
        /// <summary>
        ///     No args constructor using the default message
        /// </summary>
        public NoShiftAssignmentFoundException()
            : base("No shift assignments found for the user at the current date/time.")
        {
        }

        public NoShiftAssignmentFoundException(long userId)
            : base("No shift assignments found for userId " + userId + "for the current date/time.")
        {
        }

        public NoShiftAssignmentFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Constructor that allows you to specify the message which caused this exception
        /// </summary>
        /// <param name="message"></param>
        public NoShiftAssignmentFoundException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Constructor taking in a message and the exception that caused it
        /// </summary>
        /// <param name="message">the message explaining the cause of this exception</param>
        /// <param name="innerException">the exception that caused this exception to be thrown</param>
        public NoShiftAssignmentFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}