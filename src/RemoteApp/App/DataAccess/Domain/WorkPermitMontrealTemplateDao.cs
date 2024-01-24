using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMontrealTemplateDao : AbstractManagedDao, IWorkPermitMontrealTemplateDao
    {
        private const string QUERY_ALL_NOT_DELETED_STORED_PROCEDURE = "QueryAllWorkPermitMontrealTemplatesNotDeleted";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllWorkPermitMontrealTemplates";
        private const string INSERT_STORED_PROCEDURE = "InsertWorkPermitMontrealTemplate";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryWorkPermitMontrealTemplateById";
        private const string DELETE_STORED_PROCEDURE = "DeleteWorkPermitMontrealTemplate";
        private const string UPDATE_STORED_PROCEDURE = "UpdateWorkPermitMontrealTemplate";

        public WorkPermitMontrealTemplate Insert(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter templateNumberParameter = command.AddInputOutputParameter("@TemplateNumber", SqlDbType.Int, workPermitMontrealTemplate.TemplateNumber);

            command.Insert(workPermitMontrealTemplate, AddInsertOrUpdateParameters, INSERT_STORED_PROCEDURE);
            
            workPermitMontrealTemplate.Id = long.Parse(idParameter.Value.ToString());
            workPermitMontrealTemplate.TemplateNumber = int.Parse((templateNumberParameter.Value.ToString()));

            return workPermitMontrealTemplate;
        }

        public WorkPermitMontrealTemplate QueryById(long id)
        {
            return ManagedCommand.QueryById<WorkPermitMontrealTemplate>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<WorkPermitMontrealTemplate> QueryAllNotDeleted()
        {
            return ManagedCommand.QueryForListResult<WorkPermitMontrealTemplate>(PopulateInstance, QUERY_ALL_NOT_DELETED_STORED_PROCEDURE);
        }

        public List<WorkPermitMontrealTemplate> QueryAll()
        {
            return ManagedCommand.QueryForListResult<WorkPermitMontrealTemplate>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public void Delete(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermitMontrealTemplate.Id);
            command.ExecuteNonQuery(DELETE_STORED_PROCEDURE);
        }

        public void Update(WorkPermitMontrealTemplate workPermitMontrealTemplate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermitMontrealTemplate.Id);
            command.ExecuteNonQuery(workPermitMontrealTemplate, UPDATE_STORED_PROCEDURE, AddInsertOrUpdateParameters);
        }

        private static void AddInsertOrUpdateParameters(WorkPermitMontrealTemplate workPermitMontrealTemplate, SqlCommand command)
        {
            command.AddParameter("@Name", workPermitMontrealTemplate.Name);
            command.AddParameter("@TypeId", workPermitMontrealTemplate.WorkPermitType.Id);
            command.AddParameter("@Active", workPermitMontrealTemplate.IsActive);
            command.AddParameter("@Deleted", workPermitMontrealTemplate.IsDeleted);
	        command.AddParameter("@H2S", workPermitMontrealTemplate.H2S);
	        command.AddParameter("@Hydrocarbure", workPermitMontrealTemplate.Hydrocarbure);
	        command.AddParameter("@Ammoniaque", workPermitMontrealTemplate.Ammoniaque);
	        command.AddParameter("@Corrosif", workPermitMontrealTemplate.Corrosif);
	        command.AddParameter("@CorrosifValue", workPermitMontrealTemplate.CorrosifValue);
	        command.AddParameter("@Aromatique", workPermitMontrealTemplate.Aromatique);
	        command.AddParameter("@AromatiqueValue", workPermitMontrealTemplate.AromatiqueValue);
	        command.AddParameter("@AutresSubstances", workPermitMontrealTemplate.AutresSubstances);
	        command.AddParameter("@AutresSubstancesValue", workPermitMontrealTemplate.AutresSubstancesValue);
	        command.AddParameter("@ObtureOuDeBranche", workPermitMontrealTemplate.ObtureOuDebranche);
	        command.AddParameter("@DepressuriseEtVidange", workPermitMontrealTemplate.DepressuriseEtVidange);
	        command.AddParameter("@EnPresenceDeGazInerte", workPermitMontrealTemplate.EnPresenceDeGazInerte);
	        command.AddParameter("@PurgeALaVapeur", workPermitMontrealTemplate.PurgeALaVapeur);
	        command.AddParameter("@RinceALEau", workPermitMontrealTemplate.RinceALeau);
	        command.AddParameter("@Excavation", workPermitMontrealTemplate.Excavation);
	        command.AddParameter("@DessinsRequis", workPermitMontrealTemplate.DessinsRequis);
	        command.AddParameter("@DessinsRequisValue", workPermitMontrealTemplate.DessinsRequisValue);
	        command.AddParameter("@CablesChauffantsMisHorsTension", workPermitMontrealTemplate.CablesChauffantsMisHorsTension);
	        command.AddParameter("@PompeOuVerinPneumatique", workPermitMontrealTemplate.PompeOuVerinPneumatique);
	        command.AddParameter("@ChaineEtCadenasseOuScelle", workPermitMontrealTemplate.ChaineEtCadenasseOuScelle);
	        command.AddParameter("@InterrupteursElectriquesVerrouilles", workPermitMontrealTemplate.InterrupteursElectriquesVerrouilles);
	        command.AddParameter("@PurgeParUnGazInerte", workPermitMontrealTemplate.PurgeParUnGazInerte);
	        command.AddParameter("@OutilsElectriquesOuABatteries", workPermitMontrealTemplate.OutilsElectriquesOuABatteries);
	        command.AddParameter("@BoiteEnergieZero", workPermitMontrealTemplate.BoiteEnergieZero);
	        command.AddParameter("@BoiteEnergieZeroValue", workPermitMontrealTemplate.BoiteEnergieZeroValue);
	        command.AddParameter("@OutilsPneumatiques", workPermitMontrealTemplate.OutilsPneumatiques);
	        command.AddParameter("@MoteurACombustionInterne", workPermitMontrealTemplate.MoteurACombustionInterne);
	        command.AddParameter("@TravauxSuperposes", workPermitMontrealTemplate.TravauxSuperPoses);
	        command.AddParameter("@FormulaireDespaceClosAffiche", workPermitMontrealTemplate.FormulaireDespaceClosAffiche);
	        command.AddParameter("@FormulaireDespaceClosAfficheValue", workPermitMontrealTemplate.FormulaireDespaceClosAfficheValue);
	        command.AddParameter("@ExisteIlUneAnalyseDeTache", workPermitMontrealTemplate.ExisteIlUneAnalyseDeTache);
	        command.AddParameter("@PossibiliteDeSulfureDeFer", workPermitMontrealTemplate.PossibiliteDeSulfureDeFer);
	        command.AddParameter("@AereVentile", workPermitMontrealTemplate.AereVentile);
	        command.AddParameter("@SoudureALelectricite", workPermitMontrealTemplate.SoudureALelectricite);
	        command.AddParameter("@BrulageAAcetylene", workPermitMontrealTemplate.BrulageAAcetylene);
	        command.AddParameter("@Nacelle", workPermitMontrealTemplate.Nacelle);
	        command.AddParameter("@AutreConditions", workPermitMontrealTemplate.AutreConditions);
	        command.AddParameter("@AutreConditionsValue", workPermitMontrealTemplate.AutreConditionsValue);
	        command.AddParameter("@LunettesMonocoques", workPermitMontrealTemplate.LunettesMonocoques);
	        command.AddParameter("@HarnaisDeSecurite", workPermitMontrealTemplate.HarnaisDeSecurite);
	        command.AddParameter("@EcranFacial", workPermitMontrealTemplate.EcranFacial);
	        command.AddParameter("@ProtectionAuditive", workPermitMontrealTemplate.ProtectionAuditive);
	        command.AddParameter("@Trepied", workPermitMontrealTemplate.Trepied);
	        command.AddParameter("@DispositifAntiChute", workPermitMontrealTemplate.DispositifAntichute);
	        command.AddParameter("@ProtectionRespiratoire", workPermitMontrealTemplate.ProtectionRespiratoire);
	        command.AddParameter("@ProtectionRespiratoireValue", workPermitMontrealTemplate.ProtectionRespiratoireValue);
	        command.AddParameter("@Habits", workPermitMontrealTemplate.Habits);
	        command.AddParameter("@HabitsValue", workPermitMontrealTemplate.HabitsValue);
	        command.AddParameter("@AutreProtection", workPermitMontrealTemplate.AutreProtection);
	        command.AddParameter("@AutreProtectionValue", workPermitMontrealTemplate.AutreProtectionValue);
	        command.AddParameter("@Extincteur", workPermitMontrealTemplate.Extincteur);
	        command.AddParameter("@BouchesDegoutProtegees", workPermitMontrealTemplate.BouchesDegoutProtegees);
	        command.AddParameter("@CouvertureAntiEtincelles", workPermitMontrealTemplate.CouvertureAntiEtincelles);
	        command.AddParameter("@SurveillantPourEtincelles", workPermitMontrealTemplate.SurveillantPouretincelles);
	        command.AddParameter("@PareEtincelles", workPermitMontrealTemplate.PareEtincelles);
	        command.AddParameter("@MiseAlaTerrePresDuLieuDeTravail", workPermitMontrealTemplate.MiseAlaTerrePresDuLieuDeTravail);
	        command.AddParameter("@BoyauAVapeur", workPermitMontrealTemplate.BoyauAVapeur);
	        command.AddParameter("@AutresEquipementDincendie", workPermitMontrealTemplate.AutresEquipementDincendie);
	        command.AddParameter("@AutresEquipementDincendieValue", workPermitMontrealTemplate.AutresEquipementDincendieValue);
	        command.AddParameter("@Ventulateur", workPermitMontrealTemplate.Ventulateur);
	        command.AddParameter("@Barrieres", workPermitMontrealTemplate.Barrieres);
	        command.AddParameter("@Surveillant", workPermitMontrealTemplate.Surveillant);
	        command.AddParameter("@SurveillantValue", workPermitMontrealTemplate.SurveillantValue);
	        command.AddParameter("@RadioEmetteur", workPermitMontrealTemplate.RadioEmetteur);
	        command.AddParameter("@PerimetreDeSecurite", workPermitMontrealTemplate.PerimetreDeSecurite);
	        command.AddParameter("@DetectionContinueDesGaz", workPermitMontrealTemplate.DetectionContinueDesGaz);
	        command.AddParameter("@DetectionContinueDesGazValue", workPermitMontrealTemplate.DetectionContinueDesGazValue);
	        command.AddParameter("@KlaxonSonore", workPermitMontrealTemplate.KlaxonSonore);
	        command.AddParameter("@Localiser", workPermitMontrealTemplate.Localiser);
	        command.AddParameter("@Amiante", workPermitMontrealTemplate.Amiante);
	        command.AddParameter("@AutreEquipementsSecurite", workPermitMontrealTemplate.AutreEquipementsSecurite);
	        command.AddParameter("@AutreEquipementsSecuriteValue", workPermitMontrealTemplate.AutreEquipementsSecuriteValue);
	        command.AddParameter("@InstructionsSpeciales", workPermitMontrealTemplate.InstructionsSpeciales);
	        command.AddParameter("@SignatureOperateurSurLeTerrain", workPermitMontrealTemplate.SignatureOperateurSurLeTerrain);
	        command.AddParameter("@DetectionDesGazs", workPermitMontrealTemplate.DetectionDesGazs);
	        command.AddParameter("@SignatureContremaitre", workPermitMontrealTemplate.SignatureContremaitre);
	        command.AddParameter("@SignatureAutorise", workPermitMontrealTemplate.SignatureAutorise);
            command.AddParameter("@NettoyageTransfertHorsSite", workPermitMontrealTemplate.NettoyageTransfertHorsSite);
        }

        private WorkPermitMontrealTemplate PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            int typeId = reader.Get<int>("TypeId");
            bool isActive = reader.Get<bool>("Active");
            bool isDeleted = reader.Get<bool>("Deleted");
            int templateNumber = reader.Get<int>("TemplateNumber");

            WorkPermitMontrealTemplate workPermitMontrealTemplate =
                new WorkPermitMontrealTemplate(name,
                                               WorkPermitMontrealType.Get(typeId),
                                               isActive, isDeleted, templateNumber);

            workPermitMontrealTemplate.Id = id;

            workPermitMontrealTemplate.H2S = reader.Get<byte>("H2S").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Hydrocarbure = reader.Get<byte>("Hydrocarbure").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Ammoniaque = reader.Get<byte>("Ammoniaque").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Corrosif = reader.Get<byte>("Corrosif").ToEnum<TemplateState>();
            workPermitMontrealTemplate.CorrosifValue = reader.Get<string>("CorrosifValue");
            workPermitMontrealTemplate.Aromatique = reader.Get<byte>("Aromatique").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AromatiqueValue = reader.Get<string>("AromatiqueValue");
            workPermitMontrealTemplate.AutresSubstances = reader.Get<byte>("AutresSubstances").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutresSubstancesValue = reader.Get<string>("AutresSubstancesValue");

            workPermitMontrealTemplate.ObtureOuDebranche = reader.Get<byte>("ObtureOuDebranche").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DepressuriseEtVidange = reader.Get<byte>("DepressuriseEtVidange").ToEnum<TemplateState>();
            workPermitMontrealTemplate.EnPresenceDeGazInerte = reader.Get<byte>("EnPresenceDeGazInerte").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PurgeALaVapeur = reader.Get<byte>("PurgeALaVapeur").ToEnum<TemplateState>();
            workPermitMontrealTemplate.RinceALeau = reader.Get<byte>("RinceALeau").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Excavation = reader.Get<byte>("Excavation").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DessinsRequis = reader.Get<byte>("DessinsRequis").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DessinsRequisValue = reader.Get<string>("DessinsRequisValue");
            workPermitMontrealTemplate.CablesChauffantsMisHorsTension = reader.Get<byte>("CablesChauffantsMisHorsTension").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PompeOuVerinPneumatique = reader.Get<byte>("PompeOuVerinPneumatique").ToEnum<TemplateState>();

            workPermitMontrealTemplate.ChaineEtCadenasseOuScelle = reader.Get<byte>("ChaineEtCadenasseOuScelle").ToEnum<TemplateState>();
            workPermitMontrealTemplate.InterrupteursElectriquesVerrouilles = reader.Get<byte>("InterrupteursElectriquesVerrouilles").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PurgeParUnGazInerte = reader.Get<byte>("PurgeParUnGazInerte").ToEnum<TemplateState>();
            workPermitMontrealTemplate.OutilsElectriquesOuABatteries = reader.Get<byte>("OutilsElectriquesOuABatteries").ToEnum<TemplateState>();
            workPermitMontrealTemplate.BoiteEnergieZero = reader.Get<byte>("BoiteEnergieZero").ToEnum<TemplateState>();
            workPermitMontrealTemplate.BoiteEnergieZeroValue = reader.Get<string>("BoiteEnergieZeroValue");
            workPermitMontrealTemplate.OutilsPneumatiques = reader.Get<byte>("OutilsPneumatiques").ToEnum<TemplateState>();
            workPermitMontrealTemplate.MoteurACombustionInterne = reader.Get<byte>("MoteurACombustionInterne").ToEnum<TemplateState>();
            workPermitMontrealTemplate.TravauxSuperPoses = reader.Get<byte>("TravauxSuperPoses").ToEnum<TemplateState>();

            workPermitMontrealTemplate.FormulaireDespaceClosAffiche = reader.Get<byte>("FormulaireDespaceClosAffiche").ToEnum<TemplateState>();
            workPermitMontrealTemplate.FormulaireDespaceClosAfficheValue = reader.Get<string>("FormulaireDespaceClosAfficheValue");
            workPermitMontrealTemplate.ExisteIlUneAnalyseDeTache = reader.Get<byte>("ExisteIlUneAnalyseDeTache").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PossibiliteDeSulfureDeFer = reader.Get<byte>("PossibiliteDeSulfureDeFer").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AereVentile = reader.Get<byte>("AereVentile").ToEnum<TemplateState>();
            workPermitMontrealTemplate.SoudureALelectricite = reader.Get<byte>("SoudureALelectricite").ToEnum<TemplateState>();
            workPermitMontrealTemplate.BrulageAAcetylene = reader.Get<byte>("BrulageAAcetylene").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Nacelle = reader.Get<byte>("Nacelle").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutreConditions = reader.Get<byte>("AutreConditions").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutreConditionsValue = reader.Get<string>("AutreConditionsValue");

            workPermitMontrealTemplate.LunettesMonocoques = reader.Get<byte>("LunettesMonocoques").ToEnum<TemplateState>();
            workPermitMontrealTemplate.HarnaisDeSecurite = reader.Get<byte>("HarnaisDeSecurite").ToEnum<TemplateState>();
            workPermitMontrealTemplate.EcranFacial = reader.Get<byte>("EcranFacial").ToEnum<TemplateState>();
            workPermitMontrealTemplate.ProtectionAuditive = reader.Get<byte>("ProtectionAuditive").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Trepied = reader.Get<byte>("Trepied").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DispositifAntichute = reader.Get<byte>("DispositifAntichute").ToEnum<TemplateState>();
            workPermitMontrealTemplate.ProtectionRespiratoire = reader.Get<byte>("ProtectionRespiratoire").ToEnum<TemplateState>();
            workPermitMontrealTemplate.ProtectionRespiratoireValue = reader.Get<string>("ProtectionRespiratoireValue");
            workPermitMontrealTemplate.Habits = reader.Get<byte>("Habits").ToEnum<TemplateState>();
            workPermitMontrealTemplate.HabitsValue = reader.Get<string>("HabitsValue");
            workPermitMontrealTemplate.AutreProtection = reader.Get<byte>("AutreProtection").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutreProtectionValue = reader.Get<string>("AutreProtectionValue");

            workPermitMontrealTemplate.Extincteur = reader.Get<byte>("Extincteur").ToEnum<TemplateState>();
            workPermitMontrealTemplate.BouchesDegoutProtegees = reader.Get<byte>("BouchesDegoutProtegees").ToEnum<TemplateState>();
            workPermitMontrealTemplate.CouvertureAntiEtincelles = reader.Get<byte>("CouvertureAntiEtincelles").ToEnum<TemplateState>();
            workPermitMontrealTemplate.SurveillantPouretincelles = reader.Get<byte>("SurveillantPouretincelles").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PareEtincelles = reader.Get<byte>("PareEtincelles").ToEnum<TemplateState>();
            workPermitMontrealTemplate.MiseAlaTerrePresDuLieuDeTravail = reader.Get<byte>("MiseAlaTerrePresDuLieuDeTravail").ToEnum<TemplateState>();
            workPermitMontrealTemplate.BoyauAVapeur = reader.Get<byte>("BoyauAVapeur").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutresEquipementDincendie = reader.Get<byte>("AutresEquipementDincendie").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutresEquipementDincendieValue = reader.Get<string>("AutresEquipementDincendieValue");

            workPermitMontrealTemplate.Ventulateur = reader.Get<byte>("Ventulateur").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Barrieres = reader.Get<byte>("Barrieres").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Surveillant = reader.Get<byte>("Surveillant").ToEnum<TemplateState>();
            workPermitMontrealTemplate.SurveillantValue = reader.Get<string>("SurveillantValue");
            workPermitMontrealTemplate.RadioEmetteur = reader.Get<byte>("RadioEmetteur").ToEnum<TemplateState>();
            workPermitMontrealTemplate.PerimetreDeSecurite = reader.Get<byte>("PerimetreDeSecurite").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DetectionContinueDesGaz = reader.Get<byte>("DetectionContinueDesGaz").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DetectionContinueDesGazValue = reader.Get<string>("DetectionContinueDesGazValue");
            workPermitMontrealTemplate.KlaxonSonore = reader.Get<byte>("KlaxonSonore").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Localiser = reader.Get<byte>("Localiser").ToEnum<TemplateState>();
            workPermitMontrealTemplate.Amiante = reader.Get<byte>("Amiante").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutreEquipementsSecurite = reader.Get<byte>("AutreEquipementsSecurite").ToEnum<TemplateState>();
            workPermitMontrealTemplate.AutreEquipementsSecuriteValue = reader.Get<string>("AutreEquipementsSecuriteValue");

            workPermitMontrealTemplate.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");

            workPermitMontrealTemplate.SignatureOperateurSurLeTerrain = reader.Get<byte>("SignatureOperateurSurLeTerrain").ToEnum<TemplateState>();
            workPermitMontrealTemplate.DetectionDesGazs = reader.Get<byte>("DetectionDesGazs").ToEnum<TemplateState>();
            workPermitMontrealTemplate.SignatureContremaitre = reader.Get<byte>("SignatureContremaitre").ToEnum<TemplateState>();
            workPermitMontrealTemplate.SignatureAutorise = reader.Get<byte>("SignatureAutorise").ToEnum<TemplateState>();
            workPermitMontrealTemplate.NettoyageTransfertHorsSite = reader.Get<byte>("NettoyageTransfertHorsSite").ToEnum<TemplateState>();

            return workPermitMontrealTemplate;
        }

    }
}
