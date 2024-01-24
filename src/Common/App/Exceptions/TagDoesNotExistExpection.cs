using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class TagDoesNotExistExpection : OLTException
    {
        private const string formattedMessage = "The is no Tag named {0} available";

        public TagDoesNotExistExpection(string serverName)
            : base(String.Format(formattedMessage, serverName))
        {
        }

        public TagDoesNotExistExpection(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}