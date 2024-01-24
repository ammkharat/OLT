using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestPostFinalizeResult
    {
        private readonly int importCount;
        private readonly List<NotifiedEvent> notifiedEvents;
        private readonly List<PermitRequestImportRejection> rejectList;

        public PermitRequestPostFinalizeResult(List<NotifiedEvent> notifiedEvents,
            List<PermitRequestImportRejection> rejectList, int importCount)
        {
            this.importCount = importCount;

            this.notifiedEvents = notifiedEvents;
            this.rejectList = rejectList;
        }

        public List<NotifiedEvent> NotifiedEvents
        {
            get { return notifiedEvents; }
        }

        public List<PermitRequestImportRejection> RejectList
        {
            get { return rejectList; }
        }

        public bool HasRejections
        {
            get { return rejectList.Count > 0; }
        }

        public int ImportCount
        {
            get { return importCount; }
        }
    }
}