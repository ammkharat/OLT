using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;


namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN75BSarniaFormPresenter : AddEditBaseFormPresenter<IFormGN75BSarniaView, FormGN75B>
    {

        private List<string> isolationTypes;
        private List<string> equipmentTypes;
        private List<string> devicePosition;
        private readonly IFunctionalLocationService flocService;      //ayman Sarnia eip DMND0008992
        private readonly IFormEdmontonService service;
        private static IFormGenericTemplateService service1;          //ayman Sarnia eip DMND0008992
        private readonly IDocumentLinkService documentLinkService;
        private readonly IDropdownValueService dropdownValueService;
        private readonly IReportPrintManager<FormGN75B> reportPrintManager;      //ayman Sarnia eip DMND0008992
        private FormGN75B templatedata;            //ayman Sarnia eip - 2
        private List<DocumentLink> originalDocumentLinks;
        private long? formid;
        private bool saveWasSuccessful;
        protected readonly IObjectLockingService objectLockingService;
        private FunctionalLocation originalFloc;
        private DateTime originalFromDateTime;
        private DateTime originalToDateTime;
        private string originalLocationOfWork;
        private long originalEipTemplateNumber;
        private List<string> originalListOfApprovers;
        private bool originalBlindsRequired;                        //ayman Sarnia eip DMND0008992
        private bool originalDeadLeg;                               //ayman Sarnia eip DMND0008992
        private string originalSpecialPrecautions;                  //ayman Sarnia eip DMND0008992

        private const string ImageFileFilters = "Image Files|*.BMP; *.JPG; *.JPEG; *.GIF; *.TIF; *.TIFF; *.PNG; *.ICO; *EMF; *.WMF";
        Authorized authorized = new Authorized();
        public FormGN75BSarniaFormPresenter()
           : this(null)
        {
        }

        public FormGN75BSarniaFormPresenter(FormGN75B form)
            : base(new FormGN75BSarniaForm(), form)
        {






            if (form == null)
            {
                long siteid = ClientSession.GetUserContext().Site.IdValue;
                List<IsolationItem> isolationItems = new List<IsolationItem> { new IsolationItem(null, null, 1, null, null, null, ClientSession.GetUserContext().SiteId) };      //ayman Sarnia eip DMND0008992
                List<DevicePosition> devicePosition = new List<DevicePosition> { new DevicePosition(null, null, 1, null) };   //ayman Sarnia eip DMND0008992
                form = new FormGN75B(null, null, isolationItems, null, Clock.Now, null, Clock.Now, false,false,false, null, null,
                    null, siteid, devicePosition, 0, new List<FormApproval>(),string.Empty);
            }


            SaveOriginalFormValues(form);


            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            PrintActions<FormGN75B, SarniaEipIssueReport, SarniaEipIssueReportAdapter> printActions =
              new SarniaEipIssuePrintActions(service);               //ayman Sarnia eip DMND0008992
            reportPrintManager = new ReportPrintManager<FormGN75B, SarniaEipIssueReport, SarniaEipIssueReportAdapter>(printActions);           //ayman Sarnia eip DMND0008992
            service = clientServiceRegistry.GetService<IFormEdmontonService>();
            documentLinkService = clientServiceRegistry.GetService<IDocumentLinkService>();
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();
            view.FormLoad += HandleFormLoad;
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.selectFormGN75BTemplateButtonClicked += HandleSelectFormGN75BTemplateButtonClicked;
            view.AddIsolationButtonClicked += HandleAddIsolationClicked;
            view.InsertIsolationButtonClicked += HandleInsertIsolationButtonClicked;
            view.RemoveIsolationButtonClicked += HandleRemoveIsolationClicked;
            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;
            view.ViewGN75BFormButtonClicked += HandleViewGN75BFormButtonClicked;                            //ayman Sarnia eip DMND0008992
            view.RemoveGN75BButtonClicked += HandleRemoveFormGN75BButtonClicked;                            //ayman Sarnia eip DMND0008992
            view.BrowseSchematicButtonClicked += HandleBrowseSchematicButtonClicked;                      //             view.GeneralWorkTextChanged += HandleGeneralWorkTextChanged;                                   //ayman Sarnia eip DMND0008992

            view.ClearSchematicButtonClicked += HandleClearSchematicButtonClicked;
            view.ViewSchemeticButtonClicked += HandleViewSchemeticButtonClicked;
            view.DocumentLinkOpened += HandleDocumentLinkOpened;

            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            ApprovalRelatedEventsEnabled = true;                                                            //ayman Sarnia eip DMND0008992
                                                                                                            //service1 = ClientServiceRegistry.Instance.GetService<IFormGenericTemplateService>();
                                                                                                            //form.Approvals = service1.QueryByFormSarniaEipIssueApproverByIdAndSiteId(ClientSession.GetUserContext().SiteId, EdmontonFormType.GN75BSarniaEIP.IdValue, ClientSession.GetUserContext().PlantIds[0]);

            formid = form.Id;
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

        private void SaveOriginalFormValues(FormGN75B form)
        {
            originalFloc = form.FunctionalLocation;
            originalFromDateTime = form.FromDateTime;
            originalToDateTime = form.ToDateTime;
            originalDocumentLinks = form.DocumentLinks;
            originalLocationOfWork = form.LocationOfWork;
            originalEipTemplateNumber = form.TemplateID;
            originalListOfApprovers = form.Approvals.ConvertAll(approval => approval.Approver);
            originalBlindsRequired = form.BlindsRequired;
            originalDeadLeg = form.DeadLeg;                       //ayman Sarnia eip DMND0008992
            originalSpecialPrecautions = form.SpecialPrecautions;  //ayman Sarnia eip DMND0008992
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

        //ayman Sarnia eip DMND0008992
        private bool ApprovalRelatedEventsEnabled
        {
            set
            {
                if (value)
                {
                    view.GeneralWorkTextChanged += HandleChangeToSomethingThatChangesApprovals;
                }
                else
                {
                    view.GeneralWorkTextChanged -= HandleChangeToSomethingThatChangesApprovals;
                }
            }
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

        //ayman Sarnia eip DMND0008992
        private IForm ViewTemplate(FormGN75B form)
        {
            FormGN75BSarniaTemplatePresenter presenter = new FormGN75BSarniaTemplatePresenter(form,false);
            return presenter.View;
        }


        //ayman Sarnia eip DMND0008992
        private void HandleViewGN75BFormButtonClicked()
        {
            var formGn75BTemplate = view.formgn75bTemplateId;
            if (!formGn75BTemplate.HasValue)
                return;

            var formGn75B = service.QueryFormGN75BTemplateByIdAndSiteId(formGn75BTemplate.Value, ClientSession.GetUserContext().SiteId);
            PriorityPagePresenter prsntr = new PriorityPagePresenter();
            prsntr.ShowEipTemplate(formGn75B);

        }

        //ayman Sarnia eip DMND0008992
        private void HandleRemoveFormGN75BButtonClicked()
        {
            view.formgn75bTemplateId = null;
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

        private void HandleAddIsolationClicked()
        {
            FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null, null, ClientSession.GetUserContext().SiteId));     //ayman Sarnia eip DMND0008992
            view.AddIsolationItem(item);
            EnableOrDisableRemoveButton();
        }

        //ayman Sarnia eip DMND0008992
        protected void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;
            approval.Approver = "Plan Approved By";

        }

        protected void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;
            approval.Approver = ClientSession.GetUserContext().User.FullName;
        }

        private void HandleInsertIsolationButtonClicked()
        {
            FormGN75BIsolationItemDisplayAdapter item = new FormGN75BIsolationItemDisplayAdapter(new IsolationItem(null, editObject.Id, view.IsolationItems.Count + 1, null, null, null, ClientSession.GetUserContext().SiteId));     //ayman Sarnia eip DMND0008992
            view.InsertIsolationBeforeSelectedItem(item);
            EnableOrDisableRemoveButton();
        }

        private void EnableOrDisableRemoveButton()
        {
            if (view.IsolationItems != null)     //ayman Sarnia eip DMND0008992
            {
                view.RemoveButtonEnabled = view.IsolationItems.Count != 0;
            }
            else
            {
                view.RemoveButtonEnabled = false;
            }
        }

        private void HandleSelectFormGN75BTemplateButtonClicked()
        {
            // get all eiptemplates which are Approved and waiting for approval

            var details = new FormEdmontonGN75BDetails("Template #", "Work Scope");              //ayman Sarnia eip DMND0008992
            var formPage = new FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails>(new FormEdmontonGN75BGridRenderer(), details);
            var presenter = new SelectFormGN75BTemplatePresenter(formPage);

            var formId = FormID;
            var dialogResultAndOutput = presenter.Run(view, formId);
            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                var formDto = dialogResultAndOutput.Output; //FormEdmontonGN75BDTO formDto = dialogResultAndOutput.Output;
                view.flocs = formDto.FunctionalLocation;
                view.formgn75bTemplateId = formDto.Id;
                view.FlocDesc = view.SelectedFunctionalLocation.Description;
                view.flocs = formDto.FunctionalLocation;
                view.LocationOfWork = formDto.Location;
                
            }
        }

        //ayman Sarnia eip DMND0008992
        public long? FormID
        {
            get { return formid; }
            set { formid = value; }
        }

        private void HandleHistoryButtonClicked()
        {
            EditFormGN75BHistoryFormPresenter presenter = new EditFormGN75BHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleFormLoad()
        {
            if(!authorized.ToApproveEipIssue(ClientSession.GetUserContext().UserRoleElements))
            {
                view.ApprovalGridEnabled(false);
            }

            LoadData(new List<Action> { LoadEquipmentTypes });
            view.EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
            if (IsNew)                               //ayman Sarnia eip
            {
                view.Makecheckboxesnochoice();
            }
        }

        private void LoadEquipmentTypes()
        {
            List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(userContext.SiteId, FormGN75BDropDownValueKeys.EquipmentTypes);
            equipmentTypes = FormGN75BDropDownValueKeys.EquipmentTypesDropdownValues(dropdownValues);
        }

        private void HandleChangeToSomethingThatChangesApprovals()
        {
            UpdateEditObjectFromView();
            editObject.Approvals.ForEach(approval =>
            {
                approval.Enabled = approval.ShouldBeEnabledForSarnia(editObject, Clock.Now);
                if (!approval.Enabled)
                {
                    approval.Unapprove();
                }
            });
            UpdateViewApprovalsFromEditObject();
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        //ayman Sarnia eip DMND0008992
        private void LoadDevicePositionFromDatabase()
        {
            List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(userContext.SiteId, FormGN75BDropDownValueKeys.DevicePosition);
            devicePosition = FormGN75BDropDownValueKeys.DevicePositionDropdownValues(dropdownValues);
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormType_SarniaGN75B);
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
            editObject.BlindsRequired = view.BlindsRequired.GetValueOrDefault(false);
            editObject.DeadLeg = view.DeadLeg.GetValueOrDefault(false);
            editObject.DeadLegRisk = view.DeadLegRisk.GetValueOrDefault(false);                       //ayman Sarnia eip - 2
            editObject.SpecialPrecautions = view.SpecialPrecautions;
            editObject.EquipmentType = view.EquipmentType;
            editObject.TemplateID = view.formgn75bTemplateId.Value;

            //ayman Sarnia eip DMND0008992
            templatedata = service.QueryFormGN75BTemplateByIdAndSiteId(editObject.TemplateID, editObject.SiteID);              //ayman Sarnia eip - 2
            if (templatedata != null)
            {
                editObject.EquipmentType = templatedata.EquipmentType;
            }
            //editObject.LockBoxNumber = view.LockBoxNumber;
            //editObject.LockBoxLocation = view.LockBoxLocation;
            int counter = 1;
            UpdateEditObjectApprovalsFromView();     //ayman Sarnia eip DMND0008992
        }

        //ayman Sarnia eip DMND0008992
        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            editObject.Approvals = viewApprovals;
            if (editObject.AllApprovalsAreIn())
            {
                editObject.FormStatus = FormStatus.Approved;
            }
            else
            {
                editObject.FormStatus = FormStatus.WaitingForApproval;
            }
        }


        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;
            DateTime now = Clock.Now;
            User createdByUser = userContext.User;

            if(IsEdit)
            {
                view.BlindsRequired = editObject.BlindsRequired;
                view.DeadLeg = editObject.DeadLeg;                                    //ayman Sarnia eip DMND0008992
                view.DeadLegRisk = editObject.DeadLegRisk;                            //ayman Sarnia eip - 2
            }


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
                //ayman generic forms
                long siteid = ClientSession.GetUserContext().Site.IdValue;

                List<IsolationItem> isolationItems = new List<IsolationItem> { new IsolationItem(null, null, 1, null, null, null, ClientSession.GetUserContext().SiteId) };      //ayman Sarnia eip DMND0008992
                List<DevicePosition> devicePosition = new List<DevicePosition> { new DevicePosition(null, null, 1, null) };   //ayman Sarnia eip DMND0008992

                editObject = new FormGN75B(null, null, isolationItems, createdByUser, now, createdByUser, now, false,false,false, null, null, null, siteid, devicePosition, 0, new List<FormApproval>(),null)   //ayman Sarnia eip DMND0008992
                {
                    DocumentLinks = new List<DocumentLink>(0),
                    FormStatus = FormStatus.Approved
                };
            }

            view.SelectedFunctionalLocation = editObject.FunctionalLocation;
            view.LocationOfWork = editObject.LocationOfWork;
            view.DocumentLinks = editObject.DocumentLinks;
            view.EquipmentType = editObject.EquipmentType;
            if (editObject.FunctionalLocation == null)                    //ayman Sarnia eip DMND0008992
            {
                view.FlocDesc = "";
            }
            else
            {
                view.FlocDesc = editObject.FunctionalLocation.Description ?? "";
            }
            view.LocationOfWork = editObject.LocationOfWork;                       //ayman Sarnia eip DMND0008992


            view.SpecialPrecautions = editObject.SpecialPrecautions; 
            //view.LockBoxNumber = editObject.LockBoxNumber;
            //view.LockBoxLocation = editObject.LockBoxLocation;
            if (editObject.IsolationItems == null)
            {
                view.IsolationItems = null;
            }
            else
            {
                view.IsolationItems = editObject.IsolationItems.ConvertAll(item => new FormGN75BIsolationItemDisplayAdapter(item));
            }

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;
            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            if (editObject.FunctionalLocation != null)
            {
                view.flocs = editObject.FunctionalLocation.ToString() ?? "";
            }
            view.formgn75bTemplateId = editObject.TemplateID;

            if (editObject.SchematicImage != null)
            {
                Image image = ConvertBytesToImage(editObject.SchematicImage);
                view.Schematic = image;
            }

            view.Approvals = editObject.Approvals;

            ApprovalRelatedEventsEnabled = true;
            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();
        }


        //ayman Sarnia eip DMND0008992
        public void DisplayDuplicateGN75BMessage(string value)
        {
            view.DisplayDuplicateGN75BMessage(value);
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

            List<FormGN75BIsolationItemDisplayAdapter> trainingItems = view.IsolationItems;

            //ayman Sarnia eip DMND0008992
            if (trainingItems != null)
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


            if(view.BlindsRequired == null)
            {
                view.SetErrorForNoBlindsSelected();
                hasErrors = true;                            //ayman Sarnia eip 
            }

            if(view.DeadLeg == null)
            {
                view.SetErrorForNoDeadLegSelected();
                hasErrors = true;
            }

             if(view.DeadLegRisk == null)
            {
                view.SetErrorForNoDeadLegRiskSelected();
                hasErrors = true;
            }

            //if (!hasErrors && editObject.PathToSchematic.IsNullOrEmptyOrWhitespace() && (view.DocumentLinks != null && view.DocumentLinks.Count == 0))
            //{
            //    DialogResult dialogResult = OltMessageBox.ShowCustomYesNo(StringResources.FormGn75B_NoSchematicWarning);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        hasErrors = true;
            //    }

            //}

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            bool userHasAddedDocumentLinks = UserHasAddedADocumentLinkInThisSession();

            FormGN75B insertedForm = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN75BCreate, service.InsertGN75BSarnia, editObject, userHasAddedDocumentLinks);       //ayman Sarnia eip - 3
            editObject = insertedForm;
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            bool userHasAddedDocumentLinks = UserHasAddedADocumentLinkInThisSession();

            if (SomethingRequiringReapprovalHasChanged() && editObject.FormStatus == FormStatus.Approved) //ayman Sarnia eip DMND0008992
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();
                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.WaitingForApproval; //ayman Sarnia eip DMND0008992
                    editObject.LastModifiedDateTime = Clock.Now;
                    editObject.Approvals.ForEach(approval => approval.Approver = "Plan approved by");
                    FormApproval.UnapproveApprovals(view.Approvals);       //ayman Sarnia eip DMND0008992
                    UpdateViewFromEditObject();
                }
                else if(result == DialogResult.No)
                {
                    return;
                }
            }
            else if ((originalListOfApprovers != editObject.Approvals.ConvertAll(approval => approval.Approver)) && editObject.AllApprovalsAreIn() && !SomethingRequiringReapprovalHasChanged())             //ayman Sarnia eip
            {
                editObject.FormStatus = FormStatus.Approved;
                UpdateViewFromEditObject();
            }
            else if ((originalListOfApprovers != editObject.Approvals.ConvertAll(approval => approval.Approver)) &&
                     !editObject.AllApprovalsAreIn() && !SomethingRequiringReapprovalHasChanged()) //ayman Sarnia eip DMND0008992
            {
                editObject.FormStatus = FormStatus.WaitingForApproval;
                UpdateViewFromEditObject();
            }
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(formGn75B => service.UpdateSarniaGN75B(formGn75B, userHasAddedDocumentLinks,"EIP Issue"), editObject);

            
        }


        protected bool SomethingRequiringReapprovalHasChanged()
        {
            // bool approvalschanged = originalListOfApprovers != editObject.Approvals.ConvertAll(approval => approval.Approver);
            User currentuser = ClientSession.GetUserContext().User;
            return editObject.SomethingRequiringReapprovalHasChanged(currentuser, originalEipTemplateNumber, originalDocumentLinks, originalFloc, originalLocationOfWork, originalBlindsRequired,originalDeadLeg,originalSpecialPrecautions);
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
