using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMontrealHistoryDao : AbstractManagedDao, IWorkPermitMontrealHistoryDao
    {
        private const string QUERY_WORK_PERMIT_MONTREAL_HISTORIES_BY_ID = "QueryWorkPermitMontrealHistoriesById";
        private const string INSERT = "InsertWorkPermitMontrealHistory";

        private readonly IUserDao userDao;

        public WorkPermitMontrealHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<WorkPermitMontrealHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult < WorkPermitMontrealHistory>(PopulateInstance, QUERY_WORK_PERMIT_MONTREAL_HISTORIES_BY_ID);
        }

        private WorkPermitMontrealHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));

            WorkPermitMontrealHistory history = new WorkPermitMontrealHistory(id, lastModifiedBy, lastModifiedDate);

            history.WorkPermitType = WorkPermitMontrealType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.Template = reader.Get<string>("Template");
            history.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatusId"));
            history.StartDateTime = reader.Get<DateTime>("StartDateTime");
            history.EndDateTime = reader.Get<DateTime>("EndDateTime");
            history.PermitNumber = reader.Get<long?>("PermitNumber");
            history.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            history.FunctionalLocations = reader.Get<string>("FunctionalLocations");
            history.Trade = reader.Get<string>("Trade");
            history.Description = reader.Get<string>("Description");
            history.IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime");
            history.H2S = reader.Get<bool>("H2S");
            history.Hydrocarbure = reader.Get<bool>("Hydrocarbure");
            history.Ammoniaque = reader.Get<bool>("Ammoniaque");
            history.Corrosif = reader.GetTernaryString("Corrosif");
            history.Aromatique = reader.GetTernaryString("Aromatique"); 
            history.AutresSubstances = reader.GetTernaryString("AutresSubstances"); 
            history.ObtureOuDebranche = reader.Get<bool>("ObtureOuDebranche"); 
            history.DepressuriseEtVidange = reader.Get<bool>("DepressuriseEtVidange"); 
            history.EnPresenceDeGazInerte = reader.Get<bool>("EnPresenceDeGazInerte"); 
            history.PurgeALaVapeur = reader.Get<bool>("PurgeALaVapeur"); 
            history.RinceALeau = reader.Get<bool>("RinceALeau"); 
            history.Excavation = reader.Get<bool>("Excavation"); 
            history.DessinsRequis = reader.GetTernaryString("DessinsRequis"); 
            history.CablesChauffantsMisHorsTension = reader.Get<bool>("CablesChauffantsMisHorsTension"); 
            history.PompeOuVerinPneumatique = reader.Get<bool>("PompeOuVerinPneumatique"); 
            history.ChaineEtCadenasseOuScelle = reader.Get<bool>("ChaineEtCadenasseOuScelle"); 
            history.InterrupteursElectriquesVerrouilles = reader.Get<bool>("InterrupteursElectriquesVerrouilles"); 
            history.PurgeParUnGazInerte = reader.Get<bool>("PurgeParUnGazInerte"); 
            history.OutilsElectriquesOuABatteries = reader.Get<bool>("OutilsElectriquesOuABatteries"); 
            history.BoiteEnergieZero = reader.GetTernaryString("BoiteEnergieZero"); 
            history.OutilsPneumatiques = reader.Get<bool>("OutilsPneumatiques"); 
            history.MoteurACombustionInterne = reader.Get<bool>("MoteurACombustionInterne"); 
            history.TravauxSuperPoses = reader.Get<bool>("TravauxSuperPoses"); 
            history.FormulaireDespaceClosAffiche = reader.GetTernaryString("FormulaireDespaceClosAffiche"); 
            history.ExisteIlUneAnalyseDeTache = reader.Get<bool>("ExisteIlUneAnalyseDeTache"); 
            history.PossibiliteDeSulfureDeFer = reader.Get<bool>("PossibiliteDeSulfureDeFer"); 
            history.AereVentile = reader.Get<bool>("AereVentile"); 
            history.SoudureALelectricite = reader.Get<bool>("SoudureALelectricite");
            history.BrulageAAcetylene = reader.Get<bool>("BrulageAAcetylene");
            history.Nacelle = reader.Get<bool>("Nacelle");
            history.AutreConditions = reader.GetTernaryString("AutreConditions"); 
            history.LunettesMonocoques = reader.Get<bool>("LunettesMonocoques");
            history.HarnaisDeSecurite = reader.Get<bool>("HarnaisDeSecurite");
            history.EcranFacial = reader.Get<bool>("EcranFacial");
            history.ProtectionAuditive = reader.Get<bool>("ProtectionAuditive");
            history.Trepied = reader.Get<bool>("Trepied");
            history.DispositifAntichute = reader.Get<bool>("DispositifAntichute");
            history.ProtectionRespiratoire = reader.GetTernaryString("ProtectionRespiratoire"); 
            history.Habits = reader.GetTernaryString("Habits"); 
            history.AutreProtection = reader.GetTernaryString("AutreProtection"); 
            history.Extincteur = reader.Get<bool>("Extincteur");
            history.BouchesDegoutProtegees = reader.Get<bool>("BouchesDegoutProtegees");
            history.CouvertureAntiEtincelles = reader.Get<bool>("CouvertureAntiEtincelles");
            history.SurveillantPouretincelles = reader.Get<bool>("SurveillantPouretincelles");
            history.PareEtincelles = reader.Get<bool>("PareEtincelles");
            history.MiseAlaTerrePresDuLieuDeTravail = reader.Get<bool>("MiseAlaTerrePresDuLieuDeTravail");
            history.BoyauAVapeur = reader.Get<bool>("BoyauAVapeur");
            history.AutresEquipementDincendie = reader.GetTernaryString("AutresEquipementDincendie"); 
            history.Ventulateur = reader.Get<bool>("Ventulateur");
            history.Barrieres = reader.Get<bool>("Barrieres");
            history.Surveillant = reader.GetTernaryString("Surveillant");
            history.RadioEmetteur = reader.Get<bool>("RadioEmetteur");
            history.PerimetreDeSecurite = reader.Get<bool>("PerimetreDeSecurite");
            history.DetectionContinueDesGaz = reader.GetTernaryString("DetectionContinueDesGaz");
            history.KlaxonSonore = reader.Get<bool>("KlaxonSonore");
            history.Localiser = reader.Get<bool>("Localiser");
            history.Amiante = reader.Get<bool>("Amiante");
            history.AutreEquipementsSecurite = reader.GetTernaryString("AutreEquipementsSecurite");
            history.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");
            history.SignatureOperateurSurLeTerrain = reader.Get<bool>("SignatureOperateurSurLeTerrain");
            history.DetectionDesGazs = reader.Get<bool>("DetectionDesGazs");
            history.SignatureContremaitre = reader.Get<bool>("SignatureContremaitre");
            history.SignatureAutorise = reader.Get<bool>("SignatureAutorise");
            history.NettoyageTransfertHorsSite = reader.Get<bool>("NettoyageTransfertHorsSite");
            history.DocumentLinks = reader.Get<string>("DocumentLinks");
            history.RequestedByGroup = reader.Get<string>("RequestedByGroup");

            return history;
        }


        public void Insert(WorkPermitMontrealHistory workPermitMontrealHistory)
        {
            ManagedCommand.Insert(workPermitMontrealHistory, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(WorkPermitMontrealHistory history, SqlCommand command)
        {
            command.AddParameter("@Id", history.Id);
            command.AddParameter("@WorkPermitTypeId", history.WorkPermitType.Id);
            command.AddParameter("@Template", history.Template);
            command.AddParameter("@WorkPermitStatusId", history.WorkPermitStatus.Id);
            command.AddParameter("@StartDateTime", history.StartDateTime);
            command.AddParameter("@EndDateTime", history.EndDateTime);
            command.AddParameter("@PermitNumber", history.PermitNumber);
            command.AddParameter("@WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("@FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("@Trade", history.Trade);
            command.AddParameter("@Description", history.Description);
            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@IssuedDateTime", history.IssuedDateTime);
            command.AddParameter("@H2S", history.H2S);
            command.AddParameter("@Hydrocarbure", history.Hydrocarbure);
            command.AddParameter("@Ammoniaque", history.Ammoniaque);
            command.AddParameter("@Corrosif", history.Corrosif.StateAsBool);
            command.AddParameter("@CorrosifValue", history.Corrosif.Text);
            command.AddParameter("@Aromatique", history.Aromatique.StateAsBool);
            command.AddParameter("@AromatiqueValue", history.Aromatique.Text);
            command.AddParameter("@AutresSubstances", history.AutresSubstances.StateAsBool);
            command.AddParameter("@AutresSubstancesValue", history.AutresSubstances.Text);
            command.AddParameter("@ObtureOuDebranche", history.ObtureOuDebranche);
            command.AddParameter("@DepressuriseEtVidange", history.DepressuriseEtVidange);
            command.AddParameter("@EnPresenceDeGazInerte", history.EnPresenceDeGazInerte);
            command.AddParameter("@PurgeALaVapeur", history.PurgeALaVapeur);
            command.AddParameter("@RinceALeau", history.RinceALeau);
            command.AddParameter("@Excavation", history.Excavation);
            command.AddParameter("@DessinsRequis", history.DessinsRequis.StateAsBool);
            command.AddParameter("@DessinsRequisValue", history.DessinsRequis.Text);
            command.AddParameter("@CablesChauffantsMisHorsTension", history.CablesChauffantsMisHorsTension);
            command.AddParameter("@PompeOuVerinPneumatique", history.PompeOuVerinPneumatique);
            command.AddParameter("@ChaineEtCadenasseOuScelle", history.ChaineEtCadenasseOuScelle);
            command.AddParameter("@InterrupteursElectriquesVerrouilles", history.InterrupteursElectriquesVerrouilles);
            command.AddParameter("@PurgeParUnGazInerte", history.PurgeParUnGazInerte);
            command.AddParameter("@OutilsElectriquesOuABatteries", history.OutilsElectriquesOuABatteries);
            command.AddParameter("@BoiteEnergieZero", history.BoiteEnergieZero.StateAsBool);
            command.AddParameter("@BoiteEnergieZeroValue", history.BoiteEnergieZero.Text);
            command.AddParameter("@OutilsPneumatiques", history.OutilsPneumatiques);
            command.AddParameter("@MoteurACombustionInterne", history.MoteurACombustionInterne);
            command.AddParameter("@TravauxSuperPoses", history.TravauxSuperPoses);
            command.AddParameter("@FormulaireDespaceClosAffiche", history.FormulaireDespaceClosAffiche.StateAsBool);
            command.AddParameter("@FormulaireDespaceClosAfficheValue", history.FormulaireDespaceClosAffiche.Text);
            command.AddParameter("@ExisteIlUneAnalyseDeTache", history.ExisteIlUneAnalyseDeTache);
            command.AddParameter("@PossibiliteDeSulfureDeFer", history.PossibiliteDeSulfureDeFer);
            command.AddParameter("@AereVentile", history.AereVentile);
            command.AddParameter("@SoudureALelectricite", history.SoudureALelectricite);
            command.AddParameter("@BrulageAAcetylene", history.BrulageAAcetylene);
            command.AddParameter("@Nacelle", history.Nacelle);
            command.AddParameter("@AutreConditions", history.AutreConditions.StateAsBool);
            command.AddParameter("@AutreConditionsValue", history.AutreConditions.Text);
            command.AddParameter("@LunettesMonocoques", history.LunettesMonocoques);
            command.AddParameter("@HarnaisDeSecurite", history.HarnaisDeSecurite);
            command.AddParameter("@EcranFacial", history.EcranFacial);
            command.AddParameter("@ProtectionAuditive", history.ProtectionAuditive);
            command.AddParameter("@Trepied", history.Trepied);
            command.AddParameter("@DispositifAntichute", history.DispositifAntichute);
            command.AddParameter("@ProtectionRespiratoire", history.ProtectionRespiratoire.StateAsBool);
            command.AddParameter("@ProtectionRespiratoireValue", history.ProtectionRespiratoire.Text);
            command.AddParameter("@Habits", history.Habits.StateAsBool);
            command.AddParameter("@HabitsValue", history.Habits.Text);
            command.AddParameter("@AutreProtection", history.AutreProtection.StateAsBool);
            command.AddParameter("@AutreProtectionValue", history.AutreProtection.Text);
            command.AddParameter("@Extincteur", history.Extincteur);
            command.AddParameter("@BouchesDegoutProtegees", history.BouchesDegoutProtegees);
            command.AddParameter("@CouvertureAntiEtincelles", history.CouvertureAntiEtincelles);
            command.AddParameter("@SurveillantPouretincelles", history.SurveillantPouretincelles);
            command.AddParameter("@PareEtincelles", history.PareEtincelles);
            command.AddParameter("@MiseAlaTerrePresDuLieuDeTravail", history.MiseAlaTerrePresDuLieuDeTravail);
            command.AddParameter("@BoyauAVapeur", history.BoyauAVapeur);
            command.AddParameter("@AutresEquipementDincendie", history.AutresEquipementDincendie.StateAsBool);
            command.AddParameter("@AutresEquipementDincendieValue", history.AutresEquipementDincendie.Text);
            command.AddParameter("@Ventulateur", history.Ventulateur);
            command.AddParameter("@Barrieres", history.Barrieres);
            command.AddParameter("@Surveillant", history.Surveillant.StateAsBool);
            command.AddParameter("@SurveillantValue", history.Surveillant.Text);
            command.AddParameter("@RadioEmetteur", history.RadioEmetteur);
            command.AddParameter("@PerimetreDeSecurite", history.PerimetreDeSecurite);
            command.AddParameter("@DetectionContinueDesGaz", history.DetectionContinueDesGaz.StateAsBool);
            command.AddParameter("@DetectionContinueDesGazValue", history.DetectionContinueDesGaz.Text);
            command.AddParameter("@KlaxonSonore", history.KlaxonSonore);
            command.AddParameter("@Localiser", history.Localiser);
            command.AddParameter("@Amiante", history.Amiante);
            command.AddParameter("@AutreEquipementsSecurite", history.AutreEquipementsSecurite.StateAsBool);
            command.AddParameter("@AutreEquipementsSecuriteValue", history.AutreEquipementsSecurite.Text);
            command.AddParameter("@InstructionsSpeciales", history.InstructionsSpeciales);
            command.AddParameter("@SignatureOperateurSurLeTerrain", history.SignatureOperateurSurLeTerrain);
            command.AddParameter("@DetectionDesGazs", history.DetectionDesGazs);
            command.AddParameter("@SignatureContremaitre", history.SignatureContremaitre);
            command.AddParameter("@SignatureAutorise", history.SignatureAutorise);
            command.AddParameter("@NettoyageTransfertHorsSite", history.NettoyageTransfertHorsSite);
            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@RequestedByGroup", history.RequestedByGroup);
        }

    }
}