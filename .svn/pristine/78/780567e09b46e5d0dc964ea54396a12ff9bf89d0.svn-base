using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class AttemptedToUpdateObjectWithoutIdException : OLTException
    {
        public AttemptedToUpdateObjectWithoutIdException(DomainObject parent, Type childType)
            : base(string.Format("Attempting to update {0} without Id while working with {1} with Id {2}.",
                childType, parent.GetType(), parent.Id.Value))
        {
        }

        public AttemptedToUpdateObjectWithoutIdException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AttemptedToUpdateObjectWithoutIdException(string message)
            : base(message)
        {
        }

        public AttemptedToUpdateObjectWithoutIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}