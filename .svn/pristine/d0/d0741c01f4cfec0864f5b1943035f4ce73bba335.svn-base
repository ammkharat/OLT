using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    public class ShiftHandoverAnswerTableLayoutRenderer : IDisposable
    {
        private const int DEFAULT_HEIGHT = 60;

        private TableLayoutPanel tableLayoutPanel;
        private readonly List<ShiftHandoverAnswerControl> answerControls = new List<ShiftHandoverAnswerControl>();

        public ShiftHandoverAnswerTableLayoutRenderer(Form form, TableLayoutPanel tableLayoutPanel)
        {
            this.tableLayoutPanel = tableLayoutPanel;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;

            form.Disposed += HandleFormDisposed;
        }

        private void HandleFormDisposed(object sender, EventArgs e)
        {
            Form form = (Form) sender;
            form.Disposed -= HandleFormDisposed;
            tableLayoutPanel = null;
            Dispose();
        }

        public void SetAnswers(List<ShiftHandoverAnswer> value)
        {
            tableLayoutPanel.Visible = false;   // hiding it gets rid of a lot of flickering

            foreach (ShiftHandoverAnswerControl control in answerControls)
            {
                control.RadioButtonChecked -= HandleAnswerControlRadioButtonChecked;
                control.Dispose();
            }
            answerControls.Clear();

            tableLayoutPanel.Controls.Clear();

            float totalHeight = 0;

            if (value.Count > 0)
            {
                OltLabelLine line = new OltLabelLine();
                line.Dock = DockStyle.Fill;
                line.Label = RendererStringResources.Questions;

                tableLayoutPanel.Controls.Add(line, 0, 0);
                totalHeight += line.Height;
            }

            for (int i = 0; i < value.Count; i++)
            {
                ShiftHandoverAnswer answer = value[i];

                ShiftHandoverAnswerControl singleAnswerControl = new ShiftHandoverAnswerControl();
                singleAnswerControl.SetAnswer(i + 1, answer);
                singleAnswerControl.RadioButtonChecked += HandleAnswerControlRadioButtonChecked;
                singleAnswerControl.Dock = DockStyle.Fill;

                RowStyle rowStyle = new RowStyle(SizeType.Absolute);
               // rowStyle.Height = GetHeight(answer.IsCompleted && answer.Answer);
                rowStyle.Height = GetHeight(answer.IsCompleted && singleAnswerControl.Commentboxenabled);//Added by ppanigrahi
                tableLayoutPanel.RowStyles.Add(rowStyle);
                tableLayoutPanel.Controls.Add(singleAnswerControl, 0, i+1);

                totalHeight += rowStyle.Height;

                answerControls.Add(singleAnswerControl);
            }

            tableLayoutPanel.Height = (int) Math.Ceiling(totalHeight);
            tableLayoutPanel.Visible = true;
        }

        private void HandleAnswerControlRadioButtonChecked(ShiftHandoverAnswerControl control, bool yesChecked)
        {
            if (control.Commentboxenabled)
            {
                int row = tableLayoutPanel.GetRow(control);

                tableLayoutPanel.RowStyles[row].Height = GetHeight(yesChecked);
            }
            else
            {
                int row = tableLayoutPanel.GetRow(control);

                tableLayoutPanel.RowStyles[row].Height = 60;
            }


        }

        private static int GetHeight(bool answerIsYes)
        {
            int height = DEFAULT_HEIGHT;
            if (answerIsYes)
            {
                height = DEFAULT_HEIGHT * 3;
            }
            return height;
        }

        public void ClearErrorProviders()
        {
            answerControls.ForEach(control => control.ClearErrorProviders());
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

        public void SetHelpText(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.Id.Value);
            answerControl.SetHelpText(question.HelpText);
        }
        //Added by ppanigrahi
        public void SetYesNo(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.Id.Value);
            answerControl.SetYesNo(question.YesNoValue);
        }
        //Added by ppanigrahi
        public void SetEmailList(ShiftHandoverQuestion question)
        {
            ShiftHandoverAnswerControl answerControl = GetAnswerControl(question.Id.Value);
            answerControl.SetEmailList(question.EmailList);
        }
        //Added by ppanigrahi
        public bool GetControlEnabled(ShiftHandoverAnswer answer)
        {
            ShiftHandoverAnswerControl control = GetAnswerControl(answer);
            return control.Commentboxenabled;

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

        public void Dispose()
        {
            foreach (ShiftHandoverAnswerControl control in answerControls)
            {
                control.Dispose();
            }
            answerControls.Clear();
        }
    }
}
