using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class SAPNotificationDetails : AbstractDetails, ISAPNotificationDetails
    {
        public event EventHandler SubmitToLog;
        public event EventHandler SubmitToOperatingEngineerLog;
        public event EventHandler Edit;
        public event EventHandler ExportAll;

        public SAPNotificationDetails()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            submitToLogButton.Click += submitToLogButton_Click;
            submitToLogButtonAsOperatingEngineerLog.Click += submitToOperatingEngineerLogButton_Click;
            editButton.Click += editButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;

            if (!ClientSession.GetUserContext().SiteConfiguration.CreateOperatingEngineerLogs)
            {
                submitToLogButtonAsOperatingEngineerLog.Available = false;
            }
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void submitToLogButton_Click(object sender, EventArgs e)
        {
            if(SubmitToLog != null)
            {
                SubmitToLog(this, e);
            }
        }

        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if(ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void submitToOperatingEngineerLogButton_Click(object sender, EventArgs e)
        {
            if(SubmitToOperatingEngineerLog != null)
            {
                SubmitToOperatingEngineerLog(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(Edit != null)
            {
                Edit(this, e);
            }
        }

        public string Description
        {
            set { descriptionLabelData.Text = value; }
        }

        public string Comments
        {
            set { commentsLabelData.Text = value; }
        }

        public string CreateDate
        {
            set { createDateData.Text = value; }
        }

        public string StartTime
        {
            set { createTimeData.Text = value; }
        }

        public string NotificationType
        {
            set { typeData.Text = value; }
        }

        public string NotificationNumber
        {
            set { notificationNumberLabelData.Text = value; }
        }

        public string FunctionalLocationString
        {
            set { functionalLocationLabelData.Text = value; }
        }

        public string ShortTextString
        {
            set { shortTextLabelData.Text = value; }
        }

        public string IncidentIDString
        {
            set { incidentIDLabelData.Text = value; }
        }


        public DialogResult ApproveOK()
        {
            return OltMessageBox.Show(Form.ActiveForm, StringResources.SAPNotificationCreateLogMessageBoxText, StringResources.SAPNotificationCreateLogMessageBoxCaption, MessageBoxButtons.YesNo);
        }

        public bool SubmitToLogEnabled
        {
            set { submitToLogButton.Enabled = value; }
        }

        public bool SubmitToOperatingEngineerLogEnabled
        {
            set { submitToLogButtonAsOperatingEngineerLog.Enabled = value; }
        }

        public string SubmitToOperatingEngineerLogText
        {
            set { submitToLogButtonAsOperatingEngineerLog.Text = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if(editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }
    }
}