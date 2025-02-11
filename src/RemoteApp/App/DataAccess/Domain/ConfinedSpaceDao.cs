using System;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ConfinedSpaceDao : AbstractManagedDao, IConfinedSpaceDao
    {
        private string QUERY_CONFINED_SPACE_BY_ID = "QueryConfinedSpaceById";
        private const string UpdateStoredProcedure = "UpdateConfinedSpace";
        private const string InsertStoredProcedure = "InsertConfinedSpace";
        private const string RemoveStoredProcedure = "RemoveConfinedSpace";

        private readonly IFunctionalLocationDao flocDao;
        private readonly IUserDao userDao;

        public ConfinedSpaceDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public ConfinedSpace QueryById(long id)
        {
            return ManagedCommand.QueryById<ConfinedSpace>(id, PopulateInstance, QUERY_CONFINED_SPACE_BY_ID);
        }

        public ConfinedSpace Insert(ConfinedSpace confinedSpace)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter permitNumberParameter = command.AddOutputParameter("@ConfinedSpaceNumber", SqlDbType.BigInt);

            command.Insert(confinedSpace, AddInsertParameters, InsertStoredProcedure);
            confinedSpace.Id = (long)idParameter.Value;
            SetConfinedSpaceNumber(confinedSpace, permitNumberParameter);

            return confinedSpace;

        }

        private static void SetConfinedSpaceNumber(ConfinedSpace confinedSpace, SqlParameter confinedSpaceNumberParameter)
        {
            if (confinedSpaceNumberParameter.Value == DBNull.Value)
            {
                confinedSpace.ConfinedSpaceNumber = null;
            }
            else
            {
                confinedSpace.ConfinedSpaceNumber = (long)confinedSpaceNumberParameter.Value;
            }
        }

        public void Update(ConfinedSpace confinedSpace)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", confinedSpace.Id);
            command.Update(confinedSpace, AddInsertOrUpdateParameters, UpdateStoredProcedure);
        }

        public void Remove(ConfinedSpace confinedSpace)
        {
            ManagedCommand.Remove(confinedSpace, RemoveStoredProcedure);                        
        }

        private static void AddInsertParameters(ConfinedSpace confinedSpace, SqlCommand command)
        {
            command.AddParameter("ShouldCreateConfinedSpaceNumber",
                confinedSpace.ConfinedSpaceNumber.HasNoValue());

            AddInsertOrUpdateParameters(confinedSpace, command);
        }

        private static void AddInsertOrUpdateParameters(ConfinedSpace confinedSpace, SqlCommand command)
        {
            command.AddParameter("ConfinedSpaceStatus", confinedSpace.ConfinedSpaceStatus.IdValue);

            command.AddParameter("StartDateTime", confinedSpace.StartDateTime);
            command.AddParameter("EndDateTime", confinedSpace.EndDateTime);
            command.AddParameter("FunctionalLocationId", confinedSpace.FunctionalLocation.IdValue);

            command.AddParameter("LastModifiedDateTime", confinedSpace.LastModifiedDateTime);
            command.AddParameter("LastModifiedByUserId", confinedSpace.LastModifiedBy.IdValue);

            command.AddParameter("H2S", confinedSpace.H2S);
            command.AddParameter("Hydrocarbure", confinedSpace.Hydrocarbure);
            command.AddParameter("Ammoniaque", confinedSpace.Ammoniaque);
            command.AddParameter("Corrosif", confinedSpace.Corrosif.StateAsBool);
            command.AddParameter("CorrosifValue", confinedSpace.Corrosif.Text);
            command.AddParameter("Aromatique", confinedSpace.Aromatique.StateAsBool);
            command.AddParameter("AromatiqueValue", confinedSpace.Aromatique.Text);
            command.AddParameter("AutresSubstances", confinedSpace.AutresSubstances.StateAsBool);
            command.AddParameter("AutresSubstancesValue", confinedSpace.AutresSubstances.Text);

            command.AddParameter("ObtureOuDebranche", confinedSpace.ObtureOuDebranche);
            command.AddParameter("DepressuriseEtVidange", confinedSpace.DepressuriseEtVidange);
            command.AddParameter("EnPresenceDeGazInerte", confinedSpace.EnPresenceDeGazInerte);
            command.AddParameter("PurgeALaVapeur", confinedSpace.PurgeALaVapeur);
            command.AddParameter("DessinsRequis", confinedSpace.DessinsRequis.StateAsBool);
            command.AddParameter("DessinsRequisValue", confinedSpace.DessinsRequis.Text);
            command.AddParameter("PlanDeSauvetage", confinedSpace.PlanDeSauvetage);

            command.AddParameter("CablesChauffantsMisHorsTension", confinedSpace.CablesChauffantsMisHorsTension);
            command.AddParameter("InterrupteursElectriquesVerrouilles", confinedSpace.InterrupteursElectriquesVerrouilles);
            command.AddParameter("PurgeParUnGazInerte", confinedSpace.PurgeParUnGazInerte);
            command.AddParameter("RinceAlEau", confinedSpace.RinceAlEau);
            command.AddParameter("VentilationMecanique", confinedSpace.VentilationMecanique);

            command.AddParameter("BouchesDegoutProtegees", confinedSpace.BouchesDegoutProtegees);
            command.AddParameter("PossibiliteDeSulfureDeFer", confinedSpace.PossibiliteDeSulfureDeFer);
            command.AddParameter("AereVentile", confinedSpace.AereVentile);
            command.AddParameter("AutreConditions", confinedSpace.AutreConditions.StateAsBool);
            command.AddParameter("AutreConditionsValue", confinedSpace.AutreConditions.Text);
            command.AddParameter("VentilationNaturelle", confinedSpace.VentilationNaturelle);

            command.AddParameter("InstructionsSpeciales", confinedSpace.InstructionsSpeciales);
        }

        private ConfinedSpace PopulateInstance(SqlDataReader reader)
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
            
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            FunctionalLocation functionalLocation = flocDao.QueryById(flocId);
            User createdBy = userDao.QueryById(createdByUserId);
            User lastModifiedBy = userDao.QueryById(lastModifiedByUserId);

            return new ConfinedSpace(
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
                createdBy,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime);
        }
    }
}