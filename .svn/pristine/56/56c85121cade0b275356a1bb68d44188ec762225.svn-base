using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class FormEdmontonGN75BDetails : AbstractDetails, IFormEdmontonDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event Action Clone;
        public event Func<bool> Cancel;
        public event Func<bool> Close;
        public event EventHandler Print;
        public event Action PrintPreview;
        public event Action Email; //only for implementation of the interface IFormEdmontonDetails. We don't email this form.
        public event Action DocumentLinkOpened;

        private readonly DomainListView<IsolationItem> isolationsListview;
        private readonly DomainListView<DevicePosition> devicePositionListview;   //ayman Sarnia eip DMND0008992
        private Image currentImageOriginalSized;
        private string formType = String.Empty;    //ayman Sarnia eip DMND0008992
        private string locationName = String.Empty;  //ayman Sarnia eip DMND0008992
        public FormEdmontonGN75BDetails(string formtype, string locationname)
        {
            formType = formtype;                   //ayman Sarnia eip DMND0008992
            locationName = locationname;           //ayman Sarnia eip DMND0008992
            InitializeComponent();
            mainPanel.Layout += HandleMainPanelLayout;

            isolationsListview = new DomainListView<IsolationItem>(new DetailsFormGN75BIsolationRenderer(), false) { Dock = DockStyle.Fill };
            isolationsGroupBox.Controls.Add(isolationsListview);

            //ayman Sarnia eip DMND0008992
            if (ClientSession.GetUserContext().IsSarniaSite)
            {
                devicePositionListview = new DomainListView<DevicePosition>(new DetailsFormGN75BDevicePositionRenderer(), 
                    false) {Dock = DockStyle.Fill};
                isolationsGroupBox.Controls.Add(devicePositionListview);
            }

            editButton.Click += HandleEditButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            closeButton.Click += HandleCloseButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePrintPreviewButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
            documentLinksControl.LinkOpened += HandleDocumentLinkOpened;

            expandContentLinkLabel.Click += HandleExpandContentClicked;

            if (locationname == "Work Scope")
            {
                LocationOfWork = "Work Scope";
                oltGroupBox1.Text = "Work Scope";
                blindsRequiredLabel.Visible = false;
                blindsRequiredDataLabel.Visible = false;
                lockBoxGroupBox.Visible = false;
            }


        }

        private void HandleExpandContentClicked(object sender, EventArgs e)
        {
            if (currentImageOriginalSized == null)
            {
                return;
            }

            FormGN75BSchematicForm schematicForm = new FormGN75BSchematicForm {OriginalImage = currentImageOriginalSized};
            schematicForm.ShowDialog(this);
            schematicForm.Dispose();
        }

        public bool RangeVisible
        {
            set { dateRangeButton.Visible = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool CloseEnabled
        {
            set { closeButton.Enabled = value; }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool EmailEnabled
        {
            set {  }
        }

        //ayman Sarnia eip DMND0008992
        public bool PrintPreviewButtonVisible
        {
            set { printPreviewButton.Visible = value; }
        }


        public bool PrintButtonVisible
        {
            set { printButton.Visible = value; }
        }

        public bool CloseButtonVisible
        {
            set { closeButton.Visible = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditVisible
        {
            set { editButton.Visible = value; }
        }

        private void HandleExportButtonClick(object sender, EventArgs eventArgs)
        {
            if (ExportAll != null)
            {
                ExportAll(sender, eventArgs);
            }
        }

        private void HandleDocumentLinkOpened()
        {
            if (DocumentLinkOpened != null)
            {
                DocumentLinkOpened();
            }
        }

        private void HandlePrintPreviewButtonClick(object sender, EventArgs eventArgs)
        {
            if (PrintPreview != null)
            {
                PrintPreview();
            }
        }

        private void HandlePrintButtonClick(object sender, EventArgs eventArgs)
        {
            if (Print != null)
            {
                Print(sender, eventArgs);
            }
        }

        private void HandleCloseButtonClick(object sender, EventArgs eventArgs)
        {
            if (Close != null)
            {
                Close();
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (Edit != null)
            {
                Edit(sender, eventArgs);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs eventArgs)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(sender, eventArgs);
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs eventArgs)
        {
            if (Delete != null)
            {
                Delete(sender, eventArgs);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs eventArgs)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, new EventArgs());
            }
        }

        public DateTime? CreatedDateTime
        {
            set { createdDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User CreatedByUser
        {
            set { createdByUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        public DateTime? LastModifiedDateTime
        {
            set { lastModifiedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserDataLabel.Text = value == null ? string.Empty : value.FullNameWithUserName; }
        }

        //ayman Sarnia eip DMND0008992
        public string FormNumberString
        {
            get { return formNumberDataLabel.Text; }
            set { formNumberDataLabel.Text = value == null ? string.Empty : value.ToString(CultureInfo.InvariantCulture); }
        }
        
        public long? FormNumber
        {
            set { formNumberDataLabel.Text = value == null ? string.Empty : value.Value.ToString(CultureInfo.InvariantCulture); }
        }

        public DateTime? ClosedDateTime
        {
            set { closedDateDataLabel.Text = value == null ? string.Empty : value.Value.ToLongDateAndTimeString(); }
        }

        public List<IsolationItem> Isolations
        {
            set { isolationsListview.ItemList = value ?? new List<IsolationItem>(); }
        }

        public byte[] Schematic
        {
            set
            {
                if (value == null)
                {
                    schemeticPictureBox.Image = null;
                    currentImageOriginalSized = null;
                }
                else
                {
                    currentImageOriginalSized = ConvertBytesToImage(value);
                    Rectangle imageRectangle = schemeticPictureBox.ClientRectangle;
                    Image scaledImage = FormGN75BSchematicForm.ScaleImage(currentImageOriginalSized, imageRectangle.Width, imageRectangle.Height);
                    schemeticPictureBox.Image = scaledImage;
                }
            }
        }

        private Image ConvertBytesToImage(byte[] imageBytes)
        {
            Image image;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        public string BlindsRequired
        {
            set { blindsRequiredDataLabel.Text = value; }
        }

        public string EquipmentType
        {
            set { equipmentTypeDataLabel.Text = value; }
        }

        public string LockBoxNumber
        {
            set { lockBoxNumberDataLabel.Text = value; }
        }

        public string LockBoxLocation
        {
            set { lockBoxLocationDataLabel.Text = value; }
        }

        public string FunctionalLocation
        {
            set { functionalLocationDataLabel.Text = value; }
        }

        public string LocationOfWork
        {
            set { locationDataLabel.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            set { documentLinksControl.DataSource = value ?? new List<DocumentLink>(); }
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }
        
        /*RITM0265746 - Sarnia CSD marked as read start */
        public bool MarkAsReadEnabled
        { set { } }

        public bool MarkAsReadVisible
        { set { } }
        public List<ItemReadBy> MarkedAsReadBy
        { set { } }
        public bool MarkedAsReadToggleCollaps
        { set { } }
        public event Action MarkAsRead;
        public event Action MarkedAsReadByToggled;

        
        /*RITM0265746 - Sarnia CSD marked as read End*/
        //DMND0010261-SELC CSD EdmontonPipeline
        public bool IsTheCSDForSCADAeDataLabel { get; set; }
    }
}