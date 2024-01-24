using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class TargetDefinitionDetails : AbstractDetails, ITargetDefinitionDetails
    {
        public event EventHandler Delete;
        public event EventHandler Approve;
        public event EventHandler Reject;
        public event EventHandler Edit;
        public event EventHandler Comment;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;

        private readonly DomainSummaryGrid<Comment> commentsSummaryGrid;
        private readonly DomainListView<TargetDefinitionDTO> dependantTargetsListView;

        public TargetDefinitionDetails()
        {
            InitializeComponent();
            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;
            approveButton.Click += approveButton_Click;
            rejectButton.Click += rejectButton_Click;
            commentsButton.Click += CommentsButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportAllButton_Click;
            editHistoryButton.Click += editHistoryButton_Click;
           
            commentsSummaryGrid = new DomainSummaryGrid<Comment>(new CommentGridRenderer(),
                                                                 OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, string.Empty)
                                      {Dock = DockStyle.Fill};
            commentsSummaryGrid.DisplayLayout.GroupByBox.Hidden = true;
            commentsPanel.Controls.Add(commentsSummaryGrid);

            dependantTargetsListView = new DomainListView<TargetDefinitionDTO>(new TargetDefinitionDTOListViewRenderer(), false);
            dependantTargetPanel.Controls.Add(dependantTargetsListView);
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            if (Approve != null)
            {
                Approve(this, e);
            }
        }

        private void CommentsButton_Click(object sender, EventArgs e)
        {
            if (Comment != null)
            {
                Comment(this, e);
            }
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            if (Reject != null)
            {
                Reject(this, e);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
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

        public string EditedBy
        {
            set { editedByDataLabel.Text = value; }
        }

        public bool RequiredApproval
        {
            set { requireApprovalCheckBox.Checked = value; }
        }

        public bool RequiredAlert
        {
            set { suppressAlertCheckBox.Checked = ! value; }
        }

        public bool RequiresResponseWhenAlerted
        {
            set { requiresResponseWhenAlertedCheckBox.Checked = value; }
        }

        public bool Active
        {
            set { temporarilyInactiveCheckBox.Checked = ! value; }
        }

        public bool GenerateActionItem
        {
            set { generateActionItemCheckBox.Checked = value; }
        }

        public string TargetName
        {
            set { targetNameData.Text = value; }
        }

        public string FunctionalLocation
        {
            set { functionalLocationData.Text = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        public new string Tag
        {
            set { tagData.Text = value; }
        }

        public string Category
        {
            set { categoryData.Text = value; }
        }

        public string WorkAssignment
        {
            set { workAssignmentLabelData.Text = value; }
        }
        
        public string Priority
        {
            set { priorityLabelData.Text = value; }
        }

        public string OperationalMode
        {
            set { operationalModeLabel.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        public string NeverToExceedMaxValue
        {
            set { neverToExceedMaxDataLabel.Text = value; }
        }

        public string MaxValue
        {
            set { maxDataLabel.Text = value; }
        }

        public string NeverToExceedMinValue
        {
            set { neverToExceedMinDataLabel.Text = value; }
        }

        public string MinValue
        {
            set { minDataLabel.Text = value; }
        }

        public string PreApprovedNeverToExceedMinValue
        {
            set { preApprovedNeverToExceedMinDataLabel.Text = value; }
        }

        public string PreApprovedNeverToExceedMaxValue
        {
            set { preApprovedNeverToExceedMaxDataLabel.Text = value; }
        }

        public string PreApprovedMinValue
        {
            set { preApprovedMinDataLabel.Text = value; }
        }

        public string PreApprovedMaxValue
        {
            set { preApprovedMaxDataLabel.Text = value; }
        }

        public string TargetValue
        {
            set { targetDataLabel.Text = value; }
        }

        public string GapUnitValue
        {
            set { gapUnitValueDataLabel.Text = value; }
        }

        public string GapUnitValueUnits
        {
            set { guvUnitsLabel.Text = value; }
        }

        public string NeverToExceedMaxFrequency
        {
            set { nteMaxFrequency.Text = value; }
        }

        public string NeverToExceedMinFrequency
        {
            set { nteMinFrequency.Text = value; }
        }

        public string MaxValueFrequency
        {
            set { maxFrequency.Text = value; }
        }

        public string MinValueFrequency
        {
            set { minFrequency.Text = value; }
        }

        public TagDirection MaxReadWriteDirection
        {
            set { maxReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection MinReadWriteDirection
        {
            set { minReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection TargetReadWriteDirection
        {
            set { targetReadWriteTagDirectionLabel.Direction = value; }
        }

        public TagDirection GapUnitReadWriteDirection
        {
            set { gapUnitValueReadWriteTagDirectionLabel.Direction = value; }
        }

        public ISchedule Schedule
        {
            set
            {
                scheduleDisplay.ShowEndTimeOnlyIfEndDateNotNull = (value.Type == ScheduleType.RoundTheClock);
                scheduleDisplay.Schedule = value;
            }
        }

        public List<Comment> Comments
        {
            set
            {
                if (value != null)
                {
                    value.Sort(comment => comment.CreatedDate, false);
                    commentsSummaryGrid.Items = value;
                }
                else
                    commentsSummaryGrid.Items = new List<Comment>();
            }
        }

        public List<TargetDefinitionDTO> TargetDefinitions
        {
            set {
                dependantTargetsListView.ItemList = value ?? new List<TargetDefinitionDTO>();
            }
        }

        public bool ApproveEnabled
        {
            set { approveButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool RejectEnabled
        {
            set { rejectButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool CommentEnabled
        {
            set { commentsButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
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
    }
}