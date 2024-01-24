using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
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
    public class FormGenericTemplateFormPresenter : AbstractFormEdmontonFormPresenter<FormGenericTemplate, IFormGenericTemplateView>
    {

        private readonly IFormGenericTemplateService service;
        private static IFormGenericTemplateService service1;
        private FormTemplate formTemplate;

        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalPlainTextContent;
        private List<FunctionalLocation> originalFlocs;

        private List<string> originalListOfApprovers;

        private string buttontext;

        EdmontonFormType formtype { get; set; }

        public FormGenericTemplateFormPresenter()
            : this(CreateDefaultForm(null))
        {
        }

        public FormGenericTemplateFormPresenter(EdmontonFormType edmontonFormType)
            : this(CreateDefaultForm(edmontonFormType))
        {
            //if (!CreateForm(edmontonFormType)) return;

            formtype = edmontonFormType;
            //DMND0009363-#950321920-Mukesh
            showneverEndcheck(formtype.IdValue);
        }

        private bool CreateForm(EdmontonFormType formType)
        {
            var userRoleElements = userContext.UserRoleElements;
            bool canCreate = false;
            if (formType == EdmontonFormType.OdourNoiseComplaint)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ODOURNOISE);
            }
            else if (formType == EdmontonFormType.Deviation)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DEVIATION);
            }
            else if (formType == EdmontonFormType.RoadClosure)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ROADCLOSURE);
            }
            else if (formType == EdmontonFormType.GN11GroundDisturbance)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN11GROUNDDISTURBANCE);
            }
            else if (formType == EdmontonFormType.GN27FreezePlug)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN27FREEZEPLUG);
            }
            else if (formType == EdmontonFormType.HazardAssessment)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_HAZARDASSESSMENT);
            }
            //TASK0593631 - mangesh
            if (formType == EdmontonFormType.NonEmergencyWaterSystemApproval)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_NonEmergencyWaterSystemApproval);
            }
            // RITM0341710 mangesh
            else if (formType == EdmontonFormType.FortHillOilSample)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_OILSAMPLE);
            }
            else if (formType == EdmontonFormType.FortHillDailyInspection)
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DAILYINSPECTION);
            }
            return canCreate;
        }

        public FormGenericTemplateFormPresenter(FormGenericTemplate form)
            : base(new FormGenericTemplateForm(), form)
        {
            formtype = form.FormType;
            SaveOriginalFormValues();

            service = ClientServiceRegistry.Instance.GetService<IFormGenericTemplateService>();

            view.AddFunctionalLocationButtonClicked += HandleAddFunctionalLocationButtonClicked;
            view.RemoveFunctionalLocationButtonClicked += HandleRemoveFunctionalLocationButtonClicked;
            view.FormLoad += HandleViewLoad;
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandClicked += HandleExpandClicked;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked;
            ApprovalRelatedEventsEnabled = true;
            //DMND0009363-#950321920-Mukesh
            view.NeverEndCheckChanged += NeverEndCheckChanged;
            if(formtype!=null)
            showneverEndcheck(formtype.IdValue);
           
        }
       
        //DMND0009363-#950321920-Mukesh
        private void NeverEndCheckChanged()
        {
            view.neverEndchecked = view.neverEndchecked;
        }

        //waiting for approval button status
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

        //private void HandleApprovalSelected(FormApproval approval)
        //{
        //    UpdateWaitingForApprovalButtonStatus();
        //}

        //private void HandleApprovalUnselected(FormApproval approval)
        //{
        //    UpdateWaitingForApprovalButtonStatus();
        //}

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            //originalDepartment = editObject.Department;
            //originalPressureSafetyValveAnswer = editObject.IsTheCSDForAPressureSafetyValve;
            //originalCriticalSystemDefeated = editObject.CriticalSystemDefeated;
            originalListOfApprovers = editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static FormGenericTemplate CreateDefaultForm(EdmontonFormType edmontonFormType)
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            //generic forms
            UserContext context = ClientSession.GetUserContext();
            long siteid = context.Site.IdValue;
            long plantid = context.Site.Plants[0].IdValue; //INC0251500 - mangesh
            Role createdByRole = context.Role;

            FormGenericTemplate form = new FormGenericTemplate(null, FormStatus.Draft, now, now, currentUser, now, siteid, edmontonFormType, createdByRole);
            service1 = ClientServiceRegistry.Instance.GetService<IFormGenericTemplateService>();
            form.Approvals = service1.QueryFormGenericTemplateEFormApproverByIdAndSiteId(siteid, edmontonFormType.Value, plantid);

            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            //generic forms
            editObject.SiteId = userContext.SiteId;
            editObject.FormTypeId = formtype.Value;
            editObject.PlantId = userContext.Site.Plants[0].IdValue; //INC0251500- mangesh
            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.DocumentLinks = view.DocumentLinks;
            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            editObject.Approvals = viewApprovals;
        }

        protected override void ShowEmail()
        {
            //Dharmesh 14-Feb-2018 start -- FOR INC0250954 - All Eform Email alert message pointing to OP14
            string name = Convert.ToString(FormGenericTemplate.getEdmontonFormType(editObject.FormTypeId));
            FormEdmontonPagePresenterHelper.ShowEmail(name, editObject.FormNumber);
            //Dharmesh 14-Feb-2018 End -- FOR INC0250954 - All Eform Email alert message pointing to OP14
        }

        private void UpdateViewFromEditObject()
        {
            ApprovalRelatedEventsEnabled = false;

            view.FunctionalLocations = editObject.FunctionalLocations;
            UpdateViewApprovalsFromEditObject();
            view.ValidTo = editObject.ToDateTime;
            //DMND0009363-#950321920-Mukesh
            if(view.ValidTo.ToDate()==new Com.Suncor.Olt.Common.Domain.Date(Convert.ToDateTime("12/31/9998")) )
            {
                view.neverEndchecked = true;
                view.neverEndvisible = true;
            }

            view.ValidFrom = editObject.FromDateTime;

            view.Content = editObject.Content;
            view.DocumentLinks = editObject.DocumentLinks;

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();


            UpdateWaitingForApprovalButtonStatus(); //waiting for approval status
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, editObject);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((System.Windows.Forms.Control)(sender)).Name;
            Save(false, buttontext);
        }

        private void HandleWaitingApprovalClicked()
        {
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
            List<string> currentUnapprovedApprovers = editObject.Approvals.FindAll(approval => approval.Enabled && !approval.IsApproved).ConvertAll(approval => approval.Approver);
            return (currentUnapprovedApprovers.Exists(approver => !originalListOfApprovers.Contains(approver)));
        }

        //INC0280983 mangesh
        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(
                originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User,
                null, false, string.Empty);
        }

        //INC0280983 mangesh
        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User,
                null, false, String.Empty);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> { QueryFormTemplate });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, formtype.Name);

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

            UpdateViewFromEditObject();

            Authorized authorized = new Authorized();
            view.ApprovalsEnabled = //= authorized.ToApproveOilsandsTrainingForm(ClientSession.GetUserContext().UserRoleElements);
                                authorized.ToApproveOrCloseFormGenericTemplate(ClientSession.GetUserContext().UserRoleElements, editObject.FormStatus,
                                            FormGenericTemplate.getEdmontonFormType(editObject.FormTypeId), userContext.Site);
        }


        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(formtype, ClientSession.GetUserContext().SiteId)[0];
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

        protected override bool ValidateViewHasError()
        {
            bool hasError = base.ValidateViewHasError();

            if (Clock.Now > view.ValidTo)
            {
                ((IFormGenericTemplateView)view).SetErrorForValidToIsInThePast();
                hasError = true;
            }
            return hasError;
        }


        //DMND0009363-#950321920-Mukesh
        private void showneverEndcheck(long FormTypeId)
        {          
            Site site = ClientSession.GetUserContext().Site;
            long plantId = site.Plants[0].IdValue;
            IGenericTemplateService GenericTemplateService = ClientServiceRegistry.Instance.GetService<IGenericTemplateService>();
            List<GenericTemplateApproval> eFormTypeList = GenericTemplateService.QueryForEGenericForms(site, plantId);
            view.neverEndvisible = eFormTypeList.Find(E => E.FormTypeId == FormTypeId).ShowneverEnd;
            //End DMND0009363-#950321920-Mukesh
        }
    }

}
