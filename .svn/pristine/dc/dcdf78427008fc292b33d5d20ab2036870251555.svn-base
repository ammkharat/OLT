using System;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ConfinedSpaceMudsDao : AbstractManagedDao, IConfinedSpaceMudsDao
    {
        private string QUERY_CONFINED_SPACE_BY_ID = "QueryConfinedSpaceMudsById";
        private const string UpdateStoredProcedure = "UpdateConfinedSpaceMuds";
        private const string InsertStoredProcedure = "InsertConfinedSpaceMuds";
        private const string RemoveStoredProcedure = "RemoveConfinedSpaceMuds";
        private string QUERY_CONFINED_SPACE_BY_CONFINEDSPACE_ID = "QueryConfinedSpaceMudsByConfinedSpaceId";
        private readonly IGasTestElementDao gasTestElementDao;

        private readonly IFunctionalLocationDao flocDao;
        private readonly IUserDao userDao;

        public ConfinedSpaceMudsDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            gasTestElementDao = DaoRegistry.GetDao<IGasTestElementDao>();
        }

        public ConfinedSpaceMuds QueryById(long id)
        {
            return ManagedCommand.QueryById<ConfinedSpaceMuds>(id, PopulateInstance, QUERY_CONFINED_SPACE_BY_ID);
        }

        public ConfinedSpaceMuds QueryByConfinedSpaceId(long id)
        {
            return ManagedCommand.QueryById<ConfinedSpaceMuds>(id, PopulateInstance, QUERY_CONFINED_SPACE_BY_CONFINEDSPACE_ID);
        }

        public ConfinedSpaceMuds Insert(ConfinedSpaceMuds confinedSpace)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter permitNumberParameter = command.AddOutputParameter("@ConfinedSpaceNumber", SqlDbType.BigInt);

            command.Insert(confinedSpace, AddInsertParameters, InsertStoredProcedure);
            confinedSpace.Id = (long)idParameter.Value;
            SetConfinedSpaceNumber(confinedSpace, permitNumberParameter);
            if (confinedSpace.GasTests != null)
                foreach (GasTestElement element in confinedSpace.GasTests.Elements)
                {
                    gasTestElementDao.InsertMuds(element, confinedSpace.Id.GetValueOrDefault());
                }

            return confinedSpace;

        }

        private static void SetConfinedSpaceNumber(ConfinedSpaceMuds confinedSpace, SqlParameter confinedSpaceNumberParameter)
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

        public void Update(ConfinedSpaceMuds confinedSpace)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", confinedSpace.Id);
            command.Update(confinedSpace, AddInsertOrUpdateParameters, UpdateStoredProcedure);
            foreach (GasTestElement element in confinedSpace.GasTests.Elements)
            {
                if (element.Id == null)
                    gasTestElementDao.InsertMuds(element, confinedSpace.Id.GetValueOrDefault());
                else
                    //gasTestElementDao.UpdateMuds(element);
                    gasTestElementDao.InsertMuds(element, confinedSpace.Id.GetValueOrDefault());
            }
        }

        public void Remove(ConfinedSpaceMuds confinedSpace)
        {
            ManagedCommand.Remove(confinedSpace, RemoveStoredProcedure);                        
        }

        private static void AddInsertParameters(ConfinedSpaceMuds confinedSpace, SqlCommand command)
        {
            command.AddParameter("ShouldCreateConfinedSpaceNumber",
                confinedSpace.ConfinedSpaceNumber.HasNoValue());

            AddInsertOrUpdateParameters(confinedSpace, command);
        }

        private static void AddInsertOrUpdateParameters(ConfinedSpaceMuds confinedSpace, SqlCommand command)
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

command.AddParameter("SO2",confinedSpace.SO2);
command.AddParameter("NH3",confinedSpace.NH3); 
command.AddParameter("AcideSulfurique",confinedSpace.AcideSulfurique );
command.AddParameter("CO",confinedSpace.CO );
command.AddParameter("Azote",confinedSpace.Azote );
command.AddParameter("Reflux",confinedSpace.Reflux );
command.AddParameter("NaOH",confinedSpace.NaOH );
command.AddParameter("SBS",confinedSpace.SBS );
command.AddParameter("Soufre",confinedSpace.Soufre );
command.AddParameter("Amiante",confinedSpace.Amiante );
command.AddParameter("Bacteries",confinedSpace.Bacteries); 
command.AddParameter("Depressurise",confinedSpace.Depressurise); 
command.AddParameter("Rince",confinedSpace.Rince );
command.AddParameter("Obture",confinedSpace.Obture );
command.AddParameter("Nettoyes",confinedSpace.Nettoyes );
command.AddParameter("Purge",confinedSpace.Purge );
command.AddParameter("Vide",confinedSpace.Vide );
command.AddParameter("Dessins ",confinedSpace.Dessins);  
command.AddParameter("DetectionDeGaz",confinedSpace.DetectionDeGaz );
command.AddParameter("PSS",confinedSpace.PSS );
command.AddParameter("VentilationEn",confinedSpace.VentilationEn );
command.AddParameter("VentilationForce",confinedSpace.VentilationForce );
command.AddParameter("Harnis",confinedSpace.Harnis);
            //Added by ppanigrahi
if (confinedSpace.GasTests == null)
{
    command.AddParameter("@GasTestFirstResultTime", null);
    command.AddParameter("@GasTestSecondResultTime", null);
    command.AddParameter("@GasTestThirdResultTime", null);
    command.AddParameter("@GasTestFourthResultTime", null);
}
else
{
    if (confinedSpace.GasTests.GasTestFirstResultTime == null)
    {
        command.AddParameter("@GasTestFirstResultTime", null);
    }
    else
    {
        command.AddParameter("@GasTestFirstResultTime",
            confinedSpace.GasTests.GasTestFirstResultTime.ToDateTime());
    }
    if (confinedSpace.GasTests.GasTestSecondResultTime == null)
    {
        command.AddParameter("@GasTestSecondResultTime", null);
    }
    else
    {
        command.AddParameter("@GasTestSecondResultTime",
            confinedSpace.GasTests.GasTestSecondResultTime.ToDateTime());
    }
    if (confinedSpace.GasTests.GasTestThirdResultTime == null)
    {
        command.AddParameter("@GasTestThirdResultTime", null);
    }
    else
    {
        command.AddParameter("@GasTestThirdResultTime",
            confinedSpace.GasTests.GasTestThirdResultTime.ToDateTime());
    }
    if (confinedSpace.GasTests.GasTestFourthResultTime == null)
    {
        command.AddParameter("@GasTestFourthResultTime", null);
    }
    else
    {
        command.AddParameter("@GasTestFourthResultTime",
            confinedSpace.GasTests.GasTestFourthResultTime.ToDateTime());
    }
}

        }

        private ConfinedSpaceMuds PopulateInstance(SqlDataReader reader)
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
            
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            FunctionalLocation functionalLocation = flocDao.QueryById(flocId);
            User createdBy = userDao.QueryById(createdByUserId);
            User lastModifiedBy = userDao.QueryById(lastModifiedByUserId);

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

          

            ConfinedSpaceMuds confinedSpaceMuds= new ConfinedSpaceMuds(
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
                lastModifiedDateTime,
                sO2 ,nH3 ,acideSulfurique ,cO ,azote ,reflux ,naOH ,sBS ,soufre ,amiante ,bacteries ,depressurise ,rince ,obture ,nettoyes ,purge 
                ,vide ,dessins  ,detectionDeGaz ,pSS ,ventilationEn ,ventilationForce ,harnis
                );

            confinedSpaceMuds.GasTests = PopulateWorkPermitGasTests(reader, confinedSpaceMuds.Id.GetValueOrDefault());
            return confinedSpaceMuds;


        }
        //Added by ppanigrahi
        private WorkPermitGasTests PopulateWorkPermitGasTests(SqlDataReader reader, long confinedSpaceMudsId)
        {
            WorkPermitGasTests result = new WorkPermitGasTests
            {
                // ConstantMonitoringRequired = reader.Get<bool>("GasTestConstantMonitoringRequired"),
                // FrequencyOrDuration = reader.Get<string>("GasTestFrequencyOrDuration"),
                // ForkliftNotUsed = reader.Get<bool>("GasTestForkliftNotUsed")
            };

            //DateTime? testTime = reader.Get<DateTime?>("GasTestTestTime");
            //result.ImmediateAreaTestTime = testTime.HasValue ? new Time(testTime.Value) : null;

            //DateTime? confinedSpaceTestTime = reader.Get<DateTime?>("GasTestConfinedSpaceTestTime");
            //result.ConfinedSpaceTestTime = confinedSpaceTestTime.HasValue ? new Time(confinedSpaceTestTime.Value) : null;

            //DateTime? systemEntryTestTime = reader.Get<DateTime?>("GasTestSystemEntryTestTime");
            //result.SystemEntryTestTime = systemEntryTestTime.HasValue ? new Time(systemEntryTestTime.Value) : null;
            //FunctionalLocation floc = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            DateTime? testTime = reader.Get<DateTime?>("GasTestFirstResultTime");
            result.GasTestFirstResultTime = testTime.HasValue ? new Time(testTime.Value) : null;

            DateTime? testTime1 = reader.Get<DateTime?>("GasTestSecondResultTime");
            result.GasTestSecondResultTime = testTime1.HasValue ? new Time(testTime1.Value) : null;

            DateTime? testTime2 = reader.Get<DateTime?>("GasTestThirdResultTime");
            result.GasTestThirdResultTime = testTime2.HasValue ? new Time(testTime2.Value) : null;

            DateTime? testTime3 = reader.Get<DateTime?>("GasTestFourthResultTime");
            result.GasTestFourthResultTime = testTime3.HasValue ? new Time(testTime3.Value) : null;



            result.Elements = gasTestElementDao.QueryAllGasTestElementByWorkPermitIdMuds(confinedSpaceMudsId, 16);

            return result;
        }
        //Added by ppanigrahi for signature
        public ConfinedSpaceMudSign GetConfinedSpaceMudSign(string confinedSpaceID, int SiteId)
        {


            SqlCommand command = ManagedCommand;
            command.AddParameter("@ConfinedSpaceId", confinedSpaceID);
            command.AddParameter("@SiteId", SiteId);

            return command.QueryForSingleResult<ConfinedSpaceMudSign>(PopulateConfinedSpaceMudSign, "GetConfinedSpaceMudssign");
        }

        public static ConfinedSpaceMudSign PopulateConfinedSpaceMudSign(SqlDataReader reader)
        {
            ConfinedSpaceMudSign confinedspaceSign = new ConfinedSpaceMudSign();


            confinedspaceSign.ConfinedSpaceId = reader.Get<string>("ConfinedSpaceId");

            confinedspaceSign.Verifier_FNAME = reader.Get<string>("Verifier_FNAME");
            confinedspaceSign.Verifier_LNAME = reader.Get<string>("Verifier_LNAME");
            confinedspaceSign.Verifier_BADGENUMBER = reader.Get<string>("Verifier_BADGENUMBER");
            confinedspaceSign.Verifier_BADGETYPE = reader.Get<string>("Verifier_BADGETYPE");
            confinedspaceSign.Verifier_SOURCE = reader.Get<string>("Verifier_SOURCE");


            confinedspaceSign.DETENTEUR_FNAME = reader.Get<string>("DETENTEUR_FNAME");
            confinedspaceSign.DETENTEUR_LNAME = reader.Get<string>("DETENTEUR_LNAME");
            confinedspaceSign.DETENTEUR_BADGENUMBER = reader.Get<string>("DETENTEUR_BADGENUMBER");
            confinedspaceSign.DETENTEUR_BADGETYPE = reader.Get<string>("DETENTEUR_BADGETYPE");
            confinedspaceSign.DETENTEUR_SOURCE = reader.Get<string>("DETENTEUR_SOURCE");


            confinedspaceSign.EMETTEUR_FNAME = reader.Get<string>("EMETTEUR_FNAME");
            confinedspaceSign.EMETTEUR_LNAME = reader.Get<string>("EMETTEUR_LNAME");
            confinedspaceSign.EMETTEUR_BADGENUMBER = reader.Get<string>("EMETTEUR_BADGENUMBER");
            confinedspaceSign.EMETTEUR_BADGETYPE = reader.Get<string>("EMETTEUR_BADGETYPE");
            confinedspaceSign.EMETTEUR_SOURCE = reader.Get<string>("EMETTEUR_SOURCE");




            confinedspaceSign.UpdatedBy = reader.Get<int>("UpdatedBy");
            confinedspaceSign.CreatedBy = reader.Get<int>("CreatedBy");
            confinedspaceSign.CreatedDate = Convert.ToString(reader.Get<DateTime>("CreatedDate"));
            confinedspaceSign.UpdatedDate = Convert.ToString(reader.Get<DateTime>("UpdatedDate"));
            //confinedspaceSign.SiteId =Convert.ToString(reader.Get<long?>("SiteId"));

            confinedspaceSign.FirstNameFirstResult = reader.Get<string>("FirstNameFirstResult");
            confinedspaceSign.LasttNameFirstResult = reader.Get<string>("LasttNameFirstResult");
            confinedspaceSign.SourceFirstResult = reader.Get<string>("SourceFirstResult");
            confinedspaceSign.BadgeFirstResult = reader.Get<string>("BadgeFirstResult");
            confinedspaceSign.FirstNameSecondResult = reader.Get<string>("FirstNameSecondResult");
            confinedspaceSign.LasttNameSecondResult = reader.Get<string>("LasttNameSecondResult");
            confinedspaceSign.SourceSecondResult = reader.Get<string>("SourceSecondResult");
            confinedspaceSign.BadgeSecondResult = reader.Get<string>("BadgeSecondResult");
            confinedspaceSign.FirstNameThirdResult = reader.Get<string>("FirstNameThirdResult");
            confinedspaceSign.LasttNameThirdResult = reader.Get<string>("LasttNameThirdResult");
            confinedspaceSign.SourceThirdResult = reader.Get<string>("SourceThirdResult");
            confinedspaceSign.BadgeThirdResult = reader.Get<string>("BadgeThirdResult");
            confinedspaceSign.FirstNameFourthResult = reader.Get<string>("FirstNameFourthResult");
            confinedspaceSign.LasttNameFourthResult = reader.Get<string>("LasttNameFourthResult");
            confinedspaceSign.SourceFourthResult = reader.Get<string>("SourceFourthResult");
            confinedspaceSign.BadgeFourthResult = reader.Get<string>("BadgeFourthResult");






            return confinedspaceSign;
        }


        public void InserUpdateConfinedSpaceMudSign(ConfinedSpaceMudSign confinedspaceSign)
        {
            ManagedCommand.ExecuteNonQuery(confinedspaceSign, "InsertUpdateConfinedSpaceMudssign", AddSignParameters);
        }

        private static void AddSignParameters(ConfinedSpaceMudSign confinedspaceSign, SqlCommand command)
        {

            command.AddParameter("@ConfinedSpaceId", confinedspaceSign.ConfinedSpaceId);

            command.AddParameter("@Verifier_FNAME", confinedspaceSign.Verifier_FNAME);
            command.AddParameter("@Verifier_LNAME", confinedspaceSign.Verifier_LNAME);
            command.AddParameter("@Verifier_BADGENUMBER", confinedspaceSign.Verifier_BADGENUMBER);
            command.AddParameter("@Verifier_BADGETYPE", confinedspaceSign.Verifier_BADGETYPE);
            command.AddParameter("@Verifier_SOURCE", confinedspaceSign.Verifier_SOURCE);



            command.AddParameter("@DETENTEUR_FNAME", confinedspaceSign.DETENTEUR_FNAME);
            command.AddParameter("@DETENTEUR_LNAME", confinedspaceSign.DETENTEUR_LNAME);
            command.AddParameter("@DETENTEUR_BADGENUMBER", confinedspaceSign.DETENTEUR_BADGENUMBER);
            command.AddParameter("@DETENTEUR_BADGETYPE", confinedspaceSign.DETENTEUR_BADGETYPE);
            command.AddParameter("@DETENTEUR_SOURCE", confinedspaceSign.DETENTEUR_SOURCE);


            command.AddParameter("@EMETTEUR_FNAME", confinedspaceSign.EMETTEUR_FNAME);
            command.AddParameter("@EMETTEUR_LNAME", confinedspaceSign.EMETTEUR_LNAME);
            command.AddParameter("@EMETTEUR_BADGENUMBER", confinedspaceSign.EMETTEUR_BADGENUMBER);
            command.AddParameter("@EMETTEUR_BADGETYPE", confinedspaceSign.EMETTEUR_BADGETYPE);
            command.AddParameter("@EMETTEUR_SOURCE", confinedspaceSign.EMETTEUR_SOURCE);





            command.AddParameter("@UpdatedBy", confinedspaceSign.UpdatedBy);
            command.AddParameter("@CreatedBy", confinedspaceSign.CreatedBy);
            command.AddParameter("@CreatedDate", confinedspaceSign.CreatedDate);
            command.AddParameter("@UpdatedDate", confinedspaceSign.UpdatedDate);
            command.AddParameter("@SiteId", confinedspaceSign.SiteId);

            command.AddParameter("@FirstNameFirstResult", confinedspaceSign.FirstNameFirstResult);
            command.AddParameter("@LasttNameFirstResult", confinedspaceSign.LasttNameFirstResult);
            command.AddParameter("@SourceFirstResult", confinedspaceSign.SourceFirstResult);
            command.AddParameter("@BadgeFirstResult", confinedspaceSign.BadgeFirstResult);
            command.AddParameter("@FirstNameSecondResult", confinedspaceSign.FirstNameSecondResult);
            command.AddParameter("@LasttNameSecondResult", confinedspaceSign.LasttNameSecondResult);
            command.AddParameter("@SourceSecondResult", confinedspaceSign.SourceSecondResult);
            command.AddParameter("@BadgeSecondResult", confinedspaceSign.BadgeSecondResult);
            command.AddParameter("@FirstNameThirdResult", confinedspaceSign.FirstNameThirdResult);
            command.AddParameter("@LasttNameThirdResult", confinedspaceSign.LasttNameThirdResult);
            command.AddParameter("@SourceThirdResult", confinedspaceSign.SourceThirdResult);
            command.AddParameter("@BadgeThirdResult", confinedspaceSign.BadgeThirdResult);
            command.AddParameter("@FirstNameFourthResult", confinedspaceSign.FirstNameFourthResult);
            command.AddParameter("@LasttNameFourthResult", confinedspaceSign.LasttNameFourthResult);
            command.AddParameter("@SourceFourthResult", confinedspaceSign.SourceFourthResult);
            command.AddParameter("@BadgeFourthResult", confinedspaceSign.BadgeFourthResult);


        }



    }
}