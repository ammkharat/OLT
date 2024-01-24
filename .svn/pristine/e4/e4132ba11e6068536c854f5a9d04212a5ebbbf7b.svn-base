using System;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.DTO.Excursions;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IExcursionResponseDetails : IDeletableDetails
    {
        void SetDetails(OpmExcursion excursion);
        void SetCurrentTagValue(object result);
        event EventHandler ViewEnvelopeCommentsHistory;
        bool EnvelopeCommentsHistoryEnabled { set; }
    }
}