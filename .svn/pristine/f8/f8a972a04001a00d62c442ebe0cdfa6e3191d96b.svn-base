using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Client.Services;
using Infragistics.Win;
//using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormGN75BSarniaForm : BaseForm, IFormGN75BSarniaView
    {
        private const string TypeOfIsolationColumnKey = "TypeOfIsolation";
        private const string TypeOfIsolationValueListKey = "TypeOfIsolationValueList";
        private readonly IFunctionalLocationService flocService;
        public event Action FormLoad;
        public event EventHandler SaveButtonClicked;
        public event EventHandler WaitingApprovalClicked;             //ayman Sarnia eip DMND0008992
        public event Action selectFormGN75BTemplateButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action AddIsolationButtonClicked;
        public event Action InsertIsolationButtonClicked;
        public event Action RemoveIsolationButtonClicked;
        public event Action BrowseFunctionalLocationButtonClicked;
        public event Action BrowseSchematicButtonClicked;
        public event Action ViewGN75BFormButtonClicked;               //ayman Sarnia eip DMND0008992
        public event Action RemoveGN75BButtonClicked;                  //ayman Sarnia eip DMND0008992
        public event Action ClearSchematicButtonClicked;
        public event Action ViewSchemeticButtonClicked;
        public event Action DocumentLinkOpened;
        public event Action DocumentLinkAdded;

        public event Action GeneralWorkTextChanged;                   //ayman Sarnia eip DMND0008992


        //ayman Sarnia eip DMND0008992
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        public void ClearSchematic()
        {
            //pictureBox1.Image = null;
            //pictureBox1.Invalidate();
        }

        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;

        public FormGN75BSarniaForm()
        {
            InitializeComponent();
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            flocService = clientServiceRegistry.GetService<IFunctionalLocationService>();     //ayman Sarnia eip DMND0008992
            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(
                userContext.SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection));
            selectFormGN75BTemplateButton.Click += HandleSelectFormGN75BTemplateClicked;
            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;
            viewGN75BFormButton.Click += HandleViewGN75BFormButtonClick;          //ayman Sarnia eip DMND0008992
            removeFormGN75BButton.Click += HandleRemoveFormGN75BButtonClick;      //ayman Sarnia eip DMND0008992
            documentLinksControl.LinkOpened += HandleDocumentLinkOpened;
            documentLinksControl.LinkAdded += HandleDocumentLinkAdded;
            GeneralWorkTextBox.Enabled = false;
            functionallocationtextbox.Enabled = false;
            flocdesc.Enabled = false;
            approvalsGridControl.ApprovalSelected += HandleApprovalSelected;
            approvalsGridControl.ApprovalUnselected += HandleApprovalUnselected;

            GeneralWorkTextBox.TextChanged += HandleGeneralWorkTextChanged;                 //ayman Sarnia eip DMND0008992
            formGn75bTextBox.TextChanged += HandleGN75BFormNumberTextBoxTextChanged;
        }

        //ayman Sarnia eip DMND0008992
        public long? formgn75bTemplateId
        {
            get
            {
                return (long?)formGn75bTextBox.Tag;
            }
            set
            {
                if (value == 0)
                {
                    formGn75bTextBox.Text = string.Empty;
                }
                else
                {
                    formGn75bTextBox.Text = value.HasValue ? value.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;
                }
                formGn75bTextBox.Tag = value;
                EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
            }
        }



        //ayman Sarnia eip DMND0008992
        public string flocs
        {
            get { return functionallocationtextbox.Text; }
            set { functionallocationtextbox.Text = value; }
        }

        //ayman Sarnia eip DMND0008992
        public string GeneralWorkText
        {
            get { return GeneralWorkTextBox.Text; }
            set { GeneralWorkTextBox.Text = value; }
        }


        //ayman Sarnia eip - 2
        public void ApprovalGridEnabled(bool enabled)
        {
            approvalsGridControl.Enabled = enabled;
        }



        //ayman Sarnia eip DMND0008992
        public bool ApprovalsChecked
        {
            get { return approvalsGridControl.Enabled; }
            set { approvalsGridControl.Enabled = value; }
        }

        public string FlocDesc
        {
            get { return flocdesc.Text; }
            set { flocdesc.Text = value; }
        }

        private void HandleDocumentLinkAdded()
        {
            if (DocumentLinkAdded != null)
            {
                DocumentLinkAdded();
            }
        }

        private void HandleDocumentLinkOpened()
        {
            if (DocumentLinkOpened != null)
            {
                DocumentLinkOpened();
            }
        }

        //ayman Sarnia eip DMND0008992
        public void DisableAllControls()
        {
        }

        private void HandleViewSchemeticButtonClick(object sender, EventArgs e)
        {
            if (ViewSchemeticButtonClicked != null)
            {
                ViewSchemeticButtonClicked();
            }
        }

        private void HandleClearSchemeticButtonClick(object sender, EventArgs e)
        {
            if (ClearSchematicButtonClicked != null)
            {
                ClearSchematicButtonClicked();
            }
        }

        //ayman Sarnia eip DMND0008992
        protected virtual List<string> RemainingApprovals()
        {
            var remainingApprovals =
                Approvals.ConvertAll(approval => approval.IsApproved || !approval.Enabled ? null : approval.Approver);
            remainingApprovals.RemoveAll(approvalString => approvalString == null);
            return remainingApprovals;
        }

        private void HandleApprovalUnselected(FormApproval formApproval)
        {
            if (ApprovalUnselected != null)
            {
                ApprovalUnselected(formApproval);
            }
        }

        private void HandleGeneralWorkTextChanged(object sender, EventArgs e)
        {
            if (GeneralWorkTextChanged != null)
            {
                GeneralWorkTextChanged();
            }
        }

        private void HandleGN75BFormNumberTextBoxTextChanged(object sender, EventArgs e)
        {
            EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
        }

        public void Makecheckboxesnochoice()
        {
            blankingrequiredno.Checked = false;
            blankingrequiredyes.Checked = false;
            ImplementingYes.Checked = false;
            ImplementingNo.Checked = false;
            deadlegyes.Checked = false;
            deadlegno.Checked = false;         //ayman Sarnia eip - 2
        }

        public void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet()    //ayman Sarnia eip
        {
            removeFormGN75BButton.Enabled = !(formGn75bTextBox.Text.IsNullOrEmptyOrWhitespace() || formGn75bTextBox.Text.TrimAndEqual("0"));
            viewGN75BFormButton.Enabled = !(formGn75bTextBox.Text.IsNullOrEmptyOrWhitespace() || formGn75bTextBox.Text.TrimAndEqual("0"));
            saveButton.Enabled = !(formGn75bTextBox.Text.IsNullOrEmptyOrWhitespace() || formGn75bTextBox.Text.TrimAndEqual("0"));
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
            if (ApprovalSelected != null)
            {
                ApprovalSelected(formApproval);
            }
        }


        private void HandleSchematicButtonClick(object sender, EventArgs e)
        {
            if (BrowseSchematicButtonClicked != null)
            {
                BrowseSchematicButtonClicked();
            }
        }

        private void HandleRemoveIsolationButtonClicked(object sender, EventArgs e)
        {
            if (RemoveIsolationButtonClicked != null)
            {
                RemoveIsolationButtonClicked();
            }
        }

        private void HandleInsertIsolationButtonClicked(object sender, EventArgs e)
        {
            //if (InsertIsolationButtonClicked != null)
            //{
            //    InsertIsolationButtonClicked();
            //}
        }


        private void HandleAddIsolationButtonClicked(object sender, EventArgs e)
        {
            if (AddIsolationButtonClicked != null)
            {
                AddIsolationButtonClicked();
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (HistoryButtonClicked != null)
            {
                HistoryButtonClicked();
            }
        }


        //ayman Sarnia eip DMND0008992
        private void HandleViewGN75BFormButtonClick(object sender, EventArgs e)
        {
            if (ViewGN75BFormButtonClicked != null)
            {
                ViewGN75BFormButtonClicked();
            }
        }

        //ayman Sarnia eip DMND0008992
        private void HandleRemoveFormGN75BButtonClick(object sender, EventArgs e)
        {
            if (RemoveGN75BButtonClicked != null)
            {
                RemoveGN75BButtonClicked();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //isolationGrid.DataSource = new List<FormGN75BIsolationItemDisplayAdapter>();
            if (FormLoad != null)
            {
                FormLoad();
            }
            EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            if (IsolationItems != null)     //ayman Sarnia eip DMND0008992
            {
                IsolationItems.ForEach(item => item.ClearErrors());
            }
            MakeIsolationGridValidationIconsShowOrDisappear();
        }


        public void MakeIsolationGridValidationIconsShowOrDisappear()
        {
            //isolationGrid.Rows.Refresh(RefreshRow.FireInitializeRow);
        }





        //public List<FormGN75BIsolationItemDisplayAdapter> IsolationItems()
        //{
        //    return null;
        //}

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public User CreatedByUser
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> Approvals
        {
            set { approvalsGridControl.Items = value.ConvertAll(approval => new FormApprovalGridDisplayAdapter(approval)); }
            get
            {
                List<FormApprovalGridDisplayAdapter> list = new List<FormApprovalGridDisplayAdapter>(approvalsGridControl.Items);
                return list.ConvertAll(adapter => adapter.GetApproval());
            }
        }

        //ayman Sarnia eip DMND0008992
        public List<FormApproval> EnabledApprovals
        {
            get { return Approvals.FindAll(a => a.Enabled); }
        }

        public DateTime CreatedDateTime
        {
            set {
                createdDateLabel.Text = value.ToLongDateAndTimeString();
                StartDateLabel.Text = value.ToLongDateAndTimeString();
            }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public string LocationOfWork            //ayman Sarnia eip DMND0008992
        {
            get { return GeneralWorkTextBox.Text; }
            set
            {
                GeneralWorkTextBox.Text = value;
            }
        }


        public string SpecialPrecautions            //ayman Sarnia eip DMND0008992
        {
            get { return SpecialPrecautionsTextBox.Text; }
            set
            {
                SpecialPrecautionsTextBox.Text = value;
            }
        }


        public List<FormGN75BIsolationItemDisplayAdapter> IsolationItems
        {
            get { return null; //(List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource;
            }

            set
            {
                object dum;
                dum = value; //isolationGrid.DataSource = value;
                //isolationGrid.ResetBindings();
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get
            {
                if (functionallocationtextbox.Tag == null)
                {
                    return flocService.QueryByFullHierarchy(flocs, ClientSession.GetUserContext().SiteId);
                }
                return functionallocationtextbox.Tag as FunctionalLocation; 
            }


            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionallocationtextbox, value.Description);
                    functionallocationtextbox.Text = value.FullHierarchyWithDescription;
                    functionallocationtextbox.Tag = value;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionallocationtextbox.Text = string.Empty;
                    functionallocationtextbox.Tag = null;
                }
            }
        }

        public Image Schematic
        {
            set
            {
                //Image scaledImage = FormGN75BSchematicForm.ScaleImage(value, pictureBox1.Width, pictureBox1.Height);
                //pictureBox1.Image = scaledImage;
            }
        }

        public bool? BlindsRequired
        {
            get
            {
                if (blankingrequiredyes.Checked)
                {
                    return true;
                }
                if (blankingrequiredno.Checked)
                {
                    return false;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    blankingrequiredyes.Checked = value.Value;
                    blankingrequiredno.Checked = !value.Value;
                }
                else
                {
                    blankingrequiredyes.Checked = false;
                    blankingrequiredno.Checked = false;
                }
            }
        }


        //ayman Sarnia eip DMND0008992
        public bool? DeadLeg
        {
            get
            {
                if (ImplementingYes.Checked)
                {
                    return true;
                }
                if (ImplementingNo.Checked)
                {
                    return false;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    ImplementingYes.Checked = value.Value;
                    ImplementingNo.Checked = !value.Value;
                }
                else
                {
                    ImplementingYes.Checked = false;
                    ImplementingNo.Checked = false;
                }
            }
        }



        //ayman Sarnia eip - 2
        public bool? DeadLegRisk
        {
            get
            {
                if (deadlegyes.Checked)
                {
                    return true;
                }
                if (deadlegno.Checked)
                {
                    return false;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    deadlegyes.Checked = value.Value;
                    deadlegno.Checked = !value.Value;
                }
                else
                {
                    deadlegyes.Checked = false;
                    deadlegno.Checked = false;
                }
            }
        }




        public string EquipmentType
        {
        
            get { return null; }
            set
            {
                string dummy;
                dummy = value;
            }
        }

        //public string LockBoxNumber
        //{
        //    get { return lockBoxNumber.Text; }
        //    set { lockBoxNumber.Text = value; }
        //}

        //public string LockBoxLocation
        //{
        //    get { return lockBoxLocation.Text; }
        //    set { lockBoxLocation.Text = value; }
        //}

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector()
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this);

            FunctionalLocation selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
            return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        }

        //ayman Sarnia eip DMND0008992
        //public DialogResultAndOutput<FormGN75B> ShowFormGN75BTemplates()
        //{
        //    DialogResult dialogResult = flocSelector.ShowDialog(this);

        //    FunctionalLocation selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
        //    return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        //}

        public void SetErrorForNoBlindsSelected()
        {
            errorProvider.SetError(blankingrequiredyes, StringResources.FormGN75B_Error_BlindsRequired);
            errorProvider.SetError(blankingrequiredno, StringResources.FormGN75B_Error_BlindsRequired);
        }

        public void SetErrorForNoLocationOfWork()
        {
        }

        public void SetErrorForNoDeadLegSelected()
        {
            errorProvider.SetError(ImplementingYes, "It is Required");
            errorProvider.SetError(ImplementingNo, "It is Required");
        }

        public void SetErrorForNoDeadLegRiskSelected()                 //ayman Sarnia eip - 2
        {
            errorProvider.SetError(deadlegyes, "It is Required");
            errorProvider.SetError(deadlegno, "It is Required");
        }

        public void SetErrorForNoEquipmentType()
        {
            //errorProvider.SetError(equipmentTypeComboBox, StringResources.FormGN75B_Error_EquipmentTypeRequired);
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionallocationtextbox, StringResources.FlocEmptyError);
        }

        //Aarti INC0548411 
        public void SetErrorForIsolationGrid()
        {
           // errorProvider.SetError(isolationGrid, StringResources.FlocEmptyError);
        }

        private void HandleSelectFormGN75BTemplateClicked(object sender, EventArgs e)
        {
            if (selectFormGN75BTemplateButtonClicked != null)
            {
                selectFormGN75BTemplateButtonClicked();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        //ayman Sarnia eip DMND0008992
        private void HandleWaitingApprovalClicked(object sender, EventArgs eventArgs)
        {
            if (WaitingApprovalClicked != null)
            {
                WaitingApprovalClicked(sender, eventArgs);
            }
        }

        private void HandleCancelButtonClicked(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked(object sender, EventArgs eventArgs)
        {
            if (BrowseFunctionalLocationButtonClicked != null)
            {
                BrowseFunctionalLocationButtonClicked();
            }
        }

        public List<string> IsolationItemsDropdownList
        {
            set
            {
                ValueList valueList = null; // (ValueList)isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList ??
            //                          isolationGrid.DisplayLayout.ValueLists.Add(TypeOfIsolationValueListKey);

            //    valueList.ValueListItems.Clear();
            //    foreach (string isolationType in value)
            //    {
            //        valueList.ValueListItems.Add(isolationType);
            //    }

            //    isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList = valueList;
            
            }
            
        }

        public List<string> EquipmentTypesDropdownList
        {
            set
            {
            //    equipmentTypeComboBox.DataSource = value;
            }
        }

        public void InsertIsolationBeforeSelectedItem(FormGN75BIsolationItemDisplayAdapter item)
        {
            //int indexOfSelectedItem = isolationGrid.ActiveRow.Index;
            //// need to re-order items
            //List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource);
            //items.Insert(indexOfSelectedItem, item);

            //isolationGrid.DataSource = items;
            //isolationGrid.ResetBindings();
            //isolationGrid.ActiveItemByReference = item;
        }

        //ayman Sarnia eip DMND0008992
        public List<string> DevicePositionItemsDropdownList
        {
            set { ValueList valueList = null; }
        }


        //ayman Sarnia eip DMND0008992
        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }


        public void AddIsolationItem(FormGN75BIsolationItemDisplayAdapter item)
        {
        //    List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource)
        //    {
        //        item
        //    };
        //    isolationGrid.DataSource = items;
        //    isolationGrid.ResetBindings();
        //    isolationGrid.ActiveItemByReference = item;
       }

        public void RemoveSelectedIsolationItem()
        {
            //List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource);

            //FormGN75BIsolationItemDisplayAdapter activeItem = (FormGN75BIsolationItemDisplayAdapter)isolationGrid.ActiveItem;

            //if (activeItem != null)
            //{
            //    items.Remove(activeItem);
            //    isolationGrid.DataSource = items;

            //    isolationGrid.ResetBindings();
            //}
        }

        //ayman Sarnia eip DMND0008992
        public void DisplayDuplicateGN75BMessage(string value)
        {
            //view.DisplayDuplicateGN75BMessage(value);
        }

        public bool RemoveButtonEnabled
        {
            set
            {
                bool removeisol;
                removeisol = value;
            }

        }

        private void mainTableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void oltLabel6_Click(object sender, EventArgs e)
        {

        }

    }
}
