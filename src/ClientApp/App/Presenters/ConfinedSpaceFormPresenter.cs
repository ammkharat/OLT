using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfinedSpaceFormPresenter : AddEditBaseFormPresenter<IConfinedSpaceView, ConfinedSpace>
    {
        private readonly IConfinedSpaceService service;        
        private readonly IDropdownValueService dropdownValueService;
        private readonly IConfiguredDocumentLinkService configuredDocumentLinkService;

        private List<ShiftPattern> allShifts;
        private List<ConfiguredDocumentLink> configuredDocumentLinks;
        private List<DropdownValue> dropdownValues;

        public ConfinedSpaceFormPresenter(): this(null)
        {
            
        }
        public ConfinedSpaceFormPresenter(ConfinedSpace editObject) : base(new ConfinedSpaceForm(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            service = clientServiceRegistry.GetService<IConfinedSpaceService>();            
            dropdownValueService = clientServiceRegistry.GetService<IDropdownValueService>();
            configuredDocumentLinkService = clientServiceRegistry.GetService<IConfiguredDocumentLinkService>();

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += OnFormLoad;
            view.PreparationCheckChanged += OnPreparationChange;
            view.FunctionalLocationSelector += OnFunctionalLocationClick;
            view.ViewDocumentLinkClicked += OnViewDocumentLinkClick;
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
            configuredDocumentLinks = configuredDocumentLinkService.GetLinks(ConfiguredDocumentLinkLocation.ConfinedSpaceMontreal);
        }

        private void QueryDropdownValues()
        {
            dropdownValues = dropdownValueService.QueryAll(Site.MONTREAL_ID);
        }

        private void UpdateViewWithDefaults()
        {
            SetStartAndEndDateTimesInCurrentShift();
            view.ObtureOuDebranche = true;
            view.DepressuriseEtVidange = true;
            view.AereVentile = true;
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

        }

        private void UpdateEditObjectFromView()
        {
            long? id = IsEdit ? editObject.Id : null;
            long? confinedSpaceNumber = IsEdit ? editObject.ConfinedSpaceNumber : null;
            ConfinedSpaceStatus status = !IsEdit ? ConfinedSpaceStatus.Pending : editObject.ConfinedSpaceStatus;

            editObject = new ConfinedSpace(id, status, view.StartDateTime, view.EndDateTime,
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
                                           Clock.Now);
        }


        protected override bool ValidateViewHasError()
        {
            ConfinedSpaceViewValidator validator = new ConfinedSpaceViewValidator(view);
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
            view.AromatiqueValues = WorkPermitMontrealDropDownValueKeys.AromatiqueDropdownValues(dropdownValues);
            view.AutreConditionsValues = WorkPermitMontrealDropDownValueKeys.AutresConditionsDropdownValues(dropdownValues);
            view.AutresSubstancesValues = WorkPermitMontrealDropDownValueKeys.AutresSubstancesDropdownValues(dropdownValues);
            view.CorrosifValues = WorkPermitMontrealDropDownValueKeys.CorrosifDropdownValues(dropdownValues);
        }
    }
}