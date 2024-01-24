using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraRichEdit.API.Native;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitCloseWithStatusForm : BaseForm, IWorkPermitCloseWithStatusFormView
    {
        public event EventHandler SubmitButtonClick;
        public event EventHandler CancelButtonClick;
        public event EventHandler ActionItemCheckboxCheck;//Added by ppanigrahi

        public WorkPermitCloseWithStatusForm()
        {
            InitializeComponent();
            closeStatusComboBox.DisplayMember = "Name";
            this.validToTimePicker.Value = Clock.TimeNow;
            submitButton.Click += submitButton_Click;
            cancelButton.Click += cancelButton_Click;
            actionItemCheckBox.Click += ActionItemCheckboxCheck_Click;//Added by ppanigrahi
            this.Load += WorkPermitCloseWithStatusForm_Load;
            this.closeStatusComboBox.SelectedValueChanged +=closeStatusComboBox_SelectedValueChanged;
            
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedData.LastModifiedDate = value; }
        }

        public User Author
        {
            set { lastModifiedData.LastModifiedUser = value; }
        }

        public List<WorkPermitLoggableStatus> Statuses
        {
            set
            {
                closeStatusComboBox.DataSource = value;
            }
        }

        public Size SetSize
        {
            set { this.buttonsPanel.Size = value; }
        }

        public Size setFormSize
        {
            set { this.Size = value; }

        }

        public Size mainPanelSize
        {
            set { this.mainPanel.Size = value; }
        }

        public string Shift
        {
            set { shiftLabel.Text = value; }
        }

        public WorkPermitLoggableStatus SelectedStatus
        {
            get { return (WorkPermitLoggableStatus) closeStatusComboBox.SelectedItem; }
        }

        public string CommentsSectionTitle
        {
            set { commentsGroupBox.Text = value; }
        }

        public string Comment
        {
            get { return commentTextBox.Text; }
        }
       

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public string FormTitle
        {
            set { Text = value; }
        }

        public bool StatusHidden
        {
            get { return !closeGroupBox.Visible; }
            
        }

        public bool ActionItemCheckBoxVisible
        {
           
            set
            {
                

                    actionItemCheckBox.Visible = value;
              
            }
        }

        public bool ActionItemCheckBoxEnable
        {

            get { return actionItemCheckBox.Enabled; }
            set { actionItemCheckBox.Enabled = value; }
        }

        public bool ActionItemCheckBoxchecked
        {

            get { return actionItemCheckBox.Checked; }
            set { actionItemCheckBox.Checked = value; }

        }

        public bool commentBoxEnable
        {

            get { return cmtTextBox.Enabled; }
            set
            {
                cmtTextBox.Enabled = value;
                
            }
        }


        public bool commentBoxVisible
        {
            set { cmtTextBox.Visible = value; }
        }

        public bool dateTimeControlVisible
        {

            set
            {
                validToDatePicker.Visible = value;
                validToTimePicker.Visible = value;
                dtClose.Visible = value;
                oltLabelLine3.Visible = value;
                oltLabelLine2.Visible = value;
            }
        }

        public bool dateTimeControlEnable
        {
            set
            {
                validToDatePicker.Enabled = value;
                validToTimePicker.Enabled = value;
            }
        }

        //public bool hotpanelVisible
        //{
        //    set {HotPermitPanel.Visible = value; }
        //}
        public void HideCloseStatus()
        {
            closeGroupBox.Hide();
        }

        public void SetErrorForNoStatusSelected()
        {
            errorProvider.SetError(closeGroupBox, StringResources.WorkPermitCloseComment_NoStatusError);
        }

        public void SetErrorForNoComments()
        {
            errorProvider.SetError(commentsGroupBox, StringResources.WorkPermitCloseComment_NoLogCommentError);
        }

        public void SetErrorForNoActionItemComments()
        {
            errorProvider.SetError(cmtTextBox, StringResources.SiteCommunicationMessageEmptyError);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButtonClick != null)
            {
                SubmitButtonClick(sender, e);
            }
        }
        //Added by ppanigrahi

        private void WorkPermitCloseWithStatusForm_Load(object sender, EventArgs e)
        {
            long sitid = ClientSession.GetUserContext().SiteId;

            if (sitid != Common.Domain.Site.MontrealSulphur_ID)
            {
                this.cmtTextBox.Visible = false;
                this.validToDatePicker.Visible = false;
                this.validToTimePicker.Visible = false;
                this.actionItemCheckBox.Visible = false;
                this.oltLabelLine2.Visible = false;
                //this.validToDatePicker = Clock.DateNow.da

            }
            //this.ActionItemCheckBoxEnable = false;
            //this.commentBoxEnable = false;
            //this.dateTimeControlEnable = false;

        }

        private void closeStatusComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (closeStatusComboBox.SelectedIndex == 1 || closeStatusComboBox.SelectedIndex == 3 || closeStatusComboBox.SelectedIndex == 4 ||
                closeStatusComboBox.SelectedIndex == 6)
            {
                this.ActionItemCheckBoxEnable = true;
               // this.commentBoxEnable = true;
                this.dateTimeControlEnable = true;
            }
            else
            {
                this.ActionItemCheckBoxEnable = false;
                this.commentBoxEnable = false;
                this.dateTimeControlEnable = false;
                
            }
            
        }
        private void ActionItemCheckboxCheck_Click(object sender, EventArgs e)
        {
            if (ActionItemCheckboxCheck != null)
            {
                ActionItemCheckboxCheck(sender, e);
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick(sender, e);
            }
        }
        public DateTime ClosingDateTime
        {
            get
            {
                Date date = validToDatePicker.Value;
                Time time = validToTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                validToDatePicker.Value = new Date(value);
                validToTimePicker.Value = new Time(value);
            }
        }

        public string WorkPermitCloseComment
        {

            get { return cmtTextBox.Text; }
        }

    }
}
