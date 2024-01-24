using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class TargetDefinitionAutoReApprovalConfigurationControl : UserControl, ITargetDefinitionAutoReApprovalConfigurationView
    {
        public event EventHandler SelectAllButtonClick;
        public event EventHandler ClearAllButtonClick;

        public TargetDefinitionAutoReApprovalConfigurationControl()
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
            get { return operationalModeChangeoltCheckBox.Checked; }
            set { operationalModeChangeoltCheckBox.Checked = value; }
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
            get { return documentLinksCheckBox.Checked; }
            set { documentLinksCheckBox.Checked = value; }
        }

        public bool FunctionalLocationChange
        {
            get { return functionalLocationChangeCheckBox.Checked; }
            set { functionalLocationChangeCheckBox.Checked = value; }
        }

        public bool PHTagChange
        {
            get { return phTagChangeCheckBox.Checked; }
            set { phTagChangeCheckBox.Checked = value; }
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

        public bool GenerateActionItemChange

        {
            get { return generateActionItemCheckBox.Checked; }
            set { generateActionItemCheckBox.Checked = value; }
        }

        public bool RequiresResponseWhenAlertedChange
        {
            get { return requiresResponseWhenAlertedChangeCheckBox.Checked; }
            set { requiresResponseWhenAlertedChangeCheckBox.Checked = value; }
        }

        public bool SuppressAlertChange
        {
            get { return suppressAlertCheckBox.Checked; }
            set { suppressAlertCheckBox.Checked = value; }
        }
    }
}
