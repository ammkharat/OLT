using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditQuestionnaireSectionForm : BaseForm, IAddEditQuestionnaireSectionForm
    {
        private readonly bool isAddMode;
        private bool cancelClicked;

        private DomainSummaryGrid<Question> questionGrid;
        private QuestionnaireSection section;

        public AddEditQuestionnaireSectionForm(QuestionnaireSection section)
        {
            InitializeComponent();

            this.section = section;

            isAddMode = section == null;
            SetUpControlsForAddOrEditMode();

            InitializePresenter(section);
            InitializeGrid();
        }

        public QuestionnaireSection Section
        {
            set { section = value; }
        }

        public string SectionName
        {
            get { return nameTextBox.Text.TrimOrNull(); }
            set { nameTextBox.Text = value; }
        }

        public string PercentageWeight
        {
            set { percentageWeightingLabel.Text = value + " %"; }
        }

        public List<Question> Questions
        {
            set { questionGrid.Items = value; }
        }

        public Question SelectedQuestion
        {
            get { return questionGrid.SelectedItem; }
            set { questionGrid.SelectItemByReference(value); }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetNameMissingError()
        {
            errorProvider.SetError(nameTextBox, StringResources.NameEmptyError);
        }

        public Question LaunchAddEditQuestionForm(QuestionnaireSection section, Question question)
        {
            var form = new AddEditQuestionnaireQuestionForm(section, question);
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

        private void InitializeGrid()
        {
            questionGrid = new DomainSummaryGrid<Question>(new QuestionGridRenderer(),
                OltGridAppearance.NON_OUTLOOK, string.Empty) {Dock = DockStyle.Fill};

            questionGrid.DisplayLayout.GroupByBox.Hidden = true;

            questionGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            questionGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            questionsGridPanel.Controls.Add(questionGrid);
        }

        private void InitializePresenter(QuestionnaireSection section)
        {
            var presenter =
                new AddEditQuestionnaireSectionFormPresenter(this, section);

            Load += presenter.Load;

            submitButton.Click += presenter.SaveAndCloseButton_Clicked;
            cancelButton.Click += HandleCancelButtonClicked;

            moveQuestionUpButton.Click += presenter.MoveQuestionUpButton_Clicked;
            moveQuestionDownButton.Click += presenter.MoveQuestionDownButton_Clicked;

            addQuestionButton.Click += presenter.AddQuestionButton_Clicked;
            editQuestionButton.Click += presenter.EditQuestionButton_Clicked;
            deleteQuestionButton.Click += presenter.DeleteQuestionButton_Clicked;
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        private void SetUpControlsForAddOrEditMode()
        {
            //submitButton.Text = isAddMode ? StringResources.AddButtonLabelNoAmpersand : StringResources.OKButtonLabel;
            //Text = isAddMode ? StringResources.AddQuestionnaireSection : StringResources.EditQuestionnaireSection;

            if (!isAddMode)
            {
                SectionName = section.Name;
                PercentageWeight = section.PercentageWeightingAsString;
            }
        }

        public QuestionnaireSection ShowDialogAndReturnSection(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : section;
        }
    }
}