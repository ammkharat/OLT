using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ShiftHandoverEmailConfigurationAddEditForm : BaseForm, IShiftHandoverEmailConfigurationAddEditFormView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> assignmentGrid; 

        public ShiftHandoverEmailConfigurationAddEditForm()
        {
            InitializeComponent();
            InitializeAssignmentGrid();

            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
        }

        private void HandleSaveButtonClicked(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(this, EventArgs.Empty);
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(this, EventArgs.Empty);
            }
        }
        
        private void InitializeAssignmentGrid()
        {
            assignmentGrid = new SummaryGrid<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(
                    new WorkAssignmentMultiSelectGridRenderer(WorkAssignmentMultiSelectGridRenderer.Layout.ConfigurationLayout), OltGridAppearance.EDIT_ROW_SELECT_WITH_FILTER);
            assignmentGrid.DisplayLayout.GroupByBox.Hidden = true;
            assignmentGrid.TabIndex = 0;
            assignmentGrid.MaximumBands = 1;
            gridPanel.Controls.Add(assignmentGrid);
            assignmentGrid.Dock = DockStyle.Fill;
        }

        public List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments
        {
            set { assignmentGrid.Items = value; }
            get { return new List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter>(assignmentGrid.Items); }
        }
        
        public List<ShiftPattern> Shifts
        {            
            set { shiftComboBox.DataSource = value; }
        }
        
        public ShiftPattern SelectedShift
        {
            get { return (ShiftPattern) shiftComboBox.SelectedItem; }
            set { shiftComboBox.SelectedItem = value; }
        }

        public Time Time
        {
            get { return timePicker.Value; }
            set { timePicker.Value = value; }
        }

        public string EmailAddressList
        {
            get { return emailAddressTextBox.Text; }
            set { emailAddressTextBox.Text = value; }
        }
       
        public void SetNoShiftSelectedError()
        {
            errorProvider.SetError(shiftComboBox, StringResources.NoShiftSelectedError);
        }

        public void SetEmailAddressListError()
        {
            errorProvider.SetError(emailAddressTextBox, StringResources.NoEmailAddressError);
        }

        public void SetNoWorkAssignmentSelectedError()
        {
            errorProvider.SetError(gridPanel, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();    
        }
    }
}
