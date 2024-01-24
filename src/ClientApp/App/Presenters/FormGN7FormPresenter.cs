using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN7FormPresenter : AbstractFormEdmontonFormPresenter<FormGN7, IFormView>
    {
        private readonly IFormEdmontonService service;
        private FormTemplate formTemplate;

        private DateTime originalValidFromDateTime;
        private DateTime originalValidToDateTime;
        private string originalPlainTextContent;
        private List<FunctionalLocation> originalFlocs;
        public string buttontext; // Swapnil Patki For DMND0005325 Point Number 7

        public FormGN7FormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormGN7FormPresenter(FormGN7 form) : base(new FormForm(), form)
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
        }

        private void SaveOriginalFormValues()
        {
            originalValidFromDateTime = editObject.FromDateTime;
            originalValidToDateTime = editObject.ToDateTime;
            originalPlainTextContent = editObject.PlainTextContent;
            originalFlocs = new List<FunctionalLocation>(editObject.FunctionalLocations);
        }

        private static FormGN7 CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            long siteid = ClientSession.GetUserContext().SiteId;      //ayman generic forms

            FormGN7 form = new FormGN7(null, FormStatus.Draft, now, now, currentUser, now, siteid);         //ayman generic forms
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
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.Approvals = view.Approvals;
            
        }

        private void UpdateViewFromEditObject()
        {
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;
            view.Approvals = editObject.Approvals;
            view.DocumentLinks = editObject.DocumentLinks;

            if (editObject.Content.IsNullOrEmptyOrWhitespace())
            {
                view.Content = formTemplate.Template;
            }
            else
            {
                view.Content = editObject.Content;
            }

            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;


            //ayman enable/disable waiting for approval button
            if (editObject.AllApprovalsAreIn())
            {
                view.DisableWaitingForApprovalButton();
            }
            else
            {
                view.EnableWaitingForApprovalButton();
            }



        }

        protected override List<NotifiedEvent> RawInsert()
        {
            return ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.InsertGN7, editObject);            
        }

       
        protected override void Update()
        {
            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateGN7, editObject, attributesForHazardsLabel);
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

            UpdateEditObjectFromView();

            if (IsEdit && FormWillNeedReapproval())
            {
                DialogResult result = view.ShowFormWillNeedReapprovalQuestion();

                if (result == DialogResult.Yes)
                {
                    editObject.FormStatus = FormStatus.Draft;   // this is just for safety/clarity; if we're editing the form, it should already be in 'draft' mode
                    FormApproval.UnapproveApprovalsThatWereNotApprovedByUser(ClientSession.GetUserContext().User, view.Approvals);
                    SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext); // Swapnil Patki For DMND0005325 Point Number 7
                }
            }
            else
            {
                SaveWithApprovalCheckForEdmontonForm7And59(showEmail, buttontext); // Swapnil Patki For DMND0005325 Point Number 7
            }            
        }

        protected override void ShowEmail()
        {
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.GN7.Name, editObject.FormNumber);
        }

        private bool FormWillNeedReapproval()
        {
            return editObject.WillNeedReapproval(originalPlainTextContent, originalValidFromDateTime, originalValidToDateTime, originalFlocs, ClientSession.GetUserContext().User);
        }

        protected override bool SomethingRequiringReapprovalHasChanged()
        {
            return false;   // you can't edit a GN-7 if it has been approved, so this always returns false
        }

        private void HandleViewLoad()
        {
            LoadData(new List<Action> { QueryFormTemplate });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.FormGN7FormTitle);
            UpdateViewFromEditObject();
        }

        private void QueryFormTemplate()
        {
            formTemplate = service.QueryFormTemplatesByFormType(EdmontonFormType.GN7,ClientSession.GetUserContext().SiteId)[0];       //ayman generic forms
        }

        private void HandleSaveAndEmailClicked()
        {
            Save(true, buttontext);
        }
    }
}
