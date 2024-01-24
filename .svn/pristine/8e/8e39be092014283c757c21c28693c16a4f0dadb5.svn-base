using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DirectiveForm : BaseForm, IDirectiveFormView
    {
        private readonly IAssignmentMultiSelectFormView assignmentMultiSelectForm;
        private IMultiSelectFunctionalLocationSelectionForm flocSelector;
        private List<DocumentRootUncPath> documentRoots;

        public DirectiveForm()
        {
            InitializeComponent();
            if (Culture.IsFrench)
            {
                activeFromDatePicker.CustomFormat = "ddd yyyy-MM-dd";
                activeToDatePicker.CustomFormat = "ddd yyyy-MM-dd";
            }
            assignmentMultiSelectForm = new AssignmentMultiSelectForm(true);

            addFunctionalLocationButton.Click += (sender, args) => AddFunctionalLocationButtonClicked();
            removeFunctionalLocationButton.Click += (sender, args) => RemoveFunctionalLocationButtonClicked();

            cancelButton.Click += (sender, args) => CancelButtonClicked(null, EventArgs.Empty);
            saveAndCloseButton.Click += (sender, args) => SaveButtonClicked(null, EventArgs.Empty);
            insertTemplateButton.Click += (sender, args) => HandleLogTemplateButtonClick();
            addWorkAssignmentButton.Click += (sender, args) => AddRemoveWorkAssignmentButtonClicked();
            expandLinkLabel.Click += HandleExplandLinkLabelClick;
            historyButton.Click += (sender, args) => HistoryButtonClicked();
            oltCmbImageType.SelectedIndex = 0;
        }

        public IMultiSelectFunctionalLocationSelectionForm FlocSelector
        {
            set { flocSelector = value; }
        }

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action HandleLogTemplateButtonClick;
        public event Action AddFunctionalLocationButtonClicked;
        public event Action RemoveFunctionalLocationButtonClicked;
        public event Action AddRemoveWorkAssignmentButtonClicked;
        public event Action HistoryButtonClicked;

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = new List<FunctionalLocation>(value); }
            get { return functionalLocationListBox.FunctionalLocations; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationListBox.SelectedFunctionalLocation; }
        }

        public DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(
            List<FunctionalLocation> flocSelections)
        {
            var dialogResult = flocSelector.ShowDialog(this, flocSelections);

            var selectedFunctionalLocations = flocSelector.UserSelectedFunctionalLocations;
            return new DialogResultAndOutput<List<FunctionalLocation>>(dialogResult,
                new List<FunctionalLocation>(selectedFunctionalLocations));
        }

        public DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(
            List<WorkAssignment> selectedAssignments)
        {
            assignmentMultiSelectForm.ShowMultiSelectDialog(selectedAssignments);
            var result = new DialogResultAndOutput<IList<WorkAssignment>>(assignmentMultiSelectForm.DialogResult,
                assignmentMultiSelectForm.SelectedAssignments);

            return result;
        }

        public DateTime ActiveFromDateTime
        {
            get
            {
                var theDate = activeFromDatePicker.Value;
                return theDate.CreateDateTime(activeFromTimePicker.Value);
            }
            set
            {
                activeFromDatePicker.Value = new Date(value);
                activeFromTimePicker.Value = new Time(value);
            }
        }

        public DateTime ActiveToDateTime
        {
            get
            {
                var theDate = activeToDatePicker.Value;
                return theDate.CreateDateTime(activeToTimePicker.Value);
            }
            set
            {
                activeToDatePicker.Value = new Date(value);
                activeToTimePicker.Value = new Time(value);
            }
        }

        public string Content
        {
            get { return contentRichTextEditor.Text; }
            set { contentRichTextEditor.Text = value; }
        }

        public User LastModifiedBy
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public User CreatedBy
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime CreatedDateTime
        {
            set { createdDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public string PlainTextContent
        {
            get { return contentRichTextEditor.PlainText; }
        }

        public string ExtraInfoFromMigrationSource
        {
            set { extraInfoTextBox.Text = value; }
        }

        public void HideExtraInfo()
        {
            var row = contentAndExtraInfoTableLayoutPanel.GetRow(extraInfoGroupBox);
            contentAndExtraInfoTableLayoutPanel.RowStyles[row].Height = 0;
        }

        public List<WorkAssignment> SelectedWorkAssignments
        {
            get { return (List<WorkAssignment>) workAssignmentBindingSource.DataSource; }
            set { workAssignmentBindingSource.DataSource = value; }
        }

        public void SetErrorForActiveFromMustBeBeforeActiveTo()
        {
            errorProvider.SetError(activeToTimePicker, StringResources.ActiveToBeforeActiveFrom);
        }

        public void SetErrorForEmptyContent()
        {
            errorProvider.SetError(contentAndExtraInfoTableLayoutPanel, StringResources.DescriptionEmptyError);
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationListBox, StringResources.FlocEmptyError);
        }

        public void SetLogTemplates(List<LogTemplateDTO> logTemplates)
        {
            logTemplateComboBox.Items.Clear();

            foreach (var logTemplate in logTemplates)
            {
                logTemplateComboBox.Items.Add(logTemplate);
            }
        }

        public LogTemplateDTO SelectedLogTemplate
        {
            get { return (LogTemplateDTO) logTemplateComboBox.SelectedItem; }
            set { logTemplateComboBox.SelectedItem = value; }
        }

        public void ApplyLogTemplateText(string text)
        {
            contentRichTextEditor.AppendText(text);
        }

        public void HideLogTemplateComponent()
        {
            templatePanel.Visible = false;
        }

        public void ShowLogTemplateComponent()
        {
            templatePanel.Visible = true;
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public string WindowTitleText
        {
            set { Text = value; }
        }

        private void HandleExplandLinkLabelClick(object sender, EventArgs e)
        {
            var expandedLogCommentForm = new ExpandedLogCommentForm(contentRichTextEditor.Text, false);
            expandedLogCommentForm.ShowDialog(this);
            contentRichTextEditor.Text = expandedLogCommentForm.TextEditorText;
        }
//RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        List<ImageUploader> lstimage = new List<ImageUploader>();
        public List<ImageUploader> ImageDirectivedetails
        {
            set
            {

                lstimage = value;
                oltDGVImage.AutoGenerateColumns = false;
                oltDGVImage.DataSource = null;
                oltDGVImage.DataSource = value;
            }
            get
            {
                foreach (DataGridViewRow row in oltDGVImage.Rows)
                {
                    if (row.Index > 0)
                    {
                        lstimage[row.Index].Name = Convert.ToString(row.Cells["ImageName"].Value);
                        lstimage[row.Index].Description = Convert.ToString(row.Cells["DescriptionDirective"].Value);
                    }
                }

                return lstimage;
            }
        }

        private void oltbtnbrowse_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //txtFilePath.Text = openFileDialog1.FileName;

            //Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form
            AddNewDocumentLinkFormPresenter doc = new AddNewDocumentLinkFormPresenter(ClientServiceRegistry.Instance.GetService<IDocumentLinkService>());
            documentRoots = doc.GetFlocData();

            if (documentRoots.Count == 1)
                DisplayFileBrowser(documentRoots[0]);
            else
            {
                DocumentRootUncPath selectedDocumentRoot = DisplayRootSelector();

                if (selectedDocumentRoot != null)
                    DisplayFileBrowser(selectedDocumentRoot);
            }
            //END

        }

        //Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form
        #region Added by Vibhor : RITM0502408 - Browse option for images similar to Add document form

        private void SelectFile(DocumentRootUncPath uncPath)
        {
            string path = uncPath.Path;

            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
                openFileDialog1.Title = string.Format(StringResources.AddDocumentLinkFileDialogTitle, uncPath.PathName);
            }

            DialogResult dialogResult = openFileDialog1.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                documentLink = fileName;
            }

        }

        public string documentLink
        {
            get
            {
                return txtFilePath.Text;
            }
            private set { txtFilePath.Text = value; }
        }

        public DocumentRootUncPath DisplayRootSelector()
        {
            DocumentRootSelectionForm form = new DocumentRootSelectionForm { StartPosition = FormStartPosition.CenterParent };
            DialogResult dialogResult = form.ShowDialog(this);

            return dialogResult == DialogResult.OK ? form.SelectedItem : null;
        }

        private void DisplayFileBrowser(DocumentRootUncPath uncPath)
        {
            SelectFile(uncPath);
        }

        #endregion

        private void oltbtnAdd_Click(object sender, EventArgs e)
        {
            errorProviderImage.Clear();
            if (oltCmbImageType.Text.ToUpper() == "IMAGE")
            {
                foreach (string strfileName in openFileDialog1.FileNames)
                {
                    ImageUploader Img = new ImageUploader();
                    Img.RecordType = ImageUploader.RecordTypes.Directive;
                    Img.Name = txtName.Text;
                    Img.Description = txtDescription.Text;
                    Img.ImagePath = strfileName;// txtFilePath.Text;


                    //if (File.Exists(strfileName))
                    //{

                    //}

                    //Img.BitImage = 
                    Img.Id = 0;
                    Img.Action = "Insert";


                    Img.Types = ImageUploader.Type.Image;
                    if (!File.Exists(txtFilePath.Text))
                    {
                        errorProviderImage.SetError(txtFilePath, "File not exists");
                        return;
                    }


                    lstimage.Add(Img);
                }
            }

            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            txtFilePath.Text = string.Empty;
            oltCmbImageType.SelectedIndex = 0;
            List<ImageUploader> lst = new List<ImageUploader>(lstimage);
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = null;
            oltDGVImage.DataSource = lst;//.FindAll(A => A.Action != "Remove");

        }

        private void oltCmbImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oltCmbImageType.Text == "")
            {
                oltbtnAdd.Enabled = false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }
            if (txtFilePath.Text == "")
            {
                oltbtnAdd.Enabled = false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }
            
            if (oltCmbImageType.Text.ToUpper() == "Image".ToUpper())
            {
                txtFilePath.Enabled = true;
                oltbtnbrowse.Enabled = true;
                txtDescription.Enabled = true;
            }
            else
            {
                txtFilePath.Text = string.Empty;
                txtFilePath.Enabled = false;
                oltbtnbrowse.Enabled = false;
                txtDescription.Enabled = false;
                txtDescription.Text = string.Empty;

            }
        }
        
        public bool setDirectiveImage
        {
            set
            {
                oltLabelDirectiveImagesTitle.Visible = value;
                oltLabelDirectiveImagesTitle.Visible = value;

            }

        }

        private void oltDGVImage_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";

        }

        public bool EnableImagePanel
        {
            get { return oltDGVImage.Enabled; }
            set { oltDGVImage.Enabled = value; }
        }

        public bool EnableImagePanelDirective
        {
            get { return oltTableLayoutPanelActionItemDef.Enabled; }
            set { oltTableLayoutPanelActionItemDef.Enabled = value; }
        }

         public bool EnableImagePanelDirectiveTitle
        {
            get { return oltLabelDirectiveImagesTitle.Enabled; }
            set { oltLabelDirectiveImagesTitle.Enabled = value; }
        }

         public bool EnableAddButton
         {
             get { return oltbtnAdd.Enabled; }
             
         }
         public string FilePathText
         {
             get { return txtFilePath.Text; }

         }
        

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                oltbtnAdd.Enabled = false;
            }
            else
            {
                oltbtnAdd.Enabled = true;
            }
        }

        public void SetErrorForAddButton()
        {
            errorProviderImage.SetError(oltTableLayoutPanelActionItemDef, "Please Click on ADD Button to Save the Images");
        }

    }
}