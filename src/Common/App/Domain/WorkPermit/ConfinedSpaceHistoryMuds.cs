using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class ConfinedSpaceHistoryMuds : DomainObjectHistorySnapshot
    {
        public ConfinedSpaceHistoryMuds(long id, ConfinedSpaceStatusMuds confinedSpaceStatus, DateTime startDateTime,
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
            DateTime lastModifiedDateTime,
            bool sO2, bool nH3, bool acideSulfurique, bool cO, bool azote, bool reflux, bool naOH, bool sBS, bool soufre, bool amiante, bool bacteries, bool depressurise, bool rince,
            bool obture, bool nettoyes, bool purge, bool vide, bool dessins, bool detectionDeGaz, bool pSS, bool ventilationEn, bool ventilationForce, bool harnis
            ) : base(id, lastModifiedBy, lastModifiedDateTime)
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

        public ConfinedSpaceStatusMuds ConfinedSpaceStatus { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public long? ConfinedSpaceNumber { get; set; }
        public FunctionalLocation FunctionalLocation { get; private set; }

        public string InstructionsSpeciales { get; set; }

        #region Substances
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

    [Serializable]
    public class ConfinedSpaceMudsSignHistory : DomainObject, IHistorySnapshot
    {
        public string ConfinedSpaceId { get; set; }
        public string VERIFICATEUR { get; set; }
        public string VERIFICATEUR_BADGENUMBER { get; set; }
        public string VERIFICATEUR_SOURCE { get; set; }

        public string DETENTEUR_NAME { get; set; }
        public string DETENTEUR_BADGENUMBER { get; set; }
        public string DETENTEUR_SOURCE { get; set; }

        public string EMETTEUR_NAME { get; set; }
        public string EMETTEUR_BADGENUMBER { get; set; }
        public string EMETTEUR_SOURCE { get; set; }



        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string SiteId { get; set; }
        User _LastModifiedBy;
        DateTime _LastModifiedDate;
        public User LastModifiedBy { get { return _LastModifiedBy; } set { _LastModifiedBy = value; } }
        public DateTime LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set { _LastModifiedDate = value; }
        }


        public string FirstResult_Name
        {
            get;
            set;
        }

        public string FirstResult_Source
        {
            get;
            set;
        }



        public string SecondResult_Name
        {
            get;
            set;
        }

        public string SecondResult_Source
        {
            get;
            set;
        }



        public string ThirdResult_Name
        {
            get;
            set;
        }

        public string ThirdResult_Source
        {
            get;
            set;
        }





        public string FourthResult_Name
        {
            get;
            set;
        }

        public string FourthResult_Source
        {
            get;
            set;
        }


    }
}