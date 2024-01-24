using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IDeviationAlertDetails : IRespondableDetails
    {
        event EventHandler ViewResponseHistory;

        bool ViewReponseHistoryEnabled { set; }
        
        string RestrictionDefinitionName { set; }
        string RestrictionDefinitionDescription { set; }
        string FunctionalLocationName { set; }
        
        string MeasurementTagName { set; }        
        string MeasurementTagValue { set; }     
   
        string ProductionTargetTagName { set; }        
        string ProductionTargetTagValue { set; }

        string DeviationValue { set; }
        string Comments { set; }

        string StartTime { set; }
        string EndTime { set; }

        List<DeviationAlertResponseReasonCodeAssignment> Assignments { set; }
    }
    
    public interface IDeviationAlertActions
    {        
        event EventHandler Respond;                       
        bool RespondEnabled { set; }
    }
}
