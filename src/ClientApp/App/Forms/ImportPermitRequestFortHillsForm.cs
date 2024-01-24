using System;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ImportPermitRequestFortHillsForm : BaseForm, IImportPermitRequestFortHillsFormView
    {
        public event EventHandler ImportButtonClicked;
        public event EventHandler CancelButtonClicked;

        public ImportPermitRequestFortHillsForm()
        {
            InitializeComponent();

            importButton.Click += HandleImportButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;          
        }        

        private void HandleImportButtonClicked(object sender, EventArgs e)
        {
            if (ImportButtonClicked != null)
            {
                ImportButtonClicked(sender, e);
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }
        
        public Date StartDate
        {
            get { return startRangeDatePicker.Value; }
            set { startRangeDatePicker.Value = value; }
        }

        public Date EndDate
        {
            get { return endRangeDatePicker.Value; }
            set { endRangeDatePicker.Value = value; }
        }

        public string LastImportDate
        {
            set { lastImportLabelData.Text = value; }
        }

        public string FromDateLabel
        {
            set { fromDateGroupBox.Text = value; }
        }
        
        public void ShowSuccessMessageBox(string message)
        {
            OltMessageBox.Show(this, message, StringResources.PermitRequestImportSuccess_Title);
        }

        public void DisableControlsForImport()
        {
            ControlsEnabledForImport(false);
        }

        public void EnableControlsForImport()
        {
            ControlsEnabledForImport(true);
        }

        private void ControlsEnabledForImport(bool enabled)
        {
            startRangeDatePicker.Enabled = enabled;
            endRangeDatePicker.Enabled = enabled;
            importButton.Enabled = enabled;
            cancelButton.Enabled = enabled;            
        }

        public void SetErrorForTooManyDaysSelected()
        {
            endDateErrorProvider.SetError(endRangeDatePicker, StringResources.Maximum7DaysAllowed);
        }

        public void SetErrorForEndDateBeforeStartDate()
        {
            endDateErrorProvider.SetError(endRangeDatePicker, StringResources.FromDateBeforeToDate);            
        }
    }
}