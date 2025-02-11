using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.Services;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ActionItemResponseForm : BaseForm, IActionItemResponseFormView
    {
        private readonly SummaryGrid<CustomField> CustomFieldGrid;        //ayman action item reading
        private DomainSummaryGrid<ActionItemResponseTracker> grid;
        private SummaryGrid<CustomFieldEntryGridRenderer.CustomFieldEntryGridAdapter> customFieldEntryGrid;
        private List<entriesText> entriesTextsForTracker;
        private CustomFieldGridRenderer gridrenderer;
        private ICustomFieldService customFieldService;                        //ayman custom fields DMND0010030  
        private List<DocumentRootUncPath> documentRoots;
        ActionItem respondTo1;
        public ActionItemResponseForm(ActionItem respondTo, ActionItemStatus[] statusList, ActionItemStatus defaultStatus)
        {
            Initialize(statusList, defaultStatus);
            InitializeGrid();
            customFieldService = ClientServiceRegistry.Instance.GetService<ICustomFieldService>();
            entriesTextsForTracker = new List<entriesText>();
            respondTo1 = respondTo;
            ActionItemResponseFormPresenter presenter = new ActionItemResponseFormPresenter(this, respondTo);
            RegisterEventHandlersOnPresenter(presenter);
        }


        public class entriesText
        {
            public CustomFieldEntry entry {get; set;}
            public string text { get; set; }

        }


        private void InitializeGrid()
        {
            var customFieldEntryGridRenderer = new CustomFieldEntryGridRenderer();
            grid = new DomainSummaryGrid<ActionItemResponseTracker>(new CustomFieldGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            grid.MaximumBands = 1;
            customFieldAreaGroupBox.Controls.Add(grid);
            gridrenderer = new CustomFieldGridRenderer();
            grid.ClickCell += CellClicked;
        }
        //Added by Mukesh for Trend
        public void CellClicked(object sender, ClickCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Header.Caption.ToUpper() == "Name".ToUpper())
                {
                    long CustomFieldId = Convert.ToInt64(e.Cell.Row.Cells[9].Value);
                    ActionItemResponseFormPresenter presenter = new ActionItemResponseFormPresenter(this, respondTo1);
                    presenter.HandleCustomFieldClick(CustomFieldId);
                }
            }
            catch(Exception ex)
            { 
                //MessageBox.Show(ex.Message); 
            }
        }
       

        private void Initialize(ActionItemStatus[] statusList, ActionItemStatus defaultStatus)
        {
            InitializeComponent();


            tableLayoutPanel.ControlThatShouldFillEmptySpace = RestTableLayoutPanel;

            //IEF Submitted status changes Start
            var userContext = ClientSession.GetUserContext();
            var list = new List<ActionItemStatus>(statusList);
            if (userContext.SiteId != 3 || !userContext.PlantIds.Contains(1100))
            {
                list.RemoveAt(4);
            }
            //IEF Submitted status changes End

            Text = StringResources.ActionItemResponseFormTitle;
            reasonCodeComboBox.DataSource = list;// statusList;
            reasonCodeComboBox.SelectedItem = defaultStatus;
            detailCommentsTextbox.ReadOnly = true;

            oltCmbImageType.SelectedIndex = 0; // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
        }

        //ayman custom fields DMND0010030

        public string GetCustomFieldEntryText(long customFieldId)
        {
            return customFieldControl.GetCustomFieldEntryText(customFieldId);
        }

        public List<ActionItemResponseTracker> GetCustomFieldEntryTextForTracker(IEnumerable<CustomField> customfields)
        {
            var griditems = grid.Items;
            List<ActionItemResponseTracker> trckrs = new List<ActionItemResponseTracker>();
            for (int i = 0; i < griditems.Count; i++)
            {
                ActionItemResponseTracker trckr = new ActionItemResponseTracker(griditems[i].ActionItemDefinitionId, griditems[i].ActionItemId, griditems[i].CustomFieldId, griditems[i].CustomFieldName, griditems[i].DisplayOrder, griditems[i].TypeId, null, null, griditems[i].Comment, griditems[i].PhdLinkTypeId, griditems[i].BatchNumber, griditems[i].FieldEntry, griditems[i].DropDownValues,griditems[i].FieldEntry);
                //Added by Mukesh to set phdlink type
                trckr.PhdLinkType = customfields.Single(C => C.Id == griditems[i].CustomFieldId).PhdLinkType;
                trckr.Type = customfields.Single(C => C.Id == griditems[i].CustomFieldId).Type;
                
                ////New
                //var item = (from x in customfields where x.Id == griditems[i].CustomFieldId select x).FirstOrDefault();
                //if (item == null)
                //{
                //    trckr.PhdLinkType = CustomFieldPhdLinkType.Off;
                //    trckr.Type = CustomFieldType.BlankSpace;
                //}
                //else
                //{
                //    trckr.PhdLinkType = customfields.Single(C => C.Id == griditems[i].CustomFieldId).PhdLinkType;
                //    trckr.Type = customfields.Single(C => C.Id == griditems[i].CustomFieldId).Type;
                //}
                ////--
               
                
                if (trckr.Type.Equals(CustomFieldType.NumericValue))
                {
                    decimal d;
                    if (trckr.FieldEntry != null && decimal.TryParse(trckr.FieldEntry, out d))
                    {
                        trckr.NumericFieldEntry = d;
                        trckr.FieldEntry = null;
                    }
                    else
                    {
                        trckr.FieldEntry = null;
                    }
                }
                //End 
                  trckrs.Add(trckr);
            }
            return trckrs;
        }

        public List<entriesText> GetEntriesTextForTracker()
        {
            return entriesTextsForTracker.Distinct().ToList();

        }



        public void SetCustomFieldPhTagAssociationControlsVisible(bool hasPhdReadCustomField, bool hasPhdWriteCustomField)
        {
            LogFormHelper.SetCustomFieldPhTagAssociationControlsVisible(customFieldPhTagLegendControl, importCustomFieldsButton, customFieldControl, customFieldsPanel,
                hasPhdReadCustomField, hasPhdWriteCustomField);
        }


        //ayman custom fields DMND0010030
        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return customFieldControl.GetCustomFieldEntryText(entry);
        }
        public void DisableControls()
        {
            ControlsEnabled = false;
        }
        public void EnableControls()
        {
            ControlsEnabled = true;
        }
        public void SetCustomFieldEntryText(CustomFieldEntry entry, String text)
        {
            customFieldControl.SetCustomFieldEntryText(entry, text);
            AddEntryTextToTracker(entry, text);
        }

        public void AddEntryTextToTracker(CustomFieldEntry entry, string text)
        {
            entriesText myentry = new entriesText();
            myentry.entry = entry;
            myentry.text = text;
            entriesTextsForTracker.Add(myentry);
        }


        public void SetCustomFieldEntryTextForReading(List<ActionItemResponseTracker> mytrckers)
        {
//            List<ActionItemResponseTracker> mytrckers = new List<ActionItemResponseTracker>();
            //List<ActionItemResponseTracker> trckrdata = customFieldService.QueryForActionItemResponseTracker(actionitemid);
            //foreach (var entry in entrieslist)
            //{
            //    CustomFieldEntry foundentry = customFields
            //    // get the data from the action item response tracker table
            //    //                List<ActionItemResponseTracker> trckrdata = new List<ActionItemResponseTracker>();  //customFieldService.QueryActionItemResponseTrackerEntryByEntryIDAndActionItemId(entry.entry.CustomFieldId.Value,actionitemid);
            //    //ActionItemResponseTracker trckr = new ActionItemResponseTracker(actionitemid, entry.entry.CustomFieldId.Value, entry.entry.CustomFieldName, entry.entry.DisplayOrder,(byte)entry.entry.Type.Id, null, null, null, (byte)entry.entry.PhdLinkType,0 , entry.text);

            //        //ActionItemResponseTracker trcker = new ActionItemResponseTracker(0, entry.entry.CustomFieldId.Value, entry.entry.CustomFieldName, entry.entry.DisplayOrder,entry.entry.NumericFieldEntry ,entry.text,"",(byte)entry.entry.PhdLinkType);
            //        mytrckers.Add(trckr);
            //}
            List<ActionItemResponseTracker> noduptrackers = mytrckers.Distinct().ToList();
            grid.Items = noduptrackers;
        }


        //ayman custom fields DMND0010030
        public void EnableCustomFieldsLabel(bool enable)
        {
            customFieldsLabelLine.Visible = enable;
        }

        //ayman action item reading
        public void EnableTableLayoutPanel(bool enable)
        {
            customFieldsPanel.Visible = enable;
            oltTableLayoutPanel1.Visible = enable;
            customFieldsLabelLine.Visible = enable;
            customFieldPhTagLegendControl.Visible = enable;
        }

        //ayman action item reading
        public void EnableCustomFieldControl(bool enable)
        {
            customFieldControl.Visible = enable;
        }

        //ayman action item reading
        public void EnableCustomFieldAreaGroupBox(bool enable)
        {
            customFieldAreaGroupBox.Visible = enable;
        }

        //ayman custom fields DMND0010030
        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries)
        {
            customFieldControl.TurnOnHighlighting(entries);
        }


        public void TurnOnCustomFieldPhTagHighlights(List<CustomFieldEntry> entries, bool reading)          //ayman action item reading
        {
            if (reading)
            {
                //                customFieldControlForReading.TurnOnHighlighting(entries);
            }
            else
            {
                customFieldControl.TurnOnHighlighting(entries);
            }
        }

        //ayman action item reading
        //public List<entriesText> TrackerEntriesList
        //{
        //    set
        //    {
        //        grid.Items = value;
        //    }
                
        //}

        //ayman action item reading
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Browsable(false)]
        public List<ActionItemResponseTracker> TrackerList
        {
            set
            {
                grid.Items = value;
            }
        }

        private bool ControlsEnabled
        {
            set
            {
                functionalLocationGroupBox.Enabled = value;
                customFieldControl.Enabled = value;
            }
        }


        private void RegisterEventHandlersOnPresenter(ActionItemResponseFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;
            submitButton.Click += presenter.HandleSubmitButtonClick;
            createLogCheckBox.CheckedChanged += presenter.HandleCreateLogCheckedChanged;
            importCustomFieldsButton.Click += presenter.HandleImportCustomFieldButtonClicked;            //ayman custom fields DMND0010030
            cancelButton.Click += presenter.HandleCancelButtonClick;
            commentOnlyCheckBox.CheckedChanged += presenter.HandleCommentOnlyCheckedChanged;
            customFieldControl.CustomFieldClicked += presenter.HandleCustomFieldClick;
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields, ActionItem respondTo)
        {
            if (!respondTo.CreatedByActionItemDefinition.Reading)
            {
                customFieldControl.SetCustomFieldEntries(customFieldEntries, customFields, false);
                customFieldControl.Visible = customFields.Count > 0;
            }
            else if(respondTo.CreatedByActionItemDefinition.Reading)
            {

                //    //get custom field entry numeric value
                //    List<CustomFieldEntry> entries = respondTo.CustomFieldEntries;
//                gridrenderer.SetCustomFieldsEntryText(customFieldEntries, customFields);
            //    customFieldControlForReading.Visible = customFields.Count > 0;
            }
        }


        //ayman action item reading
        public void CallImportCustomFields()
        {
            importCustomFieldsButton.PerformClick();
        }

        public bool CommentOnly
        {
            set { commentOnlyCheckBox.Checked = value; }
            get { return commentOnlyCheckBox.Checked; }
        }

        //ayman custom fields DMND0010030
        public List<CustomFieldEntry> customFieldEntries
        {
            get { return customFieldEntries; }
            set { customFieldEntries = value; }
        }

        public bool CreateLogChecked
        {
            get { return createLogCheckBox.Checked; }
            set { createLogCheckBox.Checked = value; }
        }

        public bool CreateLogEnabled
        {
            set { createLogCheckBox.Enabled = value; }
        }

        public bool CreateLogVisible
        {
            set { createLogCheckBox.Visible = value; }
        }

        public User Author
        {
            set { oltLastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            get { return oltLastModifiedDateAuthorHeader.LastModifiedDate; }
            set { oltLastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public string Shift
        {
            get { return shiftLabelData.Text; }
            set { shiftLabelData.Text = value; }
        }

        public SimpleDomainObject SelectedStatus
        {
            get { return reasonCodeComboBox.SelectedItem as SimpleDomainObject; }
        }

        public string Comment
        {
            get { return commentTextBox.Text; }
        }

        public string ActionItemName
        {
            set { actionItemLabelValue.Text = value; }
        }

        public string Category
        {
            set { categoryLabelValue.Text = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationListBox.FunctionalLocations = value; }
        }

        public string DetailComments
        {
            set { detailCommentsTextbox.Text = value; }
        }

        public void DisableLogCreatedWithComments()
        {
            commentTextBox.Enabled = false;
            //            EnableMakingAnOperatingEngineerLog();
        }

        public void EnableLogCreatedWithComments()
        {
            commentTextBox.Enabled = true;
            //            EnableMakingAnOperatingEngineerLog();
        }

        public void EnableOperatingEngineerLogCheckbox(bool enable)
        {
            makeLogAnOperatingEngineerCheckBox.Enabled = createLogCheckBox.Checked && enable;
        }

        public void HideOperatingEngineerLogCheckbox()
        {
            makeLogAnOperatingEngineerCheckBox.Hide();
        }

        public string OperatingEngineerLogDisplayText
        {
            set { makeLogAnOperatingEngineerCheckBox.Text = value; }
        }

        public void ShowCommentOnlyError()
        {
            errorProvider.SetError(commentOnlyCheckBox, StringResources.CommentsRequiredError);
        }

        public void ShowCommentRequiredError()
        {
            errorProvider.SetError(commentTextBox, StringResources.CommentsRequiredForCertainStatusError);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public bool ShowSaveButton
        {
            set { submitButton.Enabled = value; }
        }

        public void DisableReasonCodeDropDown()
        {
            reasonCodeComboBox.Enabled = false;
        }

        public void EnableReasonCodeDropDown()
        {
            reasonCodeComboBox.Enabled = true;
        }

        public ActionItemStatus SelectedActionItemStatus
        {
            set { reasonCodeComboBox.SelectedItem = value; }
            get { return (ActionItemStatus)reasonCodeComboBox.SelectedItem; }
        }

        public bool IsLogAnOperatingEngineeringLog
        {
            get { return makeLogAnOperatingEngineerCheckBox.Checked; }
            set { makeLogAnOperatingEngineerCheckBox.Checked = value; }
        }

        public void HideCommentOnlyCheckbox()
        {
            commentOnlyCheckBox.Visible = false;
        }

        //ayman action item rading
        public void SelectFirstCustomField()
        {
            grid.SelectFirstRow();
        }

        // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
        
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
                    LogImage Img = new LogImage();
                    Img.RecordType = LogImage.RecordTypes.Log;
                    Img.Name = txtName.Text;
                    Img.Description = txtDescription.Text;
                    Img.ImagePath = strfileName;// txtFilePath.Text;
                    Img.Id = 0;
                    Img.Action = "Insert";


                    Img.Types = LogImage.Type.Image;
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
            List<LogImage> lst = new List<LogImage>(lstimage);
            oltDGVImage.AutoGenerateColumns = false;
            oltDGVImage.DataSource = null;
            oltDGVImage.DataSource = lst;//.FindAll(A => A.Action != "Remove");
        }

        List<LogImage> lstimage = new List<LogImage>();
        public List<LogImage> ActionItemResponseImageLogdetails
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
                        lstimage[row.Index].Description = Convert.ToString(row.Cells["DescriptionActionItemDef"].Value);

                    }
                }

                return lstimage;
            }
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

        private void oltDGVImage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;
            oltDGVImage.Rows[e.RowIndex].Cells[6].Value = "Remove";
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

        public bool EnableAddButton
        {
            get { return oltbtnAdd.Enabled; }

        }

        public string FilePathText
        {
            get { return txtFilePath.Text; }

        }

        public bool EnableActionItemImagePanel
        {
            get { return oltPanel1.Enabled; }
            set { oltPanel1.Enabled = value; }
        }



       
    }
}
