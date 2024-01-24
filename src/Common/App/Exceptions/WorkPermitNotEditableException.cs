using System;
using System.Runtime.Serialization;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Exceptions
{
    [Serializable]
    public class WorkPermitNotEditableException : OLTException
    {
        private readonly string permitNumber;
        private readonly WorkPermitStatus status;

        public WorkPermitNotEditableException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
            permitNumber = (string) info.GetValue("permitNumber", typeof (string));
            status = (WorkPermitStatus) info.GetValue("status", typeof (WorkPermitStatus));
        }

        public WorkPermitNotEditableException(string permitNumber, WorkPermitStatus status) :
            this(
            string.Format("Cannot copy to Work Permit #{0} because it now has an uneditable status of {1}.",
                permitNumber, status))
        {
            this.permitNumber = permitNumber;
            this.status = status;
        }

        public WorkPermitNotEditableException(string message) : base(message)
        {
        }

        public string PermitNumber
        {
            get { return permitNumber; }
        }

        public WorkPermitStatus Status
        {
            get { return status; }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("permitNumber", permitNumber);
            info.AddValue("status", status);
            base.GetObjectData(info, context);
        }
    }
}