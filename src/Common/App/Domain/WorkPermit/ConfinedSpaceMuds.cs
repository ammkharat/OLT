using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class ConfinedSpaceMuds : ModifiableDomainObject, IFunctionalLocationRelevant
    {
        public ConfinedSpaceMuds(long? id, ConfinedSpaceStatusMuds confinedSpaceStatus, DateTime startDateTime,
            DateTime endDateTime, long? confinedSpaceNumber,
            FunctionalLocation functionalLocation, bool h2S, bool hydrocarbure, bool ammoniaque,
            TernaryString corrosif, TernaryString aromatique, TernaryString autresSubstances,
            bool obtureOuDebranche, bool depressuriseEtVidange, bool enPresenceDeGazInerte,
            bool purgeALaVapeur, TernaryString dessinsRequis, bool planDeSauvetage,
            bool cablesChauffantsMisHorsTension, bool interrupteursElectriquesVerrouilles,
            bool purgeParUnGazInerte, bool rinceAlEau, bool ventilationMecanique,
            bool bouchesDegoutProtegees, bool possibiliteDeSulfureDeFer, bool aereVentile,
            TernaryString autreConditions, bool ventilationNaturelle, string instructionsSpeciales,
            User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            bool sO2, bool nH3,bool acideSulfurique ,bool cO ,bool azote ,bool reflux ,bool naOH ,bool sBS ,bool soufre ,bool amiante ,bool bacteries ,bool depressurise ,bool rince ,
            bool obture ,bool nettoyes ,bool purge ,bool vide ,bool dessins  ,bool detectionDeGaz ,bool pSS ,bool ventilationEn ,bool ventilationForce ,bool harnis )
        {
            Id = id;
            ConfinedSpaceStatus = confinedSpaceStatus;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ConfinedSpaceNumber = confinedSpaceNumber;
            FunctionalLocation = functionalLocation;
            H2S = h2S;
            Hydrocarbure = hydrocarbure;
            Ammoniaque = ammoniaque;
            Corrosif = corrosif;
            Aromatique = aromatique;
            AutresSubstances = autresSubstances;
            ObtureOuDebranche = obtureOuDebranche;
            DepressuriseEtVidange = depressuriseEtVidange;
            EnPresenceDeGazInerte = enPresenceDeGazInerte;
            PurgeALaVapeur = purgeALaVapeur;
            DessinsRequis = dessinsRequis;
            PlanDeSauvetage = planDeSauvetage;
            CablesChauffantsMisHorsTension = cablesChauffantsMisHorsTension;
            InterrupteursElectriquesVerrouilles = interrupteursElectriquesVerrouilles;
            PurgeParUnGazInerte = purgeParUnGazInerte;
            RinceAlEau = rinceAlEau;
            VentilationMecanique = ventilationMecanique;
            BouchesDegoutProtegees = bouchesDegoutProtegees;
            PossibiliteDeSulfureDeFer = possibiliteDeSulfureDeFer;
            AereVentile = aereVentile;
            AutreConditions = autreConditions;
            VentilationNaturelle = ventilationNaturelle;
            InstructionsSpeciales = instructionsSpeciales;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;

            SO2 = sO2;
            NH3 = nH3;
            AcideSulfurique = acideSulfurique;
            CO = cO;
            Azote = azote;
            Reflux = reflux;
            NaOH = naOH;
            SBS = sBS;
            Soufre = soufre;
            Amiante = amiante;
            Bacteries = bacteries;
            Depressurise = depressurise;
            Rince = rince;
            Obture = obture;
            Nettoyes = nettoyes;
            Purge = purge;
            Vide = vide;
            Dessins = dessins;
            DetectionDeGaz = detectionDeGaz;
            PSS = pSS;
            VentilationEn = ventilationEn;
            VentilationForce = ventilationForce;
            Harnis = harnis;
        }
        //Added by ppanigrahi
        public ConfinedSpaceMuds(long? id, ConfinedSpaceStatusMuds confinedSpaceStatus, DateTime startDateTime,
            DateTime endDateTime, long? confinedSpaceNumber,
            FunctionalLocation functionalLocation, bool h2S, bool hydrocarbure, bool ammoniaque,
            TernaryString corrosif, TernaryString aromatique, TernaryString autresSubstances,
            bool obtureOuDebranche, bool depressuriseEtVidange, bool enPresenceDeGazInerte,
            bool purgeALaVapeur, TernaryString dessinsRequis, bool planDeSauvetage,
            bool cablesChauffantsMisHorsTension, bool interrupteursElectriquesVerrouilles,
            bool purgeParUnGazInerte, bool rinceAlEau, bool ventilationMecanique,
            bool bouchesDegoutProtegees, bool possibiliteDeSulfureDeFer, bool aereVentile,
            TernaryString autreConditions, bool ventilationNaturelle, string instructionsSpeciales,
            User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            bool sO2, bool nH3, bool acideSulfurique, bool cO, bool azote, bool reflux, bool naOH, bool sBS, bool soufre, bool amiante, bool bacteries, bool depressurise, bool rince,
            bool obture, bool nettoyes, bool purge, bool vide, bool dessins, bool detectionDeGaz, bool pSS, bool ventilationEn, bool ventilationForce, bool harnis, WorkPermitGasTests gastests)
        {
            Id = id;
            ConfinedSpaceStatus = confinedSpaceStatus;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ConfinedSpaceNumber = confinedSpaceNumber;
            FunctionalLocation = functionalLocation;
            H2S = h2S;
            Hydrocarbure = hydrocarbure;
            Ammoniaque = ammoniaque;
            Corrosif = corrosif;
            Aromatique = aromatique;
            AutresSubstances = autresSubstances;
            ObtureOuDebranche = obtureOuDebranche;
            DepressuriseEtVidange = depressuriseEtVidange;
            EnPresenceDeGazInerte = enPresenceDeGazInerte;
            PurgeALaVapeur = purgeALaVapeur;
            DessinsRequis = dessinsRequis;
            PlanDeSauvetage = planDeSauvetage;
            CablesChauffantsMisHorsTension = cablesChauffantsMisHorsTension;
            InterrupteursElectriquesVerrouilles = interrupteursElectriquesVerrouilles;
            PurgeParUnGazInerte = purgeParUnGazInerte;
            RinceAlEau = rinceAlEau;
            VentilationMecanique = ventilationMecanique;
            BouchesDegoutProtegees = bouchesDegoutProtegees;
            PossibiliteDeSulfureDeFer = possibiliteDeSulfureDeFer;
            AereVentile = aereVentile;
            AutreConditions = autreConditions;
            VentilationNaturelle = ventilationNaturelle;
            InstructionsSpeciales = instructionsSpeciales;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;

            SO2 = sO2;
            NH3 = nH3;
            AcideSulfurique = acideSulfurique;
            CO = cO;
            Azote = azote;
            Reflux = reflux;
            NaOH = naOH;
            SBS = sBS;
            Soufre = soufre;
            Amiante = amiante;
            Bacteries = bacteries;
            Depressurise = depressurise;
            Rince = rince;
            Obture = obture;
            Nettoyes = nettoyes;
            Purge = purge;
            Vide = vide;
            Dessins = dessins;
            DetectionDeGaz = detectionDeGaz;
            PSS = pSS;
            VentilationEn = ventilationEn;
            VentilationForce = ventilationForce;
            Harnis = harnis;
            GasTests = gastests;
        }


        public ConfinedSpaceStatusMuds ConfinedSpaceStatus { get; set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long? ConfinedSpaceNumber { get; set; }
        public FunctionalLocation FunctionalLocation { get; private set; }

        public string InstructionsSpeciales { get; set; }

        public User CreatedBy { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        
        public WorkPermitGasTests GasTests { get; set; }  //Added by ppanigrahi

        #region Substances

        public bool H2S { get; set; }
        public bool Hydrocarbure { get; set; }
        public bool Ammoniaque { get; set; }
        public TernaryString Corrosif { get; set; }
        public TernaryString Aromatique { get; set; }
        public TernaryString AutresSubstances { get; set; }

        public bool SO2 { get; set; }
        public bool NH3 { get; set; }
        public bool AcideSulfurique { get; set; }
        public bool CO { get; set; }
        public bool Azote { get; set; }
        public bool Reflux { get; set; }
        public bool NaOH { get; set; }
        public bool SBS { get; set; }
        public bool Soufre { get; set; }
        public bool Amiante { get; set; }
        public bool Bacteries { get; set; }
        public bool Depressurise { get; set; }
        public bool Rince { get; set; }
        public bool Obture { get; set; }
        public bool Nettoyes { get; set; }
        public bool Purge { get; set; }
        public bool Vide { get; set; }
        public bool Dessins { get; set; }
        public bool DetectionDeGaz { get; set; }
        public bool PSS { get; set; }
        public bool VentilationEn { get; set; }
        public bool VentilationForce { get; set; }
        public bool Harnis { get; set; }
        

        #endregion

        #region Conditions

        public bool ObtureOuDebranche { get; set; }
        public bool DepressuriseEtVidange { get; set; }
        public bool EnPresenceDeGazInerte { get; set; }
        public bool PurgeALaVapeur { get; set; }
        public TernaryString DessinsRequis { get; set; }
        public bool PlanDeSauvetage { get; set; }

        public bool CablesChauffantsMisHorsTension { get; set; }
        public bool InterrupteursElectriquesVerrouilles { get; set; }
        public bool PurgeParUnGazInerte { get; set; }
        public bool RinceAlEau { get; set; }
        public bool VentilationMecanique { get; set; }

        public bool BouchesDegoutProtegees { get; set; }
        public bool PossibiliteDeSulfureDeFer { get; set; }
        public bool AereVentile { get; set; }
        public TernaryString AutreConditions { get; set; }
        public bool VentilationNaturelle { get; set; }

        #endregion

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies,
            List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,
            SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public ConfinedSpaceHistoryMuds TakeSnapshot()
        {
            return new ConfinedSpaceHistoryMuds(IdValue, ConfinedSpaceStatus, StartDateTime, EndDateTime,
                ConfinedSpaceNumber,
                FunctionalLocation, H2S, Hydrocarbure,
                Ammoniaque, Corrosif, Aromatique, AutresSubstances, ObtureOuDebranche,
                DepressuriseEtVidange, EnPresenceDeGazInerte, PurgeALaVapeur, DessinsRequis,
                PlanDeSauvetage, CablesChauffantsMisHorsTension,
                InterrupteursElectriquesVerrouilles, PurgeParUnGazInerte, RinceAlEau,
                VentilationMecanique, BouchesDegoutProtegees,
                PossibiliteDeSulfureDeFer, AereVentile, AutreConditions,
                VentilationNaturelle, InstructionsSpeciales, LastModifiedBy,
                LastModifiedDateTime,
                SO2 ,NH3 ,AcideSulfurique ,CO ,Azote ,Reflux ,NaOH ,SBS ,Soufre ,Amiante ,Bacteries ,Depressurise ,Rince ,Obture ,Nettoyes ,Purge ,Vide ,Dessins  
                ,DetectionDeGaz ,PSS ,VentilationEn ,VentilationForce ,Harnis);}

        public ConfinedSpaceMuds CreateCopy()
        {
            return new ConfinedSpaceMuds(null, ConfinedSpaceStatusMuds.Pending, StartDateTime, EndDateTime, null,
                FunctionalLocation, H2S, Hydrocarbure,
                Ammoniaque, Corrosif, Aromatique, AutresSubstances, ObtureOuDebranche,
                DepressuriseEtVidange, EnPresenceDeGazInerte, PurgeALaVapeur, DessinsRequis,
                PlanDeSauvetage, CablesChauffantsMisHorsTension,
                InterrupteursElectriquesVerrouilles, PurgeParUnGazInerte, RinceAlEau,
                VentilationMecanique, BouchesDegoutProtegees,
                PossibiliteDeSulfureDeFer, AereVentile, AutreConditions,
                VentilationNaturelle, InstructionsSpeciales, null, CreatedDateTime, null, CreatedDateTime,
                SO2 ,NH3 ,AcideSulfurique ,CO ,Azote ,Reflux ,NaOH ,SBS ,Soufre ,Amiante ,Bacteries ,Depressurise ,Rince ,Obture ,Nettoyes ,Purge 
                ,Vide ,Dessins  ,DetectionDeGaz ,PSS ,VentilationEn ,VentilationForce ,Harnis,GasTests);
        }
    }
}