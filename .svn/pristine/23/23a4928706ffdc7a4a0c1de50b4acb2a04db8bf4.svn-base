using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditCokerCardConfigurationForm : BaseForm, IEditCokerCardConfigurationFormView
    {
        private readonly ISingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private readonly IAssignmentMultiSelectFormView assignmentMultiSelectForm;      

        private DomainSummaryGrid<CokerCardConfigurationDrum> drumGrid;
        private DomainSummaryGrid<CokerCardConfigurationCycleStep> stepGrid;

        public EditCokerCardConfigurationForm(CokerCardConfiguration editObject)
        {
            InitializeComponent();

            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.LevelTwoAndAbove);
            assignmentMultiSelectForm = new AssignmentMultiSelectForm();

            InitializePresenter(editObject);
            InitializeGrids();
        }

        private void InitializeGrids()
        {
            drumGrid = new DomainSummaryGrid<CokerCardConfigurationDrum>(
                new CokerCardConfigurationDrumGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            drumGrid.Dock = DockStyle.Fill;
            drumGrid.DisplayLayout.GroupByBox.Hidden = true;
            drumPanel.Controls.Add(drumGrid);

            stepGrid = new DomainSummaryGrid<CokerCardConfigurationCycleStep>(
                new CokerCardConfigurationCycleStepGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            stepGrid.Dock = DockStyle.Fill;
            stepGrid.DisplayLayout.GroupByBox.Hidden = true;
            stepPanel.Controls.Add(stepGrid);
        }

        private void InitializePresenter(CokerCardConfiguration editObject)
        {
            EditCokerCardConfigurationFormPresenter presenter = new EditCokerCardConfigurationFormPresenter(this, editObject);

            Load += presenter.Load;
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Clicked;
            cancelButton.Click += presenter.CancelButton_Click;
            functionalLocationButton.Click += presenter.FunctionalLocationButton_Click;
            workAssignmentButton.Click += presenter.SelectWorkAssignments_Click;
            
            addDrumButton.Click += presenter.AddDrumButton_Click;
            editDrumButton.Click += presenter.EditDrumButton_Click;
            deleteDrumButton.Click += presenter.DeleteDrumButton_Click;

            addStepButton.Click += presenter.AddStepButton_Click;
            editStepButton.Click += presenter.EditStepButton_Click;
            deleteStepButton.Click += presenter.DeleteStepButton_Click;

            moveDrumUpButton.Click += presenter.DrumUpButton_Click;
            moveDrumDownButton.Click += presenter.DrumDownButton_Click;

            moveStepUpButton.Click += presenter.StepUpButton_Click;
            moveStepDownButton.Click += presenter.StepDownButton_Click;
        }

        public string ConfigurationName
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionalLocationTextBox, value.Description);
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = value;
                }
            }
        }

        public List<WorkAssignment> WorkAssignments
        {
            get { return workAssignmentListBox.DataSource as List<WorkAssignment> ?? new List<WorkAssignment>(); }
            set
            {
                List<WorkAssignment> sortedList = new List<WorkAssignment>(value);
                sortedList.Sort((x,y) => x.Name.CompareTo(y.Name));
                workAssignmentListBox.DataSource = sortedList;
            }
        }

        public IList<CokerCardConfigurationDrum> Drums
        {
            set { drumGrid.Items = value; }
            get { return drumGrid.Items; }
        }

        public IList<CokerCardConfigurationCycleStep> Steps
        {
            get { return stepGrid.Items; }
            set { stepGrid.Items = value; }
        }

        public CokerCardConfigurationDrum SelectedDrum
        {
            get { return drumGrid.SelectedItem; }
            set { drumGrid.SelectItemByReference(value); }
        }

        public CokerCardConfigurationCycleStep SelectedStep
        {
            get { return stepGrid.SelectedItem; }
            set { stepGrid.SelectItemByReference(value); }
        }

        public void SelectFirstDrum()
        {
            drumGrid.SelectFirstRow();
        }

        public void SelectFirstStep()
        {
            stepGrid.SelectFirstRow();
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return new DialogResultAndOutput<FunctionalLocation>(result, functionalLocationSelectorForm.SelectedFunctionalLocation);
        }

        public string ShowAddItemForm(string formTitle, string value)
        {
            AddEditCokerCardConfigurationChildItemForm form = new AddEditCokerCardConfigurationChildItemForm(formTitle, value);
            return form.ShowDialogAndReturnName(this);
        }

        public DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments)
        {
            assignmentMultiSelectForm.ShowMultiSelectDialog(selectedAssignments);

            DialogResultAndOutput<IList<WorkAssignment>> result =
                new DialogResultAndOutput<IList<WorkAssignment>>(
                    assignmentMultiSelectForm.DialogResult, assignmentMultiSelectForm.SelectedAssignments);

            return result;
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetConfigurationNameMissingError()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public void SetFunctionalLocationMissingError()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocNotSelectedError);
        }

        public void SetAtLeastOneDrumRequiredError()
        {
            errorProvider.SetError(drumPanel, StringResources.AtLeastOneDrumRequiredValidationError);
        }

        public void SetAtLeastOneStepRequiredError()
        {
            errorProvider.SetError(stepPanel, StringResources.AtLeastOneCycleStepRequiredValidationError);
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }
    }
}
