using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLoggableStatus
    {
        public static readonly WorkPermitLoggableStatus EMPTY =
            new WorkPermitLoggableStatus(new PermitRequestBasedWorkPermitStatus(0, 0), false);

        private readonly PermitRequestBasedWorkPermitStatus status;

        public WorkPermitLoggableStatus(PermitRequestBasedWorkPermitStatus status, bool requiresLog)
        {
            this.status = status;
            RequiresLog = requiresLog;
        }

        public bool RequiresLog { get; private set; }

        public string Name
        {
            get { return status.Name; }
        }

        public PermitRequestBasedWorkPermitStatus Status
        {
            get { return status; }
        }
    }
}