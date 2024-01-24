using System;
using System.Collections.Generic;
using System.Web.Services.Description;
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
    public class FormGN6FormPresenter : AddEditBaseFormPresenter<IFormGN6View, FormGN6>
    {
        private readonly IFormEdmontonService service;
        private List<FormTemplate> formTemplates;
        private bool saveWasSuccessful;
        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalJobDescription;
        private string originalReasonForCriticalLift;
        private string originalSection1PlainTextContent;
        private bool originalSection1NotApplicableToJob;
        private string originalSection2PlainTextContent;
        private bool originalSection2NotApplicableToJob;
        private string originalSection3PlainTextContent;
        private bool originalSection3NotApplicableToJob;
        private string originalSection4PlainTextContent;
        private bool originalSection4NotApplicableToJob;
        private string originalSection5PlainTextContent;
        private bool originalSection5NotApplicableToJob;
        private string originalSection6PlainTextContent;
        private bool originalSection6NotApplicableToJob;
        private List<FunctionalLocation> originalFlocs;
        private List<DocumentLink> originalDocumentLinks;
        private string originalPlainTextPreJobMeetingSignatures;

        // This is saved so when the user sets section 3 to not applicable it can be restored to the form if they then make it applicable again.
        private FormApproval savedElectricalRepFormApproval;

        private string buttontext;

        public FormGN6FormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormGN6FormPresenter(FormGN6 form)
            : base(new FormGN6Form(), form)
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

            view.ExpandSection1Clicked += HandleExpandSection1Clicked;
            view.ExpandSection2Clicked += HandleExpandSection2Clicked;
            view.ExpandSection3Clicked += HandleExpandSection3Clicked;
            view.ExpandSection4Clicked += HandleExpandSection4Clicked;
            view.ExpandSection5Clicked += HandleExpandSection5Clicked;
            view.ExpandSection6Clicked += HandleExpandSection6Clicked;

            view.Section1NotApplicableToJobCheckedChanged += HandleSection1NotApplicableToJobCheckedChanged;
            view.Section2NotApplicableToJobCheckedChanged += HandleSection2NotApplicableToJobCheckedChanged;
            view.Section3NotApplicableToJobCheckedChanged += HandleSection3NotApplicableToJobCheckedChanged;
            view.Section4NotApplicableToJobCheckedChanged += HandleSection4NotApplicableToJobCheckedChanged;
            view.Section5NotApplicableToJobCheckedChanged += HandleSection5NotApplicableToJobCheckedChanged;
            view.Section6NotApplicableToJobCheckedChanged += HandleSection6NotApplicableToJobCheckedChanged;

            view.ExpandPreJobMeetingSignaturesClicked += HandleExpandPreJobMeetingSignaturesClicked;

            UpdateWaitingForApprovalButtonStatus(); //ayman enable/disable waiting for approval button

        }

        private void HandleSection1NotApplicableToJobCheckedChanged()
        {
            if (view.Section1NotApplicableToJob)
            {
                view.Section1Content = TemplateTextForSection1();
            }
        }

        private void HandleSection2NotApplicableToJobCheckedChanged()
        {
            if (view.Section2NotApplicableToJob)
            {
                view.Section2Content = TemplateTextForSection2();
            }
        }
        
        private void HandleSection3NotApplicableToJobCheckedChanged()
        {
            if (view.Section3NotApplicableToJob)
            {
                view.Section3Content = TemplateTextForSection3();

                List<FormApproval> formApprovals = view.Approvals;
                FormApproval electricalApproval = formApprovals.Find(FormGN6.IsElectricalRepApproval);

                if (electricalApproval != null)
                {
                    savedElectricalRepFormApproval = electricalApproval;
                    formApprovals.Remove(electricalApproval);
                    view.Approvals = formApprovals;
                }
            }
            else
            {
                if (savedElectricalRepFormApproval != null)
                {                    
                    List<FormApproval> formApprovals = view.Approvals;

                    if (!formApprovals.Exists(FormGN6.IsElectricalRepApproval))
                    {
                        formApprovals.Insert(0, savedElectricalRepFormApproval);
                        view.Approvals = formApprovals;
                    }                    
                }
                else
                {
                    List<FormApproval> formApprovals = view.Approvals;
                    formApprovals.Insert(0, FormGN6.CreateElectricalRepFormApproval(editObject.Id));
                    view.Approvals = formApprovals;
                }
            }
        }

        private void HandleSection4NotApplicableToJobCheckedChanged()
        {
            if (view.Section4NotApplicableToJob)
            {
                view.Section4Content = TemplateTextForSection4();
            }
        }

        private void HandleSection5NotApplicableToJobCheckedChanged()
        {
            if (view.Section5NotApplicableToJob)
            {
                view.Section5Content = TemplateTextForSection5();
            }
        }

        private void HandleSection6NotApplicableToJobCheckedChanged()
        {
            if (view.Section6NotApplicableToJob)
            {
                view.Section6Content = TemplateTextForSection6();
            }
        }

        private void HandleExpandSection1Clicked()
        {
            view.Section1Content = view.DisplayExpandedContentForm(view.Section1Content);
        }

        private void HandleExpandSection2Clicked()
        {
            view.Section2Content = view.DisplayExpandedContentForm(view.Section2Content);
        }

        private void HandleExpandSection3Clicked()
        {
            view.Section3Content = view.DisplayExpandedContentForm(view.Section3Content);
        }

        private void HandleExpandSection4Clicked()
        {
            view.Section4Content = view.DisplayExpandedContentForm(view.Section4Content);
        }

        private void HandleExpandSection5Clicked()
        {
            view.Section5Content = view.DisplayExpandedContentForm(view.Section5Content);
        }

        private void HandleExpandSection6Clicked()
        {
            view.Section6Content = view.DisplayExpandedContentForm(view.Section6Content);
        }

        private void HandleExpandPreJobMeetingSignaturesClicked()
        {
            view.PreJobMeetingSignatures = view.DisplayExpandedContentForm(view.PreJobMeetingSignatures);
        }

        private void HandleHistoryButtonClicked()
        {
            EditFormGN6HistoryFormPresenter presenter = new EditFormGN6HistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action> { QueryFormTemplates });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, EdmontonFormType.GN6.GetName());
            view.HistoryButtonEnabled = IsEdit;

            UpdateViewFromEditObject();
        }

        private void QueryFormTemplates()
        {
            formTemplates = service.QueryFormTemplatesByFormType(EdmontonFormType.GN6,ClientSession.GetUserContext().SiteId);
        }

        private string PreJobMeetingSignaturesTemplate()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_PREJOBSIGNATURES, formTemplates).Template;
        }

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;

            originalJobDescription = editObject.JobDescription;
            originalReasonForCriticalLift = editObject.ReasonForCriticalLift;

            originalSection1PlainTextContent = editObject.Section1PlainTextContent;
            originalSection1NotApplicableToJob = editObject.Section1NotApplicableToJob;
            originalSection2PlainTextContent = editObject.Section2PlainTextContent;
            originalSection2NotApplicableToJob = editObject.Section2NotApplicableToJob;
            originalSection3PlainTextContent = editObject.Section3PlainTextContent;
            originalSection3NotApplicableToJob = editObject.Section3NotApplicableToJob;
            originalSection4PlainTextContent = editObject.Section4PlainTextContent;
            originalSection4NotApplicableToJob = editObject.Section4NotApplicableToJob;
            originalSection5PlainTextContent = editObject.Section5PlainTextContent;
            originalSection5NotApplicableToJob = editObject.Section5NotApplicableToJob;
            originalSection6PlainTextContent = editObject.Section6PlainTextContent;
            originalSection6NotApplicableToJob = editObject.Section6NotApplicableToJob;

            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalDocumentLinks = new List<DocumentLink>(editObject.DocumentLinks);

            originalPlainTextPreJobMeetingSignatures = editObject.PlainTextPreJobMeetingSignatures;
        }

        private static FormGN6 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;            //ayman generic forms

            FormGN6 form = new FormGN6(null, FormStatus.Draft, now, now, currentUser, now, siteid);    //ayman generic forms

            form.WorkerResponsibiltiesTemplateText = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>().GetFormGN6WorkerResponsibilitiesText();
            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            
            //ayman generic forms
            editObject.SiteId = userContext.SiteId;

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.JobDescription = view.JobDescription;
            editObject.ReasonForCriticalLift = view.ReasonForCriticalLift;
            
            editObject.Section1Content = view.Section1Content;
            editObject.Section1PlainTextContent = view.Section1PlainTextContent;
            editObject.Section1NotApplicableToJob = view.Section1NotApplicableToJob;

            editObject.Section2Content = view.Section2Content;
            editObject.Section2PlainTextContent = view.Section2PlainTextContent;
            editObject.Section2NotApplicableToJob = view.Section2NotApplicableToJob;

            editObject.Section3Content = view.Section3Content;
            editObject.Section3PlainTextContent = view.Section3PlainTextContent;
            editObject.Section3NotApplicableToJob = view.Section3NotApplicableToJob;

            editObject.Section4Content = view.Section4Content;
            editObject.Section4PlainTextContent = view.Section4PlainTextContent;
            editObject.Section4NotApplicableToJob = view.Section4NotApplicableToJob;

            editObject.Section5Content = view.Section5Content;
            editObject.Section5PlainTextContent = view.Section5PlainTextContent;
            editObject.Section5NotApplicableToJob = view.Section5NotApplicableToJob;

            editObject.Section6Content = view.Section6Content;
            editObject.Section6PlainTextContent = view.Section6PlainTextContent;
            editObject.Section6NotApplicableToJob = view.Section6NotApplicableToJob;

            editObject.PreJobMeetingSignatures = view.PreJobMeetingSignatures;
            editObject.PlainTextPreJobMeetingSignatures = view.PlainTextPreJobMeetingSignatures;
            editObject.DocumentLinks = view.DocumentLinks;

            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateViewFromEditObject()
        {
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;
            view.JobDescription = editObject.JobDescription;
            view.ReasonForCriticalLift = editObject.ReasonForCriticalLift;
            view.DocumentLinks = editObject.DocumentLinks;

            UpdateViewApprovalsFromEditObject();

            view.Section1NotApplicableToJob = editObject.Section1NotApplicableToJob;
            view.Section2NotApplicableToJob = editObject.Section2NotApplicableToJob;
            view.Section3NotApplicableToJob = editObject.Section3NotApplicableToJob;
            view.Section4NotApplicableToJob = editObject.Section4NotApplicableToJob;
            view.Section5NotApplicableToJob = editObject.Section5NotApplicableToJob;
            view.Section6NotApplicableToJob = editObject.Section6NotApplicableToJob;

            if (editObject.Section1Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section1Content = TemplateTextForSection1();
            }
            else
            {
                view.Section1Content = editObject.Section1Content;
            }

            if (editObject.Section2Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section2Content = TemplateTextForSection2();
            }
            else
            {
                view.Section2Content = editObject.Section2Content;
            }

            if (editObject.Section3Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section3Content = TemplateTextForSection3();
            }
            else
            {
                view.Section3Content = editObject.Section3Content;
            }

            if (editObject.Section4Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section4Content = TemplateTextForSection4();
            }
            else
            {
                view.Section4Content = editObject.Section4Content;
            }

            if (editObject.Section5Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section5Content = TemplateTextForSection5();
            }
            else
            {
                view.Section5Content = editObject.Section5Content;
            }

            if (editObject.Section6Content.IsNullOrEmptyOrWhitespace())
            {
                view.Section6Content = TemplateTextForSection6();
            }
            else
            {
                view.Section6Content = editObject.Section6Content;
            }

            if (editObject.PreJobMeetingSignatures.IsNullOrEmptyOrWhitespace())
            {
                view.PreJobMeetingSignatures = PreJobMeetingSignaturesTemplate();
            }
            else
            {
                view.PreJobMeetingSignatures = editObject.PreJobMeetingSignatures;
            }

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
        }

        private string TemplateTextForSection1()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_MANBASKET, formTemplates).Template;
        }

        private string TemplateTextForSection2()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_CRANECHART, formTemplates).Template;
        }

        private string TemplateTextForSection3()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_POWERLINES, formTemplates).Template;
        }

        private string TemplateTextForSection4()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_ACIDDRUMS, formTemplates).Template;
        }

        private string TemplateTextForSection5()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_ALOTOFCRANES, formTemplates).Template;
        }

        private string TemplateTextForSection6()
        {
            return FormTemplateKeys.FormTemplateForKey(FormTemplateKeys.GN6_OTHER, formTemplates).Template;
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

            if (view.JobDescription.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForJobDescriptionRequired();
                hasErrors = true;
            }

            if (view.ReasonForCriticalLift.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForReasonForCriticalLiftRequired();
                hasErrors = true;
            }

            return hasErrors;
        }


        private void UpdateWaitingForApprovalButtonStatus()
        {
            //ayman enable/disable waiting for approval button
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingApprovalButton();
            }
            else
            {
                view.EnableWaitingApprovalButton();
            }

        }


        protected override void Insert()
        {
            UpdateEditObjectFromView();
            FormGN6 form = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN6Create, service.InsertGN6, editObject);
            editObject.Id = form.Id;
        }


        private void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;

            UpdateWaitingForApprovalButtonStatus(); //ayman enable/disable waiting for approval button
        }

        private void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;

            UpdateWaitingForApprovalButtonStatus(); //ayman enable/disable waiting for approval button
        }

        protected override void Update()
        {
            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();

            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateGN6, editObject, attributesForHazardsLabel);
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

            if (IsEdit && FormWillNeedElectricalReapproval())
            {
                DialogResult result = view.ShowFormWillNeedElectricalReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    UnapproveFormAndSave(showEmail);
                }
            }
            else if (IsEdit && FormWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    UnapproveFormAndSave(showEmail);
                }
            }
            else
            {
                SaveWithApprovalCheck(showEmail);
            }
        }

        private void UnapproveFormAndSave(bool showEmail)
        {
            editObject.FormStatus = FormStatus.Draft;
            FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);
            SaveWithApprovalCheck(showEmail);
        }

        protected void SaveWithApprovalCheck(bool showEmail)
        {
            UpdateEditObjectFromView();

            if (editObject.AllApprovalsAreIn())
            {
                DateTime? approvalDateTime;

                if (IsEdit && !editObject.SomethingRequiringReapprovalHasChanged(originalJobDescription, originalReasonForCriticalLift, originalSection1NotApplicableToJob, originalSection1PlainTextContent, originalSection2NotApplicableToJob, originalSection2PlainTextContent, originalSection3NotApplicableToJob, originalSection3PlainTextContent, originalSection4NotApplicableToJob, originalSection4PlainTextContent, originalSection5NotApplicableToJob, originalSection5PlainTextContent, originalSection6NotApplicableToJob, originalSection6PlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, originalDocumentLinks, userContext.User, new Authorized().ToChangeEndDateOfGN6WithNoReapprovalRequired(userContext.UserRoleElements)))
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

        protected void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.GN6.Name, editObject.FormNumber);
        }

        private bool FormWillNeedElectricalReapproval()
        {
            return editObject.WillNeedElectricalReapproval(originalSection3NotApplicableToJob, originalSection3PlainTextContent, userContext.User);
        }

        private bool FormWillNeedReapproval()
        {
            Authorized authorized = new Authorized();
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN6WithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.WillNeedReapproval(originalJobDescription, originalReasonForCriticalLift, originalSection1NotApplicableToJob, originalSection1PlainTextContent, originalSection2NotApplicableToJob, originalSection2PlainTextContent, originalSection3NotApplicableToJob, originalSection3PlainTextContent, originalSection4NotApplicableToJob, originalSection4PlainTextContent, originalSection5NotApplicableToJob, originalSection5PlainTextContent, originalSection6NotApplicableToJob, originalSection6PlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, originalDocumentLinks, ClientSession.GetUserContext().User, noReapprovalRequiredForEndDateChange);
        }

        protected void HandleAddFunctionalLocationButtonClicked()
        {
            DialogResultAndOutput<List<FunctionalLocation>> result = view.ShowFunctionalLocationSelector(view.FunctionalLocations);

            if (result.Result == DialogResult.OK)
            {
                IList<FunctionalLocation> newFlocList = result.Output;
                view.FunctionalLocations = newFlocList == null ? new List<FunctionalLocation>() : new List<FunctionalLocation>(newFlocList);
            }
        }

        protected void HandleRemoveFunctionalLocationButtonClicked()
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

        public DialogResultAndOutput<FormGN6> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<FormGN6>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<FormGN6>(DialogResult.Cancel, null);
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            base.SaveOrUpdate(shouldCloseForm);

            saveWasSuccessful = true;
        }

    }
}
