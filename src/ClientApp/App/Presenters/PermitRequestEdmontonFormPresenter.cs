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
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class PermitRequestEdmontonFormPresenter : AddEditBaseFormPresenter<IPermitRequestEdmontonFormView, PermitRequestEdmonton>
    {
        private readonly IPermitRequestEdmontonService service;
        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly ICraftOrTradeService craftOrTradeService;
        private readonly IContractorService contractorService;
        private readonly IFormEdmontonService formService;
        private readonly IAreaLabelService areaLabelService;

        private List<CraftOrTrade> craftOrTrades;
        private List<Contractor> contractors;
        private List<AreaLabel> areaLabels;
        private List<WorkPermitEdmontonGroup> groups;
        private List<CraftOrTrade> roadAccessPermitList;
        private List<SpecialWork> specialWorkList;

        private bool locationChangedByUser;
        
        public PermitRequestEdmontonFormPresenter() : this(CreateDefaultPermitRequest())
        {
        }

        public PermitRequestEdmontonFormPresenter(PermitRequestEdmonton request) 
            : base(new PermitRequestEdmontonForm(), request)
        {            
            service = ClientServiceRegistry.Instance.GetService<IPermitRequestEdmontonService>();
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            craftOrTradeService = ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>();
            contractorService = ClientServiceRegistry.Instance.GetService<IContractorService>();
            formService = ClientServiceRegistry.Instance.GetService<IFormEdmontonService>();
            areaLabelService = ClientServiceRegistry.Instance.GetService<IAreaLabelService>();

            view.Load += HandleFormLoad;
            view.ViewEditHistoryButtonClicked += ViewEditHistoryButton_Click;
            view.FunctionalLocationButtonClicked += HandleFunctionalLocationButtonClicked;
            view.SubmitAndCloseButtonClicked += HandleSubmitAndCloseButtonClicked;
            view.ValidateButtonClicked += HandleValidateButtonClicked;
            view.SelectFormGN1ButtonClicked += HandleSelectFormGN1ButtonClicked;
            view.SelectFormGN6ButtonClicked += HandleSelectFormGN6ButtonClicked;            
            view.SelectFormGN7ButtonClicked += HandleSelectFormGN7ButtonClicked;
            view.SelectFormGN59ButtonClicked += HandleSelectFormGN59ButtonClicked;
            view.SelectFormGN24ButtonClicked += HandleSelectFormGN24ButtonClicked;
            view.SelectFormGN75AButtonClicked += HandleSelectFormGN75AButtonClicked;

            view.FormGN1CheckBoxCheckChanged += HandleFormGN1CheckBoxChanged;
        }

        private static PermitRequestEdmonton CreateDefaultPermitRequest()
        {
            DateTime now = Clock.Now;
            Date defaultDate = now.ToDate();
            User currentUser = ClientSession.GetUserContext().User;

            PermitRequestEdmonton request = new PermitRequestEdmonton(
                null, defaultDate, null, null, null, DataSource.MANUAL, null, null, null, null, currentUser, now, currentUser, now);

            UserShift userShift = ClientSession.GetUserContext().UserShift;
            DateTime shiftStartDateTime = userShift.StartDateTime;
            DateTime shiftEndDateTime = userShift.EndDateTime;
            DateTime currentDateTime = Clock.Now;

            DateTime startDateTime = currentDateTime >= shiftStartDateTime ? currentDateTime : shiftStartDateTime;
            DateTime endDateTime = currentDateTime >= shiftEndDateTime ? currentDateTime : shiftEndDateTime;

            request.RequestedStartDate = startDateTime.ToDate();                   
            request.EndDate = endDateTime.ToDate();

            if(startDateTime.ToTime().InRange(WorkPermitEdmonton.DayShiftStartTime, WorkPermitEdmonton.NightShiftStartTime))
            {
                request.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
                request.RequestedStartTimeNight = null;
            }
            else
            {
                request.RequestedStartTimeDay = null;
                request.RequestedStartTimeNight = WorkPermitEdmonton.PermitDefaultNightStart;
            }

            return request;
        }
       
        private void HandleFormLoad(object sender, EventArgs e)
        {
            LoadData(new List<Action> { QueryCraftOrTrades, QueryContractors, QueryAreaLabels, QueryGroups, LoadRoadOnAccessPermitList, LoadSpecialWorkList });
        }

        private void LoadSpecialWorkList()
        {
            specialWorkList =
                ClientServiceRegistry.Instance.GetService<ISpecialWorkService>().QueryBySite(userContext.Site);
        }

        private void LoadRoadOnAccessPermitList()
        {
            roadAccessPermitList =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySiteIdRoadAccessOnPermit(userContext.Site);
        }

        protected override void AfterDataLoad()
        {
            view.PopulateFunctionalLocationSelector(userContext.HasFlocsForWorkPermits ? userContext.RootFlocSetForWorkPermits.FunctionalLocations : userContext.RootFlocSet.FunctionalLocations);
            SetToolTips();
            SetupRoadOnAccessPermitList();
            SetupSpecialWorkList();
            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.PermitRequestFormTitle);
            view.ViewEditHistoryEnabled = IsEdit;

            List<WorkPermitEdmontonType> workPermitTypes = new List<WorkPermitEdmontonType>(WorkPermitEdmontonType.All);
            workPermitTypes.Insert(0, WorkPermitEdmontonType.NULL);
            view.AllPermitTypes = workPermitTypes;
            
            areaLabels.Insert(0, AreaLabel.EMPTY);
            view.AreaLabels = AreaLabel.ManuallySelectableAreaLabels(editObject.AreaLabel, areaLabels);

            contractors.Sort((x, y) => string.Compare(x.CompanyName, y.CompanyName, StringComparison.Ordinal));
            contractors.Insert(0, Contractor.EMPTY);
            view.AllCompanies = contractors;

            PermitFormHelper.SortCraftOrTrades(craftOrTrades);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
            view.AllCraftOrTrades = craftOrTrades;

            view.AllAffectedAreas = PermitFormHelper.GetAreasAffectedList();            
            view.AllGroups = groups;
            view.Priorities = new List<Priority>(WorkPermitEdmonton.Priorities);

            view.AlkylationEntryClassOfClothingSelectionList = PermitFormHelper.GetABCDSelectionList();
            view.FlarePitEntryTypeSelectionList = PermitFormHelper.Get12SelectionList();
            view.ConfinedSpaceClassSelectionList = PermitFormHelper.GetConfinedSpaceClassSelectionList();
            view.SpecialWorkTypeSelectionList = EdmontonPermitSpecialWorkType.GetAllAsList();

            view.GN11Values = WorkPermitSafetyFormState.AllValues;
            view.GN27Values = WorkPermitSafetyFormState.AllValues;            

            UpdateViewFromEditObject();

            if (IsEdit)
            {
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), editObject.DataSource);
                validator.Validate();
            }
        }

        private void HandleFormGN1CheckBoxChanged()
        {
            EdmontonPermitSharedPresenterLogic.HandleFormGN1CheckBoxChanged(view);
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
            locationChangedByUser = view.Location != WorkPermitEdmonton.GetLocation(view.FunctionalLocation);
        }

        private void UpdateViewFromEditObject()
        {
            view.LastModifiedBy = editObject.LastModifiedBy;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;

            view.IssuedToSuncor = editObject.IssuedToSuncor;
            view.Company = editObject.Company;
            view.Occupation = editObject.Occupation;
            view.NumberOfWorkers = editObject.NumberOfWorkers;
            view.Group = editObject.Group;
            view.WorkPermitType = editObject.WorkPermitType;            
            view.FunctionalLocation = editObject.FunctionalLocation;            
            view.Location = editObject.Location;
                        
            UpdateTypeOfWorkSectionFromEditObject();

            view.DocumentLinks = editObject.DocumentLinks;
            view.Priority = editObject.Priority;

            view.RequestedStartDate = editObject.RequestedStartDate;

            // This is because the checkchanged event only fires if changed, so we can't always rely on it to enable the field
            bool startTimeDayHasValue = editObject.RequestedStartTimeDay != null;
            view.RequestedStartDayTimeCheckboxChecked = startTimeDayHasValue;
            view.RequestedStartTimeDayPickerEnabled = startTimeDayHasValue;

            bool startTimeNightHasValue = editObject.RequestedStartTimeNight != null;
            view.RequestedStartNightTimeCheckboxChecked = startTimeNightHasValue;
            view.RequestedStartTimeNightPickerEnabled = startTimeNightHasValue;

            view.RequestedStartTimeDay = editObject.RequestedStartTimeDay;
            view.RequestedStartTimeNight = editObject.RequestedStartTimeNight;
            view.RequestedEndDate = editObject.EndDate;

            view.Description = editObject.Description;
            view.SapDescription = editObject.SapDescription;
            view.HazardsAndOrRequirements = editObject.HazardsAndOrRequirements;

            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.OperationNumber = editObject.OperationNumberListAsString;

            view.AreaLabel = editObject.AreaLabel;

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

            view.SetOtherAreasAndOrUnitsAffected(editObject.OtherAreasAndOrUnitsAffectedArea, editObject.OtherAreasAndOrUnitsAffectedPersonNotified);                        

            UpdateWorkersMinimumSafetyRequirementsFromEditObject();

            // --------------

            bool isManualOrClone = editObject.DataSource.Equals(DataSource.MANUAL) || editObject.DataSource.Equals(DataSource.CLONE);
            view.WorkOrderNumberEnabled = isManualOrClone;
            view.OperationNumberEnabled = isManualOrClone;
            view.SubOperationNumberEnabled = isManualOrClone;
            view.SapDescriptionVisible = editObject.IsSAPDescriptionAvailableForDisplay;
        }

        private void UpdateWorkersMinimumSafetyRequirementsFromEditObject()
        {
            view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = editObject.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            view.FaceShield = editObject.FaceShield;
            view.Goggles = editObject.Goggles;
            view.RubberBoots = editObject.RubberBoots;
            view.RubberGloves = editObject.RubberGloves;
            view.RubberSuit = editObject.RubberSuit;
            view.SafetyHarnessLifeline = editObject.SafetyHarnessLifeline;
            view.HighVoltagePPE = editObject.HighVoltagePPE;
            view.Other1Value = editObject.Other1;

            view.EquipmentGrounded = editObject.EquipmentGrounded;
            view.FireBlanket = editObject.FireBlanket;
            view.FireExtinguisher = editObject.FireExtinguisher;
            view.FireMonitorManned = editObject.FireMonitorManned;
            view.FireWatch = editObject.FireWatch;
            view.SewersDrainsCovered = editObject.SewersDrainsCovered;
            view.SteamHose = editObject.SteamHose;
            view.Other2Value = editObject.Other2;

            view.AirPurifyingRespirator = editObject.AirPurifyingRespirator;
            view.BreathingAirApparatus = editObject.BreathingAirApparatus;
            view.DustMask = editObject.DustMask;
            view.LifeSupportSystem = editObject.LifeSupportSystem;
            view.SafetyWatch = editObject.SafetyWatch;
            view.ContinuousGasMonitor = editObject.ContinuousGasMonitor;
            view.WorkersMonitor = editObject.WorkersMonitor;
            view.WorkersMonitorNumber = editObject.WorkersMonitorNumber;
            view.BumpTestMonitorPriorToUse = editObject.BumpTestMonitorPriorToUse;
            view.Other3Value = editObject.Other3; 

            view.AirMover = editObject.AirMover;
            view.BarriersSigns = editObject.BarriersSigns;
            view.RadioChannel = editObject.RadioChannel;
            view.RadioChannelNumber = editObject.RadioChannelNumber;
            view.AirHorn = editObject.AirHorn;
            view.MechVentilationComfortOnly = editObject.MechVentilationComfortOnly;
            view.AsbestosMMCPrecautions = editObject.AsbestosMMCPrecautions;
            view.Other4Value = editObject.Other4;
        }

        private void UpdateEditObjectFromView()
        {           
            editObject.LastModifiedBy = userContext.User;
            editObject.LastModifiedDateTime = Clock.Now;

            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.Company = view.Company;

            editObject.Occupation = view.Occupation;
            editObject.NumberOfWorkers = view.NumberOfWorkers;
            editObject.Group = view.Group;
            editObject.WorkPermitType = view.WorkPermitType;            
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;            

            UpdateEditObjectWithTypeOfWorkSectionData();
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.Priority = view.Priority;

            editObject.RequestedStartDate = view.RequestedStartDate;
           
            editObject.RequestedStartTimeDay = view.RequestedStartTimeDay;
            editObject.RequestedStartTimeNight = view.RequestedStartTimeNight;
            editObject.EndDate = view.RequestedEndDate;

            if (DataSource.MANUAL.Equals(editObject.DataSource))
            {
                editObject.ClearWorkOrderSources();
                editObject.AddWorkOrderSource(view.WorkOrderNumber, view.OperationNumber, view.SubOperationNumber);
            }

            editObject.Description = view.Description;
            editObject.SapDescription = view.SapDescription;
            editObject.HazardsAndOrRequirements = view.HazardsAndOrRequirements;
            editObject.AreaLabel = view.AreaLabel == AreaLabel.EMPTY ? null : view.AreaLabel;

            editObject.OtherAreasAndOrUnitsAffectedArea = view.OtherAreasAndOrUnitsAffectedArea;
            editObject.OtherAreasAndOrUnitsAffectedPersonNotified = view.OtherAreasAndOrUnitsAffectedPersonNotified;
          
            UpdateEditObjectWithWorkersMinimumSafetyRequirementsSectionData();
        }

        private void UpdateEditObjectWithWorkersMinimumSafetyRequirementsSectionData()
        {
            editObject.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = view.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

            editObject.FaceShield = view.FaceShield;
            editObject.Goggles = view.Goggles;
            editObject.RubberBoots = view.RubberBoots;
            editObject.RubberGloves = view.RubberGloves;
            editObject.RubberSuit = view.RubberSuit;
            editObject.SafetyHarnessLifeline = view.SafetyHarnessLifeline;
            editObject.HighVoltagePPE = view.HighVoltagePPE;
            editObject.Other1 = view.Other1Value; 

            editObject.EquipmentGrounded = view.EquipmentGrounded;
            editObject.FireBlanket = view.FireBlanket;
            editObject.FireExtinguisher = view.FireExtinguisher;
            editObject.FireMonitorManned = view.FireMonitorManned;
            editObject.FireWatch = view.FireWatch;
            editObject.SewersDrainsCovered = view.SewersDrainsCovered;
            editObject.SteamHose = view.SteamHose;
            editObject.Other2 = view.Other2Value;

            editObject.AirPurifyingRespirator = view.AirPurifyingRespirator;
            editObject.BreathingAirApparatus = view.BreathingAirApparatus;
            editObject.DustMask = view.DustMask;
            editObject.LifeSupportSystem = view.LifeSupportSystem;
            editObject.SafetyWatch = view.SafetyWatch;
            editObject.ContinuousGasMonitor = view.ContinuousGasMonitor;
            editObject.WorkersMonitor = view.WorkersMonitor;
            editObject.WorkersMonitorNumber = view.WorkersMonitorNumber;
            editObject.BumpTestMonitorPriorToUse = view.BumpTestMonitorPriorToUse;
            editObject.Other3 = view.Other3Value;

            editObject.AirMover = view.AirMover;
            editObject.BarriersSigns = view.BarriersSigns;
            editObject.RadioChannel = view.RadioChannel;
            editObject.RadioChannelNumber = view.RadioChannelNumber;
            editObject.AirHorn = view.AirHorn;
            editObject.MechVentilationComfortOnly = view.MechVentilationComfortOnly;
            editObject.AsbestosMMCPrecautions = view.AsbestosMMCPrecautions;
            editObject.Other4 = view.Other4Value;
        }

        private void UpdateEditObjectWithTypeOfWorkSectionData()
        {
            editObject.AlkylationEntry = view.AlkylationEntry;
            editObject.FlarePitEntry = view.FlarePitEntry;
            editObject.ConfinedSpace = view.ConfinedSpace;
            editObject.RescuePlan = view.RescuePlan;
            editObject.VehicleEntry = view.VehicleEntry;
            editObject.SpecialWork = view.SpecialWork;

            editObject.AlkylationEntryClassOfClothing = view.AlkylationEntryClassOfClothing;
            editObject.FlarePitEntryType = view.FlarePitEntryType;
            editObject.ConfinedSpaceClass = view.ConfinedSpaceClass;
            editObject.ConfinedSpaceCardNumber = view.ConfinedSpaceCardNumber;
            
            editObject.RescuePlanFormNumber = view.RescuePlanFormNumber;
            editObject.VehicleEntryTotal = view.VehicleEntryTotal;
            editObject.VehicleEntryType = view.VehicleEntryType;
            editObject.SpecialWorkType = view.SpecialWorkType;
            editObject.SpecialWorkFormNumber = view.SpecialWorkFormNumber;

            editObject.specialworktype = view.specialworktype;//mangesh for SpecialWork
            editObject.SpecialWorkName = view.SpecialWorkName;

            editObject.RoadAccessOnPermit = view.RoadAccessOnPermit;
            editObject.RoadAccessOnPermitFormNumber = view.RoadAccessOnPermit ? view.RoadAccessOnPermitFormNumber : null;
            editObject.RoadAccessOnPermitType = view.RoadAccessOnPermit ? view.RoadAccessOnPermitType : null;

            editObject.FormGN59 = view.FormGN59;
            editObject.FormGN6 = view.FormGN6;
            editObject.FormGN7 = view.FormGN7;
            editObject.FormGN24 = view.FormGN24;
            editObject.FormGN75A = view.FormGN75A;
            editObject.FormGN1 = view.FormGN1;
            editObject.FormGN1TradeChecklistId = view.FormGN1TradeChecklistId;
            editObject.FormGN1TradeChecklistDisplayNumber = view.FormGN1TradeChecklistNumber;

            editObject.GN59 = view.GN59;
            editObject.GN6 = view.GN6;
            editObject.GN7 = view.GN7;
            editObject.GN24 = view.GN24;
            editObject.GN75A = view.GN75A;
            editObject.GN1 = view.GN1;

            editObject.GN11 = view.GN11;
            editObject.GN27 = view.GN27;            
        }

        private void UpdateTypeOfWorkSectionFromEditObject()
        {
            view.FormGN1 = editObject.FormGN1;
            view.FormGN1TradeChecklistId = editObject.FormGN1TradeChecklistId;
            view.FormGN1TradeChecklistNumber = editObject.FormGN1TradeChecklistDisplayNumber;

            view.AlkylationEntry = editObject.AlkylationEntry;
            view.FlarePitEntry = editObject.FlarePitEntry;

            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.RescuePlan = editObject.RescuePlan;
            view.ConfinedSpace = editObject.ConfinedSpace; // zzz

            view.VehicleEntry = editObject.VehicleEntry;
            view.SpecialWork = editObject.SpecialWork;

            view.AlkylationEntryClassOfClothingEnabled = editObject.AlkylationEntry;
            view.FlarePitEntryTypeEnabled = editObject.FlarePitEntry;
            view.ConfinedSpaceClassEnabled = editObject.ConfinedSpace;
            view.ConfinedSpaceCardNumberEnabled = editObject.ConfinedSpace;
            view.RescuePlanFormNumberEnabled = editObject.RescuePlan;
            view.VehicleEntryTotalEnabled = editObject.VehicleEntry;
            view.VehicleEntryTypeEnabled = editObject.VehicleEntry;
            view.SpecialWorkTypeEnabled = editObject.SpecialWork;
            view.SpecialWorkFormNumberEnabled = editObject.SpecialWork;

            view.RoadAccessOnPermit = editObject.RoadAccessOnPermit;
            view.RoadAccessOnPermitFormNumber = editObject.RoadAccessOnPermitFormNumber;
            view.RoadAccessOnPermitType = editObject.RoadAccessOnPermitType;

            view.AlkylationEntryClassOfClothing = editObject.AlkylationEntryClassOfClothing;
            view.FlarePitEntryType = editObject.FlarePitEntryType;
            view.ConfinedSpaceCardNumber = editObject.ConfinedSpaceCardNumber;            
            view.RescuePlanFormNumber = editObject.RescuePlanFormNumber;
            view.VehicleEntryTotal = editObject.VehicleEntryTotal;
            view.VehicleEntryType = editObject.VehicleEntryType;
            view.SpecialWorkFormNumber = editObject.SpecialWorkFormNumber;
            view.SpecialWorkType = editObject.SpecialWorkType;

            view.specialworktype = editObject.specialworktype;//mangesh for SpecialWork
            view.SpecialWorkName = editObject.SpecialWorkName;

            view.FormGN59 = editObject.FormGN59;
            view.FormGN6 = editObject.FormGN6;
            view.FormGN7 = editObject.FormGN7;
            view.FormGN24 = editObject.FormGN24;
            view.FormGN75A = editObject.FormGN75A;
            
            view.GN59 = editObject.GN59;
            view.GN6 = editObject.GN6;
            view.GN7 = editObject.GN7;
            view.GN24 = editObject.GN24;
            view.GN75A = editObject.GN75A;
            view.GN1 = editObject.GN1;

            view.GN11 = editObject.GN11;
            view.GN27 = editObject.GN27;            

            if (editObject.WorkPermitType != null && editObject.WorkPermitType.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK) && !editObject.Group.Name.ToLower().Contains("turnaround")  && editObject.Group != WorkPermitEdmontonType.COLD_WORK)
            {
                // In this case, GN-59 has to be selected.
                view.GN59CheckBoxEnabled = false;
            }

            if (view.GN1)
            {
                EdmontonPermitSharedPresenterLogic.UpdateFieldsAfterSelectingFormGN1(view);
            }
            else
            {
                view.ApplyConfinedSpaceClassFormRules();    
            }            
        }

        private void HandleSelectFormGN7ButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            var formPage = new FormPage<FormEdmontonDTO, FormEdmontonDetails>(new FormEdmontonDetails(), range);
            var presenter = new SelectFormPresenter<FormEdmontonDTO, FormGN7, FormEdmontonDetails, FormPage<FormEdmontonDTO, FormEdmontonDetails>>(EdmontonFormType.GN7, formPage, range);

            long? formId = null;
            if (view.FormGN7 != null)
            {
                formId = view.FormGN7.Id;
            }

            DialogResultAndOutput<FormEdmontonDTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN7 form = formService.QueryFormGN7ById(formDto.IdValue);
                view.FormGN7 = form;
            }
        }

        private DialogResult ChooseTradeChecklist(long formId)
        {            
            List<TradeChecklistInfo> displayItems = formService.QueryFormGN1TradeChecklistDisplayItemsByFormGN1Id(formId);

            SelectTradeChecklistForm form = new SelectTradeChecklistForm(displayItems);
            DialogResult result = form.ShowDialog(view);

            if (DialogResult.OK.Equals(result))
            {                
                view.FormGN1TradeChecklistNumber = form.SelectedTradeChecklistNumber;
                view.FormGN1TradeChecklistId = form.SelectedTradeChecklistId;
                return DialogResult.OK;
            }

            return DialogResult.Cancel;
        }

        private void HandleViewTradeChecklist(TradeChecklist selectedTradeChecklist)
        {
            EdmontonGN1FormSingleTradeChecklistPrintActions checklistPrintActions = new EdmontonGN1FormSingleTradeChecklistPrintActions(selectedTradeChecklist);
            IReportPrintManager<FormGN1> tradeChecklistReportPrintManager =
                new ReportPrintManager<FormGN1, FormGN1SingleTradeChecklistReport, FormGN1TradeChecklistReportAdapter>(checklistPrintActions);

            if (gn1FormPage != null)
            {
                FormEdmontonGN1DTO formEdmontonGn1Dto = gn1FormPage.FirstSelectedItem;
                FormGN1 selectedFormGn1 = formService.QueryFormGN1ById(formEdmontonGn1Dto.IdValue);
                tradeChecklistReportPrintManager.PreviewReport(selectedFormGn1);
            }
        }

        private FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details> gn1FormPage;

        private void HandleSelectFormGN1ButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            FormEdmontonGN1Details formEdmontonGn1Details = new FormEdmontonGN1Details();
            formEdmontonGn1Details.ViewTradeChecklist += HandleViewTradeChecklist;

            gn1FormPage = new FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details>(formEdmontonGn1Details, range, false,true);
            var presenter = new SelectFormPresenter<FormEdmontonGN1DTO, FormGN1, FormEdmontonGN1Details, FormPage<FormEdmontonGN1DTO, FormEdmontonGN1Details>>(EdmontonFormType.GN1, gn1FormPage, ChooseTradeChecklist, true, range);

            long? formId = null;
            if (view.FormGN1 != null)
            {
                formId = view.FormGN1.Id;
            }

            DialogResultAndOutput<FormEdmontonGN1DTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN1 form = formService.QueryFormGN1ById(formDto.IdValue);
                view.FormGN1 = form;
                EdmontonPermitSharedPresenterLogic.UpdateFieldsAfterSelectingFormGN1(view);
                EdmontonPermitSharedPresenterLogic.AddInNewDocumentLinks(view, form.DocumentLinks);
            }

            formEdmontonGn1Details.ViewTradeChecklist -= HandleViewTradeChecklist;
        }

        private void HandleSelectFormGN6ButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            var formPage = new FormPage<FormEdmontonGN6DTO, FormEdmontonGN6Details>(new FormEdmontonGN6Details(), range);
            var presenter = new SelectFormPresenter<FormEdmontonGN6DTO, FormGN6, FormEdmontonGN6Details, FormPage<FormEdmontonGN6DTO, FormEdmontonGN6Details>>(EdmontonFormType.GN6, formPage, range);

            long? formId = null;
            if (view.FormGN6 != null)
            {
                formId = view.FormGN6.Id;
            }

            DialogResultAndOutput<FormEdmontonGN6DTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN6 form = formService.QueryFormGN6ById(formDto.IdValue);
                view.FormGN6 = form;
            }
        }

        private void HandleSelectFormGN59ButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            var formPage = new FormPage<FormEdmontonDTO, FormEdmontonDetails>(new FormEdmontonDetails(), range);
            var presenter = new SelectFormPresenter<FormEdmontonDTO, FormGN59, FormEdmontonDetails, FormPage<FormEdmontonDTO, FormEdmontonDetails>>(EdmontonFormType.GN59, formPage, range);

            long? formId = null;
            if (view.FormGN59 != null)
            {
                formId = view.FormGN59.Id;
            }

            DialogResultAndOutput<FormEdmontonDTO> dialogResultAndOutput = presenter.Run(view, formId);


            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN59 form = formService.QueryFormGN59ById(formDto.IdValue);
                view.FormGN59 = form;
            }
        }

        private void HandleSelectFormGN24ButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            var formPage = new FormPage<FormEdmontonGN24DTO, FormEdmontonGN24Details>(new FormEdmontonGN24Details(), range, false,false);
            var presenter = new SelectFormPresenter<FormEdmontonGN24DTO, FormGN24, FormEdmontonGN24Details, FormPage<FormEdmontonGN24DTO, FormEdmontonGN24Details>>(EdmontonFormType.GN24, formPage, range);

            long? formId = null;
            if (view.FormGN24 != null)
            {
                formId = view.FormGN24.Id;
            }

            DialogResultAndOutput<FormEdmontonGN24DTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN24 form = formService.QueryFormGN24ById(formDto.IdValue);
                view.FormGN24 = form;
            }
        }

        private void HandleSelectFormGN75AButtonClicked()
        {
            Range<Date> range = new Range<Date>(view.RequestedStartDate, view.RequestedEndDate);
            var formPage = new FormPage<FormEdmontonGN75ADTO, FormEdmontonGN75ADetails>(new FormEdmontonGN75ADetails(), range, false,false);
            var presenter = new SelectFormPresenter<FormEdmontonGN75ADTO, FormGN75A, FormEdmontonGN75ADetails, FormPage<FormEdmontonGN75ADTO, FormEdmontonGN75ADetails>>(EdmontonFormType.GN75A, formPage, range);

            long? formId = null;

            if(view.FormGN75A != null)
            {
                formId = view.FormGN75A.Id;
            }

            DialogResultAndOutput<FormEdmontonGN75ADTO> dialogResultAndOutput = presenter.Run(view, formId);

            if (dialogResultAndOutput.Result == DialogResult.OK)
            {
                FormEdmontonDTO formDto = dialogResultAndOutput.Output;
                FormGN75A form = formService.QueryFormGN75AById(formDto.IdValue);
                view.FormGN75A = form;
            }
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
                    view.Location = WorkPermitEdmonton.GetLocation(floc);
                }
            }
        }

        private void ViewEditHistoryButton_Click()
        {
            EditPermitRequestEdmontonHistoryFormPresenter presenter = new EditPermitRequestEdmontonHistoryFormPresenter(editObject);
            presenter.Run(view);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            view.ClearErrorProviders();
            
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), editObject.DataSource);
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
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), editObject.DataSource);
            validator.Validate();

            editObject.CompletionStatus = validator.CompletionStatus;

            bool requestIsSubmittable = !validator.HasErrors && (!validator.HasWarnings || PermitRequestCompletionStatus.ForReview.Equals(editObject.CompletionStatus));

            if (requestIsSubmittable)
            {
                PerformSubmit();
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

            CheckPermitRequestAssociationAlreadyExists<PermitRequestEdmontonDTO> checkPermitRequestAssociationAlreadyExists = null;

            if (IsEdit)
            {
                checkPermitRequestAssociationAlreadyExists = CheckPermitRequestAssociationAlreadyExists;
            }

            SubmitPermitRequests<PermitRequestEdmontonDTO> submitPermitRequests = SubmitPermitRequests;
            List<PermitRequestEdmontonDTO> dtos = new List<PermitRequestEdmontonDTO> {new PermitRequestEdmontonDTO(editObject)};
            SubmitPermitRequestEdmontonFormPresenter presenter = new SubmitPermitRequestEdmontonFormPresenter(dtos,
                                                                                                              submitPermitRequests,
                                                                                                              checkPermitRequestAssociationAlreadyExists,
                                                                                                              true);

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
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationViewAdapter(view), editObject.DataSource);
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
       
        private bool CheckPermitRequestAssociationAlreadyExists(Date workPermitDate, List<PermitRequestEdmontonDTO> requestDtos)
        {
            return workPermitService.DoesPermitRequestEdmontonAssociationExist(requestDtos, workPermitDate);
        }

        private void SubmitPermitRequests(Date workPermitDate, List<PermitRequestEdmontonDTO> requestDtos, User user)
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

        private void SetToolTips()
        {
            view.SetFormGN11ToolTip(StringResources.FormGN11Description);
            view.SetFormGN24ToolTip(StringResources.FormGN24Description);
            view.SetFormGN27ToolTip(StringResources.FormGN27Description);
            view.SetFormGN59ToolTip(StringResources.FormGN59Description);
            view.SetFormGN6ToolTip(StringResources.FormGN6Description);
            view.SetFormGN75ToolTip(StringResources.FormGN75Description);
            view.SetFormGN7ToolTip(StringResources.FormGN7Description);
            view.SetFormGN1ToolTip(StringResources.FormGN1Description);
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
            view.AllSpecialWorkType = specialWorkList;
        }

    }
}
