using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class SummaryLogDetails : AbstractDetails, ISummaryLogDetails
    {
        private const int COMMENTS_FIELD_HEIGHT_WHEN_DOR_HIDDEN = 264;
        private const int COMMENTS_FIELD_HEIGHT_WHEN_DOR_SHOWING = 129;

        public event DomainEventHandler<SummaryLogDTO> SelectedThreadItemChanged;

        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler MarkAsRead;
        public event EventHandler ExportAll;       
        public event EventHandler Print;
        public event EventHandler Preview;
        public event EventHandler Reply;
        public event EventHandler ViewThread;
        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;
        public event Action<SummaryLog> DetailsMarkedAsReadByToggled;
        public event EventHandler Email;
        private DomainListView<FunctionalLocation> functionalLocationListView;
        private DomainListView<ItemReadBy> markedAsReadByGrid;
        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;
        public event EventHandler Copy; ////Aarti :RITM0512605:Copy feature for Shift Summary log

        private readonly LogDetailsThreadHelper logDetailsThreadHelper;

        private SummaryLog summaryLog;
       

        public SummaryLogDetails()
        {
            InitializeComponent();
            InitializeFunctionalLocationsGrid();
            InitializeCustomFieldEntriesGrid();

            Dock = DockStyle.Fill;

            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;
           
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;
            editHistoryButton.Click += editHistoryButton_Click;
            copyButton.Click += copyButton_Click; ////Aarti :RITM0512605:Copy feature for Shift Summary log

            markAsReadButton.Click += markAsReadButton_Click;

            customFieldEntriesPanel.BorderStyle = BorderStyle.FixedSingle;

            printButton.Click += PrintButton_Click;
            previewButton.Click += PreviewButton_Click;

            replyButton.Click += ReplyButton_Click;
            viewThreadButton.Click += ViewThreadButton_Click;
            expandLinkLabel1.Click += ExpandLinkLabel1Click;

            ViewThread += HandleViewThread;

            logDetailsThreadHelper = new LogDetailsThreadHelper(splitContainer, logDetailThreadTreeView, viewThreadButton);
            logDetailsThreadHelper.AfterSelect += HandleLogThreadAfterSelect;

            mainFlowLayoutPanel.Layout += HandleMainFlowLayoutPanelLayout;
            markedAsReadToggleButton.Toggled += MarkedAsReadByToggleButtonOnToggled;
       
            // Added by Mukesh for RITM0218684
            emailButton.Click += EmailButton_Click;
        }

        private void HandleMainFlowLayoutPanelLayout(object sender, LayoutEventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            if (panel != null)
            {
                panel.Controls[0].Dock = DockStyle.None;
                panel.Controls[0].Width = panel.DisplayRectangle.Width - panel.Controls[0].Margin.Horizontal;
                for (int i = 1; i < panel.Controls.Count; i++)
                {
                    panel.Controls[i].Dock = DockStyle.Top;
                }
            }
        }

        private void ExpandLinkLabel1Click(object sender, EventArgs eventArgs)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(RtfComments, true);
            expandedLogCommentForm.ShowDialog();
        }

        private void HandleLogThreadAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectedThreadItemChanged != null)
            {
                SelectedThreadItemChanged(this, new DomainEventArgs<SummaryLogDTO>((SummaryLogDTO)logDetailThreadTreeView.SelectedLogDTO));
            }
        }

        private void HandleViewThread(object sender, EventArgs e)
        {
            splitContainer.SplitterDistance = Height / 2;
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void InitializeFunctionalLocationsGrid()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationPanel.Controls.Add(functionalLocationListView);
        }

        private void InitializeCustomFieldEntriesGrid()
        {
            CustomFieldEntryGridRenderer customFieldEntryGridRenderer = new CustomFieldEntryGridRenderer();
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
            customFieldEntryGrid.DisplayLayout.Override.RowSizingAutoMaxLines = CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter.NumberOfRowsToShow;
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

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }
                                     
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
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

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            if (Reply != null)
            {
                Reply(this, e);
            }
        }

        private void ViewThreadButton_Click(object sender, EventArgs e)
        {
            if (ViewThread != null)
            {
                ViewThread(this, e);
            }
        }

        public void SelectThreadItem(IThreadableDTO selectedDto)
        {
            logDetailsThreadHelper.SelectedDTO = selectedDto;
        }

        public override void Hide()
        {
            base.Hide();
            ShowTreePanel = false;
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

        public void Clear()
        {
            CreationDateTime = string.Empty;
            LogDateTime = string.Empty;
            RtfComments = string.Empty;
            FunctionalLocations = new List<FunctionalLocation>();
            WorkAssignment = string.Empty;

            ProcessControl = false;
            Operations = false;
            Inspection = false;
            Supervision = false;
            EnvironmentalHealthAndSafety = false;
            OtherFollowUp = false;
            HideDORComments = false;
        }

        private string CreationDateTime
        {
            set { creationDateTimeTextBox.Text = value; }
        }

        private string LogDateTime
        {
            set { logDateTimeTextBox.Text = value; }
        }

        private string RtfComments
        {
            get { return commentsDisplayControl.Text; }
            set { commentsDisplayControl.Text = value; }
        }

        private string DorComments
        {
            set { dorCommentsTextBox.Text = value; }
        }

        private List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value; }
        }

        private string WorkAssignment
        {
            set { workAssignmentTextBox.Text = value; }
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

        private List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        public List<ItemReadBy> MarkedAsReadBy
        {
            set { markedAsReadByGrid.ItemList = value; }
        }

        private void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            if (customFields.Count > 0 && CustomFieldEntry.HasAtLeastOneNonEmptyEntry(customFieldEntries))
            {
                customFieldsPanel.Visible = true;
                customFieldEntryGrid.Items = CustomFieldEntryGridRenderer.Convert(customFieldEntries, customFields);
            }
            else
            {
                customFieldsPanel.Visible = false;
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

        public bool CancelEnabled
        {
            set { }
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
        //Amit Shukla disable copy button if no record selected 
        public bool CopyButtonEnabled
        {
           set { copyButton.Enabled = value; }
           
        }


        private bool HideDORComments
        {
            set
            {
                if (value)
                {
                    dorCommentsPanel.Visible = false;
                    summaryCommentsPanel.Height += (COMMENTS_FIELD_HEIGHT_WHEN_DOR_HIDDEN - commentsDisplayPanel.Height);
                    commentsDisplayPanel.Height = COMMENTS_FIELD_HEIGHT_WHEN_DOR_HIDDEN;
                }
                else
                {
                    dorCommentsPanel.Visible = true;
                    summaryCommentsPanel.Height -= (commentsDisplayPanel.Height - COMMENTS_FIELD_HEIGHT_WHEN_DOR_SHOWING);
                    commentsDisplayPanel.Height = COMMENTS_FIELD_HEIGHT_WHEN_DOR_SHOWING;
                }
            }
        }

        private void MarkedAsReadByToggleButtonOnToggled(bool expanded)
        {
            if (expanded && markedAsReadByGrid == null && DetailsMarkedAsReadByToggled != null)
            {
                markedAsReadByGrid = new DomainListView<ItemReadBy>(new LogReadByListViewRenderer(), false) { Dock = DockStyle.Fill };
                markedAsReadByPanel.Controls.Add(markedAsReadByGrid);
                markedAsReadByPanel.Visible = true;
                markedAsReadPanel.Height += 100;
                DetailsMarkedAsReadByToggled(summaryLog);
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

        public void SetDetails(SummaryLog log, List<CustomField> customFields)
        {
            summaryLog = log;

            SetMarkedAsReadToDefault();
            CreationDateTime = log.CreatedDateTime.ToLongDateAndTimeString();
            LogDateTime = log.LogDateTime.ToLongDateAndTimeString();
            SetCustomFieldEntries(log.CustomFieldEntries, customFields);

            RtfComments = log.RtfComments;
            DorComments = log.DorComments;

            HideDORComments = ClientSession.GetUserContext().SiteConfiguration.HideDORCommentEntry;

            FunctionalLocations = log.FunctionalLocations;
            WorkAssignment = log.WorkAssignment != null ? log.WorkAssignment.DisplayName : null;

            ProcessControl = log.ProcessControlFollowUp;
            Operations = log.OperationsFollowUp;
            Inspection = log.InspectionFollowUp;
            Supervision = log.SupervisionFollowUp;
            EnvironmentalHealthAndSafety = log.EnvironmentalHealthSafetyFollowUp;
            OtherFollowUp = log.OtherFollowUp;

            DocumentLinks = log.DocumentLinks;

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

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return toggleShowButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
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


        // Added by Mukesh for RITM0218684
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
                if (summaryLog.Imagelist != null && summaryLog.Imagelist.Count > 0)
                    if (oltDGVImage.Columns[e.ColumnIndex].Name == "Imagebutton")
                    {
                        if (summaryLog.Imagelist.Count > 0)
                        {
                            if (summaryLog.Imagelist[e.RowIndex].Types != LogImage.Type.Title)
                            {
                                if (File.Exists(summaryLog.Imagelist[e.RowIndex].ImagePath))
                                {
                                    e.Value = Image.FromFile(summaryLog.Imagelist[e.RowIndex].ImagePath);
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
                //OltMessageBox.ShowError(ex.Message);
            }
        }
       
        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((oltDGVImage.CurrentCell.OwningColumn).Name == "Imagebutton")
            {
                if (oltDGVImage.CurrentCell.EditedFormattedValue == null) return;
                if (oltDGVImage.CurrentCell.ToolTipText.Equals("Title")) return;
                Bitmap img = (Bitmap)(oltDGVImage).CurrentCell.EditedFormattedValue;

                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);

                ImageForm frm = new ImageForm(ms);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        ////Aarti :RITM0512605:Copy feature for Shift Summary log
        private void copyButton_Click(object sender, EventArgs e)
        {
            if (Copy != null)
            {
                Copy(this, e);
            }
        }
    }
}