using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Microsoft.Office.Interop.Outlook;
using Action = System.Action;
using Exception = System.Exception;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class ActionItemDefinitionDetails : AbstractDetails, IActionItemDefinitionDetails
    {
        private ActionItemDefinition definition_img;
        public event EventHandler Approve;
        public event EventHandler Reject;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Comment;
        public event EventHandler ViewEditHistory; 
        public event EventHandler ExportAll;        
        public event EventHandler ViewAssociatedLogs;        
        public event Action ViewAssociatedGN75B;
        //mangesh - DMND0005327 - Request 15
        public event Action ViewAssociatedGN75B1;
        public event Action ViewAssociatedGN75B2; 
        
        private readonly DomainSummaryGrid<Comment> commentsSummaryGrid;
        private readonly DomainListView<FunctionalLocation> functionalLocationListView;
        private readonly DomainListView<TargetDefinitionDTO> targetDTOListView;

		// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        public event EventHandler Clone;

        public void SetDetails(ActionItemDefinition definition, bool isEdmontonSite)
        {
            
            EditedBy = definition.LastModifiedBy.FullNameWithUserName;
            Description = definition.Description;
            Schedule = definition.Schedule;
            ActionItemDefinitionName = definition.Name;
            ActionCategory = definition.Category != null ? definition.Category.Name : null;
            CustomfieldGroup = definition.Customfieldgroup != null ? definition.Customfieldgroup.Name : null;


            WorkAssignment = definition.Assignment != null ? definition.Assignment.DisplayName : null;
            Priority = definition.Priority.Name;
            Comments = definition.Comments;
            FunctionalLocations = definition.FunctionalLocations;
            RequiresApproval = definition.RequiresApproval;
            Active = definition.Active;
            CopyResponseToLog = definition.CopyResponseToLog; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            ResponseRequired = definition.ResponseRequired;
            TargetDefinitionDTOs = definition.TargetDefinitionDTOs;
            OperationalMode = definition.OperationalMode.Name;
            DocumentLinks = definition.DocumentLinks;
            CreateAnActionItemForEachFunctionalLocation = definition.CreateAnActionItemForEachFunctionalLocation;
            EveryShift = definition.EveryShift;//RITM0265710 mangesh      ayman commented to fix code overlap
            if (isEdmontonSite)
            {
                AssociatedGn75BFormNumber = definition.AssociatedFormGN75BId.HasValue ? definition.AssociatedFormGN75BId.Value : (long?)null;

                //mangesh - DMND0005327 - Request 15
                AssociatedGn75BFormNumber1 = definition.AssociatedFormGN75BId1.HasValue ? definition.AssociatedFormGN75BId1.Value : (long?)null;
                AssociatedGn75BFormNumber2 = definition.AssociatedFormGN75BId2.HasValue ? definition.AssociatedFormGN75BId2.Value : (long?)null;
            }
            else
            {
                HideGn75BAssocation();
            }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            //if (definition.Imagelist_detail != null && definition.Imagelist_detail.Count > 0)
            if (definition.Imagelist != null && definition.Imagelist.Count > 0)
            {
                oltDGVImage.Visible = true;
                oltDGVImage.AutoGenerateColumns = false;
                //oltDGVImage.DataSource = definition.Imagelist_detail;
                oltDGVImage.DataSource = definition.Imagelist;
            }
            else
            {
                oltDGVImage.Visible = false;

            }

            toolStrip.Visible = false;
        }

        public ActionItemDefinitionDetails()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;
            approveButton.Click += approveButton_Click;
            rejectButton.Click += rejectButton_Click;
            commentsButton.Click += CommentsButton_Click;
            exportAllButton.Click += exportAllButton_Click;
            editHistoryButton.Click += editHistoryButton_Click;            

            viewAssociatedLogsButton.Click += viewAssociatedLogsButton_Click;
            viewGN75BFormButton.Click += viewAssociatedGn75B_Click;

            commentsSummaryGrid = new DomainSummaryGrid<Comment>(new CommentGridRenderer(),
                                                                 OltGridAppearance.SINGLE_SELECT_WRAPPED_TEXT, string.Empty)
                                      {Dock = DockStyle.Fill};
            commentsSummaryGrid.DisplayLayout.GroupByBox.Hidden = true;
            commentsPanel.Controls.Add(commentsSummaryGrid);

            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false)
                                             {Dock = DockStyle.Fill};
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            targetDTOListView = new DomainListView<TargetDefinitionDTO>(new TargetDefinitionDTOListViewRenderer(), false)
                                    {Dock = DockStyle.Fill};
            dependentTargetsPanel.Controls.Add(targetDTOListView);

            //mangesh- DMND0005327- Requet 15
            viewGN75BFormButton1.Click += viewAssociatedGn75B1_Click;
            viewGN75BFormButton2.Click += viewAssociatedGn75B2_Click;

            oltDGVImage.AutoGenerateColumns = false;

			// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

            cloneButton.Click += cloneButton_Click;

        }

        private void viewAssociatedGn75B_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedGN75B != null)
            {
                ViewAssociatedGN75B();
            }
        }

        //mangesh- DMND0005327- Requet 15
        private void viewAssociatedGn75B1_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedGN75B1 != null)
            {
                ViewAssociatedGN75B1();
            }
        }
        //mangesh- DMND0005327- Requet 15
        private void viewAssociatedGn75B2_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedGN75B2 != null)
            {
                ViewAssociatedGN75B2();
            }
        }


        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        void detailsPanel_MouseEnter(object sender, EventArgs e)
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

        private void rejectButton_Click(object sender, EventArgs e)
        {
            if (Reject!= null)
            {
                Reject(this, e);
            }
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

        private void CommentsButton_Click(object sender, EventArgs e)
        {
            if (Comment != null)
            {
                Comment(this, e);
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

        private void viewAssociatedLogsButton_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs(this, e);
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
            }
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

        public List<TargetDefinitionDTO> TargetDefinitionDTOs
        {
            set
            {
                if (value != null)
                {
                    targetDTOListView.ItemList = value;
                }
            }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        //public List<ImageDownloader> actionItemImage
        //{
        //    set
        //    {
        //        oltDGVImage.DataSource = value;
        //        oltDGVImage.ClearSelection();
        //    }
            
        //}

        public List<ImageUploader> actionItemImage
        {
            set
            {
                oltDGVImage.DataSource = value;
                oltDGVImage.ClearSelection();
            }

        }
        

        public long? AssociatedGn75BFormNumber
        {
            set
            {
                viewGN75BFormButton.Enabled = value.HasValue;
                formGn75LabelData.Tag = value;
                formGn75LabelData.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
            }
            get { return (long?) formGn75LabelData.Tag; }
        }

        //mangesh - DMND0005327 - Request 15
        public long? AssociatedGn75BFormNumber1
        {
            set
            {
                viewGN75BFormButton1.Enabled = value.HasValue;
                formGn75LabelData1.Tag = value;
                formGn75LabelData1.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
            }
            get { return (long?)formGn75LabelData1.Tag; }
        }
        //mangesh - DMND0005327 - Request 15
        public long? AssociatedGn75BFormNumber2
        {
            set
            {
                viewGN75BFormButton2.Enabled = value.HasValue;
                formGn75LabelData2.Tag = value;
                formGn75LabelData2.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
            }
            get { return (long?)formGn75LabelData2.Tag; }
        }

        public bool CreateAnActionItemForEachFunctionalLocation
        {
            set
            {
                createActionItemForEachFlocRadioButton.Checked = value;
                createOneActionItemForAllFlocsRadioButton.Checked = !value;
            }
        }

        public bool EveryShift
        {
            set { everyShiftCheckBox.Checked = value; }
        }

        public string ActionCategory
        {
            set { actionCategoryLabelData.Text = value; }
        }

        //ayman custom fields DMND0010030
        public string CustomfieldGroup
        {
            set { customfieldGroupLabelData.Text = value; }
        }


        public string WorkAssignment
        {
            set { workAssignmentLabelData.Text = value; }
        }

        public string Priority
        {
            set { priorityLabelData.Text = value;  }
        }

        public string OperationalMode
        {
            set { operationalModeLabel.Text = value; }
        }

        public bool RequiresApproval
        {
            set { requiresApprovalCheckBox.Checked = value; }
        }

        public bool Active
        {
            set { temporarilyInActiveCheckBox.Checked = ! value; }
        }
//Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
        public bool CopyResponseToLog
        {
            set { temporarilyInActiveCheckBox.Checked = !value; }
        }

        public bool ResponseRequired
        {
            set { responseRequiredCheckBox.Checked = value; }
        }

        public bool ApproveEnabled
        {
            set { approveButton.Enabled = value; }
        }

        public bool RejectEnabled
        {
            set { rejectButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
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

        public void HideGn75BAssocation()
        {
            formGn75bLabel.Visible = false;
            formGn75LabelData.Visible = false;
            viewGN75BFormButton.Visible = false;

            //mangesh - DMND0005327 - Request 15
            formGn75LabelData1.Visible = false;
            viewGN75BFormButton1.Visible = false;
            formGn75LabelData2.Visible = false;
            viewGN75BFormButton2.Visible = false;

        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentsLinkControl.DataSource = value; }
        }

        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        public string EditedBy
        {
            set { editedByData.Text = value; }
        }

        public string ActionItemDefinitionName
        {
            set { nameData.Text = value; }
        }

        public ISchedule Schedule
        {
            set
            {
                scheduleDisplay.ShowEndTimeRegardlessOfEndDateNull = (value.Type != ScheduleType.Continuous);
                scheduleDisplay.ShowEndTimeOnlyIfEndDateNotNull = (value.Type == ScheduleType.Continuous);
                scheduleDisplay.ShowEndDateTimeForSingleEndDate = (value.Type == ScheduleType.Single);
                scheduleDisplay.Schedule = value;
            }
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
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        public ActionItemDefinition DefinitionDetailImage
        {
            set { definition_img = value; }
        }

        private void oltDGVImage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (oltDGVImage.Columns[e.ColumnIndex].Name == "PathImage")
                {
                    //if (definition_img.Imagelist_detail.Count > 0)
                    if (definition_img.Imagelist.Count > 0)
                    {
                        //e.Value = Image.FromFile(definition_img.Imagelist_detail[e.RowIndex].ImagePath);
                        e.Value = Image.FromFile(definition_img.Imagelist[e.RowIndex].ImagePath);

                        oltDGVImage.Columns[2].Width = 100;

                        for (int i = 0; i < oltDGVImage.Rows.Count; i++)
                        {
                            oltDGVImage.Rows[i].Height = 80;
                        }
                        oltDGVImage.Rows[e.RowIndex].Cells["PathImage"].ToolTipText = StringResources.ImageColumnToolTipText;


                    }
                }
            }
            catch (Exception)
            {
                
                
            }
           
        }

        public bool ImageGridVisible
        {
            get { return oltDGVImage.Enabled; }
            set
            {
                oltDGVImage.Enabled = value;

                if (!value)
                {
                    oltDGVImage.BackgroundColor = Color.LightGray;
                    
                }
                
            }
        }

        public bool ImageGridLabelVisible
        {
            get { return ActionItemDetailsImageLabel.Enabled; }
            set { ActionItemDetailsImageLabel.Enabled = value; }
        }

        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = 0;
            //if (oltDGVImage.CurrentCell.ColumnIndex.Equals(index) && e.RowIndex != -1)
            //    if (oltDGVImage.CurrentCell != null && oltDGVImage.CurrentCell.Value != null)
            //    {

            try
            {
                if ((oltDGVImage.CurrentCell.OwningColumn).HeaderText == "Image")
                {
                    //if (oltDGVImage.CurrentRow.Cells[2].EditedFormattedValue == string.Empty) return;

                    if (oltDGVImage.CurrentCell.EditedFormattedValue == string.Empty) return;

                    Bitmap img = (Bitmap)(oltDGVImage).CurrentCell.EditedFormattedValue;

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Png);

                    ImageForm frm = new ImageForm(ms);
                    frm.ShowDialog();
                }
            }
            catch (Exception)
            {
                
                
            }

//            if ((oltDGVImage.CurrentCell.OwningColumn).HeaderText == "View Image")
            
        }

		// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        private void cloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

    }
}