using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class AddEditQuestionnaireSectionFormPresenter
    {
        private readonly QuestionnaireConfiguration config;
        private readonly IQuestionnaireConfigurationService questionnaireConfigurationService;
        private readonly IAddEditQuestionnaireSectionForm view;
        private QuestionnaireSection editObject;
        private List<Question> questions;

        public AddEditQuestionnaireSectionFormPresenter(IAddEditQuestionnaireSectionForm view,
            QuestionnaireSection editObject)
        {
            this.view = view;
            this.editObject = editObject;

            questionnaireConfigurationService =
                ClientServiceRegistry.Instance.GetService<IQuestionnaireConfigurationService>();

            if (editObject != null)
            {
                config =
                    questionnaireConfigurationService.QueryQuestionnaireConfigurationById(
                        editObject.QuestionnaireConfigurationId);
            }
        }

        public void Load(object sender, EventArgs e)
        {
            questions = new List<Question>();
            if (editObject != null)
            {
                questions.AddRange(editObject.Questions);
            }

            SortAndSetQuestionsOnGrid();
            view.SelectFirstQuestion();
        }

        private void SortAndSetQuestionsOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(questions, true);
            view.Questions = questions;
        }

        private void UpdateSectionPercentWeighting()
        {
            if (config == null) return;

            if (editObject != null)
            {
                LoadEditObjectFromView();
            }
            else
            {
                CreateNewObjectFromView();
            }

            editObject.PercentageWeighting =
                QuestionnaireConfigurationHelper.RecalculatePercentageWeighting(config, editObject);
            view.PercentageWeight = editObject.PercentageWeightingAsString;
        }

        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if (ValidateViewSuccessful())
            {
                if (editObject != null)
                {
                    LoadEditObjectFromView();
                }
                else
                {
                    CreateNewObjectFromView();
                }

                view.Close();
            }
        }

        private void CreateNewObjectFromView()
        {
            var name = view.SectionName;

            editObject = new QuestionnaireSection(null, 0, 0, 0, name, questions);

            view.Section = editObject;
        }

        private void LoadEditObjectFromView()
        {
            editObject.Name = view.SectionName;

            editObject.Questions.Clear();
            editObject.Questions.AddRange(questions);

            view.Section = editObject;
        }

        private bool ValidateViewSuccessful()
        {
            view.ClearErrors();
            var hasErrors = false;

            if (view.SectionName.IsNullOrEmptyOrWhitespace())
            {
                view.SetNameMissingError();
                hasErrors = true;
            }
            if (questions.Count == 0)
            {
                view.SetAtLeastOneQuestionRequiredError();
                hasErrors = true;
            }

            return !hasErrors;
        }

        public void MoveQuestionUpButton_Clicked(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                return;
            }

            var question = view.SelectedQuestion;

            var index = questions.IndexOf(question);

            if (index == 0)
            {
                return;
            }

            questions.Remove(question);
            questions.Insert(index - 1, question);

            DisplayOrderHelper.ResetDisplayValues(questions, true);
            SortAndSetQuestionsOnGrid();

            view.SelectedQuestion = question;
        }

        public void MoveQuestionDownButton_Clicked(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                return;
            }

            var question = view.SelectedQuestion;

            var index = questions.IndexOf(question);

            if (index == questions.Count - 1)
            {
                return;
            }

            questions.Remove(question);
            questions.Insert(index + 1, question);

            DisplayOrderHelper.ResetDisplayValues(questions, true);
            SortAndSetQuestionsOnGrid();

            view.SelectedQuestion = question;
        }

        public void AddQuestionButton_Clicked(object sender, EventArgs e)
        {
            var newQuestion = view.LaunchAddEditQuestionForm(editObject, null);
            if (newQuestion != null)
            {
                newQuestion.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(questions, true) + 1;
                questions.Add(newQuestion);
                SortAndSetQuestionsOnGrid();
                UpdateSectionPercentWeighting();
                view.SelectedQuestion = newQuestion;
            }
        }

        public void EditQuestionButton_Clicked(object sender, EventArgs e)
        {
            var selectedQuestion = view.SelectedQuestion;
            if (selectedQuestion != null)
            {
                view.LaunchAddEditQuestionForm(editObject, selectedQuestion);
                SortAndSetQuestionsOnGrid();
                UpdateSectionPercentWeighting();
                view.SelectedQuestion = selectedQuestion;
            }
        }

        public void DeleteQuestionButton_Clicked(object sender, EventArgs e)
        {
            var selectedQuestion = view.SelectedQuestion;
            if (selectedQuestion != null)
            {
                if (view.UserIsSure())
                {
                    questions.Remove(selectedQuestion);
                    SortAndSetQuestionsOnGrid();
                    UpdateSectionPercentWeighting();
                    view.SelectFirstQuestion();
                }
            }
        }
    }
}