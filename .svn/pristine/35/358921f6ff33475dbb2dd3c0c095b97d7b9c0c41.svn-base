using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class LockException : OLTException
    {
        /// <summary>
        ///     Constructor that allows you to specify the message which caused this exception
        /// </summary>
        /// <param name="message"></param>
        public LockException(string message) : base(message)
        {
        }


        /// <summary>
        ///     For serialization reasons
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public LockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}