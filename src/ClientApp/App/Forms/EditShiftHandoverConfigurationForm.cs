using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditShiftHandoverConfigurationForm : BaseForm, IEditShiftHandoverConfigurationForm
    {
        private DomainSummaryGrid<ShiftHandoverQuestion> questionGrid;
        private readonly IAssignmentMultiSelectFormView assignmentMultiSelectForm;      

        public EditShiftHandoverConfigurationForm(ShiftHandoverConfiguration editObject)
        {
            InitializeComponent();
            InitializePresenter(editObject);
            InitializeGrid();

            assignmentMultiSelectForm = new AssignmentMultiSelectForm();
        }

        private void InitializePresenter(ShiftHandoverConfiguration editObject)
        {
            EditShiftHandoverConfigurationFormPresenter presenter = 
                new EditShiftHandoverConfigurationFormPresenter(this, editObject);

            Load += presenter.Load;            
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Clicked;
            moveQuestionUpButton.Click += presenter.MoveQuestionUpButton_Clicked;
            moveQuestionDownButton.Click += presenter.MoveQuestionDownButton_Clicked;

            addQuestionButton.Click += presenter.AddQuestionButton_Clicked;
            editQuestionButton.Click += presenter.EditQuestionButton_Clicked;
            deleteQuestionButton.Click += presenter.DeleteQuestionButton_Clicked;

            workAssignmentButton.Click += presenter.SelectWorkAssignments_Click;    
        }

        private void InitializeGrid()
        {
            questionGrid = new DomainSummaryGrid<ShiftHandoverQuestion>(
                new ShiftHandoverQuestionGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            questionGrid.Dock = DockStyle.Fill;
            questionGrid.DisplayLayout.GroupByBox.Hidden = true;            

            questionGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            questionGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            questionsGridPanel.Controls.Add(questionGrid);
        }

        public void ClearWorkAssignmentListBox()
        {
            WorkAssignments = new List<WorkAssignment>();
        }

        public List<WorkAssignment> WorkAssignments
        {
            get { return workAssignmentListBox.DataSource as List<WorkAssignment>; }
            set { workAssignmentListBox.DataSource = value; }
        }

        public string ShiftHandoverType
        {
            get { return shiftHandoverTypeTextField.Text.TrimWhitespace(); }
            set { shiftHandoverTypeTextField.Text = value; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }
       
        public void SetShiftHandoverTypeMissingError()
        {
            errorProvider.SetError(shiftHandoverTypeTextField, StringResources.FieldEmptyError);
        }

        public void SetAtLeastOneWorkAssignmentNotSelectedError()
        {
            errorProvider.SetError(workAssignmentListBox, StringResources.AtLeastOneWorkAssignmentMustBeSelected);
        }

        public List<ShiftHandoverQuestion> ShiftHandoverQuestions
        {
            set { questionGrid.Items = value; }
        }

        public ShiftHandoverQuestion SelectedQuestion
        {
            get { return questionGrid.SelectedItem; }
            set { questionGrid.SelectItemByReference(value); }
        }

        public ShiftHandoverQuestion LaunchAddEditQuestionForm(ShiftHandoverQuestion question)
        {
            AddEditShiftHandoverQuestionForm form = new AddEditShiftHandoverQuestionForm(question);
            return form.ShowDialogAndReturnQuestion(this);
        }

        public void SetAtLeastOneQuestionRequiredError()
        {
            errorProvider.SetError(questionsGridPanel, StringResources.QuestionRequiredError);
        }

        public void SelectFirstQuestion()
        {
            questionGrid.SelectFirstRow();
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        public DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments)
        {
            assignmentMultiSelectForm.ShowMultiSelectDialog(selectedAssignments);

            DialogResultAndOutput<IList<WorkAssignment>> result =
                new DialogResultAndOutput<IList<WorkAssignment>>(
                    assignmentMultiSelectForm.DialogResult, assignmentMultiSelectForm.SelectedAssignments);

            return result;
        }
    }
}
