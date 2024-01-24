using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InvalidPlantHistorianConnectionInfoException : OLTException
    {
        public InvalidPlantHistorianConnectionInfoException(string message)
            : base(message)
        {
        }

        public InvalidPlantHistorianConnectionInfoException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}