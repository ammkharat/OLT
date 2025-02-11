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
    public class WorkPermitMudsDao: AbstractManagedDao, IWorkPermitMudsDao
    {
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IWorkPermitMudsTemplateDao templateDao;
        //private readonly IPermitAttributeDao attributeDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitMudsGroupDao groupDao;
        private readonly IGasTestElementDao gasTestElementDao;
        public WorkPermitMudsDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            templateDao = DaoRegistry.GetDao<IWorkPermitMudsTemplateDao>();
            //attributeDao = DaoRegistry.GetDao<IPermitAttributeDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitMudsGroupDao>();
            gasTestElementDao = DaoRegistry.GetDao<IGasTestElementDao>();
        }

        private const string UpdateStoredProcedure = "UpdateWorkPermitMuds";
        private const string InsertStoredProcedure = "InsertWorkPermitMuds";
        private const string InsertPermitAttributeAssociationStoredProcedure = "InsertWorkPermitMudsPermitAttributeAssociation";
        private const string InsertWorkPermitFunctionalLocationStoredProcedure = "InsertWorkPermitMudsFunctionalLocation";
        private const string RemoveStoredProcedure = "RemoveWorkPermitMuds";
        private const string DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId = "DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId";
        private const string QueryDoesPermitRequestMudsAssociationExist = "QueryDoesPermitRequestMudsAssociationExist";
        private const string QueryWorkPermitMudsUserReadDocumentLinkAssociationCount = "QueryWorkPermitMudsUserReadDocumentLinkAssociationCount";
        private const string InsertWorkPermitMudsUserReadDocumentLinkAssociationStoredProcedure = "InsertWorkPermitMudsUserReadDocumentLinkAssociation";
        
        public WorkPermitMuds QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitMuds>(id, PopulateInstance, "QueryWorkPermitMudsById");
        }
        public WorkPermitMuds QueryByIdTemplate(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<WorkPermitMuds>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryWorkPermitTemplateNameandCategory");
        }

        private WorkPermitMuds PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");


            WorkPermitMuds workPermitMuds = new WorkPermitMuds(templateName, categories);

            return workPermitMuds;

        }




        private WorkPermitMuds PopulateInstance(SqlDataReader reader)
        {
            long workPermitId = reader.Get<long>("Id");
            long? permitNumber = reader.Get<long?>("PermitNumber");

            DataSource dataSource = DataSource.GetById(reader.Get<int>("SourceId"));

            int workPermitStatusId = reader.Get<int>("WorkPermitStatusId");
            PermitRequestBasedWorkPermitStatus status = PermitRequestBasedWorkPermitStatus.Get(workPermitStatusId);

            int workPermitTypeId = reader.Get<int>("WorkPermitTypeId");
            WorkPermitMudsType type = WorkPermitMudsType.Get(workPermitTypeId);

            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");
            string workOrderNumber = reader.Get<string>("WorkOrderNumber");
            string trade = reader.Get<string>("Trade");
            string description = reader.Get<string>("Description");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            string ClonedFormDetailMuds = reader.Get<string>("ClonedFormDetailMuds"); // Added by Vibhor : DMND0011077 - Work Permit Clone History
            //Added by ppanigrahi
            long  WorkpermitClosedById = reader.Get<long>("WorkpermitClosedById");
            long ActionItemCloseById = reader.Get<long>("ActionItemCloseById");
           
            
            string nbTravail = reader.Get<string>("NbTravail");
            bool formationCheck = reader.Get<bool>("FormationCheck");
            string nomsEnt = reader.Get<string>("NomsEnt");
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            string nomsEnt_1 = reader.Get<string>("NomsEnt_1");
            string nomsEnt_2 = reader.Get<string>("NomsEnt_2");
            string nomsEnt_3 = reader.Get<string>("NomsEnt_3");
            string surveilant = reader.Get<string>("Surveilant");

            WorkPermitMudsTemplate template = null;
            int? templateId = reader.Get<int?>("TemplateId");
            if (templateId.HasValue)
            {
                template = templateDao.QueryById(templateId.Value);
            }

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            User createdBy = userDao.QueryById(createdByUserId);

            long lastModifiedUserId = reader.Get<long>("LastModifiedByUserId");
            User lastModifiedUser = userDao.QueryById(lastModifiedUserId);

            List<FunctionalLocation> functionalLocations = functionalLocationDao.QueryByWorkPermitMudsId(workPermitId);

            //long? requestedByGroupId = reader.Get<long?>("RequestedByGroupId");
            WorkPermitMudsGroup requestedByGroup = null;
            //if (requestedByGroupId.HasValue)
            //{
            //    requestedByGroup = groupDao.QueryById(requestedByGroupId.Value);    
            //}

            string requestedByGroupText = reader.Get<string>("RequestedByGroupId");

            DateTime? issuedDateTime = reader.Get<DateTime?>("IssuedDateTime");

            User WorkpermitClosedBy=null;
            User ActionItemCloseBy=null ;
            string WorkPermitCloseComment = null;
            bool? ActionItemCheckboxchecked = reader.Get<bool?>("ActionItemCheckboxchecked");
           DateTime? ActionItemCloseDateTime = reader.Get<DateTime?>("ActionItemCloseDateTime");
            DateTime? PermitCloseDateTime = reader.Get<DateTime?>("PermitCloseDateTime");
            if (WorkpermitClosedById != null)
            {
               WorkpermitClosedBy = userDao.QueryById(WorkpermitClosedById);
            }
            if (ActionItemCloseById != null)
            {
                ActionItemCloseBy = userDao.QueryById(ActionItemCloseById);
            }
            if (reader.Get<string>("WorkPermitCloseComments") != null)
            {
                WorkPermitCloseComment = reader.Get<string>("WorkPermitCloseComments");
            }
            

            WorkPermitMuds workPermitMuds = new WorkPermitMuds(workPermitId, permitNumber, dataSource, status, type,
                                                                          template, startDateTime, endDateTime, functionalLocations,
                                                                          workOrderNumber, trade, description, createdDateTime, createdBy,
                                                                          lastModifiedDateTime, lastModifiedUser, requestedByGroup, issuedDateTime, requestedByGroupText,
                                                                          nbTravail, formationCheck, nomsEnt, nomsEnt_1, nomsEnt_2, nomsEnt_3, surveilant,WorkPermitCloseComment, WorkpermitClosedById, WorkpermitClosedBy, ActionItemCloseById,ActionItemCloseBy,PermitCloseDateTime,ActionItemCloseDateTime,ActionItemCheckboxchecked);

            workPermitMuds.UsePreviousPermitAnswered = reader.Get<bool>("UsePreviousPermitAnswered");

            
           
           

            // Put the rest of the stuff.
            PopulateDetails(reader, workPermitMuds);
            PopulateRequestDetails(reader, workPermitMuds);
            workPermitMuds.DocumentLinks = documentLinkDao.QueryByWorkPermitMudsId(workPermitId);

            workPermitMuds.ConfinedSpace = DaoRegistry.GetDao<IConfinedSpaceMudsDao>().QueryByConfinedSpaceId(Convert.ToInt64(workPermitMuds.RemplirLeFormulaireDeCondition.Text));

            workPermitMuds.GasTests = PopulateWorkPermitGasTests(reader, workPermitMuds.Id.GetValueOrDefault());
            return workPermitMuds;
        }

        private static void PopulateDetails(SqlDataReader reader, WorkPermitMuds workPermitMuds)
        {
            bool remplirLeFormulaireDeCondition = reader.Get<bool>("RemplirLeFormulaireDeCondition");
            string remplirLeFormulaireDeConditionValue = reader.Get<string>("RemplirLeFormulaireDeConditionValue");
            workPermitMuds.RemplirLeFormulaireDeCondition = new TernaryString(remplirLeFormulaireDeCondition, remplirLeFormulaireDeConditionValue);
            
            workPermitMuds.AnalyseCritiqueDeLaTache = reader.Get<bool>("AnalyseCritiqueDeLaTache");
            workPermitMuds.Depressurises = reader.Get<bool>("Depressurises");
            workPermitMuds.Vides = reader.Get<bool>("Vides");
            workPermitMuds.ContournementDesGda = reader.Get<bool>("ContournementDesGDA");
            workPermitMuds.Rinces = reader.Get<bool>("Rinces");
            workPermitMuds.NettoyesLaVapeur = reader.Get<bool>("NettoyesLaVapeur");
            workPermitMuds.Purges = reader.Get<bool>("Purges");
            workPermitMuds.Ventiles = reader.Get<bool>("Ventiles");
            workPermitMuds.Aeres = reader.Get<bool>("Aeres");
            workPermitMuds.Energies = reader.Get<bool>("Energies"); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            //workPermitMuds.Autres = reader.Get<bool>("Autres");

            bool autresCondition = reader.Get<bool>("AutresCondition");
            string autreseConditionValue = reader.Get<string>("AutresConditionValue");
            workPermitMuds.AutresCondition = new TernaryString(autresCondition, autreseConditionValue);

            //Added by vibhor : INC0513419 - MUDS workpermit
            bool procedureCheckBox = reader.Get<bool>("Procedure");
            string procedureTextBox_Value = reader.Get<string>("ProcedureValue");
            workPermitMuds.ProcedureEntretien = new TernaryString(procedureCheckBox, procedureTextBox_Value);
            //END

            bool procedure = reader.Get<bool>("Procedure");
            string procedureValue = reader.Get<string>("ProcedureValue");
            workPermitMuds.Procedure = new TernaryString(procedure, procedureValue);
            
            bool interrupteursEtVannesCadenasses = reader.Get<bool>("InterrupteursEtVannesCadenasses");
            string interrupteursEtVannesCadenassesValue = reader.Get<string>("InterrupteursEtVannesCadenassesValue");
            workPermitMuds.InterrupteursEtVannesCadenasses = new TernaryString(interrupteursEtVannesCadenasses, interrupteursEtVannesCadenassesValue);

            workPermitMuds.VerrouillagesParTravailleurs = reader.Get<bool>("VerrouillagesParTravailleurs");
            workPermitMuds.SourcesDesenergisees = reader.Get<bool>("SourcesDesenergisees");
            workPermitMuds.DepartsLocauxTestes = reader.Get<bool>("DepartsLocauxTestes");
            workPermitMuds.ConduitesDesaccouplees = reader.Get<bool>("ConduitesDesaccouplees");
            workPermitMuds.ObturateursInstallees = reader.Get<bool>("ObturateursInstallees");
            workPermitMuds.PvciSuncorEffectuee = reader.Get<bool>("PVCISuncorEffectuee");
            workPermitMuds.PvciEntExtEffectuee = reader.Get<bool>("PVCIEntExtEffectuee");

            bool etiquette = reader.Get<bool>("Etiquette");
            string etiquetteValue = reader.Get<string>("EtiquetteValue");
            workPermitMuds.Etiquette = new TernaryString(etiquette, etiquetteValue);

            workPermitMuds.Amiante = reader.Get<bool>("Amiante");
            workPermitMuds.AcideSulfurique = reader.Get<bool>("AcideSulfurique");
            workPermitMuds.Azote = reader.Get<bool>("Azote");
            workPermitMuds.Caustique = reader.Get<bool>("Caustique");
            workPermitMuds.DioxydeDeSoufre = reader.Get<bool>("DioxydeDeSoufre");
            workPermitMuds.Sbs = reader.Get<bool>("SBS");
            workPermitMuds.Soufre = reader.Get<bool>("Soufre");
            workPermitMuds.EquipementsNonRinces = reader.Get<bool>("EquipementsNonRinces");
            workPermitMuds.Hydrocarbures = reader.Get<bool>("Hydrocarbures");
            workPermitMuds.HydrogeneSulfure = reader.Get<bool>("HydrogeneSulfure");
            workPermitMuds.MonoxydeCarbone = reader.Get<bool>("MonoxydeCarbone");
            workPermitMuds.Reflux = reader.Get<bool>("Reflux");
            workPermitMuds.ProduitsVolatilsUtilises = reader.Get<bool>("ProduitsVolatilsUtilises");
            workPermitMuds.Bacteries = reader.Get<bool>("Bacteries");

            bool appareil = reader.Get<bool>("Appareil");
            string appareilValue = reader.Get<string>("AppareilValue");
            workPermitMuds.Appareil = new TernaryString(appareil, appareilValue);
           
            workPermitMuds.InterferencesEntreTravaux = reader.Get<bool>("InterferencesEntreTravaux");
            workPermitMuds.PiecesEnRotation = reader.Get<bool>("PiecesEnRotation");
            workPermitMuds.IncendieExplosion = reader.Get<bool>("IncendieExplosion");
            workPermitMuds.ContrainteThermique = reader.Get<bool>("ContrainteThermique");
            workPermitMuds.Radiations = reader.Get<bool>("Radiations");
            workPermitMuds.Silice = reader.Get<bool>("Silice");
            workPermitMuds.Vanadium = reader.Get<bool>("Vanadium");
            workPermitMuds.AsphyxieIntoxication = reader.Get<bool>("AsphyxieIntoxication");

            bool autresRisques = reader.Get<bool>("AutresRisques");
            string autresRisquesValue = reader.Get<string>("AutresRisquesValue");
            workPermitMuds.AutresRisques = new TernaryString(autresRisques, autresRisquesValue);

            bool electriciteVolt = reader.Get<bool>("ElectriciteVolt");
            string electriciteVoltValue = reader.Get<string>("ElectriciteVoltValue");
            workPermitMuds.ElectriciteVolt = new TernaryString(electriciteVolt, electriciteVoltValue);
            
            //workPermitMuds.OutilDeLaiton = reader.Get<bool>("OutillageElectrique");
            workPermitMuds.OutilDeLaiton = reader.Get<bool>("OutilDeLaiton");


            bool outilManuelEquipementDePrevention = reader.Get<bool>("OutilDeLaitonManel");
            string outilManuelEquipementDePreventionValue = reader.Get<string>("OutilDeLaitonManelValue");
            workPermitMuds.OutilManuelEquipementDePrevention = new TernaryString(outilManuelEquipementDePrevention, outilManuelEquipementDePreventionValue);

            bool perimetreSecurite = reader.Get<bool>("PerimetreSecurite");
            string perimetreSecuriteValue = reader.Get<string>("PerimetreSecuriteValue");
            workPermitMuds.PerimetreDeSecurityEquipementDePrevention = new TernaryString(perimetreSecurite, perimetreSecuriteValue);

            workPermitMuds.TravailEnHauteur6EtPlus = reader.Get<bool>("TravailEnHauteur6EtPlus");
            workPermitMuds.VapeurCondensat = reader.Get<bool>("VapeurCondensat"); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            workPermitMuds.FeSValue = reader.Get<bool>("FeSValue"); 
            

            workPermitMuds.Electrisation = reader.Get<bool>("Electrisation");
            workPermitMuds.LunettesMonocoques = reader.Get<bool>("LunettesMonocoques");
            workPermitMuds.Visiere = reader.Get<bool>("Visiere");
            workPermitMuds.ProtectionAuditive = reader.Get<bool>("ProtectionAuditive");
            //workPermitMuds.ManteauAntiEclaboussure = reader.Get<bool>("ManteauAntiEclaboussure");
            workPermitMuds.CagouleIgnifuge = reader.Get<bool>("CagouleIgnifuge");
            workPermitMuds.Harnais2LiensDeRetenue = reader.Get<bool>("Harnais2LiensDeRetenue");
            //workPermitMuds.MasqueAntiPoussiere = reader.Get<bool>("MasqueAntiPoussiere");
            //workPermitMuds.FiltresParticules = reader.Get<bool>("FiltresParticules");

            bool gants = reader.Get<bool>("Gants");
            string gantsValue = reader.Get<string>("GantsValue");
            workPermitMuds.Gants = new TernaryString(gants, gantsValue);

            bool masqueACartouches = reader.Get<bool>("MasqueACartouches");
            string masqueACartouchesValue = reader.Get<string>("MasqueACartouchesValue");
            workPermitMuds.MasqueACartouches = new TernaryString(masqueACartouches, masqueACartouchesValue);
            workPermitMuds.AppareilEquipementDePrevention = new TernaryString(masqueACartouches, masqueACartouchesValue);

            bool epiAntiArcCat = reader.Get<bool>("EpiAntiArcCat");
            string epiAntiArcCatValue = reader.Get<string>("EpiAntiArcCatValue");
            workPermitMuds.EpiAntiArcCat = new TernaryString(epiAntiArcCat, epiAntiArcCatValue);
            
            bool habitProtecteur = reader.Get<bool>("HabitProtecteur");
            string habitProtecteurValue = reader.Get<string>("HabitProtecteurValue");
            workPermitMuds.HabitProtecteur = new TernaryString(habitProtecteur, habitProtecteurValue);

            //workPermitMuds.HabitCompletAntiEclaboussure = reader.Get<bool>("HabitCompletAntiEclaboussure");
            //workPermitMuds.HabitCouvreToutJetable = reader.Get<bool>("HabitCouvreToutJetable");
            workPermitMuds.EpiAntiChoc = reader.Get<bool>("EPIAntiChoc");
            //workPermitMuds.SystemeDAdductionDAir = reader.Get<bool>("SystemeDAdductionDAir");
            workPermitMuds.EcranDeflecteur = reader.Get<bool>("EcranDeflecteur");
            workPermitMuds.MaltDesEquipements = reader.Get<bool>("MALTDesEquipements");
            workPermitMuds.Rallonges = reader.Get<bool>("Rallonges");
            workPermitMuds.ApprobationPourEquipDeLevage = reader.Get<bool>("ApprobationPourEquipDeLevage");
            workPermitMuds.BarricadeRigide = reader.Get<bool>("BarricadeRigide");

            bool autresE = reader.Get<bool>("AutresE");
            string autresEValue = reader.Get<string>("AutresEValue");
            workPermitMuds.AutresE = new TernaryString(autresE, autresEValue);

            bool alarmeDcs = reader.Get<bool>("AlarmeDCS");
            string alarmeDcsValue = reader.Get<string>("AlarmeDCSValue");
            workPermitMuds.AlarmeDcs = new TernaryString(alarmeDcs, alarmeDcsValue);

            workPermitMuds.EchelleSecurisee = reader.Get<bool>("EchelleSecurisee");
            workPermitMuds.EchafaudageApprouve = reader.Get<bool>("EchafaudageApprouve");
            workPermitMuds.OutilDeLaiton = reader.Get<bool>("OutilDeLaiton");
            workPermitMuds.PerimetreSecurite = reader.Get<bool>("PerimetreSecurite");
            workPermitMuds.Radio = reader.Get<bool>("Radio");
            workPermitMuds.Signaleur = reader.Get<bool>("Signaleur");

            workPermitMuds.OutilDeLaitonPrevention = reader.Get<bool>("OutilDeLaitonManel");
            
            workPermitMuds.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            workPermitMuds.MudsAnswerTextBox = reader.Get<string>("MudsAnswerTextBox");
            workPermitMuds.MudsQuestionlabel = reader.Get<string>("MudsQuestionlabel");

            workPermitMuds.SignatureOperateurSurLeTerrain = reader.Get<bool>("SignatureOperateurSurLeTerrain");
            workPermitMuds.DetectionDesGazs = reader.Get<bool>("DetectionDesGazs");
            workPermitMuds.SignatureContremaitre = reader.Get<bool>("SignatureContremaitre");
            workPermitMuds.SignatureAutorise = reader.Get<bool>("SignatureAutorise");
            workPermitMuds.NettoyageTransfertHorsSite = reader.Get<bool>("NettoyageTransfertHorsSite");


            workPermitMuds.Soudage= reader.Get<bool>("Soudage");
            workPermitMuds.Traitement= reader.Get<bool>("Traitement");
            workPermitMuds.Cuissons= reader.Get<bool>("Cuissons");
            workPermitMuds.Per�age= reader.Get<bool>("Percage");
            workPermitMuds.Chaufferette= reader.Get<bool>("Chaufferette");
            workPermitMuds.Meulage= reader.Get<bool>("Meulage");
            workPermitMuds.Nettoyage= reader.Get<bool>("Nettoyage");

            bool autresTravaux = reader.Get<bool>("AutresTravaux");
            string autresTravauxValue = reader.Get<string>("AutresTravauxValue");
            workPermitMuds.AutresTravaux = new TernaryString(autresTravaux, autresTravauxValue);

            workPermitMuds.TravauxDansZone= reader.Get<bool>("TravauxDansZone");
            workPermitMuds.Combustibles= reader.Get<bool>("Combustibles");
            workPermitMuds.Ecran= reader.Get<bool>("Ecran");
            workPermitMuds.Boyau= reader.Get<bool>("Boyau");
            workPermitMuds.BoyauDe= reader.Get<bool>("BoyauDe");
            workPermitMuds.Couverture= reader.Get<bool>("Couverture");
            workPermitMuds.Extincteur= reader.Get<bool>("Extincteur");
            workPermitMuds.Bouche= reader.Get<bool>("Bouche");
            workPermitMuds.RadioS= reader.Get<bool>("RadioS");
            workPermitMuds.Surveillant= reader.Get<bool>("Surveillant");
            workPermitMuds.UtilisationMoteur= reader.Get<bool>("UtilisationMoteur");
            workPermitMuds.NettoyageAu= reader.Get<bool>("NettoyageAU");
            workPermitMuds.UtilisationElectronics= reader.Get<bool>("UtilisationElectronics");
            workPermitMuds.Radiographie= reader.Get<bool>("Radiographie");
            workPermitMuds.UtilisationOutlis= reader.Get<bool>("UtilisationOutlis");
            workPermitMuds.UtilisationEquipments= reader.Get<bool>("UtilisationEquipments");
            workPermitMuds.Demolition= reader.Get<bool>("Demolition");

            workPermitMuds.OutillageElectrique = reader.Get<bool>("OutillageElectrique");

            

            bool autresInstruction = reader.Get<bool>("AutresInstruction");
            string autresInstructionValue = reader.Get<string>("AutresInstructionValue");
            workPermitMuds.AutresInstruction = new TernaryString(autresInstruction, autresInstructionValue);

            workPermitMuds.EffondrementEnsevelissement = reader.Get<bool>("EffondrementEnsevelissement");
            workPermitMuds.MasqueSoudeur = reader.Get<bool>("MasqueSoudeur");

          

        }

        private void PopulateRequestDetails(SqlDataReader reader, WorkPermitMuds workPermitMuds)
        {
            workPermitMuds.RequestedDateTime = reader.Get<DateTime?>("RequestedDateTime");
            long? userId = reader.Get<long?>("RequestedByUserId");
            if (userId.HasValue)
            {
                workPermitMuds.RequestedByUser = userDao.QueryById(userId.Value);
            }
            workPermitMuds.Company = reader.Get<string>("Company");
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            workPermitMuds.Company_1 = reader.Get<string>("Company_1");
            workPermitMuds.Company_2 = reader.Get<string>("Company_2");
            workPermitMuds.Supervisor = reader.Get<string>("Supervisor");
            workPermitMuds.ExcavationNumber = reader.Get<string>("ExcavationNumber");
            //workPermitMuds.Attributes.AddRange(attributeDao.QueryByWorKPermitMuds(workPermitMuds));
        }

        public WorkPermitMuds Insert(WorkPermitMuds workPermit, long? permitRequestId)
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
            //Added for Muds Gas Test
            if (workPermit.GasTests!=null)
            foreach (GasTestElement element in workPermit.GasTests.Elements)
            {
                gasTestElementDao.InsertMuds(element, workPermit.Id.GetValueOrDefault());
            }

            return workPermit;
        }

        public WorkPermitMuds InsertTemplate(WorkPermitMuds workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertWorkPermitTemplate");

            //InserttTemplateCategory(workPermit);

            return workPermit;
        }

        private static void AddInsertParametersForTemplate(WorkPermitMuds workPermit, SqlCommand command)
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
            command.AddParameter("@SiteId", 16);

        }
        private void InserttTemplateCategory(WorkPermitMuds workpermit)
        {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "InsertTemplateCategory";
                    command.AddParameter("@Id", workpermit.IdValue);
                    command.AddParameter("@SiteId", 16);
                    command.AddParameter("@Categories", workpermit.Categories);
                    command.ExecuteNonQuery();
        }

        private void InsertFunctionalLocations(SqlCommand command, WorkPermitMuds workPermit)
        {
            if (!workPermit.FunctionalLocations.IsEmpty())
            {
                command.CommandText = InsertWorkPermitFunctionalLocationStoredProcedure;
                foreach (FunctionalLocation functionalLocation in workPermit.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@WorkPermitMudsId",  workPermit.Id);
                    command.AddParameter("@FunctionalLocationId",  functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void InsertPermitAttributeAssociation(SqlCommand command, WorkPermitMuds workPermit)
        {
            if (workPermit.Attributes.Count > 0)
            {
                command.CommandText = InsertPermitAttributeAssociationStoredProcedure;
                foreach (PermitAttribute attribute in workPermit.Attributes)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@WorkPermitMudsId",  workPermit.Id);
                    command.AddParameter("@PermitAttributeId",  attribute.Id);
                    command.AddParameter("@WorkPermitTypeId", workPermit.WorkPermitType.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(WorkPermitMuds workPermit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", workPermit.Id);
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            command.Update(workPermit, AddUpdateParameters, UpdateStoredProcedure);
            SetPermitNumber(workPermit, permitNumberParameter);
            UpdateFunctionalLocations(command, workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            foreach (GasTestElement element in workPermit.GasTests.Elements)
            {
                if (element.Id == null)
                    gasTestElementDao.InsertMuds(element, workPermit.Id.GetValueOrDefault());
                else
                    //gasTestElementDao.UpdateMuds(element);
                gasTestElementDao.InsertMuds(element, workPermit.Id.GetValueOrDefault());
            }

        }

        private void UpdateFunctionalLocations(SqlCommand command, WorkPermitMuds workPermit)
        {
            command.CommandText = DeleteWorkPermitMudsFunctionalLocationsByWorkPermitMudsId;
            command.Parameters.Clear();
            command.AddParameter("@WorkPermitMudsId",  workPermit.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, workPermit);
        }

        private static void AddInsertOrUpdateParameters(WorkPermitMuds workPermit, SqlCommand command)
        {
            WorkPermitMudsTemplate template = workPermit.Template;
			
            if (template != null && template.Id.HasValue)
            {
                command.AddParameter("TemplateId", template.IdValue);
            }

            command.AddParameter("WorkPermitTypeId", workPermit.WorkPermitType.IdValue);
            command.AddParameter("WorkPermitStatusId", workPermit.WorkPermitStatus.IdValue);
            //command.AddParameter("RequestedByGroupId", workPermit.RequestedByGroup == null ? null : workPermit.RequestedByGroup.Name);
            command.AddParameter("RequestedByGroupId", workPermit.RequestedByGroupText);
            command.AddParameter("StartDateTime", workPermit.StartDateTime);
            command.AddParameter("EndDateTime", workPermit.EndDateTime);
            //Added ppanigrahi
            if (workPermit.WorkpermitClosedById != null)
            {
                command.AddParameter("WorkpermitClosedById", workPermit.WorkpermitClosedById);
            }
            if (workPermit.ActionItemCloseById != null)
            {
                command.AddParameter("ActionItemCloseById", workPermit.ActionItemCloseById);
            }
            if (workPermit.PermitCloseDateTime != null)
            {
                command.AddParameter("PermitCloseDateTime", workPermit.PermitCloseDateTime);
            }
            if (workPermit.ActionItemCloseDateTime != null)
            {
                command.AddParameter("ActionItemCloseDateTime", workPermit.ActionItemCloseDateTime);
            }
            if (workPermit.ActionItemCheckboxchecked != null)
            {
                command.AddParameter("ActionItemCheckboxchecked", workPermit.ActionItemCheckboxchecked);
            }




            if (workPermit.WorkOrderNumber.HasValue())
            {
                command.AddParameter("WorkOrderNumber", workPermit.WorkOrderNumber);
            }
            if (workPermit.WorkPermitCloseComments.HasValue())
            {
                command.AddParameter("WorkPermitCloseComments", workPermit.WorkPermitCloseComments);
            }

            command.AddParameter("NbTravail", workPermit.NbTravail);
            command.AddParameter("FormationCheck", workPermit.FormationCheck);
            command.AddParameter("NomsEnt", workPermit.NomsEnt);
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            command.AddParameter("NomsEnt_1", workPermit.NomsEnt_1);
            command.AddParameter("NomsEnt_2", workPermit.NomsEnt_2);
            command.AddParameter("NomsEnt_3", workPermit.NomsEnt_3);
            command.AddParameter("Surveilant", workPermit.Surveilant);

            command.AddParameter("Trade", workPermit.Trade);
            command.AddParameter("CompanyName", workPermit.Company);
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            command.AddParameter("CompanyName_1", workPermit.Company_1);
            command.AddParameter("CompanyName_2", workPermit.Company_2);
            command.AddParameter("Description", workPermit.Description);

            command.AddParameter("LastModifiedDateTime", workPermit.LastModifiedDateTime);
            command.AddParameter("LastModifiedByUserId", workPermit.LastModifiedBy.IdValue);

            command.AddParameter("IssuedDateTime", workPermit.IssuedDateTime);

            
            command.AddParameter("RemplirLeFormulaireDeCondition", workPermit.RemplirLeFormulaireDeCondition.StateAsBool);
            command.AddParameter("RemplirLeFormulaireDeConditionValue", workPermit.RemplirLeFormulaireDeCondition.Text);
            command.AddParameter("AnalyseCritiqueDeLaTache", workPermit.AnalyseCritiqueDeLaTache);
            command.AddParameter("Depressurises", workPermit.Depressurises);
            command.AddParameter("Vides", workPermit.Vides);
            command.AddParameter("ContournementDesGDA", workPermit.ContournementDesGda);
            command.AddParameter("Rinces", workPermit.Rinces);
            command.AddParameter("NettoyesLaVapeur", workPermit.NettoyesLaVapeur);
            command.AddParameter("Purges", workPermit.Purges);
            command.AddParameter("Ventiles", workPermit.Ventiles);
            command.AddParameter("Aeres", workPermit.Aeres);
            command.AddParameter("Energies", workPermit.Energies); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            command.AddParameter("Procedure", workPermit.ProcedureEntretien.StateAsBool);
            command.AddParameter("ProcedureValue", workPermit.ProcedureEntretien.Text);
            command.AddParameter("AutresCondition", workPermit.AutresConditions.StateAsBool);//Autres
            command.AddParameter("AutresConditionValue", workPermit.AutresConditions.Text);
            command.AddParameter("InterrupteursEtVannesCadenasses", workPermit.InterrupteursEtVannesCadenasses.StateAsBool);
            command.AddParameter("InterrupteursEtVannesCadenassesValue", workPermit.InterrupteursEtVannesCadenasses.Text);
            command.AddParameter("VerrouillagesParTravailleurs", workPermit.VerrouillagesParTravailleurs);
            command.AddParameter("SourcesDesenergisees", workPermit.SourcesDesenergisees);
            command.AddParameter("DepartsLocauxTestes", workPermit.DepartsLocauxTestes);
            command.AddParameter("ConduitesDesaccouplees", workPermit.ConduitesDesaccouplees);
            command.AddParameter("ObturateursInstallees", workPermit.ObturateursInstallees);
            
         //   command.AddParameter("Etiquette", workPermit.EtiquettObturateur.StateAsBool);
            //command.AddParameter("EtiquetteValue", workPermit.EtiquettObturateur.Text);
            if (workPermit.EtiquettObturateur.StateAsBool)
            {
                command.AddParameter("Etiquette", workPermit.EtiquettObturateur.StateAsBool);
            }
            else
            {
                command.AddParameter("Etiquette", workPermit.Etiquette.StateAsBool);
            }
            if (workPermit.EtiquettObturateur.Text != null)
            {
                command.AddParameter("EtiquetteValue", workPermit.EtiquettObturateur.Text);
            }
            else
            {
                command.AddParameter("EtiquetteValue", workPermit.Etiquette.Text);
            }
           
            
            command.AddParameter("PVCISuncorEffectuee", workPermit.PvciSuncorEffectuee);
            command.AddParameter("PVCIEntExtEffectuee", workPermit.PvciEntExtEffectuee);
            command.AddParameter("Amiante", workPermit.Amiante);
            command.AddParameter("AcideSulfurique", workPermit.AcideSulfurique);
            command.AddParameter("Azote", workPermit.Azote);
            command.AddParameter("Caustique", workPermit.Caustique);
            command.AddParameter("DioxydeDeSoufre", workPermit.DioxydeDeSoufre);
            command.AddParameter("SBS", workPermit.Sbs);
            command.AddParameter("Soufre", workPermit.Soufre);
            command.AddParameter("EquipementsNonRinces", workPermit.EquipementsNonRinces);
            command.AddParameter("Hydrocarbures", workPermit.Hydrocarbures);
            command.AddParameter("HydrogeneSulfure", workPermit.HydrogeneSulfure);
            command.AddParameter("MonoxydeCarbone", workPermit.MonoxydeCarbone);
            command.AddParameter("Reflux", workPermit.Reflux);
            command.AddParameter("ProduitsVolatilsUtilises", workPermit.ProduitsVolatilsUtilises);
            command.AddParameter("Bacteries", workPermit.Bacteries);
            command.AddParameter("Appareil", workPermit.Appareil.StateAsBool);
            command.AddParameter("AppareilValue", workPermit.Appareil.Text);
            command.AddParameter("InterferencesEntreTravaux", workPermit.InterferencesEntreTravaux);
            command.AddParameter("PiecesEnRotation", workPermit.PiecesEnRotation);
            command.AddParameter("IncendieExplosion", workPermit.IncendieExplosion);
            command.AddParameter("ContrainteThermique", workPermit.ContrainteThermique);
            command.AddParameter("Radiations", workPermit.Radiations);
            command.AddParameter("Silice", workPermit.Silice);
            command.AddParameter("Vanadium", workPermit.Vanadium);
            command.AddParameter("AsphyxieIntoxication", workPermit.AsphyxieIntoxication);
            command.AddParameter("AutresRisques", workPermit.AutresRisques.StateAsBool);
            command.AddParameter("AutresRisquesValue", workPermit.AutresRisques.Text);
            command.AddParameter("ElectriciteVolt", workPermit.ElectronicVoltRisques.StateAsBool);
            command.AddParameter("ElectriciteVoltValue", workPermit.ElectronicVoltRisques.Text);
            command.AddParameter("OutillageElectrique", workPermit.OutilDeLaiton);
            command.AddParameter("TravailEnHauteur6EtPlus", workPermit.TravailEnHauteur6EtPlus);
            command.AddParameter("VapeurCondensat", workPermit.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            command.AddParameter("FeSValue", workPermit.FeSValue);
            

            command.AddParameter("Electrisation", workPermit.Electrisation);
            command.AddParameter("LunettesMonocoques", workPermit.LunettesMonocoques);
            command.AddParameter("Visiere", workPermit.Visiere);
            command.AddParameter("ProtectionAuditive", workPermit.ProtectionAuditive);
            command.AddParameter("CagouleIgnifuge", workPermit.CagouleIgnifuge);
            command.AddParameter("Harnais2LiensDeRetenue", workPermit.Harnais2LiensDeRetenue);
            command.AddParameter("Gants", workPermit.Gants.StateAsBool);
            command.AddParameter("GantsValue", workPermit.Gants.Text);
            command.AddParameter("MasqueACartouches", workPermit.AppareilEquipementDePrevention.StateAsBool);
            command.AddParameter("MasqueACartouchesValue", workPermit.AppareilEquipementDePrevention.Text);
            command.AddParameter("EPIAntiArcCAT", workPermit.EpiAntiArcCatProtecteurEquipementDeProtection.StateAsBool);
            command.AddParameter("EPIAntiArcCATValue", workPermit.EpiAntiArcCatProtecteurEquipementDeProtection.Text);
            command.AddParameter("EPIAntiChoc", workPermit.EpiAntiChoc);
            command.AddParameter("HabitProtecteur", workPermit.HabitProtecteurEquipementDeProtection.StateAsBool);
            command.AddParameter("HabitProtecteurValue", workPermit.HabitProtecteurEquipementDeProtection.Text);
            command.AddParameter("EcranDeflecteur", workPermit.EcranDeflecteur);
            command.AddParameter("MALTDesEquipements", workPermit.MaltDesEquipements);
            command.AddParameter("Rallonges", workPermit.Rallonges);
            command.AddParameter("ApprobationPourEquipDeLevage", workPermit.ApprobationPourEquipDeLevage);
            command.AddParameter("BarricadeRigide", workPermit.BarricadeRigide);
            command.AddParameter("AutresE", workPermit.AutresEquipementDePrevention.StateAsBool);
            command.AddParameter("AutresEValue", workPermit.AutresEquipementDePrevention.Text);
            command.AddParameter("AlarmeDCS", workPermit.AlarmeDcs.StateAsBool);
            command.AddParameter("AlarmeDCSValue", workPermit.AlarmeDcs.Text);
            command.AddParameter("EchelleSecurisee", workPermit.EchelleSecurisee);
            command.AddParameter("EchafaudageApprouve", workPermit.EchafaudageApprouve);
            
            command.AddParameter("OutilDeLaiton", workPermit.OutilDeLaiton);
            //command.AddParameter("OutilDeLaitonManel", workPermit.OutilManuelEquipementDePrevention.StateAsBool);
            //command.AddParameter("outilDeLaitonManelValue", workPermit.OutilManuelEquipementDePrevention.Text);

            command.AddParameter("OutilDeLaitonManel", workPermit.OutilDeLaitonPrevention);
            command.AddParameter("outilDeLaitonManelValue", workPermit.OutilManuelEquipementDePrevention.Text);

            command.AddParameter("PerimetreSecurite", workPermit.PerimetreDeSecurityEquipementDePrevention.StateAsBool);
            command.AddParameter("PerimetreSecuriteValue", workPermit.PerimetreDeSecurityEquipementDePrevention.Text);
            command.AddParameter("Radio", workPermit.Radio);
            command.AddParameter("Signaleur", workPermit.Signaleur);
            command.AddParameter("InstructionsSpeciales", workPermit.InstructionsSpeciales);
// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            command.AddParameter("MudsAnswerTextBox", workPermit.MudsAnswerTextBox);
            command.AddParameter("MudsQuestionlabel", workPermit.MudsQuestionlabel);

            command.AddParameter("SignatureOperateurSurLeTerrain", workPermit.SignatureOperateurSurLeTerrain);
            command.AddParameter("DetectionDesGazs", workPermit.DetectionDesGazs);
            command.AddParameter("SignatureContremaitre", workPermit.SignatureContremaitre);
            command.AddParameter("SignatureAutorise", workPermit.SignatureAutorise);
            command.AddParameter("NettoyageTransfertHorsSite", workPermit.NettoyageTransfertHorsSite);
            command.AddParameter("Soudage", workPermit.Soudage);
            command.AddParameter("Traitement", workPermit.Traitement);
            command.AddParameter("Cuissons", workPermit.Cuissons);
            command.AddParameter("Percage", workPermit.Per�age);
            command.AddParameter("Chaufferette", workPermit.Chaufferette);
            command.AddParameter("Meulage", workPermit.Meulage);
            command.AddParameter("Nettoyage", workPermit.Nettoyage);
            command.AddParameter("AutresTravaux", workPermit.AutresTravaux.StateAsBool);
            command.AddParameter("AutresTravauxValue", workPermit.AutresTravaux.Text);
            command.AddParameter("TravauxDansZone", workPermit.TravauxDansZone);
            command.AddParameter("Combustibles", workPermit.Combustibles);
            command.AddParameter("Ecran", workPermit.Ecran);
            command.AddParameter("Boyau", workPermit.Boyau);
            command.AddParameter("BoyauDe", workPermit.BoyauDe);
            command.AddParameter("Couverture", workPermit.Couverture);
            command.AddParameter("Extincteur", workPermit.Extincteur);
            command.AddParameter("Bouche", workPermit.Bouche);
            command.AddParameter("RadioS", workPermit.RadioS);
            command.AddParameter("Surveillant", workPermit.Surveillant);
            command.AddParameter("UtilisationMoteur", workPermit.UtilisationMoteur);
            command.AddParameter("NettoyageAU", workPermit.NettoyageAu);
            command.AddParameter("UtilisationElectronics", workPermit.UtilisationElectronics);
            command.AddParameter("Radiographie", workPermit.Radiographie);
            command.AddParameter("UtilisationOutlis", workPermit.UtilisationOutlis);
            command.AddParameter("UtilisationEquipments", workPermit.UtilisationEquipments);
            command.AddParameter("Demolition", workPermit.Demolition);
            command.AddParameter("AutresInstruction", workPermit.AutresInstruction.StateAsBool);
            command.AddParameter("AutresInstructionValue", workPermit.AutresInstruction.Text);
            command.AddParameter("EffondrementEnsevelissement", workPermit.EffondrementEnsevelissement);
            command.AddParameter("MasqueSoudeur", workPermit.MasqueSoudeur);

            if (workPermit.GasTests == null)
            {
                command.AddParameter("@GasTestFirstResultTime", null);
                command.AddParameter("@GasTestSecondResultTime", null);
                command.AddParameter("@GasTestThirdResultTime", null);
                command.AddParameter("@GasTestFourthResultTime", null);
            }
            else 
            {
                if (workPermit.GasTests.GasTestFirstResultTime == null)
                {
                    command.AddParameter("@GasTestFirstResultTime", null);
                }
                else
                {
                    command.AddParameter("@GasTestFirstResultTime",
                        workPermit.GasTests.GasTestFirstResultTime.ToDateTime());
                }
                if (workPermit.GasTests.GasTestSecondResultTime == null)
                {
                    command.AddParameter("@GasTestSecondResultTime", null);
                }
                else
                {
                    command.AddParameter("@GasTestSecondResultTime",
                        workPermit.GasTests.GasTestSecondResultTime.ToDateTime());
                }
                if (workPermit.GasTests.GasTestThirdResultTime == null)
                {
                    command.AddParameter("@GasTestThirdResultTime", null);
                }
                else
                {
                    command.AddParameter("@GasTestThirdResultTime",
                        workPermit.GasTests.GasTestThirdResultTime.ToDateTime());
                }
                if (workPermit.GasTests.GasTestFourthResultTime == null)
                {
                    command.AddParameter("@GasTestFourthResultTime", null);
                }
                else
                {
                    command.AddParameter("@GasTestFourthResultTime",
                        workPermit.GasTests.GasTestFourthResultTime.ToDateTime());
                }
            }
        }

        private static void AddInsertParameters(WorkPermitMuds workPermit, SqlCommand command)
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
// Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            command.AddParameter("@Company_1", workPermit.Company_1);
            command.AddParameter("@Company_2", workPermit.Company_2);
            command.AddParameter("@Supervisor", workPermit.Supervisor);
            command.AddParameter("@ExcavationNumber", workPermit.ExcavationNumber);

            command.AddParameter("@ClonedFormDetailMuds", workPermit.ClonedFormDetailMuds); // Added by Vibhor : DMND0011077 - Work Permit Clone History

            command.AddParameter("CreatedDateTime", workPermit.CreatedDateTime);
            command.AddParameter("CreatedByUserId", workPermit.CreatedBy.IdValue);
            //Added by ppanigrahi;
           // command.AddParameter("WorkpermitClosedById", workPermit.CreatedBy.IdValue);
           // command.AddParameter("ActionItemCloseById", workPermit.CreatedBy.IdValue);

            AddInsertOrUpdateParameters(workPermit, command);
        }


        private static void AddUpdateParameters(WorkPermitMuds workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", workPermit.PermitNumber == null);
            AddInsertOrUpdateParameters(workPermit, command);
        }

        private static void SetPermitNumber(WorkPermitMuds workPermit, SqlParameter permitNumberParameter)
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

        public void Remove(WorkPermitMuds workPermit)
        {
            ManagedCommand.Remove(workPermit, RemoveStoredProcedure);
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(WorkPermitMuds workPermit)
        {
            string spname = "RemoveWorkPermitTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(WorkPermitMuds workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

          //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public WorkPermitMuds UpdateTemplate(WorkPermitMuds workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdateWorkPermitTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(WorkPermitMuds workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);

        }


        public bool DoesPermitRequestMudsAssociationExist(List<PermitRequestMudsDTO> permitRequests, Date workPermitStartDate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStartDate", workPermitStartDate.ToDateTimeAtStartOfDay());

            string permitRequestIds = permitRequests.BuildIdStringFromList();
            command.AddParameter("@PermitRequestIds", permitRequestIds);

            int count = command.GetCount(QueryDoesPermitRequestMudsAssociationExist);

            return count > 0;
        }

        public bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMudsId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId", userId);
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            int count = command.GetCount(QueryWorkPermitMudsUserReadDocumentLinkAssociationCount);
            return count > 0;
        }

        public void InsertWorkPermitMudsUserReadDocumentLinkAssociation(long userId, long workPermitMudsId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = InsertWorkPermitMudsUserReadDocumentLinkAssociationStoredProcedure;
            command.Parameters.Clear();
            command.AddParameter("@UserId", userId);
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            command.ExecuteNonQuery();
        }

        public WorkPermitMuds QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMuds permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", permit.IdValue);
            return command.QueryForSingleResult<WorkPermitMuds>(PopulateInstance, "QueryWorkPermitMudsForReuse");
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByWorkPermitMudsId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedWorkPermitMuds);
        }


        //Adde by Mukesh for WOrkpermit Sign

        public WorkPermitMudSign GetWorkPermitSign(string WorkPermitId, int SiteId)
        {


            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", WorkPermitId);
            command.AddParameter("@SiteId", SiteId);

            return command.QueryForSingleResult<WorkPermitMudSign>(PopulateWorkPermitSign, "GETWORKPERMITMUDSSIGN");
        }

        public static WorkPermitMudSign PopulateWorkPermitSign(SqlDataReader reader)
        {
            WorkPermitMudSign objWorkPermitSign = new WorkPermitMudSign();


            objWorkPermitSign.WorkPermitId = reader.Get<string>("WorkPermitId");

            objWorkPermitSign.Verifier_FNAME = reader.Get<string>("Verifier_FNAME");
            objWorkPermitSign.Verifier_LNAME = reader.Get<string>("Verifier_LNAME");
            objWorkPermitSign.Verifier_BADGENUMBER = reader.Get<string>("Verifier_BADGENUMBER");
            objWorkPermitSign.Verifier_BADGETYPE = reader.Get<string>("Verifier_BADGETYPE");
            objWorkPermitSign.Verifier_SOURCE = reader.Get<string>("Verifier_SOURCE");


            objWorkPermitSign.DETENTEUR_FNAME = reader.Get<string>("DETENTEUR_FNAME");
            objWorkPermitSign.DETENTEUR_LNAME = reader.Get<string>("DETENTEUR_LNAME");
            objWorkPermitSign.DETENTEUR_BADGENUMBER = reader.Get<string>("DETENTEUR_BADGENUMBER");
            objWorkPermitSign.DETENTEUR_BADGETYPE = reader.Get<string>("DETENTEUR_BADGETYPE");
            objWorkPermitSign.DETENTEUR_SOURCE = reader.Get<string>("DETENTEUR_SOURCE");


            objWorkPermitSign.EMETTEUR_FNAME = reader.Get<string>("EMETTEUR_FNAME");
            objWorkPermitSign.EMETTEUR_LNAME = reader.Get<string>("EMETTEUR_LNAME");
            objWorkPermitSign.EMETTEUR_BADGENUMBER = reader.Get<string>("EMETTEUR_BADGENUMBER");
            objWorkPermitSign.EMETTEUR_BADGETYPE = reader.Get<string>("EMETTEUR_BADGETYPE");
            objWorkPermitSign.EMETTEUR_SOURCE = reader.Get<string>("EMETTEUR_SOURCE");



           
            objWorkPermitSign.UpdatedBy = reader.Get<int>("UpdatedBy");
            objWorkPermitSign.CreatedBy = reader.Get<int>("CreatedBy");
            objWorkPermitSign.CreatedDate = Convert.ToString(reader.Get<DateTime>("CreatedDate"));
            objWorkPermitSign.UpdatedDate = Convert.ToString(reader.Get<DateTime>("UpdatedDate"));
            //objWorkPermitSign.SiteId =Convert.ToString(reader.Get<long?>("SiteId"));

            objWorkPermitSign.FirstNameFirstResult = reader.Get<string>("FirstNameFirstResult");
            objWorkPermitSign.LasttNameFirstResult = reader.Get<string>("LasttNameFirstResult");
            objWorkPermitSign.SourceFirstResult = reader.Get<string>("SourceFirstResult");
            objWorkPermitSign.BadgeFirstResult = reader.Get<string>("BadgeFirstResult");
            objWorkPermitSign.FirstNameSecondResult = reader.Get<string>("FirstNameSecondResult");
            objWorkPermitSign.LasttNameSecondResult = reader.Get<string>("LasttNameSecondResult");
            objWorkPermitSign.SourceSecondResult = reader.Get<string>("SourceSecondResult");
            objWorkPermitSign.BadgeSecondResult = reader.Get<string>("BadgeSecondResult");
            objWorkPermitSign.FirstNameThirdResult = reader.Get<string>("FirstNameThirdResult");
            objWorkPermitSign.LasttNameThirdResult = reader.Get<string>("LasttNameThirdResult");
            objWorkPermitSign.SourceThirdResult = reader.Get<string>("SourceThirdResult");
            objWorkPermitSign.BadgeThirdResult = reader.Get<string>("BadgeThirdResult");
          objWorkPermitSign.FirstNameFourthResult = reader.Get<string>("FirstNameFourthResult");
          objWorkPermitSign.LasttNameFourthResult = reader.Get<string>("LasttNameFourthResult");
          objWorkPermitSign.SourceFourthResult = reader.Get<string>("SourceFourthResult");
          objWorkPermitSign.BadgeFourthResult = reader.Get<string>("BadgeFourthResult");
        





            return objWorkPermitSign;
        }


        public void InserUpdateWorkPermitSign(WorkPermitMudSign workPermitSign)
        {
            ManagedCommand.ExecuteNonQuery(workPermitSign, "INSERTUPDATEWORKPERMITMUDSIGN", AddSignParameters);
        }

        private static void AddSignParameters(WorkPermitMudSign objWorkPermitSign, SqlCommand command)
        {

            command.AddParameter("@WorkPermitId", objWorkPermitSign.WorkPermitId);

            command.AddParameter("@Verifier_FNAME", objWorkPermitSign.Verifier_FNAME);
            command.AddParameter("@Verifier_LNAME", objWorkPermitSign.Verifier_LNAME);
            command.AddParameter("@Verifier_BADGENUMBER", objWorkPermitSign.Verifier_BADGENUMBER);
            command.AddParameter("@Verifier_BADGETYPE", objWorkPermitSign.Verifier_BADGETYPE);
            command.AddParameter("@Verifier_SOURCE", objWorkPermitSign.Verifier_SOURCE);



            command.AddParameter("@DETENTEUR_FNAME", objWorkPermitSign.DETENTEUR_FNAME);
            command.AddParameter("@DETENTEUR_LNAME", objWorkPermitSign.DETENTEUR_LNAME);
            command.AddParameter("@DETENTEUR_BADGENUMBER", objWorkPermitSign.DETENTEUR_BADGENUMBER);
            command.AddParameter("@DETENTEUR_BADGETYPE", objWorkPermitSign.DETENTEUR_BADGETYPE);
            command.AddParameter("@DETENTEUR_SOURCE", objWorkPermitSign.DETENTEUR_SOURCE);


            command.AddParameter("@EMETTEUR_FNAME", objWorkPermitSign.EMETTEUR_FNAME);
            command.AddParameter("@EMETTEUR_LNAME", objWorkPermitSign.EMETTEUR_LNAME);
            command.AddParameter("@EMETTEUR_BADGENUMBER", objWorkPermitSign.EMETTEUR_BADGENUMBER);
            command.AddParameter("@EMETTEUR_BADGETYPE", objWorkPermitSign.EMETTEUR_BADGETYPE);
            command.AddParameter("@EMETTEUR_SOURCE", objWorkPermitSign.EMETTEUR_SOURCE);


         


            command.AddParameter("@UpdatedBy", objWorkPermitSign.UpdatedBy);
            command.AddParameter("@CreatedBy", objWorkPermitSign.CreatedBy);
            command.AddParameter("@CreatedDate", objWorkPermitSign.CreatedDate);
            command.AddParameter("@UpdatedDate", objWorkPermitSign.UpdatedDate);
            command.AddParameter("@SiteId", objWorkPermitSign.SiteId);

            command.AddParameter("@FirstNameFirstResult", objWorkPermitSign.FirstNameFirstResult);
            command.AddParameter("@LasttNameFirstResult", objWorkPermitSign.LasttNameFirstResult);
            command.AddParameter("@SourceFirstResult", objWorkPermitSign.SourceFirstResult);
            command.AddParameter("@BadgeFirstResult", objWorkPermitSign.BadgeFirstResult);
            command.AddParameter("@FirstNameSecondResult", objWorkPermitSign.FirstNameSecondResult);
            command.AddParameter("@LasttNameSecondResult", objWorkPermitSign.LasttNameSecondResult);
            command.AddParameter("@SourceSecondResult", objWorkPermitSign.SourceSecondResult);
            command.AddParameter("@BadgeSecondResult", objWorkPermitSign.BadgeSecondResult);
            command.AddParameter("@FirstNameThirdResult", objWorkPermitSign.FirstNameThirdResult);
            command.AddParameter("@LasttNameThirdResult", objWorkPermitSign.LasttNameThirdResult);
            command.AddParameter("@SourceThirdResult", objWorkPermitSign.SourceThirdResult);
            command.AddParameter("@BadgeThirdResult", objWorkPermitSign.BadgeThirdResult);
            command.AddParameter("@FirstNameFourthResult", objWorkPermitSign.FirstNameFourthResult);
            command.AddParameter("@LasttNameFourthResult", objWorkPermitSign.LasttNameFourthResult);
            command.AddParameter("@SourceFourthResult", objWorkPermitSign.SourceFourthResult);
            command.AddParameter("@BadgeFourthResult", objWorkPermitSign.BadgeFourthResult); 
        

        }





        //Gas test


        private WorkPermitGasTests PopulateWorkPermitGasTests(SqlDataReader reader, long workPermitId)
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



            result.Elements = gasTestElementDao.QueryAllGasTestElementByWorkPermitIdMuds(workPermitId, 16);        

            return result;
        }

    }
}