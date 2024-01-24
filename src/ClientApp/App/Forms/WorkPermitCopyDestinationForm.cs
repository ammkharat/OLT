using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitCopyDestinationForm : BaseForm, IWorkPermitCopyDestinationFormView
    {
        private readonly DomainListView<WorkPermit> candidateWorkPermitsView;

        public WorkPermitCopyDestinationForm()
        {
            InitializeComponent();
            candidateWorkPermitsView = new DomainListView<WorkPermit>(new WorkPermitListViewRenderer(),
                                                                      false, true);
            candidateWorkPermitsPanel.Controls.Add(candidateWorkPermitsView);
            
            
            cancelButton.Click +=cancelButton_Click;
        }

        #region IWorkPermitCopyDestinationFormView Members

        public event EventHandler LoadView;
        public event EventHandler Copy;

        public string Title
        {
            set { Text = value; }
        }

        public List<WorkPermit> CandidateWorkPermits
        {
            set { candidateWorkPermitsView.ItemList = value; }
        }

        public WorkPermit SelectedWorkPermit
        {
            get { return SelectedWorkPermits[0]; }
        }

        public List<WorkPermit> SelectedWorkPermits
        {
            get
            {
                ICollection selectedItems = candidateWorkPermitsView.SelectedItems;
                return selectedItems.ConvertAll<WorkPermit, DomainListViewItem<WorkPermit>>(item => item.Item);
            }
        }

        public new DialogResult ShowMessageBox(string text, string caption)
        {
            return OltMessageBox.Show(ActiveForm, text, caption);
        }

        public DialogResult ShowWarningMessage(string text, string caption)
        {
            return OltMessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowYesNoMessageBox(string text, string caption)
        {
            return OltMessageBox.Show(ActiveForm, text, caption, MessageBoxButtons.YesNo);
        }

        #endregion

        private void copyButton_Click(object sender, EventArgs e)
        {
            if(Copy != null)
            {
                Copy(sender, e);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if(ConfirmCancelDialog())
            {
                Close();
            }
        }

        private void WorkPermitCopyDestinationForm_Load(object sender, EventArgs e)
        {
            if(LoadView != null)
            {
                LoadView(sender, e);
            }
        }
    }
}