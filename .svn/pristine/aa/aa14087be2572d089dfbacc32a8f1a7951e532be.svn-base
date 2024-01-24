using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitMontrealFormView : IWorkPermitMontrealValidationAction, IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action WorkPermitTypeChanged;
        event Action WorkPermitTemplateChanged;
        event Action FunctionalLocationSelector;
        event Action PreparationCheckChanged;
        event Action ViewConfiguredDocumentLinkClicked;
        event Action ConfinedSpaceButtonClicked;
        event EventHandler StartOrEndDateTimeValueChanged;
        event Action<string> AutresSubstancesTextValueChanged;
        event Action DocumentLinkOpened;
        event Action DocumentLinkAdded;

        void PutInTemplateMode();
        void TurnOnAutosetIndicatorsForDateTimes();
        void TurnOffAutosetIndicatorsForDateTimes();

        bool IsPreparation { get; set; }
        void DisableFieldsForPermitEdit(bool enableTemplateSelection);

        List<CraftOrTrade> Trade { set; }
        List<WorkPermitMontrealType> PermitTypes { set; }
        WorkPermitMontrealType SelectedPermitType { get; set; }
        List<WorkPermitMontrealTemplate> PermitTemplates { set; }
        WorkPermitMontrealTemplate SelectedPermitTemplate { get; set; }
        string SelectedPermitTemplateName { get; set; }
        List<WorkPermitMontrealGroup> RequestedByGroupValues { set; }
        WorkPermitMontrealGroup SelectedRequestedByGroup { get; set; }
        List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs);
        List<FunctionalLocation> FunctionalLocations { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
        string SelectedTrade { get; set; }
        string Description { get; set; }
        string ReferenceNumber { set; }
        string WorkOrderNumber { set; get; }
        
        string ClonedFormDetailMontreal { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

        Visible<bool> H2S { get; set; }
        Visible<bool> Hydrocarbure { get; set; }
        Visible<bool> Ammoniaque { get; set; }
        Visible<TernaryString> Corrosif { get; set; }
        Visible<TernaryString> Aromatique { get; set; }
        Visible<TernaryString> AutresSubstances { get; set; }
        Visible<bool> ObtureOuDebranche { get; set; }
        Visible<bool> DepressuriseEtVidange { get; set; }
        Visible<bool> EnPreenceDeGazInerte { get; set; }
        Visible<bool> PurgeALaVapeur { get; set; }
        Visible<bool> RinceALeau { get; set; }
        Visible<bool> Excavation { get; set; }
        Visible<TernaryString> DessinsRequis { get; set; }
        Visible<bool> CablesChauffantsMisHorsTension { get; set; }
        Visible<bool> PompeOuVerinPneumatique { get; set; }
        Visible<bool> ChaineEtCadenasseOuScelle { get; set; }
        Visible<bool> InterrupteursElectriquesVerrouilles { get; set; }
        Visible<bool> PurgeParUnGazInerte { get; set; }
        Visible<bool> OutilsElectriquesOuABatteries { get; set; }
        Visible<TernaryString> BoiteEnergieZero { get; set; }
        Visible<bool> OutilsPneumatiques { get; set; }
        Visible<bool> MoteurACombustionInterne { get; set; }
        Visible<bool> TravauxSuperPoses { get; set; }
        Visible<TernaryString> FormulaireDespaceClosAffiche { get; set; }
        Visible<bool> ExisteIlUneAnalyseDeTache { get; set; }
        Visible<bool> PossibiliteDeSulfureDeFer { get; set; }
        Visible<bool> AereVentile { get; set; }
        Visible<bool> SoudureALelectricite { get; set; }
        Visible<bool> BrulageAAcetylene { get; set; }
        Visible<bool> Nacelle { get; set; }
        Visible<TernaryString> AutreConditions { get; set; }
        Visible<bool> LunettesMonocoques { get; set; }
        Visible<bool> HarnaisDeSecurite { get; set; }
        Visible<bool> EcranFacial { get; set; }
        Visible<bool> ProtectionAuditive { get; set; }
        Visible<bool> Trepied { get; set; }
        Visible<bool> DispositifAntichute { get; set; }
        Visible<TernaryString> ProtectionRespiratoire { get; set; }
        Visible<TernaryString> Habits { get; set; }
        Visible<TernaryString> AutreProtection { get; set; }
        Visible<bool> Extincteur { get; set; }
        Visible<bool> BouchesDegoutProtegees { get; set; }
        Visible<bool> CouvertureAntiEtincelles { get; set; }
        Visible<bool> SurveillantPouretincelles { get; set; }
        Visible<bool> PareEtincelles { get; set; }
        Visible<bool> MiseAlaTerrePresDuLieuDeTravail { get; set; }
        Visible<bool> BoyauAVapeur { get; set; }
        Visible<TernaryString> AutresEquipementDincendie { get; set; }
        Visible<bool> Ventulateur { get; set; }
        Visible<bool> Barrieres { get; set; }
        Visible<TernaryString> Surveillant { get; set; }
        Visible<bool> RadioEmetteur { get; set; }
        Visible<bool> PerimetreDeSecurite { get; set; }
        Visible<TernaryString> DetectionContinueDesGaz { get; set; }
        Visible<bool> KlaxonSonore { get; set; }
        Visible<bool> Localiser { get; set; }
        Visible<bool> Amiante { get; set; }
        Visible<TernaryString> AutreEquipementsSecurite { get; set; }
        string InstructionsSpeciales { get; set; }
        Visible<bool> SignatureOperateurSurLeTerrain { get; set; }
        Visible<bool> DetectionDesGazs { get; set; }
        Visible<bool> SignatureContremaitre { get; set; }
        Visible<bool> SignatureAutorise { get; set; }
        Visible<bool> NettoyageTransfertHorsSite { get; set; }
        List<String> CorrosifValues { set; }
        List<String> AromatiqueValues { set; }
        List<String> AutresSubstancesValues { set; }
        List<String> AutreConditionsValues { set; }
        List<string> HabitsValues { set; }
        List<string> AutreProtectionValues { set; }
        List<String> AutresEquipementDincendieValues { set; }
        List<String> SurveillantValues { set; }
        List<String> DetectionContinueDesGazValues { set; }
        List<String> AutreEquipementsSecuriteValues { set; }
        List<string> ProtectionRespiratoireValues { set; }
        ConfiguredDocumentLink SelectedConfiguredDocumentLink { get; }
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        List<DocumentLink> DocumentLinks { get; set; }

        void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
            string company, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes);

        DialogResult ShowFunctionalLocationsLengthWarning(string truncatedFlocString);
        void DisableConfiguredDocumentLinks();
        void OpenFileOrDirectoryOrWebsite(string link);
        bool ShowFieldOperatorUncheckedWarning();
        DialogResult ShowReviewDocumentLinksWarning();
    }
}