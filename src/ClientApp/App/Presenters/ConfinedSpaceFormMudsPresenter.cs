using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfinedSpaceFormMudsPresenter : AddEditBaseFormPresenter<IConfinedSpaceViewMuds, ConfinedSpaceMuds>
    {
        private readonly IConfinedSpaceMudsService service;        
        private readonly IDropdownValueService dropdownValueService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private List<ShiftPattern> allShifts;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<DropdownValue> dropdownValues;
        private List<GasTestElementInfo> standardGasTestElementInfoList;
        private readonly IGasTestElementInfoService gasTestElementInfoService;

        private readonly IDictionary<GasTestElementDetailsMuds, GasTestElement> detailsToGasTestElementTable;

        public ConfinedSpaceFormMudsPresenter(): this(null)
        {
            
        }
        public ConfinedSpaceFormMudsPresenter(ConfinedSpaceMuds editObject)
            : base(new ConfinedSpaceFormMuds(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IConfinedSpaceMudsService>();            
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();
            configuredDocumentLinkService = clientServiceRegistry.GetService<IConfiguredDocumentLinkService>();

           SubscribeToViewEvents();
            //Added by ppanigrahi
           gasTestElementInfoService = clientServiceRegistry.GetService<IGasTestElementInfoService>();
           detailsToGasTestElementTable = new Dictionary<GasTestElementDetailsMuds, GasTestElement>();
           QueryStandardGasTestElementInfoList();

        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += OnFormLoad;
            view.PreparationCheckChanged += OnPreparationChange;
            view.FunctionalLocationSelector += OnFunctionalLocationClick;
            view.ViewDocumentLinkClicked += OnViewDocumentLinkClick;
            view.ViewPssClicked += OnViewDocumentLinkClick;
            //view.WorkPermitTypeChanged += HandleSelectedWorkPermitTypeChange;
        }

        private void OnViewDocumentLinkClick(ConfiguredDocumentLink link)
        {
            if (link != null)
            {
                view.OpenFileOrDirectoryOrWebsite(link.Link);
            }
        }

        private void OnFunctionalLocationClick()
        {
            FunctionalLocation selectedFloc = view.ShowFunctionalLocationSelector();
            if (selectedFloc != null)
            {
                view.FunctionalLocation = selectedFloc;
            }

        }

        private void OnPreparationChange()
        {
            SetStartAndEndDateTimes();
        }

        private void SetStartAndEndDateTimes()
        {
            if (view.IsPreparation)
            {
                UserShift nextShift = userContext.UserShift.ChooseNextShift(allShifts);
                view.StartDateTime = nextShift.StartDateTime;
                view.EndDateTime = nextShift.EndDateTime;
            }
            else
            {
                SetStartAndEndDateTimesInCurrentShift();
            }

        }

        private void SetStartAndEndDateTimesInCurrentShift()
        {
            UserShift userShift = userContext.UserShift;
            DateTime shiftStartDateTime = userShift.StartDateTime;
            DateTime shiftEndDateTime = userShift.EndDateTime;
            DateTime currentDateTime = Clock.Now;

            DateTime startDateTime = currentDateTime >= shiftStartDateTime ? currentDateTime : shiftStartDateTime;
            DateTime endDateTime = currentDateTime >= shiftEndDateTime ? currentDateTime : shiftEndDateTime;

            view.StartDateTime = startDateTime;
            view.EndDateTime = endDateTime;
        }

        private void OnFormLoad()
        {
            LoadData(new List<Action> { QueryDropdownValues, QueryConfiguredDocumentLinks, QueryShifts });
        }

        protected override void AfterDataLoad()
        {

            view.InitializeStandardGasTestElementInfoList(standardGasTestElementInfoList);

            view.UpdateTitleAsCreateOrEdit(IsEdit, StringResources.ConfinedSpaceFormTitle);

            SetDropdownValues(dropdownValues);

            if (configuredDocumentLinks.Count == 0)
            {
                view.DisableConfiguredDocumentLinks();
            }
            else
            {
                view.ConfiguredDocumentLinks = configuredDocumentLinks;
            }

            if (IsEdit)
            {
                UpdateViewFromEditObject();
            }
            else if (IsClone)
            {
                UpdateViewFromEditObject();
                SetStartAndEndDateTimesInCurrentShift();
            }
            else
            {
                UpdateViewWithDefaults();
            }
        }

        private void QueryShifts()
        {
            IShiftPatternService shiftPatternService = ClientServiceRegistry.Instance.GetService<IShiftPatternService>();
            allShifts = shiftPatternService.QueryBySite(userContext.Site);
        }

        private void QueryConfiguredDocumentLinks()
        {
            configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.ConfinedSpaceMuds);
        }

        private void QueryDropdownValues()
        {
            dropdownValues = dropdownValueService.QueryAll(Site.MontrealSulphur_ID);
        }

        private void UpdateViewWithDefaults()
        {
            SetStartAndEndDateTimesInCurrentShift();
            view.ObtureOuDebranche = true;
            view.DepressuriseEtVidange = true;
            view.AereVentile = true;
            view.Harnis = true;
            view.DetectionDeGaz = true;
            view.PSS = true;
            view.InstructionsSpeciales = "Registre de présence obligatoire ";
        }

        private void UpdateViewFromEditObject()
        {
            view.StartDateTime = editObject.StartDateTime;
            view.EndDateTime = editObject.EndDateTime;

            if (editObject.ConfinedSpaceNumber.HasValue)
            {
                view.ConfinedSpaceNumber = "EC " + editObject.ConfinedSpaceNumber.Value.ToString();
            }
            view.FunctionalLocation = editObject.FunctionalLocation;

            view.H2S = editObject.H2S;
            view.Hydrocarbure = editObject.Hydrocarbure;
            view.Ammoniaque = editObject.Ammoniaque;
            view.Corrosif = editObject.Corrosif;
            view.Aromatique = editObject.Aromatique;
            view.AutresSubstances = editObject.AutresSubstances;

            view.ObtureOuDebranche = editObject.ObtureOuDebranche;
            view.DepressuriseEtVidange = editObject.DepressuriseEtVidange;
            view.EnPresenceDeGazInerte = editObject.EnPresenceDeGazInerte;
            view.PurgeALaVapeur = editObject.PurgeALaVapeur;
            view.DessinsRequis = editObject.DessinsRequis;
            view.PlanDeSauvetage = editObject.PlanDeSauvetage;

            view.CablesChauffantsMisHorsTension = editObject.CablesChauffantsMisHorsTension;
            view.InterrupteursElectriquesVerrouilles = editObject.InterrupteursElectriquesVerrouilles;
            view.PurgeParUnGazInerte = editObject.PurgeParUnGazInerte;
            view.RinceALeau = editObject.RinceAlEau;
            view.VentilationMecanique = editObject.VentilationMecanique;

            view.BouchesDegoutProtegees = editObject.BouchesDegoutProtegees;
            view.PossibiliteDeSulfureDeFer = editObject.PossibiliteDeSulfureDeFer;
            view.AereVentile = editObject.AereVentile;
            view.AutreConditions = editObject.AutreConditions;
            view.VentilationNaturelle = editObject.VentilationNaturelle;

            view.InstructionsSpeciales = editObject.InstructionsSpeciales;


            view.SO2 = editObject.SO2;
            view.NH3 = editObject.NH3;
            view.AcideSulfurique = editObject.AcideSulfurique;
            view.CO = editObject.CO;
            view.Azote = editObject.Azote;
            view.Reflux = editObject.Reflux;
            view.NaOH = editObject.NaOH;
            view.SBS = editObject.SBS;
            view.Soufre = editObject.Soufre;
            view.Amiante = editObject.Amiante;
            view.Bacteries = editObject.Bacteries;
            view.Depressurise = editObject.Depressurise;
            view.Rince = editObject.Rince;
            view.Obture = editObject.Obture;
            view.Nettoyes = editObject.Nettoyes;
            view.Purge = editObject.Purge;
            view.Vide = editObject.Vide;
            view.Dessins = editObject.Dessins;
            view.DetectionDeGaz = editObject.DetectionDeGaz;
            view.PSS = editObject.PSS;
            view.VentilationEn = editObject.VentilationEn;
            view.VentilationForce = editObject.VentilationForce;
            view.Harnis = editObject.Harnis;

          //  if (editObject.WorkPermitType == WorkPermitMudsType.ELEVATED_HOT)
              LoadWorkItemGasTests(editObject);


        }

        private void UpdateEditObjectFromView()
        {
            long? id = IsEdit ? editObject.Id : null;
            long? confinedSpaceNumber = IsEdit ? editObject.ConfinedSpaceNumber : null;
            ConfinedSpaceStatusMuds status = !IsEdit ? ConfinedSpaceStatusMuds.Pending : editObject.ConfinedSpaceStatus;

            editObject = new ConfinedSpaceMuds(id, status, view.StartDateTime, view.EndDateTime,
                                           confinedSpaceNumber, view.FunctionalLocation, view.H2S, view.Hydrocarbure,
                                           view.Ammoniaque, view.Corrosif, view.Aromatique, view.AutresSubstances,
                                           view.ObtureOuDebranche, view.DepressuriseEtVidange,
                                           view.EnPresenceDeGazInerte, view.PurgeALaVapeur, view.DessinsRequis,
                                           view.PlanDeSauvetage, view.CablesChauffantsMisHorsTension,
                                           view.InterrupteursElectriquesVerrouilles, view.PurgeParUnGazInerte,
                                           view.RinceALeau, view.VentilationMecanique, view.BouchesDegoutProtegees,
                                           view.PossibiliteDeSulfureDeFer,
                                           view.AereVentile, view.AutreConditions, view.VentilationNaturelle,
                                           view.InstructionsSpeciales, userContext.User, Clock.Now, userContext.User,
                                           Clock.Now,
                                           view.SO2 ,view.NH3 ,view.AcideSulfurique ,view.CO ,view.Azote ,view.Reflux ,view.NaOH ,view.SBS ,view.Soufre ,view.Amiante ,view.Bacteries ,view.Depressurise ,
                                           view.Rince ,view.Obture ,view.Nettoyes ,view.Purge ,view.Vide ,view.Dessins  ,view.DetectionDeGaz ,view.PSS ,view.VentilationEn ,view.VentilationForce ,view.Harnis
                                        );
            editObject.GasTests = new WorkPermitGasTests();
            SaveWorkItemGasTests(editObject.GasTests);
        }


        protected override bool ValidateViewHasError()
        {
            ConfinedSpaceViewValidatorMuds validator = new ConfinedSpaceViewValidatorMuds(view);
            validator.ValidateViewAndSetErrors(view);
            return validator.HasErrors;
        }

        protected override void Insert()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Insert, editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(service.Update, editObject);
        }

        private void SetDropdownValues(List<DropdownValue> dropdownValues)
        {
            //view.AromatiqueValues = WorkPermitMudsDropDownValueKeys.AromatiqueDropdownValues(dropdownValues);
            view.AutreConditionsValues = WorkPermitMudsDropDownValueKeys.CsdAutresConditionsDropdownValues(dropdownValues);
            view.AutresSubstancesValues = WorkPermitMudsDropDownValueKeys.CsdAutresSubstancessDropdownValues(dropdownValues);
            //view.CorrosifValues = WorkPermitMudsDropDownValueKeys.CorrosifDropdownValues(dropdownValues);
        }
        //Added by ppanigrahi

        private void SaveWorkItemGasTests(WorkPermitGasTests gasTests)
        {

            gasTests.GasTestFirstResultTime = view.FirtTestResult;
            //if (view.ClonedFormDetailMuds == null || view.ClonedFormDetailMuds == "")
            //{

                gasTests.GasTestSecondResultTime = view.SecondTestResult;

                gasTests.GasTestThirdResultTime = view.ThirdTestResult;

                gasTests.GasTestFourthResultTime = view.FourthTestResult;
           // }

            List<GasTestElementDetailsMuds> gasTestElementDetailsList = view.GasTestElementDetailsList;
            // gasTests= new WorkPermitGasTests();
            foreach (GasTestElementDetailsMuds details in gasTestElementDetailsList)
            {
                GasTestElement element;
                if (detailsToGasTestElementTable.Keys.Contains(details) == false)
                {
                    GasTestElementInfo info;
                    if (details.IsStandard)
                    {
                        long? detailElementInfoId = details.GasTestElementInfoId;
                        info = FindStandardGasTestElementInfoById(detailElementInfoId);
                    }
                    else
                    {
                        Site site = ClientSession.GetUserContext().Site;
                        info = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                        //info = GasTestElementInfo.CreateOtherGasTestElementInfo_Other(site);
                    }
                    element = GasTestElement.CreateGasTestElement(info);
                    detailsToGasTestElementTable.Add(details, element);
                }
                else
                {
                    element = detailsToGasTestElementTable[details];
                }

                SaveGasTestElement(details, element);
                gasTests.Elements.Add(element);
                //if (element.HasData() && gasTests.Elements.Contains(element) == false)
                //{
                //    gasTests.Elements.Add(element);
                //}
                //else if (element.HasData() == false && gasTests.Elements.Contains(element))
                //{
                //    gasTests.Elements.Remove(element);
                //}

            }
        }
        private void SaveGasTestElement(GasTestElementDetailsMuds details, GasTestElement element)
        {
            element.ImmediateAreaTestResult = details.ImmediateAreaTestResult;
            element.ImmediateAreaTestRequired = details.ImmediateAreaTestRequired;
            // element.ConfinedSpaceTestResult = details.ConfinedSpaceTestResult;
            // element.ConfinedSpaceTestRequired = details.ConfinedSpaceTestRequired;
            element.SystemEntryTestResult = details.SystemEntryTestResult;
            element.SystemEntryTestNotApplicable = details.SystemEntryTestNotApplicable;
            //if (view.ClonedFormDetailMuds != null || view.ClonedFormDetailMuds != "")
            //{
            element.ConfinedSpaceTestRequired = false;
            element.ConfinedSpaceTestResult = null;
            element.ThirdTestRequired = false;
            element.ThirdTestResult = null;
            element.FourthTestResult = null;
            element.FourthTestRequired = false;
            //}
            if (element.ElementInfo.IsStandard == false)
            {
                element.ElementInfo.OtherLimits = details.Limits;
                element.ElementInfo.Name = details.ElementName;
                element.ElementInfo.Name = details.ElementNameOther;  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

            }
        }

        public void LoadWorkItemGasTests(ConfinedSpaceMuds workPermit)
        {
            // view.GasTestEventsEnabled = false;
            if (workPermit.GasTests.GasTestFirstResultTime != null)
                view.FirtTestResult = workPermit.GasTests.GasTestFirstResultTime;

            if (workPermit.GasTests.GasTestSecondResultTime != null)
                view.SecondTestResult = workPermit.GasTests.GasTestSecondResultTime;

            if (workPermit.GasTests.GasTestThirdResultTime != null)
                view.ThirdTestResult = workPermit.GasTests.GasTestThirdResultTime;

            if (workPermit.GasTests.GasTestFourthResultTime != null)
                view.FourthTestResult = workPermit.GasTests.GasTestFourthResultTime;

            WorkPermitGasTests gasTests = workPermit.GasTests;
            detailsToGasTestElementTable.Clear();
            List<GasTestElementDetailsMuds> detailsList = view.GasTestElementDetailsList;
            foreach (GasTestElementDetailsMuds details in view.GasTestElementDetailsList)
            {


                GasTestElement element = FindOrCreateGasTestElementForDetails(gasTests.Elements, details);
                LoadGasTestElement(details, element, workPermit);
                detailsToGasTestElementTable.Add(details, element);
            }

            // view.GasTestEventsEnabled = true;
        }

        private static void LoadGasTestElement(GasTestElementDetailsMuds details, GasTestElement element, ConfinedSpaceMuds confinedspaceMuds)
        {

            details.ElementName = element.ElementInfo.Name;
            details.ElementNameOther = element.ElementInfo.Name;
            //details.Limits = new GasTestElementLimitFormatter().ToLimitWithUnits(element, workPermit.WorkPermitType, WorkPermitMuds.Attributes);
            details.GasTestElementInfoId = element.ElementInfo.Id;
            details.IsStandard = element.ElementInfo.IsStandard;
            details.ImmediateAreaTestResult = element.ImmediateAreaTestResult;
            details.ImmediateAreaTestRequired = element.ImmediateAreaTestRequired;
            details.ConfinedSpaceTestRequired = element.ConfinedSpaceTestRequired;
            details.ConfinedSpaceTestResult = element.ConfinedSpaceTestResult;
            details.ThirdTestRequired = element.ThirdTestRequired;
            details.ThirdTestResult = element.ThirdTestResult;

            details.FourthTestRequired = element.FourthTestRequired;
            details.FourthTestResult = element.FourthTestResult;
        }
        //Gas test Added

        private void QueryStandardGasTestElementInfoList()
        {

            standardGasTestElementInfoList = gasTestElementInfoService.QueryStandardElementInfosBySiteId(ClientSession.GetUserContext().SiteId);
        }
        private readonly List<string> _listElement = new List<string>();
        private bool has = false;
        private GasTestElement FindOrCreateGasTestElementForDetails(IEnumerable<GasTestElement> elementList, GasTestElementDetailsMuds gasTestElementDetails)
        {
            long? gasTestElementInfoId = gasTestElementDetails.GasTestElementInfoId;

            foreach (GasTestElement element in elementList)
            {

                if (gasTestElementDetails.IsStandard)
                {
                    if (element.ElementInfo.Id == gasTestElementInfoId)
                    {
                        return element;
                    }
                }
                else if (element.ElementInfo.Id == null ||
                        (element.ElementInfo.IsStandard == false && gasTestElementInfoId == null) ||
                        element.ElementInfo.Id == gasTestElementInfoId)
                {
                    //return element;
                    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                    if (_listElement.Count == 0)
                    {
                        _listElement.Add(Convert.ToString(element.ElementInfo.Name));
                        return element;
                    }

                    has = _listElement.Any(s => s == Convert.ToString(element.ElementInfo.Name));
                    if (!has) return element;


                }
            }

            if (gasTestElementInfoId == null)
            {
                Site site = ClientSession.GetUserContext().Site;
                GasTestElementInfo otherInfo = GasTestElementInfo.CreateOtherGasTestElementInfo(site);
                return GasTestElement.CreateGasTestElement(otherInfo);
            }
            GasTestElementInfo info = FindStandardGasTestElementInfoById(gasTestElementInfoId);
            return GasTestElement.CreateGasTestElement(info);
        }
        private GasTestElementInfo FindStandardGasTestElementInfoById(long? elementInfoId)
        {
            foreach (GasTestElementInfo standardInfo in standardGasTestElementInfoList)
            {
                if (standardInfo.Id == elementInfoId)
                {
                    return standardInfo;
                }
            }
            throw new ApplicationException("Invalid Standard Gas Test Element Info Id : " + elementInfoId);
        }
        public bool ValidateGasTest()
        {
            bool result = true;

            List<GasTestElementDetailsMuds> lst = view.GasTestElementDetailsList;
            foreach (GasTestElementDetailsMuds Contrl in lst)
            {
                Contrl.ClearWarningMessages();
                if (Contrl.ImmediateAreaTestRequired && Contrl.ImmediateAreaTestResult.HasValue)
                {
                    GasTestElementInfo info = standardGasTestElementInfoList.FindById(Contrl.GasTestElementInfoId);
                    GasLimitRange range = info.GetLimitRange(WorkPermitType.HOT, new WorkPermitAttributes());
                    if (Contrl.ImmediateAreaTestResult.OutsideOf(range))
                    {
                        Contrl.SetImmediateAreaResultAlertMessage("Outside Range");
                        result = false;
                    }
                }

            }

            // bool returnResult = result || resultError;

            return result;
        }

    }
}