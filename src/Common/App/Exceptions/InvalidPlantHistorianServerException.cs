using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InvalidPlantHistorianServerException : OLTException
    {
        private const string formattedMessage = "The is no Server named {0} available";

        public InvalidPlantHistorianServerException(string serverName)
            : base(string.Format(formattedMessage, serverName))
        {
        }

        public InvalidPlantHistorianServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}