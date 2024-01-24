using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ILabAlertDetails : IRespondableDetails
    {
        string CreatedDateTime { set; }
        string DefinitionName { set; }
        string FunctionalLocation { set; }
        string Tag { set; }
        string Description { set; }
        int ActualNumberOfSamples { set; }
        int MinimumNumberOfSamples { set; }
        string LabAlertTagQueryRangeFromDateTime { set; }
        string LabAlertTagQueryRangeToDateTime { set; }
        string Schedule { set; }
        List<LabAlertResponse> Responses { set; }
    }

    public interface ILabAlertActions
    {
        event EventHandler Respond;
        bool RespondEnabled { set; }
    }

}