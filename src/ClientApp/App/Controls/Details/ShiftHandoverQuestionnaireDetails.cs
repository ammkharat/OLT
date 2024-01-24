using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class ShiftHandoverQuestionnaireDetails : AbstractDetails, IShiftHandoverQuestionnaireDetails
    {
        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private DomainListView<ItemReadBy> markedAsReadByGrid;
        private ShiftHandoverQuestionnaire shiftHandoverQuestionnaire;
        List<LogImage> lstimage = new List<LogImage>();
        public ShiftHandoverQuestionnaireDetails()
        {
            InitializeComponent();
            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            flowLayoutPanel.MouseEnter += DetailsPanel_MouseEnter;
            deleteButton.Click += DeleteButton_Click;
            editButton.Click += EditButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            exportAllButton.Click += ExportAllButton_Click;
            markAsReadButton.Click += MarkAsReadButton_Click;
            printButton.Click += PrintButton_Click;
            previewButton.Click += PreviewButton_Click;
            emailButton.Click += EmailButton_Click;

            flowLayoutPanel.Layout += flowLayoutPanel_Layout;
            expandLinkLabel1.Click += ExpandLinkLabel1Click;
            summaryLogCustomFieldEntrySetsControl.CustomFieldEntryClicked += OnSummaryLogCustomFieldEntryClicked;
            shiftLogCustomFieldEntrySetsControl.CustomFieldEntryClicked += OnShiftLogCustomFieldEntryClicked;
            markedAsReadToggleButton.Toggled += MarkedAsReadByToggleButtonOnToggled;
        }

        protected override Panel Details
        {
            get { return flowLayoutPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        public bool RangeVisible
        {
            set { ToggleDateRangeButton.Visible = value; }
        }

        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;
        public event EventHandler MarkAsRead;
        public event EventHandler Print;
        public event EventHandler Preview;
        public event EventHandler Email;

        public event CustomFieldEntryClickHandler SummaryLogCustomFieldEntryClicked;
        public event CustomFieldEntryClickHandler ShiftLogCustomFieldEntryClicked;

        public event Action<ShiftHandoverQuestionnaire> DetailsMarkedAsReadByToggled;

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PreviewEnabled
        {
            set { previewButton.Enabled = value; }
        }

        public bool EmailEnabled
        {
            set { emailButton.Enabled = value; }
        }

        public string CreatedBy
        {
            set { createdByDataLabel.Text = value; }
        }

        public string CreatedDateTime
        {
            set { createdDateTimeDataLabel.Text = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set
            {
                if (value != null)
                {
                    functionalLocationListView.ItemList = value;
                }
            }
        }

        public WorkAssignment Assignment
        {
            set { assignmentDataLabel.Text = value == null ? string.Empty : value.DisplayName; }
        }

        public string ShiftHandoverConfigurationName
        {
            set { handoverTypeDataLabel.Text = value; }
        }

        public List<ShiftHandoverAnswer> Answers
        {
            set
            {
                SuspendLayout();

                answerControl.Answers = value;
                panelQuestions.Height = answerControl.Height + 10;

                ResumeLayout(false);
                PerformLayout();
            }
        }

        public void SetAndFormatComments(ShiftHandoverQuestionnaire handover, List<HasCommentsDTO> summaryLogComments,
            List<HasCommentsDTO> logComments)
        {
            SetMarkedAsReadToDefault();
            shiftHandoverQuestionnaire = handover;
            var commentsBuilder =
                new ShiftHandoverCommentTextRenderer.RichTextCommentsBuilder(richTextDisplay);
            var renderer = new ShiftHandoverCommentTextRenderer(commentsBuilder);

            renderer.RenderCommentText(handover, summaryLogComments, logComments);

            //Mukesh for Log Image
            //System.Data.DataTable dt = new System.Data.DataTable();
            
            pnlImagedetails.Visible = false;
            foreach (HasCommentsDTO comment in logComments)
            {
                if(comment.SummaryLogImagelist!=null && comment.SummaryLogImagelist.Count>0)
                {
                    pnlImagedetails.Visible = true;
                    foreach(LogImage Img in comment.SummaryLogImagelist)
                    {
                        lstimage.Add(Img);
                    }
                }
            }

            foreach (HasCommentsDTO comment in summaryLogComments)
            {
                if (comment.SummaryLogImagelist != null && comment.SummaryLogImagelist.Count > 0)
                {
                      pnlImagedetails.Visible = true;
                    foreach (LogImage Img in comment.SummaryLogImagelist)
                    {
                        lstimage.Add(Img);
                    }
                }
            }
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = DBNull.Value;
            oltDGVImage.DataSource = lstimage;
            oltDGVImage.Refresh();
            //End Mukesh for Log Image

        }

        public List<ItemReadBy> MarkedAsReadBy
        {
            set { markedAsReadByGrid.ItemList = value; }
        }

        public bool MarkAsReadEnabled
        {
            set { markAsReadButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
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

        public void ClearComments()
        {
            richTextDisplay.Clear();
        }

        public void HideSummaryLogCustomFieldEntries()
        {
            SuspendLayout();

            panelSummaryLogCustomFields.Hide();

            ResumeLayout(false);
            PerformLayout();
        }

        public void HideShiftLogCustomFieldEntries()
        {
            SuspendLayout();

            panelShiftLogCustomFields.Hide();

            ResumeLayout(false);
            PerformLayout();
        }

        public void AddSummaryLogCustomFieldEntries(List<HasCommentsDTO> summaryLogs,
            Dictionary<long, List<CustomField>> summaryLogIdToCustomFieldsMap)
        {
            SuspendLayout();

            var hasCustomFieldEntrieses = summaryLogs.ConvertAll(s => (IHasCustomFieldEntries) s);
            summaryLogCustomFieldEntrySetsControl.SetCustomFields(hasCustomFieldEntrieses, summaryLogIdToCustomFieldsMap);

            summaryLogCustomFieldEntrySetsControl.FitToContents();
            panelSummaryLogCustomFields.Height = summaryLogCustomFieldEntrySetsControl.Height + 10;
            panelSummaryLogCustomFields.Show();

            ResumeLayout(false);
            PerformLayout();
        }

        public void AddShiftLogCustomFieldEntries(List<HasCommentsDTO> logs,
            Dictionary<long, List<CustomField>> logIdToCustomFieldsMap)
        {
            SuspendLayout();

            shiftLogCustomFieldEntrySetsControl.SetCustomFields(logs.ConvertAll(l => (IHasCustomFieldEntries) l),
                logIdToCustomFieldsMap);
            shiftLogCustomFieldEntrySetsControl.FitToContents();
            panelShiftLogCustomFields.Height = shiftLogCustomFieldEntrySetsControl.Height + 10;
            panelShiftLogCustomFields.Show();

            ResumeLayout(false);
            PerformLayout();
        }

        public void AddCokerCardSummaries(List<CokerCardDrumEntryDTO> cokerCardSummaries)
        {
            var renderer = new CokerCardSummaryRenderer(richTextDisplay);
            renderer.RenderCokerCardSummaries(cokerCardSummaries);
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Visible = false;
            }
        }

        public void AddMarkedAsReadUser(ItemReadBy itemReadBy)
        {
            if (markedAsReadByGrid != null)
            {
                markedAsReadByGrid.ItemList.Add(itemReadBy);
            }
        }

        private void ExpandLinkLabel1Click(object sender, EventArgs eventArgs)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(richTextDisplay.Text, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void flowLayoutPanel_Layout(object sender, LayoutEventArgs e)
        {
            flowLayoutPanel.Controls[0].Dock = DockStyle.None;

            flowLayoutPanel.Controls[0].Width =
                flowLayoutPanel.DisplayRectangle.Width - flowLayoutPanel.Controls[0].Margin.Horizontal;

            for (var i = 1; i < flowLayoutPanel.Controls.Count; i++)
            {
                flowLayoutPanel.Controls[i].Dock = DockStyle.Top;
            }
        }

        private void MarkedAsReadByToggleButtonOnToggled(bool expanded)
        {
            if (expanded && markedAsReadByGrid == null && DetailsMarkedAsReadByToggled != null)
            {
                markedAsReadByGrid = new DomainListView<ItemReadBy>(new LogReadByListViewRenderer(), false)
                {
                    Dock = DockStyle.Fill
                };
                markedAsReadByPanel.Controls.Add(markedAsReadByGrid);
                markedAsReadByPanel.Visible = true;
                markedAsReadPanel.Height += 100;
                DetailsMarkedAsReadByToggled(shiftHandoverQuestionnaire);
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

        private void DetailsPanel_MouseEnter(object sender, EventArgs e)
        {
            flowLayoutPanel.Focus();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void MarkAsReadButton_Click(object sender, EventArgs e)
        {
            if (MarkAsRead != null)
                MarkAsRead(this, e);
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

        private void EmailButton_Click(object sender, EventArgs e)
        {
            if (Email != null)
            {
                Email(this, e);
            }
        }

        private void OnSummaryLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (SummaryLogCustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {
               
                SummaryLogCustomFieldEntryClicked(customFieldEntry);
            }
        }

        private void OnShiftLogCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (ShiftLogCustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {
                ShiftLogCustomFieldEntryClicked(customFieldEntry);
            }
        }



        private void oltDGVImage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (lstimage != null && lstimage.Count > 0)
                    if (oltDGVImage.Columns[e.ColumnIndex].Name == "Imagebutton")
                    {
                        if (lstimage.Count > 0)
                        {
                            if (lstimage[e.RowIndex].Types != LogImage.Type.Title)
                            {
                                if (File.Exists(lstimage[e.RowIndex].ImagePath))
                                {
                                    e.Value = Image.FromFile(lstimage[e.RowIndex].ImagePath);
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
            catch(Exception ex)
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