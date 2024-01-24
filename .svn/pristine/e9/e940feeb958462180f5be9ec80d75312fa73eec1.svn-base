using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InvalidPlantHistorianReadException : OLTException
    {
        private const string formattedMessage = "Could not read values from Tag: {0} for times: {1}";

        public InvalidPlantHistorianReadException(List<string> tags, DateTime readTime, Exception innerException)
            : base(
                string.Format("Could not read one or more of the following tags: {0} at {1}.", FormatTags(tags),
                    readTime), innerException)
        {
        }

        public InvalidPlantHistorianReadException(string tag, DateTime[] readTimes)
            : base(string.Format(formattedMessage, tag, ToString(readTimes)))
        {
        }

        public InvalidPlantHistorianReadException(TagInfo tag, DateTime[] readTimes, Exception innerException) :
            base(string.Format(formattedMessage, tag, ToString(readTimes)), innerException)
        {
        }

        public InvalidPlantHistorianReadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private static string FormatTags(List<string> tags)
        {
            if (tags == null)
                return "<null>";
            return string.Join(", ", tags.ToArray());
        }

        private static string ToString(DateTime[] dateTimes)
        {
            var dateTimeStrings = Array.ConvertAll(dateTimes, input => input.ToString());
            return "[" + string.Join(", ", dateTimeStrings) + "]";
        }
    }
}