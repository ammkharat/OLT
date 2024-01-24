using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditWorkPermitMudsGroupForm : BaseForm, IAddEditWorkPermitMudsGroupView
    {
        public event Action OkButtonClicked;
        public event Action CancelButtonClicked;

        public AddEditWorkPermitMudsGroupForm()
        {
            InitializeComponent();

            okButton.Click += HandleOkButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            OkButtonClicked();
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            CancelButtonClicked();
        }

        public string GroupName
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForMissingName()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void SetErrorForDuplicateName()
        {
            errorProvider.SetError(nameTextBox, StringResources.DuplicateGroup);
        }
    }
}
