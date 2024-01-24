using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICommentsFormView : IBaseForm
    {
        event EventHandler SubmitButtonClick;
        event EventHandler CancelButtonClick;
        event EventHandler CreateLogCheckedChanged;

        string Title { set; }
        string UserComments { get;}
        bool IsLogRequired { get;}
        DateTime CreateDateTime { set;get;}
        string ShiftName { set;}
        User Author { set;}        
        void EnableLogAsOperatingEngineeringLog(bool enabled, string displayText);
        bool IsLogAnOperatingEngineeringLog { set; get;}
        void HideOperatingEngineerLogCheckbox();

        DialogResult ShowDialog(IWin32Window owner);

        /// <summary>
        /// Sets the control that will be used to display a summary of whatever entity
        /// the comment is for.
        /// </summary>
        Control SummaryView { set; }        
    }
}
