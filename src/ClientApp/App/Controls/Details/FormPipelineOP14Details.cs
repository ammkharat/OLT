using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormPipelineOP14Details : AbstractDetails, IFormEdmontonDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event Action MarkAsRead; /*RITM0265746 - Sarnia CSD marked as read start*/
        public event Action MarkedAsReadByToggled; /*RITM0265746 - Sarnia CSD marked as read start*/
        public event Action Clone;
        public event Func<bool> Cancel;
        public event Func<bool> Close;
        public event EventHandler Print;
        public event Action PrintPreview;
        public event Action Email;

        

        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private readonly DomainListView<FormApproval> approvalListView;
        private readonly DomainListView<WorkPermitEdmontonDTO> workPermitsListView;
        private DomainListView<ItemReadBy> markedAsReadByGrid;
        protected readonly UserContext userContext;

        public FormPipelineOP14Details()
        {
            InitializeComponent();

            mainPanel.Layout += HandleMainPanelLayout;

            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            approvalListView = new DomainListView<FormApproval>(new DetailsFormApprovalRenderer(), false) { Dock = DockStyle.Fill };
            approvalsGroupBox.Controls.Add(approvalListView);

            workPermitsListView = new DomainListView<WorkPermitEdmontonDTO>(new DetailsWorkPermitEdmontonRenderer(), false) { Dock = DockStyle.Fill };
            workPermitsGroupBox.Controls.Add(workPermitsListView);

            expandLinkLabel.Click += HandleExpandClicked;            

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            closeButton.Click += HandleCloseButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            emailButton.Click += HandleEmailButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
            /**/
            markAsReadButton.Click += MarkAsReadButton_Click; /*RITM0265746 - Sarnia CSD marked as read start */
            markedAsReadToggleButton.Toggled += HandleMarkedAsReadButtonToggled;
            //HandleMarkedAsReadButtonToggled(true);
            //show hide mark as read pannel from details page based on AllowUsersToEnableCSDMarkAsRead from site config
           // MarkedAsReadPannelVisible = ClientSession.GetUserContext().SiteConfiguration.AllowUsersToEnableCSDMarkAsRead; 

            MarkedAsReadPannelVisible = (ClientSession.GetUserContext().SiteConfiguration.EnableCSDMarkAsRead &&
            ClientSession.GetUserContext().UserRoleElements.AuthorizedTo(RoleElement.MARKASREAD_CSDFORMS)); ;
           
            /*RITM0265746 - Sarnia CSD marked as read end */
        }

        public bool RangeVisible
        {
            set
            {
                dateRangeButton.Visible = value;
            }
        }

        public bool EditEnabled
        {
            set
            {
                editButton.Enabled = value;
            }
        }

        public bool ViewEditHistoryEnabled
        {
            set
            {
                historyButton.Enabled = value;
            }
        }

        public bool DeleteEnabled
        {
            set
            {
                deleteButton.Enabled = value;
            }
        }

        public bool CloneEnabled
        {
            set
            {
                cloneButton.Enabled = value;
            }
        }

        public List<DocumentLink> DocumentLinks
        {

            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
        }


        public bool CloseEnabled
        {
            set
            {
                closeButton.Enabled = value;
            }
        }

        public bool PrintEnabled
        {
            set
            {
                printButton.Enabled = value;
            }
        }

        public bool EmailEnabled
        {
            set
            {
                emailButton.Enabled = value;
            }
        }

        public bool PrintButtonVisible
        {
            set
            {
                printButton.Visible = value;
            }
        }

        public bool CloseButtonVisible
        {
            set
            {
                closeButton.Visible = value;
            }
        }

        public bool PrintPreviewEnabled
        {
            set
            {
                printPreviewButton.Enabled = value;
            }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditVisible
        {
            set
            {
                editButton.Visible = value;
            }
        }



        private void HandleExportButtonClick(object sender, EventArgs eventArgs)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, eventArgs);
            }
        }

        private void HandleEmailButtonClick(object sender, EventArgs eventArgs)
        {
            if (Email != null)
            {
                Email();
            }
        }

        private void HandlePrintPreviewButtonClick(object sender, EventArgs eventArgs)
        {
            if (PrintPreview != null)
            {
                PrintPreview();
            }
        }

        private void HandlePrintButtonClick(object sender, EventArgs eventArgs)
        {
            if (Print != null)
            {
                Print(sender, eventArgs);
            }
        }

        private void HandleCloseButtonClick(object sender, EventArgs eventArgs)
        {
            if (Close != null)
            {
                Close();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (Edit != null)
            {
                Edit(sender, eventArgs);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs eventArgs)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(sender, eventArgs);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs eventArgs)
        {
            if (Delete != null)
            {
                Delete(sender, eventArgs);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs eventArgs)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        /*RITM0265746 - Sarnia CSD marked as read start */
        public bool MarkAsReadEnabled  
        {
            set { markAsReadButton.Enabled = value; }
        }

        public bool MarkedAsReadPannelVisible
        {
            set { markedAsReadByPanel.Controls.Remove(markedAsReadByGrid);
                markedAsReadByGrid = null;
                markedAsReadByPanel.Visible = value;
                oltPanel1.Visible = value;
            }
        }

       public bool MarkedAsReadToggleCollaps
       {
           set
           {
               if (markedAsReadToggleButton.Expanded)
                {
                    markedAsReadToggleButton.Expanded = value;
                }
                markedAsReadByPanel.Controls.Remove(markedAsReadByGrid);
                markedAsReadByGrid = null;
                markedAsReadByPanel.Visible = false;
           }
       }

        public bool MarkAsReadVisible 
        {
            set { markAsReadButton.Visible = value; }
        }

        public List<ItemReadBy> MarkedAsReadBy
        { set { if(markedAsReadByGrid!=null)markedAsReadByGrid.ItemList = value; } }

        private void MarkAsReadButton_Click(object sender, EventArgs e) /*RITM0265746 - Sarnia CSD marked as read */
        {
            if (MarkAsRead != null)
            {
                MarkAsRead();
                MarkedAsReadByToggled();
                HandleMarkedAsReadButtonToggled(true);
                markedAsReadToggleButton.Expanded = true;
               
            }
        }
        private void HandleMarkedAsReadButtonToggled(bool expanded) /*RITM0265746 - Sarnia CSD marked as read */
        {
            if (expanded && markedAsReadByGrid == null)
            {
                markedAsReadByGrid = new DomainListView<ItemReadBy>(new LogReadByListViewRenderer(), false)
                {
                    Dock = DockStyle.Fill
                };
                markedAsReadByPanel.Controls.Add(markedAsReadByGrid);
                markedAsReadByPanel.Visible = true;
                MarkedAsReadByToggled();
            }
            else if (expanded && markedAsReadByGrid != null)
            {
                markedAsReadByPanel.Visible = true;
            }
            else
            {
                markedAsReadByPanel.Visible = false;
            }
        }

        //public bool markedAsReadToggle
        //{
        //    set
        //    {
        //        if (markedAsReadToggleButton.Expanded)
        //        {
        //            markedAsReadToggleButton.Expanded = false;
        //        }
        //        markedAsReadByPanel.Controls.Remove(markedAsReadByGrid);
        //        markedAsReadByGrid = null;
        //        markedAsReadByPanel.Visible = false;
        //    }
        //}
        /*RITM0265746 - Sarnia CSD marked as read End*/

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }
        
        private void HandleExpandClicked(object sender, EventArgs e)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Content, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        public DateTime? CreatedDateTime
        {
            set { createdDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User CreatedByUser
        {
            set { createdByUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public DateTime? LastModifiedDateTime
        {
            set { lastModifiedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public string ValidFromDateTimeLabel
        {
            set { validFromLabel.Text = value; }
        }

        public string ValidToDateTimeLabel
        {
            set { validToLabel.Text = value; }
        }

        public DateTime? ValidFromDateTime
        {
            set { validFromDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public DateTime? ValidToDateTime
        {
            set { validToDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public long? FormNumber
        {
            set { formNumberDataLabel.Text = value == null ? string.Empty : value.Value.ToString(); }
        }

        public DateTime? ApprovedDateTime
        {
            set { approvedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public DateTime? ClosedDateTime
        {
            set { closedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public List<FormApproval> Approvals
        {
            set { approvalListView.ItemList = value ?? new List<FormApproval>(); }
        }

        public List<WorkPermitEdmontonDTO> WorkPermitEdmontonDTOs
        {
            set { workPermitsListView.ItemList = value ?? new List<WorkPermitEdmontonDTO>(); }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value ?? new List<FunctionalLocation>(); }
        }

        public string Content
        {
            set { contentRichTextDisplay.Text = value; }
            private get { return contentRichTextDisplay.Text; }
        }

        public FormOP14Department Department
        {
            set { departmentDataLabel.Text = value.NullableToString();

                switch (value.NullableToString())
                  {
                      case "Operations": departmentDataLabel.Text = "SPCC"; break;
                      case "Maintenance": departmentDataLabel.Text = "Field O&M"; break;
                    case "Engineering": departmentDataLabel.Text = "Engineering"; break;

                  }
            
              }
        }

        public bool? IsTheCSDForAPressureSafetyValve
        {
            set { isTheCSDForAPressureSafetyValveDataLabel.Text = value != null ? (value == true ? "SELC " : "SEUSA") : string.Empty; }
        }
        public bool IsTheCSDForSCADAeDataLabel
        {
            get
            {
                return IsTheCSDForSCADAeDataLabel;
            }
            set { isTheCSDForSCADAeDataLabel.Text = value != null ? value.BooleanToYesNoString() : string.Empty; }
        }

        public string CriticalSystemDefeated
        {
            set { criticalSystemDefeatedTextBox.Text = value ?? string.Empty;
            }
        }

        public bool WorkPermitEdmontonSectionVisible
        {
            set { workPermitsGroupBox.Visible = value; }
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        private int? criticalSystemDefeatedDefaultGroupBoxHeight;

        public void AdjustTextBoxHeights()
        {
            if (criticalSystemDefeatedDefaultGroupBoxHeight == null)
            {
                criticalSystemDefeatedDefaultGroupBoxHeight = criticalSystemDefeatedGroupBox.Height;
            }

            criticalSystemDefeatedGroupBox.Height = criticalSystemDefeatedDefaultGroupBoxHeight.Value;
                
            AdjustTextBoxHeightToFitText(criticalSystemDefeatedTextBox, criticalSystemDefeatedGroupBox);                   
        }

        private static void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            int oldContainerHeight = containerGroupBox.Height;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue), TextFormatFlags.WordBreak);
            int heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
        }
       
      
    }
}