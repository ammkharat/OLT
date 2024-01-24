using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class CokerCardDetails : AbstractDetails, ICokerCardDetails
    {
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;

        private readonly CokerCardRowGridRenderer gridRenderer;
        private readonly SummaryGrid<CokerCardRow> cokerCardGrid;

        public CokerCardDetails()
        {
            InitializeComponent();

            gridRenderer = new CokerCardRowGridRenderer(true);
            cokerCardGrid = new SummaryGrid<CokerCardRow>(gridRenderer, OltGridAppearance.NON_OUTLOOK);
            gridRenderer.InitializeGrid(cokerCardGrid);
            cokerCardGrid.Dock = DockStyle.Fill;

            cokerCardPanel.Controls.Add(cokerCardGrid);

            tableLayoutPanel.MouseEnter += DetailsPanel_MouseEnter;
            deleteButton.Click += DeleteButton_Click;
            editButton.Click += EditButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            exportAllButton.Click += ExportAllButton_Click;                                     
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void DetailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
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

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
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

        public void SetDetails(
            UserShift nextCokerCardUserShift,
            CokerCardConfiguration configuration,
            CokerCard cokerCard,
            CokerCard previousCokerCard,
            CokerCard nextCokerCard,
            CokerCard previousPreviousCokerCard)
        {
            if (cokerCard == null)
            {
                createdByDataLabel.Text = string.Empty;
                createdDateTimeDataLabel.Text = string.Empty;
                nameDataLabel.Text = string.Empty;
                functionalLocationDataLabel.Text = string.Empty;
                workAssignmentDataLabel.Text = string.Empty;

                gridRenderer.CycleStepEntryColumnKeys = new List<CycleStepEntryColumnKey>();
                cokerCardGrid.Items = new List<CokerCardRow>();
                tableLayoutPanel.RowStyles[tableLayoutPanel.GetCellPosition(cokerCardPanel).Row].Height = 70; 
            }
            else
            {
                createdByDataLabel.Text = cokerCard.CreatedBy.FullNameWithUserName;
                createdDateTimeDataLabel.Text = cokerCard.CreatedDateTime.ToLongDateAndTimeString();
                nameDataLabel.Text = cokerCard.ConfigurationName;
                functionalLocationDataLabel.Text = cokerCard.FunctionalLocation.FullHierarchyWithDescription;
                workAssignmentDataLabel.Text = string.Empty;
                if (cokerCard.WorkAssignment != null)
                {
                    workAssignmentDataLabel.Text = cokerCard.WorkAssignment.DisplayName;
                }

                CokerCardDisplayAdapter displayAdapter = new CokerCardDisplayAdapter(
                    nextCokerCardUserShift,
                    configuration, 
                    cokerCard,
                    previousCokerCard,
                    nextCokerCard,
                    previousPreviousCokerCard);
                gridRenderer.CycleStepEntryColumnKeys = displayAdapter.ColumnKeys;
                List<CokerCardRow> rows = displayAdapter.Rows;
                cokerCardGrid.Items = rows;

                int gridCellHeight = GetGridHeight() + 13;
                int gridCellWidth = GetGridWidth() + 13;
                tableLayoutPanel.RowStyles[tableLayoutPanel.GetCellPosition(cokerCardPanel).Row].Height = gridCellHeight;
                tableLayoutPanel.ColumnStyles[tableLayoutPanel.GetCellPosition(cokerCardPanel).Column].Width = gridCellWidth;

                int panelHeight = GetHeightOfAllRowsExceptForCokerCardRow() + gridCellHeight + 5;
                int panelWidth = (int)tableLayoutPanel.ColumnStyles[0].Width + gridCellWidth + 5;
                tableLayoutPanel.Height = panelHeight;
                tableLayoutPanel.Width = panelWidth;

                detailsPanel.AutoScrollMinSize = new Size(panelWidth, panelHeight);
            }
        }

        private int GetGridHeight()
        {
            int gridHeight = 30 + (22 + 2) * cokerCardGrid.Rows.Count; // 30 is header space, 22 is row height, 2 is the lines            
            return gridHeight;
        }

        private int GetGridWidth()
        {
            int width = 0;

            if (cokerCardGrid.Rows.Count > 0)
            {
                CellsCollection cellsForThatOneRow = cokerCardGrid.Rows[0].Cells;

                foreach (UltraGridCell cell in cellsForThatOneRow)
                {
                    if (!cell.Column.Hidden)
                    {
                        width += cell.Column.Width;
                    }
                }
            }

            return Math.Max(600, width);
        }

        private int GetHeightOfAllRowsExceptForCokerCardRow()
        {
            int height = 0;

            int[] rowHeights = tableLayoutPanel.GetRowHeights();
            for (int i = 0; i < rowHeights.Length; i++)
            {
                if (i != tableLayoutPanel.GetRow(cokerCardPanel))
                {
                    height += rowHeights[i];
                }
            }

            return height;
        }
    }
}