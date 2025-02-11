using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Client.Controls;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitMudsFormView : IWorkPermitMudsValidationAction, IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action WorkPermitTypeChanged;
        event Action WorkPermitTemplateChanged;
        event Action FunctionalLocationSelector;
        event Action PreparationCheckChanged;
        event Action ViewConfiguredDocumentLinkClicked;
        event Action ConfinedSpaceButtonClicked;
        event EventHandler StartOrEndDateTimeValueChanged;
        event Action DocumentLinkOpened;
        event Action DocumentLinkAdded;

        event Action UtilisationElectronicsChanged;

        void PutInTemplateMode();
        void TurnOnAutosetIndicatorsForDateTimes();
        void TurnOffAutosetIndicatorsForDateTimes();

        bool IsPreparation { get; set; }
        void DisableFieldsForPermitEdit(bool enableTemplateSelection);
        void DisablePermitType(bool enablePermitSelection);

        List<CraftOrTrade> Trade { set; }
        List<Contractor> AllCompanies { set; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        List<Contractor> AllCompanies_1 { set; }
        List<Contractor> AllCompanies_2 { set; }

        //List<WorkPermitMudsTemplate> PermitTemplatesCC { set; }

        List<WorkPermitMudsType> PermitTypes { set; }
        WorkPermitMudsType SelectedPermitType { get; set; }
        List<WorkPermitMudsTemplate> PermitTemplates { set; }
        WorkPermitMudsTemplate SelectedPermitTemplate { get; set; }
        string SelectedPermitTemplateName { get; set; }
        List<WorkPermitMudsGroup> RequestedByGroupValues { set; }
        WorkPermitMudsGroup SelectedRequestedByGroup { get; set; }
        List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs);
        List<FunctionalLocation> FunctionalLocations { get; set; }
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
        string SelectedTrade { get; set; }
        string Description { get; set; }
        string ReferenceNumber { set; }
        string WorkOrderNumber { set; get; }
        string Company { set; get; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string Company_1 { set; get; }
        string Company_2 { set; get; }

        string NbTravail { set; get; }
        bool FormationCheck { set; get; }
        string NomsEnt { set; get; }
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        string NomsEnt_1 { set; get; }
        string NomsEnt_2 { set; get; }
        string NomsEnt_3 { set; get; }
        string Surveilant { set; get; }

        string SelectedRequestedByGroupText { get; set; }


        string ClonedFormDetailMuds { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

        Visible<TernaryString> RemplirLeFormulaireDeCondition { get; set; }
        //Visible<bool> RemplirLeFormulaireDeConditionValue { get; set; }
        Visible<bool> AnalyseCritiqueDeLaTache { get; set; }
        Visible<bool> Depressurises { get; set; }
        Visible<bool> Vides { get; set; }
        Visible<bool> ContournementDesGda { get; set; }
        Visible<bool> Rinces { get; set; }
        Visible<bool> NettoyesLaVapeur { get; set; }
        Visible<bool> Purges { get; set; }
        Visible<bool> Ventiles { get; set; }
        Visible<bool> Aeres { get; set; }
        Visible<bool> Energies { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        //Visible<bool> Autres { get; set; }
        Visible<TernaryString> InterrupteursEtVannesCadenasses { get; set; }
        //Visible<bool> InterrupteursEtVannesCadenassesValue { get; set; }
        Visible<bool> VerrouillagesParTravailleurs { get; set; }
        Visible<bool> SourcesDesenergisees { get; set; }
        Visible<bool> DepartsLocauxTestes { get; set; }
        Visible<bool> ConduitesDesaccouplees { get; set; }
        Visible<bool> ObturateursInstallees { get; set; }
        Visible<bool> PvciSuncorEffectuee { get; set; }
        Visible<bool> PvciEntExtEffectuee { get; set; }
        Visible<bool> Amiante { get; set; }
        Visible<bool> AcideSulfurique { get; set; }
        Visible<bool> Azote { get; set; }
        Visible<bool> Caustique { get; set; }
        Visible<bool> DioxydeDeSoufre { get; set; }
        Visible<bool> Sbs { get; set; }
        Visible<bool> Soufre { get; set; }
        Visible<bool> EquipementsNonRinces { get; set; }
        Visible<bool> Hydrocarbures { get; set; }
        Visible<bool> HydrogeneSulfure { get; set; }
        Visible<bool> MonoxydeCarbone { get; set; }
        Visible<bool> Reflux { get; set; }
        Visible<bool> ProduitsVolatilsUtilises { get; set; }
        Visible<bool> Bacteries { get; set; }
        //Visible<TernaryString> Appareil { get; set; }
        //Visible<bool> AppareilValue { get; set; }
        Visible<bool> InterferencesEntreTravaux { get; set; }
        Visible<bool> PiecesEnRotation { get; set; }
        Visible<bool> IncendieExplosion { get; set; }
        Visible<bool> ContrainteThermique { get; set; }
        Visible<bool> Radiations { get; set; }
        Visible<bool> Silice { get; set; }
        Visible<bool> Vanadium { get; set; }
        Visible<bool> AsphyxieIntoxication { get; set; }
        //Visible<TernaryString> AutresRisques { get; set; }
        //Visible<bool> AutresRisquesValue { get; set; }
        //Visible<TernaryString> ElectriciteVolt { get; set; }
        //Visible<bool> ElectriciteVoltValue { get; set; }
        Visible<bool> TravailEnHauteur6EtPlus { get; set; }
        Visible<bool> VapeurCondensat { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        Visible<bool> FeSValue { get; set; } 
        
        
        Visible<bool> Electrisation { get; set; }
        Visible<bool> LunettesMonocoques { get; set; }
        Visible<bool> Visiere { get; set; }
        Visible<bool> ProtectionAuditive { get; set; }
        //Visible<bool> ManteauAntiEclaboussure { get; set; }
        Visible<bool> CagouleIgnifuge { get; set; }
        Visible<bool> Harnais2LiensDeRetenue { get; set; }
        //Visible<bool> MasqueAntiPoussiere { get; set; }
        //Visible<bool> FiltresParticules { get; set; }
        //Visible<TernaryString> Gants { get; set; }
        //Visible<bool> GantsValue { get; set; }
        //Visible<TernaryString> MasqueACartouches { get; set; }
        //Visible<bool> MasqueACartouchesValue { get; set; }
        //Visible<TernaryString> EpiAntiArcCat { get; set; }
        //Visible<bool> EPIAntiArcCATValue { get; set; }
        //Visible<bool> HabitCompletAntiEclaboussure { get; set; }
        //Visible<bool> HabitCouvreToutJetable { get; set; }
        Visible<bool> EpiAntiChoc { get; set; }
        //Visible<bool> SystemeDAdductionDAir { get; set; }
        Visible<bool> EcranDeflecteur { get; set; }
        Visible<bool> MaltDesEquipements { get; set; }
        Visible<bool> Rallonges { get; set; }
        Visible<bool> ApprobationPourEquipDeLevage { get; set; }
        Visible<bool> BarricadeRigide { get; set; }
        //Visible<TernaryString> AutresE { get; set; }
        //Visible<bool> AutresEValue { get; set; }
        Visible<TernaryString> AlarmeDcs { get; set; }
        //Visible<bool> AlarmeDCSValue { get; set; }
        Visible<bool> EchelleSecurisee { get; set; }
        Visible<bool> EchafaudageApprouve { get; set; }
        Visible<bool> OutilDeLaiton { get; set; }
        //Visible<bool> PerimetreSecurite { get; set; }
        Visible<bool> Radio { get; set; }
        Visible<bool> Signaleur { get; set; }

        Visible<bool> OutilDeLaitonPrevention { get; set; }

        Visible<bool> EffondrementEnsevelissement { get; set; }
        Visible<TernaryString> AutresConditions { get; set; }
        List<String> AutresConditionsValues { set; }

        Visible<TernaryString> AutresRisques { get; set; }
        List<String> AutresRisquesValues { set; }

        Visible<TernaryString> ElectronicVoltRisques { get; set; }
        List<String> ElectronicVoltRisquesValues { set; }

        Visible<TernaryString> GantsEquipementDeProtection { get; set; }
        List<String> GantsEquipementDeProtectionValues { set; }

        Visible<TernaryString> AppareilProtecteurEquipementDeProtection { get; set; }
        List<String> AppareilProtecteurEquipementDeProtectionValues { set; }

        Visible<TernaryString> HabitProtecteurEquipementDeProtection { get; set; }
        List<String> HabitProtecteurEquipementDeProtectionValues { set; }

        Visible<TernaryString> EpiAntiArcCatProtecteurEquipementDeProtection { get; set; }
        List<String> EpiAntiArcCatProtecteurEquipementDeProtectionValues { set; }

        Visible<TernaryString> AutresEquipementDePrevention { get; set; }
        List<String> AutresEquipementDePreventionValues { set; }

        Visible<TernaryString> OutilManuelEquipementDePrevention { get; set; }
        List<String> OutilManuelEquipementDePreventionValues { set; }

        Visible<TernaryString> PerimetreDeSecurityEquipementDePrevention { get; set; }
        List<String> PerimetreDeSecurityEquipementDePreventionValues { set; }

        Visible<TernaryString> AppareilEquipementDePrevention { get; set; }
        List<String> AppareilEquipementDePreventionValues { set; }

        Visible<TernaryString> AutresTravaux { get; set; }
        List<String> AutresTravauxValues { set; }

        Visible<TernaryString> AutresInstruction { get; set; }
        List<String> AutresInstructionValues { set; }

        Visible<TernaryString> ProcedureEntretien { get; set; }
        Visible<TernaryString> EtiquettObturateur { get; set; }
        Visible<bool> MasqueSoudeur { get; set; }

        Visible<bool> Soudage { get; set; }
        Visible<bool> Traitement { get; set; }
        Visible<bool> Cuissons { get; set; }
        Visible<bool> Per�age { get; set; }
        Visible<bool> Chaufferette { get; set; }
        Visible<bool> Meulage { get; set; }
        Visible<bool> Nettoyage { get; set; }
        Visible<bool> TravauxDansZone { get; set; }
        Visible<bool> Combustibles { get; set; }
        Visible<bool> Ecran { get; set; }
        Visible<bool> Boyau { get; set; }
        Visible<bool> BoyauDe { get; set; }
        Visible<bool> Couverture { get; set; }
        Visible<bool> Extincteur { get; set; }
        Visible<bool> Bouche { get; set; }
        Visible<bool> RadioS { get; set; }
        Visible<bool> Surveillant { get; set; }
        Visible<bool> UtilisationMoteur { get; set; }
        Visible<bool> NettoyageAu { get; set; }
        Visible<bool> UtilisationElectronics { get; set; }
        Visible<bool> Radiographie { get; set; }
        Visible<bool> UtilisationOutlis { get; set; }
        //Visible<bool> UtilisationEquipments { get; set; }
        Visible<bool> Demolition { get; set; }
        Visible<bool> MhAutres { get; set; }
       
        string InstructionsSpeciales { get; set; }
        Visible<bool> SignatureOperateurSurLeTerrain { get; set; }
        Visible<bool> DetectionDesGazs { get; set; }
        Visible<bool> SignatureContremaitre { get; set; }
        Visible<bool> SignatureAutorise { get; set; }
        Visible<bool> NettoyageTransfertHorsSite { get; set; }
        //List<String> CorrosifValues { set; }
        //List<String> AromatiqueValues { set; }
        //List<String> AutresSubstancesValues { set; }
        //List<String> AutreConditionsValues { set; }
        //List<string> HabitsValues { set; }
        //List<string> AutreProtectionValues { set; }
        //List<String> AutresEquipementDincendieValues { set; }
        //List<String> SurveillantValues { set; }
        //List<String> DetectionContinueDesGazValues { set; }
        //List<String> AutreEquipementsSecuriteValues { set; }
        //List<string> ProtectionRespiratoireValues { set; }
        ConfiguredDocumentLink SelectedConfiguredDocumentLink { get; }
        List<ConfiguredDocumentLink> ConfiguredDocumentLinks { set; }
        List<DocumentLink> DocumentLinks { get; set; }

        void SetRequestDetails(
            bool visible,
            DateTime? requestedDateTime, string requestedByUser,
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string company, string company_1, string company_2, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes);

        DialogResult ShowFunctionalLocationsLengthWarning(string truncatedFlocString);
        void DisableConfiguredDocumentLinks();
        void OpenFileOrDirectoryOrWebsite(string link);
        bool ShowFieldOperatorUncheckedWarning();
        DialogResult ShowReviewDocumentLinksWarning();



        //Added for Gas test
        void InitializeStandardGasTestElementInfoList(List<GasTestElementInfo> list);
        List<GasTestElementDetailsMuds> GasTestElementDetailsList { get; }
        Time FirtTestResult{set;get;}
        Time SecondTestResult { set; get; }
        Time ThirdTestResult { set; get; }
        Time FourthTestResult { set; get; }
        void EnbaleGasTest(bool val);

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

        string MudsAnswerTextBox { set; get; }
        string MudsQuestionlabel { set; get; }
        
        
    }
}