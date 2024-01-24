using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class FortHillsPermitRequestPostFinalizeResult
    {
        private readonly List<NotifiedEvent> notifiedEvents;

        public FortHillsPermitRequestPostFinalizeResult(List<NotifiedEvent> notifiedEvents,
            int numberOfTurnaroundPermitsHandled)
        {
            this.notifiedEvents = notifiedEvents;
            NumberOfTurnaroundPermitsHandled = numberOfTurnaroundPermitsHandled;
        }

        public int NumberOfTurnaroundPermitsHandled { get; private set; }

        public List<NotifiedEvent> NotifiedEvents
        {
            get { return notifiedEvents; }
        }
    }
}