using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitMontrealDetails : IDeletableDetails
    {
        event EventHandler Clone;
        event EventHandler CloseWorkPermit;
        event EventHandler Print;
        event EventHandler PrintPreview;
        event Action OpenDocumentLink;
        event Action ViewAssociatedLogs;

        event Action<ConfiguredDocumentLink> ConfiguredDocumentLinkClicked;

        IWorkPermitMontrealDetails BindingTarget { get; }

        void MakeAllButtonsInvisible();
        bool EditVisible { set; }
        bool CloseVisible { set; }
        bool PrintVisible { set; }
        bool PrintPreviewVisible { set; }
        bool EditHistoryVisible { set; }

        bool CloseEnabled { set; }
        bool CloneEnabled { set; }
        bool PrintEnabled { set; }
        bool PrintPreviewEnabled { set; }


        string PermitType { set; }
        string PermitStartDate { set; }
        string PermitEndDate { set; }
        string WorkPermitTemplate { set; }
        string WorkPermitNumber { set; }
        List<FunctionalLocation> FunctionalLocations { set; }
        string Trade { set; }
        string RequestedByGroup { set; }
        string WorkOrderNumber { set; }
        string Description { set; }

        Visible<bool> H2S { set; }
        Visible<bool> Hydrocarbure { set; }
        Visible<bool> Ammoniaque { set; }
        string CorrosifData { set; }
        Visible<bool> Corrosif { set; }
        string AromatiqueData { set; }
        Visible<bool> Aromatique { set; }
        string AutresData { set; }
        Visible<bool> Autres { set; }

        Visible<bool> ObtureOuDebranche { set; }
        Visible<bool> DepressuriseEtVidange { set; }
        Visible<bool> EnPresenceDeGazInerte { set; }
        Visible<bool> PurgeALaVapeur { set; }
        Visible<bool> RinceALeau { set; }
        Visible<bool> Excavation { set; }
        string DessinsRequisData { set; }
        Visible<bool> DessinsRequis { set; }
        Visible<bool> CablesChauffantsMisHorsTension { set; }
        Visible<bool> PompeOuVerinPneumatique { set; }

        Visible<bool> ChaineEtCadenasseOuScelle { set; }
        Visible<bool> InterrupteursElectriquesVerrouilles { set; }
        Visible<bool> PurgeParUnGazInerte { set; }
        Visible<bool> OutilsElectriquesOuABatteries { set; }
        string BoiteEnergieZeroData { set; }
        Visible<bool> BoiteEnergieZero { set; }
        Visible<bool> OutilsPneumatiques { set; }
        Visible<bool> MoteurACombustionInterne { set; }
        Visible<bool> TravauxSuperPoses { set; }
        string FormulaireDespaceClosAfficheData { set; }
        Visible<bool> FormulaireDespaceClosAffiche { set; }
        Visible<bool> ExisteIlUneAnalyseDeTache { set; }
        Visible<bool> PossibiliteDeSulfureDeFer { set; }
        Visible<bool> AereVentile { set; }
        Visible<bool> SoudureALelectricite { set; }
        Visible<bool> BrulageAAcetylene { set; }
        Visible<bool> Nacelle { set; }
        string AutreConditionsData { set; }
        Visible<bool> AutreConditions { set; }
        Visible<bool> LunettesMonocoques { set; }
        Visible<bool> HarnaisDeSecurite { set; }
        Visible<bool> EcranFacial { set; }
        Visible<bool> ProtectionAuditive { set; }
        Visible<bool> Trepied { set; }
        Visible<bool> DispositifAntichute { set; }
        string ProtectionRespiratoireData { set; }
        Visible<bool> ProtectionRespiratoire { set; }
        string HabitsData { set; }
        Visible<bool> Habits { set; }
        string AutreProtectionData { set; }
        Visible<bool> AutreProtection { set; }

        // Protection incendie
        Visible<bool> Extincteur { set; }
        Visible<bool> BouchesDegoutProtegees { set; }
        Visible<bool> CouvertureAntiEtincelles { set; }
        Visible<bool> SurveillantPouretincelles { set; }
        Visible<bool> PareEtincelles { set; }
        Visible<bool> MiseAlaTerrePresDuLieuDeTravail { set; }
        Visible<bool> BoyauAVapeur { set; }
        string AutresEquipementDincendieData { set; }
        Visible<bool> AutresEquipementDincendie { set; }
        
        // Autres �quipements de s�curit�
        Visible<bool> Ventulateur { set; }
        Visible<bool> Barrieres { set; }
        string SurveillantData { set; }
        Visible<bool> Surveillant { set; }
        Visible<bool> RadioEmetteur { set; }
        Visible<bool> PerimetreDeSecurite { set; }
        string DetectionContinueDesGazData { set; }
        Visible<bool> DetectionContinueDesGaz { set; }
        Visible<bool> KlaxonSonore { set; }
        Visible<bool> Localiser { set; }
        Visible<bool> Amiante { set; }
        string AutreEquipementsSecuriteData { set; }
        Visible<bool> AutreEquipementsSecurite { set; }
        string InstructionsSpeciales { set; }
        Visible<bool> SignatureOperateurSurLeTerrain { set; }
        Visible<bool> DetectionDesGazs { set; }
        Visible<bool> SignatureContremaitre { set; }
        Visible<bool> SignatureAutorise { set; }
        Visible<bool> NettoyageTransfertHorsSite { set; }

        List<DocumentLink> DocumentLinks { set; }

        void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
            string company, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes);

        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        bool ViewAssociatedLogsEnabled { set; }
        void DisableConfiguredDocumentLinks();

        // DMND0010609-OLT - Edmonton Work permit Scan
        bool ViewAttachEnabled { set; }
        event EventHandler ViewAttachment;
        bool ViewScanEnabled { set; }
        void MakeSeachWindowRequiredButtonsvisibleonly();

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        event EventHandler MarkAsTemplate;
        
        bool MarkTemplateEnabled { set; }

        bool DeleteVisible { set; }
        bool editVisible { set; }
        bool closeButtonVisible { set; }
        bool printButtonVisible { set; }
        bool printPreviewButtonVisible { set; }

        bool editHistoryButtonVisible { set; }
        bool viewAssociatedLogsButtonVisible { set; }
        bool ScanButtonVisible { set; }
        bool ViewAttachmentbuttonVisible { set; }
        
        bool documentLinksVisible { set; }

        event EventHandler RefreshAll;

        event EventHandler EditTemplate;

        bool editTemplateVisible { set; }
        
    }
}