using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class InconsistentTagInfoGroupDataException : OLTException
    {
        private const string ERROR_MESSAGE_TEMPLATE =
            "Inconsistent data between tag group and its tags.  TagGroup = {0}";

        public InconsistentTagInfoGroupDataException(TagInfoGroup invalidTagInfoGroup)
            : base(string.Format(ERROR_MESSAGE_TEMPLATE, invalidTagInfoGroup.Name))
        {
        }

        public InconsistentTagInfoGroupDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}