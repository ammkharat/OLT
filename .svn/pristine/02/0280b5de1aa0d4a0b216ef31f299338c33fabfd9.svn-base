using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class ParentTargetExistsException : OLTException
    {
        private readonly List<string> targetNames;

        public ParentTargetExistsException(SerializationInfo info, StreamingContext context)
            :
                base
                (
                info,
                context
                )
        {
            if (info != null)
            {
                targetNames = (List<string>) info.GetValue("TargetNames", typeof (List<string>));
            }
        }

        public ParentTargetExistsException(List<string> targetNames)
        {
            this.targetNames = targetNames;
        }

        public List<string> TargetNames
        {
            get { return targetNames; }
        }


        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
                info.AddValue("TargetNames", targetNames);

            base.GetObjectData(info, context);
        }
    }
}