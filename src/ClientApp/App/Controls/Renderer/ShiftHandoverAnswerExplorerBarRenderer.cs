using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinExplorerBar;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class ShiftHandoverAnswerExplorerBarRenderer : BaseExplorerBarRenderer
    {
        private const int NUMBER_OF_GROUPS_THAT_ARE_DISPLAYED_AFTER_ANSWERS = 2;
        private const int DEFAULT_HEIGHT = 60;

        private enum BarGroupType
        {
            Answer
        }

        private readonly List<ShiftHandoverAnswerControl> answerControls = new List<ShiftHandoverAnswerControl>();

        public ShiftHandoverAnswerExplorerBarRenderer(Form form, OltExplorerBar explorerBar)
            : base(form, explorerBar, 100, false)
        {
        }

        public void SetAnswers(List<ShiftHandoverAnswer> value)
        {
            const BarGroupType groupType = BarGroupType.Answer;

            RemoveExistingBarGroup(groupType);
            foreach (ShiftHandoverAnswerControl control in answerControls)
            {
                control.RadioButtonChecked -= AnswerControl_RadioButtonChecked;
                control.Dispose();
            }
            answerControls.Clear();

            int numberOfGroupsWithNoType = GetNumberOfGroupsWithNoType();
            if (value.Count > 0)
            {
                UltraExplorerBarGroup barGroup = AddLine(RendererStringResources.Questions, groupType);
                int index = Math.Max(numberOfGroupsWithNoType - NUMBER_OF_GROUPS_THAT_ARE_DISPLAYED_AFTER_ANSWERS, 0);                
                explorerBar.Groups.Reposition(barGroup, index);
            }

            for (int i = 0; i < value.Count; i++)
            {
                ShiftHandoverAnswer answer = value[i];

                ShiftHandoverAnswerControl singleAnswerControl = new ShiftHandoverAnswerControl();
                singleAnswerControl.RadioButtonChecked += AnswerControl_RadioButtonChecked;
                singleAnswerControl.SetAnswer(i + 1, answer);

               // UltraExplorerBarGroup barGroup = AddBarGroupFill(singleAnswerControl, groupType, GetHeight(answer.IsCompleted && answer.Answer));
                UltraExplorerBarGroup barGroup = AddBarGroupFill(singleAnswerControl, groupType, GetHeight(answer.IsCompleted && singleAnswerControl.Commentboxenabled));//Added by ppanigrahi
                explorerBar.Groups.Reposition(barGroup, Math.Max(numberOfGroupsWithNoType, 2) + 1 + i - NUMBER_OF_GROUPS_THAT_ARE_DISPLAYED_AFTER_ANSWERS);
                answerControls.Add(singleAnswerControl);
            }
        }

        private void AnswerControl_RadioButtonChecked(ShiftHandoverAnswerControl control, bool yesChecked)
        {
            if (control.Commentboxenabled)
            {

                UltraExplorerBarContainerControl container = control.Parent as UltraExplorerBarContainerControl;
                if (container != null)
                {
                    UltraExplorerBarGroup barGroup = GetBarGroup(container);
                    if (barGroup != null)
                    {

                        int height = GetHeight(yesChecked);
                        barGroup.Settings.ContainerHeight = height;


                    }

                }
            }
            else
            {
                UltraExplorerBarContainerControl container = control.Parent as UltraExplorerBarContainerControl;
                if (container != null)
                {
                    UltraExplorerBarGroup barGroup = GetBarGroup(container);
                    barGroup.Settings.ContainerHeight=60;

                }
                

            }



        }
        
        private static int GetHeight(bool answerIsYes)
        {
            int height =  DEFAULT_HEIGHT;
            if (answerIsYes)
            {
                height = DEFAULT_HEIGHT * 3;
            }
           
            return height;
        }

        private UltraExplorerBarGroup GetBarGroup(UltraExplorerBarContainerControl container)
        {
            foreach (UltraExplorerBarGroup barGroup in explorerBar.Groups)
            {
                if (ReferenceEquals(barGroup.Container, container))
                {
                    return barGroup;
                }
            }
            return null;
        }

        public bool? YesNoAnswer(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl control = GetAnswerControl(answer);
            return control.YesNoAnswer;
        }

        public string GetAnswerComments(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl control = GetAnswerControl(answer);
            return control.CommentsText;
        }
        //Added by ppanigrahi
        public bool GetControlEnabled(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl control = GetAnswerControl(answer);

            
            return control.Commentboxenabled;

        }
        //Added by ppanigrahi
       
        private ShiftHandoverAnswerControl GetAnswerControl(ShiftHandoverAnswer answer)
        {
            return GetAnswerControl(answer.ShiftHandoverQuestionId);
        }

        private ShiftHandoverAnswerControl GetAnswerControl(long questionId)
        {
            foreach (ShiftHandoverAnswerControl answerControl in answerControls)
            {
                if (Equals(answerControl.Answer.ShiftHandoverQuestionId, questionId))
                {
                    return answerControl;
                }
            }

            return null;
        }

        public void SetCommentsError(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(answer);
            answerControl.SetCommentsError();
        }

        public void SetYesNoError(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(answer);
            answerControl.SetYesNoError();
        }

        public void ClearErrorProviders()
        {
            answerControls.ForEach(control => control.ClearErrorProviders());
        }

        public void SetHelpText(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.IdValue);
            answerControl.SetHelpText(question.HelpText);
        }
        public void SetYesNo(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.IdValue);
            answerControl.SetYesNo(question.YesNoValue);
        }
        public void SetEmailList(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.IdValue);
            answerControl.SetEmailList(question.EmailList);
        }

        public override void Dispose()
        {
            foreach (ShiftHandoverAnswerControl control in answerControls)
            {
                control.Dispose();
            }
            answerControls.Clear();
        }

        protected override object GetResizableGroupType()
        {
            return BarGroupType.Answer;
        }
    }
}
