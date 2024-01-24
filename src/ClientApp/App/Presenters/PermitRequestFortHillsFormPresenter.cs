using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.History;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.FortHills;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitRequestFortHillsFormPresenter : AddEditBaseFormPresenter<IPermitRequestFortHillsFormView, PermitRequestFortHills>
    {
        private readonly IPermitRequestFortHillsService service;
        private readonly IWorkPermitFortHillsService wpservice;
        private readonly IWorkPermitFortHillsService workPermitService;
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IContractorService contractorService;
        private readonly IFormFortHillsService formService;
        private readonly IAreaLabelService areaLabelService;

        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;
        private List<AreaLabel> areaLabels;
        private List<WorkPermitFortHillsGroup> groups;
        private List<CraftOrTrade> roadAccessPermitList;
        private List<SpecialWork> specialWorkList;
        private static ITimeService timeService;
        private readonly IBusinessCategoryService businessCategoryService;

        private bool locationChangedByUser;
        private bool IsSubmitted = true;

        public PermitRequestFortHillsFormPresenter()
            : this(CreateDefaultPermitRequest())
        {
        }

        public PermitRequestFortHillsFormPresenter(PermitRequestFortHills request)
            : base(new PermitRequestFortHillsForm(), request)
        {
            service = ClientServiceRegistry.Instance.GetService<IPermitRequestFortHillsService>();
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitFortHillsService>();
            craftOrTradeService = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormFortHillsService>();
            areaLabelService = ClientServiceRegistry.Instance.GetService<IAreaLabelService>();
            timeService =  ClientServiceRegistry.Instance.GetService<ITimeService>();
            businessCategoryService = ClientServiceRegistry.Instance.GetService<IBusinessCategoryService>(); 
            view.Load += HandleFormLoad;
            view.ViewEditHistoryButtonClicked += ViewEditHistoryButton_Click;
            view.FunctionalLocationButtonClicked += HandleFunctionalLocationButtonClicked;
            view.SubmitAndCloseButtonClicked += HandleSubmitAndCloseButtonClicked;
            view.ValidateButtonClicked += HandleValidateButtonClicked;
            //view.SelectFormGN1ButtonClicked += HandleSelectFormGN1ButtonClicked;
            //view.SelectFormGN6ButtonClicked += HandleSelectFormGN6ButtonClicked;
            //view.SelectFormGN7ButtonClicked += HandleSelectFormGN7ButtonClicked;
            //view.SelectFormGN59ButtonClicked += HandleSelectFormGN59ButtonClicked;
            //view.SelectFormGN24ButtonClicked += HandleSelectFormGN24ButtonClicked;
            //view.SelectFormGN75AButtonClicked += HandleSelectFormGN75AButtonClicked;
            //view.FormGN1CheckBoxCheckChanged += HandleFormGN1CheckBoxChanged;
        }

        private static PermitRequestFortHills CreateDefaultPermitRequest()
        {
            DateTime now = Clock.Now;
            Date defaultDate = now.ToDate();
            User currentUser = ClientSession.GetUserContext().User;

            PermitRequestFortHills request = new PermitRequestFortHills(
                null, defaultDate, null, null, null, DataSource.MANUAL, null, null, null, null, currentUser, now, currentUser, now);

            UserShift userShift = ClientSession.GetUserContext().UserShift;
            DateTime shiftStartDateTime = userShift.StartDateTime;
            DateTime shiftEndDateTime = userShift.EndDateTime;
            DateTime currentDateTime = Clock.Now;

            DateTime startDateTime = currentDateTime >= shiftStartDateTime ? currentDateTime : shiftStartDateTime;
            DateTime endDateTime = currentDateTime >= shiftEndDateTime ? currentDateTime : shiftEndDateTime;

            request.RequestedStartDate = startDateTime.ToDate();
            request.EndDate = endDateTime.ToDate();
            
            if (startDateTime.ToTime().InRange(WorkPermitFortHills.DayShiftStartTime, WorkPermitFortHills.NightShiftStartTime))
            {
                request.RequestedStartTime = WorkPermitFortHills.PermitDefaultDayStart;
                request.RequestedEndTime = WorkPermitFortHills.NightShiftStartTime;
            }
            else
            {
                request.RequestedStartTime = WorkPermitFortHills.PermitDefaultNightStart; 
                request.RequestedEndTime = WorkPermitFortHills.PermitDefaultDayStart;
            }

            return request;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { QueryCraftOrTrades, QueryContractors, QueryAreaLabels, QueryGroups, LoadRoadOnAccessPermitList, LoadSpecialWorkList });
        }

        private void LoadSpecialWorkList()
        {
            specialWorkList = ClientServiceRegistry.Instance.GetService<ISpecialWorkService>().QueryBySite(userContext.Site);
        }

        private void LoadRoadOnAccessPermitList()
        {
            roadAccessPermitList = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySiteIdRoadAccessOnPermit(userContext.Site);
        }

        protected override void AfterDataLoad()
        {
            view.PopulateFunctionalLocationSelector(userContext.HasFlocsForWorkPermits ? userContext.RootFlocSetForWorkPermits.FunctionalLocations : userContext.RootFlocSet.FunctionalLocations);
            
            SetupRoadOnAccessPermitList();
            SetupSpecialWorkList();
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.PermitRequestFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;

            List<WorkPermitFortHillsType> workPermitTypes = new List<WorkPermitFortHillsType>(WorkPermitFortHillsType.All);
            workPermitTypes.Insert(0, WorkPermitFortHillsType.NULL);
            view.AllPermitTypes = workPermitTypes;

            areaLabels.Insert(0, AreaLabel.EMPTY);
           

            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
            view.AllCompanies = contractors;

            PermitFormHelper.SortCraftOrTrades(craftOrTrades);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
            view.AllCraftOrTrades = craftOrTrades;

           // view.AllAffectedAreas = PermitFormHelper.GetAreasAffectedList();
            view.AllGroups = groups;
           

            //view.AlkylationEntryClassOfClothingSelectionList = PermitFormHelper.GetABCDSelectionList();
            //view.FlarePitEntryTypeSelectionList = PermitFormHelper.Get12SelectionList();
            view.ConfinedSpaceClassSelectionList = PermitFormHelper.GetConfinedSpaceClassSelectionList();
            //view.SpecialWorkTypeSelectionList = FortHillsPermitSpecialWorkType.GetAllAsList();

            //view.GN11Values = WorkPermitSafetyFormState.AllValues;
            //view.GN27Values = WorkPermitSafetyFormState.AllValues;

            UpdateViewFromEditObject();

            if (IsEdit)
            {
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestFortHillsValidationViewAdapter(view), editObject.DataSource);
                validator.Validate();
            }
        }

        private void QueryGroups()
        {
            groups = workPermitService.QueryAllGroups();
        }

        private void QueryContractors()
        {
            contractors = contractorService.QueryBySite(userContext.Site);
        }

        private void QueryCraftOrTrades()
        {
            craftOrTrades = craftOrTradeService.QueryBySite(userContext.Site);
        }

        private void QueryAreaLabels()
        {
            areaLabels = areaLabelService.QueryBySiteId(ClientSession.GetUserContext().Site.IdValue);
        }

        private void SetLocationChangedByUser()
        {
            locationChangedByUser = view.Location != WorkPermitFortHills.GetLocation(view.FunctionalLocation);
        }

        private void UpdateViewFromEditObject()
        {

           
            view.Company = editObject.Company;
            view.Occupation = editObject.Occupation;
            view.NumberOfWorkers = editObject.NumberOfWorkers;
            view.Group = editObject.Group;
            view.WorkPermitType = editObject.WorkPermitType;
            view.Priorities = new List<Priority>(WorkPermitFortHills.Priorities);
            view.Priority = editObject.Priority;

            view.FunctionalLocation = editObject.FunctionalLocation;
            view.Location = editObject.Location;
            
            view.DocumentLinks = editObject.DocumentLinks;

            view.RequestedStartDate = editObject.RequestedStartDate;
            view.RequestedStartTime = editObject.RequestedStartTime;
            view.RequestedEndDate = editObject.EndDate;
            view.RequestedEndTime = editObject.RequestedEndTime;
            //enable disable date if value is not there...... 
            view.RequestedStartDatePickerEnabled = editObject.RequestedStartDate != null;
            view.RequestedStartTimePickerEnabled = editObject.RequestedStartTime != null;
            view.RequestedEndDatePickerEnabled = editObject.EndDate != null;
            view.RequestedEndTimePickerEnabled = editObject.RequestedEndTime != null;

            if (editObject.DataSource.Equals(DataSource.CLONE))
            {
                view.RequestedStartDate = ClientSession.GetUserContext().UserShift.StartDate;
                view.RequestedStartTime = ClientSession.GetUserContext().UserShift.StartDateTime.ToTime();
                view.RequestedEndDate = ClientSession.GetUserContext().UserShift.EndDate;
                view.RequestedEndTime = ClientSession.GetUserContext().UserShift.EndDateTime.ToTime();
            }

            view.JobCoordinator = editObject.JobCoordinator;
            view.CoOrdContactNumber = editObject.CoOrdContactNumber;
            view.EquipmentNo = editObject.EquipmentNo;
            view.LockBoxnumberChecked = editObject.LockBoxnumberChecked;
            
            view.Description = editObject.Description;
            view.SapDescription = editObject.SapDescription;

            view.PartDWorkSectionNotApplicableToJob = editObject.PartDWorkSectionNotApplicableToJob;
            view.HazardsAndOrRequirements = editObject.HazardsAndOrRequirements;

            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.OperationNumber = editObject.OperationNumberListAsString;
            if (DataSource.SAP.Equals(editObject.DataSource))
            {
                view.SubOperationNumber = editObject.SubOperationNumberListAsString;
            }
            else
            {
                if (editObject.WorkOrderSourceList == null || editObject.WorkOrderSourceList.Count == 0)
                {
                    view.SubOperationNumber = null;
                }
                else
                {
                    // there can only be one suboperation number for manually created permit requests, so display it here
                    view.SubOperationNumber = editObject.WorkOrderSourceList[0].SubOperationNumber;
                }
            }
            bool isManualOrClone = editObject.DataSource.Equals(DataSource.MANUAL) || editObject.DataSource.Equals(DataSource.CLONE);
            view.WorkOrderNumberEnabled = isManualOrClone;
            view.OperationNumberEnabled = isManualOrClone;
            view.SubOperationNumberEnabled = isManualOrClone;
            view.SapDescriptionVisible = editObject.IsSAPDescriptionAvailableForDisplay;

            // PART C WORK AUTHORIZATION AND OR DOCUMENTATION SPECIAL SAFETY EQUIPMENT REQUIREMENT
            UpdateViewPartCfromEditObject();
           // PART E WORK AUTHORIZATION AND OR DOCUMENTATION 
            UpdateViewPartEfromEditObject();

          //  view.SetOtherAreasAndOrUnitsAffected(editObject.OtherAreasAndOrUnitsAffectedArea, editObject.OtherAreasAndOrUnitsAffectedPersonNotified);
            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            // --------------

        }

        private void UpdateViewPartCfromEditObject()
        {
          //  view.MSDS = editObject.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;
            //PART C-1
            view.PartCWorkSectionNotApplicableToJob = editObject.PartCWorkSectionNotApplicableToJob;
            view.FlameResistantWorkWear = editObject.FlameResistantWorkWear;
            view.ChemicalSuit = editObject.ChemicalSuit;
            view.FireWatch = editObject.FireWatch;
            view.FireBlanket = editObject.FireBlanket;
            view.SuppliedBreathingAir = editObject.SuppliedBreathingAir;
            view.AirMover = editObject.AirMover;
            view.PersonalFlotationDevice = editObject.PersonalFlotationDevice;
            view.HearingProtection = editObject.HearingProtection;
            view.Other1Value = editObject.Other1;

            view.MonoGoggles = editObject.MonoGoggles;
            view.ConfinedSpaceMoniter = editObject.ConfinedSpaceMoniter;
            view.FireExtinguisher = editObject.FireExtinguisher;
            view.SparkContainment = editObject.SparkContainment;
            view.BottleWatch = editObject.BottleWatch;
            view.StandbyPerson = editObject.StandbyPerson;
            view.WorkingAlone = editObject.WorkingAlone;
            view.SafetyGloves = editObject.SafetyGloves;
            view.Other2Value = editObject.Other2;


            view.FaceShield = editObject.FaceShield; 
            view.FallProtection = editObject.FallProtection;
            view.ChargedFireHouse = editObject.ChargedFireHouse;
            view.CoveredSewer = editObject.CoveredSewer;
            view.AirPurifyingRespirator = editObject.AirPurifyingRespirator;
            view.SingalPerson = editObject.SingalPerson;
            view.CommunicationDevice = editObject.CommunicationDevice;
            view.ReflectiveStrips = editObject.ReflectiveStrips;
            view.Other3Value = editObject.Other3;

            
        }

        private void UpdateEditObjectFromView()
        {
            editObject.RequestedStartDate = view.RequestedStartDate;
            editObject.RequestedStartTime = view.RequestedStartTime;

            editObject.EndDate = view.RequestedEndDate;
            editObject.RequestedEndTime = view.RequestedEndTime;
            editObject.EndDate = view.RequestedEndDate; 
            editObject.JobCoordinator = view.JobCoordinator;
            editObject.CoOrdContactNumber = view.CoOrdContactNumber;
            editObject.EquipmentNo = view.EquipmentNo;
            editObject.LockBoxnumberChecked = view.LockBoxnumberChecked;
            editObject.Description = view.Description;
            editObject.SapDescription = view.SapDescription;

            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDateTime = Clock.Now;

            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.IssuedToContractor = view.IssuedToContractor;
            editObject.Company = view.Company;

            editObject.Occupation = view.Occupation;
            editObject.NumberOfWorkers = view.NumberOfWorkers;
            editObject.Group = view.Group;
            editObject.WorkPermitType = view.WorkPermitType;
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;

            editObject.DocumentLinks = view.DocumentLinks;
            editObject.Priority = view.Priority;

            if (DataSource.MANUAL.Equals(editObject.DataSource))
            {
                editObject.ClearWorkOrderSources();
                editObject.AddWorkOrderSource(view.WorkOrderNumber, view.OperationNumber, view.SubOperationNumber);
            }

            editObject.PartDWorkSectionNotApplicableToJob = view.PartDWorkSectionNotApplicableToJob;
            editObject.HazardsAndOrRequirements = view.HazardsAndOrRequirements;
            
            UpdateEditObjectWithPartE();
            UpdateEditObjectWithPartC();
        }

        private void UpdateEditObjectWithPartC()
        {
           
            editObject.PartCWorkSectionNotApplicableToJob = view.PartCWorkSectionNotApplicableToJob;

            editObject.FlameResistantWorkWear = view.FlameResistantWorkWear;
            editObject.ChemicalSuit = view.ChemicalSuit;
            editObject.FireWatch = view.FireWatch;
            editObject.FireBlanket = view.FireBlanket;
            editObject.SuppliedBreathingAir = view.SuppliedBreathingAir;
            editObject.AirMover = view.AirMover;
            editObject.PersonalFlotationDevice = view.PersonalFlotationDevice;
            editObject.HearingProtection = view.HearingProtection;
            editObject.Other1 = view.Other1Value;

            editObject.MonoGoggles = view.MonoGoggles;
            editObject.ConfinedSpaceMoniter = view.ConfinedSpaceMoniter;
            editObject.FireExtinguisher = view.FireExtinguisher;
            editObject.SparkContainment = view.SparkContainment;
            editObject.BottleWatch = view.BottleWatch;
            editObject.StandbyPerson = view.StandbyPerson;
            editObject.WorkingAlone = view.WorkingAlone;
            editObject.SafetyGloves = view.SafetyGloves;
            editObject.Other2 = view.Other2Value;
            
            
            
            editObject.FaceShield = view.FaceShield;
            editObject.FallProtection = view.FallProtection;
            editObject.ChargedFireHouse = view.ChargedFireHouse;
            editObject.CoveredSewer = view.CoveredSewer;
            editObject.AirPurifyingRespirator = view.AirPurifyingRespirator;
            editObject.SingalPerson = view.SingalPerson;
            editObject.CommunicationDevice = view.CommunicationDevice;
            editObject.ReflectiveStrips = view.ReflectiveStrips;  
            editObject.Other3 = view.Other3Value;
        }

        private void UpdateEditObjectWithPartE()
        {
            editObject.PartEWorkSectionNotApplicableToJob = view.PartEWorkSectionNotApplicableToJob;

            editObject.ConfinedSpace = view.ConfinedSpace;
            editObject.ConfinedSpaceClass = view.ConfinedSpaceClass;
            editObject.GroundDisturbance = view.GoundDisturbance;
            editObject.FireProtectionAuthorization = view.FireProtectionAuthorization;
            editObject.CriticalOrSeriousLifts = view.CriticalOrSeriousLifts;
            editObject.VehicleEntry = view.VehicleEntry;
            editObject.IndustrialRadiography = view.IndustrialRadiography;
            editObject.ElectricalEncroachment = view.ElectricalEncroachment;
            editObject.MSDS = view.MSDS;
            editObject.OthersPartE = view.OthersPartE;
           
        }

        private void UpdateViewPartEfromEditObject()
        {
            view.PartEWorkSectionNotApplicableToJob = editObject.PartEWorkSectionNotApplicableToJob;

            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.ConfinedSpaceClassEnabled = editObject.ConfinedSpace;
            view.GoundDisturbance = editObject.GroundDisturbance;
            view.FireProtectionAuthorization = editObject.FireProtectionAuthorization;
            view.CriticalOrSeriousLifts = editObject.CriticalOrSeriousLifts;
            view.VehicleEntry = editObject.VehicleEntry;
            view.IndustrialRadiography = editObject.IndustrialRadiography;
            view.ElectricalEncroachment = editObject.ElectricalEncroachment;
            view.MSDS = editObject.MSDS;
            view.OthersPartE = editObject.OthersPartE;
            
        }

        private void HandleFunctionalLocationButtonClicked()
        {
            SetLocationChangedByUser();

            FunctionalLocation floc = view.ShowFunctionalLocationSelector();
            if (floc != null)
            {
                view.FunctionalLocation = floc;

                if (!locationChangedByUser)
                {
                    view.Location = WorkPermitFortHills.GetLocation(floc);
                }
            }
        }

        private void ViewEditHistoryButton_Click()
        {
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            EditPermitRequestFortHillsHistoryFormPresenter presenter = new EditPermitRequestFortHillsHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            view.ClearErrorProviders();
            IsSubmitted = false;
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestFortHillsValidationViewAdapter(view), editObject.DataSource);
            validator.Validate();

            bool hasWarnings = validator.HasWarnings;
            bool hasErrors = validator.HasErrors;

            PermitRequestCompletionStatus completionStatus = validator.CompletionStatus;

            if (hasErrors && !hasWarnings)
            {
                view.ShowSaveAndCloseMessageForErrors();
            }
            else if (hasWarnings && !hasErrors)
            {
                DialogResult result;
                if (PermitRequestCompletionStatus.ForReview.Equals(completionStatus))
                {
                    result = view.ShowSaveAndCloseMessageForWarnings_TurnaroundCase();
                }
                else
                {
                    result = view.ShowSaveAndCloseMessageForWarnings_NonTurnaroundCase();
                }
                if (result == DialogResult.Yes)
                {
                    FinalizePermitRequestAndSave(completionStatus);
                }
            }
            else if (validator.HasWarnings && validator.HasErrors)
            {
                if (PermitRequestCompletionStatus.ForReview.Equals(completionStatus))
                {
                    view.ShowSaveAndCloseMessageForWarningsAndErrors_TurnaroundCase();
                }
                else
                {
                    view.ShowSaveAndCloseMessageForWarningsAndErrors_NonTurnaroundCase();
                }
            }
            else
            {
                FinalizePermitRequestAndSave(completionStatus);
            }
        }

        private void FinalizePermitRequestAndSave(PermitRequestCompletionStatus completionStatus)
        {
            editObject.CompletionStatus = completionStatus;

            try
            {
                SaveOrUpdate(true);
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private void HandleSubmitAndCloseButtonClicked()
        {
            view.ClearErrorProviders();
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestFortHillsValidationViewAdapter(view), editObject.DataSource);
            validator.Validate();

            editObject.CompletionStatus = validator.CompletionStatus;

            bool requestIsSubmittable = !validator.HasErrors && (!validator.HasWarnings || PermitRequestCompletionStatus.ForReview.Equals(editObject.CompletionStatus));

            if (requestIsSubmittable)
            {
                PerformSubmit();
                //create action item here 
            }
            else
            {
                if (validator.HasErrors && !validator.HasWarnings)
                {
                    view.ShowSubmitAndCloseMessageForErrors();
                }
                else if (validator.HasWarnings && !validator.HasErrors)
                {
                    view.ShowSubmitAndCloseMessageForWarnings();
                }
                else if (validator.HasWarnings && validator.HasErrors)
                {
                    if (PermitRequestCompletionStatus.ForReview.Equals(editObject.CompletionStatus))
                    {
                        view.ShowSubmitAndCloseMessageForWarningsAndErrors_TurnaroundCase();
                    }
                    else
                    {
                        view.ShowSubmitAndCloseMessageForWarningsAndErrors_NonTurnaroundCase();
                    }
                }
            }
        }

        private void PerformSubmit()
        {
            UpdateEditObjectFromView();
            DateTime now = Clock.Now;
            editObject.CreatedDateTime = now;
            editObject.LastModifiedDateTime = now;
            editObject.IsModified = true;

            CheckPermitRequestAssociationAlreadyExists<PermitRequestFortHillsDTO> checkPermitRequestAssociationAlreadyExists = null;

            if (IsEdit)
            {
                checkPermitRequestAssociationAlreadyExists = CheckPermitRequestAssociationAlreadyExists;
            }

            SubmitPermitRequests<PermitRequestFortHillsDTO> submitPermitRequests = SubmitPermitRequests;
            List<PermitRequestFortHillsDTO> dtos = new List<PermitRequestFortHillsDTO> { new PermitRequestFortHillsDTO(editObject) };
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            SubmitPermitRequestFortHillsFormPresenter presenter = new SubmitPermitRequestFortHillsFormPresenter(dtos,
                                                                                                              submitPermitRequests,
                                                                                                              checkPermitRequestAssociationAlreadyExists,
                                                                                                              true);
            /* DMND0009632 - Fort Hills OLT - E-Permit Development Commented*/
            DialogResult dialogResult = presenter.Run(view);

            if (dialogResult == DialogResult.Cancel)
            {
                // If user cancels the Date Picker for the Work Permit Start Date then we still want to keep the Work Permit form open
                return;
            }


            shouldSkipConfirm = true;
            view.Close();
        }

        private void HandleValidateButtonClicked()
        {
            view.ClearErrorProviders();
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestFortHillsValidationViewAdapter(view), editObject.DataSource);
            validator.Validate();

            PermitRequestCompletionStatus completionStatus = validator.CompletionStatus;

            if (!validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowIsValidMessageBox();
            }
            else if (!validator.HasWarnings && validator.HasErrors)
            {
                view.ShowSubmitAndCloseMessageForErrors();
            }
            else if (validator.HasWarnings && !validator.HasErrors)
            {
                if (PermitRequestCompletionStatus.ForReview.Equals(completionStatus))
                {
                    view.ShowValidationMessageForTurnaroundWarnings();
                }
                else
                {
                    view.ShowSubmitAndCloseMessageForWarnings();
                }
            }
            else if (validator.HasWarnings && validator.HasErrors)
            {
                if (PermitRequestCompletionStatus.ForReview.Equals(completionStatus))
                {
                    view.ShowSubmitAndCloseMessageForWarningsAndErrors_TurnaroundCase();
                }
                else
                {
                    view.ShowSubmitAndCloseMessageForWarningsAndErrors_NonTurnaroundCase();
                }
            }
        }

        private bool CheckPermitRequestAssociationAlreadyExists(Date workPermitDate, List<PermitRequestFortHillsDTO> requestDtos)
        {
            return workPermitService.DoesPermitRequestFortHillsAssociationExist(requestDtos, workPermitDate);
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestFortHillsDTO> requestDtos, User user)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.SaveAndSubmit, workPermitDate, editObject, user);
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();

            DateTime now = Clock.Now;
            editObject.CreatedDateTime = now;
            editObject.LastModifiedDateTime = now;
            editObject.IsModified = true;

            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, editObject);
            //if (editObject.LockBoxnumberChecked && IsSubmitted) {
            //    GetAIObjectToInsert(editObject, ClientSession.GetUserContext().Site);
            //}
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            editObject.IsModified = true;
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, editObject);
        }

        // this method is not actually called in our case since we handle the saving process ourselves
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

        

        private void SetupRoadOnAccessPermitList()
        {
            roadAccessPermitList.Sort(c => c.Name);
            roadAccessPermitList.Insert(0, CraftOrTrade.EMPTY);
            view.AllRoadAccessOnPermitType = roadAccessPermitList;
        }

        private void SetupSpecialWorkList()
        {
            specialWorkList.Sort(c => c.CompanyName);
            specialWorkList.Insert(0, SpecialWork.EMPTY);
          //  view.AllSpecialWorkType = specialWorkList;
        }

        //protected void GetAIObjectToInsert(PermitRequestFortHills workPermit, Site currentSite)
        //{
        //    var currentTimeAtSite = timeService.GetTime(currentSite.TimeZone);
        //    var name = string.Format("{0}-{1}-{2}", workPermit.WorkOrderNumber, workPermit.OperationNumber,
        //        currentTimeAtSite.Millisecond);

        //    List<FunctionalLocation> floc = new List<FunctionalLocation>();
        //    //FunctionalLocation floc = functionalLocationDao.QueryByFullHierarchy(importData.FunctionalLocation, site.IdValue);
        //    List<DocumentLink> docLink = new List<DocumentLink>(0);
        //    var businessCategory = businessCategoryService.GetDefaultSAPWorkOrderCategory(currentSite.IdValue);
        //    WorkAssignment workAssignment = ClientSession.GetUserContext().Assignment;
        //    ISchedule schedule = new SingleSchedule(workPermit.RequestedStartDate, workPermit.RequestedStartTime, workPermit.RequestedEndTime, currentSite);
        //    floc.Add(workPermit.FunctionalLocation);
        //    var actionItemDefinition =
        //        new ActionItemDefinition(name, businessCategory, ActionItemDefinitionStatus.Approved, schedule, workPermit.Description.TrimOrEmpty(), DataSource.PERMIT, false, true, true, workPermit.CreatedBy, currentTimeAtSite, workPermit.CreatedBy, currentTimeAtSite, floc, new List<Common.DTO.TargetDefinitionDTO>(), new List<DocumentLink>(), OperationalMode.Normal, workAssignment, false, null, null, null, false, false, false, null);

        //    //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(ApplicationEvent.ActionItemDefinitionCreate, service.UpdateAndInsertActionItems, workPermit, actionItemDefinition);
        //    ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(wpservice.UpdateAndInsertActionItems, workPermit, actionItemDefinition); //|| add Action             
        //    // return actionItemDefinition;
        //}


    }
}
