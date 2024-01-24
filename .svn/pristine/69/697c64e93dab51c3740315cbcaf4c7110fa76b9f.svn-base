using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InvalidPlantHistorianWriteException : OLTException
    {
        private const string formattedMessage = "Could not write to Tag: {0} the value : {1}";

        private readonly TagInfo tag;

        public InvalidPlantHistorianWriteException(TagInfo tag, decimal? value, Exception innerException) :
            base(string.Format(formattedMessage, tag, value.HasValue ? value.Value.ToString() : "null"), innerException)
        {
            this.tag = tag;
        }
        //Added by Mukesh :-RITM0238302
        public InvalidPlantHistorianWriteException(TagInfo tag, String value, Exception innerException,string tagname) :
            base(string.Format(formattedMessage, tag, value.ToString() ), innerException)
        {
            this.tag = tag;
        }

        public InvalidPlantHistorianWriteException(TagInfo tag, decimal? value) :
            base(string.Format(formattedMessage, tag, value.HasValue ? value.Value.ToString() : "null"))
        {
            this.tag = tag;
        }


        public InvalidPlantHistorianWriteException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public TagInfo Tag
        {
            get { return tag; }
        }
    }
}