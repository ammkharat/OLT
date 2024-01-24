using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SelectItemsForShiftSummaryForm : BaseForm, ISelectItemsForShiftSummaryFormView
    {
        public event Action FormLoad;
        public event Action AppendToCommentsButtonClicked;
        public event Action<object> SelectedItemChanged;
        public event Action<object> ItemSelectedForSummary;
        public event Action<object> ItemUnselectedForSummary;
        public event Action<WidgetAppearance> DateRangeButtonClicked;
        public event Action<Log> DetailsMarkedAsReadByToggled;

        private readonly SummaryGrid<IShiftSummaryItemGridDisplayAdapter> logGrid;
        private readonly LogDetails logDetails;
        private readonly ShiftHandoverQuestionnaireDetails shiftHandoverQuestionnaireDetails;
        private ShiftHandoverQuestionnaireDetailsPresenter shiftHandoverQuestionnaireDetailsPresenter;

        public SelectItemsForShiftSummaryForm()
        {
            InitializeComponent();

            logDetails = new LogDetails();
            logDetails.Dock = DockStyle.Fill;
            logDetails.AutoScroll = true;
            logDetails.TabIndex = 0;
            logDetails.MakeAllButtonsInvisible();
            logDetails.ShowTreePanel = false;
            logDetails.RangeVisible = true;
            logDetails.ToggleShow += HandleToggleShow;
            logDetails.DetailsMarkedAsReadByExpand += HandleDetailsMarkedAsReadByExpand;
            
            shiftHandoverQuestionnaireDetails = new ShiftHandoverQuestionnaireDetails();
            shiftHandoverQuestionnaireDetails.Dock = DockStyle.Fill;
            shiftHandoverQuestionnaireDetails.AutoScroll = true;
            shiftHandoverQuestionnaireDetails.TabIndex = 0;
            shiftHandoverQuestionnaireDetails.MakeAllButtonsInvisible();
            shiftHandoverQuestionnaireDetails.RangeVisible = true;
            shiftHandoverQuestionnaireDetails.ToggleShow += HandleToggleShow;

            UseLogDetails();

            logGrid = new SummaryGrid<IShiftSummaryItemGridDisplayAdapter>(new ItemsForSummaryGridRenderer(), OltGridAppearance.EDIT_ROW_SELECT_WITH_FILTER);
            logGrid.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(logGrid);

            logGrid.InitializeRow += LogGrid_InitializeRow;
            logGrid.AfterRowActivate += LogGrid_AfterRowActivate;
            logGrid.CellChange += LogGrid_CellChange;            
            appendToCommentsButton.Click += HandleAppendToCommentsButtonClicked;
            cancelButton.Click += CancelButton_Click;            
        }

        private void HandleDetailsMarkedAsReadByExpand(Log log)
        {
            if (log != null && DetailsMarkedAsReadByToggled != null)
            {
                DetailsMarkedAsReadByToggled(log);
            }
        }

        private void HandleToggleShow()
        {
            if (DateRangeButtonClicked != null)
            {
                DateRangeButtonClicked(UsingLogDetails ? logDetails.ShowButtonAppearance : shiftHandoverQuestionnaireDetails.ShowButtonAppearance);
            }
        }

        private void HandleAppendToCommentsButtonClicked(object sender, EventArgs eventArgs)
        {
            if (AppendToCommentsButtonClicked != null)
            {
                AppendToCommentsButtonClicked();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public void UseLogDetails()
        {
            splitContainer.SuspendLayout();

            if (UsingShiftHandoverQuestionnaireDetails)
            {
                splitContainer.Panel2.Controls.Remove(shiftHandoverQuestionnaireDetails);
            }
            splitContainer.Panel2.Controls.Add(logDetails);

            splitContainer.ResumeLayout(true);
        }

        public void UseShiftHandoverQuestionnaireDetails()
        {
            splitContainer.SuspendLayout();

            if (UsingLogDetails)
            {
                splitContainer.Panel2.Controls.Remove(logDetails);
            }

            splitContainer.Panel2.Controls.Add(shiftHandoverQuestionnaireDetails);

            splitContainer.ResumeLayout(true);
        }

        private bool UsingLogDetails
        {
            get { return splitContainer.Panel2.Controls.Contains(logDetails); }
        }

        private bool UsingShiftHandoverQuestionnaireDetails
        {
            get { return splitContainer.Panel2.Controls.Contains(shiftHandoverQuestionnaireDetails); }
        }

        private static void LogGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            foreach (UltraGridCell cell in e.Row.Cells)
            {
                if (cell.Column.Key == ItemsForSummaryGridRenderer.EDIT_COLUMN)
                {
                    cell.ActiveAppearance.BackColor = SystemColors.Window;
                    cell.ActiveAppearance.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void LogGrid_CellChange(object sender, CellEventArgs e)
        {
            UltraGridCell cell = e.Cell;

            if(cell != null)
            {
                // There is only one editable field in the grid, checking to make sure it's a CheckEditor is probably
                // a good idea.
                CheckEditor checkEditor = cell.EditorResolved as CheckEditor;

                if (checkEditor != null)
                {
                    object item = cell.Row.ListObject;

                    if (CheckState.Checked.Equals(checkEditor.CheckState))
                    {
                        if (ItemSelectedForSummary != null)
                        {
                            ItemSelectedForSummary(item);
                        }
                    }
                    else if (CheckState.Unchecked.Equals(checkEditor.CheckState))
                    {
                        if (ItemUnselectedForSummary != null)
                        {
                            ItemUnselectedForSummary(item);
                        }
                    }
                }
            }
        }

        private void LogGrid_AfterRowActivate(object sender, EventArgs e)
        {
            UltraGridRow ultraGridRow = logGrid.ActiveRow;
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(ultraGridRow.ListObject);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public List<IShiftSummaryItemGridDisplayAdapter> ItemList
        {
            set { logGrid.Items = value; }
        }

        public List<ItemReadBy> MarkedAsReadByList
        {
            set { logDetails.MarkedAsReadBy = value; }
        }

        public void SetDetails(Log item, List<CustomField> customFields)
        {
            logDetails.SetDetails(item, customFields);
        }

        public void SetDetails(ShiftHandoverQuestionnaire item)
        {
            shiftHandoverQuestionnaireDetailsPresenter = new ShiftHandoverQuestionnaireDetailsPresenter(shiftHandoverQuestionnaireDetails, item);
            shiftHandoverQuestionnaireDetailsPresenter.LoadView();
        }

        public void SetResultToOk()
        {
            DialogResult = DialogResult.OK;
        }

        public void HideDetails()
        {
            AbstractDetails details = (AbstractDetails) splitContainer.Panel2.Controls[0];
            details.Hide();
        }

        public void ShowDetails()
        {
            AbstractDetails details = (AbstractDetails)splitContainer.Panel2.Controls[0];
            details.Show();
        }

        public DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog()
        {
            DateRangeSelectorForm dateRangeForm = new DateRangeSelectorForm();
            return dateRangeForm.DisplayFormAsDialog(ParentForm);
        }

        public void ShowCurrentAppearanceForDateRangeButton()
        {
            logDetails.ShowButtonAppearance = Constants.SHOW_CURRENT_WIDGET_APPEARANCE;
            shiftHandoverQuestionnaireDetails.ShowButtonAppearance = Constants.SHOW_CURRENT_WIDGET_APPEARANCE;
        }

        public void ShowDateRangeAppearanceForDateRangeButton()
        {
            logDetails.ShowButtonAppearance = Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;
            shiftHandoverQuestionnaireDetails.ShowButtonAppearance = Constants.SHOW_DATE_RANGE_WIDGET_APPEARANCE;
        }

        public void SetGridHeader(string title)
        {
            pageTitle.Text = title;
        }

        public List<string> BuildCommentRichText(List<RtfChunk> rtfCommentChunks)
        {
            List<string> commentsForSummary = new List<string>();

            for (int i = 0; i < rtfCommentChunks.Count; i++)
            {
                RtfChunk chunk = rtfCommentChunks[i];

                if (!chunk.IsEmpty())
                {
                    bool isLast = (i == (rtfCommentChunks.Count - 1)) || rtfCommentChunks.Count == 1;
                    string richText = BuildCommentRichText(chunk, isLast);
                    commentsForSummary.Add(richText);
                }                
            }
            
            return commentsForSummary;
        }

        private static string BuildCommentRichText(RtfChunk chunk, bool isLast)
        {            
            RichEditDocumentServer richEditDocumentServer = new RichEditDocumentServer();

            string horizontalRule = "_____________________________________________" + Environment.NewLine;
            string rtfHorizontalRule = RichTextUtilities.ConvertTextToRTF(horizontalRule, 9, true, false, false);
            
            if (!isLast)
            {
                chunk.AddSubchunk(Environment.NewLine);
            }

            Document document = richEditDocumentServer.Document;
            document.AppendRtfText(rtfHorizontalRule);
            foreach (string subchunk in chunk.Subchunks)
            {
                string textAsRtf = RichTextUtilities.ConvertTextToRTF(subchunk);
                document.AppendRtfText(textAsRtf);
            }

            return richEditDocumentServer.RtfText;           
        }       
    }   
}
