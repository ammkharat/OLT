using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class LogDefinitionDetails : AbstractDetails, ILogDefinitionDetails
    {
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;

        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;

        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;
        private DomainListView<FunctionalLocation> functionalLocationListView;

        public LogDefinitionDetails()
        {
            InitializeComponent();
            InitializeFunctionalLocationsGrid();
            InitializeCustomFieldEntriesGrid();

            editButton.Click += editButton_Click;
            cancelButton.Click += cancelButton_Click;
            exportAllButton.Click += exportAllButton_Click;
            editHistoryButton.Click += editHistoryButton_Click;
            expandLinkLabel1.Click += ExpandLinkLabel1Click;

            mainFlowLayoutPanel.Layout += MainFlowLayoutPanel_Layout;
            mainFlowLayoutPanel.MouseEnter += ControlResponsibleForAutoScrolling_MouseEnter;

            customFieldEntriesPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ExpandLinkLabel1Click(object sender, EventArgs e)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Comments, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private static void MainFlowLayoutPanel_Layout(object sender, LayoutEventArgs e)
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

        private void ControlResponsibleForAutoScrolling_MouseEnter(object sender, EventArgs e)
        {
            mainFlowLayoutPanel.Focus();
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void InitializeFunctionalLocationsGrid()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            flocContentPanel.Controls.Add(functionalLocationListView);
        }

        private void cancelButton_Click(object sender, EventArgs e)
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

        private void exportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void editHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { cancelButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool IsOperatingEngineerLog
        {
            set { isOperatingEngineerLogCheckBox.Checked = value; }
        }

        public string OperatingEngineerLogDisplayText
        {
            set { isOperatingEngineerLogCheckBox.Text = value;} 
        }
         
        public string CreationDateTime
        {
            set { creationDateTimeTextBox.Text = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListView.ItemList = value; }
        }

        public string WorkAssignment
        {
            set { workAssignmentTextBox.Text = value; }
        }

        public bool CreateALogForEachFunctionalLocation
        {
            set
            {
                createLogForEachFlocRadioButton.Checked = value;
                createOneLogForAllFlocsRadioButton.Checked = !value;
            }
        }

        public bool Inspection
        {
            set { inspectionCheckBox.Checked = value; }
        }

        public bool ProcessControl
        {
            set { processControlCheckBox.Checked = value; }
        }

        public bool Operations
        {
            set { operationsCheckBox.Checked = value; }
        }

        public bool EnvironmentalHealthAndSafety
        {
            set { EnvironmentalHealthAndSafetyCheckBox.Checked = value; }
        }

        public bool OtherFollowUp
        {
            set { otherCheckBox.Checked = value; }
        }

        public bool Supervision
        {
            set { supervisionCheckBox.Checked = value; }
        }

        public string Comments
        {
            get { return commentsDisplayControl.Text; }
            set { commentsDisplayControl.Text = value; }
        }

        public string RecurrenceStartDate
        {
            set { recurrenceStartDateData.Text = value; }
        }

        public string RecurrenceEndDate
        {
            set { recurrenceEndDateData.Text = value; }
        }

        public string RaiseStartTime
        {
            set { raiseStartTimeData.Text = value; }
        }

        public string RecurrencePattern
        {
            set { recurrencePatternData.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields)
        {
            customFieldEntryGrid.Items = CustomFieldEntryGridRenderer.Convert(customFieldEntries, customFields);
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

        void CustomFieldEntryGridRendererCustomFieldEntryClicked(CustomFieldEntry customFieldEntry)
        {
            if (CustomFieldEntryClicked != null && !customFieldEntry.IsJustForDisplay)
            {
                CustomFieldEntryClicked(customFieldEntry);
            }
        }

        public bool OptionsVisible
        {
            set { optionsPanel.Visible = value; }
        }

        public bool CustomFieldsPanelVisible
        {
            set { customFieldsPanel.Visible = value; }
        }

        public bool FollowupPanelVisible
        {
            set { followupPanel.Visible = value; }
        }

        public bool MultipleFlocOptionsVisible
        {
            set { multipleFlocPanel.Visible = value; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }
    }
}
