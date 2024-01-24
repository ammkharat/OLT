using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IChangeActiveFunctionalLocationPresenter
    {
        void Form_Load(object sender, EventArgs e);
        void AcceptButton_Click(object sender, EventArgs e);
        void CancelButton_Click(object sender, EventArgs e);
        void HandleLoadDefaultAssignmentFlocsButtonClick(object sender, EventArgs e);
        void ClearSelectionButton_Click(object sender, EventArgs e);
        DialogResult ShowDialog(IWin32Window owner, List<FunctionalLocation> initialSelection);
    }
}
