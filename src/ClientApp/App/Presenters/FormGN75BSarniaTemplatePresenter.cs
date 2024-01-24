using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.History;
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
namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN75BSarniaTemplatePresenter : AddEditBaseFormPresenter<IFormGN75BSarniaView, FormGN75B>
    {
        private List<string> isolationTypes;
        private List<string> equipmentTypes;
        private List<string> devicePosition;           

        private readonly IFormEdmontonService service;

        private readonly IDocumentLinkService documentLinkService;
        private readonly IDropdownValueService dropdownValueService;

        private List<DocumentLink> originalDocumentLinks;

        private bool saveWasSuccessful;

        private const string ImageFileFilters = "Image Files|*.BMP; *.JPG; *.JPEG; *.GIF; *.TIF; *.TIFF; *.PNG; *.ICO; *EMF; *.WMF";

         public FormGN75BSarniaTemplatePresenter()
            : this(null,false)
        {
        }

              public FormGN75BSarniaTemplatePresenter(FormGN75B form,bool disableallcontrols)
            : base(new FormGN75BSarniaFormTemplate(), form)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;

            service = clientServiceRegistry.GetService<IFormEdmontonService>();
            documentLinkService = clientServiceRegistry.GetService<IDocumentLinkService>();
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();

            view.FormLoad += HandleFormLoad;
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.AddIsolationButtonClicked += HandleAddIsolationClicked;
            view.selectFormGN75BTemplateButtonClicked += HandleSelectFormGN75BTemplateButtonClicked;
            view.InsertIsolationButtonClicked += HandleInsertIsolationButtonClicked;
            view.RemoveIsolationButtonClicked += HandleRemoveIsolationClicked;
            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;
            view.BrowseSchematicButtonClicked += HandleBrowseSchematicButtonClicked;
            view.ClearSchematicButtonClicked += HandleClearSchematicButtonClicked;
            view.ViewSchemeticButtonClicked += HandleViewSchemeticButtonClicked;
            view.DocumentLinkOpened += HandleDocumentLinkOpened;


                  view.ApprovalSelected += HandleApprovalSelected;
                  view.ApprovalUnselected += HandleApprovalUnselected;

            if(disableallcontrols)
            {
                view.DisableAllControls();
            }

        }

          private void HandleDocumentLinkOpened()
          {
              // if we are editing an existing form, save the fact the user read a document link now so that it remembers even if they hit cancel
              if (editObject != null && editObject.Id != null)
              {
                  ClientBackgroundWorker worker = new ClientBackgroundWorker();
                  worker.DoWork += (sender, args) => service.InsertGN75BUserReadDocumentLinkAssociationTemplateSarnia(editObject.IdValue, userContext.User.IdValue);////INC0458107  Aarti (OLT::EIP template Sarnia:: attachment crash)
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
                     // view.LocationOfWork = newFloc.Description;
                  }
              }
          }

          private void HandleRemoveIsolationClicked()
          {
              view.RemoveSelectedIsolationItem();
              EnableOrDisableRemoveButton();
          }

          protected void HandleApprovalUnselected(FormApproval approval)
          {
              approval.ApprovedByUser = null;
              approval.ApprovalDateTime = null;
          }

          protected void HandleApprovalSelected(FormApproval approval)
          {
              approval.ApprovedByUser = ClientSession.GetUserContext().User;
              approval.ApprovalDateTime = Clock.Now;
          }

          private void HandleAddIsolationClicked()
          {
              FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null,null,ClientSession.GetUserContext().SiteId));     //ayman Sarnia eip DMND0008992
            view.AddIsolationItem(item);
              EnableOrDisableRemoveButton();
          }

        private void HandleSelectFormGN75BTemplateButtonClicked()
        {
        }

        private void HandleInsertIsolationButtonClicked()
          {
              FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null,null,ClientSession.GetUserContext().SiteId));     //ayman Sarnia eip DMND0008992
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

          private void HandleFormLoad()
          {
              LoadData(new List<Action> { LoadIsolationTypesFromDatabase, LoadEquipmentTypes, LoadDevicePositionFromDatabase  });

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

        //ayman Sarnia eip DMND0008992
        private void LoadDevicePositionFromDatabase()
          {
              List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(userContext.SiteId, FormGN75BDropDownValueKeys.DevicePosition);
              devicePosition = FormGN75BDropDownValueKeys.DevicePositionDropdownValues(dropdownValues);
          }

          protected override void AfterDataLoad()
          {
              view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormType_SarniaGN75BTemplate);       //ayman Sarnia eip DMND0008992
            view.IsolationItemsDropdownList = isolationTypes;
              view.DevicePositionItemsDropdownList = devicePosition;         //ayman Sarnia eip DMND0008992
            view.EquipmentTypesDropdownList = equipmentTypes;
              view.HistoryButtonEnabled = IsEdit;

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
              //editObject.BlindsRequired = view.BlindsRequired.GetValueOrDefault(false);
              editObject.EquipmentType = view.EquipmentType;
              //editObject.LockBoxNumber = view.LockBoxNumber;
              //editObject.LockBoxLocation = view.LockBoxLocation;
              List<IsolationItem> isolationItems = view.IsolationItems.ConvertAll(item => item.GetIsolationItem());
              int counter = 1;
              isolationItems.ForEach(i => i.DisplayOrder = counter++);
              editObject.IsolationItems = isolationItems;
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

              //view.BlindsRequired = IsNew ? (bool?)null : editObject.BlindsRequired;

              if (IsNew)
              {
                  List<IsolationItem> isolationItems = new List<IsolationItem> { new IsolationItem(null, null, 1, null, null,null,ClientSession.GetUserContext().SiteId) };    //ayman Sarnia eip DMND0008992
                List<DevicePosition> devicePosition = new List<DevicePosition> { new DevicePosition(null, null, 1, null) };   //ayman Sarnia eip DMND0008992

                editObject = new FormGN75B(null, null, isolationItems, createdByUser, now, createdByUser, now, false,false,false, null, null, null,8,devicePosition,1,null,null)   //ayman Sarnia eip DMND0008992
                {
                      DocumentLinks = new List<DocumentLink>(0),
                      //FormStatus = FormStatus.Approved
                      FormStatus = FormStatus.WaitingForApproval // INC0512123 : Added by Vibhor
                  };
              }

              view.SelectedFunctionalLocation = editObject.FunctionalLocation;
              view.LocationOfWork = editObject.LocationOfWork;
              view.DocumentLinks = editObject.DocumentLinks;
              view.EquipmentType = editObject.EquipmentType;
            //view.LockBoxNumber = editObject.LockBoxNumber;
            //view.LockBoxLocation = editObject.LockBoxLocation;
            if (editObject.IsolationItems != null)
            {
                view.IsolationItems = editObject.IsolationItems.ConvertAll(item => new FormGN75BIsolationItemDisplayAdapter(item));
            }
              view.CreatedByUser = editObject.CreatedBy;
              view.CreatedDateTime = editObject.CreatedDateTime;
              view.LastModifiedByUser = editObject.LastModifiedBy;
              view.LastModifiedDateTime = editObject.LastModifiedDateTime;

              if (editObject.SchematicImage != null)
              {
                  Image image = ConvertBytesToImage(editObject.SchematicImage);
                  view.Schematic = image;
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

              //if (view.BlindsRequired.HasValue == false)
              //{
              //    view.SetErrorForNoBlindsSelected();
              //    hasErrors = true;
              //}

              if (view.EquipmentType.IsNullOrEmptyOrWhitespace())
              {
                  view.SetErrorForNoEquipmentType();
                  hasErrors = true;
              }

              List<FormGN75BIsolationItemDisplayAdapter> trainingItems = view.IsolationItems;

              //Aarti
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
              //INC0458107 Aarti (OLT::EIP template Sarnia:: attachment crash
              FormGN75B insertedForm = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN75BTemplateCreate, service.InsertGN75BTemplateSarnia, editObject, userHasAddedDocumentLinks);
              editObject = insertedForm;
          }

          protected override void Update()
          {
              UpdateEditObjectFromView();

              bool userHasAddedDocumentLinks = UserHasAddedADocumentLinkInThisSession();

              //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => service.UpdateSarniaGN75B(formGn75B, userHasAddedDocumentLinks,"EIP Template"), editObject);

              FormGN75B updatedform =
                  ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN75BTemplateUpdate,
                  (formGn75B => service.UpdateSarniaGN75B(formGn75B, userHasAddedDocumentLinks, "EIP Template")), editObject);   // INC0433199 : Added by vibhor ( Fixed issue of Closing a EIP Template)
              
                  
              editObject = updatedform;
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
