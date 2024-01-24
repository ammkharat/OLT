using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class TagSchedulerException : OLTException
    {
        /// <summary>
        ///     Constructor that allows you to specify the message which caused this exception
        /// </summary>
        /// <param name="message"></param>
        public TagSchedulerException(string message) : base(message)
        {
        }

        public TagSchedulerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        /// <summary>
        ///     For serialization reasons
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public TagSchedulerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}