using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN24FormPresenter : AddEditBaseFormPresenter<IFormGN24View, FormGN24>
    {
        private readonly IFormEdmontonService service;
        private List<FormTemplate> formTemplates;
        private bool saveWasSuccessful;

        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalPlainTextContent;
        private List<FunctionalLocation> originalFlocs;
        private bool originalIsTheSafeWorkPlanForPSVRemovalOrInstallation;
        private bool originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit;
        private FormGN24AlkylationClass originalAlkylationClass;
        private List<DocumentLink> originalDocumentLinks;
        private string buttontext;
        
        public FormGN24FormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormGN24FormPresenter(FormGN24 form) : base(new FormGN24Form(), form)
        {
            SaveOriginalFormValues();
            
            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            view.FormLoad += HandleFormLoad;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked; // Swapnil Patki For DMND0005325 Point Number 7
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandContentClicked += HandleExpandContentClicked;
            view.ExpandPreJobMeetingSignaturesClicked += HandleExpandPreJobMeetingSignaturesClicked;
            view.IsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged += HandleIsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged;
            view.IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged += HandleIsTheSafeWorkPlanForPsvRemovalOrInstallationChanged;

            ApprovalRelatedEventsEnabled = true;
        }

        private void HandleExpandContentClicked()
        {
            view.DisplayExpandedContentForm();
        }

        private void HandleExpandPreJobMeetingSignaturesClicked()
        {
            view.DisplayExpandedPreJobMeetingSignaturesForm();
        }

        private void HandleHistoryButtonClicked()
        {
            EditFormGN24HistoryFormPresenter presenter = new EditFormGN24HistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleIsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged()
        {
            view.AlkylationClassSelectionEnabled = view.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { QueryFormTemplates });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, EdmontonFormType.GN24.GetName());
            view.AlkylationClasses = FormGN24AlkylationClass.All;
            view.HistoryButtonEnabled = IsEdit;

            UpdateViewFromEditObject();
        }

        private void QueryFormTemplates()
        {
            formTemplates = service.QueryFormTemplatesByFormType(EdmontonFormType.GN24,ClientSession.GetUserContext().SiteId);            //ayman generic forms
        }

        private void HandleIsTheSafeWorkPlanForPsvRemovalOrInstallationChanged()
        {
            view.Content = TemplateTextBasedOnViewState();
        }

        private string TemplateTextBasedOnViewState()
        {
            FormTemplate template = FormTemplateKeys.FormTemplateForKey(
                view.IsTheSafeWorkPlanForPSVRemovalOrInstallation ? FormTemplateKeys.GN24_PSV : FormTemplateKeys.GN24_NONPSV, formTemplates);

            return template.Template;
        }

        private string PreJobMeetingSignaturesTemplate()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN24_PREJOBSIGNATURES, formTemplates).Template;
        }

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalDocumentLinks = new List<DocumentLink>(editObject.DocumentLinks);
            originalIsTheSafeWorkPlanForPSVRemovalOrInstallation = editObject.IsTheSafeWorkPlanForPSVRemovalOrInstallation;
            originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit = editObject.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            originalAlkylationClass = editObject.AlkylationClass;
        }

        private static FormGN24 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;     //ayman generic forms

            FormGN24 form = new FormGN24(null, FormStatus.Draft, now, now, currentUser, now, siteid);     //ayman generic forms
            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            //ayman generic forms
            editObject.SiteId = userContext.SiteId;

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.PreJobMeetingSignatures = view.PreJobMeetingSignatures;
            editObject.PlainTextPreJobMeetingSignatures = view.PlainTextPreJobMeetingSignatures;
            editObject.DocumentLinks = view.DocumentLinks;

            UpdateEditObjectApprovalsFromView();

            editObject.IsTheSafeWorkPlanForPSVRemovalOrInstallation = view.IsTheSafeWorkPlanForPSVRemovalOrInstallation;
            editObject.IsTheSafeWorkPlanForWorkInTheAlkylationUnit = view.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            editObject.AlkylationClass = view.AlkylationClass;
        }

        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;

            view.FunctionalLocations = editObject.FunctionalLocations;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;
            view.IsTheSafeWorkPlanForPSVRemovalOrInstallation = editObject.IsTheSafeWorkPlanForPSVRemovalOrInstallation;
            view.IsTheSafeWorkPlanForWorkInTheAlkylationUnit = editObject.IsTheSafeWorkPlanForWorkInTheAlkylationUnit;
            view.AlkylationClass = editObject.AlkylationClass;
            view.DocumentLinks = editObject.DocumentLinks;

            UpdateViewApprovalsFromEditObject();

            view.Content = editObject.Content.IsNullOrEmptyOrWhitespace() ? TemplateTextBasedOnViewState() : editObject.Content;

            view.PreJobMeetingSignatures = editObject.PreJobMeetingSignatures.IsNullOrEmptyOrWhitespace() ? PreJobMeetingSignaturesTemplate() : editObject.PreJobMeetingSignatures;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();



            //ayman enable/disable waiting for approval button
           UpdateWaitingForApprovalButtonStatus();

        }


        private void UpdateWaitingForApprovalButtonStatus()
        {
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingForApprovalButton();
            }
            else
            {
                view.EnableWaitingForApprovalButton();
            }
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

            if (view.ValidFrom >= view.ValidTo)
            {
                view.SetErrorForValidFromMustBeBeforeValidTo();
                hasErrors = true;
            }

            if (view.IsTheSafeWorkPlanForWorkInTheAlkylationUnit && view.AlkylationClass == null)
            {
                view.SetErrorForNoAlkylationClassSelected();
                hasErrors = true;
            }

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            FormGN24 form = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN24Create, service.InsertGN24, editObject);
            editObject.Id = form.Id;
        }


        private void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;
            //ayman enable/disable waiting for approval button
            UpdateWaitingForApprovalButtonStatus();
        }

        private void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;
            //ayman enable/disable waiting for approval button
            UpdateWaitingForApprovalButtonStatus();
        }

        protected override void Update()
        {
            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();

            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateGN24, editObject, attributesForHazardsLabel);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((System.Windows.Forms.Control)(sender)).Name; // Swapnil Patki For DMND0005325 Point Number 7
            Save(false);
        }

        private void HandleWaitingApprovalClicked() // Swapnil Patki For DMND0005325 Point Number 7
        {
            Save(false);
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true);
        }

        private void Save(bool showEmail)
        {
            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            if (IsEdit && FormWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;   // this is just for safety/clarity; if we're editing the form, it should already be in 'draft' mode
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);
                    SaveWithApprovalCheck(showEmail);
                }
            }
            else
            {
                SaveWithApprovalCheck(showEmail);
            }
        }

        private void SaveWithApprovalCheck(bool showEmail)
        {
            UpdateEditObjectFromView();

            if (editObject.AllApprovalsAreIn())
            {
                DateTime? approvalDateTime;

                if (IsEdit && !editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, originalDocumentLinks, originalIsTheSafeWorkPlanForPSVRemovalOrInstallation, originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit, originalAlkylationClass, userContext.User, new Authorized().ToChangeEndDateOfGN24WithNoReapprovalRequired(userContext.UserRoleElements)))
                {                    
                    approvalDateTime = editObject.ApprovedDateTime ?? Clock.Now;
                }
                else
                {
                    approvalDateTime = Clock.Now;
                }

                editObject.MarkAsApproved(approvalDateTime);                                
            }
            else
            {
                //editObject.MarkAsUnapproved();
                if (buttontext != null) // Swapnil Patki For DMND0005325 Point Number 7
                {
                    editObject.MarkAsUnapproved();
                }
                else
                {
                    editObject.MarkAsWaitingForApproval();
                }
            }

            SaveOrUpdate(true);

            if (showEmail)
            {
                ShowEmail();
            }
        }

        private void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.GN24.Name, editObject.FormNumber);
        }

        private bool FormWillNeedReapproval()
        {
            Authorized authorized = new Authorized();
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN24WithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.WillNeedReapproval(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, originalDocumentLinks,
                originalIsTheSafeWorkPlanForPSVRemovalOrInstallation, originalIsTheSafeWorkPlanForWorkInTheAlkylationUnit, originalAlkylationClass,
                ClientSession.GetUserContext().User, noReapprovalRequiredForEndDateChange);
        }

        private void HandleAddFunctionalLocationButtonClicked()
        {
            DialogResultAndOutput<List<FunctionalLocation>> result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
            }
        }

        private void HandleRemoveFunctionalLocationButtonClicked()
        {
            FunctionalLocation floc = view.SelectedFunctionalLocation;

            if (floc != null)
            {
                List<FunctionalLocation> associatedFlocs = view.FunctionalLocations;
                associatedFlocs.Remove(floc);
                var newAssociatedFlocs = new List<FunctionalLocation>(associatedFlocs);

                view.FunctionalLocations = newAssociatedFlocs;
            }
        }

        private void HandleChangeToSomethingThatChangesApprovals()
        {
            UpdateEditObjectFromView();
            editObject.Approvals.ForEach(approval =>
            {
                approval.Enabled = approval.ShouldBeEnabled(editObject, Clock.Now);
                if (!approval.Enabled)
                {
                    approval.Unapprove();
                }
            });
            UpdateViewApprovalsFromEditObject();
        }

        private bool ApprovalRelatedEventsEnabled
        {
            set
            {
                if (value)
                {
                    view.IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged += HandleChangeToSomethingThatChangesApprovals;
                }
                else
                {
                    view.IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged -= HandleChangeToSomethingThatChangesApprovals;
                }
            }
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            editObject.Approvals = viewApprovals;
        }

        public DialogResultAndOutput<FormGN24> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<FormGN24>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<FormGN24>(DialogResult.Cancel, null);
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            base.SaveOrUpdate(shouldCloseForm);

            saveWasSuccessful = true;
        }

    }
}
