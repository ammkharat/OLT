﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormGN75BForm : BaseForm, IFormGN75BView
    {
        private const string TypeOfIsolationColumnKey = "TypeOfIsolation";
        private const string TypeOfIsolationValueListKey = "TypeOfIsolationValueList";

        public event Action FormLoad;
        public event EventHandler SaveButtonClicked;
        public event Action PreEditButtonClicked; //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
       public event Action EditPrintButtonClicked; ////RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
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
        public event Action DocumentLinkAdded;
        
        
        public void ClearSchematic()
        {
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private readonly ISingleSelectFunctionalLocationSelectionForm flocSelector;

        public FormGN75BForm()
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
            PreEdit.Click += HandlePreEditButtonClick; //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            editPrint.Click += HandleEditPrintButtonClick;//RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            if (ClientSession.GetUserContext().IsEdmontonSite && ClientSession.GetUserContext().Role.Name == "Operator")//RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            {
                cancelButton.Text = "Close";
            }
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

        private void HandleClearSchemeticButtonClick(object sender, EventArgs e)
        {
            if (ClearSchematicButtonClicked != null)
            {
                ClearSchematicButtonClicked();
            }
        }

        public void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet()
        {
           //RemoveButtonEnabled = !gn75BFormNumberTextBox.Text.IsNullOrEmptyOrWhitespace();
           // viewGN75BFormButton.Enabled = !gn75BFormNumberTextBox.Text.IsNullOrEmptyOrWhitespace();
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
            if (InsertIsolationButtonClicked != null)
            {
                InsertIsolationButtonClicked();
            }
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

        public string LocationOfWork
        {
            get { return locationTextBox.Text; }
            set { locationTextBox.Text = value; }
        }

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

        public bool? BlindsRequired
        {
            get
            {
                if (blindsRequiredYes.Checked)
                {
                    return true;
                }
                if (blindsRequiredNo.Checked)
                {
                    return false;
                }
                return null;
            }
            set 
            {
                if (value.HasValue)
                {
                    blindsRequiredYes.Checked = value.Value;
                    blindsRequiredNo.Checked = !value.Value;
                }
                else
                {
                    blindsRequiredYes.Checked = false;
                    blindsRequiredNo.Checked = false;
                }
            }
        }

        public string EquipmentType
        {
            get { return equipmentTypeComboBox.Text; }
            set { equipmentTypeComboBox.Text = value; }
        }

        public string LockBoxNumber
        {
            get { return lockBoxNumber.Text; }
            set { lockBoxNumber.Text = value; }
        }

        public string LockBoxLocation
        {
            get { return lockBoxLocation.Text; }
            set { lockBoxLocation.Text = value; }
        }

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

        public void SetErrorForNoBlindsSelected()
        {
            errorProvider.SetError(blindsRequiredPanel, StringResources.FormGN75B_Error_BlindsRequired);
        }

        public void SetErrorForNoLocationOfWork()
        {
            errorProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForNoEquipmentType()
        {
            errorProvider.SetError(equipmentTypeComboBox, StringResources.FormGN75B_Error_EquipmentTypeRequired);
        }

        //Aarti INC0548411 
        public void SetErrorForIsolationGrid()
        {
            
           OltMessageBox.ShowError("At Least One Isolation Type Is Required to Save Template");
        }

        public void SetErrorForNoFunctionalLocationSelected()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FlocEmptyError);
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }
        //RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti
        private void HandlePreEditButtonClick(object sender, EventArgs eventArgs)
        {
            if (PreEditButtonClicked != null)
            {
                PreEditButtonClicked();
            }
        }

        //RITM0468037:EN50:OLT::Edmonton::GN75B changes:Aarti
        private void HandleEditPrintButtonClick(object sender, EventArgs eventArgs)
        {
            if (EditPrintButtonClicked != null)
            {
                EditPrintButtonClicked();
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
                ValueList valueList = (ValueList)isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList ??
                                      isolationGrid.DisplayLayout.ValueLists.Add(TypeOfIsolationValueListKey);

                valueList.ValueListItems.Clear();
                foreach (string isolationType in value)
                {
                    valueList.ValueListItems.Add(isolationType);
                }

                isolationGrid.DisplayLayout.Bands[0].Columns[TypeOfIsolationColumnKey].ValueList = valueList;
                isolationGrid.DisplayLayout.Bands[0].Columns["DevicePosition"].Hidden = true;   //ayman fix bug for device position 
            }
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

        //RITM0468037:EN50:OLT:: Edmonton:: GN75B changes
        public bool SaveButtonEnable
        {
            set { saveButton.Enabled = value; }
        }

        //RITM0468037:EN50:OLT:: Edmonton:: GN75B changes
        public bool PreEditEnable
        {
            set { PreEdit.Visible = value; }
        }

        //RITM0468037:EN50:OLT:: Edmonton:: GN75B changes
        public bool EditPrintEnable
        {
            set { editPrint.Visible = value; }
        }
    }
}