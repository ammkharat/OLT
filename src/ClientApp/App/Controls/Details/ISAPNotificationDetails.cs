using System;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface ISAPNotificationDetails : IDetails
    {
        event EventHandler SubmitToLog;
        event EventHandler SubmitToOperatingEngineerLog;
        event EventHandler Edit;
        
        string FunctionalLocationString { set; }
        string NotificationNumber { set; }
        string NotificationType { set; }
        string StartTime { set; }
        string CreateDate { set; }
        string Description { set; }
        string Comments { set; }

        bool SubmitToLogEnabled { set; }
        bool SubmitToOperatingEngineerLogEnabled { set; }
        bool EditEnabled { set; }
        string ShortTextString { set; }
        string IncidentIDString { set; }
        string SubmitToOperatingEngineerLogText { set; }
    }
}