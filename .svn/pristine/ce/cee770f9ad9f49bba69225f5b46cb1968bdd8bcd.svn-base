using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class ShiftNotFoundException : OLTException
    {
        public ShiftNotFoundException(Time providedTime)
            : base(string.Format("No shift found for time ({0}) provided", providedTime))
        {
        }

        public ShiftNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ShiftNotFoundException(string message) : base(message)
        {
        }

        public ShiftNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}