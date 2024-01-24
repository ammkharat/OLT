using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISAPNotificationFormView : IBaseForm
    {
        DateTime CreateDateTime { set; get; }
        string ShiftPatternName { set; }
        User Author { set; }
        string FunctionalLocationName { set; }
        string NotificationNumber { set; }
        string NotificationType { set; }
        string IncidentId { set; }
        string PreviousDescription { set; }
        string Comments { get; }
        void SetCommentsBlankError(bool show);
        void ClearErrorProviders();        
        void HideSaveAndImportAsOperatingEngineer();
        string SaveAndImportAsOperatingEnginnerText{ set; }
    }
}