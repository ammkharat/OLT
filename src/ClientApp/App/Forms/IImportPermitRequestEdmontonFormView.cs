using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IImportPermitRequestEdmontonFormView : IBaseForm
    {
        event EventHandler ImportButtonClicked;
        event EventHandler CancelButtonClicked;

        Date StartDate { get; set; }
        Date EndDate { get; set; }        
        string LastImportDate { set; }
        string FromDateLabel { set; }        

        void ShowSuccessMessageBox(string message);

        void DisableControlsForImport();
        void EnableControlsForImport();

        void SetErrorForTooManyDaysSelected();
        void SetErrorForEndDateBeforeStartDate();
    }
}
