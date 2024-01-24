using System;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class ExpectedAnActionItemDefintionFLOCPairException : OLTException
    {
        public ExpectedAnActionItemDefintionFLOCPairException()
            : base("Expected An ActionItemDefinition with only one Functional Location to determine shift.")
        {
        }

        public ExpectedAnActionItemDefintionFLOCPairException(string message) : base(message)
        {
        }

        public ExpectedAnActionItemDefintionFLOCPairException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ExpectedAnActionItemDefintionFLOCPairException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}