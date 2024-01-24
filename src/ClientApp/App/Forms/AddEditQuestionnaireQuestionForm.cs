using System;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditQuestionnaireQuestionForm : BaseForm
    {
        private readonly bool isAddMode;

        private readonly QuestionnaireSection section;
        private bool cancelClicked;
        private Question question;

        public AddEditQuestionnaireQuestionForm(QuestionnaireSection section, Question question)
        {
            InitializeComponent();

            this.section = section;
            this.question = question;

            isAddMode = question == null;
            SetUpControlsForAddOrEditMode();

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;

            this.ActiveControl = questionTextBox;
        }

        private string QuestionFromTextBox
        {
            get { return questionTextBox.Text.TrimOrNull(); }
        }

        private string WeightFromTextBox
        {
            get { return weightTextBox.Text.TrimOrNull(); }
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            var questionText = QuestionFromTextBox;
            var weight = Int32.Parse(WeightFromTextBox);

            var sectionId = (section != null) ? section.IdValue : 0;
            var configId = (section != null) ? section.QuestionnaireConfigurationId : 0;

            if (isAddMode)
            {
                question = new Question(0, sectionId, configId, 0, weight, questionText);
            }
            else
            {
                question.QuestionText = questionText;
                question.Weight = weight;
            }

            Close();
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();

            var hasError = false;

            int weight;

            if (QuestionFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(questionTextBox, StringResources.InvalidQuestionnaireQuestion);
                hasError = true;
            }
            if (WeightFromTextBox.IsNullOrEmptyOrWhitespace() || Int32.TryParse(WeightFromTextBox, out weight) == false)
            {
                errorProvider.SetError(weightTextBox, StringResources.InvalidQuestionnaireWeight);
                hasError = true;
            }

            return !hasError;
        }

        private void SetUpControlsForAddOrEditMode()
        {
            Text = isAddMode ? StringResources.AddQuestionnaireQuestion : StringResources.EditQuestionnaireQuestion;

            if (!isAddMode)
            {
                questionTextBox.Text = question.QuestionText;
                weightTextBox.Text = question.Weight.ToString();
            }
        }

        public Question ShowDialogAndReturnQuestion(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : question;
        }
    }
}