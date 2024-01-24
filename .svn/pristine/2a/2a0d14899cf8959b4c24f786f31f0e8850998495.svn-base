using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ITagSearchFormView
    {
        List<SearchField> SearchCriteria { set; }
        List<TagInfo> ListData { set; }

        SearchField CriteriaField { get; }
        string CriteriaValue { get; set; }

        bool SelectButtonEnabled { set; }
        TagInfo SelectedTag { get; }
        bool SelectedTagReadStatus { set;}
        bool SelectedTagWriteStatus { set; get; }
        void ResetTagStatusImages();
        
        void ClearErrorProviders();
        void ShowInvalidCriteriaValueError();
        void CloseForm();
        bool ConfirmCancel();
        void SetDialogResultOK();
        DialogResult ShowDialog();
        DialogResult ShowDialog(IWin32Window owner);
        void ShowMustSelectWritableTag();
        void SetDialogResultNone();
    }
}