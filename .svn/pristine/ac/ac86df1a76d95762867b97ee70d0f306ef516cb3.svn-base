using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogReplyForm : BaseForm, ILogReplyFormView
    {
        private readonly ILogReplyFormPresenter presenter;

        public LogReplyForm(Log replyToLog)
        {           
            presenter = new LogReplyFormPresenter(this, replyToLog.IdValue);                            
            Initialize();
        }

        public LogReplyForm(SummaryLog replyToLog)
        {           
            presenter = new SummaryLogReplyFormPresenter(this, replyToLog.IdValue);                            
            Initialize();
        }

        public LogReplyForm(long replyToLogId, SummaryLog logToUpdate)
        {
            presenter = new SummaryLogReplyFormPresenter(this, replyToLogId, logToUpdate);
            Initialize();
        }

        public LogReplyForm(long replyToLogId, Log logToUpdate)
        {
            presenter = new LogReplyFormPresenter(this, replyToLogId, logToUpdate);
            Initialize();
        }

        private void Initialize()
        {
            InitializeComponent();
            explorerBar.MouseWheeling += ExplorerBar_MouseWheeling;
            RegisterEventHandler();
        }

        private bool ExplorerBar_MouseWheeling()
        {
            return logCommentControl != ActiveControl;
        }

        private void RegisterEventHandler()
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            logCommentControl.GuidelineLinkClick += presenter.HandleLogCommentGuidelineLinkClick;
        }

        public void ClearErrorProviders()
        {
            commentsErrorProvider.Clear();
        }

        public void SetCommentsBlankError()
        {   
            logCommentControl.SetError(StringResources.CommentFieldEmpty);            
        }

        public string Title
        {
            set { Text = value; }
        }

        public DateTime LogDateTime
        {
            set { logDateTimeLabelData.Text = value.ToLongDateAndTimeString(); }            
        }

        public bool EHSFollowUp
        {
            get{return eHSFollowUpCheckBox.Checked;}
            set{eHSFollowUpCheckBox.Checked = value;}
        }

        public bool InspectionFollowUp
        {
            get{return inspectionFollowUpCheckbox.Checked;}
            set{inspectionFollowUpCheckbox.Checked = value;}
        }

        public bool OperationsFollowUp
        {
            get{return operationsFollowUpCheckbox.Checked;}
            set{operationsFollowUpCheckbox.Checked = value;}
        }

        public bool ProcessControlFollowUp
        {
            get{return processControlFollowUpCheckBox.Checked;}
            set{processControlFollowUpCheckBox.Checked = value;}
        }

        public bool SupervisionFollowUp
        {
            get{return supervisorFollowUpCheckbox.Checked;}
            set{supervisorFollowUpCheckbox.Checked = value;}
        }

        public bool OtherFollowUp
        {
            get{return otherFollowUpCheckBox.Checked;}
            set{otherFollowUpCheckBox.Checked = value;}
        }

        public string ParentEntryLineLabel
        {
            set { commentLabelLine.Text = value; }
        }

        public string OperatingEngineerDisplayText
        {
            set { isOperatingEngineerLogCheckBox.Text = value; }
        }
      
        public string Comments
        {
            get { return logCommentControl.Text; }
            set { logCommentControl.Text = value; }
        }

        public string CommentsAsPlainText
        {
            get { return logCommentControl.PlainText; }
        }

        public bool IsCommentEmpty
        {
            get { return logCommentControl.IsEmpty; }
        }

        public bool RecommendForShiftSummary
        {
            get { return recommendForShiftSummaryCheckBox.Checked; }
            set { recommendForShiftSummaryCheckBox.Checked = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = value; }
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }

        public string Author
        {
            set { createdByLabelData.Text = value; }
        }

        public DateTime ParentLogDateTime
        {
            set { parentLogTimeLabelData.Text = value.ToLongDateAndTimeString(); }
        }

        public string ParentShift
        {
            set { parentShiftLabelData.Text = value; }
        }

        public string ParentAuthor
        {
            set { parentCreatedByLabelData.Text = value; }
        }

        public string ParentComments
        {
            set { parentCommentsTextBox.Text = value; }
        }      

        public bool IsOperatingEngineer
        {
            get
            {
                return isOperatingEngineerLogCheckBox.Checked;
            }
            set
            {
                isOperatingEngineerLogCheckBox.Checked = value;
            }
        }

        public void DisableOperatingEngineerLogs()
        {
            isOperatingEngineerLogCheckBox.Enabled = false;
        }

        public void HideOperatingEngineerCheckBox()
        {
            isOperatingEngineerLogCheckBox.Hide();
        }

        public void HideFollowupFlags()
        {
            followupGroupBox.Hide();
        }

        public void HideOptions()
        {
            optionsGroupBox.Hide();
        }

        public void ShowGuidelines(List<LogGuideline> logGuidelines)
        {
            logCommentControl.ShowLogGuidelineForm(logGuidelines);
        }

        public string EntryReplyDetailsLabelLine
        {
            set { entryReplyDetailsLabelLine.Label = value; }
        }

        public string CommentLabelLine
        {
            set { commentLabelLine.Label = value; }
        }

        public string ParentLogTimeGroupBoxText
        {
            set { parentLogTimeGroupBox.Text = value; }
        }

        public string LogTimeGroupBoxText
        {
            set { logTimeGroupBox.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }
    }
}
