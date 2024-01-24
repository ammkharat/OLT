using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EditShiftHandoverConfigurationFormPresenter
    {
        private readonly IEditShiftHandoverConfigurationForm view;
        private readonly ShiftHandoverConfiguration editObject;
        private List<ShiftHandoverQuestion> questions;
        
        private readonly IShiftHandoverService shiftHandoverService;        

        public EditShiftHandoverConfigurationFormPresenter(IEditShiftHandoverConfigurationForm view, ShiftHandoverConfiguration editObject)
        {
            this.view = view;
            this.editObject = editObject;

            shiftHandoverService = ClientServiceRegistry.Instance.GetService<IShiftHandoverService>();
        }

        public void Load(object sender, EventArgs e)
        {     
            questions = new List<ShiftHandoverQuestion>();
            if(editObject != null)
            {
                questions.AddRange(editObject.Questions);
            }            

            SortAndSetQuestionsOnGrid();
            view.SelectFirstQuestion();

            SetUpWorkAssignments();

            view.ShiftHandoverType = editObject != null ? editObject.Name : null;
        }

        private void SortAndSetQuestionsOnGrid()
        {
            DisplayOrderHelper.SortAndResetDisplayOrder(questions);
            view.ShiftHandoverQuestions = questions;
        }
       
        public void SaveAndCloseButton_Clicked(object sender, EventArgs e)
        {
            if(ValidateViewSuccessful())
            {
                if (editObject != null)
                {
                    LoadEditObjectFromViewAndSave();
                }
                else
                {
                    CreateNewObjectFromViewAndSave(); 
                }

                view.Close();
            }           
        }

        private void CreateNewObjectFromViewAndSave()
        {
            ShiftHandoverConfiguration configuration = 
                new ShiftHandoverConfiguration(null, view.WorkAssignments, view.ShiftHandoverType, questions);

            shiftHandoverService.InsertShiftHandoverConfiguration(configuration);
        }
                
        private void LoadEditObjectFromViewAndSave()
        {
            editObject.Name = view.ShiftHandoverType;
            
            editObject.WorkAssignments.Clear();
            editObject.WorkAssignments.AddRange(view.WorkAssignments);

            List<ShiftHandoverQuestion> deletedQuestions = new List<ShiftHandoverQuestion>();
            foreach (ShiftHandoverQuestion oldQuestion in editObject.Questions)
            {
                if (oldQuestion.IsInDatabase() && !questions.ExistsById(oldQuestion))
                {
                    deletedQuestions.Add(oldQuestion);
                }
            }

            editObject.Questions.Clear();
            editObject.Questions.AddRange(questions);

            shiftHandoverService.UpdateShiftHandoverConfiguration(editObject, deletedQuestions);
        }

        private bool ValidateViewSuccessful()
        {
            view.ClearErrors();
            bool hasErrors = false;

            if (view.ShiftHandoverType.IsNullOrEmptyOrWhitespace())
            {
                view.SetShiftHandoverTypeMissingError();
                hasErrors = true;
            }

            if (view.WorkAssignments.Count == 0)
            {
                view.SetAtLeastOneWorkAssignmentNotSelectedError();
                hasErrors = true;
            }

            if (questions.Count == 0)
            {
                view.SetAtLeastOneQuestionRequiredError();
                hasErrors = true;
            }

            return !hasErrors;
        }

        private void SetUpWorkAssignments()
        {
            if (editObject != null)
            {
                view.WorkAssignments = new List<WorkAssignment>(editObject.WorkAssignments);
            }
            else
            {
                view.WorkAssignments = new List<WorkAssignment>();
            }
        }

        public void MoveQuestionUpButton_Clicked(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                return;
            }

            ShiftHandoverQuestion shiftHandoverQuestion = view.SelectedQuestion;

            int index = questions.IndexOf(shiftHandoverQuestion);

            if (index == 0)
            {
                return;
            }

            questions.Remove(shiftHandoverQuestion);
            questions.Insert(index - 1, shiftHandoverQuestion);

            DisplayOrderHelper.ResetDisplayValues(questions);       
            SortAndSetQuestionsOnGrid();

            view.SelectedQuestion = shiftHandoverQuestion;
        }
       
        public void MoveQuestionDownButton_Clicked(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                return;
            }

            ShiftHandoverQuestion shiftHandoverQuestion = view.SelectedQuestion;

            int index = questions.IndexOf(shiftHandoverQuestion);

            if (index == questions.Count - 1)
            {
                return;
            }

            questions.Remove(shiftHandoverQuestion);
            questions.Insert(index + 1, shiftHandoverQuestion);

            DisplayOrderHelper.ResetDisplayValues(questions);
            SortAndSetQuestionsOnGrid();

            view.SelectedQuestion = shiftHandoverQuestion;
        }
        
        public void AddQuestionButton_Clicked(object sender, EventArgs e)
        {            
            ShiftHandoverQuestion newQuestion = view.LaunchAddEditQuestionForm(null);
            if (newQuestion != null)
            {
                newQuestion.DisplayOrder = DisplayOrderHelper.GetHighestDisplayOrderValue(questions) + 1;
                questions.Add(newQuestion);
                SortAndSetQuestionsOnGrid();
                view.SelectedQuestion = newQuestion;
            }
        }

        public void EditQuestionButton_Clicked(object sender, EventArgs e)
        {
            ShiftHandoverQuestion selectedQuestion = view.SelectedQuestion;
            if (selectedQuestion != null)
            {
                view.LaunchAddEditQuestionForm(selectedQuestion);
                SortAndSetQuestionsOnGrid();
                view.SelectedQuestion = selectedQuestion;
            }
        }

        public void DeleteQuestionButton_Clicked(object sender, EventArgs e)
        {
            ShiftHandoverQuestion selectedQuestion = view.SelectedQuestion;
            if (selectedQuestion != null)
            {
                if(view.UserIsSure())
                {
                    questions.Remove(selectedQuestion);
                    SortAndSetQuestionsOnGrid();
                    view.SelectFirstQuestion();   
                }                
            }            
        }

        public void SelectWorkAssignments_Click(object sender, EventArgs e)
        {
            List<WorkAssignment> selectedAssignments = view.WorkAssignments;
            DialogResultAndOutput<IList<WorkAssignment>> result = view.ShowWorkAssignmentSelector(selectedAssignments);

            if (result.Result == DialogResult.OK)
            {
                IList<WorkAssignment> assignments = result.Output;
                view.WorkAssignments = assignments == null ? new List<WorkAssignment>() : new List<WorkAssignment>(assignments);
            }
        }
    }
}
