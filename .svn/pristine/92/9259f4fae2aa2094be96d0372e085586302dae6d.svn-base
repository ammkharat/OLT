using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core.Internal;
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
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormLubesAlarmDisableFormPresenter :
        AbstractFormEdmontonFormPresenter<LubesAlarmDisableForm, IFormLubesAlarmDisableFormView>
    {
        private readonly IAuthorized authorized;
        private readonly IFormEdmontonService service;
        private List<string> criticalityChoices;
        private FormTemplate formTemplate;
        private string originalAlarm;
        private string originalCriticality;

        private FunctionalLocation originalFunctionalLocation;
        private string originalLocationText;

        private List<string> originalListOfApprovers;
        private string originalPlainTextContent;

        private string originalSapNotification;

        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;

        public FormLubesAlarmDisableFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public FormLubesAlarmDisableFormPresenter(LubesAlarmDisableForm form)
            : base(new FormLubesAlarmDisableForm(), form)
        {
            SaveOriginalFormValues();

            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            authorized = new Authorized();

            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandClicked += HandleExpandClicked;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.HistoryButtonClicked += HandleHistoryButtonClicked;

            ApprovalRelatedEventsEnabled = true;
        }

        private bool ApprovalRelatedEventsEnabled
        {
            set
            {
                if (value)
                {
                    view.CriticalityChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.AlarmChanged += HandleChangeToSomethingThatChangesApprovals;
                    view.ValidityDatesChanged += HandleChangeToSomethingThatChangesApprovals;
                }
                else
                {
                    view.CriticalityChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.AlarmChanged -= HandleChangeToSomethingThatChangesApprovals;
                    view.ValidityDatesChanged -= HandleChangeToSomethingThatChangesApprovals;
                }
            }
        }

        private void HandleBrowseFunctionalLocationButtonClicked()
        {
            var userHasChangedLocation = HasTheUserChangedTheLocation();

            var result =
                view.ShowFunctionalLocationSelector(view.SelectedFunctionalLocation);

            if (result.Result == DialogResult.OK)
            {
                var floc = result.Output;
                view.SelectedFunctionalLocation = floc;

                if (!userHasChangedLocation)
                {
                    view.LocationText = WorkPermitEdmonton.GetLocation(floc);
                }
            }
        }

        private bool HasTheUserChangedTheLocation()
        {
            // This is because, for some reason, the OLT text box likes to return "" even after it's been set to null.
            var locationTextValue = string.IsNullOrEmpty(view.LocationText) ? null : view.LocationText;

            return (locationTextValue != WorkPermitEdmonton.GetLocation(view.SelectedFunctionalLocation));
        }

        private void SaveOriginalFormValues()
        {
            originalFunctionalLocation = editObject.FunctionalLocation;
            originalLocationText = editObject.Location;
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalAlarm = editObject.Alarm;
            originalCriticality = editObject.Criticality;
            originalSapNotification = editObject.SapNotification;
            originalListOfApprovers =
                editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static LubesAlarmDisableForm CreateDefaultForm()
        {
            var now = Clock.Now;
            var currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;         //ayman generic forms

            var form = new LubesAlarmDisableForm(null, FormStatus.Draft, now, now, currentUser, now);   //ayman generic forms
            form.SetDefaultDatesBasedOnShift(WorkPermitLubes.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            editObject.FunctionalLocation = view.SelectedFunctionalLocation;
            editObject.Location = view.LocationText;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.Alarm = view.Alarm;
            editObject.Criticality = view.Criticality;
            editObject.SapNotification = view.SapNotification;
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
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.LubesAlarmDisable.Name, editObject.FormNumber);
        }

        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;

            view.SelectedFunctionalLocation = editObject.FunctionalLocation;
            view.LocationText = editObject.Location;

            UpdateViewApprovalsFromEditObject();
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;

            view.Content = editObject.Content;
            view.DocumentLinks = editObject.DocumentLinks;

            view.CriticalityChoices = criticalityChoices;

            view.Alarm = editObject.Alarm;
            view.Criticality = editObject.Criticality;
            view.SapNotification = editObject.SapNotification;

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
            editObject.EnabledApprovals.ForEach(CheckToDisableEdit);
            view.Approvals = editObject.EnabledApprovals;
        }

        /// <summary>
        ///     Only enable the appropriate Approvals Checkboxes if:
        ///     "Lead Tech" - if the user has the security role element "Approve Form - Lubes Temporary Alarm Disable".
        ///     "Supervisor" - if the user has the security role element "Approve Form - Lubes Temporary Alarm Disable".
        ///     "Process Engineer" - if the user has the security role element "Approve Form - Lubes CSD - Process Engineer". (and
        ///     it's shown)
        ///     "Lead Tech" - if the user has the security role element "Approve Form - Lubes CSD - Lead Tech".
        ///     "Area Team Lead/Supervisor" - if the user has the security role element "Approve Form - Lubes CSD - Area Team
        ///     Lead".
        ///     "Director of Production" - if the user has the security role element "Approve Form - Lubes CSD - Director of
        ///     Production". (and it's shown)
        /// </summary>
        private void CheckToDisableEdit(FormApproval approval)
        {
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            if (approval.Approver.StartsWith("Lead Tech"))
            {
                approval.DisableEdit =
                    !authorized.ToApproveLubesAlarmDisableLeadTech(userRoleElements);
            }

            if (approval.Approver.StartsWith("Supervisor"))
            {
                approval.DisableEdit =
                    !authorized.ToApproveLubesAlarmDisableSupervisor(userRoleElements);
            }
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertLubesAlarmDisable,
                    editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateLubesAlarmDisable,
                editObject);
        }

        private void HandleHistoryButtonClicked()
        {
            LaunchEditHistoryForm();
        }

        protected void LaunchEditHistoryForm()
        {
            var presenter = new LubesAlarmDisableHistoryFormPresenter(editObject);
            presenter.Run(view);
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
            return editObject.WillNeedReapproval(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFunctionalLocation,
                originalLocationText,
                ClientSession.GetUserContext().User,
                authorized.ToChangeEndDateOfLubesAlarmDisableWithNoReapprovalRequired(
                    ClientSession.GetUserContext().UserRoleElements),
                originalCriticality,
                originalAlarm);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFunctionalLocation,
                originalLocationText,
                ClientSession.GetUserContext().User,
                authorized.ToChangeEndDateOfLubesAlarmDisableWithNoReapprovalRequired(
                    ClientSession.GetUserContext().UserRoleElements),
                originalCriticality,
                originalAlarm);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> {QueryFormTemplate, LoadCriticalityDropdownValues});
        }

        private void LoadCriticalityDropdownValues()
        {
            var dropdownValues = ClientServiceRegistry.Instance.GetService<IDropdownValueService>()
                .QueryByKey(userContext.SiteId, LubesAlarmDisableDropDownValueKeys.Criticality);
            criticalityChoices = LubesAlarmDisableDropDownValueKeys.CriticalityDropdownValues(dropdownValues);
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormLubesAlarmDisableFormTitle);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();
        }

        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.LubesAlarmDisable,ClientSession.GetUserContext().SiteId)[0];    // ayman generic forms
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

            if (view.LocationText.IsNullOrEmpty())
            {
                view.SetErrorForEmptyLocation();
                hasError = true;
            }

            if (view.Criticality.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyCriticality();
                hasError = true;
            }

            if (view.Alarm.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyAlarm();
                hasError = true;
            }

            if (Clock.Now > view.ValidTo)
            {
                view.SetErrorForValidToIsInThePast();
                hasError = true;
            }

//            if (view.ValidTo < view.ValidFrom)
//            {
//                view.SetErrorForExpiresDateBeforeDisabledOnDate();
//                hasError = true;
//            }

            if (view.ValidTo.Subtract(view.ValidFrom).Days > 30)
            {
                view.SetErrorForTotalDurationExceeds30Days();
                hasError = true;
            }

            return hasError;
        }
    }
}