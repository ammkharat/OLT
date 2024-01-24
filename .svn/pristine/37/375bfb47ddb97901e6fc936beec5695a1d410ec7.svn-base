using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ITargetAlertDetails : IRespondableDetails
    {
        event Action Acknowledge;
        event Action ViewAssociatedLogs;

        bool AcknowledgeEnabled { set; }
        bool ExportVisible { set;  }
        bool RangeVisible { set;  }
        bool GoToDefinitionVisible { set;  }
        bool SaveGridLayoutVisible { set; }

        string TargetName { set; }
        string FunctionalLocationName { set; }
        string Description { set; }
        string WorkAssignmentName { set; }
        DateTime? LastViolatedDateTime { set; }
        string TagName { set; }
        string TagUnits { set; }
        string Category { set; }
        string NeverToExceedMax { set; }
        string Max { set; }
        string Min { set; }
        string NeverToExceedMin { set; }
        string TargetValue { set; }
        string GapUnitValue { set; }
        string GapUnitValueUnits { set; }
        string ActualValue { set; }
        string CalculatedLosses { set; }
        List<DocumentLink> DocumentLinks { set; }

        ISchedule Schedule { set; }
        bool ViewAssociatedLogsEnabled { set; }
        bool ViewAssociatedLogsVisible { set; }
    }
    
    public interface ITargetAlertActions
    {
        event EventHandler Acknowledge;
        event EventHandler Respond;
        
        bool AcknowledgeEnabled { set; }
        bool RespondEnabled { set; }
    }
}
