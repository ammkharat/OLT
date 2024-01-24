using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IPermitRequestFortHillsDetails : IPermitRequestDetails
    {
        event EventHandler Clone;        

        void SetDetails(PermitRequestFortHills request);
        bool CloneEnabled { set; }
    }
}