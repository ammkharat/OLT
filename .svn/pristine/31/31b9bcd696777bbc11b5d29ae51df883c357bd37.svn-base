using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using System.IO;
using System.Data;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public partial class DateRangeWithActionItemReadingReportCriteriaForm : BaseForm, IDateRangeWithActionItemReadingReportCriteriaFormView
    {
        public event Action FormLoad;
        public event Action FormClose;
        public event Action RunReportButtonClick;
        public event Action CancelButtonClick;
        public event Action GetDefinitionsButtonClick;

        public DateRangeWithActionItemReadingReportCriteriaForm()
        {
            InitializeComponent();

            Load += HandleLoad;
            FormClosing += HandleFormClosing;
            runReportButton.Click += HandleRunReportButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            GetDefinitionsButton.Click += HandleGetDefinitionClick;

            Array itemValues = System.Enum.GetValues(typeof(DevExpress.XtraCharts.ViewType));
            Array itemNames = System.Enum.GetNames(typeof(DevExpress.XtraCharts.ViewType));


            GrapgTypeCombo.DataSource = Enum.GetValues(typeof(DevExpress.XtraCharts.ViewType));
            GrapgTypeCombo.SelectedItem = DevExpress.XtraCharts.ViewType.Line;
            
        }

        //public void HideReportGroupBox()
        //{
        //    int column = dateRangeAndReportTableLayoutPanel.GetColumn(reportGroupBox);
        //    dateRangeAndReportTableLayoutPanel.ColumnStyles[column].Width = 0;
        //}

        private void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (FormClose != null)
            {
                FormClose();
            }
        }

        //private void InitializeAssignmentGrid(bool allowAssignmentNameFiltering)
        //{
        //    assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ReportParameterLayout, allowAssignmentNameFiltering), OltGridAppearance.EDIT_CELL_SELECT_WITH_FILTER);
        //    assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
        //    assignmentGrid.TabIndex = 0;
        //    assignmentGrid.MaximumBands = 1;
        //    actionItemsGroupBox.Controls.Add(assignmentGrid);
        //    assignmentGrid.Dock = DockStyle.Fill;
        //}

        public string Title
        {
            set { Text = value; }
        }

        public List<ActionItemDefinition> ActionitemDefinitions
        {
            set
            {
                ActionItemDefCombo.ValueMember = "Id";
                ActionItemDefCombo.DisplayMember = "Name";
                ActionItemDefCombo.DataSource = value;
            }
        }

        //public List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> FilteredInAssignments
        //{
        //    get { return new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(assignmentGrid.FilteredInItems); }
        //}        

        //public List<WorkAssignment> SelectedAssignments
        //{
        //    get
        //    {
        //        List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> selectedAdapters = FilteredInAssignments.FindAll(a => a.Selected);
        //        return selectedAdapters.ConvertAll(a => a.GetWorkAssignment());
        //    }
        //}

        public long SelectedAId
        {
            get { return (long)((Com.Suncor.Olt.Common.Domain.DomainObject)ActionItemDefCombo.SelectedValue).Id; }
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


        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Browsable(false)]
        //public IList<FunctionalLocation> UserSelectedFunctionalLocations
        //{
        //    get { return flocSelectionControl.UserCheckedFunctionalLocations; }
        //    set
        //    {
        //        flocSelectionControl.UserCheckedFunctionalLocations = value;                
        //    }
        //}

        //public void SelectAllFunctionalLocations()
        //{
        //    flocSelectionControl.UserCheckedFunctionalLocations = flocSelectionControl.RootFunctionalLocations;
        //}

        //public ShiftPattern StartShiftPattern
        //{
        //    get { return (ShiftPattern) startShiftComboBox.SelectedItem; }
        //}

        //public ShiftPattern EndShiftPattern
        //{
        //    get { return (ShiftPattern) endShiftComboBox.SelectedItem; }
        //}

        //public List<ShiftPattern> AvailableShiftPatterns
        //{
        //    set
        //    {
        //        List<ShiftPattern> startShifts = new List<ShiftPattern>(value);
        //        startShiftComboBox.DataSource = startShifts;
        //        startShiftComboBox.DisplayMember = "Name";

        //        List<ShiftPattern> endShifts = new List<ShiftPattern>(value);
        //        endShiftComboBox.DataSource = endShifts;
        //        endShiftComboBox.DisplayMember = "Name";
        //    }
        //}

        public void CloseForm()
        {
            Close();
        }

        //public long SelectedAID()
        //{
        //    return ActionItemDefCombo.SelectedValue();
        //}
        
        //public void SelectAllAssignments()
        //{
        //    foreach (WorkAssignmentMultiSelectGridRenderer.DisplayAdapter displayAdapter in assignmentGrid.Items)
        //    {
        //        displayAdapter.Selected = true;
        //    }
        //}


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
     public string ActionItemName
        {
         get
            {
              // return ActionItemDefCombo.SelectedText;
                return (ActionItemDefCombo.SelectedItem as ActionItemDefinition).Name;
            }
        }
        public string RptType
        {
           
            get
            {
                if (oltRadioExcel.Checked)
                {
                    return "Excel";
                }
                else
                {
                    return "Graph";
                }
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

        private void HandleGetDefinitionClick(object sender, EventArgs e)
        {
            if(GetDefinitionsButtonClick != null)
            {
                GetDefinitionsButtonClick();
                if(ActionItemDefCombo.Items.Count>0)
                {
                    buttonPanel.Enabled = true;
                }
            }
        }

        //public void SetErrorForFunctionalLocationSelectionRequired()
        //{
        //    errorProvider.SetError(functionalLocationsGroupBox, StringResources.FlocEmptyError);
        //}

        public void SetErrorForWorkAssignmentSelectionRequired()
        {
            errorProvider.SetError(actionItemsGroupBox, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public void SetErrorForMoreThanOneWorkAssignmentSelection()
        {
            errorProvider.SetError(actionItemsGroupBox, StringResources.MoreThanOneWorkAssignmentCannotBeSelected);
        }

        //public void SetSelectReportError()
        //{
        //    errorProvider.SetError(reportGroupBox, StringResources.ReportSelectionError);
        //}

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

        private void oltRadioGraph_CheckedChanged(object sender, EventArgs e)
        {
            GrapgTypeCombo.Enabled = oltRadioGraph.Checked;
          
        }


        public DevExpress.XtraCharts.ViewType graphtype { get{return (DevExpress.XtraCharts.ViewType) GrapgTypeCombo.SelectedItem;} }



    }
}
