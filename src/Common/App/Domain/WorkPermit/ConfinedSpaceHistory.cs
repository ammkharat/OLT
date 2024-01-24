using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class ConfinedSpaceHistory : DomainObjectHistorySnapshot
    {
        public ConfinedSpaceHistory(long id, ConfinedSpaceStatus confinedSpaceStatus, DateTime startDateTime,
            DateTime endDateTime, long? confinedSpaceNumber,
            FunctionalLocation functionalLocation, bool h2S, bool hydrocarbure, bool ammoniaque,
            TernaryString corrosif, TernaryString aromatique, TernaryString autresSubstances,
            bool obtureOuDebranche, bool depressuriseEtVidange, bool enPresenceDeGazInerte,
            bool purgeALaVapeur, TernaryString dessinsRequis, bool planDeSauvetage,
            bool cablesChauffantsMisHorsTension, bool interrupteursElectriquesVerrouilles,
            bool purgeParUnGazInerte, bool rinceAlEau, bool ventilationMecanique,
            bool bouchesDegoutProtegees, bool possibiliteDeSulfureDeFer, bool aereVentile,
            TernaryString autreConditions, bool ventilationNaturelle, string instructionsSpeciales,
            User lastModifiedBy,
            DateTime lastModifiedDateTime) : base(id, lastModifiedBy, lastModifiedDateTime)
        {
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
        }

        public ConfinedSpaceStatus ConfinedSpaceStatus { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long? ConfinedSpaceNumber { get; set; }
        public FunctionalLocation FunctionalLocation { get; private set; }

        public string InstructionsSpeciales { get; set; }

        #region Substances

        public bool H2S { get; set; }
        public bool Hydrocarbure { get; set; }
        public bool Ammoniaque { get; set; }
        public TernaryString Corrosif { get; set; }
        public TernaryString Aromatique { get; set; }
        public TernaryString AutresSubstances { get; set; }

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
    }
}