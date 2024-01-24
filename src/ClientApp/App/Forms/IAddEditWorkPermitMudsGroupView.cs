using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditWorkPermitMudsGroupView : IBaseForm
    {
        event Action OkButtonClicked;
        event Action CancelButtonClicked;
        
        string GroupName { get; set; }

        void ClearErrors();
        void SetErrorForMissingName();
        void SetErrorForDuplicateName();
    }
}
