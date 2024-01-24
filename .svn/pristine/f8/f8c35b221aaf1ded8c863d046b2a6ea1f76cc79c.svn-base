using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class ActionItemDetails : AbstractDetails, IActionItemDetails
    {
        private ActionItem actionItem;
        public event EventHandler Respond;
        public event EventHandler ExportAll;
        public event EventHandler GoToDefinition;
        public event EventHandler ViewAssociatedLogs;
        public event EventHandler PrintPreview;
        public event EventHandler Print;
        public event Action ViewAssociatedGN75B;
        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;

        public event EventHandler CopyLastResponse; //DMND0010124 mangesh

        public event CustomFieldEntryClickHandler CustomFieldEntryClicked;


        //mangesh - DMND0005327 -Request 15
        public event Action ViewAssociatedGN75B1;
        public event Action ViewAssociatedGN75B2;
        public event Action EditAssociatedGN75B;
        public event Action EditAssociatedGN75B1;
        public event Action EditAssociatedGN75B2;

        public void SetDetails(ActionItem actionItem, bool isEdmontonSite, bool HideCustomFields)     //ayman fix customfields          
        {
            this.actionItem = actionItem;
            StartDate = actionItem.StartDateTime.ToDateString();
            StartTime = actionItem.StartDateTime.ToTimeString();
            EndTime = actionItem.EndDateTime.ToTimeString();

            Name = actionItem.Name;
            Status = actionItem.Status.ToString();
            Description = actionItem.Description;
            Category = actionItem.CategoryName;
            WorkAssignment = actionItem.Assignment != null ? actionItem.Assignment.DisplayName : null;
            RequestedBy = actionItem.CreatedByActionItemDefinition == null ? string.Empty : actionItem.CreatedByActionItemDefinition.CreatedBy.FullNameWithUserName;
            FunctionalLocations = actionItem.FunctionalLocations;
            AssociatedDocumentLinks = actionItem.DocumentLinks;

            if (isEdmontonSite)
            {
                AssociatedGn75BFormNumber = actionItem.AssociatedFormGn75BId.HasValue ? actionItem.AssociatedFormGn75BId.Value : (long?)null;

                //mangesh- DMND000537- Request 15
                AssociatedGn75BFormNumber1 = actionItem.AssociatedFormGn75BId1.HasValue ? actionItem.AssociatedFormGn75BId1.Value : (long?)null;
                AssociatedGn75BFormNumber2 = actionItem.AssociatedFormGn75BId2.HasValue ? actionItem.AssociatedFormGn75BId2.Value : (long?)null;
            }
            else
            {
                HideGn75BAssocation();
            }


            //ayman custom fields DMND0010030
            if (!HideCustomFields)
            {
                SetCustomFieldEntries(actionItem.CustomFieldEntries, actionItem.CustomFields);
            }
            else
            {
                customFieldsLeftPanel.Visible = false;
                customFieldsPanel.Visible = false;
                customFieldEntriesPanel.Visible = false;
            }

            SetStatusModificationDetailData(actionItem.StatusModification);

            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            if (actionItem.Imagelist != null && actionItem.Imagelist.Count > 0)
            {
                oltDGVImage.Enabled = true;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = actionItem.Imagelist;
                oltDGVImage.ClearSelection();
            }
            else
            {
                oltDGVImage.DataSource = null;
                ImageGridVisible = false;
                ImageGridLabelVisible = false;


            }

            //actionItemImage = actionItem.Imagelist;

        }

        //DMND0010124 mangesh
        public bool CopyLastResponseEnabled
        {
            set { }
        }

        //ayman custom fields DMND0010030
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



        //ayman custom fields DMND0010030
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


        private void SetStatusModificationDetailData(ActionItemStatusModification statusModification)
        {
            if (statusModification == null)
            {
                StatusModificationUser = StringResources.NoData;
                StatusModificationDateTime = StringResources.NoData;
                PreviousStatus = StringResources.NoData;
            }
            else
            {
                StatusModificationUser = statusModification.ModifiedUser.FullNameWithUserName;
                StatusModificationDateTime = statusModification.ModifiedDateTime.ToLongDateAndTimeString();
                PreviousStatus = statusModification.PreviousStatus.ToString();
            }
        }

        private readonly DomainListView<FunctionalLocation> functionalLocationListView;



        public ActionItemDetails()
        {
            InitializeComponent();
            InitializeCustomFieldEntriesGrid();           //ayman custom fields DMND0010030
            Dock = DockStyle.Fill;
            respondButton.Click += respondButton_Click;
            detailsPanel.MouseEnter += detailsPanel_MouseEnter;
            exportAllButton.Click += exportButton_Click;
            goToDefinitionButton.Click += goToDefinitionButton_Click;
            viewAssociatedLogsButton.Click += viewAssociatedLogsButton_Click;
            previewButton.Click += previewButton_Click;
            printButton.Click += printButton_Click;
            viewGN75BFormButton.Click += viewAssociatedGn75B_Click;

            functionalLocationListView = new DomainListView<FunctionalLocation>(new DetailsFunctionalLocationRenderer(), false) { Dock = DockStyle.Fill };
            functionalLocationPanel.Controls.Add(functionalLocationListView);

            //mangesh - DMND0005327 -Request15
            viewGN75BFormButton1.Click += viewAssociatedGn75B1_Click;
            viewGN75BFormButton2.Click += viewAssociatedGn75B2_Click;

            editGN75BFormButton.Click += editAssociatedGn75B_Click;
            editGN75BFormButton1.Click += editAssociatedGn75B1_Click;
            editGN75BFormButton2.Click += editAssociatedGn75B2_Click;

            oltDGVImage.AutoGenerateColumns = false;

        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        private void detailsPanel_MouseEnter(object sender, EventArgs e)
        {
            detailsPanel.Focus();
        }

        private void respondButton_Click(object sender, EventArgs e)
        {
            if (Respond != null)
            {
                Respond(this, e);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void goToDefinitionButton_Click(object sender, EventArgs e)
        {
            if (GoToDefinition != null)
            {
                GoToDefinition(this, e);
            }
        }

        private void viewAssociatedLogsButton_Click(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs(this, e);
            }
        }

        private void previewButton_Click(object sender, EventArgs eventArgs)
        {
            if (PrintPreview != null)
            {
                PrintPreview(sender, eventArgs);
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(sender, e);
            }
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

        //mangesh- DMND0005327- Requet 15
        private void editAssociatedGn75B_Click(object sender, EventArgs e)
        {
            if (EditAssociatedGN75B != null)
            {
                EditAssociatedGN75B();
            }
        }
        //mangesh- DMND0005327- Requet 15
        private void editAssociatedGn75B1_Click(object sender, EventArgs e)
        {
            if (EditAssociatedGN75B1 != null)
            {
                EditAssociatedGN75B1();
            }
        }
        //mangesh- DMND0005327- Requet 15
        private void editAssociatedGn75B2_Click(object sender, EventArgs e)
        {
            if (EditAssociatedGN75B2 != null)
            {
                EditAssociatedGN75B2();
            }
        }

        private List<FunctionalLocation> FunctionalLocations
        {
            set
            {
                functionalLocationListView.ItemList = value ?? new List<FunctionalLocation>();
            }
        }

        private string StartDate
        {
            set { startDateData.Text = value; }
        }

        private string StartTime
        {
            set { startByData.Text = value; }
        }

        private string EndTime
        {
            set { endByData.Text = value; }
        }

        public string Name
        {
            set { nameLabelData.Text = value; }
        }

        private string Status
        {
            set { statusLabelData.Text = value; }
        }

        private string Description
        {
            set { descriptionLabelData.Text = value; }
        }

        private string Category
        {
            set { categoryData.Text = value; }
        }

        private string WorkAssignment
        {
            set { workAssignmentLabelData.Text = value; }
        }

        private string RequestedBy
        {
            set { requestedByData.Text = value; }
        }

        private List<DocumentLink> AssociatedDocumentLinks
        {
            set { documentLinksControl.DataSource = value; }
        }

        private string StatusModificationUser
        {
            set { statusModificationControl.ModificationUser = value; }
        }

        private string StatusModificationDateTime
        {
            set { statusModificationControl.ModificationDateTime = value; }
        }

        private string PreviousStatus
        {
            set { statusModificationControl.PreviousStatus = value; }
        }

        public bool RespondEnabled
        {
            set { respondButton.Enabled = value; }
        }

        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (respondButton.Enabled)
            {
                respondButton_Click(this, new EventArgs());
            }
        }

        public bool GoToDefinitionEnabled
        {
            set { goToDefinitionButton.Enabled = value; }
        }

        public bool GoToDefinitionVisible
        {
            set { goToDefinitionButton.Visible = value; }
        }

        public bool RespondVisible
        {
            set { respondButton.Visible = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { previewButton.Enabled = value; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.Visible = false;
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

        private void HideGn75BAssocation()
        {
            //formGn75BLabel.Visible = false;
            //formGn75LabelData.Visible = false;
            //viewGN75BFormButton.Visible = false;
            functionalLocationPanel.Height += gn75AssociationGroupBox.Height;
            formGn75BLabel.Visible = false;
            gn75AssociationGroupBox.Visible = false;
            gn75AssociationGroupBox.Height = 0;
            Refresh();
        }

        public long? AssociatedGn75BFormNumber
        {
            private set
            {
                viewGN75BFormButton.Enabled = value.HasValue;
                formGn75LabelData.Tag = value;
                formGn75LabelData.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                editGN75BFormButton.Enabled = value.HasValue;//mangesh - DMND0005327 - Request 15
            }
            get { return (long?)formGn75LabelData.Tag; }
        }

        //mangesh - DMND0005327 - Request 15
        public long? AssociatedGn75BFormNumber1
        {
            private set
            {
                viewGN75BFormButton1.Enabled = value.HasValue;
                formGn75LabelData1.Tag = value;
                formGn75LabelData1.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                editGN75BFormButton1.Enabled = value.HasValue;

                //if (formGn75LabelData1.Text == string.Empty) HideGn75BAssocation1();
            }
            get { return (long?)formGn75LabelData1.Tag; }
        }

        //mangesh - DMND0005327 - Request 15
        public long? AssociatedGn75BFormNumber2
        {
            private set
            {
                viewGN75BFormButton2.Enabled = value.HasValue;
                formGn75LabelData2.Tag = value;
                formGn75LabelData2.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                editGN75BFormButton2.Enabled = value.HasValue;

                //if (formGn75LabelData2.Text == string.Empty) HideGn75BAssocation2();
            }
            get { return (long?)formGn75LabelData2.Tag; }
        }
        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> actionItemImage
        {
            set { oltDGVImage.DataSource = value; }
        }

        private void oltDGVImage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (actionItem.Imagelist != null && actionItem.Imagelist.Count > 0)
            if (oltDGVImage.Columns[e.ColumnIndex].Name == "PathImage")
            {
                if (actionItem.Imagelist.Count > 0)
                {
                    try
                    {
                        e.Value = Image.FromFile(actionItem.Imagelist[e.RowIndex].ImagePath);

                        oltDGVImage.Columns[2].Width = 100;

                        for (int i = 0; i < oltDGVImage.Rows.Count; i++)
                        {
                            oltDGVImage.Rows[i].Height = 80;
                        }
                        oltDGVImage.Rows[e.RowIndex].Cells["PathImage"].ToolTipText = StringResources.ImageColumnToolTipText;
                    }
                    catch (Exception)
                    {
                        
                    }
                     
                    
                }
            }
        }

        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = 2;
            //if (oltDGVImage.CurrentCell.ColumnIndex.Equals(index) && e.RowIndex != -1)
            //    if (oltDGVImage.CurrentCell != null && oltDGVImage.CurrentCell.Value != null)

            try
            {
                if ((oltDGVImage.CurrentCell.OwningColumn).HeaderText == "Image")
                {
                    if (oltDGVImage.CurrentCell.EditedFormattedValue == string.Empty) return;

                    Bitmap img = (Bitmap)(oltDGVImage).CurrentCell.EditedFormattedValue;

                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Jpeg);

                    ImageForm frm = new ImageForm(ms);
                    frm.ShowDialog();
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

        private void oltDGVImage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }








    }
}