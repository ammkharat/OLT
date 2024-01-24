using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Exceptions;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class ShiftOutOfBoundsException : OLTException
    {
        public ShiftOutOfBoundsException(string format, params object[] args) :
            this(string.Format(format, args))
        {
        }

        public ShiftOutOfBoundsException(string message) : base(message)
        {
        }

        public ShiftOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ShiftOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}