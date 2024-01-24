using System;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LabAlertResponseForm : BaseForm, ILabAlertResponseFormView
    {
        public LabAlertResponseForm(LabAlert alert)
        {
            Initialize();
            LabAlertResponseFormPresenter presenter = new LabAlertResponseFormPresenter(this, alert);
            RegisterEventHandlersOnPresenter(presenter);
        }

        private void Initialize()
        {
            InitializeComponent();
            reasonCodeComboBox.DataSource = LabAlertStatus.AllForResponding;
            reasonCodeComboBox.SelectedItem = LabAlertStatus.NotResponded;
        }

        private void RegisterEventHandlersOnPresenter(LabAlertResponseFormPresenter presenter)
        {
            Load += presenter.Form_Load;
            submitButton.Click += presenter.SubmitButton_Clicked;
            cancelButton.Click += presenter.CancelButton_Clicked;
        }

        public User Author
        {
            set { oltLastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            get { return oltLastModifiedDateAuthorHeader.LastModifiedDate; }
            set { oltLastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public string Shift
        {
            get { return shiftLabelData.Text; }
            set { shiftLabelData.Text = value; }
        }

        public LabAlertStatus SelectedStatus
        {
            get { return (LabAlertStatus)reasonCodeComboBox.SelectedItem; }
            set { reasonCodeComboBox.SelectedItem = value; }
        }

        public string Comments
        {
            get { return commentTextBox.Text.TrimOrNull(); }
            set { commentTextBox.Text = value; }
        }

        public bool CreateLogChecked
        {
            get { return createLogCheckBox.Checked; }
            set { createLogCheckBox.Checked = value; }
        }

        public void ShowCommentRequiredError()
        {
            commentErrorProvider.SetError(commentTextBox, StringResources.FieldEmptyError);
        }

        public void ClearAllErrors()
        {
            commentErrorProvider.Clear();
        }
    }
}
