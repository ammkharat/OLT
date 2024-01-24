using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ProcedureDeviationRiskAssessmentControl : UserControl
    {
        private const string AttendeeTypeColumnKey = "AttendeeType";
        private const string AttendeeNameColumnKey = "AttendeeName";
        private const string DisableEditColumnKey = "DisableEdit";

        public ProcedureDeviationRiskAssessmentControl()
        {
            InitializeComponent();

            InitializeRiskAssessmentAttendeesGrid();

            SetAnswer1CheckBoxHandlers();
            SetAnswer2CheckBoxHandlers();
            SetAnswer3CheckBoxHandlers();
            SetAnswer4CheckBoxHandlers();
            SetAnswer5CheckBoxHandlers();
        }

        public string GroupBoxLabel
        {
            set { riskAssessmentGroupBox.Text = value; }
            get { return riskAssessmentGroupBox.Text; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AffectsToe
        {
            get { return affectsToeYesRadioButton.Checked; }
            set
            {
                affectsToeYesRadioButton.Checked = value;
                affectsToeNoRadioButton.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter> RiskAssessmentAttendeeItems
        {
            get
            {
                var items =
                    attendeesGrid.DataSource as List<ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter>;
                return items;
            }
            set
            {
                var items = new List<ProcedureDeviationFormRiskAssessmentAttendeeGridDisplayAdapter>();

                if (value != null)
                {
                    items.AddRange(value);
                }

                attendeesGrid.DataSource = items;
                attendeesGrid.ResetBindings();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Answer1
        {
            get { return yes1CheckBox.Checked; }
            set
            {
                yes1CheckBox.Checked = value;
                no1CheckBox.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Answer2
        {
            get { return yes2CheckBox.Checked; }
            set
            {
                yes2CheckBox.Checked = value;
                no2CheckBox.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Answer3
        {
            get { return yes3CheckBox.Checked; }
            set
            {
                yes3CheckBox.Checked = value;
                no3CheckBox.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Answer4
        {
            get { return yes4CheckBox.Checked; }
            set
            {
                yes4CheckBox.Checked = value;
                no4CheckBox.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Answer5
        {
            get { return yes5CheckBox.Checked; }
            set
            {
                yes5CheckBox.Checked = value;
                no5CheckBox.Checked = !value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Comments
        {
            get { return question6ControlsTextBox.Text; }
            set { question6ControlsTextBox.Text = value; }
        }

        public bool Answer1Checked
        {
            get { return yes1CheckBox.Checked || no1CheckBox.Checked; }
        }
        public bool Answer2Checked
        {
            get { return yes2CheckBox.Checked || no2CheckBox.Checked; }
        }
        public bool Answer3Checked
        {
            get { return yes3CheckBox.Checked || no3CheckBox.Checked; }
        }
        public bool Answer4Checked
        {
            get { return yes4CheckBox.Checked || no4CheckBox.Checked; }
        }
        public bool Answer5Checked
        {
            get { return yes5CheckBox.Checked || no5CheckBox.Checked; }
        }

        public bool HasAtLeastOneYesAnswer
        {
            get { return Answer1 || Answer2 || Answer3 || Answer4 || Answer5; }
        }

        public void ResetAnswers()
        {
            yes1CheckBox.Checked = false;
            no1CheckBox.Checked = false;

            yes2CheckBox.Checked = false;
            no2CheckBox.Checked = false;

            yes3CheckBox.Checked = false;
            no3CheckBox.Checked = false;

            yes4CheckBox.Checked = false;
            no4CheckBox.Checked = false;

            yes5CheckBox.Checked = false;
            no5CheckBox.Checked = false;
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public void SetErrorForTechnicalSMERequired()
        {
            errorProvider.SetError(affectsToeNoRadioButton, StringResources.ProcedureDeviationTechnicalSMERequired);
        }

        public void SetErrorForAnswer1NotSet()
        {
            errorProvider.SetError(no1CheckBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForAnswer2NotSet()
        {
            errorProvider.SetError(no2CheckBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForAnswer3NotSet()
        {
            errorProvider.SetError(no3CheckBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForAnswer4NotSet()
        {
            errorProvider.SetError(no4CheckBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForAnswer5NotSet()
        {
            errorProvider.SetError(no5CheckBox, StringResources.FieldCannotBeEmpty);
        }

        public void SetErrorForCommentsNotSet()
        {
            errorProvider.SetError(question6ControlsTextBox, StringResources.FieldCannotBeEmpty);
        }

        private void SetAnswer1CheckBoxHandlers()
        {
            yes1CheckBox.CheckedChanged += Answer1CheckBoxOnCheckedChanged;
            no1CheckBox.CheckedChanged += Answer1CheckBoxOnCheckedChanged;
        }

        private void RemoveAnswer1CheckBoxHandlers()
        {
            yes1CheckBox.CheckedChanged -= Answer1CheckBoxOnCheckedChanged;
            no1CheckBox.CheckedChanged -= Answer1CheckBoxOnCheckedChanged;
        }

        private void Answer1CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveAnswer1CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in answer1PanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetAnswer1CheckBoxHandlers();
            }
        }

        private void SetAnswer2CheckBoxHandlers()
        {
            yes2CheckBox.CheckedChanged += Answer2CheckBoxOnCheckedChanged;
            no2CheckBox.CheckedChanged += Answer2CheckBoxOnCheckedChanged;
        }

        private void RemoveAnswer2CheckBoxHandlers()
        {
            yes2CheckBox.CheckedChanged -= Answer2CheckBoxOnCheckedChanged;
            no2CheckBox.CheckedChanged -= Answer2CheckBoxOnCheckedChanged;
        }

        private void Answer2CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveAnswer2CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in answer2PanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetAnswer2CheckBoxHandlers();
            }
        }

        private void SetAnswer3CheckBoxHandlers()
        {
            yes3CheckBox.CheckedChanged += Answer3CheckBoxOnCheckedChanged;
            no3CheckBox.CheckedChanged += Answer3CheckBoxOnCheckedChanged;
        }

        private void RemoveAnswer3CheckBoxHandlers()
        {
            yes3CheckBox.CheckedChanged -= Answer3CheckBoxOnCheckedChanged;
            no3CheckBox.CheckedChanged -= Answer3CheckBoxOnCheckedChanged;
        }

        private void Answer3CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveAnswer3CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in answer3PanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetAnswer3CheckBoxHandlers();
            }
        }

        private void SetAnswer4CheckBoxHandlers()
        {
            yes4CheckBox.CheckedChanged += Answer4CheckBoxOnCheckedChanged;
            no4CheckBox.CheckedChanged += Answer4CheckBoxOnCheckedChanged;
        }

        private void RemoveAnswer4CheckBoxHandlers()
        {
            yes4CheckBox.CheckedChanged -= Answer4CheckBoxOnCheckedChanged;
            no4CheckBox.CheckedChanged -= Answer4CheckBoxOnCheckedChanged;
        }

        private void Answer4CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveAnswer4CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in answer4PanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetAnswer4CheckBoxHandlers();
            }
        }

        private void SetAnswer5CheckBoxHandlers()
        {
            yes5CheckBox.CheckedChanged += Answer5CheckBoxOnCheckedChanged;
            no5CheckBox.CheckedChanged += Answer5CheckBoxOnCheckedChanged;
        }

        private void RemoveAnswer5CheckBoxHandlers()
        {
            yes5CheckBox.CheckedChanged -= Answer5CheckBoxOnCheckedChanged;
            no5CheckBox.CheckedChanged -= Answer5CheckBoxOnCheckedChanged;
        }

        private void Answer5CheckBoxOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            RemoveAnswer5CheckBoxHandlers();

            try
            {
                var currentSelectedCheckBox = sender as OltCheckBox;

                foreach (var control in answer5PanelControl.Controls)
                {
                    var currentCheckBox = control as OltCheckBox;

                    if (currentCheckBox != currentSelectedCheckBox)
                    {
                        currentCheckBox.Checked = false;
                    }
                }
            }
            finally
            {
                SetAnswer5CheckBoxHandlers();
            }
        }

        private void InitializeRiskAssessmentAttendeesGrid()
        {
            attendeesGrid.InitializeLayout += HandleImmediateApprovalGridInitializeLayoutEditMode;
            attendeesGrid.InitializeRow += HandleImmediateApprovalGridInitializeRow;
            attendeesGrid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
            attendeesGrid.DisplayLayout.Override.SelectedAppearancesEnabled = DefaultableBoolean.False;
        }

        private void HandleImmediateApprovalGridInitializeLayoutEditMode(object sender, InitializeLayoutEventArgs e)
        {
            var layout = e.Layout;
            var band = layout.Bands[0];

            foreach (var column in band.Columns)
            {
                column.CellActivation = (column.Key != AttendeeNameColumnKey)
                    ? Activation.NoEdit
                    : Activation.AllowEdit;
            }
        }

        private void HandleImmediateApprovalGridInitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Activation = Activation.AllowEdit;

            var disableEditValue =
                e.Row.Cells[attendeesGrid.DisplayLayout.Bands[0].Columns[DisableEditColumnKey]].Value;

            if (disableEditValue != null && (bool) disableEditValue)
            {
                e.Row.Activation = Activation.NoEdit;
            }
        }
    }
}