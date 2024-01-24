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

namespace Com.Suncor.Olt.Client.Presenters
{
    public class EdmontonPipelineOP14Presenter : AbstractFormEdmontonFormPresenter<FormOP14, IFormOP14View>
    {
        
        private readonly IFormEdmontonService service;
        private FormTemplate formTemplate;
        private List<FormApproval> approvals = new List<FormApproval>();      //ayman Sarnia eip DMND0008992
        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalPlainTextContent;
        private List<FunctionalLocation> originalFlocs;
        private FormOP14Department originalDepartment;
        private bool originalPressureSafetyValveAnswer;
        private string originalCriticalSystemDefeated;

        private List<string> originalListOfApprovers;

        private string buttontext;

        public EdmontonPipelineOP14Presenter() : this(CreateDefaultForm())
        {
        }

        public EdmontonPipelineOP14Presenter(FormOP14 form)
            : base(new EdmontonPipelineOP14Form(), form)
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
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked; // Swapnil Patki For DMND0005325 Point Number 7
            ApprovalRelatedEventsEnabled = true;

           
        }

        //ayman waiting for approval button status
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

      
        public List<FormApproval> Approvals
        {
            get { return approvals; }
            set { approvals = value; }
        }

      
        public virtual List<FormApproval> AllApprovals
        {
            get { return Approvals; }
        }

      

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
            originalDepartment = editObject.Department;
            originalPressureSafetyValveAnswer = editObject.IsTheCSDForAPressureSafetyValve;
            originalCriticalSystemDefeated = editObject.CriticalSystemDefeated;
            originalListOfApprovers = editObject.Approvals.FindAll(approval => approval.Enabled).ConvertAll(approval => approval.Approver);
        }

        private static FormOP14 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;
            
            //ayman generic forms
            long siteid = ClientSession.GetUserContext().Site.IdValue;


            FormOP14 form = new FormOP14(null, FormStatus.Draft, now, now, currentUser, now,siteid);   //ayman generic forms
           form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected override void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            
            //ayman generic forms
            editObject.SiteId = userContext.SiteId;

            editObject.FunctionalLocations = view.FunctionalLocations;
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.Department = view.Department;
            editObject.IsTheCSDForAPressureSafetyValve = view.IsTheCSDForAPressureSafetyValve;
            editObject.CriticalSystemDefeated = view.CriticalSystemDefeated;
            editObject.DocumentLinks = view.DocumentLinks;
           editObject.IsSCADASupport = view.IsSCADASupport;

            UpdateEditObjectApprovalsFromView();
        }

        private void UpdateEditObjectApprovalsFromView()
        {
            List<FormApproval> viewApprovals = new List<FormApproval>(view.Approvals);
            viewApprovals.AddRange(editObject.Approvals.FindAll(approval => !approval.Enabled));
            DisplayOrderHelper.SortAndResetDisplayOrder(viewApprovals);
            
            //TO disable approvalbased on role
            bool enableEdit=ClientSession.GetUserContext().UserRoleElements.HasRoleElement(RoleElement.Pipeline_CSD_APPROVAL);
            foreach (FormApproval app in viewApprovals)
            {
                app.DisableEdit = !enableEdit;
            }
            editObject.Approvals = viewApprovals;
        }

        protected override void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.OP14.Name, editObject.FormNumber);
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
            view.CriticalSystemDefeated = editObject.CriticalSystemDefeated;
            if (view.FunctionalLocations.Count > 0)
            {
                view.Department = editObject.Department;
                view.IsTheCSDForAPressureSafetyValve = editObject.IsTheCSDForAPressureSafetyValve;
                view.IsSCADASupport = editObject.IsSCADASupport;
            }

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            ApprovalRelatedEventsEnabled = true;
            
            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();


            UpdateWaitingForApprovalButtonStatus(); //ayman waiting for approval status
        }

        private void UpdateViewApprovalsFromEditObject()
        {
            view.Approvals = editObject.EnabledApprovals;
        }

        protected override List<NotifiedEvent> RawInsert()   
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertOP14, editObject);
        }


        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateOP14, editObject);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            buttontext = ((System.Windows.Forms.Control)(sender)).Name; // Swapnil Patki For DMND0005325 Point Number 7
            Save(false, buttontext);
        }

        private void HandleWaitingApprovalClicked() // Swapnil Patki For DMND0005325 Point Number 7
        {
            Save(false, buttontext);
        }

        private void Save(bool showEmail, string buttontext)
        {
            if (Validate())
            {
                return;
            }
            /*Sarnia CSD marked as read start*/
            if (IsEdit && service.UserMarkedFormOp14AsRead(editObject.FormNumber, null, Convert.ToInt64(ClientSession.GetUserContext().UserShift.ShiftPatternId)).Count > 0) //if record is edited and Mark as read count is grated than 0
            {
                if ((!view.ShowLogMarkedAsReadWarning()))
                {
                    return;
                }
            }
            /*CSD marked as read end*/
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

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(
                originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User, 
                originalDepartment, originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return editObject.SomethingRequiringReapprovalHasChanged(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User,
                originalDepartment, originalPressureSafetyValveAnswer, originalCriticalSystemDefeated);
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> { QueryFormTemplate });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, "Critical System Defeat");

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                editObject.Content = formTemplate.Template;
            }

          
            UpdateViewFromEditObject();         
        }

        
       private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.OP14,ClientSession.GetUserContext().SiteId)[0];        //ayman generic forms
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

            if(view.CriticalSystemDefeated.IsNullOrEmptyOrWhitespace())
            {
                ((IFormOP14View) view).SetErrorForEmptyOP14CriticalSystemDefeated();
                hasError = true;
            }
           

            if (Clock.Now > view.ValidTo)
            {
                ((IFormOP14View) view).SetErrorForValidToIsInThePast();
                hasError = true;
            }
            return hasError;
        }
    }
}
