using System;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface ILogReplyFormPresenter
    {
        void HandleFormLoad(object sender, EventArgs e);
        void HandleFormClosing(object sender, FormClosingEventArgs e);
        void HandleCancelButtonClick(object sender, EventArgs e);
        void HandleSaveAndCloseButtonClick(object sender, EventArgs e);
        void HandleLogCommentGuidelineLinkClick(object sender, EventArgs e);
    }
}
