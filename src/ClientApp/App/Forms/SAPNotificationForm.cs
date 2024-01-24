using System;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SAPNotificationForm : BaseForm, ISAPNotificationFormView 
    {
        public SAPNotificationForm(SAPNotification sapNotification)
        {
            InitializeComponent();           
            RegisterEventHandler(new SAPNotificationFormPresenter(this, sapNotification));    
        }
       
        private void RegisterEventHandler(SAPNotificationFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            saveAndCloseButton.Click += presenter.HandleSaveAndCloseButtonClick;
            saveImportButton.Click += presenter.UpdateAndImport;
            saveImportAsOperatingEngineerLogButton.Click += presenter.UpdateAndImportAsOperatingEngineerLog;
        }
        
        public void HideSaveAndImportAsOperatingEngineer()
        {
            saveImportAsOperatingEngineerLogButton.Hide();
        }

        public string SaveAndImportAsOperatingEnginnerText 
        { 
            set
                {
                    saveImportAsOperatingEngineerLogButton.Text = value;
                } 
        }

        #region Interface properties

        public DateTime CreateDateTime
        {
            get { return oltLastModifiedDateAuthorHeader.LastModifiedDate; }
            set { oltLastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public string ShiftPatternName
        {
            set { shiftLabelData.Text = value; }
        }

        public User Author
        {
            set { oltLastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public string FunctionalLocationName
        {
            set { functionalLocationLabelData.Text = value; }
        }

        public string NotificationNumber
        {
            set { notificationNumberLabelData.Text = value; }
        }

        public string NotificationType
        {
            set { notificationTypeLabelData.Text = value; }
        }

        public string IncidentId
        {
            set { incidentIDLabelData.Text = value; }
        }

        public string Comments
        {
            get { return commentsTextBox.Text.Trim(); }
            set { commentsTextBox.Text = value; }
        }

        public string PreviousDescription
        {
            set { previousDescriptionTextBox.Text = value; }
        }

        public void SetCommentsBlankError(bool show)
        {
            descriptionErrorProvider.SetError(commentsTextBox, show ? StringResources.DescriptionEmptyError : string.Empty);
        }

        #endregion

        public void ClearErrorProviders()
        {
            descriptionErrorProvider.Clear();
        }
    }
}