using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public partial class DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm : BaseForm, IDateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaFormView
    {
        public event Action FormLoad;
        public event Action FormClose;
        public event Action RunReportButtonClick;
        public event Action CancelButtonClick;

        private SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;

        public DateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaForm()
        {
            InitializeComponent();
            InitializeAssignmentGrid(true);

            Load += HandleLoad;
            FormClosing += HandleFormClosing;
            runReportButton.Click += HandleRunReportButtonClick;
            cancelButton.Click += HandleCancelButtonClick;

            flocSelectionControl.Mode = FunctionalLocationMode.GetAll(ClientSession.GetUserContext().SiteConfiguration);
        }

        public void HideReportGroupBox()
        {
            int column = dateRangeAndReportTableLayoutPanel.GetColumn(reportGroupBox);
            dateRangeAndReportTableLayoutPanel.ColumnStyles[column].Width = 0;
        }

        private void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormClose != null)
            {
                FormClose();
            }
        }

        private void InitializeAssignmentGrid(bool allowAssignmentNameFiltering)
        {
            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ReportParameterLayout, allowAssignmentNameFiltering), OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER);
            assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            assignmentGrid.TabIndex = 0;
            assignmentGrid.MaximumBands = 1;
            workAssignmentGroupBox.Controls.Add(assignmentGrid);
            assignmentGrid.Dock = DockStyle.Fill;
        }

        public string Title
        {
            set { Text = value; }
        }

        public List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments
        {
            set { assignmentGrid.Items = value; }
        }

        public List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> FilteredInAssignments
        {
            get { return new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(assignmentGrid.FilteredInItems); }
        }        

        public List<WorkAssignment> SelectedAssignments
        {
            get
            {
                List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> selectedAdapters = FilteredInAssignments.FindAll(a => a.Selected);
                return selectedAdapters.ConvertAll(a => a.GetWorkAssignment());
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

        public bool IncludeLogs
        {
            get { return logCheckBox.Checked; }
            set { logCheckBox.Checked = value; }
        }

        public bool IncludeDailyDirectives
        {
            get { return dailyDirectiveCheckBox.Checked; }
            set { dailyDirectiveCheckBox.Checked = value; }
        }

        public bool IncludeSummaryLogs
        {
            get { return summaryLogCheckBox.Checked; }
            set { summaryLogCheckBox.Checked = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IList<FunctionalLocation> UserSelectedFunctionalLocations
        {
            get { return flocSelectionControl.UserCheckedFunctionalLocations; }
            set
            {
                flocSelectionControl.UserCheckedFunctionalLocations = value;                
            }
        }

        public void SelectAllFunctionalLocations()
        {
            flocSelectionControl.UserCheckedFunctionalLocations = flocSelectionControl.RootFunctionalLocations;
        }

        public ShiftPattern StartShiftPattern
        {
            get { return (ShiftPattern) startShiftComboBox.SelectedItem; }
        }

        public ShiftPattern EndShiftPattern
        {
            get { return (ShiftPattern) endShiftComboBox.SelectedItem; }
        }

        public List<ShiftPattern> AvailableShiftPatterns
        {
            set
            {
                List<ShiftPattern> startShifts = new List<ShiftPattern>(value);
                startShiftComboBox.DataSource = startShifts;
                startShiftComboBox.DisplayMember = "Name";

                List<ShiftPattern> endShifts = new List<ShiftPattern>(value);
                endShiftComboBox.DataSource = endShifts;
                endShiftComboBox.DisplayMember = "Name";
            }
        }

        public void CloseForm()
        {
            Close();
        }

        public void SelectAllAssignments()
        {
            foreach (WorkAssignmentMultiSelectGridRenderer.DisplayAdapter displayAdapter in assignmentGrid.Items)
            {
                displayAdapter.Selected = true;
            }
        }

        public void DisableIncludeLogsCapability()
        {
            IncludeLogs = false;
            logCheckBox.Enabled = false;
        }

        public void DisableIncludeSummaryLogsCapability()
        {
            IncludeSummaryLogs = false;
            summaryLogCheckBox.Enabled = false;
        }

        public void DisableIncludeDailyDirectivesCapability()
        {
            IncludeDailyDirectives = false;
            dailyDirectiveCheckBox.Enabled = false;
        }

        public bool RunReportButtonEnabled
        {
            set
            {
                runReportButton.Enabled = value;
            }
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

        public void SetErrorForFunctionalLocationSelectionRequired()
        {
            errorProvider.SetError(functionalLocationsGroupBox, StringResources.FlocEmptyError);
        }

        public void SetErrorForWorkAssignmentSelectionRequired()
        {
            errorProvider.SetError(workAssignmentGroupBox, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public void SetErrorForMoreThanOneWorkAssignmentSelection()
        {
            errorProvider.SetError(workAssignmentGroupBox, StringResources.MoreThanOneWorkAssignmentCannotBeSelected);
        }

        public void SetSelectReportError()
        {
            errorProvider.SetError(reportGroupBox, StringResources.ReportSelectionError);
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
    }
}
