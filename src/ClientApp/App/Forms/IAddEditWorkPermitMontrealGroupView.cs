using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditWorkPermitMontrealGroupView : IBaseForm
    {
        event Action OkButtonClicked;
        event Action CancelButtonClicked;
        
        string GroupName { get; set; }

        void ClearErrors();
        void SetErrorForMissingName();
        void SetErrorForDuplicateName();
    }
}
