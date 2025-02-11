﻿using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMudsHistory : DomainObjectHistorySnapshot
    {
        public WorkPermitMudsHistory(long id, User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
        }

        public WorkPermitMudsType WorkPermitType { get; set; }
        public string Template { get; set; }
        public PermitRequestBasedWorkPermitStatus WorkPermitStatus { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public long? PermitNumber { get; set; }
        public string WorkOrderNumber { get; set; }
        public string FunctionalLocations { get; set; }
        public string Trade { get; set; }
        public string Description { get; set; }
        public DateTime? IssuedDateTime { get; set; }

        public TernaryString RemplirLeFormulaireDeCondition { get; set; }
        public bool AnalyseCritiqueDeLaTache { get; set; }
        public bool Depressurises { get; set; }
        public bool Vides { get; set; }
        public bool ContournementDesGda { get; set; }
        public bool Rinces { get; set; }
        public bool NettoyesLaVapeur { get; set; }
        public bool Purges { get; set; }
        public bool Ventiles { get; set; }
        public bool Aeres { get; set; }
        public bool Energies { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        public TernaryString ProcedureEntretien { get; set; }
        public TernaryString AutresConditions { get; set; }
        public TernaryString InterrupteursEtVannesCadenasses { get; set; }
        public bool VerrouillagesParTravailleurs { get; set; }
        public bool SourcesDesenergisees { get; set; }
        public bool DepartsLocauxTestes { get; set; }
        public bool ConduitesDesaccouplees { get; set; }
        public bool ObturateursInstallees { get; set; }
        public TernaryString EtiquettObturateur { get; set; }
        public bool PvciSuncorEffectuee { get; set; }
        public bool PvciEntExtEffectuee { get; set; }
        public bool Amiante { get; set; }
        public bool AcideSulfurique { get; set; }
        public bool Azote { get; set; }
        public bool Caustique { get; set; }
        public bool DioxydeDeSoufre { get; set; }
        public bool Sbs { get; set; }
        public bool Soufre { get; set; }
        public bool EquipementsNonRinces { get; set; }
        public bool Hydrocarbures { get; set; }
        public bool HydrogeneSulfure { get; set; }
        public bool MonoxydeCarbone { get; set; }
        public bool Reflux { get; set; }
        public bool ProduitsVolatilsUtilises { get; set; }
        public bool Bacteries { get; set; }
        public TernaryString Appareil { get; set; }
        public bool InterferencesEntreTravaux { get; set; }
        public bool PiecesEnRotation { get; set; }
        public bool IncendieExplosion { get; set; }
        public bool ContrainteThermique { get; set; }
        public bool Radiations { get; set; }
        public bool Silice { get; set; }
        public bool Vanadium { get; set; }
        public bool AsphyxieIntoxication { get; set; }
        public TernaryString AutresRisques { get; set; }
        public TernaryString ElectriciteVolt { get; set; }
        public bool OutillageElectrique { get; set; }
        public bool TravailEnHauteur6EtPlus { get; set; }
        public bool VapeurCondensat { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        public bool FeSValue { get; set; }
        

        public bool Electrisation { get; set; }
        public bool LunettesMonocoques { get; set; }
        public bool Visiere { get; set; }
        public bool ProtectionAuditive { get; set; }
        public bool CagouleIgnifuge { get; set; }
        public bool Harnais2LiensDeRetenue { get; set; }
        public TernaryString Gants { get; set; }
        public TernaryString MasqueACartouches { get; set; }
        public TernaryString EpiAntiArcCat { get; set; }
        public bool EpiAntiChoc { get; set; }
        public TernaryString HabitProtecteurEquipementDeProtection { get; set; }
        public bool EcranDeflecteur { get; set; }
        public bool SystemeDAdductionDAir { get; set; }
        public bool MaltDesEquipements { get; set; }
        public bool Rallonges { get; set; }
        public bool ApprobationPourEquipDeLevage { get; set; }
        public bool BarricadeRigide { get; set; }
        public TernaryString AutresE { get; set; }
        public TernaryString AlarmeDcs { get; set; }
        public bool EchelleSecurisee { get; set; }
        public bool EchafaudageApprouve { get; set; }
        public bool OutilDeLaiton { get; set; }
        public TernaryString OutilDeLaitonManel { get; set; }
        public TernaryString PerimetreDeSecurityEquipementDePrevention { get; set; }
        public bool PerimetreSecurite { get; set; }
        public bool Radio { get; set; }
        public bool Signaleur { get; set; }
        public string InstructionsSpeciales { get; set; }

        // Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

        public string MudsAnswerTextBox { get; set; }
        public string MudsQuestionlabel { get; set; }

         public bool SignatureOperateurSurLeTerrain { get; set; }
        public bool DetectionDesGazs { get; set; }
        public bool SignatureContremaitre { get; set; }
        public bool SignatureAutorise { get; set; }
        public bool NettoyageTransfertHorsSite { get; set; }
        public bool Soudage { get; set; }
        public bool Traitement { get; set; }
        public bool Cuissons { get; set; }
        public bool Perçage { get; set; }
        public bool Chaufferette { get; set; }
        public bool Meulage { get; set; }
        public bool Nettoyage { get; set; }
        public TernaryString AutresTravaux { get; set; }
        public bool TravauxDansZone { get; set; }
        public bool Combustibles { get; set; }
        public bool Ecran { get; set; }
        public bool Boyau { get; set; }
        public bool BoyauDe { get; set; }
        public bool Couverture { get; set; }
        public bool Extincteur { get; set; }
        public bool Bouche { get; set; }
        public bool RadioS { get; set; }
        public bool Surveillant { get; set; }
        public bool UtilisationMoteur { get; set; }
        public bool NettoyageAu { get; set; }
        public bool UtilisationElectronics { get; set; }
        public bool Radiographie { get; set; }
        public bool UtilisationOutlis { get; set; }
        public bool UtilisationEquipments { get; set; }
        public bool Demolition { get; set; }
        public TernaryString AutresInstruction { get; set; }


        //public TernaryString RemplirLeFormulaireDeCondition { get; set; }
        //public TernaryString InterrupteursEtVannesCadenasses { get; set; }
        //public TernaryString Appareil { get; set; }
        //public TernaryString AutresRisques { get; set; }
        //public TernaryString ElectriciteVolt { get; set; }
        //public TernaryString Gants { get; set; }
        //public TernaryString EpiAntiArcCat { get; set; }
        //public TernaryString AlarmeDcs { get; set; }
        //public TernaryString AutresE { get; set; }
        //public TernaryString MasqueACartouches { get; set; }

        //public bool Autres { get; set; }
        //public bool AnalyseCritiqueDeLaTache { get; set; }
        //public bool Depressurises { get; set; }
        //public bool Vides { get; set; }
        //public bool ContournementDesGda { get; set; }
        //public bool Rinces { get; set; }
        //public bool NettoyesLaVapeur { get; set; }
        //public bool Purges { get; set; }
        //public bool Ventiles { get; set; }
        //public bool Aeres { get; set; }
        //public bool VerrouillagesParTravailleurs { get; set; }
        //public bool SourcesDesenergisees { get; set; }
        //public bool DepartsLocauxTestes { get; set; }
        //public bool ConduitesDesaccouplees { get; set; }
        //public bool ObturateursInstallees { get; set; }
        //public bool PvciSuncorEffectuee { get; set; }
        //public bool PvciEntExtEffectuee { get; set; }
        //public bool Amiante { get; set; }
        //public bool AcideSulfurique { get; set; }
        //public bool Azote { get; set; }
        //public bool Caustique { get; set; }
        //public bool DioxydeDeSoufre { get; set; }
        //public bool Sbs { get; set; }
        //public bool Soufre { get; set; }
        //public bool EquipementsNonRinces { get; set; }
        //public bool Hydrocarbures { get; set; }
        //public bool HydrogeneSulfure { get; set; }
        //public bool MonoxydeCarbone { get; set; }
        //public bool Reflux { get; set; }
        //public bool ProduitsVolatilsUtilises { get; set; }
        //public bool Bacteries { get; set; }
        //public bool InterferencesEntreTravaux { get; set; }
        //public bool PiecesEnRotation { get; set; }
        //public bool IncendieExplosion { get; set; }
        //public bool ContrainteThermique { get; set; }
        //public bool Radiations { get; set; }
        //public bool Silice { get; set; }
        //public bool Vanadium { get; set; }
        //public bool AsphyxieIntoxication { get; set; }
        //public bool TravailEnHauteur6EtPlus { get; set; }
        //public bool Electrisation { get; set; }
        //public bool LunettesMonocoques { get; set; }
        //public bool Visiere { get; set; }
        //public bool ProtectionAuditive { get; set; }
        //public bool ManteauAntiEclaboussure { get; set; }
        //public bool CagouleIgnifuge { get; set; }
        //public bool Harnais2LiensDeRetenue { get; set; }
        //public bool MasqueAntiPoussiere { get; set; }
        //public bool FiltresParticules { get; set; }
        //public bool HabitCompletAntiEclaboussure { get; set; }
        //public bool HabitCouvreToutJetable { get; set; }
        //public bool EpiAntiChoc { get; set; }
        //public bool SystemeDAdductionDAir { get; set; }
        //public bool EcranDeflecteur { get; set; }
        //public bool MaltDesEquipements { get; set; }
        //public bool Rallonges { get; set; }
        //public bool ApprobationPourEquipDeLevage { get; set; }
        //public bool BarricadeRigide { get; set; }
        //public bool EchelleSecurisee { get; set; }
        //public bool EchafaudageApprouve { get; set; }
        //public bool OutilDeLaiton { get; set; }
        //public bool PerimetreSecurite { get; set; }
        //public bool Radio { get; set; }
        //public bool Signaleur { get; set; }

        //public string InstructionsSpeciales { get; set; }
        //public bool SignatureOperateurSurLeTerrain { get; set; }
        //public bool DetectionDesGazs { get; set; }
        //public bool SignatureContremaitre { get; set; }
        //public bool SignatureAutorise { get; set; }
        //public bool NettoyageTransfertHorsSite { get; set; }
        public string DocumentLinks { get; set; }
        public string RequestedByGroup { get; set; }

        public string RequestedByGroupText { get; set; }

        public string GasTestElements { get; set; }

        public Time FirstResultTime { get; set; }
        public Time SecondResultTime { get; set; }
        public Time ThirdResultTime { get; set; }
        public Time FourthResultTime { get; set; }
        //Added by ppanigrahi
        public string WorkPermitCloseComments { get; set; }

        public long WorkpermitClosedById { get; set; }
       public User WorkpermitClosedBy { get; set; }
        public long ActionItemCloseById { get; set; }
        public User ActionItemCloseBy { get; set; }
        public DateTime? PermitCloseDateTime { get; set; }
        public DateTime? ActionItemCloseDateTime { get; set; }
        public bool? ActionItemCheckboxchecked { get; set; }

    }
}