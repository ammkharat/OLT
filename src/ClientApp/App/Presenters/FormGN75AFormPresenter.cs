using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Presenters.Page;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FormGN75AFormPresenter : AddEditBaseFormPresenter<IFormGN75AView, FormGN75A>
    {
        private readonly IFormEdmontonService service;        
        private FormTemplate formTemplate;
        private bool saveWasSuccessful;

        private FunctionalLocation originalFloc;
        private DateTime originalFromDateTime;
        private DateTime originalToDateTime;
        private string originalPlainTextContent;
        private long? originalGN75BAssociationId;        
        private List<DocumentLink> originalDocumentLinks;

        private readonly IReportPrintManager<FormGN75B> reportPrintManager;

        private bool isClone;

        private string buttontext;

        public FormGN75AFormPresenter() : this(CreateDefaultForm())
        {
        }

        public FormGN75AFormPresenter(FormGN75A form) : this(form, false)
        {
        }

        public FormGN75AFormPresenter(FormGN75A form, bool isClone) : base(new FormGN75AForm(), form)
        {
            this.isClone = isClone;
            SaveOriginalFormValues(form);

            service = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();            

            view.FormLoad += HandleFormLoad;
            view.SaveAndEmailButtonClicked += HandleSaveAndEmailClicked;
            view.WaitingApprovalButtonClicked += HandleWaitingApprovalClicked; // Swapnil Patki For DMND0005325 Point Number 7
            view.HistoryButtonClicked += HandleHistoryButtonClicked;
            view.BrowseFunctionalLocationButtonClicked += HandleBrowseFunctionalLocationButtonClicked;            
            view.ApprovalSelected += HandleApprovalSelected;
            view.ApprovalUnselected += HandleApprovalUnselected;
            view.ExpandContentClicked += HandleExpandContentClicked;
            view.AssociateFormGN75BButtonClicked += HandleAssociateFormGN75BButtonClicked;
            view.RemoveFormGN75BButtonClicked += HandleRemoveFormGN75BButtonClicked;
            view.ViewFormGN75BButtonClicked += HandleViewFormGN75BButtonClicked;

            PrintActions<FormGN75B, FormGN75BReport, FormGN75BReportAdapter> printActions = new EdmontonGN75BFormPrintActions(service);
            reportPrintManager = new ReportPrintManager<FormGN75B, FormGN75BReport, FormGN75BReportAdapter>(printActions);
        }

        // In this presenter, we store the new object as the edit object so the base class's clone doesn't work.
        protected override bool IsClone
        {
            get { return isClone; }            
        }

        private void HandleExpandContentClicked()
        {
            view.DisplayExpandedContentForm();
        }
      
        private void HandleHistoryButtonClicked()
        {            
            EditFormGN75AHistoryFormPresenter presenter = new EditFormGN75AHistoryFormPresenter(editObject);
            presenter.Run(view);
        }
      
        private void HandleFormLoad()
        {
            List<FormTemplate> templates = service.QueryFormTemplatesByFormType(EdmontonFormType.GN75A,ClientSession.GetUserContext().SiteId);   //ayman generic forms

            if (templates.Count == 1)
            {
                formTemplate = templates[0];
            }

            view.UpdateTitleAsCreateOrEdit(IsEdit, EdmontonFormType.GN75A.GetName());                      
            view.HistoryButtonEnabled = IsEdit;

            UpdateViewFromEditObject();
            view.EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();
        }
       
        private void SaveOriginalFormValues(FormGN75A form)
        {
            originalFloc = form.FunctionalLocation;
            originalFromDateTime = form.FromDateTime;
            originalToDateTime = form.ToDateTime;
            originalPlainTextContent = form.PlainTextContent;
            originalGN75BAssociationId = form.AssociatedFormGN75BNumber;
            originalDocumentLinks = form.DocumentLinks;
        }

        private static FormGN75A CreateDefaultForm()
        {
            DateTime now = Clock.Now;
            User currentUser = ClientSession.GetUserContext().User;

            FormGN75A form = new FormGN75A(null, FormStatus.Draft, now, now, currentUser, now, ClientSession.GetUserContext().SiteId);       //ayman generic forms
            form.SetDefaultDatesBasedOnShift(WorkPermitEdmonton.IsDayShift(now.ToTime()), now.ToDate(), now.ToTime());
            return form;
        }

        protected void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;

            //ayman generic forms
            long siteid = userContext.SiteId;

            editObject.SiteId = siteid;

            editObject.FunctionalLocation = view.SelectedFunctionalLocation;            
            editObject.FromDateTime = view.ValidFrom;
            editObject.ToDateTime = view.ValidTo;
            editObject.Content = view.Content;            
            editObject.PlainTextContent = view.PlainTextContent;
            editObject.AssociatedFormGN75BNumber = view.FormGN75BId;
            editObject.DocumentLinks = view.DocumentLinks;

            UpdateEditObjectApprovalsFromView();           
        }

        private void UpdateViewFromEditObject()
        {            
            view.SelectedFunctionalLocation = editObject.FunctionalLocation;
            view.ValidTo = editObject.ToDateTime;
            view.ValidFrom = editObject.FromDateTime;           
            view.DocumentLinks = editObject.DocumentLinks;

            UpdateViewApprovalsFromEditObject();

            if (!IsEdit && !IsClone)
            {      
                view.Content = formTemplate != null ? formTemplate.Template : null;                
            }
            else
            {
                view.Content = editObject.Content;
            }
           
            view.CreatedByUser = editObject.CreatedBy;
            view.CreatedDateTime = editObject.CreatedDateTime;

            view.LastModifiedByUser = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            
            view.FormGN75BId = editObject.AssociatedFormGN75BNumber;

            // force the approvals to update
            HandleChangeToSomethingThatChangesApprovals();
        
        //ayman enable/disable waiting for approval button
            UpdateWaitingForApprovalButton();

        }


        //ayman enable/disable waiting for approval button
        private void UpdateWaitingForApprovalButton()
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

            return hasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            FormGN75A form = ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.FormGN75ACreate, service.InsertGN75A, editObject);
            editObject.Id = form.Id;
        }

        private void HandleApprovalUnselected(FormApproval approval)
        {
            approval.ApprovedByUser = null;
            approval.ApprovalDateTime = null;

            //ayman enable/disable waiting for approval button
            UpdateWaitingForApprovalButton();
        }

        private void HandleApprovalSelected(FormApproval approval)
        {
            approval.ApprovedByUser = ClientSession.GetUserContext().User;
            approval.ApprovalDateTime = Clock.Now;

            //ayman enable/disable waiting for approval button
            UpdateWaitingForApprovalButton();
        }

        protected override void Update()
        {
            LabelAttributes attributesForHazardsLabel = WorkPermitEdmontonReport.GetAttributesForHazardsLabel();

            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateGN75A, editObject, attributesForHazardsLabel);
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

            if (!editObject.AssociatedFormGN75BNumber.HasValue && (editObject.DocumentLinks != null && editObject.DocumentLinks.Count == 0))
            {
                DialogResult result = view.DisplayNoAssociatedGN75BFormDialog();

                if (DialogResult.Yes == result)
                {
                    return;
                }
            }

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
      
        protected void SaveWithApprovalCheck(bool showEmail)
        {
            UpdateEditObjectFromView();

            if (editObject.AllApprovalsAreIn())
            {
                DateTime? approvalDateTime;

                if (IsEdit && !SomethingRequiringReapprovalHasChanged())
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
               // editObject.MarkAsUnapproved();
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
            FormEdmontonPagePresenterHelper.ShowEmail(EdmontonFormType.GN75A.Name, editObject.FormNumber);
        }

        private bool FormWillNeedReapproval()
        {            
            Authorized authorized = new Authorized();
            User currentUser = ClientSession.GetUserContext().User;
            
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN75AWithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.WillNeedReapproval(currentUser, noReapprovalRequiredForEndDateChange, originalFloc, originalFromDateTime, originalToDateTime, originalPlainTextContent, originalGN75BAssociationId, originalDocumentLinks);
        }

        protected bool SomethingRequiringReapprovalHasChanged()
        {
            Authorized authorized = new Authorized();
            bool noReapprovalRequiredForEndDateChange = authorized.ToChangeEndDateOfGN75AWithNoReapprovalRequired(userContext.UserRoleElements);

            return editObject.SomethingRequiringReapprovalHasChanged(noReapprovalRequiredForEndDateChange, originalFloc, originalFromDateTime, originalToDateTime, originalPlainTextContent, originalGN75BAssociationId, originalDocumentLinks);                
        }

        protected void HandleBrowseFunctionalLocationButtonClicked()
        {           
            DialogResultAndOutput<FunctionalLocation> result = view.ShowFunctionalLocationSelector(view.SelectedFunctionalLocation);

            if (result.Result == DialogResult.OK)
            {
                FunctionalLocation newFloc = result.Output;
                view.SelectedFunctionalLocation = newFloc;
            }
        }

        private void HandleAssociateFormGN75BButtonClicked()
        {
            FormEdmontonGN75BDetails details = new FormEdmontonGN75BDetails("Form #","Location");               //ayman Sarnia eip DMND0008992
            FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails> formPage = new FormPage<FormEdmontonGN75BDTO, FormEdmontonGN75BDetails>(new FormEdmontonGN75BGridRenderer(),  details);

            SelectFormGN75BFormPresenter presenter = new SelectFormGN75BFormPresenter(formPage);

            // this has to be here because something in the Form Page or Presenter is setting RangeVisible to true. 
            // So set to false afterwards.
            details.RangeVisible = false;

            long? formId = view.FormGN75BId;

            DialogResultAndOutput<FormEdmontonGN75BDTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonGN75BDTO formDto = dialogResultAndOutput.Output;
                view.FormGN75BId = formDto.Id;
            }
        }

        private void HandleRemoveFormGN75BButtonClicked()
        {
            view.FormGN75BId = null;
        }

        private void HandleViewFormGN75BButtonClicked()
        {
            if (view.FormGN75BId.HasValue)
            {
                FormGN75B itemToPreview = service.QueryFormGN75BById(view.FormGN75BId.Value);
                reportPrintManager.PreviewReport(itemToPreview);            
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

        public DialogResultAndOutput<FormGN75A> RunAndReturnTheEditObject(IBaseForm parent)
        {
            Run(parent);

            if (saveWasSuccessful)
            {
                return new DialogResultAndOutput<FormGN75A>(DialogResult.OK, editObject);
            }

            return new DialogResultAndOutput<FormGN75A>(DialogResult.Cancel, null);
        }

        protected override void SaveOrUpdate(bool shouldCloseForm)
        {
            base.SaveOrUpdate(shouldCloseForm);
            saveWasSuccessful = true;
        }
    }
}
