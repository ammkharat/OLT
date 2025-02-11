﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraEditors.Repository;
using Microsoft.Office.Interop.Outlook;
using Action = System.Action;
using Exception = System.Exception;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class DirectiveDetails : AbstractDetails, IDirectiveDetails
    {
        private Directive directive;
        private DomainListView<FunctionalLocation> functionalLocationListView;
        private DomainListView<ItemReadBy> markedAsReadByGrid;
        private DomainListView<WorkAssignment> workAssignmentListView;
       

        public DirectiveDetails()
        {
            InitializeComponent();
            InitializeWorkAssignmentList();
            InitializeFunctionalLocationsList();

            expireButton.Click += HandleExpireButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            editButton.Click += HandleEditButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            printButton.Click += HandlePrint;
            printPreviewButton.Click += HandlePrintPreviewButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;
            expandLinkLabel.Click += HandleExpandClicked;
            markedAsReadToggleButton.Toggled += HandleMarkedAsReadButtonToggled;
            detailsPanel.Layout += HandleDetailsPanelLayout;
            markAsReadButton.Click += (sender, args) => MarkAsRead();
            exportAllButton.Click += HandleExportButtonClick;
            markasnotreadButton.Click +=(sender, args) => MarkAsNotRead();//Added by ppanigrahi
            oltDGVImage.AutoGenerateColumns = false;

        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        public bool PrintAndPrintPreviewEnabled
        {
            set
            {
                printButton.Enabled = value;
                printPreviewButton.Enabled = value;
            }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveLayoutToolStripButton; }
        }

        public event EventHandler Expire;
        public event EventHandler Clone;
        public event EventHandler ExportAll;
        public event EventHandler Delete;
        public event EventHandler Edit;
        public event EventHandler Print;
        public event EventHandler Preview;
        public event EventHandler ViewEditHistory;
        public event Action MarkAsRead;
        public event Action MarkAsNotRead;//Added by ppanigrahi;

        public event Action<Directive> MarkedAsReadByToggled;

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, EventArgs.Empty);
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
            set { historyButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public bool ExpireEnabled
        {
            set { expireButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public List<ItemReadBy> MarkedAsReadBy
        {
            set { markedAsReadByGrid.ItemList = value; }
        }

        public List<ItemReadBy> MarkedAsReadByUser { get; set; }

        public bool MarkAsReadEnabled
        {
            set { markAsReadButton.Enabled = value; }
        }

        public bool MarkAsReadVisible
        {
            set { markAsReadButton.Visible = value; }
        }

        public bool PrintButtonVisible
        {
            set { printButton.Visible = value; }
        }

        //Added by ppanigrahi
        public bool MarkAsNotReadEnabled
        {

            set { markasnotreadButton.Enabled = value; }
        }

        public bool MarkAsNotReadVisible
        {
            set { markasnotreadButton.Visible = value; }
        } 

        public void SetDetails(Directive directive)
        {
            this.directive = directive;

            SetMarkedAsReadToDefault();

            if (directive == null)
            {
                createdByAuthorDataLabel.Text = string.Empty;
                createdByDateDataLabel.Text = string.Empty;
                lastModifiedAuthorDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;

                workAssignmentListView.ItemList = new List<WorkAssignment>();
                functionalLocationListView.ItemList = new List<FunctionalLocation>();
                activeFromDateDataLabel.Text = string.Empty;
                activeToDateDataLabel.Text = string.Empty;
                contentRichTextDisplay.Text = string.Empty;

                documentLinksControl.DataSource = new List<DocumentLink>();

                extraInfoGroupBox.Visible = false;
            }
            else
            {
                createdByAuthorDataLabel.Text = directive.CreatedBy.FullNameWithUserName;
                createdByDateDataLabel.Text = directive.CreatedDateTime.ToShortDateAndTimeString();
                lastModifiedAuthorDataLabel.Text = directive.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = directive.LastModifiedDateTime.ToShortDateAndTimeString();

                workAssignmentListView.ItemList = directive.WorkAssignments;
                functionalLocationListView.ItemList = directive.FunctionalLocations;
                activeFromDateDataLabel.Text = directive.ActiveFromDateTime.ToShortDateAndTimeString();
                activeToDateDataLabel.Text = directive.ActiveToDateTime.ToShortDateAndTimeString();
                contentRichTextDisplay.Text = directive.Content;

                documentLinksControl.DataSource = directive.DocumentLinks;

                extraInfoGroupBox.Visible = directive.ExtraInfoFromMigrationSource != null;
                extraInfoTextBox.Text = directive.ExtraInfoFromMigrationSource;
            }


            //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            if (directive.Imagelist != null && directive.Imagelist.Count > 0)
            {
                //oltDGVImage.Visible = true;
                EnableDetailImagePanel = true;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = directive.Imagelist;
                directiveImage = directive.Imagelist; //vibhor
                oltDGVImage.ClearSelection();

            }
            else
            {
                //oltDGVImage.Visible = false;
                directiveImage = null;
                EnableDetailImagePanel = false;

            }

            

        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        private void HandleExportButtonClick(object sender, EventArgs eventArgs)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, eventArgs);
            }
        }

        private void HandleMarkedAsReadButtonToggled(bool expanded)
        {
            if (expanded && markedAsReadByGrid == null)
            {
                markedAsReadByGrid = new DomainListView<ItemReadBy>(new LogReadByListViewRenderer(), false)
                {
                    Dock = DockStyle.Fill
                };
                markedAsReadByPanel.Controls.Add(markedAsReadByGrid);
                markedAsReadByPanel.Visible = true;
                MarkedAsReadByToggled(directive);
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

        private void SetMarkedAsReadToDefault()
        {
            if (markedAsReadToggleButton.Expanded)
            {
                markedAsReadToggleButton.Expanded = false;
            }
            markedAsReadByPanel.Controls.Remove(markedAsReadByGrid);
            markedAsReadByGrid = null;
            markedAsReadByPanel.Visible = false;
        }

        private void HandleExpandClicked(object sender, EventArgs e)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(contentRichTextDisplay.Text, true);
            expandedLogCommentForm.ShowDialog(this);
        }

        private void HandleEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (Edit != null)
            {
                Edit(sender, eventArgs);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender, EventArgs.Empty);
            }
        }

        private void HandleExpireButtonClick(object sender, EventArgs e)
        {
            if (Expire != null)
            {
                Expire(sender, EventArgs.Empty);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(sender, EventArgs.Empty);
            }
        }

        private void HandleDetailsPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(null, EventArgs.Empty);
            }
        }

        private void HandlePrint(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(null, EventArgs.Empty);
            }
        }

        private void HandlePrintPreviewButtonClicked(object sender, EventArgs e)
        {

            if (Preview != null)
            {
                Preview(null, EventArgs.Empty);
            }
        }

        private void InitializeWorkAssignmentList()
        {
            workAssignmentListView = new DomainListView<WorkAssignment>(new DetailsWorkAssignmentRenderer(), false);
            workAssignmentListView.Dock = DockStyle.Fill;
            workAssignmentGroupBox.Controls.Add(workAssignmentListView);
        }

        private void InitializeFunctionalLocationsList()
        {
            functionalLocationListView = new DomainListView<FunctionalLocation>(
                new DetailsFunctionalLocationRenderer(), false) {Dock = DockStyle.Fill};
            functionalLocationsGroupBox.Controls.Add(functionalLocationListView);
        }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> directiveImage
        {
            set { oltDGVImage.DataSource = value; }
        }
        public bool EnableDetailImagePanel
        {
            get { return oltDGVImage.Enabled; }
            set
            {
                oltDGVImage.Enabled = true;
                if (!value)
                {
                    oltDGVImage.BackgroundColor = Color.LightGray;

                }
            }
        }

        private void oltDGVImage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
            try
            {
                if (oltDGVImage.Columns[e.ColumnIndex].Name == "PathImage")
                {

                    if (directive.Imagelist.Count > 0)
                    {
                        e.Value = Image.FromFile(directive.Imagelist[e.RowIndex].ImagePath);

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


//END
    }
}