using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class LogDetails : AbstractDetails, ILogDetails
    {
        private readonly LogDetailsThreadHelper logDetailsThreadHelper;
        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;
        private DomainListView<FunctionalLocation> functionalLocationListView;

        private Log log;
        private DomainListView<ItemReadBy> markedAsReadByGrid;

        public LogDetails()
        {
            InitializeComponent();
            InitializeFunctionalLocationsGrid();
            InitializeCustomFieldEntriesGrid();

            Dock = DockStyle.Fill;
            ViewThread += LogDetails_LogViewThread;
            deleteButton.Click += deleteButton_Click;
            replyButton.Click += replyButton_Click;
            copyButton.Click += copyButton_Click;
            editButton.Click += editButton_Click;
            viewThreadButton.Click += viewThreadButton_Click;

            mainFlowLayoutPanel.MouseEnter += ControlResponsibleForAutoScrolling_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;
            editHistoryButton.Click += editHistoryButton_Click;

            markAsReadButton.Click += markAsReadButton_Click;

            printButton.Click += PrintButton_Click;
            previewButton.Click += PreviewButton_Click;

            expandLinkLabel1.Click += ExpandLinkLabel1Click;

            customFieldEntriesPanel.BorderStyle = BorderStyle.FixedSingle;

            mainFlowLayoutPanel.Layout += MainFlowLayoutPanel_Layout;
            markedAsReadToggleButton.Toggled += MarkedAsReadByToggleButtonOnToggled;

            logDetailsThreadHelper = new LogDetailsThreadHelper(splitContainer, logDetailThreadTreeView,
                viewThreadButton);
            logDetailsThreadHelper.AfterSelect += logDetailThreadTreeView_AfterSelect;

            // Added by Mukesh for RITM0218684
            emailButton.Click += EmailButton_Click;
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private string CreationDateTime
        {
            set { creationDateTimeTextBox.Text = value; }
        }

        private string LogDateTime
        {
            set { actualLoggedDateTimeTextBox.Text = value; }
        }

        private string Comments
        {
            set { commentsDisplayControl.Text = value; }
            get { return commentsDisplayControl.Text; }
        }

        private List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value; }
        }

        private bool IsOperatingEngineerLog
        {
            set { IsOperatingEngineerLogCheckBox.Checked = value; }
        }

        private string OperatingEngineerDisplayName
        {
            set { IsOperatingEngineerLogCheckBox.Text = value; }
        }

        private bool OperatingEngineerCheckboxVisible
        {
            set { IsOperatingEngineerLogCheckBox.Visible = value; }
        }

        private bool RecommendForShiftSummaryVisible
        {
            set { recommendForShiftSummaryCheckBox.Visible = value; }
        }

        private bool RecommendForShiftSummary
        {
            set { recommendForShiftSummaryCheckBox.Checked = value; }
        }

        private bool Inspection
        {
            set { inspectionCheckBox.Checked = value; }
        }

        private bool ProcessControl
        {
            set { processControlCheckBox.Checked = value; }
        }

        private bool Operations
        {
            set { operationsCheckBox.Checked = value; }
        }

        private bool EnvironmentalHealthAndSafety
        {
            set { EnvironmentalHealthAndSafetyCheckBox.Checked = value; }
        }

        private bool OtherFollowUp
        {
            set { otherCheckBox.Checked = value; }
        }

        private bool Supervision
        {
            set { supervisionCheckBox.Checked = value; }
        }

        private bool ScheduleVisible
        {
            set
            {
                scheduleLabel.Visible = value;
                rangeOfRecurrenceGroupBox.Visible = value;
                raiseTimeGroupBox.Visible = value;
                recurrencePatternGroupBox.Visible = value;
            }
        }

        private string WorkAssignment
        {
            set { workAssignmentTextBox.Text = value; }
        }

        private string RecurrenceStartDate
        {
            set { recurrenceStartDateData.Text = value; }
        }

        private string RecurrenceEndDate
        {
            set { recurrenceEndDateData.Text = value; }
        }

        private string RaiseStartTime
        {
            set { raiseStartTimeData.Text = value; }
        }

        private string RecurrencePattern
        {
            set { recurrencePatternData.Text = value; }
        }

        private List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return toggleShowButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        public bool PreviewVisible
        {
            set { previewButton.Visible = value; }
        }

        public bool RangeVisible
        {
            set { ToggleDateRangeButton.Visible = value; }
        }

        public event DomainEventHandler<LogDTO> SelectedThreadItemChanged;

        public event EventHandler Delete;
        public event EventHandler Reply;
        public event EventHandler Copy;
        public event EventHandler Edit;
        public event EventHandler ViewThread;
        public event EventHandler ViewEditHistory;
        public event EventHandler MarkAsRead;
        public event EventHandler ExportAll;
        public event EventHandler Print;
        public event EventHandler Preview;

        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;
        public event Action<Log> DetailsMarkedAsReadByExpand;

        public override void Hide()
        {
            base.Hide();
            ShowTreePanel = false;
        }

        public void AddMarkedAsReadUser(ItemReadBy itemReadBy)
        {
            if (markedAsReadByGrid != null)
            {
                markedAsReadByGrid.ItemList.Add(itemReadBy);
            }
        }

        public void SelectThreadItem(IThreadableDTO selectedDto)
        {
            logDetailsThreadHelper.SelectedDTO = selectedDto;
        }

        public bool ShowTreePanel
        {
            set
            {
                if (value)
                {
                    logDetailsThreadHelper.ShowTreePanel();
                }
                else
                {
                    logDetailsThreadHelper.HideTreePanel();
                }
            }
            get { return logDetailsThreadHelper.IsShowingTreePanel; }
        }

        public void LoadLogThreadTree(IThreadableDTO rootDto, List<IThreadableDTO> childDtos)
        {
            logDetailsThreadHelper.LoadThreadTree(rootDto, childDtos);
        }

        public List<ItemReadBy> MarkedAsReadBy
        {
            set { markedAsReadByGrid.ItemList = value; }
        }

        public bool ParentIsMissingMessageEnabled
        {
            set
            {
                if (value)
                {
                    parentNotAvailableLabel.Show();
                }
                else
                {
                    parentNotAvailableLabel.Hide();
                }
            }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool CopyEnabled
        {
            set { copyButton.Enabled = value; }
        }

        public bool ReplyEnabled
        {
            set { replyButton.Enabled = value; }
        }

        public bool ViewThreadEnabled
        {
            set { viewThreadButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool MarkAsReadEnabled
        {
            set { markAsReadButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PreviewEnabled
        {
            set { previewButton.Enabled = value; }
        }

        public void SetDetails(Log log, List<CustomField> customFields)
        {
            this.log = log;

            SetMarkedAsReadToDefault();

            var siteConfiguration = ClientSession.GetUserContext().SiteConfiguration;

            if (log.LogType == LogType.DailyDirective)
            {
                actualLoggedDateTimeLabel.Text = StringResources.LogDetails_ActualTime_Label_Directive;
            }
            if (log.LogType == LogType.Standard)
            {
                actualLoggedDateTimeLabel.Text = StringResources.LogDetails_ActualTime_Label_Log;
            }

            CreationDateTime = log.CreatedDateTime.ToLongDateAndTimeString();
            LogDateTime = log.LogDateTime.ToLongDateAndTimeString();

            Comments = log.RtfComments;
            FunctionalLocations = log.FunctionalLocations;

            if (siteConfiguration.ShowFollowupOnLogForm || log.LogType == LogType.DailyDirective)
            {
                followupPanel.Visible = true;
                ProcessControl = log.ProcessControlFollowUp;
                Operations = log.OperationsFollowUp;
                Inspection = log.InspectionFollowUp;
                Supervision = log.SupervisionFollowUp;
                EnvironmentalHealthAndSafety = log.EnvironmentalHealthSafetyFollowUp;
                OtherFollowUp = log.OtherFollowUp;
            }
            else
            {
                followupPanel.Visible = false;
            }

            IsOperatingEngineerLog = log.IsOperatingEngineerLog;
            RecommendForShiftSummary = log.RecommendForShiftSummary;
            OperatingEngineerDisplayName = siteConfiguration.OperatingEngineerLogDisplayName;

            DocumentLinks = log.DocumentLinks;

            if (customFields.Count > 0 && CustomFieldEntry.HasAtLeastOneNonEmptyEntry(log.CustomFieldEntries))
            {
                customFieldsPanel.Visible = true;
                SetCustomFieldEntries(log.CustomFieldEntries, customFields);
            }
            else
            {
                customFieldsPanel.Visible = false;
            }

            WorkAssignment = log.WorkAssignment != null
                ? log.WorkAssignment.DisplayName
                : StringResources.NullWorkAssignment;

            var logDefinition = log.LogDefinition;
            ISchedule schedule = null;
            if (logDefinition != null)
            {
                schedule = logDefinition.Schedule;
            }
            if (schedule != null)
            {
                ScheduleVisible = true;
                RecurrenceStartDate = schedule.StartDate == null ? null : schedule.StartDate.ToString();
                RecurrenceEndDate = schedule.EndDate == null ? null : schedule.EndDate.ToString();
                RaiseStartTime = schedule.StartTime == null ? null : schedule.StartTime.ToString();
                RecurrencePattern = schedule.RecurrencePatternString;
            }
            else
            {
                ScheduleVisible = false;
                RecurrenceStartDate = string.Empty;
                RecurrenceEndDate = string.Empty;
                RaiseStartTime = string.Empty;
                RecurrencePattern = StringResources.NonRepeatingRecurrencePattern;
            }

            if (log.LogType == LogType.Standard)
            {
                optionsPanel.Visible = true;

                if (!siteConfiguration.CreateOperatingEngineerLogs)
                {
                    OperatingEngineerCheckboxVisible = false;
                }
                else
                {
                    OperatingEngineerCheckboxVisible = log.LogType == LogType.Standard;
                }
                RecommendForShiftSummaryVisible = log.LogType == LogType.Standard;
                //Mukesh for Log Image
                if (log.Imagelist != null && log.Imagelist.Count > 0)
                {
                    oltPanelImagelist.Visible = true;
                    oltDGVImage.AutoGenerateColumns = false;
                    oltDGVImage.DataSource = log.Imagelist;
                }
                else
                {
                    oltPanelImagelist.Visible = false;
                   
                }
            }
            else
            {
                optionsPanel.Visible = false;
            }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in actionStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool MarkAsReadVisible
        {
            set { markAsReadButton.Visible = value; }
        }

        public bool PrintVisible
        {
            set { printButton.Visible = value; }
        }

        private static void MainFlowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            var panel = sender as FlowLayoutPanel;
            if (panel != null)
            {
                panel.Controls[0].Dock = DockStyle.None;
                panel.Controls[0].Width = panel.DisplayRectangle.Width - panel.Controls[0].Margin.Horizontal;
                for (var i = 1; i < panel.Controls.Count; i++)
                {
                    panel.Controls[i].Dock = DockStyle.Top;
                }
            }
        }

        private void MarkedAsReadByToggleButtonOnToggled(bool expanded)
        {
            if (expanded && markedAsReadByGrid == null && DetailsMarkedAsReadByExpand != null)
            {
                markedAsReadByGrid = new DomainListView<ItemReadBy>(new LogReadByListViewRenderer(), false)
                {Dock = DockStyle.Fill};
                markedAsReadByPanel.Controls.Add(markedAsReadByGrid);
                markedAsReadByPanel.Visible = true;
                markedAsReadPanel.Height += 100;
                DetailsMarkedAsReadByExpand(log);
            }
            else if (expanded && markedAsReadByGrid != null)
            {
                markedAsReadByPanel.Visible = true;
                markedAsReadByPanel.Height += 100;
            }
            else
            {
                markedAsReadByPanel.Visible = false;
                markedAsReadByPanel.Height -= 100;
            }
        }

        private void SetMarkedAsReadToDefault()
        {
            if (markedAsReadToggleButton.Expanded)
            {
                markedAsReadPanel.Height -= 100;
                markedAsReadToggleButton.Expanded = false;
            }
            markedAsReadByPanel.Controls.Remove(markedAsReadByGrid);
            markedAsReadByGrid = null;
            markedAsReadByPanel.Visible = false;
        }

        private void InitializeFunctionalLocationsGrid()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            flocContentPanel.Controls.Add(functionalLocationListView);
        }

        private void ControlResponsibleForAutoScrolling_MouseEnter(object sender, EventArgs e)
        {
            mainFlowLayoutPanel.Focus();
        }

        private void LogDetails_LogViewThread(object sender, EventArgs e)
        {
            InitializeSplitterDistance();
        }

        private void InitializeSplitterDistance()
        {
            logDetailsThreadHelper.InitializeSplitterDistance(Height);
        }

        private void logDetailThreadTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectedThreadItemChanged != null)
            {
                SelectedThreadItemChanged(this,
                    new DomainEventArgs<LogDTO>((LogDTO) logDetailThreadTreeView.SelectedLogDTO));
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            if (Reply != null)
            {
                Reply(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (Copy != null)
            {
                Copy(this, e);
            }
        }

        private void viewThreadButton_Click(object sender, EventArgs e)
        {
            if (ViewThread != null)
            {
                ViewThread(this, e);
            }
        }

        private void editHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void markAsReadButton_Click(object sender, EventArgs e)
        {
            if (MarkAsRead != null)
            {
                MarkAsRead(this, e);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(this, e);
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (Preview != null)
            {
                Preview(this, e);
            }
        }

        private void ExpandLinkLabel1Click(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(Comments, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        public void Clear()
        {
            CreationDateTime = string.Empty;
            Comments = string.Empty;
            FunctionalLocations = new List<FunctionalLocation>();

            IsOperatingEngineerLog = false;
            RecommendForShiftSummary = false;

            ProcessControl = false;
            Operations = false;
            Inspection = false;
            Supervision = false;
            EnvironmentalHealthAndSafety = false;
            OtherFollowUp = false;

            WorkAssignment = string.Empty;

            RecurrenceStartDate = string.Empty;
            RecurrenceEndDate = string.Empty;
            RaiseStartTime = string.Empty;
            RecurrencePattern = string.Empty;
        }

        private void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldEntryGrid.Items = CustomFieldEntryGridRenderer.Convert(customFieldEntries, customFields);
        }

        public void HideActionStrip()
        {
            ShowTreePanel = false;
            actionStrip.Hide();
        }

        private void InitializeCustomFieldEntriesGrid()
        {
            var customFieldEntryGridRenderer = new CustomFieldEntryGridRenderer();
            customFieldEntryGridRenderer.CustomFieldEntryClicked += CustomFieldEntryGridRendererCustomFieldEntryClicked;

            customFieldEntryGrid = new SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter>(
                customFieldEntryGridRenderer,
                OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT);

            customFieldEntryGrid.Dock = DockStyle.Fill;
            customFieldEntryGrid.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            customFieldEntryGrid.DisplayLayout.GroupByBox.Hidden = true;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeCell = SelectType.Single;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            customFieldEntryGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            customFieldEntryGrid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            customFieldEntryGrid.DisplayLayout.Override.RowSizingAutoMaxLines =
                CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter.NumberOfRowsToShow;
            customFieldEntryGrid.DrawFilter = new CustomFieldEntryGridRenderer.DrawFilter();

            customFieldEntriesPanel.Controls.Add(customFieldEntryGrid);
        }

        private void CustomFieldEntryGridRendererCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (CustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {      
                CustomFieldEntryClicked(customFieldEntry);
            }
        }

        // Added by Mukesh for RITM0218684
        public event EventHandler Email;
        private void EmailButton_Click(object sender, EventArgs e)
        {
            if (Email != null)
            {
                Email(this, e);
            }
        }
        public bool EmailEnabled
        {
            set { emailButton.Enabled = value; }
        }





        private void oltDGVImage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (log.Imagelist != null && log.Imagelist.Count > 0)
                    if (oltDGVImage.Columns[e.ColumnIndex].Name == "Imagebutton")
                    {
                        if (log.Imagelist.Count > 0)
                        {
                            if (log.Imagelist[e.RowIndex].Types != LogImage.Type.Title)
                            {
                                if (File.Exists(log.Imagelist[e.RowIndex].ImagePath))
                                {
                                e.Value = Image.FromFile(log.Imagelist[e.RowIndex].ImagePath);
                                oltDGVImage.Rows[e.RowIndex].Height = 80;
                                oltDGVImage.Rows[e.RowIndex].Cells["Imagebutton"].ToolTipText = StringResources.ImageColumnToolTipText;
                                }

                            }

                            else
                            {
                                Bitmap EmptyPic = new Bitmap(1, 1);
                                EmptyPic.SetPixel(0, 0, Color.Transparent);
                                e.Value = EmptyPic;

                            }
                        }
                    }
            }
            catch (Exception ex)
            {
               // OltMessageBox.ShowError(ex.Message);
            }
        }

        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if ((oltDGVImage.CurrentCell.OwningColumn).Name == "Imagebutton")
            {
                if (oltDGVImage.CurrentCell.ToolTipText.Equals("Title")) return;
                if (oltDGVImage.CurrentCell.EditedFormattedValue == null) return;

                Bitmap img = (Bitmap)(oltDGVImage).CurrentCell.EditedFormattedValue;

                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);

                ImageForm frm = new ImageForm(ms);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}