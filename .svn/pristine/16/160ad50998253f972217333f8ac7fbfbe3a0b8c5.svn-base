using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain.Target;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class LinkedTargetCircularReferenceException : OLTException
    {
        private readonly TargetDefinition target;
        private readonly long[] targetChain;

        public LinkedTargetCircularReferenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public LinkedTargetCircularReferenceException(long[] targetChain, TargetDefinition target)
        {
            this.target = target;
            this.targetChain = targetChain;
        }

        public TargetDefinition CircularTarget
        {
            get { return target; }
        }

        public long[] TargetChain
        {
            get { return targetChain; }
        }
    }
}