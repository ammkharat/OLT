using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IPermitRequestLubesDetails : IPermitRequestDetails
    {
        event Action Clone;

        void SetDetails(PermitRequestLubes permitRequest);
        bool CloneEnabled { set; }
    }
}
