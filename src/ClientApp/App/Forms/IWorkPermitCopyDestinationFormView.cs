using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitCopyDestinationFormView
    {
        event EventHandler LoadView;
        event EventHandler Copy;

        string Title { set; }
        List<WorkPermit> CandidateWorkPermits { set; }
        WorkPermit SelectedWorkPermit { get; }
        List<WorkPermit> SelectedWorkPermits { get; }

        DialogResult ShowDialog(IWin32Window owner);
        DialogResult ShowMessageBox(string text, string caption);
        DialogResult ShowWarningMessage(string text, string caption);
        DialogResult ShowYesNoMessageBox(string text, string caption);
     
    }
}
