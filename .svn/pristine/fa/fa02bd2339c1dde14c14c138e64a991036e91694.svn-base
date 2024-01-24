using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Muds;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Muds;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitRequestMudsFormPresenter : AddEditBaseFormPresenter<IPermitRequestMudsFormView, PermitRequestMuds>
    {
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IContractorService contractorService;
        private readonly IPermitAttributeService permitAttributeService;
        private readonly IPermitRequestMudsService permitRequestService;
        private readonly IWorkPermitMudsService workPermitService;

        private List<WorkPermitMudsType> workPermitTypes;
        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;
        private List<WorkPermitMudsGroup> groups;
        private List<PermitAttribute> attributesForSite;

        public PermitRequestMudsFormPresenter() : this(CreateDefaultPermitRequest())
        {
        }

        public PermitRequestMudsFormPresenter(PermitRequestMuds request) 
            : base(new PermitRequestMudsForm(), request)
        {
            craftOrTradeService = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            permitAttributeService = ClientServiceRegistry.Instance.GetService<IPermitAttributeService>();
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestMudsService>();
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitMudsService>();

            view.Load += HandleFormLoad;
            view.ViewEditHistoryButtonClicked += HandleViewEditHistoryButtonClick;
            view.FunctionalLocationButtonClicked += HandleFunctionalLocationButtonClick;
            view.SubmitAndCloseButtonClicked += HandleSubmitAndCloseButtonClick;
        }

        private static PermitRequestMuds CreateDefaultPermitRequest()
        {
            DateTime now = Clock.Now;
            Date defaultDate = now.ToDate();
           
            //TimeSpan ts = new TimeSpan(07,00,00);
            //TimeSpan ts1 = new TimeSpan(16, 00, 00);
            //DateTime starTime = Clock.Now;
            //DateTime endTime = Clock.Now;

            var dateNow = Clock.Now;
            var starTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 7, 0, 0);
            var endTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 16, 0, 0);

            


// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            PermitRequestMuds request = new PermitRequestMuds(
                null, null, null, defaultDate, defaultDate, null, null, null, null, null, null,null, null, null, null, null,
                DataSource.MANUAL, null, null, null, null,
                ClientSession.GetUserContext().User, now, ClientSession.GetUserContext().User, now, null,
                PermitRequestCompletionStatus.Incomplete, null,
                null, false, null, null, null, null, null, starTime, endTime, false, false,false,false,false);

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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.AllCompanies_1 =new List<Contractor>(contractors);
            view.AllCompanies_2 =new List<Contractor>( contractors);
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

            //originalStartDateTime = view.StartDateTime;
            //originalEndDateTime = view.EndDateTime;

            UpdateViewFromEditObject();
        }

        private void QueryAttributesForSite()
        {
            attributesForSite = permitAttributeService.QueryBySite(userContext.Site.IdValue);
        }

        private void QueryGroups()
        {
            groups = workPermitService.QueryAllGroups();
            groups.Insert(0, WorkPermitMudsGroup.EMPTY);
        }

        private void QueryPermitTypes()
        {
            workPermitTypes = new List<WorkPermitMudsType>(WorkPermitMudsType.PERMIT_REQUEST_TYPES);
            workPermitTypes.Insert(0, WorkPermitMudsType.NULL);
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
            view.RequestedByGroupText = editObject.RequestedByGroupText;

            string operationDisplay = GetOperationNumberDisplay(editObject);
            view.OperationNumber = operationDisplay;
                       
            view.Description = editObject.Description;
            view.SapDescription = editObject.SapDescription;
            
            view.Company = editObject.Company;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.Company_1 = editObject.Company_1;
            view.Company_2 = editObject.Company_2;
            view.Supervisor = editObject.Supervisor;
            view.ExcavationNumber = editObject.ExcavationNumber;
            
            view.NbTravail = editObject.NbTravail;
            view.FormationCheck = editObject.Formation;
            view.Noms = editObject.Noms;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            view.Noms_1 = editObject.Noms_1;
            view.Noms_2 = editObject.Noms_2;
            view.Noms_3 = editObject.Noms_3;
            view.Surveilant = editObject.Surveilant;
            //new form
            view.SelectedAttributes = editObject.Attributes;

            if (view.SelectedAttributes.Count > 0)
            {
                for (int i = 0; i < view.SelectedAttributes.Count; i++)
                {
                    if (view.SelectedAttributes[i].Name == "Analyse critique de la tâche (ACT)")
                    {

                        view.Analyse_Attribute_CheckBox = editObject.Analyse_Attribute_CheckBox;
                    }
                    else
                    {
                        editObject.Analyse_Attribute_CheckBox = false;
                    }
                    if (view.SelectedAttributes[i].Name == "Cadenassage multiple")
                    {
                        view.Cadenassage_multiple_Attribute_CheckBox = editObject.Cadenassage_multiple_Attribute_CheckBox;
                    }
                    else
                    {
                        editObject.Cadenassage_multiple_Attribute_CheckBox = false;
                    }
                    if (view.SelectedAttributes[i].Name == "Cadenassage simple")
                    {
                        view.Cadenassage_simple_Attribute_CheckBox = editObject.Cadenassage_simple_Attribute_CheckBox;
                    }
                    else
                    {
                        editObject.Cadenassage_simple_Attribute_CheckBox = false;
                    }
                    if (view.SelectedAttributes[i].Name == "Procédure")
                    {

                        view.Procédure_Attribute_CheckBox = editObject.Procédure_Attribute_CheckBox;
                    }
                    else
                    {
                        editObject.Procédure_Attribute_CheckBox = false;
                    }
                    if (view.SelectedAttributes[i].Name == "Espace clos")
                    {
                        view.Espace_clos_Attribute_CheckBox = editObject.Espace_clos_Attribute_CheckBox;
                    }
                    else
                    {
                        editObject.Espace_clos_Attribute_CheckBox = false;
                    }

                }

            }

            view.WorkOrderNumberEnabled = editObject.DataSource != DataSource.SAP;
            view.OperationNumberEnabled = editObject.DataSource != DataSource.SAP;
            view.SapDescriptionVisible = editObject.DataSource == DataSource.SAP && editObject.Description != editObject.SapDescription;

            view.DocumentLinks = editObject.DocumentLinks;

            view.StartDateTime = editObject.StartDateTime;
            view.EndDateTime = editObject.EndDateTime;

        }

        private string GetOperationNumberDisplay(PermitRequestMuds permitRequest)
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
            editObject.RequestedByGroupText = view.RequestedByGroupText;

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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            editObject.Company_1 = view.Company_1;
            editObject.Company_2 = view.Company_2;
            editObject.Supervisor = view.Supervisor;
            editObject.ExcavationNumber = view.ExcavationNumber;

            editObject.NbTravail = view.NbTravail;
            editObject.Formation = view.FormationCheck;
            editObject.Noms = view.Noms;
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            editObject.Noms_1 = view.Noms_1;
            editObject.Noms_2 = view.Noms_2;
            editObject.Noms_3 = view.Noms_3;
            editObject.Surveilant = view.Surveilant;

            editObject.Attributes.Clear();
            //save new
            editObject.Attributes.AddRange(view.SelectedAttributes);

            if (view.SelectedAttributes.Count > 0)
            {
                for (int i = 0; i < view.SelectedAttributes.Count; i++)
                {
                    if (view.SelectedAttributes[i].Name == "Analyse critique de la tâche (ACT)")
                    {

                        editObject.Analyse_Attribute_CheckBox = true;
                    }
                    if (view.SelectedAttributes[i].Name == "Cadenassage multiple")
                    {
                        editObject.Cadenassage_multiple_Attribute_CheckBox = true;
                    }
                    if (view.SelectedAttributes[i].Name == "Cadenassage simple")
                    {
                        editObject.Cadenassage_simple_Attribute_CheckBox = true;
                    }
                    if (view.SelectedAttributes[i].Name == "Procédure")
                    {

                        editObject.Procédure_Attribute_CheckBox = true;
                    }
                    if (view.SelectedAttributes[i].Name == "Espace clos")
                    {
                        editObject.Espace_clos_Attribute_CheckBox = true;
                    }
                }

            }

            editObject.DocumentLinks = view.DocumentLinks;


            editObject.StartDateTime = view.StartDateTime;
            editObject.EndDateTime = view.EndDateTime;
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
            EditPermitRequestMudsHistoryFormPresenter presenter = new EditPermitRequestMudsHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            PermitRequestMudsValidator validator = new PermitRequestMudsValidator(new PermitRequestMudsValidationViewAdapter(view));
            validator.Validate(Clock.DateNow);

            editObject.CompletionStatus = validator.CompletionStatus;

            if (!validator.HasErrors)
            {
                SaveOrUpdate(true);
            }
        }

        private void HandleSubmitAndCloseButtonClick()
        {
            PermitRequestMudsValidator validator = new PermitRequestMudsValidator(new PermitRequestMudsValidationViewAdapter(view));
            validator.Validate(Clock.DateNow);

            editObject.CompletionStatus = validator.CompletionStatus;

            if (editObject.CompletionStatus == PermitRequestCompletionStatus.Complete)
            {
                UpdateEditObjectFromView();
                DateTime now = Clock.Now;
                editObject.CreatedDateTime = now;
                editObject.LastModifiedDateTime = now;
                editObject.IsModified = true;

                SubmitPermitRequests<PermitRequestMudsDTO> submitPermitRequests = SubmitPermitRequests;
                List<PermitRequestMudsDTO> dtos = new List<PermitRequestMudsDTO> { new PermitRequestMudsDTO(editObject) };
                SubmitPermitRequestFormPresenter<PermitRequestMudsDTO> presenter =
                    new SubmitPermitRequestFormPresenter<PermitRequestMudsDTO>(dtos, submitPermitRequests,
                                                                                   CheckPermitRequestAssociationAlreadyExists,
                                                                                   new SubmitPermitRequestFormPresenterHelper
                                                                                       <PermitRequestMudsDTO>());
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

        private bool CheckPermitRequestAssociationAlreadyExists(Date workPermitDate, List<PermitRequestMudsDTO> requestDtos)
        {
            return workPermitService.DoesPermitRequestMudsAssociationExist(requestDtos, workPermitDate);
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestMudsDTO> requestDtos, User user)
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
