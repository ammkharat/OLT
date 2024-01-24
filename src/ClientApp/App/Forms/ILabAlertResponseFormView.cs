using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ILabAlertResponseFormView : IBaseForm
    {
        DateTime CreateDateTime { set; get; }
        string Shift { set; }
        User Author { set; }

        LabAlertStatus SelectedStatus { get; set; }
        string Comments { get; set; }
        bool CreateLogChecked { set; get; }

        void ShowCommentRequiredError();
        void ClearAllErrors();
    }
}
