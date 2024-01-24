using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class EdmontonPermitRequestPostFinalizeResult
    {
        private readonly List<NotifiedEvent> notifiedEvents;

        public EdmontonPermitRequestPostFinalizeResult(List<NotifiedEvent> notifiedEvents,
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