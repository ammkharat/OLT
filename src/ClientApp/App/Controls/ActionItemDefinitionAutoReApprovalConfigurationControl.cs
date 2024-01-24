using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ActionItemDefinitionAutoReApprovalConfigurationControl : UserControl, IActionItemDefinitionAutoReApprovalConfigurationView
    {
        public event EventHandler SelectAllButtonClick;
        public event EventHandler ClearAllButtonClick;

        public ActionItemDefinitionAutoReApprovalConfigurationControl()
        {
            InitializeComponent();
            selectAllButton.Click += OnSelectAllButtonClick;
            clearButton.Click += OnClearAllButtonClick;
        }
        
        private void OnSelectAllButtonClick(object sender, EventArgs e)
        {
            if (SelectAllButtonClick != null)
                SelectAllButtonClick(this, e);
        }

        private void OnClearAllButtonClick(object sender, EventArgs e)
        {
            if (ClearAllButtonClick != null)
                ClearAllButtonClick(this, e);
        }

        public bool NameChange
        {
            get { return nameChangeCheckBox.Checked; }
            set { nameChangeCheckBox.Checked = value; }
        }

        public bool CategoryChange
        {
            get { return categoryChangeCheckBox.Checked; }
            set { categoryChangeCheckBox.Checked = value; }
        }

        public bool OperationalModeChange
        {
            get { return operationalModeChangeCheckBox.Checked; }
            set { operationalModeChangeCheckBox.Checked = value; }
        }

        public bool PriorityChange
        {
            get { return priorityChangeCheckBox.Checked; }
            set { priorityChangeCheckBox.Checked = value; }
        }

        public bool DescriptionChange
        {
            get { return descriptionChangeCheckBox.Checked; }
            set { descriptionChangeCheckBox.Checked = value; }
        }

        public bool DocumentLinksChange
        {
            get { return documentLinksChangeCheckBox.Checked; }
            set { documentLinksChangeCheckBox.Checked = value; }
        }

        public bool FunctionalLocationsChange
        {
            get { return functionalLocationsChangeCheckBox.Checked; }
            set { functionalLocationsChangeCheckBox.Checked = value; }
        }

        public bool TargetDependenciesChange
        {
            get { return targetDependenciesCheckBox.Checked; }
            set { targetDependenciesCheckBox.Checked = value; }
        }

        public bool ScheduleChange
        {
            get { return scheduleChangeCheckBox.Checked; }
            set { scheduleChangeCheckBox.Checked = value; }
        }

        public bool RequiresResponseWhenTriggeredChange
        {
            get { return requiresResponseWhenTriggeredChangeCheckBox.Checked; }
            set { requiresResponseWhenTriggeredChangeCheckBox.Checked = value; }
        }

        public bool AssignmentChange
        {
            get { return assignmentChangeCheckBox.Checked; }
            set { assignmentChangeCheckBox.Checked = value; }
        }

        public bool ActionItemGenerationModeChange
        {
            get { return actionItemGenerationModeChangeCheckBox.Checked; }
            set { actionItemGenerationModeChangeCheckBox.Checked = value; }
        }
    }
}
