using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Reports.Printing;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Validation.FortHills;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports;
using Com.Suncor.Olt.Reports.Adapters;

namespace Com.Suncor.Olt.Client.Presenters
{
    public enum WorkPermitFortHillsTab
    {
        RunningUnit,
        Turnaround
    };


    public class WorkPermitFortHillsFormPresenter : AddEditBaseFormPresenter<IWorkPermitFortHillsView, WorkPermitFortHills>, IWorkPermitFortHillsPrintable
    {
        private readonly WorkPermitFortHillsTab currentTab = WorkPermitFortHillsTab.RunningUnit;
        private readonly IBusinessCategoryService businessCategoryService;
        private readonly bool isClone;
        private readonly bool isExtension;
        private readonly bool isMerge;
        private readonly List<long> mergeSourcePermitIdList = new List<long>();
        private static ITimeService timeService;

        private readonly IReportPrintManager<WorkPermitFortHills> printManager;
        private readonly IWorkPermitFortHillsService service;

        //private readonly ISpecialWorkService specialWorkService;
        private List<SpecialWork> specialWorkList;

        private List<AreaLabel> areaLabels;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<Contractor> contractors;
        private List<CraftOrTrade> craftOrTrades;
        private List<CraftOrTrade> roadAccessPermitList;
        
        private List<WorkPermitFortHillsGroup> groups;

        private bool locationChangedByUser;
       
        private bool userChangedExpireTime;
        private bool saveandIssue;



        public WorkPermitFortHillsFormPresenter(WorkPermitFortHillsTab tab)
            : this(null)
        {
            currentTab = tab;
        }

        private WorkPermitFortHillsFormPresenter(WorkPermitFortHills editObject, bool isMerge, bool isClone, bool isExtension)
            : base(new WorkPermitFortHillsForm(), editObject)
        {
            SubscribeToViewEvents();

            this.isMerge = isMerge;
            this.isClone = isClone;
            this.isExtension = isExtension;

            var clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IWorkPermitFortHillsService>();
            timeService = clientServiceRegistry.GetService<ITimeService>();
            businessCategoryService = clientServiceRegistry.GetService<IBusinessCategoryService>();
            //formService = clientServiceRegistry.GetService<IFormFortHillsService>();
           
            /* DMND0009632 - Fort Hills OLT - E-Permit Development */
            printManager =
                new ReportPrintManager<WorkPermitFortHills, WorkPermitFortHillsReport, WorkPermitFortHillsReportAdapter>(
                    new WorkPermitFortHillsPrintActions(this));
        }

        public WorkPermitFortHillsFormPresenter(WorkPermitFortHills editObject)
            : this(editObject, false, false,false)
        {
        }

        //public WorkPermitFortHillsFormPresenter(WorkPermitFortHills editObject, IEnumerable<long> mergeSourcePermitIdList)
        //    : this(editObject, true, false,false)
        //{
        //    this.mergeSourcePermitIdList.AddRange(mergeSourcePermitIdList);
        //}

        protected override bool IsClone
        {
            get { return isClone; }
        }

        private bool IsMerge
        {
            get { return isMerge; }
        }

        public void ShowUnableToPrintWithExpiryDateInPastMessage()
        {
            view.DisplayErrorMessageDialog(StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPast,
                StringResources.WorkPermitEdmonton_UnableToPrintWithExpiryDateInPastDialogTitle);
        }

        public void UpdateWorkPermit(WorkPermitFortHills permit)
        {
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, permit);
        }

        public void ShowPrintingFailedMessage()
        {
            view.DisplayInvalidPrintMessage(StringResources.WorkPermitPrintFailureMessageBoxText);
        }

        public bool? AskIfTheyWantToPrintTheForms()
        {
            var dialogResult =
                OltMessageBox.Show(Form.ActiveForm,
                    "Do you want to print all forms associated to this safe work permit?",
                    "Print Associated Forms?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Cancel) return null;
            return dialogResult == DialogResult.Yes;
        }

        public bool IsOnlyPrintingOnePermit { get; set; }
        public bool ShouldNotPrintForms { get; set; }

        public static WorkPermitFortHillsFormPresenter CreateForClone(WorkPermitFortHills editObject)
        {

            return new WorkPermitFortHillsFormPresenter(editObject, false, true,false);
        }
        public static WorkPermitFortHillsFormPresenter CreateForExtension(WorkPermitFortHills editObject)
        {
            editObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Issued;
            return new WorkPermitFortHillsFormPresenter(editObject, false, false,true);
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += HandleFormLoad;
            view.FunctionalLocationBrowseClicked += HandleFunctionalLocationClick;
            view.ValidateButtonClicked += HandleValidateButtonClick;
            view.SaveAndIssueButtonClicked += HandleSaveAndIssueButtonClick;
            //view.SelectFormGN1ButtonClicked += HandleSelectFormGN1ButtonClicked;
            //view.SelectFormGN6ButtonClicked += HandleSelectFormGN6ButtonClicked;
            //view.SelectFormGN7ButtonClicked += HandleSelectFormGN7ButtonClicked;
            //view.SelectFormGN59ButtonClicked += HandleSelectFormGN59ButtonClicked;
            //view.SelectFormGN24ButtonClicked += HandleSelectFormGN24ButtonClicked;
            //view.SelectFormGN75AButtonClicked += HandleSelectFormGN75AButtonClicked;

            //view.FormGN1CheckBoxCheckChanged += HandleFormGN1CheckChanged;

            view.PrintPreferencesButtonClicked += HandlePrintPreferencesButtonClicked;

           
            view.ExpireTimeChangedByUser += HandleExpireTimeChangedByUser;
            view.GroupChanged += HandleGroupChanged;

        }

        private void HandleExpireTimeChangedByUser()
        {
            userChangedExpireTime = true;
        }

       

        //private void HandleFormGN1CheckChanged()
        //{
        //    /* DMND0009632 - Fort Hills OLT - E-Permit Development commented*/
        //   // EdmontonPermitSharedPresenterLogic.HandleFormGN1CheckBoxChanged(view);
        //    view.ConfinedSpaceWorkSectionNotApplicableToJobEnabled = !view.GN1;
        //    view.ConfinedSpaceWorkSectionNotApplicableToJob = !view.GN1;

        //}

        private void LoadGroupsFromDatabase()
        {
            groups = service.QueryAllGroups();
        }

        private void LoadAreaLabelsFromDatabase()
        {
            areaLabels =
                ClientServiceRegistry.Instance.GetService<IAreaLabelService>()
                    .QueryBySiteId(ClientSession.GetUserContext().Site.IdValue);
        }

        //private void LoadSupervisorDropdownValuesFromDatabase()
        //{
        //    supervisorDropdownValues =
        //        ClientServiceRegistry.Instance.GetService<IDropdownValueService>()
        //            .QueryByKey(Site.FORT_HILLS_ID, WorkPermitEdmontonDropDownValueKeys.ShiftSupervisors);
        //}

        private void LoadConfiguredDocumentLinks()
        {
            configuredDocumentLinks =
                ClientServiceRegistry.Instance.GetService<IConfiguredDocumentLinkService>()
                    .GetLinks(ConfiguredDocumentLinkLocation.WorkPermitFortHills);
        }

        private void LoadContractors()
        {
            contractors = ClientServiceRegistry.Instance.GetService<IContractorService>().QueryBySite(userContext.Site);
        }

        private void LoadCraftOrTrades()
        {
            craftOrTrades =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySite(userContext.Site);
        }

        private void LoadRoadOnAccessPermitList()
        {
            roadAccessPermitList =
                ClientServiceRegistry.Instance.GetService<ICraftOrTradeService>().QueryBySiteIdRoadAccessOnPermit(userContext.Site);
        }

        private void LoadSpecialWorkList()
        {
            specialWorkList =
                ClientServiceRegistry.Instance.GetService<ISpecialWorkService>().QueryBySite(userContext.Site);
        }

        private void HandleFormLoad()
        {
            LoadData(new List<Action>
            {
                LoadGroupsFromDatabase,
                LoadAreaLabelsFromDatabase,
                //LoadSupervisorDropdownValuesFromDatabase,
                LoadConfiguredDocumentLinks,
                LoadContractors,
                LoadCraftOrTrades,
                LoadRoadOnAccessPermitList,
                LoadSpecialWorkList
            });
        }

        protected override void AfterDataLoad()
        {
            view.PopulateFunctionalLocationSelector(userContext.HasFlocsForWorkPermits
                ? userContext.RootFlocSetForWorkPermits.FunctionalLocations
                : userContext.RootFlocSet.FunctionalLocations);

            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.CreateOrEditWorkPermitFormTitle);
            
            view.IsEdit = IsEdit;
            view.IsExtension = IsExtension;
            view.IsClone = IsClone;
            
            SetupWorkPermitTypesList();
            SetupContractorsList();
            SetupCraftOrTradesList();
            SetupRoadOnAccessPermitList();
            SetupSpecialWorkList();
            //SetToolTips();
            DisableTheSaveAndIssueButtonIfNecessary();

            view.AllGroups = groups;
           // view.AllAffectedAreas = PermitFormHelper.GetAreasAffectedList();

            var areaLabelsFromDb = new List<AreaLabel>(areaLabels);
            areaLabelsFromDb.Insert(0, AreaLabel.EMPTY);
            //view.AreaLabels = AreaLabel.ManuallySelectableAreaLabels(editObject == null ? null : editObject.AreaLabel,
            //    areaLabelsFromDb);

            //view.AlkylationEntryClassOfClothingSelectionList = PermitFormHelper.GetABCDSelectionList();
            
            //view.FlarePitEntryTypeSelectionList = PermitFormHelper.Get12SelectionList();
            
            view.ConfinedSpaceClassSelectionList = PermitFormHelper.GetConfinedSpaceClassSelectionList();
            //view.SpecialWorkTypeSelectionList = EdmontonPermitSpecialWorkType.GetAllAsList();
            view.Priorities = new List<Priority>(WorkPermitFortHills.Priorities);

            //view.ShiftSupervisorSelectionList =
            //    WorkPermitFortHillsDropDownValueKeys.ShiftSupervisorDropdownValues(supervisorDropdownValues);

           
           // view.AllowEventsToOverrideUserSelectedCheckboxes = false;
            view.ExtensionDateTimeVisible = false;
            if (IsMerge)
            {
                // set defaults for the View
                UpdateViewWithDefaults();
                // Clear items in Edit object that aren't suppose to be merged.
                editObject.RequestedStartDateTime = view.RequestedStartDateTime;
                editObject.ExpiredDateTime = view.ExpiryDateTime;
                editObject.IssuedDateTime = null;
                editObject.LastModifiedDateTime = Clock.Now;
                
                // Now set the View with items from Edit object.
                UpdateViewFromEditObject();
            }
            else if (IsEdit)
            {
               // SetupSafetyFormStateValuesWithoutIncludingEmpty();
                UpdateViewFromEditObject();
            }
            else if (IsClone)
            {
              //  SetupSafetyFormStateValuesWithoutIncludingEmpty();
                UpdateViewFromEditObject();
                view.RequestedStartDateTime = ClientSession.GetUserContext().UserShift.StartDateTime;
                view.ExpiryDateTime = ClientSession.GetUserContext().UserShift.EndDateTime;
            }
            else if (!IsClone && !IsEdit && !isExtension)
            {
                view.RequestedStartDateTime = ClientSession.GetUserContext().UserShift.StartDateTime;
                view.ExpiryDateTime = ClientSession.GetUserContext().UserShift.EndDateTime;
                
            }
            else
            {
                UpdateViewWithDefaults();
            }

            var userIsEditingAPermitThatCameFromAPermitRequest = editObject != null &&
                                                                 editObject.DataSource.Equals(DataSource.PERMIT_REQUEST);

            view.WorkOrderNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;
            view.OperationNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;
            view.SubOperationNumberReadOnly = userIsEditingAPermitThatCameFromAPermitRequest;

           // view.AllowEventsToOverrideUserSelectedCheckboxes = true;

          //  SetInitialExpiredDateTime();
           
            if (editObject == null)
            {
                editObject = CreatePermit(PermitRequestBasedWorkPermitStatus.Requested, DataSource.MANUAL);
            }

            if (IsMerge)
            {
                view.ClearErrorProviders();
                var validator = CreateValidator();
                validator.ValidateAndSetErrors(Clock.Now);
            }
            if (isExtension)
            {
                view.DisableAllcontrolsforExtension();
                view.ExtensionDateTimeVisible = true;
            }
           

        }


        private void DisableTheSaveAndIssueButtonIfNecessary()
        {
            var authorized = new Authorized();
            if (!authorized.HasPrintPermitRoleElement(userContext.UserRoleElements))
            {
                view.SaveAndIssueButtonEnabled = false;
            }
        }

        private void SetInitialExpiredDateTime()
        {
            var expiryIsInSessionStore = SessionStore.HasEdmontonWorkPermitExpiryInSessionStore();
            if (IsNew || IsClone)
            {
                if (expiryIsInSessionStore)
                {
                    SetExpiredDateTimeFromSessionStore();
                }
                else
                {
                    SetEndDateTimesToDefaultsForGroup();
                }
            }
            else if (IsEdit)
            {
                if (expiryIsInSessionStore)
                {
                    SetExpiredDateTimeFromSessionStore();
                }
            }
            else if (IsMerge)
            {
                SetEndDateTimesToDefaultsForGroup();
            }
        }

        private void SetExpiredDateTimeFromSessionStore()
        {
            var previousTimeOnExpiryControl = view.ExpiryDateTime;
            var dateTimeInSessionStore = SessionStore.GetFortHillsWorkPermitExpiryFromSessionStore();
            if (dateTimeInSessionStore.HasValue)
            {
                view.ExpiryDateTime = dateTimeInSessionStore.Value;
                if (!previousTimeOnExpiryControl.Equals(view.ExpiryDateTime))
                {
                    view.TurnOnAutosetIndicatorsForDateTimes();
                }
            }
        }

        private void HandleGroupChanged()
        {
            if (userChangedExpireTime || SessionStore.HasEdmontonWorkPermitExpiryInSessionStore())
                return;
            SetEndDateTimesToDefaultsForGroup();
        }

        //private void SetToolTips()
        //{
        //    view.SetFormGN1ToolTip(StringResources.FormGN1Description);
        //    view.SetFormGN11ToolTip(StringResources.FormGN11Description);
        //    view.SetFormGN24ToolTip(StringResources.FormGN24Description);
        //    view.SetFormGN27ToolTip(StringResources.FormGN27Description);
        //    view.SetFormGN59ToolTip(StringResources.FormGN59Description);
        //    view.SetFormGN6ToolTip(StringResources.FormGN6Description);
        //    view.SetFormGN75ToolTip(StringResources.FormGN75Description);
        //    view.SetFormGN7ToolTip(StringResources.FormGN7Description);
        //}

        // this presenter's constructor makes an editObject with no id for the manual case, so we can't use the base class's implementation of this

        //private void SetupSafetyFormStateValuesWithoutIncludingEmpty()
        //{
        //    view.GN11Values = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
        //    view.GN27Values = new List<WorkPermitSafetyFormState>(WorkPermitSafetyFormState.AllValues);
        //}

        private void SetupWorkPermitTypesList()
        {
            var workPermitTypes = new List<WorkPermitFortHillsType>(WorkPermitFortHillsType.All);
            workPermitTypes.Insert(0, WorkPermitFortHillsType.NULL);
            view.AllPermitTypes = workPermitTypes;


        }

        private void SetupContractorsList()
        {
            contractors.Sort(c => c.CompanyName);
            contractors.Insert(0, Contractor.EMPTY);
            view.AllCompanies = contractors;
        }

        private void SetupCraftOrTradesList()
        {
            craftOrTrades.Sort(c => c.Name);
            craftOrTrades.Insert(0, CraftOrTrade.EMPTY);
            view.AllCraftOrTrades = craftOrTrades;
        }

        private void SetupRoadOnAccessPermitList()
        {
            roadAccessPermitList.Sort(c => c.Name);
            roadAccessPermitList.Insert(0, CraftOrTrade.EMPTY);
            //view.AllRoadAccessOnPermitType = roadAccessPermitList;
        }

        private void SetupSpecialWorkList()
        {
            specialWorkList.Sort(c => c.CompanyName);
            specialWorkList.Insert(0, SpecialWork.EMPTY);
            //view.AllSpecialWorkType = specialWorkList;
        }

        private void UpdateViewFromEditObject()
        {
            // first set confined space class to null, as otherwise it starts its life as 'A' and the business logic operates on that wrong assumption
            view.ConfinedSpaceClass = null;
            
            view.PermitNumber = editObject.PermitNumber.HasValue
                ? Convert.ToString(editObject.PermitNumber.Value)
                : string.Empty;
            view.LastModifiedDateTime = editObject.LastModifiedDateTime;
            view.LastModifiedBy = editObject.LastModifiedBy ?? userContext.User;
            
            view.IssuedToSuncor = editObject.IssuedToSuncor;
            view.IssuedToContractor = editObject.IssuedToCompany;
            view.Company = editObject.Company;
            view.Occupation = editObject.Occupation;
            view.NumberOfWorkers = editObject.NumberOfWorkers;
            view.Group = editObject.Group;
            view.Priority = editObject.Prioritydata;
            view.WorkPermitType = editObject.WorkPermitType;

            view.ClonedFormDetailFortHills = editObject.ClonedFormDetailFortHills; // Added by Vibhor : DMND0011077 - Work Permit Clone History

            view.FunctionalLocation = editObject.FunctionalLocation;
            view.Location = editObject.Location;

            view.RequestedStartDateTime = editObject.RequestedStartDateTime;
            view.ExpiryDateTime = editObject.ExpiredDateTime;

            view.WorkOrderNumber = editObject.WorkOrderNumber;
            view.OperationNumber = editObject.OperationNumber;
            view.SubOperationNumber = editObject.SubOperationNumber;
            view.JobCoordinator = editObject.JobCoordinator;
            view.CoOrdContactNumber = editObject.CoOrdContactNumber;
            view.EquipmentNo = editObject.EquipmentNo;
            view.EmergencyAssemblyArea = editObject.EmergencyAssemblyArea;
            view.EmergencyMeetingPoint = editObject.EmergencyMeetingPoint;
            view.EmergencyContactNo = editObject.EmergencyContactNo;

            view.LockBoxnumberChecked = editObject.LockBoxnumberChecked;
            view.LockBoxNumberEnabled = editObject.LockBoxnumberChecked;
            view.IsolationNoEnabled = editObject.LockBoxnumberChecked;
            if (editObject.LockBoxnumberChecked)
            {
                view.LockBoxNumber = editObject.LockBoxNumber;
                view.IsolationNo = editObject.IsolationNo;
            }

            view.Description = editObject.TaskDescription;
            view.HazardsAndOrRequirements = editObject.HazardsAndOrRequirements;
            
            view.PartDWorkSectionNotApplicableToJob = editObject.PartDWorkSectionNotApplicableToJob;
            view.DocumentLinks = editObject.DocumentLinks;

            view.PartCWorkSectionNotApplicableToJob = editObject.PartCWorkSectionNotApplicableToJob;
            view.FlameResistantWorkWear = editObject.FlameResistantWorkWear;
            view.ChemicalSuit = editObject.ChemicalSuit;
            view.FireWatch = editObject.FireWatch;
            view.FireBlanket = editObject.FireBlanket;
            view.SuppliedBreathingAir = editObject.SuppliedBreathingAir;
            view.AirMover = editObject.AirMover;
            view.PersonalFlotationDevice = editObject.PersonalFlotationDevice;
            view.HearingProtection = editObject.HearingProtection;
            view.Other1 = editObject.Other1Checked;
            view.Other1Value = editObject.Other1;

            view.MonoGoggles = editObject.MonoGoggles;
            view.ConfinedSpaceMoniter = editObject.ConfinedSpaceMoniter;
            view.FireExtinguisher = editObject.FireExtinguisher;
            view.SparkContainment = editObject.SparkContainment;
            view.BottleWatch = editObject.BottleWatch;
            view.StandbyPerson = editObject.StandbyPerson;
            view.WorkingAlone = editObject.WorkingAlone;
            view.SafetyGloves = editObject.SafetyGloves;
            view.Other2 = editObject.Other2Checked;
            view.Other2Value = editObject.Other2;

            view.FaceShield = editObject.FaceShield;
            view.FallProtection = editObject.FallProtection;
            view.ChargedFireHouse = editObject.ChargedFireHouse;
            view.CoveredSewer = editObject.CoveredSewer;
            view.AirPurifyingRespirator = editObject.AirPurifyingRespirator;
            view.SingalPerson = editObject.SingalPerson;
            view.CommunicationDevice = editObject.CommunicationDevice;
            view.ReflectiveStrips = editObject.ReflectiveStrips;
            view.Other3 = editObject.Other3Checked;
            view.Other3Value = editObject.Other3;

            view.PartEWorkSectionNotApplicableToJob = editObject.PartEWorkSectionNotApplicableToJob;
            view.ConfinedSpace = editObject.ConfinedSpace;
            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.GoundDisturbance = editObject.GroundDisturbance;
            view.FireProtectionAuthorization = editObject.FireProtectionAuthorization;
            view.CriticalOrSeriousLifts = editObject.CriticalOrSeriousLifts;
            view.VehicleEntry = editObject.VehicleEntry;
            view.IndustrialRadiography = editObject.IndustrialRadiography;
            view.ElectricalEncroachment = editObject.ElectricalEncroachment;
            view.MSDS = editObject.MSDS;
            view.OthersPartEChecked = editObject.OthersPartEChecked;
            view.OthersPartE = editObject.OthersPartE;

            view.PartEWorkSectionNotApplicableToJob = editObject.PartEWorkSectionNotApplicableToJob;
            view.ConfinedSpace = editObject.ConfinedSpace;
            view.ConfinedSpaceClass = editObject.ConfinedSpaceClass;
            view.GoundDisturbance = editObject.GroundDisturbance;
            view.FireProtectionAuthorization = editObject.FireProtectionAuthorization;
            view.CriticalOrSeriousLifts = editObject.CriticalOrSeriousLifts;
            view.VehicleEntry = editObject.VehicleEntry;
            view.IndustrialRadiography = editObject.IndustrialRadiography;
            view.ElectricalEncroachment = editObject.ElectricalEncroachment;
            view.MSDS = editObject.MSDS;
            view.OthersPartEChecked = editObject.OthersPartEChecked;
            view.OthersPartE = editObject.OthersPartE;

            //partF
            view.PartFWorkSectionNotApplicableToJob = editObject.PartFWorkSectionNotApplicableToJob;
            view.MechanicallyIsolated = editObject.MechanicallyIsolated;
            view.BlindedOrBlanked = editObject.BlindedOrBlanked ;
            view.DoubleBlockedandBled = editObject.DoubleBlockedandBled;
            view.DrainedAndDepressurised = editObject.DrainedAndDepressurised;
            view.PurgedorNeutralised = editObject.PurgedorNeutralised;
            view.ElectricallyIsolated = editObject.ElectricallyIsolated;
            view.TestBumped = editObject.TestBumped;
            view.NuclearSource = editObject.NuclearSource;
            view.ReceiverStafingRequirements = editObject.ReceiverStafingRequirements;
            view.PermitAcceptor = editObject.PermitAcceptor;
            //part G
            view.PartGWorkSectionNotApplicableToJob = editObject.PartGWorkSectionNotApplicableToJob;
            view.Oxygen = editObject.Oxygen;
            view.LEL = editObject.LEL;
            view.H2SPPM = editObject.H2SPPM;
            view.CoPPM = editObject.CoPPM;
            view.SO2PPM = editObject.So2PPM;
            view.Other1PartG = editObject.Other1PartG;
            view.Other1PartGValue = editObject.Other1PartGValue;
            view.Other2PartG = editObject.Other2PartG;
            view.Other2PartGValue = editObject.Other2PartGValue;
            view.Frequency = editObject.Frequency;
            view.Continuous = editObject.Continuous;
            view.TesterName = editObject.TesterName;

            view.PermitIssuer = editObject.PermitIssuer;
            view.AreaAuthority = editObject.AreaAuthority;
            view.CoAuthorizingIssuer = editObject.CoAuthorizingIssuer;
            view.AddationalAuthority = editObject.AddationalAuthority;
            view.PermitIssuerContact = editObject.PermitIssuerContact;
            view.AreaAuthorityContact = editObject.AreaAuthorityContact;
            view.CoAuthorizingIssuerContact = editObject.CoAuthorizingIssuerContact;
            view.AddationalAuthorityContact = editObject.AddationalAuthorityContact;
            view.IsFieldTourRequired = editObject.IsFieldTourRequired;
            view.FieldTourConductedBy = editObject.FieldTourConductedBy;

            view.PermitAcceptor = editObject.PermitAcceptor;
           // view.ShiftSupervisor = editObject.ShiftSupervisor;

           // view.UseCurrentPermitNumberForZeroEnergyFormNumber = editObject.UseCurrentPermitNumberForZeroEnergyFormNumber;

            view.ForceExecutionOfBusinessLogic();
            
        }

        private void UpdateViewWithDefaults()
        {
            view.LastModifiedBy = userContext.User;
            view.LastModifiedDateTime = Clock.Now;
            view.PermitNumber = string.Empty;
            view.Priority = Priority.Normal;
            view.ConfinedSpace = false;
            view.IsFieldTourRequired = false;
            view.ConfinedSpaceClass = null;
            view.LockBoxnumberChecked = false;
            view.ExtensionDateTimeEnable = false;
            view.DocumentLinks = new List<DocumentLink>();
            view.Group = null;
            view.PermitAcceptor = null;
            view.PartCWorkSectionNotApplicableToJob =
                ClientSession.GetUserContext().SiteConfiguration.WorkPermitNotApplicableAutoSelected;
            view.PartDWorkSectionNotApplicableToJob =
                ClientSession.GetUserContext().SiteConfiguration.WorkPermitNotApplicableAutoSelected;
            view.PartEWorkSectionNotApplicableToJob =
                ClientSession.GetUserContext().SiteConfiguration.WorkPermitNotApplicableAutoSelected;
            view.PartFWorkSectionNotApplicableToJob =
                ClientSession.GetUserContext().SiteConfiguration.WorkPermitNotApplicableAutoSelected;
            view.PartGWorkSectionNotApplicableToJob =
                ClientSession.GetUserContext().SiteConfiguration.WorkPermitNotApplicableAutoSelected;
        }

        private DateTime? GetExpiryTimeBasedOnSelectedTab()
        {
            DateTime? expiryTimeBasedOnSelectedGroupOnView = null;

            var userShift = userContext.UserShift;
            var shiftEndDateTime = userShift.EndDateTime;

            if (view.Group == null)
            {
                //expiryTimeBasedOnSelectedGroupOnView =
                //    shiftEndDateTime.Add(currentTab == WorkPermitFortHillsTab.Turnaround
                //        ? WorkPermitFortHills.TurnaroundPermitEndTimeOffset
                //        : WorkPermitFortHills.NonTurnaroundPermitEndTimeOffset);
                expiryTimeBasedOnSelectedGroupOnView =
                  shiftEndDateTime.Add(WorkPermitFortHills.NonTurnaroundPermitEndTimeOffset);
            }

            return expiryTimeBasedOnSelectedGroupOnView;
        }

        /// <summary>
        ///     Sets the View's Expiry date time using the following rules
        ///     1.  If the user was on a Work Permit tab when creating a Work permit, use the fact that the tab is turnaround or
        ///     running unit to decide
        ///     2.  Use the Group of the Work Permit
        /// </summary>
        private void SetEndDateTimesToDefaultsForGroup()
        {
            var userShift = userContext.UserShift;

            var expiryTimeBasedOnSelectedGroupOnView = GetExpiryTimeBasedOnSelectedTab();
            if (expiryTimeBasedOnSelectedGroupOnView.HasValue)
            {
                view.ExpiryDateTime = expiryTimeBasedOnSelectedGroupOnView.Value;
            }
            else if (!IsNew)
            {
                // get the selected group off of the view, and set it on the domain object.
                editObject.Group = view.Group;
                var defaultExpiryDateTimeForGroup = editObject.GetDefaultExpiryDateTimeBasedOnGroup(userShift);
                view.ExpiryDateTime = defaultExpiryDateTimeForGroup;
            }
        }

        private void HandleFunctionalLocationClick()
        {
            SetLocationChangedByUser();

            var selectedFloc = view.ShowSecondLevelOrLowerFunctionalLocationSelector();

            if (selectedFloc != null)
            {
                view.FunctionalLocation = selectedFloc;

                if (!locationChangedByUser)
                {
                    view.Location = WorkPermitFortHills.GetLocation(selectedFloc);
                }
            }
        }

        private void SetLocationChangedByUser()
        {
            locationChangedByUser = view.Location != WorkPermitFortHills.GetLocation(view.FunctionalLocation);
        }

        protected override void HandleSaveAndCloseButtonClicked(object sender, EventArgs eventArgs)
        {
            saveandIssue = false;
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;
            /* DMND0009632 - Fort Hills OLT - E-Permit Development commented */
            var otherWarnings = new WorkPermitFortHillsOtherWarnings(view);
            //otherWarnings.Validate();

            if (hasErrors)
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsAndErrorsMessageBox();
                }
                else
                {
                    view.ShowHasValidationErrorsMessageBox();
                }
            }

            /* DMND0009632 - Fort Hills OLT - E-Permit Development commented  */
            
            else
            {
                if (hasValidationWarnings || otherWarnings.HasWarnings)
                {
                    var result = view.ShowWarnings(otherWarnings, hasValidationWarnings);
                    if (result == DialogResult.Yes)
                    {
                        FinalizePermitAndSave(hasValidationWarnings);
                    }
                }
                else
                {
                    FinalizePermitAndSave(false);
                }
            }
           
        }

        private void SaveValuesInSession()
        {
            // if the use has changed the time from what was initially set on Load via the SetInitialExpiredDateTime method, then store the value.
            if (userChangedExpireTime)
            {
                var sessionStore = ClientSession.GetInstance().GetSessionStore();
                sessionStore.SetValue(SessionStoreKey.WorkPermitEdmontonEndDateTime, editObject.ExpiredDateTime);
            }

        }

        private void FinalizePermitAndSave(bool hasValidationWarnings)
        {
            editObject.WorkPermitStatus = hasValidationWarnings
                ? PermitRequestBasedWorkPermitStatus.Requested
                : PermitRequestBasedWorkPermitStatus.Pending;

            try
            {
                SaveOrUpdate(true);
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private WorkPermitFortHillsValidator CreateValidator()
        {
            var attributesForHazardsLabel = WorkPermitFortHillsReport.GetAttributesForHazardsLabel();
            return new WorkPermitFortHillsValidator(new WorkPermitFortHillsValidationViewAdapter(view),
                attributesForHazardsLabel);
        }

        private void HandleSaveAndIssueButtonClick()
        {
            saveandIssue = true;
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            var hasValidationWarnings = validator.HasWarnings;
            var hasErrors = validator.HasErrors;

            var otherWarnings = new WorkPermitFortHillsOtherWarnings(view);
            otherWarnings.Validate();

            if (hasErrors)
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsAndErrorsMessageBox();
                }
                else
                {
                    view.ShowHasValidationErrorsMessageBox();
                }
            }
            else
            {
                if (hasValidationWarnings)
                {
                    view.ShowHasValidationWarningsMessageBox();
                }
                //else if (otherWarnings.HasWarnings)
                //{
                //    var result = view.ShowWarnings(otherWarnings, false);
                //    if (result == DialogResult.Yes)
                //    {
                //        FinalizePermitAndSaveAndPrint();
                //    }
                //}
                else
                {
                    //ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.UpdateAndInsertActionItems, ,, permitIdToAssociatedLogMap);                            
                    FinalizePermitAndSaveAndPrint();
                }
            }
        }


        // important: this method should only be called when there are no validation errors or warnings
        private void FinalizePermitAndSaveAndPrint()
        {
            editObject.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Pending;

            try
            {
                SaveOrUpdate(true);
                
                printManager.PrintReport(new List<WorkPermitFortHills> { editObject });
            }
            catch (Exception e)
            {
                HandleSaveOrUpdateException(e);
            }
        }

        private void HandleValidateButtonClick()
        {
            view.ClearErrorProviders();
            var validator = CreateValidator();
            validator.ValidateAndSetErrors(Clock.Now);

            if (!validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowIsValidMessageBox();
            }
            else if (!validator.HasWarnings && validator.HasErrors)
            {
                view.ShowHasValidationErrorsMessageBox();
            }
            else if (validator.HasWarnings && !validator.HasErrors)
            {
                view.ShowHasValidationWarningsMessageBox();
            }
            else if (validator.HasWarnings && validator.HasErrors)
            {
                view.ShowHasValidationWarningsAndErrorsMessageBox();
            }
        }

        // this method is not actually called in our case since we handle the saving process ourselves
        protected override bool ValidateViewHasError()
        {
            throw new NotImplementedException();
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();

            var workPermit = IsMerge
                ? ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitFortHillsCreate, service.InsertMergePermit, editObject,
                    mergeSourcePermitIdList)
                : ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitFortHillsCreate, service.Insert, editObject);

            editObject.Id = workPermit.Id;
            editObject.PermitNumber = workPermit.PermitNumber;
            SaveValuesInSession();
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            var workPermit =
                ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                    ApplicationEvent.WorkPermitFortHillsUpdate, service.Update, editObject);
            editObject.PermitNumber = workPermit.PermitNumber;
           // editObject.MaybeSetZeroEnergyFormNumber(workPermit.PermitNumber);
            SaveValuesInSession();
        }

        private void UpdateEditObjectFromView()
        {
            var id = IsEdit ? editObject.Id : null;

            var editUser = userContext.User;
            var now = Clock.Now;

            if (!IsEdit)
            {
                // If we're cloning or making a new permit, we want to create the permit here so it has the right 'created at' datetime set, but we don't want to overwrite the
                // status or datasource.
                var currentStatus = editObject.WorkPermitStatus;
                var currentDataSource = editObject.DataSource;
                editObject = CreatePermit(currentStatus, currentDataSource);
            }

            if (IsMerge)
            {
                editObject.DataSource = DataSource.MERGE;
                editObject.IssuedDateTime = null; // Just making sure.
            }
            if (isExtension)
            {
                editObject.ExtensionDateTime = view.ExtensionDateTime;
                editObject.ExtensionReasonPartJ = view.ExtensionComments;
                editObject.ExtendedByUser = ClientSession.GetUserContext().User;

            }
            //start
            editObject.Id = id;
            //editObject.PermitRequest = view.PermitRequestId;
            //editObject.WorkPermitStatusId = view.WorkPermitStatusId;
            //editObject.DataSourceId = view.DataSourceId;
            editObject.Company = view.Company;
            editObject.Occupation = view.Occupation;
            editObject.NumberOfWorkers = view.NumberOfWorkers;
            editObject.WorkPermitType = view.WorkPermitType;
            editObject.FunctionalLocation = view.FunctionalLocation;
            editObject.Location = view.Location;
            editObject.RequestedStartDateTime = view.RequestedStartDateTime;
            //.IssuedDateTime = view.IssuedDateTime;
            editObject.ExpiredDateTime = view.ExpiryDateTime;
           // editObject.PermitNumber = view.PermitNumber;
            editObject.WorkOrderNumber = view.WorkOrderNumber;
            editObject.OperationNumber = view.OperationNumber;

            editObject.ClonedFormDetailFortHills = view.ClonedFormDetailFortHills; // Added by Vibhor : DMND0011077 - Work Permit Clone History

            editObject.SubOperationNumber = view.SubOperationNumber;
            editObject.TaskDescription = view.Description;
            editObject.LastModifiedDateTime = now;
            editObject.LastModifiedBy = editUser;
            editObject.IssuedToSuncor = view.IssuedToSuncor;
            editObject.IssuedToCompany = view.IssuedToContractor;
            editObject.Group = view.Group;
            //editObject.PermitRequestCreatedByUser = view.PermitRequestCreatedByUser;
            editObject.Prioritydata = view.Priority;
           
            editObject.EquipmentNo = view.EquipmentNo;
            editObject.JobCoordinator = view.JobCoordinator;
            editObject.CoOrdContactNumber = view.CoOrdContactNumber;
            editObject.EmergencyAssemblyArea = view.EmergencyAssemblyArea;
            editObject.EmergencyMeetingPoint = view.EmergencyMeetingPoint;
            editObject.EmergencyContactNo= view.EmergencyContactNo;
            editObject.LockBoxNumber = view.LockBoxNumber;
            editObject.LockBoxnumberChecked = view.LockBoxnumberChecked;
            editObject.IsolationNo = view.IsolationNo;
           // editObject.RevalidationDateTime = view.RevalidationDateTime;
           // editObject.ExtensionDateTime = view.ExtensionDateTime;
            //part C
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

            //Part D
            editObject.HazardsAndOrRequirements = view.HazardsAndOrRequirements;
            //Part E
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
            //partF
            editObject.MechanicallyIsolated = view.MechanicallyIsolated;
            editObject.BlindedOrBlanked = view.BlindedOrBlanked;
            editObject.DoubleBlockedandBled = view.DoubleBlockedandBled;
            editObject.DrainedAndDepressurised = view.DrainedAndDepressurised;
            editObject.PurgedorNeutralised = view.PurgedorNeutralised;
            editObject.ElectricallyIsolated = view.ElectricallyIsolated;
            editObject.TestBumped = view.TestBumped;
            editObject.NuclearSource = view.NuclearSource;
            editObject.ReceiverStafingRequirements = view.ReceiverStafingRequirements;
            editObject.PermitAcceptor = view.PermitAcceptor;
            //part G
            editObject.Oxygen = view.Oxygen;
            editObject.LEL = view.LEL;
            editObject.H2SPPM = view.H2SPPM;
            editObject.CoPPM = view.CoPPM;
            editObject.So2PPM = view.SO2PPM;
            editObject.Other1PartG = view.Other1PartG;
            editObject.Other1PartGValue = view.Other1PartGValue;
            editObject.Other2PartG = view.Other2PartG;
            editObject.Other2PartGValue = view.Other2PartGValue;
            editObject.Frequency = view.Frequency;
            editObject.Continuous = view.Continuous;
            editObject.TesterName = view.TesterName;

            editObject.PermitIssuer = view.PermitIssuer;
            editObject.AreaAuthority = view.AreaAuthority;
            editObject.CoAuthorizingIssuer = view.CoAuthorizingIssuer;
            editObject.AddationalAuthority = view.AddationalAuthority;
            editObject.PermitIssuerContact = view.PermitIssuerContact;
            editObject.AreaAuthorityContact = view.AreaAuthorityContact;
            editObject.CoAuthorizingIssuerContact = view.CoAuthorizingIssuerContact;
            editObject.AddationalAuthorityContact = view.AddationalAuthorityContact;
            editObject.IsFieldTourRequired = view.IsFieldTourRequired;
            editObject.FieldTourConductedBy = view.FieldTourConductedBy;

         //   editObject.ShiftSupervisor = view.ShiftSupervisor;
            editObject.DocumentLinks = view.DocumentLinks;
            editObject.PartCWorkSectionNotApplicableToJob = view.PartCWorkSectionNotApplicableToJob;
            editObject.PartDWorkSectionNotApplicableToJob = view.PartDWorkSectionNotApplicableToJob;
            editObject.PartEWorkSectionNotApplicableToJob = view.PartEWorkSectionNotApplicableToJob;
            editObject.PartFWorkSectionNotApplicableToJob = view.PartFWorkSectionNotApplicableToJob;
            editObject.PartGWorkSectionNotApplicableToJob = view.PartGWorkSectionNotApplicableToJob;

           // editObject.WorkPermitType = view.WorkPermitType;
           //editObject.DurationPermit = view.DurationPermit;
            //editObject.IssuedToSuncor = view.IssuedToSuncor;
            //editObject.Occupation = view.Occupation;
            //editObject.NumberOfWorkers = view.NumberOfWorkers;
            //editObject.Group = view.Group;
            //editObject.Prioritydata = view.Priority;
            //editObject.FunctionalLocation = view.FunctionalLocation;
            //editObject.Location = view.Location;
            //editObject.RequestedStartDateTime = view.RequestedStartDateTime;
            //editObject.ExpiredDateTime = view.ExpiryDateTime;
            //editObject.WorkOrderNumber = view.WorkOrderNumber;
            //editObject.OperationNumber = view.OperationNumber;
            //editObject.SubOperationNumber = view.SubOperationNumber;

        }

        private WorkPermitFortHills CreatePermit(PermitRequestBasedWorkPermitStatus status, DataSource dataSource)
        {
            return new WorkPermitFortHills(dataSource, status, view.WorkPermitType, Clock.Now,
                ClientSession.GetUserContext().User);
        }

       
        private void HandlePrintPreferencesButtonClicked()
        {
            var printPreferencesFormPresenter = new WorkPermitPrintPreferencesFormPresenter();
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 start
          //  var userContext = ClientSession.GetUserContext();
          //  userContext.User.WorkPermitPrintPreference.JobsiteEquipmentInspected = view.JobsiteEquipmentInspected;
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 -point 4 - 03-Oct-2018 end
            
            printPreferencesFormPresenter.Run(view);
        }
       
        private void HandleIsFieldTourRequiredCheckChanged()
        {

        }
    }
}