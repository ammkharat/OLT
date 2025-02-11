using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public enum TemplateStateMuds
    {
        Default = 0, // Meaning: visible and unchecked
        Checked = 1, // Meaning: visible and checked
        Invisible = 2 // Meaning: not visible
    }

    [Serializable]
    public class WorkPermitMudsTemplate : DomainObject
    {
        public static WorkPermitMudsTemplate NULL = CreateNullTemplate();

        // Pass TemplateNumber = 0 only when a new template is being inserted. 
        // This is used by the Insert stored proc to trigger it to auto generate a new TemplateNumber.
        public static int? NET_NEW_TEMPLATE = 0;
        private bool isActive;
        private bool isDeleted;
        private string name;
        private int? templateNumber;
        private long id;
        private WorkPermitMudsType workPermitType;

        public WorkPermitMudsTemplate()
        {
        }

        public WorkPermitMudsTemplate(long id, string name, WorkPermitMudsType workPermitType, bool isActive,
            bool isDeleted, int? templateNumber)
        {
            this.name = name;
            this.workPermitType = workPermitType;
            this.isActive = isActive;
            this.isDeleted = isDeleted;
            this.templateNumber = templateNumber;
            this.id = id;
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

        public WorkPermitMudsType WorkPermitType
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

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public TemplateStateMuds RemplirLeFormulaireDeCondition { get; set; }
        public String RemplirLeFormulaireDeConditionValue { get; set; }
        public TemplateStateMuds AnalyseCritiqueDeLaTache { get; set; }
        public TemplateStateMuds Depressurises { get; set; }
        public TemplateStateMuds Vides { get; set; }
        public TemplateStateMuds ContournementDesGda { get; set; }
        public TemplateStateMuds Rinces { get; set; }
        public TemplateStateMuds NettoyesLaVapeur { get; set; }
        public TemplateStateMuds Purges { get; set; }
        public TemplateStateMuds Ventiles { get; set; }
        public TemplateStateMuds Aeres { get; set; }
        public TemplateStateMuds Energies { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
        
        public TemplateStateMuds Autres { get; set; }
        public TemplateStateMuds InterrupteursEtVannesCadenasses { get; set; }
        public String InterrupteursEtVannesCadenassesValue { get; set; }
        public TemplateStateMuds VerrouillagesParTravailleurs { get; set; }
        public TemplateStateMuds SourcesDesenergisees { get; set; }
        public TemplateStateMuds DepartsLocauxTestes { get; set; }
        public TemplateStateMuds ConduitesDesaccouplees { get; set; }
        public TemplateStateMuds ObturateursInstallees { get; set; }
        public TemplateStateMuds PvciSuncorEffectuee { get; set; }
        public TemplateStateMuds PvciEntExtEffectuee { get; set; }
        public TemplateStateMuds Amiante { get; set; }
        public TemplateStateMuds AcideSulfurique { get; set; }
        public TemplateStateMuds Azote { get; set; }
        public TemplateStateMuds Caustique { get; set; }
        public TemplateStateMuds DioxydeDeSoufre { get; set; }
        public TemplateStateMuds Sbs { get; set; }
        public TemplateStateMuds Soufre { get; set; }
        public TemplateStateMuds EquipementsNonRinces { get; set; }
        public TemplateStateMuds Hydrocarbures { get; set; }
        public TemplateStateMuds HydrogeneSulfure { get; set; }
        public TemplateStateMuds MonoxydeCarbone { get; set; }
        public TemplateStateMuds Reflux { get; set; }
        public TemplateStateMuds ProduitsVolatilsUtilises { get; set; }
        public TemplateStateMuds Bacteries { get; set; }
        public TemplateStateMuds Appareil { get; set; }
        public String AppareilValue { get; set; }
        public TemplateStateMuds InterferencesEntreTravaux { get; set; }
        public TemplateStateMuds PiecesEnRotation { get; set; }
        public TemplateStateMuds IncendieExplosion { get; set; }
        public TemplateStateMuds ContrainteThermique { get; set; }
        public TemplateStateMuds Radiations { get; set; }
        public TemplateStateMuds Silice { get; set; }
        public TemplateStateMuds Vanadium { get; set; }
        public TemplateStateMuds AsphyxieIntoxication { get; set; }
        //public TemplateStateMuds AutresRisques { get; set; }
        //public String AutresRisquesValue { get; set; }
        public TemplateStateMuds ElectriciteVolt { get; set; }
        public String ElectriciteVoltValue { get; set; }
        public TemplateStateMuds OutillageElectrique { get; set; }
        public TemplateStateMuds TravailEnHauteur6EtPlus { get; set; }
        public TemplateStateMuds VapeurCondensat { get; set; } // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

        public TemplateStateMuds FeSValue { get; set; } 
        

        public TemplateStateMuds Electrisation { get; set; }
        public TemplateStateMuds LunettesMonocoques { get; set; }
        public TemplateStateMuds Visiere { get; set; }
        public TemplateStateMuds ProtectionAuditive { get; set; }
        public TemplateStateMuds ManteauAntiEclaboussure { get; set; }
        public TemplateStateMuds CagouleIgnifuge { get; set; }
        public TemplateStateMuds Harnais2LiensDeRetenue { get; set; }
        public TemplateStateMuds MasqueAntiPoussiere { get; set; }
        public TemplateStateMuds FiltresParticules { get; set; }
        public TemplateStateMuds Gants { get; set; }
        public String GantsValue { get; set; }
        public TemplateStateMuds MasqueACartouches { get; set; }
        public String MasqueACartouchesValue { get; set; }
        public TemplateStateMuds EpiAntiArcCat { get; set; }
        public String EpiAntiArcCatValue { get; set; }
        public TemplateStateMuds HabitCompletAntiEclaboussure { get; set; }
        public TemplateStateMuds HabitCouvreToutJetable { get; set; }
        public TemplateStateMuds EpiAntiChoc { get; set; }
        public TemplateStateMuds SystemeDAdductionDAir { get; set; }
        public TemplateStateMuds EcranDeflecteur { get; set; }
        public TemplateStateMuds MaltDesEquipements { get; set; }
        public TemplateStateMuds Rallonges { get; set; }
        public TemplateStateMuds ApprobationPourEquipDeLevage { get; set; }
        public TemplateStateMuds BarricadeRigide { get; set; }
        public TemplateStateMuds AutresE { get; set; }
        public String AutresEValue { get; set; }
        public TemplateStateMuds AlarmeDcs { get; set; }
        public String AlarmeDcsValue { get; set; }
        public TemplateStateMuds EchelleSecurisee { get; set; }
        public TemplateStateMuds EchafaudageApprouve { get; set; }
        public TemplateStateMuds OutilDeLaiton { get; set; }
        public TemplateStateMuds PerimetreSecurite { get; set; }
        public TemplateStateMuds Radio { get; set; }
        public TemplateStateMuds Signaleur { get; set; }

        public TemplateStateMuds OutilDeLaitonPrevention { get; set; }

        public string InstructionsSpeciales { get; set; }
        public TemplateStateMuds SignatureOperateurSurLeTerrain { get; set; }
        public TemplateStateMuds DetectionDesGazs { get; set; }
        public TemplateStateMuds SignatureContremaitre { get; set; }
        public TemplateStateMuds SignatureAutorise { get; set; }
        public TemplateStateMuds NettoyageTransfertHorsSite { get; set; }

        public TemplateStateMuds ProcedureEntretien { get; set; }
        public String ProcedureEntretienValue { get; set; }
        public TemplateStateMuds EtiquettObturateur { get; set; }
        public String EtiquettObturateurValue { get; set; }
        public TemplateStateMuds MasqueSoudeur { get; set; }

        public TemplateStateMuds Soudage { get; set; }
        public TemplateStateMuds Traitement { get; set; }
        public TemplateStateMuds Cuissons { get; set; }
        public TemplateStateMuds Per�age { get; set; }
        public TemplateStateMuds Chaufferette { get; set; }
        public TemplateStateMuds Meulage { get; set; }
        public TemplateStateMuds Nettoyage { get; set; }
        public TemplateStateMuds TravauxDansZone { get; set; }
        public TemplateStateMuds Combustibles { get; set; }
        public TemplateStateMuds Ecran { get; set; }
        public TemplateStateMuds Boyau { get; set; }
        public TemplateStateMuds BoyauDe { get; set; }
        public TemplateStateMuds Couverture { get; set; }
        public TemplateStateMuds Extincteur { get; set; }
        public TemplateStateMuds Bouche { get; set; }
        public TemplateStateMuds RadioS { get; set; }
        public TemplateStateMuds Surveillant { get; set; }
        public TemplateStateMuds UtilisationMoteur { get; set; }
        public TemplateStateMuds NettoyageAu { get; set; }
        public TemplateStateMuds UtilisationElectronics { get; set; }
        public TemplateStateMuds Radiographie { get; set; }
        public TemplateStateMuds UtilisationOutlis { get; set; }
        public TemplateStateMuds UtilisationEquipments { get; set; }
        public TemplateStateMuds Demolition { get; set; }
        public TemplateStateMuds MhAutres { get; set; }
        public TemplateStateMuds Masque { get; set; }

        public TemplateStateMuds EffondrementEnsevelissement { get; set; } 

        public TemplateStateMuds AutresConditions { get; set; }
        public string AutresConditionsValue { get; set; }

        public TemplateStateMuds AutresRisques { get; set; }
        public string AutresRisquesValue { get; set; }

        public TemplateStateMuds ElectronicVoltRisques { get; set; }
        public string ElectronicVoltRisquesValue { get; set; }

        public TemplateStateMuds GantsEquipementDeProtection { get; set; }
        public string GantsEquipementDeProtectionValue { get; set; }

        public TemplateStateMuds HabitProtecteurEquipementDeProtection { get; set; }
        public string HabitProtecteurEquipementDeProtectionValue { get; set; }

        public TemplateStateMuds EpiAntiArcCatProtecteurEquipementDeProtection { get; set; }
        public string EpiAntiArcCatProtecteurEquipementDeProtectionValue { get; set; }

        public TemplateStateMuds AppareilProtecteurEquipementDeProtection { get; set; }
        public string AppareilProtecteurEquipementDeProtectionValue { get; set; }

        public TemplateStateMuds AutresEquipementDePrevention { get; set; }
        public string AutresEquipementDePreventionValue { get; set; }

        public TemplateStateMuds OutilManuelEquipementDePrevention { get; set; }
        public string OutilManuelEquipementDePreventionValue { get; set; }

        public TemplateStateMuds PerimetreDeSecurityEquipementDePrevention { get; set; }
        public string PerimetreDeSecurityEquipementDePreventionValue { get; set; }

        public TemplateStateMuds AppareilEquipementDePrevention { get; set; }
        public string AppareilEquipementDePreventionValue { get; set; }

        public TemplateStateMuds AutresTravaux { get; set; }
        public string AutresTravauxValue { get; set; }

        public TemplateStateMuds AutresInstruction { get; set; }
        public string AutresInstructionValue { get; set; }

        public TemplateStateMuds OutilDeLaitonManel { get; set; }
        public string OutilDeLaitonManelValue { get; set; }


        private static WorkPermitMudsTemplate CreateNullTemplate()
        {
            var template = new WorkPermitMudsTemplate(0,string.Empty, WorkPermitMudsType.NULL, true, false, null);

            template.RemplirLeFormulaireDeCondition = TemplateStateMuds.Default;
            template.AnalyseCritiqueDeLaTache = TemplateStateMuds.Default;
            template.Depressurises = TemplateStateMuds.Default;
            template.Vides = TemplateStateMuds.Default;
            template.ContournementDesGda = TemplateStateMuds.Default;
            template.Rinces = TemplateStateMuds.Default;
            template.NettoyesLaVapeur = TemplateStateMuds.Default;
            template.Purges = TemplateStateMuds.Default;
            template.Ventiles = TemplateStateMuds.Default;
            template.Aeres = TemplateStateMuds.Default;
            template.Energies = TemplateStateMuds.Default;
            
            template.ProcedureEntretien = TemplateStateMuds.Default;
            template.AutresConditions = TemplateStateMuds.Default;
            template.InterrupteursEtVannesCadenasses = TemplateStateMuds.Default;
            template.VerrouillagesParTravailleurs = TemplateStateMuds.Default;
            template.SourcesDesenergisees = TemplateStateMuds.Default;
            template.DepartsLocauxTestes = TemplateStateMuds.Default;
            template.ConduitesDesaccouplees = TemplateStateMuds.Default;
            template.ObturateursInstallees = TemplateStateMuds.Default;
            template.EtiquettObturateur = TemplateStateMuds.Default;
            template.PvciSuncorEffectuee = TemplateStateMuds.Default;
            template.PvciEntExtEffectuee = TemplateStateMuds.Default;
            template.Amiante = TemplateStateMuds.Default;
            template.AcideSulfurique = TemplateStateMuds.Default;
            template.Azote = TemplateStateMuds.Default;
            template.Caustique = TemplateStateMuds.Default;
            template.DioxydeDeSoufre = TemplateStateMuds.Default;
            template.Sbs = TemplateStateMuds.Default;
            template.Soufre = TemplateStateMuds.Default;
            template.EquipementsNonRinces = TemplateStateMuds.Default;
            template.Hydrocarbures = TemplateStateMuds.Default;
            template.HydrogeneSulfure = TemplateStateMuds.Default;
            template.MonoxydeCarbone = TemplateStateMuds.Default;
            template.Reflux = TemplateStateMuds.Default;
            template.ProduitsVolatilsUtilises = TemplateStateMuds.Default;
            template.Bacteries = TemplateStateMuds.Default;
            template.Appareil = TemplateStateMuds.Default;
            template.InterferencesEntreTravaux = TemplateStateMuds.Default;
            template.PiecesEnRotation = TemplateStateMuds.Default;
            template.IncendieExplosion = TemplateStateMuds.Default;
            template.ContrainteThermique = TemplateStateMuds.Default;
            template.Radiations = TemplateStateMuds.Default;
            template.Silice = TemplateStateMuds.Default;
            template.Vanadium = TemplateStateMuds.Default;
            template.AsphyxieIntoxication = TemplateStateMuds.Default;
            template.AutresRisques = TemplateStateMuds.Default;
            template.ElectriciteVolt = TemplateStateMuds.Default;
            template.OutillageElectrique = TemplateStateMuds.Default;
            template.TravailEnHauteur6EtPlus = TemplateStateMuds.Default;
            template.VapeurCondensat = TemplateStateMuds.Default; // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            template.FeSValue = TemplateStateMuds.Default; 
            
            template.Electrisation = TemplateStateMuds.Default;
            template.LunettesMonocoques = TemplateStateMuds.Default;
            template.Visiere = TemplateStateMuds.Default;
            template.ProtectionAuditive = TemplateStateMuds.Checked;
            template.CagouleIgnifuge = TemplateStateMuds.Default;
            template.Harnais2LiensDeRetenue = TemplateStateMuds.Default;
            template.Gants = TemplateStateMuds.Default;
            template.MasqueACartouches = TemplateStateMuds.Default;
            template.EpiAntiArcCat = TemplateStateMuds.Default;
            template.EpiAntiChoc = TemplateStateMuds.Default;
            template.HabitProtecteurEquipementDeProtection = TemplateStateMuds.Default;
            template.EcranDeflecteur = TemplateStateMuds.Default;
            template.MaltDesEquipements = TemplateStateMuds.Default;
            template.Rallonges = TemplateStateMuds.Default;
            template.ApprobationPourEquipDeLevage = TemplateStateMuds.Default;
            template.BarricadeRigide = TemplateStateMuds.Default;
            template.AutresE = TemplateStateMuds.Default;
            template.AlarmeDcs = TemplateStateMuds.Default;
            template.EchelleSecurisee = TemplateStateMuds.Default;
            template.EchafaudageApprouve = TemplateStateMuds.Default;
            template.OutilDeLaiton = TemplateStateMuds.Default;
            template.OutilDeLaitonManel = TemplateStateMuds.Default;
            template.PerimetreSecurite = TemplateStateMuds.Default;
            template.Radio = TemplateStateMuds.Default;
            template.Signaleur = TemplateStateMuds.Default;
            template.SignatureOperateurSurLeTerrain = TemplateStateMuds.Invisible;
            template.DetectionDesGazs = TemplateStateMuds.Invisible;
            template.SignatureContremaitre = TemplateStateMuds.Invisible;
            template.SignatureAutorise = TemplateStateMuds.Invisible;
            template.NettoyageTransfertHorsSite = TemplateStateMuds.Invisible;
            template.Soudage = TemplateStateMuds.Default;
            template.Traitement = TemplateStateMuds.Default;
            template.Cuissons = TemplateStateMuds.Default;
            template.Per�age = TemplateStateMuds.Default;
            template.Chaufferette = TemplateStateMuds.Default;
            template.Meulage = TemplateStateMuds.Default;
            template.Nettoyage = TemplateStateMuds.Default;
            template.AutresTravaux = TemplateStateMuds.Default;
            template.TravauxDansZone = TemplateStateMuds.Default;
            template.Combustibles = TemplateStateMuds.Default;
            template.Ecran = TemplateStateMuds.Default;
            template.Boyau = TemplateStateMuds.Default;
            template.BoyauDe = TemplateStateMuds.Default;
            template.Couverture = TemplateStateMuds.Default;
            template.Extincteur = TemplateStateMuds.Default;
            template.Bouche = TemplateStateMuds.Default;
            template.RadioS = TemplateStateMuds.Default;
            template.Surveillant = TemplateStateMuds.Default;
            template.UtilisationMoteur = TemplateStateMuds.Default;
            template.NettoyageAu = TemplateStateMuds.Default;
            template.UtilisationElectronics = TemplateStateMuds.Default;
            template.Radiographie = TemplateStateMuds.Default;
            template.UtilisationOutlis = TemplateStateMuds.Default;
            template.UtilisationEquipments = TemplateStateMuds.Default;
            template.Demolition = TemplateStateMuds.Default;
            template.AutresInstruction = TemplateStateMuds.Default;

            //template.AutresConditions = TemplateStateMuds.Default;
            //template.AutresRisques = TemplateStateMuds.Default;
            //template.ElectronicVoltRisques = TemplateStateMuds.Default;
            //template.GantsEquipementDeProtection = TemplateStateMuds.Default;
            //template.HabitProtecteurEquipementDeProtection = TemplateStateMuds.Default;
            //template.EpiAntiArcCatProtecteurEquipementDeProtection = TemplateStateMuds.Default;
            //template.AppareilProtecteurEquipementDeProtection = TemplateStateMuds.Default;
            //template.AutresEquipementDePrevention = TemplateStateMuds.Default;
            //template.OutilManuelEquipementDePrevention = TemplateStateMuds.Default;
            //template.PerimetreDeSecurityEquipementDePrevention = TemplateStateMuds.Default;
            //template.AppareilEquipementDePrevention = TemplateStateMuds.Default;
            //template.AutresTravaux = TemplateStateMuds.Default;

            //template.ProcedureEntretien = TemplateStateMuds.Default;
            //template.EtiquettObturateur = TemplateStateMuds.Default;
            //template.MasqueSoudeur = TemplateStateMuds.Default;

            return template;
        }

        public static int CompareByTemplateNumber(WorkPermitMudsTemplate x, WorkPermitMudsTemplate y)
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