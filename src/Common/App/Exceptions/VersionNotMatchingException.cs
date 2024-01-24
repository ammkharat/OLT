using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class VersionNotMatchingException : OLTException
    {
        public VersionNotMatchingException(string message) : base(message)
        {
        }

        public VersionNotMatchingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}