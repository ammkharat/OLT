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
    public partial class MarkedAsReadReportForm : BaseForm, IMarkedAsReadReportFormView
    {
        public MarkedAsReadReportForm(bool includeLogsAndSummaryLogsByDefault, bool includeHandoversByDefault, bool includeDirectivesByDefault)
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);

            InitializePresenter(includeLogsAndSummaryLogsByDefault, includeHandoversByDefault, includeDirectivesByDefault);            
        }

        private void InitializePresenter(bool includeLogsAndSummaryLogsByDefault, bool includeHandoversByDefault, bool includeDirectivesByDefault)
        {
            MarkedAsReadReportFormPresenter presenter = new MarkedAsReadReportFormPresenter(this, includeLogsAndSummaryLogsByDefault, includeHandoversByDefault, includeDirectivesByDefault);
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
        public bool LogsChecked
        {
            get { return logsCheckBox.Checked; }
            set { logsCheckBox.Checked = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool SummaryLogsChecked
        {
            get { return summaryLogsCheckBox.Checked; }
            set { summaryLogsCheckBox.Checked = value; }
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
        public bool ShiftHandoverChecked
        {
            get { return shiftHandoverCheckBox.Checked; }
            set { shiftHandoverCheckBox.Checked = value; }
        }

        /*RITM0185797 flexiu shift handover amit shukla*/
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FlexiShiftHandoverChecked
        {
            get { return flexishiftHandoverCheckBox.Checked; }
            set { flexishiftHandoverCheckBox.Checked = value; }
        }
        /**/

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
            errorProvider.SetError(logsCheckBox, errorMessage);
            errorProvider.SetError(summaryLogsCheckBox, errorMessage);
            errorProvider.SetError(directivesCheckBox, errorMessage);
            errorProvider.SetError(shiftHandoverCheckBox, errorMessage);
            errorProvider.SetError(flexishiftHandoverCheckBox, errorMessage);
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocEmptyError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}