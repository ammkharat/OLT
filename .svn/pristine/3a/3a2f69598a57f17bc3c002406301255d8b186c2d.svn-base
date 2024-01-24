using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using System.Text.RegularExpressions;//Added by ppanigrahi

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AddEditShiftHandoverQuestionForm : BaseForm
    {
        private readonly bool isAddMode;
        private bool cancelClicked;
        private ShiftHandoverQuestion question;
        private string yesNo="Yes";//Variable declared to assign Yes/No Value from screen.DMND0010303(ppanigrahi) 
        public event Action<AddEditShiftHandoverQuestionForm, bool> RadioButtonChecked;//Addded by ppanigrahi
       
        
        public AddEditShiftHandoverQuestionForm(ShiftHandoverQuestion question)
        {
            InitializeComponent();

            this.question = question;
            this.lblEmail.Text = StringResources.EmailListButton;
             
            isAddMode = question == null;
            SetUpControlsForAddOrEditMode();

            submitButton.Click += HandleSubmitButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            chkYes.CheckedChanged += RadioButton_Checked;
            chkNo.CheckedChanged += RadioButton_Checked;
        }
        //New RadioButton check changed event by ppanigrahi
        private void RadioButton_Checked(object sender, EventArgs e)
        {
            if (chkYes.Checked)
            {
                yesNo = chkYes.Text;
            }
            if (chkNo.Checked)
            {
                yesNo = chkNo.Text;
            }
            if (RadioButtonChecked != null)
            {
                RadioButtonChecked(this, chkYes.Checked);
            }
        }

        private void HandleSubmitButtonClicked(object sender, EventArgs e)
        {
            if (!DataIsValid())
            {
                return;
            }

            string questionText = QuestionFromTextBox;
            string helpText = HelpTextFromTextBox;
            string emailList= EmailAddressList;
            string yesNovalue = selectedText;
          
           
            if (isAddMode)
            {
                question = new ShiftHandoverQuestion(0, questionText, helpText,emailList,yesNovalue);            
            }
            else
            {
                question.EmailList = emailList;
                question.YesNoValue = yesNovalue;
                question.Text = questionText;
                question.HelpText = helpText;                
            }

            Close();
        }
        //Property Field added to accept Email address fromEmail text box.
        public string EmailAddressList
        {
            get { return EmailAddressTextBox.Text; }
            set { EmailAddressTextBox.Text = value; }
        }
        //Property for reading the radio button text(ppanigrahi)
        public string  selectedText
        {
            get
            {

                return yesNo;
            }
            set
            {
                yesNo = value;
            }
        }
       private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            cancelClicked = true;
            Close();
        }

        private string QuestionFromTextBox
        {
            get { return textTextBox.Text.TrimOrNull(); }        
        }

        private string HelpTextFromTextBox
        {
            get { return helpTextTextBox.Text.TrimOrNull(); }
        }

        private bool DataIsValid()
        {
            errorProvider.Clear();

            bool hasError = false;

            if (QuestionFromTextBox.IsNullOrEmptyOrWhitespace())
            {
                errorProvider.SetError(textTextBox, StringResources.InvalidShiftHandoverQuestion);
                hasError = true;
            }
            //Added by ppanigrahi
            //Commented because Email is not mandory
            //if (String.IsNullOrEmpty(EmailAddressTextBox.Text))
            //{
            //    errorProvider.SetError(EmailAddressTextBox, StringResources.FieldCannotBeEmpty);
            //    hasError = true;
            //}
            //Validation to check valid mail or not.Added by ppanigrahi
            else
            {
                string strEmail = EmailAddressTextBox.Text;
                if (strEmail.Length > 0)
                {
                    string[] eid = strEmail.Split(';');
                    for (int i = 0; i < eid.Length; i++)
                    {
                        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3}[ ]*)$";
                        Regex re = new Regex(strRegex);
                        if (!(re.IsMatch(eid[i].ToString())))
                        {
                            errorProvider.SetError(EmailAddressTextBox, StringResources.EmailError);
                            hasError = true;
                            break;
                        }
                        else
                        {
                            hasError = false;
                        }
                    }

                }
                
            }


            return !hasError;

        }

        private void SetUpControlsForAddOrEditMode()
        {
            submitButton.Text = isAddMode ? StringResources.AddButtonLabelNoAmpersand : StringResources.OKButtonLabel;
            Text = isAddMode ? StringResources.AddShiftHandoverQuestion : StringResources.EditShiftHandoverQuestion;

            if (!isAddMode)
            {
                textTextBox.Text = question.Text;
                helpTextTextBox.Text = question.HelpText;
                EmailAddressTextBox.Text = question.EmailList;
                if (question.YesNoValue == "Yes")
                {
                    chkYes.Checked = true;

                }
                if (question.YesNoValue == "No")
                {
                    chkNo.Checked = true;
                }
            }
        }
       
        public ShiftHandoverQuestion ShowDialogAndReturnQuestion(Form parentForm)
        {
            ShowDialog(parentForm);
            return cancelClicked ? null : question;
        }

        private void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                yesNo = ((RadioButton)sender).Text; 
        }

        private void chNo_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                yesNo = ((RadioButton)sender).Text; 
        }

       
        
    }
}