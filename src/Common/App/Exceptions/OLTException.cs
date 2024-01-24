using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class OLTException : ApplicationException
    {
        public OLTException()
        {
        }

        public OLTException(string message)
            : base(message)
        {
        }

        public OLTException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args))
        {
        }

        public OLTException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public OLTException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}