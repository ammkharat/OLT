using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Montreal;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Montreal;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitRequestMontrealFormPresenter : AddEditBaseFormPresenter<IPermitRequestMontrealFormView, PermitRequestMontreal>
    {
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IContractorService contractorService;
        private readonly IPermitAttributeService permitAttributeService;
        private readonly IPermitRequestMontrealService permitRequestService;
        private readonly IWorkPermitMontrealService workPermitService;

        private List<WorkPermitMontrealType> workPermitTypes;
        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;
        private List<WorkPermitMontrealGroup> groups;
        private List<PermitAttribute> attributesForSite;

        public PermitRequestMontrealFormPresenter() : this(CreateDefaultPermitRequest())
        {
        }

        public PermitRequestMontrealFormPresenter(PermitRequestMontreal request) 
            : base(new PermitRequestMontrealForm(), request)
        {
            craftOrTradeService = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            permitAttributeService = ClientServiceRegistry.Instance.GetService<IPermitAttributeService>();
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestMontrealService>();
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitMontrealService>();

            view.Load += HandleFormLoad;
            view.ViewEditHistoryButtonClicked += HandleViewEditHistoryButtonClick;
            view.FunctionalLocationButtonClicked += HandleFunctionalLocationButtonClick;
            view.SubmitAndCloseButtonClicked += HandleSubmitAndCloseButtonClick;
        }

        private static PermitRequestMontreal CreateDefaultPermitRequest()
        {
            DateTime now = Clock.Now;
            Date defaultDate = now.ToDate();

            PermitRequestMontreal request = new PermitRequestMontreal(
                null, null, null, defaultDate, defaultDate, null, null, null, null, null, null, null, null, null,
                DataSource.MANUAL, null, null, null, null,                
                ClientSession.GetUserContext().User, now, ClientSession.GetUserContext().User, now, null, PermitRequestCompletionStatus.Incomplete);

            return request;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { QueryPermitTypes, QueryCraftOrTrades, QueryContractors, QueryGroups, QueryAttributesForSite });
        }

        protected override void AfterDataLoad()
        {
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.PermitRequestFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;

            view.AllPermitTypes = workPermitTypes;
            view.AllCraftOrTrades = craftOrTrades;
            view.AllCompanies = contractors;
            view.AllRequestedByGroups = groups;
            
            List<PermitAttribute> attributes = new List<PermitAttribute>(attributesForSite);
            foreach (PermitAttribute attribute in editObject.Attributes)
            {
                if (!attributes.ExistsById(attribute))
                {
                    attributes.Add(attribute);
                }
            }
            view.AllAttributes = attributes;

            UpdateViewFromEditObject();
        }

        private void QueryAttributesForSite()
        {
            attributesForSite = permitAttributeService.QueryBySite(userContext.Site.IdValue);
        }

        private void QueryGroups()
        {
            groups = workPermitService.QueryAllGroups();
            groups.Insert(0, WorkPermitMontrealGroup.EMPTY);
        }

        private void QueryPermitTypes()
        {
            workPermitTypes = new List<WorkPermitMontrealType>(WorkPermitMontrealType.PERMIT_REQUEST_TYPES);
            workPermitTypes.Insert(0, WorkPermitMontrealType.NULL);
        }

        private void QueryCraftOrTrades()
        {
            craftOrTrades = craftOrTradeService.QueryBySite(userContext.Site);
            craftOrTrades.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
        }

        private void UpdateViewFromEditObject()
        {
            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            view.WorkPermitType = editObject.WorkPermitType;
            view.FunctionalLocations = editObject.FunctionalLocations;
            view.StartDate = editObject.StartDate;
            view.EndDate = editObject.EndDate;
            view.Trade = editObject.Trade;
            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.RequestedByGroup = editObject.RequestedByGroup;

            string operationDisplay = GetOperationNumberDisplay(editObject);
            view.OperationNumber = operationDisplay;
                       
            view.Description = editObject.Description;
            view.SapDescription = editObject.SapDescription;
            
            view.Company = editObject.Company;
            view.Supervisor = editObject.Supervisor;
            view.ExcavationNumber = editObject.ExcavationNumber;

            view.SelectedAttributes = editObject.Attributes;

            view.WorkOrderNumberEnabled = editObject.DataSource != DataSource.SAP;
            view.OperationNumberEnabled = editObject.DataSource != DataSource.SAP;
            view.SapDescriptionVisible = editObject.DataSource == DataSource.SAP && editObject.Description != editObject.SapDescription;

            view.DocumentLinks = editObject.DocumentLinks;
        }

        private string GetOperationNumberDisplay(PermitRequestMontreal permitRequest)
        {
            if (permitRequest.DataSource == DataSource.SAP)
            {
                return permitRequest.OperationNumberAndSubOperationNumberForDisplay;
            }

            return permitRequest.OperationNumber;
        }

        private void UpdateEditObjectFromView()
        {
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDateTime = Clock.Now;

            editObject.WorkPermitType = view.WorkPermitType;
            editObject.RequestedByGroup = view.RequestedByGroup;

            editObject.FunctionalLocations.Clear();
            if (view.FunctionalLocations != null)
            {
                editObject.FunctionalLocations.AddRange(view.FunctionalLocations);    
            }            

            editObject.StartDate = view.StartDate;
            editObject.EndDate = view.EndDate;
            editObject.Trade = view.Trade;
            editObject.WorkOrderNumber = view.WorkOrderNumber;
            
            if(editObject.DataSource != DataSource.SAP)
            {
                // These aren't editable when it's an SAP generated Permit Request, and we combine the operation number
                // and sub-operation number for display so we don't want to set it to that and accidentally save it.
                editObject.OperationNumber = view.OperationNumber;               
            }
                
                        
            editObject.Description = view.Description;

            editObject.Company = view.Company;
            editObject.Supervisor = view.Supervisor;
            editObject.ExcavationNumber = view.ExcavationNumber;

            editObject.Attributes.Clear();
            editObject.Attributes.AddRange(view.SelectedAttributes);

            editObject.DocumentLinks = view.DocumentLinks;
        }

        private void HandleFunctionalLocationButtonClick()
        {
            List<FunctionalLocation> flocs = view.ShowFunctionalLocationSelector(view.FunctionalLocations);
            if (flocs != null)
            {
                view.FunctionalLocations = flocs;
            }
        }

        private void HandleViewEditHistoryButtonClick()
        {
            EditPermitRequestMontrealHistoryFormPresenter presenter = new EditPermitRequestMontrealHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            PermitRequestMontrealValidator validator = new PermitRequestMontrealValidator(new PermitRequestMontrealValidationViewAdapter(view));
            validator.Validate(Clock.DateNow);

            editObject.CompletionStatus = validator.CompletionStatus;

            if (!validator.HasErrors)
            {
                SaveOrUpdate(true);
            }
        }

        private void HandleSubmitAndCloseButtonClick()
        {
            PermitRequestMontrealValidator validator = new PermitRequestMontrealValidator(new PermitRequestMontrealValidationViewAdapter(view));
            validator.Validate(Clock.DateNow);

            editObject.CompletionStatus = validator.CompletionStatus;

            if (editObject.CompletionStatus == PermitRequestCompletionStatus.Complete)
            {
                UpdateEditObjectFromView();
                DateTime now = Clock.Now;
                editObject.CreatedDateTime = now;
                editObject.LastModifiedDateTime = now;
                editObject.IsModified = true;

                SubmitPermitRequests<PermitRequestMontrealDTO> submitPermitRequests = SubmitPermitRequests;
                List<PermitRequestMontrealDTO> dtos = new List<PermitRequestMontrealDTO> { new PermitRequestMontrealDTO(editObject) };
                SubmitPermitRequestFormPresenter<PermitRequestMontrealDTO> presenter =
                    new SubmitPermitRequestFormPresenter<PermitRequestMontrealDTO>(dtos, submitPermitRequests,
                                                                                   CheckPermitRequestAssociationAlreadyExists,
                                                                                   new SubmitPermitRequestFormPresenterHelper
                                                                                       <PermitRequestMontrealDTO>());
                DialogResult dialogResult = presenter.Run(view);
                
                if(dialogResult == DialogResult.Cancel)
                {
                    // If user cancels the Date Picker for the Work Permit Start Date then we still want to keep the Work Permit form open
                    return;
                }

                shouldSkipConfirm = true;
                view.Close();
            }
        }

        private bool CheckPermitRequestAssociationAlreadyExists(Date workPermitDate, List<PermitRequestMontrealDTO> requestDtos)
        {
            return workPermitService.DoesPermitRequestMontrealAssociationExist(requestDtos, workPermitDate);
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestMontrealDTO> requestDtos, User user)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.SaveAndSubmit, workPermitDate, editObject, user);
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();

            DateTime now = Clock.Now;
            editObject.CreatedDateTime = now;
            editObject.LastModifiedDateTime = now;
            editObject.IsModified = true;

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Insert, editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            editObject.IsModified = true;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(permitRequestService.Update, editObject);
        }

        // unused since we override the save button handler
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

    }
}
