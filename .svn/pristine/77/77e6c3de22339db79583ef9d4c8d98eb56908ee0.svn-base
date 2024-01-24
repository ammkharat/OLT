using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitMontrealTemplateFormPresenter : AddEditBaseFormPresenter<IWorkPermitMontrealFormView, WorkPermitMontrealTemplate>
    {
        private readonly IWorkPermitMontrealTemplateService workPermitTemplateService;

        public WorkPermitMontrealTemplateFormPresenter() : this(null)
        {
        }

        public WorkPermitMontrealTemplateFormPresenter(WorkPermitMontrealTemplate editObject) : base(new WorkPermitMontrealForm(), editObject)
        {
            ClientServiceRegistry clientServiceRegistry = ClientServiceRegistry.Instance;
            workPermitTemplateService = clientServiceRegistry.GetService<IWorkPermitMontrealTemplateService>();
            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            view.FormLoad += OnFormLoad;
        }

        private void OnFormLoad()
        {
            view.PutInTemplateMode();
            List<WorkPermitMontrealType> workPermitTypes = new List<WorkPermitMontrealType>(WorkPermitMontrealType.All);
            workPermitTypes.Insert(0, WorkPermitMontrealType.NULL);
            view.PermitTypes = workPermitTypes;

            if (IsEdit)
            {
                view.SelectedPermitType = editObject.WorkPermitType;
                view.SelectedPermitTemplateName = editObject.Name;
                new WorkPermitMontrealTemplateViewMapper(view, editObject).MapTemplateToView();
            }
        }

        protected override bool ValidateViewHasError()
        {
            WorkPermitMontrealValidator validator = new WorkPermitMontrealValidator(view);
            validator.ValidateTemplateFormAndSetErrors(view);
            return validator.HasErrors;
        }

        protected override void Insert()
        {
            editObject = new WorkPermitMontrealTemplate(view.SelectedPermitTemplateName, view.SelectedPermitType, true, false, WorkPermitMontrealTemplate.NET_NEW_TEMPLATE); 
            UpdateEditObjectFromView();
            workPermitTemplateService.Insert(editObject);
        }

        protected override void Update()
        {
            UpdateEditObjectFromView();
            
            // Insert new row with updated template data (keeping existing Template Number)
            workPermitTemplateService.Insert(editObject); 

            // Mark old Template as deleted
            workPermitTemplateService.Delete(editObject);
        }

        private void UpdateEditObjectFromView()
        {
            editObject.WorkPermitType = view.SelectedPermitType;
            editObject.Name = view.SelectedPermitTemplateName;
            editObject.H2S = CreateTemplateStateFromVisible(view.H2S);
            editObject.Hydrocarbure = CreateTemplateStateFromVisible(view.Hydrocarbure);
            editObject.Ammoniaque = CreateTemplateStateFromVisible(view.Ammoniaque);
            editObject.Corrosif = CreateTemplateStateFromVisible(view.Corrosif);
            editObject.CorrosifValue = CreateTemplateValueFromVisible(view.Corrosif);
            editObject.Aromatique = CreateTemplateStateFromVisible(view.Aromatique);
            editObject.AromatiqueValue = CreateTemplateValueFromVisible(view.Aromatique);
            editObject.AutresSubstances = CreateTemplateStateFromVisible(view.AutresSubstances);
            editObject.AutresSubstancesValue = CreateTemplateValueFromVisible(view.AutresSubstances);

            editObject.ObtureOuDebranche = CreateTemplateStateFromVisible(view.ObtureOuDebranche);
            editObject.DepressuriseEtVidange = CreateTemplateStateFromVisible(view.DepressuriseEtVidange);
            editObject.EnPresenceDeGazInerte = CreateTemplateStateFromVisible(view.EnPreenceDeGazInerte);
            editObject.PurgeALaVapeur = CreateTemplateStateFromVisible(view.PurgeALaVapeur);
            editObject.RinceALeau = CreateTemplateStateFromVisible(view.RinceALeau);
            editObject.Excavation = CreateTemplateStateFromVisible(view.Excavation);
            editObject.DessinsRequis = CreateTemplateStateFromVisible(view.DessinsRequis);
            editObject.DessinsRequisValue = CreateTemplateValueFromVisible(view.DessinsRequis);
            editObject.CablesChauffantsMisHorsTension = CreateTemplateStateFromVisible(view.CablesChauffantsMisHorsTension);
            editObject.PompeOuVerinPneumatique = CreateTemplateStateFromVisible(view.PompeOuVerinPneumatique);

            editObject.ChaineEtCadenasseOuScelle = CreateTemplateStateFromVisible(view.ChaineEtCadenasseOuScelle);
            editObject.InterrupteursElectriquesVerrouilles = CreateTemplateStateFromVisible(view.InterrupteursElectriquesVerrouilles);
            editObject.PurgeParUnGazInerte = CreateTemplateStateFromVisible(view.PurgeParUnGazInerte);
            editObject.OutilsElectriquesOuABatteries = CreateTemplateStateFromVisible(view.OutilsElectriquesOuABatteries);
            editObject.BoiteEnergieZero = CreateTemplateStateFromVisible(view.BoiteEnergieZero);
            editObject.BoiteEnergieZeroValue = CreateTemplateValueFromVisible(view.BoiteEnergieZero);
            editObject.OutilsPneumatiques = CreateTemplateStateFromVisible(view.OutilsPneumatiques);
            editObject.MoteurACombustionInterne = CreateTemplateStateFromVisible(view.MoteurACombustionInterne);
            editObject.TravauxSuperPoses = CreateTemplateStateFromVisible(view.TravauxSuperPoses);

            editObject.FormulaireDespaceClosAffiche = CreateTemplateStateFromVisible(view.FormulaireDespaceClosAffiche);
            editObject.FormulaireDespaceClosAfficheValue = CreateTemplateValueFromVisible(view.FormulaireDespaceClosAffiche);
            editObject.ExisteIlUneAnalyseDeTache = CreateTemplateStateFromVisible(view.ExisteIlUneAnalyseDeTache);
            editObject.PossibiliteDeSulfureDeFer = CreateTemplateStateFromVisible(view.PossibiliteDeSulfureDeFer);
            editObject.AereVentile = CreateTemplateStateFromVisible(view.AereVentile);
            editObject.SoudureALelectricite = CreateTemplateStateFromVisible(view.SoudureALelectricite);
            editObject.BrulageAAcetylene = CreateTemplateStateFromVisible(view.BrulageAAcetylene);
            editObject.Nacelle = CreateTemplateStateFromVisible(view.Nacelle);
            editObject.AutreConditions = CreateTemplateStateFromVisible(view.AutreConditions);
            editObject.AutreConditionsValue = CreateTemplateValueFromVisible(view.AutreConditions);

            editObject.LunettesMonocoques = CreateTemplateStateFromVisible(view.LunettesMonocoques);
            editObject.HarnaisDeSecurite = CreateTemplateStateFromVisible(view.HarnaisDeSecurite);
            editObject.EcranFacial = CreateTemplateStateFromVisible(view.EcranFacial);
            editObject.ProtectionAuditive = CreateTemplateStateFromVisible(view.ProtectionAuditive);
            editObject.Trepied = CreateTemplateStateFromVisible(view.Trepied);
            editObject.DispositifAntichute = CreateTemplateStateFromVisible(view.DispositifAntichute);
            editObject.ProtectionRespiratoire = CreateTemplateStateFromVisible(view.ProtectionRespiratoire);
            editObject.ProtectionRespiratoireValue = CreateTemplateValueFromVisible(view.ProtectionRespiratoire);
            editObject.Habits = CreateTemplateStateFromVisible(view.Habits);
            editObject.HabitsValue = CreateTemplateValueFromVisible(view.Habits);
            editObject.AutreProtection = CreateTemplateStateFromVisible(view.AutreProtection);
            editObject.AutreProtectionValue = CreateTemplateValueFromVisible(view.AutreProtection);

            editObject.Extincteur = CreateTemplateStateFromVisible(view.Extincteur);
            editObject.BouchesDegoutProtegees = CreateTemplateStateFromVisible(view.BouchesDegoutProtegees);
            editObject.CouvertureAntiEtincelles = CreateTemplateStateFromVisible(view.CouvertureAntiEtincelles);
            editObject.SurveillantPouretincelles = CreateTemplateStateFromVisible(view.SurveillantPouretincelles);
            editObject.PareEtincelles = CreateTemplateStateFromVisible(view.PareEtincelles);
            editObject.MiseAlaTerrePresDuLieuDeTravail = CreateTemplateStateFromVisible(view.MiseAlaTerrePresDuLieuDeTravail);
            editObject.BoyauAVapeur = CreateTemplateStateFromVisible(view.BoyauAVapeur);
            editObject.AutresEquipementDincendie = CreateTemplateStateFromVisible(view.AutresEquipementDincendie);
            editObject.AutresEquipementDincendieValue = CreateTemplateValueFromVisible(view.AutresEquipementDincendie);

            editObject.Ventulateur = CreateTemplateStateFromVisible(view.Ventulateur);
            editObject.Barrieres = CreateTemplateStateFromVisible(view.Barrieres);
            editObject.Surveillant = CreateTemplateStateFromVisible(view.Surveillant);
            editObject.SurveillantValue = CreateTemplateValueFromVisible(view.Surveillant);
            editObject.RadioEmetteur = CreateTemplateStateFromVisible(view.RadioEmetteur);
            editObject.PerimetreDeSecurite = CreateTemplateStateFromVisible(view.PerimetreDeSecurite);
            editObject.DetectionContinueDesGaz = CreateTemplateStateFromVisible(view.DetectionContinueDesGaz);
            editObject.DetectionContinueDesGazValue = CreateTemplateValueFromVisible(view.DetectionContinueDesGaz);
            editObject.KlaxonSonore = CreateTemplateStateFromVisible(view.KlaxonSonore);
            editObject.Localiser = CreateTemplateStateFromVisible(view.Localiser);
            editObject.Amiante = CreateTemplateStateFromVisible(view.Amiante);
            editObject.AutreEquipementsSecurite = CreateTemplateStateFromVisible(view.AutreEquipementsSecurite);
            editObject.AutreEquipementsSecuriteValue = CreateTemplateValueFromVisible(view.AutreEquipementsSecurite);

            editObject.InstructionsSpeciales = view.InstructionsSpeciales;
            editObject.SignatureOperateurSurLeTerrain = CreateTemplateStateFromVisible(view.SignatureOperateurSurLeTerrain);
            editObject.DetectionDesGazs = CreateTemplateStateFromVisible(view.DetectionDesGazs);
            editObject.SignatureContremaitre = CreateTemplateStateFromVisible(view.SignatureContremaitre);
            editObject.SignatureAutorise = CreateTemplateStateFromVisible(view.SignatureAutorise);
            editObject.NettoyageTransfertHorsSite = CreateTemplateStateFromVisible(view.NettoyageTransfertHorsSite);
        }

        private string CreateTemplateValueFromVisible(Visible<TernaryString> visibleTernaryString)
        {
            if (visibleTernaryString.VisibleState == VisibleState.Visible && visibleTernaryString.Value.StateAsBool)
            {
                return visibleTernaryString.Value.Text;
            }
            return null;
        }

        private TemplateState CreateTemplateStateFromVisible(Visible<TernaryString> visibleValue)
        {
            if (visibleValue.VisibleState == VisibleState.Invisible)
            {
                return TemplateState.Invisible;
            }
            if (visibleValue.VisibleState == VisibleState.Visible && visibleValue.Value.StateAsBool)
            {
                return TemplateState.Checked;
            }
            return TemplateState.Default;
        }

        private TemplateState CreateTemplateStateFromVisible(Visible<bool> visibleValue)
        {
            if (visibleValue.VisibleState == VisibleState.Invisible)
            {
                return TemplateState.Invisible;
            }
            if (visibleValue.VisibleState == VisibleState.Visible && visibleValue.Value)
            {
                return TemplateState.Checked;
            }
            return TemplateState.Default;
        }
    }
}