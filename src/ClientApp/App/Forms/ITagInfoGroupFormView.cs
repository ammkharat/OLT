using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITagInfoGroupFormView : IBaseForm
    {
        string TagInfoGroupName { set; get; }
        bool RemoveButtonEnabled { set; }
        bool ClearButtonEnabled { set; }

        List<TagInfoWithError> TagInfoList { set; }
        TagInfo GetTagInfoToBeAdded();
        TagInfoWithError GetTagInfoToBeRemoved();

        void UpdateTitleAsCreateOrEdit(bool isEdit);
        void ClearErrorProviders();
        void ShowTagInfoGroupNameIsEmptyError();
        void ShowTagInfoGroupNameIsDuplicateError();
        void SetDialogResultOK();
        DialogResult ShowTagReadWarningMessage();
    }
}
