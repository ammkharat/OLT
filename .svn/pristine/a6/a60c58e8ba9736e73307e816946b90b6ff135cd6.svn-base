using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InvalidPlantHistorianValueException : OLTException
    {
        private const string formattedMessage = "The is requested Tag: {0}, Value: {1} is not a number.";

        public InvalidPlantHistorianValueException(string tagName, string tagValue)
            : base(String.Format(formattedMessage, tagName, tagValue))
        {
        }

        public InvalidPlantHistorianValueException(string message) : base(message)
        {
        }

        public InvalidPlantHistorianValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public InvalidPlantHistorianValueException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}