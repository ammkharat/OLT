using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Client.Security;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TemporaryInstallationsFormPresenter : AbstractFormEdmontonFormPresenter<TemporaryInstallationsMUDS, IFormTemporaryInstallationsView>
    {
        private readonly IFormEdmontonService service;
        private FormTemplate formTemplate;
        private string originalCriticalSystemDefeated;
        private string originalCsdReason;

        private List<FunctionalLocation> originalFlocs;
        private bool? originalHasAttachments;
        private bool? originalHasBeenCommunicated;

        private List<string> originalListOfApprovers;
        private string originalPlainTextContent;
        private bool? originalPressureSafetyValveAnswer;
        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string buttontext;

        public TemporaryInstallationsFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public TemporaryInstallationsFormPresenter(TemporaryInstallationsMUDS form)
            : base(new FormTemporaryInstallationsForm(), form)
        {
            SaveOriginalFormValues();

            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandClicked += HandleExpandClicked;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.HistoryClicked += HandleHistoryClicked;
            ApprovalRelatedEventsEnabled = true;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked;
            view.ApprovalsGroupBoxLabel = StringResources.MudsApprover;
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
       
        private bool ApprovalRelatedEventsEnabled
        {
            set
            {
                if (value)
                {
                    view.PressureSafetyValveAnswerChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.ValidityDatesChanged += HandleChangeToSomethingThatChangesApprovals;
                }
                else
                {
                    view.PressureSafetyValveAnswerChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.ValidityDatesChanged -= HandleChangeToSomethingThatChangesApprovals;
                }
            }
        }

        private void HandleHistoryClicked()
        {
            EditHistoryFormPresenter presenter = new TemporaryInstallationsMUDSHistoryPresenter(editObject);
            presenter.Run(view);
        }

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalPressureSafetyValveAnswer = editObject.IsTheCSDForAPressureSafetyValve;
            originalHasAttachments = editObject.HasAttachments;
            originalHasBeenCommunicated = editObject.HasBeenCommunicated;
            originalCsdReason = editObject.CsdReason;
            originalCriticalSystemDefeated = editObject.CriticalSystemDefeated;
            originalListOfApprovers = editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static TemporaryInstallationsMUDS CreateDefaultForm()
        {
            var now = Clock.Now;
            var currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;         

            var form = new TemporaryInstallationsMUDS(null, FormStatus.Draft, now, now, currentUser, now);    
            form.SetDefaultDatesBasedOnShift(WorkPermitMontreal.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.HasBeenCommunicated = null;//view.HasBeenCommunicated;
            editObject.HasAttachments = null;//view.HasAttachments;
            editObject.IsTheCSDForAPressureSafetyValve = null;//view.IsTheCSDForAPressureSafetyValve;
            editObject.CriticalSystemDefeated = view.CsdReason;//null;//view.CriticalSystemDefeated;// Changed by ppanigrahi(TASK0428706)
            editObject.CsdReason = view.CsdReason;
            editObject.DocumentLinks = view.DocumentLinks;
            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            var viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            editObject.Approvals = viewApprovals;
        }

        protected override void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.TemporaryInstallationsMuds.Name, editObject.FormNumber);
        }

        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;

            view.FunctionalLocations = editObject.FunctionalLocations;
            UpdateViewApprovalsFromEditObject();
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;

            view.Content = editObject.Content;
            view.DocumentLinks = editObject.DocumentLinks;

            //view.HasAttachments = editObject.HasAttachments;
            //view.HasBeenCommunicated = editObject.HasBeenCommunicated;
            //view.IsTheCSDForAPressureSafetyValve = editObject.IsTheCSDForAPressureSafetyValve;
            //view.CriticalSystemDefeated = editObject.CriticalSystemDefeated;
            view.CsdReason = editObject.CsdReason;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();

            UpdateWaitingForApprovalButtonStatus();
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertMudsTemporaryInstallations,
                editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateMudsTemporaryInstallations,
                editObject);
        }

        private void HandleWaitingApprovalClicked()
        {
           // view.CsdReason
            Save(false, buttontext);
           // Save(fasle,view.CSDr)
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((Control)(sender)).Name;
            Save(false, buttontext);
        }

        private void Save(bool showEmail, string buttontext)
        {
            if (Validate())
            {
                return;
            }
           
            UpdateEditObjectFromView();

            bool formWillNeedReapproval = FormWillNeedReapproval();

            if (IsEdit && !formWillNeedReapproval && NewApproversWereAddedButNotApproved())
            {
                DialogResult result = view.ShowFormHasAdditionalApproversRequired();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
                }
            }
            else if (IsEdit && formWillNeedReapproval)
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);
                    SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
                }
            }
            else
            {
                SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext);
            }
        }

        private bool NewApproversWereAddedButNotApproved()
        {
            var currentUnapprovedApprovers =
                editObject.Approvals.FindAll(approval => approval.Enabled && !approval.IsApproved)
                    .ConvertAll(approval => approval.Approver);
            return (currentUnapprovedApprovers.Exists(approver => !originalListOfApprovers.Contains(approver)));
        }

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(
                originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs,
                ClientSession.GetUserContext().User,
                originalHasAttachments, originalHasBeenCommunicated, originalCsdReason,
                originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent, originalValidFromDateTime,
                originalFlocs, ClientSession.GetUserContext().User,
                originalHasAttachments, originalHasBeenCommunicated, originalCsdReason,
                originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> {QueryFormTemplate});
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormMontrealSulphurFormTitle);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();

            Authorized authorized = new Authorized();
            view.ApprovalsEnabled =  authorized.ToApproveOrCloseMudsTemporaryInstallationsForms(ClientSession.GetUserContext().UserRoleElements);
        }

        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.TemporaryInstallationsMuds,ClientSession.GetUserContext().SiteId)[0];    //ayman generic forms
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true, buttontext);
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

        protected override bool ValidateViewHasError()
        {
            var hasError = base.ValidateViewHasError();

            if (view.FunctionalLocations.Count < 1)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasError = true;
            }
            if (view.CsdReason.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForNoCsdReasonGiven();
                hasError = true;
            }
            if (Clock.Now > view.ValidTo)
            {
                view.SetErrorForValidToIsInThePast();
                hasError = true;
            }
            return hasError;
        }
    }
}