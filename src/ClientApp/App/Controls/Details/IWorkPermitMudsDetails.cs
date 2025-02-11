using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public interface IWorkPermitMudsDetails : IDeletableDetails
    {
        event EventHandler Clone;
        event EventHandler CloseWorkPermit;
        event EventHandler Print;
        event EventHandler PrintPreview;
        event Action OpenDocumentLink;
        event Action ViewAssociatedLogs;

        event Action<ConfiguredDocumentLink> ConfiguredDocumentLinkClicked;

        IWorkPermitMudsDetails BindingTarget { get; }

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
        string CompanyName { set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string CompanyName_1 { set; }
        string CompanyName_2 { set; }
        string RequestedByGroup { set; }
        string RequestedByGroupText { set; }
        string WorkOrderNumber { set; }
        string Description { set; }

        string NbTravail { set; }
        bool FormationCheck { set; }
        string NomsEnt { set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string NomsEnt_1 { set; }
        string NomsEnt_2 { set; }
        string NomsEnt_3 { set; }
        string Surveilant { set; }

        string RemplirLeFormulaireDeConditionData { set; }
        Visible<bool> RemplirLeFormulaireDeCondition { set; }

        Visible<bool> AnalyseCritiqueDeLaTache { set; }
        Visible<bool> Depressurises { set; }
        Visible<bool> Vides { set; }
        Visible<bool> ContournementDesGda { set; }
        Visible<bool> Rinces { set; }
        Visible<bool> NettoyesLaVapeur { set; }
        Visible<bool> Purges { set; }
        Visible<bool> Ventiles { set; }
        Visible<bool> Aeres { set; }
        Visible<bool> Energies { set; }  // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        Visible<bool> Autres { set; }
        string AutresCData { set; }

        string InterrupteursEtVannesCadenassesData { set; }
        Visible<bool> InterrupteursEtVannesCadenasses { set; }

        Visible<bool> VerrouillagesParTravailleurs { set; }
        Visible<bool> SourcesDesenergisees { set; }
        Visible<bool> DepartsLocauxTestes { set; }
        Visible<bool> ConduitesDesaccouplees { set; }
        Visible<bool> ObturateursInstallees { set; }
        Visible<bool> PvciSuncorEffectuee { set; }
        Visible<bool> PvciEntExtEffectuee { set; }
        Visible<bool> Amiante { set; }
        Visible<bool> AcideSulfurique { set; }
        Visible<bool> Azote { set; }
        Visible<bool> Caustique { set; }
        Visible<bool> DioxydeDeSoufre { set; }
        Visible<bool> Sbs { set; }
        Visible<bool> Soufre { set; }
        Visible<bool> EquipementsNonRinces { set; }
        Visible<bool> Hydrocarbures { set; }
        Visible<bool> HydrogeneSulfure { set; }
        Visible<bool> MonoxydeCarbone { set; }
        Visible<bool> Reflux { set; }
        Visible<bool> ProduitsVolatilsUtilises { set; }
        Visible<bool> Bacteries { set; }

        string AppareilData { set; }
        Visible<bool> Appareil { set; }

        Visible<bool> InterferencesEntreTravaux { set; }
        Visible<bool> PiecesEnRotation { set; }
        Visible<bool> IncendieExplosion { set; }
        Visible<bool> ContrainteThermique { set; }
        Visible<bool> Radiations { set; }
        Visible<bool> Silice { set; }
        Visible<bool> Vanadium { set; }
        Visible<bool> AsphyxieIntoxication { set; }

        string AutresRisquesData { set; }
        Visible<bool> AutresRisques { set; }

        string ElectriciteVoltData { set; }
        Visible<bool> ElectriciteVolt { set; }

        Visible<bool> TravailEnHauteur6EtPlus { set; }
        Visible<bool> VapeurCondensat { set; }  // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        Visible<bool> FeSValue { set; } 
        

        Visible<bool> Electrisation { set; }
        Visible<bool> LunettesMonocoques { set; }
        Visible<bool> Visiere { set; }
        Visible<bool> ProtectionAuditive { set; }
        //Visible<bool> ManteauAntiEclaboussure { set; }
        Visible<bool> CagouleIgnifuge { set; }
        Visible<bool> Harnais2LiensDeRetenue { set; }
        //Visible<bool> MasqueAntiPoussiere { set; }
        //Visible<bool> FiltresParticules { set; }

        string GantsData { set; }
        Visible<bool> Gants { set; }

        string MasqueACartouchesData { set; }
        Visible<bool> MasqueACartouches { set; }

        string EpiAntiArcCatData { set; }
        Visible<bool> EpiAntiArcCat { set; }

        Visible<bool> HabitCompletAntiEclaboussure { set; }
        string HabitCompletAntiEclaboussureData { set; }

        //Visible<bool> HabitCouvreToutJetable { set; }
        Visible<bool> EpiAntiChoc { set; }
        //Visible<bool> SystemeDAdductionDAir { set; }
        Visible<bool> EcranDeflecteur { set; }
        Visible<bool> MaltDesEquipements { set; }
        Visible<bool> Rallonges { set; }
        Visible<bool> ApprobationPourEquipDeLevage { set; }
        Visible<bool> BarricadeRigide { set; }

        string AutresEData { set; }
        Visible<bool> AutresE { set; }

        string AlarmeDcsData { set; }
        Visible<bool> AlarmeDcs { set; }

        Visible<bool> EchelleSecurisee { set; }
        Visible<bool> EchafaudageApprouve { set; }
        Visible<bool> OutilDeLaiton { set; }
        Visible<bool> PerimetreSecurite { set; }
        Visible<bool> Radio { set; }
        Visible<bool> Signaleur { set; }
        string PerimetreSecuriteData { set; }

        Visible<bool> OutillageElectriqueCheckBox { set; }


        string InstructionsSpeciales { set; }
        Visible<bool> SignatureOperateurSurLeTerrain { set; }
        Visible<bool> DetectionDesGazs { set; }
        Visible<bool> SignatureContremaitre { set; }
        Visible<bool> SignatureAutorise { set; }
        Visible<bool> NettoyageTransfertHorsSite { set; }

        List<DocumentLink> DocumentLinks { set; }

        string ProcedureData { set; }
        Visible<bool> Procedure { set; }

        string HabitProtecteurData { set; }
        Visible<bool> HabitProtecteur { set; }

        string EtiquetteData { set; }
        Visible<bool> Etiquette { set; }

        //string MasqueData { set; }
        Visible<bool> Masque { set; }

        string AutresTravauxData { set; }
        Visible<bool> AutresTravaux { set; }

        string AutresInstructionData { set; }
        Visible<bool> AutresInstruction { set; }

        //string AutresColdData { set; }
        //Visible<bool> AutresCold { set; }

        Visible<bool> Soudage { set; }
        Visible<bool> Traitement { set; }
        Visible<bool> Cuissons { set; }
        Visible<bool> Per�age { set; }
        Visible<bool> Chaufferette { set; }
        Visible<bool> Meulage { set; }
        Visible<bool> Nettoyage { set; }
        Visible<bool> TravauxDansZone { set; }
        Visible<bool> Combustibles { set; }
        Visible<bool> Ecran { set; }
        Visible<bool> Boyau { set; }
        Visible<bool> BoyauDe { set; }
        Visible<bool> Couverture { set; }
        Visible<bool> Extincteur { set; }
        Visible<bool> Bouche { set; }
        Visible<bool> RadioS { set; }
        Visible<bool> Surveillant { set; }
        Visible<bool> UtilisationMoteur { set; }
        Visible<bool> NettoyageAu { set; }
        Visible<bool> UtilisationElectronics { set; }
        Visible<bool> Radiographie { set; }
        Visible<bool> UtilisationOutlis { set; }
        Visible<bool> UtilisationEquipments { set; }
        Visible<bool> Demolition { set; }
        Visible<bool> MhAutres { set; }

        void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string company, string company_1, string company_2, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes);

        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        bool ViewAssociatedLogsEnabled { set; }
        void DisableConfiguredDocumentLinks();
        // DMND0010609-OLT - Edmonton Work permit Scan
        bool ViewAttachEnabled { set; }
        event EventHandler ViewAttachment;
        bool ViewScanEnabled { set; }
        void MakeSeachWindowRequiredButtonsvisibleonly();

        bool GasTestButtonEnabled{set;}
        event EventHandler GastestButtonEvent;

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        event EventHandler MarkAsTemplate;

        event EventHandler EditTemplate;

        

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
        bool GasTestButtonVisible { set; }
        bool documentLinksVisible { set; }

        bool editTemplateVisible { set; }

        


        event EventHandler RefreshAll;

        string MudsAnswerTextBox { set; }
        string MudsQuestionlabel { set; }
        


    }
}