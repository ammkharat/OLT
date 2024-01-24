using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ShiftHandoverAnswerControl : UserControl
    {
        public event Action<ShiftHandoverAnswerControl, bool> RadioButtonChecked;

        private ShiftHandoverAnswer answer;
        private string helpText;

        public ShiftHandoverAnswerControl()
        {
            InitializeComponent();
            helpTextLinkLabel.Click += HelpTextLinkLabel_Click;
            yesRadioButton.CheckedChanged += RadioButton_Checked;
            noRadioButton.CheckedChanged += RadioButton_Checked;
        }
        //New condition has been added by ppanigrahi to check whether Yes/No has beenchoosed during adding of question.
        private void RadioButton_Checked(object sender, EventArgs e)
        {
            if (yesRadioButton.Checked)
            {
                if (answer.YesNo == "No")
                {
                    
                    commentsTextBox.Enabled = false;
                    commentsTextBox.Text = string.Empty;
                    if (RadioButtonChecked != null)
                    {
                        RadioButtonChecked(this, yesRadioButton.Checked);
                    }
                }
                else
                {
                    commentsTextBox.Enabled = true;
                    if (RadioButtonChecked != null)
                    {
                        RadioButtonChecked(this, yesRadioButton.Checked);
                    }
                }

            }
            if (noRadioButton.Checked)
            {
                if (answer.YesNo != null)
                {
                    if (answer.YesNo == "No")
                    {

                        commentsTextBox.Enabled = true;
                        if (RadioButtonChecked != null)
                        {
                            RadioButtonChecked(this, noRadioButton.Checked);
                        }
                    }
                    else
                    {
                        
                            commentsTextBox.Enabled = false;
                            commentsTextBox.Text = string.Empty;

                            if (RadioButtonChecked != null)
                            {
                                RadioButtonChecked(this, noRadioButton.Checked);
                            }
                    }
                }
                else
                {
                    commentsTextBox.Enabled = false;
                    commentsTextBox.Text = string.Empty;
                }
                //commentsTextBox.Enabled = false;
                //commentsTextBox.Text = string.Empty;
            }
            if (RadioButtonChecked != null)
            {
                
                // RadioButtonChecked(this, yesRadioButton.Checked);
                //Added by ppanigrahi to change the height of text box
                 //if (yesRadioButton.Checked && commentsTextBox.Enabled)
                 //{
                 //    RadioButtonChecked(this, yesRadioButton.Checked);
                 //}
                 //else
                 //{
                 //    if (commentsTextBox.Enabled)
                 //    {
                 //        RadioButtonChecked(this, noRadioButton.Checked);
                 //    }

                 //}
               // RadioButtonChecked(this, yesRadioButton.Checked);

                //if (yesRadioButton.Checked && answer)
                //{
                   
                //    RadioButtonChecked(this, yesRadioButton.Checked);

                //}
                //if (noRadioButton.Checked && answer.YesNo == "No")
                //{
                //    RadioButtonChecked(this, noRadioButton.Checked);

                //}
                //if (yesRadioButton.Checked )
                //{

                //    RadioButtonChecked(this, yesRadioButton.Checked);

                //}

                //if (noRadioButton.Checked)
                //{
                //    RadioButtonChecked(this, noRadioButton.Checked);
                //}
              //  RadioButtonChecked(this, yesRadioButton.Checked);
                //RadioButtonChecked(this, noRadioButton.Checked);

                //if (yesRadioButton.Checked)
                //{
                //    RadioButtonChecked(this, yesRadioButton.Checked);
                //}
                //if (noRadioButton.Checked)
                //{
                //    RadioButtonChecked(this, yesRadioButton.Checked);

                //}
            }
        }

        private void HelpTextLinkLabel_Click(object sender, EventArgs e)
        {
            ShiftHandoverHelpForm helpForm = new ShiftHandoverHelpForm(helpText);
            helpForm.ShowDialog(this);
        }

        public ShiftHandoverAnswer Answer
        {
            get { return answer; }
            private set
            {
                answer = value;

                questionTextLabel.Text = value.QuestionText;
                if (value.IsCompleted && value.Answer)
                {
                    yesRadioButton.Checked = true;
                }
                else if (value.IsCompleted && !value.Answer)
                {
                    noRadioButton.Checked = true;
                }
                else
                {
                    commentsTextBox.Enabled = false;
                }
                commentsTextBox.Text = value.Comments;
            }
        }

        public bool? YesNoAnswer
        {
            get
            {
                if (yesRadioButton.Checked)
                    return true;
                if (noRadioButton.Checked)
                    return false;
                return null;
            }
        }

        public string CommentsText
        {
            get { return commentsTextBox.Text.Trim(); }
        }

        public void SetAnswer(int answerNumber, ShiftHandoverAnswer newAnswer)
        {
            questionNumberLabel.Text = answerNumber + ".";
            Answer = newAnswer;
        }

        public bool Commentboxenabled
        {
            get { return commentsTextBox.Enabled; }
        }

        public void SetCommentsError()
        {
//            int leftSide = commentsTextBox.Left;
//            commentsTextBox.Width = (Width - leftSide) - 20;
            errorProviderPanel.Visible = true;
//            commentsErrorProvider.SetError(commentsTextBox, StringResources.FieldEmptyError);
            commentsErrorProvider.SetError(errorProviderBindingControl, StringResources.FieldEmptyError);
        }

        public void SetYesNoError()
        {
            yesNoErrorProvider.SetError(noRadioButton, StringResources.YesNoError);
        }

        public void ClearErrorProviders()
        {
//            int leftSide = commentsTextBox.Left;

//            commentsTextBox.Width = Width - leftSide;
            commentsErrorProvider.Clear();
            yesNoErrorProvider.Clear();
            errorProviderPanel.Visible = false;
        }

        public void SetHelpText(string newHelpText)
        {
            helpText = newHelpText;
            helpTextLinkLabel.Enabled = !string.IsNullOrEmpty(helpText);
        }
        //Added by ppanigrahi
        public void SetYesNo(string yesNo)
        {
            answer.YesNo = yesNo;
        }
        //Added by ppanigrahi
        public void SetEmailList(string emailList)
        {
            answer.EmailList = emailList;
        }

    }
}
