using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public partial class MarkedAsNotReadReportForm : BaseForm,IMarkedAsNotReadReportFormView
    {
        public MarkedAsNotReadReportForm(bool includeHandoversByDefault, bool includeDirectivesByDefault)
        {
            InitializeComponent();
            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);
            InitializePresenter(includeHandoversByDefault, includeDirectivesByDefault);   
        }
        private void InitializePresenter(bool includeHandoversByDefault, bool includeDirectivesByDefault)
        {
            MarkedAsNotReadReportFormPresenter presenter = new MarkedAsNotReadReportFormPresenter(this, includeHandoversByDefault, includeDirectivesByDefault);
            Load += presenter.Form_Load;
            runReportButton.Click += presenter.RunReportButton_Click;
            cancelButton.Click += presenter.CancelButton_Click;
        }   
        public void CloseForm()
        {
            Close();
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool ShiftHandoverChecked
        {
            get { return shiftHandoverCheckBox.Checked; }
            set { shiftHandoverCheckBox.Checked = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool DirectivesChecked
        {
            get { return directivesCheckBox.Checked; }
            set { directivesCheckBox.Checked = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForStartDate(string errorMessage)
        {
            errorProvider.SetError(startRangeDatePicker, errorMessage);
        }

        public void SetErrorForEndDate(string errorMessage)
        {
            errorProvider.SetError(endRangeDatePicker, errorMessage);
        }
        public void SetSelectReportError(string errorMessage)
        {
            
            errorProvider.SetError(directivesCheckBox, errorMessage);
            errorProvider.SetError(shiftHandoverCheckBox, errorMessage);
           
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocEmptyError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
