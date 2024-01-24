using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public enum TemplateState
    {
        Default = 0, // Meaning: visible and unchecked
        Checked = 1, // Meaning: visible and checked
        Invisible = 2 // Meaning: not visible
    }

    [Serializable]
    public class WorkPermitMontrealTemplate : DomainObject
    {
        public static WorkPermitMontrealTemplate NULL = CreateNullTemplate();

        // Pass TemplateNumber = 0 only when a new template is being inserted. 
        // This is used by the Insert stored proc to trigger it to auto generate a new TemplateNumber.
        public static int? NET_NEW_TEMPLATE = 0;
        private bool isActive;
        private bool isDeleted;
        private string name;
        private int? templateNumber;
        private WorkPermitMontrealType workPermitType;

        public WorkPermitMontrealTemplate(string name, WorkPermitMontrealType workPermitType, bool isActive,
            bool isDeleted, int? templateNumber)
        {
            this.name = name;
            this.workPermitType = workPermitType;
            this.isActive = isActive;
            this.isDeleted = isDeleted;
            this.templateNumber = templateNumber;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // This is used by the Form combo box (and Manage Template screen) to show a custom formated Name.
        public string DisplayName
        {
            get { return TemplateNumber.HasValue ? TemplateNumber + " - " + Name : Name; }
        }

        public WorkPermitMontrealType WorkPermitType
        {
            get { return workPermitType; }
            set { workPermitType = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public string ActiveValue
        {
            get
            {
                return isActive
                    ? StringResources.MontrealWorkPermitTemplateStatusColumnValueActive
                    : StringResources.MontrealWorkPermitTemplateStatusColumnValueInactive;
            }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public int? TemplateNumber
        {
            get { return templateNumber; }
            set { templateNumber = value; }
        }

        public TemplateState H2S { get; set; }
        public TemplateState Hydrocarbure { get; set; }

        public TemplateState Ammoniaque { get; set; }
        public TemplateState Corrosif { get; set; }
        public string CorrosifValue { get; set; }
        public TemplateState Aromatique { get; set; }
        public string AromatiqueValue { get; set; }
        public TemplateState AutresSubstances { get; set; }
        public string AutresSubstancesValue { get; set; }

        public TemplateState ObtureOuDebranche { get; set; }
        public TemplateState DepressuriseEtVidange { get; set; }
        public TemplateState EnPresenceDeGazInerte { get; set; }
        public TemplateState PurgeALaVapeur { get; set; }
        public TemplateState RinceALeau { get; set; }
        public TemplateState Excavation { get; set; }
        public TemplateState DessinsRequis { get; set; }
        public string DessinsRequisValue { get; set; }
        public TemplateState CablesChauffantsMisHorsTension { get; set; }
        public TemplateState PompeOuVerinPneumatique { get; set; }

        public TemplateState ChaineEtCadenasseOuScelle { get; set; }
        public TemplateState InterrupteursElectriquesVerrouilles { get; set; }
        public TemplateState PurgeParUnGazInerte { get; set; }
        public TemplateState OutilsElectriquesOuABatteries { get; set; }
        public TemplateState BoiteEnergieZero { get; set; }
        public string BoiteEnergieZeroValue { get; set; }
        public TemplateState OutilsPneumatiques { get; set; }
        public TemplateState MoteurACombustionInterne { get; set; }
        public TemplateState TravauxSuperPoses { get; set; }

        public TemplateState FormulaireDespaceClosAffiche { get; set; }
        public string FormulaireDespaceClosAfficheValue { get; set; }
        public TemplateState ExisteIlUneAnalyseDeTache { get; set; }
        public TemplateState PossibiliteDeSulfureDeFer { get; set; }
        public TemplateState AereVentile { get; set; }
        public TemplateState SoudureALelectricite { get; set; }
        public TemplateState BrulageAAcetylene { get; set; }
        public TemplateState Nacelle { get; set; }
        public TemplateState AutreConditions { get; set; }
        public string AutreConditionsValue { get; set; }

        public TemplateState LunettesMonocoques { get; set; }
        public TemplateState HarnaisDeSecurite { get; set; }
        public TemplateState EcranFacial { get; set; }
        public TemplateState ProtectionAuditive { get; set; }
        public TemplateState Trepied { get; set; }
        public TemplateState DispositifAntichute { get; set; }
        public TemplateState ProtectionRespiratoire { get; set; }
        public string ProtectionRespiratoireValue { get; set; }
        public TemplateState Habits { get; set; }
        public string HabitsValue { get; set; }
        public TemplateState AutreProtection { get; set; }
        public string AutreProtectionValue { get; set; }

        public TemplateState Extincteur { get; set; }
        public TemplateState BouchesDegoutProtegees { get; set; }
        public TemplateState CouvertureAntiEtincelles { get; set; }
        public TemplateState SurveillantPouretincelles { get; set; }
        public TemplateState PareEtincelles { get; set; }
        public TemplateState MiseAlaTerrePresDuLieuDeTravail { get; set; }
        public TemplateState BoyauAVapeur { get; set; }
        public TemplateState AutresEquipementDincendie { get; set; }
        public string AutresEquipementDincendieValue { get; set; }

        public TemplateState Ventulateur { get; set; }
        public TemplateState Barrieres { get; set; }
        public TemplateState Surveillant { get; set; }
        public string SurveillantValue { get; set; }
        public TemplateState RadioEmetteur { get; set; }
        public TemplateState PerimetreDeSecurite { get; set; }
        public TemplateState DetectionContinueDesGaz { get; set; }
        public string DetectionContinueDesGazValue { get; set; }
        public TemplateState KlaxonSonore { get; set; }
        public TemplateState Localiser { get; set; }
        public TemplateState Amiante { get; set; }
        public TemplateState AutreEquipementsSecurite { get; set; }
        public string AutreEquipementsSecuriteValue { get; set; }

        public string InstructionsSpeciales { get; set; }
        public TemplateState SignatureOperateurSurLeTerrain { get; set; }
        public TemplateState DetectionDesGazs { get; set; }
        public TemplateState SignatureContremaitre { get; set; }
        public TemplateState SignatureAutorise { get; set; }
        public TemplateState NettoyageTransfertHorsSite { get; set; }

        private static WorkPermitMontrealTemplate CreateNullTemplate()
        {
            var template = new WorkPermitMontrealTemplate(string.Empty, WorkPermitMontrealType.NULL, true, false, null);

            template.H2S = TemplateState.Default;
            template.Hydrocarbure = TemplateState.Default;
            template.Ammoniaque = TemplateState.Default;
            template.Corrosif = TemplateState.Default;
            template.Aromatique = TemplateState.Default;
            template.AutresSubstances = TemplateState.Default;

            template.ObtureOuDebranche = TemplateState.Default;
            template.DepressuriseEtVidange = TemplateState.Default;
            template.EnPresenceDeGazInerte = TemplateState.Default;
            template.PurgeALaVapeur = TemplateState.Default;
            template.RinceALeau = TemplateState.Default;
            template.Excavation = TemplateState.Default;

            template.DessinsRequis = TemplateState.Default;

            template.CablesChauffantsMisHorsTension = TemplateState.Default;
            template.PompeOuVerinPneumatique = TemplateState.Default;
            template.ChaineEtCadenasseOuScelle = TemplateState.Default;
            template.InterrupteursElectriquesVerrouilles = TemplateState.Default;
            template.PurgeParUnGazInerte = TemplateState.Default;
            template.OutilsElectriquesOuABatteries = TemplateState.Default;

            template.BoiteEnergieZero = TemplateState.Default;

            template.OutilsPneumatiques = TemplateState.Default;
            template.MoteurACombustionInterne = TemplateState.Default;
            template.TravauxSuperPoses = TemplateState.Default;
            template.FormulaireDespaceClosAffiche = TemplateState.Default;

            template.ExisteIlUneAnalyseDeTache = TemplateState.Default;
            template.PossibiliteDeSulfureDeFer = TemplateState.Default;
            template.AereVentile = TemplateState.Default;
            template.SoudureALelectricite = TemplateState.Default;
            template.BrulageAAcetylene = TemplateState.Default;
            template.Nacelle = TemplateState.Default;
            template.AutreConditions = TemplateState.Default;

            template.LunettesMonocoques = TemplateState.Default;
            template.HarnaisDeSecurite = TemplateState.Default;
            template.EcranFacial = TemplateState.Default;
            template.ProtectionAuditive = TemplateState.Default;
            template.Trepied = TemplateState.Default;
            template.DispositifAntichute = TemplateState.Default;
            template.ProtectionRespiratoire = TemplateState.Default;
            template.Habits = TemplateState.Default;
            template.AutreProtection = TemplateState.Default;

            template.Extincteur = TemplateState.Default;
            template.BouchesDegoutProtegees = TemplateState.Default;
            template.CouvertureAntiEtincelles = TemplateState.Default;
            template.SurveillantPouretincelles = TemplateState.Default;
            template.PareEtincelles = TemplateState.Default;
            template.MiseAlaTerrePresDuLieuDeTravail = TemplateState.Default;
            template.BoyauAVapeur = TemplateState.Default;
            template.AutresEquipementDincendie = TemplateState.Default;

            template.Ventulateur = TemplateState.Default;
            template.Barrieres = TemplateState.Default;
            template.Surveillant = TemplateState.Default;
            template.RadioEmetteur = TemplateState.Default;
            template.PerimetreDeSecurite = TemplateState.Default;

            template.DetectionContinueDesGaz = TemplateState.Default;

            template.KlaxonSonore = TemplateState.Default;
            template.Localiser = TemplateState.Default;
            template.Amiante = TemplateState.Default;
            template.AutreEquipementsSecurite = TemplateState.Default;

            template.SignatureOperateurSurLeTerrain = TemplateState.Default;
            template.DetectionDesGazs = TemplateState.Default;
            template.SignatureContremaitre = TemplateState.Default;
            template.SignatureAutorise = TemplateState.Default;

            return template;
        }

        public static int CompareByTemplateNumber(WorkPermitMontrealTemplate x, WorkPermitMontrealTemplate y)
        {
            if (x.templateNumber == null && y.templateNumber == null)
            {
                return 0;
            }
            if (x.templateNumber == null)
            {
                return -1;
            }
            if (y.templateNumber == null)
            {
                return 1;
            }
            return x.templateNumber.Value.CompareTo(y.templateNumber.Value);
        }
    }
}