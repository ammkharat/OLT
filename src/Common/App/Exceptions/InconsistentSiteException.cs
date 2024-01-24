using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InconsistentSiteException : OLTException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Requested data for Site {0}, but current Site is {1}.";

        public InconsistentSiteException(long? expectedSite, long? givenSite)
            : base(string.Format(ERROR_MESSAGE_TEMPLATE, givenSite, expectedSite))
        {
        }

        public InconsistentSiteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}