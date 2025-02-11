using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ConfinedSpaceMudsHistoryDao : AbstractManagedDao, IConfinedSpaceMudsHistoryDao
    {
        private const string QUERY_BY_ID = "QueryConfinedSpaceMudsHistoriesById";
        private const string INSERT = "InsertConfinedSpaceMudsHistory";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public ConfinedSpaceMudsHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<ConfinedSpaceHistoryMuds> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<ConfinedSpaceHistoryMuds>(PopulateInstance, QUERY_BY_ID);
        }

        private ConfinedSpaceHistoryMuds PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int status = reader.Get<int>("ConfinedSpaceStatus");
            ConfinedSpaceStatusMuds confinedSpaceStatus = ConfinedSpaceStatusMuds.Get(status);
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            long confinedSpaceNumber = reader.Get<long>("ConfinedSpaceNumber");
            long flocId = reader.Get<long>("FunctionalLocationId");

            bool h2S = reader.Get<bool>("H2S");
            bool hydrocarbure = reader.Get<bool>("Hydrocarbure");
            bool ammoniaque = reader.Get<bool>("Ammoniaque");
            TernaryString corrosif = reader.GetTernaryString("Corrosif");
            TernaryString aromatique = reader.GetTernaryString("Aromatique");
            TernaryString autresSubstances = reader.GetTernaryString("AutresSubstances");

            bool obtureOuDebranche = reader.Get<bool>("ObtureOuDebranche");
            bool depressuriseEtVidange = reader.Get<bool>("DepressuriseEtVidange");
            bool enPresenceDeGazInerte = reader.Get<bool>("EnPresenceDeGazInerte");
            bool purgeALaVapeur = reader.Get<bool>("PurgeALaVapeur");
            TernaryString dessinsRequis = reader.GetTernaryString("DessinsRequis");
            bool planDeSauvetage = reader.Get<bool>("PlanDeSauvetage");
            bool cablesChauffantsMisHorsTension = reader.Get<bool>("CablesChauffantsMisHorsTension");
            bool interrupteursElectriquesVerrouilles = reader.Get<bool>("InterrupteursElectriquesVerrouilles");
            bool purgeParUnGazInerte = reader.Get<bool>("PurgeParUnGazInerte");
            bool rinceAlEau = reader.Get<bool>("RinceAlEau");
            bool ventilationMecanique = reader.Get<bool>("VentilationMecanique");
            bool bouchesDegoutProtegees = reader.Get<bool>("BouchesDegoutProtegees");
            bool possibiliteDeSulfureDeFer = reader.Get<bool>("PossibiliteDeSulfureDeFer");
            bool aereVentile = reader.Get<bool>("AereVentile");
            TernaryString autreConditions = reader.GetTernaryString("AutreConditions");
            bool ventilationNaturelle = reader.Get<bool>("VentilationNaturelle");

            string instructionsSpeciales = reader.Get<string>("InstructionsSpeciales");

            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            bool sO2 = reader.Get<bool>("SO2");
            bool nH3 = reader.Get<bool>("NH3");
            bool acideSulfurique = reader.Get<bool>("AcideSulfurique");
            bool cO = reader.Get<bool>("CO");
            bool azote = reader.Get<bool>("Azote");
            bool reflux = reader.Get<bool>("Reflux");
            bool naOH = reader.Get<bool>("NaOH");
            bool sBS = reader.Get<bool>("SBS");
            bool soufre = reader.Get<bool>("Soufre");
            bool amiante = reader.Get<bool>("Amiante");
            bool bacteries = reader.Get<bool>("Bacteries");
            bool depressurise = reader.Get<bool>("Depressurise");
            bool rince = reader.Get<bool>("Rince");
            bool obture = reader.Get<bool>("Obture");
            bool nettoyes = reader.Get<bool>("Nettoyes");
            bool purge = reader.Get<bool>("Purge");
            bool vide = reader.Get<bool>("Vide");
            bool dessins = reader.Get<bool>("Dessins");
            bool detectionDeGaz = reader.Get<bool>("DetectionDeGaz");
            bool pSS = reader.Get<bool>("PSS");
            bool ventilationEn = reader.Get<bool>("VentilationEn");
            bool ventilationForce = reader.Get<bool>("VentilationForce");
            bool harnis = reader.Get<bool>("Harnis");

            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(flocId);
            User lastModifiedBy = userDao.QueryById(lastModifiedByUserId);

            return new ConfinedSpaceHistoryMuds(
                id,
                confinedSpaceStatus,
                startDateTime,
                endDateTime,
                confinedSpaceNumber,
                functionalLocation,
                h2S,
                hydrocarbure,
                ammoniaque,
                corrosif,
                aromatique,
                autresSubstances,
                obtureOuDebranche,
                depressuriseEtVidange,
                enPresenceDeGazInerte,
                purgeALaVapeur,
                dessinsRequis,
                planDeSauvetage,
                cablesChauffantsMisHorsTension,
                interrupteursElectriquesVerrouilles,
                purgeParUnGazInerte,
                rinceAlEau,
                ventilationMecanique,
                bouchesDegoutProtegees,
                possibiliteDeSulfureDeFer,
                aereVentile,
                autreConditions,
                ventilationNaturelle,
                instructionsSpeciales,
                lastModifiedBy,
                lastModifiedDateTime,
                sO2, nH3, acideSulfurique, cO, azote, reflux, naOH, sBS, soufre, amiante, bacteries, depressurise, rince, obture, nettoyes, purge
                , vide, dessins, detectionDeGaz, pSS, ventilationEn, ventilationForce, harnis
                );
        }
        //Added by ppanigrahi
        public List<ConfinedSpaceMudsSignHistory> GetBySignId(string id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ConfinedSpaceId", id);
            // command.AddParameter("@SiteId", SiteId);
            return command.QueryForListResult<ConfinedSpaceMudsSignHistory>(PopulateConfinedSpaceSign, "GetConfinedSpaceMudsSignHistory");

        }
        public static ConfinedSpaceMudsSignHistory PopulateConfinedSpaceSign(SqlDataReader reader)
        {
            ConfinedSpaceMudsSignHistory objConfinedSpaceSign = new ConfinedSpaceMudsSignHistory();


            objConfinedSpaceSign.ConfinedSpaceId = reader.Get<string>("ConfinedSpaceId");

            objConfinedSpaceSign.VERIFICATEUR = Convert.ToString(reader.Get<string>("Verifier_FNAME")) + " " + Convert.ToString(reader.Get<string>("Verifier_LNAME"));

            objConfinedSpaceSign.VERIFICATEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("Verifier_BADGENUMBER"));

            objConfinedSpaceSign.VERIFICATEUR_SOURCE = Convert.ToString(reader.Get<string>("Verifier_SOURCE"));


            objConfinedSpaceSign.DETENTEUR_NAME = Convert.ToString(reader.Get<string>("DETENTEUR_FNAME")) + " " + Convert.ToString(reader.Get<string>("DETENTEUR_LNAME")); ;
            objConfinedSpaceSign.DETENTEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("DETENTEUR_BADGENUMBER"));
            objConfinedSpaceSign.DETENTEUR_SOURCE = Convert.ToString(reader.Get<string>("DETENTEUR_SOURCE"));


            objConfinedSpaceSign.EMETTEUR_NAME = Convert.ToString(reader.Get<string>("EMETTEUR_FNAME")) + " " + Convert.ToString(reader.Get<string>("EMETTEUR_LNAME"));
            objConfinedSpaceSign.EMETTEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("EMETTEUR_BADGENUMBER"));
            objConfinedSpaceSign.EMETTEUR_SOURCE = Convert.ToString(reader.Get<string>("EMETTEUR_SOURCE"));


            objConfinedSpaceSign.FirstResult_Name = Convert.ToString(reader.Get<string>("FirstNameFirstResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameFirstResult"));
            objConfinedSpaceSign.SecondResult_Name = Convert.ToString(reader.Get<string>("FirstNameSecondResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameSecondResult"));
            objConfinedSpaceSign.ThirdResult_Name = Convert.ToString(reader.Get<string>("FirstNameThirdResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameThirdResult"));
            objConfinedSpaceSign.FourthResult_Name = Convert.ToString(reader.Get<string>("FirstNameFourthResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameFourthResult"));

            objConfinedSpaceSign.FirstResult_Source = reader.Get<string>("SourceFirstResult");


            objConfinedSpaceSign.SecondResult_Source = reader.Get<string>("SourceSecondResult");


            objConfinedSpaceSign.ThirdResult_Source = reader.Get<string>("SourceThirdResult");

            objConfinedSpaceSign.FourthResult_Source = reader.Get<string>("SourceFourthResult");





            objConfinedSpaceSign.UpdatedBy = reader.Get<int>("UpdatedBy");


            IUserDao userDao = DaoRegistry.GetDao<IUserDao>();
            objConfinedSpaceSign.LastModifiedBy = objConfinedSpaceSign.UpdatedBy != null ? userDao.QueryById(objConfinedSpaceSign.UpdatedBy) : null;
            objConfinedSpaceSign.LastModifiedDate = reader.Get<DateTime>("UpdatedDate");


            return objConfinedSpaceSign;
        }


        public void Insert(ConfinedSpaceHistoryMuds history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(ConfinedSpaceHistoryMuds history, SqlCommand command)
        {
            command.AddParameter("@Id", history.IdValue);

            command.AddParameter("@ConfinedSpaceNumber", history.ConfinedSpaceNumber.Value);

            command.AddParameter("ConfinedSpaceStatus", history.ConfinedSpaceStatus.IdValue);

            command.AddParameter("StartDateTime", history.StartDateTime);
            command.AddParameter("EndDateTime", history.EndDateTime);
            command.AddParameter("FunctionalLocationId", history.FunctionalLocation.IdValue);

            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);

            command.AddParameter("H2S", history.H2S);
            command.AddParameter("Hydrocarbure", history.Hydrocarbure);
            command.AddParameter("Ammoniaque", history.Ammoniaque);
            command.AddParameter("Corrosif", history.Corrosif.StateAsBool);
            command.AddParameter("CorrosifValue", history.Corrosif.Text);
            command.AddParameter("Aromatique", history.Aromatique.StateAsBool);
            command.AddParameter("AromatiqueValue", history.Aromatique.Text);
            command.AddParameter("AutresSubstances", history.AutresSubstances.StateAsBool);
            command.AddParameter("AutresSubstancesValue", history.AutresSubstances.Text);

            command.AddParameter("ObtureOuDebranche", history.ObtureOuDebranche);
            command.AddParameter("DepressuriseEtVidange", history.DepressuriseEtVidange);
            command.AddParameter("EnPresenceDeGazInerte", history.EnPresenceDeGazInerte);
            command.AddParameter("PurgeALaVapeur", history.PurgeALaVapeur);
            command.AddParameter("DessinsRequis", history.DessinsRequis.StateAsBool);
            command.AddParameter("DessinsRequisValue", history.DessinsRequis.Text);
            command.AddParameter("PlanDeSauvetage", history.PlanDeSauvetage);

            command.AddParameter("CablesChauffantsMisHorsTension", history.CablesChauffantsMisHorsTension);
            command.AddParameter("InterrupteursElectriquesVerrouilles", history.InterrupteursElectriquesVerrouilles);
            command.AddParameter("PurgeParUnGazInerte", history.PurgeParUnGazInerte);
            command.AddParameter("RinceAlEau", history.RinceAlEau);
            command.AddParameter("VentilationMecanique", history.VentilationMecanique);

            command.AddParameter("BouchesDegoutProtegees", history.BouchesDegoutProtegees);
            command.AddParameter("PossibiliteDeSulfureDeFer", history.PossibiliteDeSulfureDeFer);
            command.AddParameter("AereVentile", history.AereVentile);
            command.AddParameter("AutreConditions", history.AutreConditions.StateAsBool);
            command.AddParameter("AutreConditionsValue", history.AutreConditions.Text);
            command.AddParameter("VentilationNaturelle", history.VentilationNaturelle);

            command.AddParameter("InstructionsSpeciales", history.InstructionsSpeciales);

            command.AddParameter("SO2", history.SO2);
            command.AddParameter("NH3", history.NH3);
            command.AddParameter("AcideSulfurique", history.AcideSulfurique);
            command.AddParameter("CO", history.CO);
            command.AddParameter("Azote", history.Azote);
            command.AddParameter("Reflux", history.Reflux);
            command.AddParameter("NaOH", history.NaOH);
            command.AddParameter("SBS", history.SBS);
            command.AddParameter("Soufre", history.Soufre);
            command.AddParameter("Amiante", history.Amiante);
            command.AddParameter("Bacteries", history.Bacteries);
            command.AddParameter("Depressurise", history.Depressurise);
            command.AddParameter("Rince", history.Rince);
            command.AddParameter("Obture", history.Obture);
            command.AddParameter("Nettoyes", history.Nettoyes);
            command.AddParameter("Purge", history.Purge);
            command.AddParameter("Vide", history.Vide);
            command.AddParameter("Dessins ", history.Dessins);
            command.AddParameter("DetectionDeGaz", history.DetectionDeGaz);
            command.AddParameter("PSS", history.PSS);
            command.AddParameter("VentilationEn", history.VentilationEn);
            command.AddParameter("VentilationForce", history.VentilationForce);
            command.AddParameter("Harnis", history.Harnis);
        }
    }
}