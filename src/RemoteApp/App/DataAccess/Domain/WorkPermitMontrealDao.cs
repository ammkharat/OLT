using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMontrealDao: AbstractManagedDao, IWorkPermitMontrealDao
    {
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IWorkPermitMontrealTemplateDao templateDao;
        private readonly IPermitAttributeDao attributeDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitMontrealGroupDao groupDao;

        public WorkPermitMontrealDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            templateDao = DaoRegistry.GetDao<IWorkPermitMontrealTemplateDao>();
            attributeDao = DaoRegistry.GetDao<IPermitAttributeDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitMontrealGroupDao>();
        }

        private const string UpdateStoredProcedure = "UpdateWorkPermitMontreal";
        private const string InsertStoredProcedure = "InsertWorkPermitMontreal";
        private const string InsertPermitAttributeAssociationStoredProcedure = "InsertWorkPermitMontrealPermitAttributeAssociation";
        private const string InsertWorkPermitFunctionalLocationStoredProcedure = "InsertWorkPermitMontrealFunctionalLocation";
        private const string RemoveStoredProcedure = "RemoveWorkPermitMontreal";
        private const string DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId = "DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId";
        private const string QueryDoesPermitRequestMontrealAssociationExist = "QueryDoesPermitRequestMontrealAssociationExist";
        private const string QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount = "QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount";
        private const string InsertWorkPermitMontrealUserReadDocumentLinkAssociationStoredProcedure = "InsertWorkPermitMontrealUserReadDocumentLinkAssociation";
        
        public WorkPermitMontreal QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitMontreal>(id, PopulateInstance, "QueryWorkPermitMontrealById");
        }

        private WorkPermitMontreal PopulateInstance(SqlDataReader reader)
        {
            long workPermitId = reader.Get<long>("Id");
            long? permitNumber = reader.Get<long?>("PermitNumber");

            DataSource dataSource = DataSource.GetById(reader.Get<int>("SourceId"));

            int workPermitStatusId = reader.Get<int>("WorkPermitStatusId");
            PermitRequestBasedWorkPermitStatus status = PermitRequestBasedWorkPermitStatus.Get(workPermitStatusId);

            int workPermitTypeId = reader.Get<int>("WorkPermitTypeId");
            WorkPermitMontrealType type = WorkPermitMontrealType.Get(workPermitTypeId);

            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            string workOrderNumber = reader.Get<string>("WorkOrderNumber");
            string trade = reader.Get<string>("Trade");
            string description = reader.Get<string>("Description");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            WorkPermitMontrealTemplate template = null;
            int? templateId = reader.Get<int?>("TemplateId");
            if (templateId.HasValue)
            {
                template = templateDao.QueryById(templateId.Value);
            }

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            User createdBy = userDao.QueryById(createdByUserId);

            long lastModifiedUserId = reader.Get<long>("LastModifiedByUserId");
            User lastModifiedUser = userDao.QueryById(lastModifiedUserId);

            List<FunctionalLocation> functionalLocations = functionalLocationDao.QueryByWorkPermitMontrealId(workPermitId);

            long? requestedByGroupId = reader.Get<long?>("RequestedByGroupId");
            WorkPermitMontrealGroup requestedByGroup = null;
            if (requestedByGroupId.HasValue)
            {
                requestedByGroup = groupDao.QueryById(requestedByGroupId.Value);    
            }
          

            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");

            WorkPermitMontreal workPermitMontreal = new WorkPermitMontreal(workPermitId, permitNumber, dataSource, status, type,
                                                                           template, startDateTime, endDateTime, functionalLocations,
                                                                           workOrderNumber, trade, description, createdDateTime, createdBy,
                                                                           lastModifiedDateTime, lastModifiedUser, requestedByGroup, issuedDateTime);

            workPermitMontreal.UsePreviousPermitAnswered = reader.Get<bool>("UsePreviousPermitAnswered");


            // Put the rest of the stuff.
            PopulateDetails(reader, workPermitMontreal);
            PopulateRequestDetails(reader, workPermitMontreal);
            workPermitMontreal.DocumentLinks = documentLinkDao.QueryByWorkPermitMontrealId(workPermitId);

            return workPermitMontreal;
        }

        private static void PopulateDetails(SqlDataReader reader, WorkPermitMontreal workPermitMontreal)
        {
            workPermitMontreal.H2S = reader.Get<bool>("H2S");
            workPermitMontreal.Hydrocarbure = reader.Get<bool>("Hydrocarbure");
            workPermitMontreal.Ammoniaque = reader.Get<bool>("Ammoniaque");
            bool corrosif = reader.Get<bool>("Corrosif");
            string corrosifValue = reader.Get<string>("CorrosifValue");
            workPermitMontreal.Corrosif = new TernaryString(corrosif, corrosifValue);

            bool aromatique = reader.Get<bool>("Aromatique");
            string aromatiqueValue = reader.Get<string>("AromatiqueValue");
            workPermitMontreal.Aromatique = new TernaryString(aromatique, aromatiqueValue);

            bool autresSubstances = reader.Get<bool>("AutresSubstances");
            string autresSubstancesValue = reader.Get<string>("AutresSubstancesValue");
            workPermitMontreal.AutresSubstances = new TernaryString(autresSubstances, autresSubstancesValue);

            workPermitMontreal.ObtureOuDebranche = reader.Get<bool>("ObtureOuDebranche");
            workPermitMontreal.DepressuriseEtVidange = reader.Get<bool>("DepressuriseEtVidange");
            workPermitMontreal.EnPresenceDeGazInerte = reader.Get<bool>("EnPresenceDeGazInerte");
            workPermitMontreal.PurgeALaVapeur = reader.Get<bool>("PurgeALaVapeur");
            workPermitMontreal.RinceALeau = reader.Get<bool>("RinceALeau");
            workPermitMontreal.Excavation = reader.Get<bool>("Excavation");

            bool dessinsRequis = reader.Get<bool>("DessinsRequis");
            string dessinsRequisValue = reader.Get<string>("DessinsRequisValue");
            workPermitMontreal.DessinsRequis = new TernaryString(dessinsRequis, dessinsRequisValue);

            workPermitMontreal.CablesChauffantsMisHorsTension = reader.Get<bool>("CablesChauffantsMisHorsTension");
            workPermitMontreal.PompeOuVerinPneumatique = reader.Get<bool>("PompeOuVerinPneumatique");
            workPermitMontreal.ChaineEtCadenasseOuScelle = reader.Get<bool>("ChaineEtCadenasseOuScelle");
            workPermitMontreal.InterrupteursElectriquesVerrouilles = reader.Get<bool>("InterrupteursElectriquesVerrouilles");
            workPermitMontreal.PurgeParUnGazInerte = reader.Get<bool>("PurgeParUnGazInerte");
            workPermitMontreal.OutilsElectriquesOuABatteries = reader.Get<bool>("OutilsElectriquesOuABatteries");

            bool boiteEnergieZero = reader.Get<bool>("BoiteEnergieZero");
            string boiteEnergieZeroValue = reader.Get<string>("BoiteEnergieZeroValue");
            workPermitMontreal.BoiteEnergieZero = new TernaryString(boiteEnergieZero, boiteEnergieZeroValue);

            workPermitMontreal.OutilsPneumatiques = reader.Get<bool>("OutilsPneumatiques");
            workPermitMontreal.MoteurACombustionInterne = reader.Get<bool>("MoteurACombustionInterne");
            workPermitMontreal.TravauxSuperPoses = reader.Get<bool>("TravauxSuperPoses");

            bool formulaireDespaceClosAffiche = reader.Get<bool>("FormulaireDespaceClosAffiche");
            string formulaireDespaceClosAfficheValue = reader.Get<string>("FormulaireDespaceClosAfficheValue");
            workPermitMontreal.FormulaireDespaceClosAffiche = new TernaryString(formulaireDespaceClosAffiche,
                                                                                formulaireDespaceClosAfficheValue);

            workPermitMontreal.ExisteIlUneAnalyseDeTache = reader.Get<bool>("ExisteIlUneAnalyseDeTache");
            workPermitMontreal.PossibiliteDeSulfureDeFer = reader.Get<bool>("PossibiliteDeSulfureDeFer");
            workPermitMontreal.AereVentile = reader.Get<bool>("AereVentile");
            workPermitMontreal.SoudureALelectricite = reader.Get<bool>("SoudureALelectricite");
            workPermitMontreal.BrulageAAcetylene = reader.Get<bool>("BrulageAAcetylene");
            workPermitMontreal.Nacelle = reader.Get<bool>("Nacelle");

            bool autreConditions = reader.Get<bool>("AutreConditions");
            string autreConditionsValue = reader.Get<string>("AutreConditionsValue");
            workPermitMontreal.AutreConditions = new TernaryString(autreConditions, autreConditionsValue);

            workPermitMontreal.LunettesMonocoques = reader.Get<bool>("LunettesMonocoques");
            workPermitMontreal.HarnaisDeSecurite = reader.Get<bool>("HarnaisDeSecurite");
            workPermitMontreal.EcranFacial = reader.Get<bool>("EcranFacial");
            workPermitMontreal.ProtectionAuditive = reader.Get<bool>("ProtectionAuditive");
            workPermitMontreal.Trepied = reader.Get<bool>("Trepied");
            workPermitMontreal.DispositifAntichute = reader.Get<bool>("DispositifAntichute");

            bool protectionRespiratoire = reader.Get<bool>("ProtectionRespiratoire");
            string protectionRespiratoireValue = reader.Get<string>("ProtectionRespiratoireValue");
            workPermitMontreal.ProtectionRespiratoire = new TernaryString(protectionRespiratoire, protectionRespiratoireValue);

            bool habits = reader.Get<bool>("Habits");
            string habitsValue = reader.Get<string>("HabitsValue");
            workPermitMontreal.Habits = new TernaryString(habits, habitsValue);

            bool autreProtection = reader.Get<bool>("AutreProtection");
            string autreProtectionValue = reader.Get<string>("AutreProtectionValue");
            workPermitMontreal.AutreProtection = new TernaryString(autreProtection, autreProtectionValue);

            workPermitMontreal.Extincteur = reader.Get<bool>("Extincteur");
            workPermitMontreal.BouchesDegoutProtegees = reader.Get<bool>("BouchesDegoutProtegees");
            workPermitMontreal.CouvertureAntiEtincelles = reader.Get<bool>("CouvertureAntiEtincelles");
            workPermitMontreal.SurveillantPouretincelles = reader.Get<bool>("SurveillantPouretincelles");
            workPermitMontreal.PareEtincelles = reader.Get<bool>("PareEtincelles");
            workPermitMontreal.MiseAlaTerrePresDuLieuDeTravail = reader.Get<bool>("MiseAlaTerrePresDuLieuDeTravail");
            workPermitMontreal.BoyauAVapeur = reader.Get<bool>("BoyauAVapeur");

            bool autresEquipementDincendie = reader.Get<bool>("AutresEquipementDincendie");
            string autresEquipementDincendieValue = reader.Get<string>("AutresEquipementDincendieValue");
            workPermitMontreal.AutresEquipementDincendie = new TernaryString(autresEquipementDincendie,
                                                                             autresEquipementDincendieValue);

            workPermitMontreal.Ventulateur = reader.Get<bool>("Ventulateur");
            workPermitMontreal.Barrieres = reader.Get<bool>("Barrieres");

            bool surveillant = reader.Get<bool>("Surveillant");
            string surveillantValue = reader.Get<string>("SurveillantValue");
            workPermitMontreal.Surveillant = new TernaryString(surveillant, surveillantValue);

            workPermitMontreal.RadioEmetteur = reader.Get<bool>("RadioEmetteur");
            workPermitMontreal.PerimetreDeSecurite = reader.Get<bool>("PerimetreDeSecurite");

            bool detectionContinueDesGaz = reader.Get<bool>("DetectionContinueDesGaz");
            string detectionContinueDesGazValue = reader.Get<string>("DetectionContinueDesGazValue");
            workPermitMontreal.DetectionContinueDesGaz = new TernaryString(detectionContinueDesGaz, detectionContinueDesGazValue);

            workPermitMontreal.KlaxonSonore = reader.Get<bool>("KlaxonSonore");
            workPermitMontreal.Localiser = reader.Get<bool>("Localiser");
            workPermitMontreal.Amiante = reader.Get<bool>("Amiante");

            bool autreEquipementsSecurite = reader.Get<bool>("AutreEquipementsSecurite");
            string autreEquipementsSecuriteValue = reader.Get<string>("AutreEquipementsSecuriteValue");
            workPermitMontreal.AutreEquipementsSecurite = new TernaryString(autreEquipementsSecurite,
                                                                            autreEquipementsSecuriteValue);

            workPermitMontreal.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");
            workPermitMontreal.SignatureOperateurSurLeTerrain = reader.Get<bool>("SignatureOperateurSurLeTerrain");
            workPermitMontreal.DetectionDesGazs = reader.Get<bool>("DetectionDesGazs");
            workPermitMontreal.SignatureContremaitre = reader.Get<bool>("SignatureContremaitre");
            workPermitMontreal.SignatureAutorise = reader.Get<bool>("SignatureAutorise");
            workPermitMontreal.NettoyageTransfertHorsSite = reader.Get<bool>("NettoyageTransfertHorsSite");
        }

        private void PopulateRequestDetails(SqlDataReader reader, WorkPermitMontreal workPermitMontreal)
        {
            workPermitMontreal.RequestedDateTime = reader.Get<DateTime?>("RequestedDateTime");
            long? userId = reader.Get<long?>("RequestedByUserId");
            if (userId.HasValue)
            {
                workPermitMontreal.RequestedByUser = userDao.QueryById(userId.Value);
            }
            workPermitMontreal.Company = reader.Get<string>("Company");
            workPermitMontreal.Supervisor = reader.Get<string>("Supervisor");
            workPermitMontreal.ExcavationNumber = reader.Get<string>("ExcavationNumber");
            workPermitMontreal.Attributes.AddRange(attributeDao.QueryByWorKPermitMontreal(workPermitMontreal));
        }

        public WorkPermitMontreal Insert(WorkPermitMontreal workPermit, long? permitRequestId)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            if (permitRequestId.HasValue)
            {
                command.AddParameter("@PermitRequestId", permitRequestId);
            }
            command.Insert(workPermit, AddInsertParameters, InsertStoredProcedure);
            workPermit.Id = (long)idParameter.Value;
            SetPermitNumber(workPermit, permitNumberParameter);

            InsertPermitAttributeAssociation(command, workPermit);
            InsertFunctionalLocations(command, workPermit);
            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            return workPermit;
        }

        public WorkPermitMontreal InsertTemplate(WorkPermitMontreal workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertWorkPermitTemplate");
            //InserttTemplateCategory(workPermit);

            return workPermit;
        }

        private static void AddInsertParametersForTemplate(WorkPermitMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.IdValue);
            command.AddParameter("@PermitNumber", workPermit.PermitNumber);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@IsTemplate", workPermit.IsTemplate);
            command.AddParameter("@CreatedByUser", workPermit.TemplateCreatedBy);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@WorkPermitType", workPermit.WorkPermitType.Name);
            command.AddParameter("@Description", workPermit.Description);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@SiteId", 9);

        }

        public WorkPermitMontreal QueryByIdTemplate(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<WorkPermitMontreal>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryWorkPermitTemplateNameandCategory");
        }
        private WorkPermitMontreal PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            WorkPermitMontreal workPermit = new WorkPermitMontreal(templateName, categories);

            return workPermit;

        }

        private void InsertFunctionalLocations(SqlCommand command, WorkPermitMontreal workPermit)
        {
            if (!workPermit.FunctionalLocations.IsEmpty())
            {
                command.CommandText = InsertWorkPermitFunctionalLocationStoredProcedure;
                foreach (FunctionalLocation functionalLocation in workPermit.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@WorkPermitMontrealId",  workPermit.Id);
                    command.AddParameter("@FunctionalLocationId",  functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void InsertPermitAttributeAssociation(SqlCommand command, WorkPermitMontreal workPermit)
        {
            if (workPermit.Attributes.Count > 0)
            {
                command.CommandText = InsertPermitAttributeAssociationStoredProcedure;
                foreach (PermitAttribute attribute in workPermit.Attributes)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@WorkPermitMontrealId",  workPermit.Id);
                    command.AddParameter("@PermitAttributeId",  attribute.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(WorkPermitMontreal workPermit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermit.Id);
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            command.Update(workPermit, AddUpdateParameters, UpdateStoredProcedure);
            SetPermitNumber(workPermit, permitNumberParameter);
            UpdateFunctionalLocations(command, workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }

        private void UpdateFunctionalLocations(SqlCommand command, WorkPermitMontreal workPermit)
        {
            command.CommandText = DeleteWorkPermitMontrealFunctionalLocationsByWorkPermitMontrealId;
            command.Parameters.Clear();
            command.AddParameter("@WorkPermitMontrealId",  workPermit.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, workPermit);
        }

        private static void AddInsertOrUpdateParameters(WorkPermitMontreal workPermit, SqlCommand command)
        {
            WorkPermitMontrealTemplate template = workPermit.Template;
			
            if (template != null && template.Id.HasValue)
            {
                command.AddParameter("TemplateId", template.IdValue);
            }

            command.AddParameter("WorkPermitTypeId", workPermit.WorkPermitType.IdValue);
            command.AddParameter("WorkPermitStatusId", workPermit.WorkPermitStatus.IdValue);
            command.AddParameter("RequestedByGroupId", workPermit.RequestedByGroup == null ? null : workPermit.RequestedByGroup.Id);
            command.AddParameter("StartDateTime", workPermit.StartDateTime);
            command.AddParameter("EndDateTime", workPermit.EndDateTime);

            if (workPermit.WorkOrderNumber.HasValue())
            {
                command.AddParameter("WorkOrderNumber", workPermit.WorkOrderNumber);
            }

            command.AddParameter("Trade", workPermit.Trade);
            command.AddParameter("Description", workPermit.Description);

            command.AddParameter("LastModifiedDateTime", workPermit.LastModifiedDateTime);
            command.AddParameter("LastModifiedByUserId", workPermit.LastModifiedBy.IdValue);

            command.AddParameter("IssuedDateTime", workPermit.IssuedDateTime);

            command.AddParameter("H2S", workPermit.H2S);
            command.AddParameter("Hydrocarbure", workPermit.Hydrocarbure);
            command.AddParameter("Ammoniaque", workPermit.Ammoniaque);
            command.AddParameter("Corrosif", workPermit.Corrosif.StateAsBool);
            command.AddParameter("CorrosifValue", workPermit.Corrosif.Text);
            command.AddParameter("Aromatique", workPermit.Aromatique.StateAsBool);
            command.AddParameter("AromatiqueValue", workPermit.Aromatique.Text);
            command.AddParameter("AutresSubstances", workPermit.AutresSubstances.StateAsBool);
            command.AddParameter("AutresSubstancesValue", workPermit.AutresSubstances.Text);

            command.AddParameter("ObtureOuDebranche", workPermit.ObtureOuDebranche);
            command.AddParameter("DepressuriseEtVidange", workPermit.DepressuriseEtVidange);
            command.AddParameter("EnPresenceDeGazInerte", workPermit.EnPresenceDeGazInerte);
            command.AddParameter("PurgeALaVapeur", workPermit.PurgeALaVapeur);
            command.AddParameter("RinceALeau", workPermit.RinceALeau);
            command.AddParameter("Excavation", workPermit.Excavation);
            command.AddParameter("DessinsRequis", workPermit.DessinsRequis.StateAsBool);
            command.AddParameter("DessinsRequisValue", workPermit.DessinsRequis.Text);
            command.AddParameter("CablesChauffantsMisHorsTension", workPermit.CablesChauffantsMisHorsTension);
            command.AddParameter("PompeOuVerinPneumatique", workPermit.PompeOuVerinPneumatique);

            command.AddParameter("ChaineEtCadenasseOuScelle", workPermit.ChaineEtCadenasseOuScelle);
            command.AddParameter("InterrupteursElectriquesVerrouilles", workPermit.InterrupteursElectriquesVerrouilles);
            command.AddParameter("PurgeParUnGazInerte", workPermit.PurgeParUnGazInerte);
            command.AddParameter("OutilsElectriquesOuABatteries", workPermit.OutilsElectriquesOuABatteries);
            command.AddParameter("BoiteEnergieZero", workPermit.BoiteEnergieZero.StateAsBool);
            command.AddParameter("BoiteEnergieZeroValue", workPermit.BoiteEnergieZero.Text);
            command.AddParameter("OutilsPneumatiques", workPermit.OutilsPneumatiques);
            command.AddParameter("MoteurACombustionInterne", workPermit.MoteurACombustionInterne);
            command.AddParameter("TravauxSuperPoses", workPermit.TravauxSuperPoses);

            command.AddParameter("FormulaireDespaceClosAffiche", workPermit.FormulaireDespaceClosAffiche.StateAsBool);
            command.AddParameter("FormulaireDespaceClosAfficheValue", workPermit.FormulaireDespaceClosAffiche.Text);
            command.AddParameter("ExisteIlUneAnalyseDeTache", workPermit.ExisteIlUneAnalyseDeTache);
            command.AddParameter("PossibiliteDeSulfureDeFer", workPermit.PossibiliteDeSulfureDeFer);
            command.AddParameter("AereVentile", workPermit.AereVentile);
            command.AddParameter("SoudureALelectricite", workPermit.SoudureALelectricite);
            command.AddParameter("BrulageAAcetylene", workPermit.BrulageAAcetylene);
            command.AddParameter("Nacelle", workPermit.Nacelle);
            command.AddParameter("AutreConditions", workPermit.AutreConditions.StateAsBool);
            command.AddParameter("AutreConditionsValue", workPermit.AutreConditions.Text);
            command.AddParameter("UsePreviousPermitAnswered", workPermit.UsePreviousPermitAnswered);
        
            command.AddParameter("LunettesMonocoques", workPermit.LunettesMonocoques);
            command.AddParameter("HarnaisDeSecurite", workPermit.HarnaisDeSecurite);
            command.AddParameter("EcranFacial", workPermit.EcranFacial);
            command.AddParameter("ProtectionAuditive", workPermit.ProtectionAuditive);
            command.AddParameter("Trepied", workPermit.Trepied);
            command.AddParameter("DispositifAntichute", workPermit.DispositifAntichute);
            command.AddParameter("ProtectionRespiratoire", workPermit.ProtectionRespiratoire.StateAsBool);
            command.AddParameter("ProtectionRespiratoireValue", workPermit.ProtectionRespiratoire.Text);
            command.AddParameter("Habits", workPermit.Habits.StateAsBool);
            command.AddParameter("HabitsValue", workPermit.Habits.Text);
            command.AddParameter("AutreProtection", workPermit.AutreProtection.StateAsBool);
            command.AddParameter("AutreProtectionValue", workPermit.AutreProtection.Text);

            command.AddParameter("Extincteur", workPermit.Extincteur);
            command.AddParameter("BouchesDegoutProtegees", workPermit.BouchesDegoutProtegees);
            command.AddParameter("CouvertureAntiEtincelles", workPermit.CouvertureAntiEtincelles);
            command.AddParameter("SurveillantPouretincelles", workPermit.SurveillantPouretincelles);
            command.AddParameter("PareEtincelles", workPermit.PareEtincelles);
            command.AddParameter("MiseAlaTerrePresDuLieuDeTravail", workPermit.MiseAlaTerrePresDuLieuDeTravail);
            command.AddParameter("BoyauAVapeur", workPermit.BoyauAVapeur);
            command.AddParameter("AutresEquipementDincendie", workPermit.AutresEquipementDincendie.StateAsBool);
            command.AddParameter("AutresEquipementDincendieValue", workPermit.AutresEquipementDincendie.Text);

            command.AddParameter("Ventulateur", workPermit.Ventulateur);
            command.AddParameter("Barrieres", workPermit.Barrieres);
            command.AddParameter("Surveillant", workPermit.Surveillant.StateAsBool);
            command.AddParameter("SurveillantValue", workPermit.Surveillant.Text);
            command.AddParameter("RadioEmetteur", workPermit.RadioEmetteur);
            command.AddParameter("PerimetreDeSecurite", workPermit.PerimetreDeSecurite);
            command.AddParameter("DetectionContinueDesGaz", workPermit.DetectionContinueDesGaz.StateAsBool);
            command.AddParameter("DetectionContinueDesGazValue", workPermit.DetectionContinueDesGaz.Text);
            command.AddParameter("KlaxonSonore", workPermit.KlaxonSonore);
            command.AddParameter("Localiser", workPermit.Localiser);
            command.AddParameter("Amiante", workPermit.Amiante);
            command.AddParameter("AutreEquipementsSecurite", workPermit.AutreEquipementsSecurite.StateAsBool);
            command.AddParameter("AutreEquipementsSecuriteValue", workPermit.AutreEquipementsSecurite.Text);

            command.AddParameter("InstructionsSpeciales", workPermit.InstructionsSpeciales);
            command.AddParameter("SignatureOperateurSurLeTerrain", workPermit.SignatureOperateurSurLeTerrain);
            command.AddParameter("DetectionDesGazs", workPermit.DetectionDesGazs);
            command.AddParameter("SignatureContremaitre", workPermit.SignatureContremaitre);
            command.AddParameter("SignatureAutorise", workPermit.SignatureAutorise);
            command.AddParameter("NettoyageTransfertHorsSite", workPermit.NettoyageTransfertHorsSite);
        }

        private static void AddInsertParameters(WorkPermitMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", 
                workPermit.WorkPermitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id);                
            
            command.AddParameter("SourceId", workPermit.DataSource.Id);

            if (workPermit.RequestedDateTime.HasValue)
            {
                command.AddParameter("RequestedDateTime", workPermit.RequestedDateTime.Value);
            }
            if (workPermit.RequestedByUser != null)
            {
                command.AddParameter("RequestedByUserId", workPermit.RequestedByUser.IdValue);                
            }
            command.AddParameter("@Company", workPermit.Company);
            command.AddParameter("@Supervisor", workPermit.Supervisor);
            command.AddParameter("@ExcavationNumber", workPermit.ExcavationNumber);

            command.AddParameter("CreatedDateTime", workPermit.CreatedDateTime);
            command.AddParameter("CreatedByUserId", workPermit.CreatedBy.IdValue);
            command.AddParameter("ClonedFormDetailMontreal", workPermit.ClonedFormDetailMontreal); // Added by Vibhor : DMND0011077 - Work Permit Clone History

            AddInsertOrUpdateParameters(workPermit, command);
        }


        private static void AddUpdateParameters(WorkPermitMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", workPermit.PermitNumber == null);
            AddInsertOrUpdateParameters(workPermit, command);
        }

        private static void SetPermitNumber(WorkPermitMontreal workPermit, SqlParameter permitNumberParameter)
        {
            if (permitNumberParameter.Value == DBNull.Value)
            {
                workPermit.PermitNumber = null;
            }
            else
            {
                workPermit.PermitNumber = (long)permitNumberParameter.Value;
            }
        }

        public void Remove(WorkPermitMontreal workPermit)
        {
            ManagedCommand.Remove(workPermit, RemoveStoredProcedure);
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(WorkPermitMontreal workPermit)
        {
            string spname = "RemoveWorkPermitTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(WorkPermitMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public WorkPermitMontreal UpdateTemplate(WorkPermitMontreal workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdateWorkPermitTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(WorkPermitMontreal workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);

        }

        public bool DoesPermitRequestMontrealAssociationExist(List<PermitRequestMontrealDTO> permitRequests, Date workPermitStartDate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStartDate", workPermitStartDate.ToDateTimeAtStartOfDay());
            
            string permitRequestIds = permitRequests.BuildIdStringFromList();
            command.AddParameter("@PermitRequestIds", permitRequestIds);

            int count = command.GetCount(QueryDoesPermitRequestMontrealAssociationExist);

            return count > 0;
        }

        public bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMontrealId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            int count = command.GetCount(QueryWorkPermitMontrealUserReadDocumentLinkAssociationCount);
            return count > 0;
        }

        public void InsertWorkPermitMontrealUserReadDocumentLinkAssociation(long userId, long workPermitMontrealId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = InsertWorkPermitMontrealUserReadDocumentLinkAssociationStoredProcedure;
            command.Parameters.Clear();
            command.AddParameter("@UserId", userId);
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            command.ExecuteNonQuery();
        }

        public WorkPermitMontreal QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMontreal permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", permit.IdValue);
            return command.QueryForSingleResult<WorkPermitMontreal>(PopulateInstance, "QueryWorkPermitMontrealForReuse");
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByWorkPermitMontrealId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedWorkPermitMontreal);
        }

    }
}