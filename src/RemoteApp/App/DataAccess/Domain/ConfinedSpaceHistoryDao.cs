using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ConfinedSpaceHistoryDao : AbstractManagedDao, IConfinedSpaceHistoryDao
    {
        private const string QUERY_BY_ID = "QueryConfinedSpaceHistoriesById";
        private const string INSERT = "InsertConfinedSpaceHistory";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public ConfinedSpaceHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public List<ConfinedSpaceHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult<ConfinedSpaceHistory>(PopulateInstance, QUERY_BY_ID);
        }

        private ConfinedSpaceHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            int status = reader.Get<int>("ConfinedSpaceStatus");
            ConfinedSpaceStatus confinedSpaceStatus = ConfinedSpaceStatus.Get(status);
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

            FunctionalLocation functionalLocation = functionalLocationDao.QueryById(flocId);
            User lastModifiedBy = userDao.QueryById(lastModifiedByUserId);

            return new ConfinedSpaceHistory(
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
                lastModifiedDateTime);
        }

        public void Insert(ConfinedSpaceHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(ConfinedSpaceHistory history, SqlCommand command)
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
        }
    }
}