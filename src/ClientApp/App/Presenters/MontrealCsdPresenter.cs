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

namespace Com.Suncor.Olt.Client.Presenters
{
    public class MontrealCsdPresenter : AbstractFormEdmontonFormPresenter<MontrealCsd, IFormMontrealCsdView>
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

        public MontrealCsdPresenter()
            : this(CreateDefaultForm())
        {
        }

        public MontrealCsdPresenter(MontrealCsd form)
            : base(new FormMontrealCsdForm(), form)
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
            EditHistoryFormPresenter presenter = new MontrealCsdHistoryPresenter(editObject);
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
            originalListOfApprovers =
                editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static MontrealCsd CreateDefaultForm()
        {
            var now = Clock.Now;
            var currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;          //ayman generic forms

            var form = new MontrealCsd(null, FormStatus.Draft, now, now, currentUser, now);     //ayman generic forms
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
            editObject.HasBeenCommunicated = view.HasBeenCommunicated;
            editObject.HasAttachments = view.HasAttachments;
            editObject.IsTheCSDForAPressureSafetyValve = view.IsTheCSDForAPressureSafetyValve;
            editObject.CriticalSystemDefeated = view.CriticalSystemDefeated;
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
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.MontrealCsd.Name, editObject.FormNumber);
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

            view.HasAttachments = editObject.HasAttachments;
            view.HasBeenCommunicated = editObject.HasBeenCommunicated;
            view.IsTheCSDForAPressureSafetyValve = editObject.IsTheCSDForAPressureSafetyValve;
            view.CriticalSystemDefeated = editObject.CriticalSystemDefeated;
            view.CsdReason = editObject.CsdReason;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertMontrealCsd,
                editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateMontrealCsd,
                editObject);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            Save(false);
        }

        private void Save(bool showEmail)
        {
            if (Validate())
            {
                return;
            }

            UpdateEditObjectFromView();

            var formWillNeedReapproval = FormWillNeedReapproval();

            if (IsEdit && !formWillNeedReapproval && NewApproversWereAddedButNotApproved())
            {
                var result = view.ShowFormHasAdditionalApproversRequired();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    SaveWithApprovalCheck(showEmail);
                }
            }
            else if (IsEdit && formWillNeedReapproval)
            {
                var result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;

                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User,
                        view.Approvals);
                    SaveWithApprovalCheck(showEmail);
                }
            }
            else
            {
                SaveWithApprovalCheck(showEmail);
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
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormMontrealCsdFormTitle);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();
        }

        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.MontrealCsd,ClientSession.GetUserContext().SiteId)[0];    //ayman generic forms
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true);
        }

        private void HandleChangeToSomethingThatChangesApprovals()
        {
            UpdateEditObjectFromView();
            editObject.Approvals.ForEach(approval =>
            {
                approval.Enabled = approval.ShouldBeEnabled(editObject, Clock.Now);
                
                //Added new for SO # 8003623390:: Montreal Critical System Defeat issue post  

                if (view.IsTheCSDForAPressureSafetyValve == true && approval.Approver.ToLower().StartsWith("directeur"))
                {
                    approval.Enabled = true;
                }
                else if (view.IsTheCSDForAPressureSafetyValve == false && approval.Approver.ToLower().StartsWith("directeur"))
                {
                    approval.Enabled = false;
                }
                else if (view.IsTheCSDForAPressureSafetyValve == false && approval.Approver.ToLower().StartsWith("manager opération (> 72 heures)"))
                {
                    approval.Enabled = true;
                }
                // Till here SO # 8003623390

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

            if (view.CriticalSystemDefeated.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyCriticalSystemDefeated();
                hasError = true;
            }

            if (view.FunctionalLocations.Count < 1)
            {
                view.SetErrorForNoFunctionalLocationSelected();
                hasError = true;
            }

            if (!view.IsTheCSDForAPressureSafetyValve.HasValue)
            {
                view.SetErrorForNoPressureSafetyValveResponse();
                hasError = true;
            }
            if (!view.HasAttachments.HasValue)
            {
                view.SetErrorForNoHasAttachmentsResponse();
                hasError = true;
            }
            if (!view.HasBeenCommunicated.HasValue)
            {
                view.SetErrorForNoHasBeenCommunicatedResponse();
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