﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormGN75BSarniaFormTemplate : BaseForm,IFormGN75BSarniaView
    {
        private const string TypeOfIsolationColumnKey = "TypeOfIsolation";
        private const string TypeOfIsolationValueListKey = "TypeOfIsolationValueList";

        //ayman Sarnia eip DMND0008992
        private const string DevicePositionColumnKey = "DevicePosition";
        private const string DevicePositionValueListKey = "DevicePositionValueList";

        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;


        public event Action FormLoad;
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action HistoryButtonClicked;
        public event Action AddIsolationButtonClicked;
        public event Action InsertIsolationButtonClicked;
        public event Action RemoveIsolationButtonClicked;
        public event Action BrowseFunctionalLocationButtonClicked;
        public event Action BrowseSchematicButtonClicked;
        public event Action ClearSchematicButtonClicked;
        public event Action ViewSchemeticButtonClicked;
        public event Action DocumentLinkOpened;
        public event Action selectFormGN75BTemplateButtonClicked;
        public event Action DocumentLinkAdded;
        public event Action ViewGN75BFormButtonClicked;               //ayman Sarnia eip DMND0008992
        public event Action RemoveGN75BButtonClicked;                 //ayman Sarnia eip DMND0008992
        public event Action GeneralWorkTextChanged;                   //ayman Sarnia eip DMND0008992
        public void ClearSchematic()
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;
        
        
        public FormGN75BSarniaFormTemplate()
        {
            InitializeComponent();

            UserContext userContext = ClientSession.GetUserContext();
            List<FunctionalLocation> rootFlocsForActiveSelection = userContext.RootFlocSetForForms.FunctionalLocations;

            flocSelector = new SingleSelectFunctionalLocationSelectionForm(FunctionalLocationMode.GetLevelThreeAndBelow(
                userContext.SiteConfiguration), new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level1, rootFlocsForActiveSelection));

            addIsolationButton.Click += HandleAddIsolationButtonClicked;
            insertIsolationButton.Click += HandleInsertIsolationButtonClicked;
            removeIsolationButton.Click += HandleRemoveIsolationButtonClicked;
            
            saveButton.Click += HandleSaveButtonClicked;
            cancelButton.Click += HandleCancelButtonClicked;
            browseFunctionalLocationButton.Click += HandleBrowseFunctionalLocationButtonClicked;
            historyButton.Click += HandleHistoryButtonClick;
            browseSchematicButton.Click += HandleSchematicButtonClick;
            removeSchematicButton.Click += HandleClearSchemeticButtonClick;
            viewSchematicButton.Click += HandleViewSchemeticButtonClick;
            documentLinksControl.LinkOpened += HandleDocumentLinkOpened;
            documentLinksControl.LinkAdded += HandleDocumentLinkAdded;
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
     
        private void HandleViewSchemeticButtonClick(object sender, EventArgs e)
        {
            if (ViewSchemeticButtonClicked != null)
            {
                ViewSchemeticButtonClicked();
            }
        }

        //ayman Sarnia eip DMND0008992
        public bool? BlindsRequired
        {get;set;}

        //ayman Sarnia eip DMND0008992
        public bool? DeadLeg
        { get; set; }

        //ayman Sarnia eip - 2
        public bool? DeadLegRisk
        { get; set; }

        //ayman Sarnia eip DMND0008992
        public string SpecialPrecautions
        { get; set; }

        private void HandleClearSchemeticButtonClick(object sender, EventArgs e)
        {
            if (ClearSchematicButtonClicked != null)
            {
                ClearSchematicButtonClicked();
            }
        }

        //ayman Sarnia eip DMND0008992
        private void HandleApprovalUnselected(FormApproval formApproval)
        {
        }

        private void HandleApprovalSelected(FormApproval formApproval)
        {
        }

        //ayman Sarnia eip - 2
        public void ApprovalGridEnabled(bool enabled)
        {
        }

        //ayman Sarnia eip DMND0008992
        public void DisableAllControls()
        {
            this.functionalLocationTextBox.Enabled = false;
            this.locationTextBox.Enabled = false;
            historyButton.Visible = false;
            saveButton.Visible = false;
            browseSchematicButton.Visible = false;
            removeSchematicButton.Visible = false;
            documentLinksGroupBox.Enabled = false;
            cancelButton.Text = "Exit";
            buttonPanel.Enabled = false;
            historyButton.Enabled = false;
            addIsolationButton.Visible = false;
            insertIsolationButton.Visible = false;
            removeIsolationButton.Visible = false;
            isolationsPanel.Enabled = true;
            cancelButton.Enabled = true;
            HistoryButtonEnabled = false;
            browseFunctionalLocationButton.Visible = false;
            equipmentTypeComboBox.Enabled = false;
            label4.Visible = false;
            this.SetTitle("View Eip Template");
            UltraGrid mygrid = new UltraGrid();
            mygrid = isolationGrid;
            mygrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            isolationsPanel.Enabled = true;
        }


        private void HandleSchematicButtonClick(object sender, EventArgs e)
        {
            if (BrowseSchematicButtonClicked != null)
            {
                BrowseSchematicButtonClicked();
            }
        }

        public void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet()
        {
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
            if (InsertIsolationButtonClicked != null)
            {
                InsertIsolationButtonClicked();
            }
        }

        //ayman Sarnia eip DMND0008992
        public string GeneralWorkText
        {
            get { return string.Empty; }
            set { var txt = value; }
        }

        //ayman Sarnia eip DMND0008992
        public bool ApprovalsChecked
        {
            get { return ApprovalsChecked; }
            set { ApprovalsChecked = value; }
        }

        private void HandleGeneralWorkTextChanged(object sender, EventArgs e)
        {
         
        }

        //ayman Sarnia eip DMND0008992
        //ayman enable/disable waiting for approval button
        public void EnableWaitingForApprovalButton()
        {
        }

        public void DisableWaitingForApprovalButton()
        {
        }

        //ayman Sarnia eip DMND0008992
        public DialogResult ShowFormWillNeedReapprovalQuestion()
        {
            string message = StringResources.FormReapprovalQuestion;
            string title = StringResources.FormReapprovalQuestionTitle;
            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void Makecheckboxesnochoice()                   //ayman Sarnia eip
        {
        }

        //private void selectFormGN75BTemplateButtonClicked(object sender, EventArgs e)
        //{
        //}

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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            isolationGrid.DataSource = new List<FormGN75BIsolationItemDisplayAdapter>();
            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            IsolationItems.ForEach(item => item.ClearErrors());
            MakeIsolationGridValidationIconsShowOrDisappear();
        }

        public void MakeIsolationGridValidationIconsShowOrDisappear()
        {
            isolationGrid.Rows.Refresh(RefreshRow.FireInitializeRow);
        }


        public List<FormGN75BIsolationItemDisplayAdapter> IsolationItems
        {
            get
            {
                return (List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource;
            }

            set
            {
                isolationGrid.DataSource = value;
                isolationGrid.ResetBindings();
            }
        }
   
        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public User CreatedByUser
        {
            set { createdByUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime CreatedDateTime
        {
            set { createdDateLabel.Text = value.ToLongDateAndTimeString(); }
        }

        public User LastModifiedByUser
        {
            set { lastModifiedUserLabel.Text = value.FullNameWithUserName; }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateLabel.Text = value.ToLongDateAndTimeString(); }
        }


        //ayman Sarnia eip DMND0008992
        public long? formgn75bTemplateId
        {
            get { return 0; }
            set
            {
               
            }
        }

        public List<FormApproval> Approvals { get; set; }    //ayman Sarnia eip DMND0008992

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    toolTip.SetToolTip(functionalLocationTextBox, value.Description);
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public Image Schematic
        {
            set
            {
                Image scaledImage = FormGN75BSchematicForm.ScaleImage(value, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = scaledImage;
            }
        }

        //public bool? BlindsRequired
        //{
        //    get
        //    {
        //        if (blindsRequiredYes.Checked)
        //        {
        //            return true;
        //        }
        //        if (blindsRequiredNo.Checked)
        //        {
        //            return false;
        //        }
        //        return null;
        //    }
        //    set 
        //    {
        //        if (value.HasValue)
        //        {
        //            blindsRequiredYes.Checked = value.Value;
        //            blindsRequiredNo.Checked = !value.Value;
        //        }
        //        else
        //        {
        //            blindsRequiredYes.Checked = false;
        //            blindsRequiredNo.Checked = false;
        //        }
        //    }
        //}

        public string EquipmentType
        {
            get { return equipmentTypeComboBox.Text; }
            set { equipmentTypeComboBox.Text = value; }
        }

        public string LocationOfWork
        {
            get { return locationTextBox.Text; }
            set { locationTextBox.Text = value; }
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

        //ayman Sarnia eip DMND0008992
        public string flocs
        {
            get { return ""; }
            set { }
        }

        public string FlocDesc
        {
            get { return ""; }
            set { }
        }

        public DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector()
        {
            DialogResult dialogResult = flocSelector.ShowDialog(this);

            FunctionalLocation selectedFunctionalLocation = flocSelector.SelectedFunctionalLocation;
            return new DialogResultAndOutput<FunctionalLocation>(dialogResult, selectedFunctionalLocation);
        }

        public void SetErrorForNoBlindsSelected()
        {
        }

        public void SetErrorForNoDeadLegSelected()
        {
        }

        public void SetErrorForNoDeadLegRiskSelected()                   //ayman Sarnia eip - 2
        {
        }

        public void SetErrorForNoLocationOfWork()
        {
            errorProvider.SetError(locationTextBox, "Planned Work Scope is required" );
        }

        public void SetErrorForNoEquipmentType()
        {
            errorProvider.SetError(equipmentTypeComboBox, StringResources.FormGN75B_Error_EquipmentTypeRequired);
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocEmptyError);
        }

        //Aarti INC0548411 
        public void SetErrorForIsolationGrid()
        {
           // errorProvider.SetError(isolationGrid, StringResources.IsolationEmptyError);
            OltMessageBox.ShowError("At Least One Isolation Type Is Required to Save Template");
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
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


        //ayman Sarnia eip DMND0008992
        private void HandleRemoveGN75BButtonClicked()
        {
        }

        //ayman Sarnia eip DMND0008992
        private void HandleRemoveFormGN75BButtonClicked()
        {
         
        }


        public List<string> IsolationItemsDropdownList
        {
            set
            {
                ValueList valueList = (ValueList)isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList ??
                                      isolationGrid.DisplayLayout.ValueLists.Add(TypeOfIsolationValueListKey);

                valueList.ValueListItems.Clear();
                foreach (string isolationType in value)
                {
                    valueList.ValueListItems.Add(isolationType);
                }

                isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList = valueList;
            }
        }


        //ayman Sarnia eip DMND0008992
        public List<string> DevicePositionItemsDropdownList
        {
            set
            {
                ValueList valueList = (ValueList)isolationGrid.DisplayLayout.Bands[0].Columns[DevicePositionColumnKey].ValueList ??
                                      isolationGrid.DisplayLayout.ValueLists.Add(DevicePositionValueListKey);

                valueList.ValueListItems.Clear();
                foreach (string devicePosition in value)
                {
                    valueList.ValueListItems.Add(devicePosition);
                }

                isolationGrid.DisplayLayout.Bands[0].Columns[DevicePositionColumnKey].ValueList = valueList;
            }
        }


        //ayman Sarnia eip DMND0008992
        public void DisplayDuplicateGN75BMessage(string message)
        {
        }

        public List<string> EquipmentTypesDropdownList
        {
            set
            {
                equipmentTypeComboBox.DataSource = value;
            }
        }

        public void InsertIsolationBeforeSelectedItem(FormGN75BIsolationItemDisplayAdapter item)
        {
            int indexOfSelectedItem = isolationGrid.ActiveRow.Index;
            // need to re-order items
            List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource);
            items.Insert(indexOfSelectedItem, item);

            isolationGrid.DataSource = items;
            isolationGrid.ResetBindings();
            isolationGrid.ActiveItemByReference = item;
        }

        public void AddIsolationItem(FormGN75BIsolationItemDisplayAdapter item)
        {
            List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource)
            {
                item
            };
            isolationGrid.DataSource = items;
            isolationGrid.ResetBindings();
            isolationGrid.ActiveItemByReference = item;
        }

        public void RemoveSelectedIsolationItem()
        {
            List<FormGN75BIsolationItemDisplayAdapter> items = new List<FormGN75BIsolationItemDisplayAdapter>((List<FormGN75BIsolationItemDisplayAdapter>)isolationGrid.DataSource);

            FormGN75BIsolationItemDisplayAdapter activeItem = (FormGN75BIsolationItemDisplayAdapter)isolationGrid.ActiveItem;

            if (activeItem != null)
            {
                items.Remove(activeItem);
                isolationGrid.DataSource = items;
                isolationGrid.ResetBindings();
            }
        }

        public bool RemoveButtonEnabled
        {
            set { removeIsolationButton.Enabled = value; }
        }

        private void isolationGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }
    }
    }

