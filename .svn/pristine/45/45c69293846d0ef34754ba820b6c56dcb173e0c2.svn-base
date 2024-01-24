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
    public class FormLubesCsdFormPresenter : AbstractFormEdmontonFormPresenter<LubesCsdForm, IFormLubesCsdFormView>
    {
        private readonly IAuthorized authorized;
        private readonly IFormEdmontonService service;
        private FormTemplate formTemplate;

        private string originalCriticalSystemDefeated;
        private FunctionalLocation originalFunctionalLocation;
        private string originalLocationText;

        private List<string> originalListOfApprovers;
        private string originalPlainTextContent;
        private bool? originalPressureSafetyValveAnswer;
        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;

        public FormLubesCsdFormPresenter()
            : this(CreateDefaultForm())
        {
        }

        public FormLubesCsdFormPresenter(LubesCsdForm form)
            : base(new FormLubesCsdForm(), form)
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
            EditHistoryFormPresenter presenter = new LubesCsdHistoryFormPresenter(editObject);
            presenter.Run(view);
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
            originalPressureSafetyValveAnswer = editObject.IsTheCSDForAPressureSafetyValve;
            originalCriticalSystemDefeated = editObject.CriticalSystemDefeated;
            originalListOfApprovers =
                editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static LubesCsdForm CreateDefaultForm()
        {
            var now = Clock.Now;
            var currentUser = ClientSession.GetUserContext().User;

            var siteid = ClientSession.GetUserContext().SiteId;     //ayman generic forms

            var form = new LubesCsdForm(null, FormStatus.Draft, now, now, currentUser, now);       //ayman generic forms
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
            editObject.IsTheCSDForAPressureSafetyValve = view.IsTheCSDForAPressureSafetyValve;
            editObject.CriticalSystemDefeated = view.CriticalSystemDefeated;
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
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.LubesCsd.Name, editObject.FormNumber);
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

            view.IsTheCSDForAPressureSafetyValve = editObject.IsTheCSDForAPressureSafetyValve;
            view.CriticalSystemDefeated = editObject.CriticalSystemDefeated;

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

        private void CheckToDisableEdit(FormApproval approval)
        {
/*             Only enable the appropriate Approvals Checkboxes if:
"Process Engineer" - if the user has the security role element "Approve Form - Lubes CSD - Process Engineer". (and it's shown)
"Lead Tech" - if the user has the security role element "Approve Form - Lubes CSD - Lead Tech".
"Area Team Lead/Supervisor" - if the user has the security role element "Approve Form - Lubes CSD - Area Team Lead".
"Director of Production" - if the user has the security role element "Approve Form - Lubes CSD - Director of Production". (and it's shown)  
 */
            var userRoleElements = ClientSession.GetUserContext().UserRoleElements;
            if (approval.Approver.StartsWith("Lead Tech"))
            {
                approval.DisableEdit =
                    ! authorized.ToApproveLubesCsdLeadTech(userRoleElements);
            }

            if (approval.Approver.StartsWith("Process Engineer"))
            {
                approval.DisableEdit =
                    ! authorized.ToApproveLubesCsdProcessEngineer(userRoleElements);
            }

            if (approval.Approver.StartsWith("Area Team Lead"))
            {
                approval.DisableEdit =
                    ! authorized.ToApproveLubesCsdAreaTeamLead(userRoleElements);
            }

            if (approval.Approver.StartsWith("Director of Production"))
            {
                approval.DisableEdit =
                    ! authorized.ToApproveLubesCsdDirectorOfProduction(userRoleElements);
            }
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertLubesCsd,
                editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateLubesCsd, editObject);
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
                authorized.ToChangeEndDateOfLubesCsdWithNoReapprovalRequired(
                    ClientSession.GetUserContext().UserRoleElements),
                originalPressureSafetyValveAnswer,
                originalCriticalSystemDefeated);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent,
                originalValidFromDateTime,
                originalValidToDateTime,
                originalFunctionalLocation,
                originalLocationText,
                authorized.ToChangeEndDateOfLubesCsdWithNoReapprovalRequired(
                    ClientSession.GetUserContext().UserRoleElements),
                originalPressureSafetyValveAnswer,
                originalCriticalSystemDefeated);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> {QueryFormTemplate});
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormLubesCsdFormTitle);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();
        }

        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.LubesCsd,ClientSession.GetUserContext().SiteId)[0];          // ayman generic forms
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

            if (view.CriticalSystemDefeated.IsNullOrEmptyOrWhitespace())
            {
                view.SetErrorForEmptyOP14CriticalSystemDefeated();
                hasError = true;
            }
            if (!view.IsTheCSDForAPressureSafetyValve.HasValue)
            {
                view.SetErrorForNoPressureSafetyValveResponse();
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