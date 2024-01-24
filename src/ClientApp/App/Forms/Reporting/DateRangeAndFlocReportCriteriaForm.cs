using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public partial class DateRangeAndFlocReportCriteriaForm : BaseForm, IDateRangeAndFlocReportCriteriaFormView
    {        
        public event Action FormLoad;
        public event Action RunReportButtonClick;
        public event Action CancelButtonClick;

        public DateRangeAndFlocReportCriteriaForm()
        {
            InitializeComponent();

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);

            InitializePresenter();            
        }

        private void InitializePresenter()
        {            
            Load += HandleLoad;
            runReportButton.Click += HandleRunReportButtonClick; 
            cancelButton.Click += HandleCancelButtonClick;
        }

        private void HandleLoad(object sender, EventArgs e)
        {
            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        private void HandleRunReportButtonClick(object sender, EventArgs e)
        {
            if (RunReportButtonClick != null)
            {
                RunReportButtonClick();
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick();
            }
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
        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        }

        public string Title 
        { 
            set { Text = value; }
        }

        public void ClearErrors()
        {
            startDateErrorProvider.Clear();
        }

        public void SetErrorForStartDate(string errorMessage)
        {
            startDateErrorProvider.SetError(startRangeDatePicker, errorMessage);
        }

        public void SetErrorForEndDate(string errorMessage)
        {
            endDateErrorProvider.SetError(endRangeDatePicker, errorMessage);
        }

        public void LaunchFunctionalLocationSelectionRequiredMessage()
        {
            OltMessageBox.Show(ActiveForm, StringResources.FlocEmptyError, StringResources.FunctionalLocationsTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}