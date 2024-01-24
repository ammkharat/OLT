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
    public partial class DateRangeReportCriteriaForm : BaseForm, IDateRangeReportCriteriaFormView
    {
        public event Action FormLoad;
        public event Action FormClose;
        public event Action RunReportButtonClick;
        public event Action CancelButtonClick;

        private SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid;

        public DateRangeReportCriteriaForm()
        {
            InitializeComponent();
            Load += HandleLoad;
            FormClosing += HandleFormClosing;
            runReportButton.Click += HandleRunReportButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        private void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormClose != null)
            {
                FormClose();
            }
        }

        public string Title
        {
            set { Text = value; }
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


        public bool RunReportButtonEnabled
        {
            set { runReportButton.Enabled = value; }
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