﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN75BFormPresenter : AddEditBaseFormPresenter<IFormGN75BView, FormGN75B>
    {
        private List<string> isolationTypes;
        private List<string> equipmentTypes;
        

        private readonly IFormEdmontonService service;
        
        private readonly IDocumentLinkService documentLinkService;
        private readonly IDropdownValueService dropdownValueService;

        private List<DocumentLink> originalDocumentLinks;
        private readonly IReportPrintManager<FormGN75B> reportPrintManager; //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
      

        private bool saveWasSuccessful;

        private const string ImageFileFilters = "Image Files|*.BMP; *.JPG; *.JPEG; *.GIF; *.TIF; *.TIFF; *.PNG; *.ICO; *EMF; *.WMF";

        public FormGN75BFormPresenter()
            : this(null)
        {
        }

        public FormGN75BFormPresenter(FormGN75B form)
            : base(new FormGN75BForm(), form)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;

            service = clientServiceRegistry.GetService<IFormEdmontonService>();
            documentLinkService = clientServiceRegistry.GetService<IDocumentLinkService>();
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();

            view.FormLoad += HandleFormLoad;
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.AddIsolationButtonClicked += HandleAddIsolationClicked;
            view.InsertIsolationButtonClicked += HandleInsertIsolationButtonClicked;
            view.RemoveIsolationButtonClicked += HandleRemoveIsolationClicked;
            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;
            view.BrowseSchematicButtonClicked += HandleBrowseSchematicButtonClicked;
            view.ClearSchematicButtonClicked += HandleClearSchematicButtonClicked;
            view.ViewSchemeticButtonClicked += HandleViewSchemeticButtonClicked;
            view.DocumentLinkOpened += HandleDocumentLinkOpened;
            view.PreEditButtonClicked += HandlePreEditButtonClick;//RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            view.EditPrintButtonClicked += HandleEditPrintButtonclick;//RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions = new EdmontonGN75BFormPrintActions(service);//RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
            reportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions); //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes
        }
         
        private void HandleDocumentLinkOpened()
        {
            // if we are editing an existing form, save the fact the user read a document link now so that it remembers even if they hit cancel
            if (editObject != null && editObject.Id != null)
            {
                ClientBackgroundWorker worker = new ClientBackgroundWorker();
                worker.DoWork += (sender, args) => service.InsertGN75BUserReadDocumentLinkAssociation(editObject.IdValue, userContext.User.IdValue);
                worker.RunWorkerAsync();
            }            
        }

        private bool UserHasAddedADocumentLinkInThisSession()
        {
            List<string> urls = originalDocumentLinks.ConvertAll(link => link.Url);

            if (view.DocumentLinks.Exists(documentLink => !urls.Contains(documentLink.Url)))
            {
                return true;
            }

            return false;
        }

        private void HandleViewSchemeticButtonClicked()
        {
            if (editObject.SchematicImage == null)
                return;

            FormGN75BSchematicForm formGn75BSchematicForm = new FormGN75BSchematicForm
            {
                OriginalImage = ConvertBytesToImage(editObject.SchematicImage)
            };
            formGn75BSchematicForm.ShowDialog(view);
        }

        private void HandleClearSchematicButtonClicked()
        {
            view.ClearSchematic();
            editObject.ClearSchematic();
        }

        private void HandleBrowseSchematicButtonClicked()
        {
            List<FunctionalLocation> sectionsForSelectedFunctionalLocations = ClientSession.GetUserContext().SectionsForSelectedFunctionalLocations;
            List<DocumentRootUncPath> documentRoots = documentLinkService.QueryRootsBySecondLevelFunctionalLocation(new SectionOnlyFlocSet(sectionsForSelectedFunctionalLocations));

            if (documentRoots.Count == 0)
            {
                // TODO: Show message saying need to configure document links
            }
            else if (documentRoots.Count == 1)
            {
                DisplayFileBrowser(documentRoots[0]);
            }
            else
            {
                DocumentRootUncPath selectedDocumentRoot = DisplayRootSelector();

                if (selectedDocumentRoot != null)
                    DisplayFileBrowser(selectedDocumentRoot);
            }
        }

        private DocumentRootUncPath DisplayRootSelector()
        {
            DocumentRootSelectionForm form = new DocumentRootSelectionForm { StartPosition = FormStartPosition.CenterParent };
            DialogResult dialogResult = form.ShowDialog(view);

            return dialogResult == DialogResult.OK ? form.SelectedItem : null;
        }

        private void DisplayFileBrowser(DocumentRootUncPath uncPath)
        {
            FileDialog fileDialog = new OpenFileDialog { RestoreDirectory = true, CheckPathExists = true };
            fileDialog.Filter = ImageFileFilters;

            string path = uncPath.Path;

            if (Directory.Exists(path))
            {
                fileDialog.InitialDirectory = path;
                fileDialog.Title = string.Format(StringResources.FormGn75B_SelectSchematic, uncPath.PathName);
            }

            DialogResult dialogResult = fileDialog.ShowDialog(view);
            if (dialogResult == DialogResult.OK)
            {
                string schematicPath = fileDialog.FileName;
                if (schematicPath.HasValue() && File.Exists(schematicPath))
                {
                    byte[] imageAsBytes = File.ReadAllBytes(schematicPath);
                    editObject.AddSchematic(schematicPath, imageAsBytes);
                    view.Schematic = ConvertBytesToImage(imageAsBytes);
                    if (IsEdit)
                    {
                        editObject.SchematicImage = imageAsBytes;
                    }
                }
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked()
        {
            bool locationChangedByUser = view.SelectedFunctionalLocation != null && !string.Equals(view.LocationOfWork, view.SelectedFunctionalLocation.Description);
            
            DialogResultAndOutput<FunctionalLocation> result = view.ShowFunctionalLocationSelector();

            if (result.Result == DialogResult.OK)
            {
                FunctionalLocation newFloc = result.Output;
                view.SelectedFunctionalLocation = newFloc;
                if (!locationChangedByUser)
                {
                    view.LocationOfWork = newFloc.Description;
                }
            }
        }

        private void HandleRemoveIsolationClicked()
        {
            view.RemoveSelectedIsolationItem();
            EnableOrDisableRemoveButton();
        }

        private void HandleAddIsolationClicked()
        {
            FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null,null,ClientSession.GetUserContext().SiteId));   //ayman Sarnia eip DMND0008992
            view.AddIsolationItem(item);
            EnableOrDisableRemoveButton();
        }

        private void HandleInsertIsolationButtonClicked()
        {
            FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null,null,ClientSession.GetUserContext().SiteId));        //ayman Sarnia eip DMND0008992
            view.InsertIsolationBeforeSelectedItem(item);
            EnableOrDisableRemoveButton();
        }

        private void EnableOrDisableRemoveButton()
        {
            view.RemoveButtonEnabled = view.IsolationItems.Count != 0;
        }

        private void HandleHistoryButtonClicked()
        {
            EditFormGN75BHistoryFormPresenter presenter = new EditFormGN75BHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes:-Aarti
        private void HandlePreEditButtonClick()
        {
            if (!ValidateViewHasError())
            {
                UpdateEditObjectFromView();
                FormGN75B domainObject = editObject;

                if (IsClone || IsNew)
                {
                    domainObject.Id = 0;
                    domainObject.OperatorText = "New/Cloned GN75GB created Via OLT";

                }
                else
                {

                    domainObject.OperatorText = "Document created with reference of the GN75B form #" +
                                                domainObject.FormNumber;
                    // domainObject.Id = 0;

                }
                reportPrintManager.PreviewReport(domainObject);
            }

        }

        //RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes:-Aarti
        private void HandleEditPrintButtonclick()
        {
            if (!ValidateViewHasError())
            {
                //List<DomainObject> domainObjects = new List<DomainObject>();

                UpdateEditObjectFromView();
                FormGN75B domainObject = editObject;

                if (IsClone || IsNew)
                {
                    domainObject.Id = 0;
                    domainObject.OperatorText = "New/Cloned GN75GB created Via OLT";

                }
                else
                {

                    domainObject.OperatorText = "Document created with reference of the GN75B form #" +
                                                domainObject.FormNumber;
                    // domainObject.Id = 0;

                }
                reportPrintManager.PrintEdit(domainObject);
            }

        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { LoadIsolationTypesFromDatabase, LoadEquipmentTypes });
        }

        private void LoadEquipmentTypes()
        {
            List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(userContext.SiteId, FormGN75BDropDownValueKeys.EquipmentTypes);
            equipmentTypes = FormGN75BDropDownValueKeys.EquipmentTypesDropdownValues(dropdownValues);
        }

        private void LoadIsolationTypesFromDatabase()
        {
            List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(userContext.SiteId, FormGN75BDropDownValueKeys.IsolationTypes);
            isolationTypes = FormGN75BDropDownValueKeys.IsolationTypesDropdownValues(dropdownValues);
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormType_GN75B);
            view.IsolationItemsDropdownList = isolationTypes;
            view.EquipmentTypesDropdownList = equipmentTypes;
            view.HistoryButtonEnabled = IsEdit;
            ////RITM0468037:EN50 : OLT:: Edmonton:: GN75B changes-Aarti
            if (ClientSession.GetUserContext().IsEdmontonSite && ClientSession.GetUserContext().Role.Name == "Operator")
                {
                    view.SaveButtonEnable = false;
                    view.PreEditEnable = true;
                    view.EditPrintEnable = true;
                
                }
                else
                {
                    view.SaveButtonEnable = true;
                    view.PreEditEnable = false;
                    view.EditPrintEnable = false;
                }

            UpdateViewFromEditObject();

            EnableOrDisableRemoveButton();

            originalDocumentLinks = new List<DocumentLink>(view.DocumentLinks);
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            //ayman generic forms
            editObject.SiteID = userContext.SiteId;

            editObject.FunctionalLocation = view.SelectedFunctionalLocation;
            editObject.LocationOfWork = view.LocationOfWork;
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.BlindsRequired = view.BlindsRequired.GetValueOrDefault(false);
            editObject.EquipmentType = view.EquipmentType;
            editObject.LockBoxNumber = view.LockBoxNumber;
            editObject.LockBoxLocation = view.LockBoxLocation;
            List<IsolationItem> isolationItems = view.IsolationItems.ConvertAll(item => item.GetIsolationItem());
            int counter = 1;
            isolationItems.ForEach(i => i.DisplayOrder = counter++);
            editObject.IsolationItems = isolationItems;

            //string schematicPath = view.;
            //if (schematicPath.HasValue() && File.Exists(schematicPath))
            //{
            //    byte[] imageAsBytes = File.ReadAllBytes(schematicPath);
            //    editObject.AddSchematic(schematicPath, imageAsBytes);
            //    view.Schematic = ConvertBytesToImage(imageAsBytes);
            //}
            //editObject.SchematicImage = view.Schematic;
        }

        private void UpdateViewFromEditObject()
        {
            DateTime now = Clock.Now;
            User createdByUser = userContext.User;

            if (IsClone)
            {
                editObject.CreatedBy = createdByUser;
                editObject.CreatedDateTime = now;
                editObject.LastModifiedBy = createdByUser;
                editObject.LastModifiedDateTime = now;
            }

            view.BlindsRequired = IsNew ? (bool?)null : editObject.BlindsRequired;

            if (IsNew)
            {
                List<IsolationItem> isolationItems = new List<IsolationItem>{new IsolationItem(null, null, 1, null, null,null,ClientSession.GetUserContext().SiteId)};     //ayman Sarnia eip DMND0008992
                editObject = new FormGN75B(null, null, isolationItems, createdByUser, now, createdByUser,now, false,false,false,string.Empty,string.Empty,string.Empty,1,null,0,new List<FormApproval>(),null)   //ayman Sarnia eip DMND0008992
                {
                    DocumentLinks = new List<DocumentLink>(0),
                    FormStatus =  FormStatus.Approved
                };
            }

            view.SelectedFunctionalLocation = editObject.FunctionalLocation;
            view.LocationOfWork = editObject.LocationOfWork;
            view.DocumentLinks = editObject.DocumentLinks;
            view.EquipmentType = editObject.EquipmentType;
            view.LockBoxNumber = editObject.LockBoxNumber;
            view.LockBoxLocation = editObject.LockBoxLocation;
            view.IsolationItems = editObject.IsolationItems.ConvertAll(item => new FormGN75BIsolationItemDisplayAdapter(item));
            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;
            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            if (editObject.SchematicImage != null)
            {
                Image image = ConvertBytesToImage(editObject.SchematicImage);
                view.Schematic = image;
            }
         //amit shukla INC0466688
            if (IsEdit)
            {
                if (editObject.SchematicImage !=null)
                {
                    view.Schematic = ConvertBytesToImage(editObject.SchematicImage);
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

        protected override bool ValidateViewHasError()
        {
            bool hasErrors = false;

            view.ClearErrorProviders();

            if (view.SelectedFunctionalLocation == null)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasErrors = true;
            }

            if (view.LocationOfWork.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoLocationOfWork();
                hasErrors = true;
            }

            if (view.BlindsRequired.HasValue == false)
            {
                view.SetErrorForNoBlindsSelected();
                hasErrors = true;
            }

            if (view.EquipmentType.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoEquipmentType();
                hasErrors = true;
            }

            List<FormGN75BIsolationItemDisplayAdapter> trainingItems = view.IsolationItems;

            //Aarti INC0548411

            if (trainingItems.Count.Equals(0))
            {
                view.SetErrorForIsolationGrid();
                hasErrors = true;
            }
            else
            {

                trainingItems.ForEach(item =>
                {
                    if (item.TypeOfIsolation.IsNullOrEmptyOrWhitespace() ||
                        item.LocationOfIsolation.IsNullOrEmptyOrWhitespace())
                    {
                        item.AddError(StringResources.FormGN75B_Error_IsolationIncomplete);
                        hasErrors = true;
                    }
                });
            }

            if (hasErrors)
            {
                view.MakeIsolationGridValidationIconsShowOrDisappear();
            }

            if (!hasErrors && editObject.PathToSchematic.IsNullOrEmptyOrWhitespace() && (view.DocumentLinks != null && view.DocumentLinks.Count == 0))
            {
                DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.FormGn75B_NoSchematicWarning);
                
                if (dialogResult == DialogResult.Yes)
                {
                    hasErrors = true;
                }
                
            }
            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();          

            bool userHasAddedDocumentLinks = UserHasAddedADocumentLinkInThisSession();

            FormGN75B insertedForm = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN75BCreate, service.InsertGN75B, editObject, userHasAddedDocumentLinks);
            editObject = insertedForm;
        }

     protected override void Update()
        {
            UpdateEditObjectFromView();

            bool userHasAddedDocumentLinks = UserHasAddedADocumentLinkInThisSession();

            //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => service.UpdateGN75B(formGn75B, userHasAddedDocumentLinks), editObject);

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                formGn75B => service.UpdateSarniaGN75B(
                    formGn75B, userHasAddedDocumentLinks, "EIP Template"), editObject); // INC0433199 : Added by vibhor ( Fixed issue of Closing a EIP Template)
        }

        public DialogResultAndOutput<FormGN75B> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<FormGN75B>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<FormGN75B>(DialogResult.Cancel, null);
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {           
            base.SaveOrUpdate(shouldCloseForm);
            saveWasSuccessful = true;
        }
    }
}