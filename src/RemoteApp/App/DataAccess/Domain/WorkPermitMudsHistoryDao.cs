﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMudsHistoryDao : AbstractManagedDao, IWorkPermitMudsHistoryDao
    {
        private const string QUERY_WORK_PERMIT_Muds_HISTORIES_BY_ID = "QueryWorkPermitMudsHistoriesById";
        private const string INSERT = "InsertWorkPermitMudsHistory";

        private readonly IUserDao userDao;

        public WorkPermitMudsHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<WorkPermitMudsHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult < WorkPermitMudsHistory>(PopulateInstance, QUERY_WORK_PERMIT_Muds_HISTORIES_BY_ID);
        }

        private WorkPermitMudsHistory PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));


            WorkPermitMudsHistory history = new WorkPermitMudsHistory(id, lastModifiedBy, lastModifiedDate);

            history.WorkPermitType = WorkPermitMudsType.Get(reader.Get<int>("WorkPermitTypeId"));
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
            //Added by ppanigrahi
            history.WorkpermitClosedBy= userDao.QueryById(reader.Get<long>("WorkpermitClosedById"));
            history.ActionItemCloseBy = userDao.QueryById(reader.Get<long>("ActionItemCloseById"));
            history.PermitCloseDateTime = reader.Get<DateTime?>("PermitCloseDateTime");
            history.ActionItemCloseDateTime = reader.Get<DateTime?>("ActionItemCloseDateTime");
            history.ActionItemCheckboxchecked = reader.Get<bool?>("ActionItemCheckboxchecked");
            history.WorkPermitCloseComments = reader.Get<string>("WorkPermitCloseComments");
            history.RemplirLeFormulaireDeCondition = reader.GetTernaryString("RemplirLeFormulaireDeCondition");
            history.AnalyseCritiqueDeLaTache = reader.Get<bool>("AnalyseCritiqueDeLaTache");
            history.Depressurises = reader.Get<bool>("Depressurises");
            history.Vides = reader.Get<bool>("Vides");
            history.ContournementDesGda = reader.Get<bool>("ContournementDesGDA");
            history.Rinces = reader.Get<bool>("Rinces");
            history.NettoyesLaVapeur = reader.Get<bool>("NettoyesLaVapeur");
            history.Purges = reader.Get<bool>("Purges");
            history.Ventiles = reader.Get<bool>("Ventiles");
            history.Aeres = reader.Get<bool>("Aeres");
            history.Energies = reader.Get<bool>("Energies"); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            //history.Autres = reader.Get<bool>("Autres");
            history.AutresConditions = reader.GetTernaryString("AutresCondition");
            history.ProcedureEntretien = reader.GetTernaryString("Procedure");
            history.InterrupteursEtVannesCadenasses = reader.GetTernaryString("InterrupteursEtVannesCadenasses");
            history.VerrouillagesParTravailleurs = reader.Get<bool>("VerrouillagesParTravailleurs");
            history.SourcesDesenergisees = reader.Get<bool>("SourcesDesenergisees");
            history.DepartsLocauxTestes = reader.Get<bool>("DepartsLocauxTestes");
            history.ConduitesDesaccouplees = reader.Get<bool>("ConduitesDesaccouplees");
            history.ObturateursInstallees = reader.Get<bool>("ObturateursInstallees");
            history.PvciSuncorEffectuee = reader.Get<bool>("PVCISuncorEffectuee");
            history.PvciEntExtEffectuee = reader.Get<bool>("PVCIEntExtEffectuee");
            history.EtiquettObturateur = reader.GetTernaryString("Etiquette");
            history.Amiante = reader.Get<bool>("Amiante");
            history.AcideSulfurique = reader.Get<bool>("AcideSulfurique");
            history.Azote = reader.Get<bool>("Azote");
            history.Caustique = reader.Get<bool>("Caustique");
            history.DioxydeDeSoufre = reader.Get<bool>("DioxydeDeSoufre");
            history.Sbs = reader.Get<bool>("SBS");
            history.Soufre = reader.Get<bool>("Soufre");
            history.EquipementsNonRinces = reader.Get<bool>("EquipementsNonRinces");
            history.Hydrocarbures = reader.Get<bool>("Hydrocarbures");
            history.HydrogeneSulfure = reader.Get<bool>("HydrogeneSulfure");
            history.MonoxydeCarbone = reader.Get<bool>("MonoxydeCarbone");
            history.Reflux = reader.Get<bool>("Reflux");
            history.ProduitsVolatilsUtilises = reader.Get<bool>("ProduitsVolatilsUtilises");
            history.Bacteries = reader.Get<bool>("Bacteries");
            history.Appareil = reader.GetTernaryString("Appareil");
            history.InterferencesEntreTravaux = reader.Get<bool>("InterferencesEntreTravaux");
            history.PiecesEnRotation = reader.Get<bool>("PiecesEnRotation");
            history.IncendieExplosion = reader.Get<bool>("IncendieExplosion");
            history.ContrainteThermique = reader.Get<bool>("ContrainteThermique");
            history.Radiations = reader.Get<bool>("Radiations");
            history.Silice = reader.Get<bool>("Silice");
            history.Vanadium = reader.Get<bool>("Vanadium");
            history.AsphyxieIntoxication = reader.Get<bool>("AsphyxieIntoxication");
            history.AutresRisques = reader.GetTernaryString("AutresRisques");
            history.ElectriciteVolt = reader.GetTernaryString("ElectriciteVolt");
            history.TravailEnHauteur6EtPlus = reader.Get<bool>("TravailEnHauteur6EtPlus");
            history.VapeurCondensat = reader.Get<bool>("VapeurCondensat"); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            history.FeSValue = reader.Get<bool>("FeSValue");

            history.Electrisation = reader.Get<bool>("Electrisation");
            history.LunettesMonocoques = reader.Get<bool>("LunettesMonocoques");
            history.Visiere = reader.Get<bool>("Visiere");
            history.ProtectionAuditive = reader.Get<bool>("ProtectionAuditive");
            //history.ManteauAntiEclaboussure = reader.Get<bool>("ManteauAntiEclaboussure");
            history.CagouleIgnifuge = reader.Get<bool>("CagouleIgnifuge");
            history.Harnais2LiensDeRetenue = reader.Get<bool>("Harnais2LiensDeRetenue");
            //history.MasqueAntiPoussiere = reader.Get<bool>("MasqueAntiPoussiere");
            //history.FiltresParticules = reader.Get<bool>("FiltresParticules");
            history.Gants = reader.GetTernaryString("Gants");
            history.MasqueACartouches = reader.GetTernaryString("MasqueACartouches");
            history.EpiAntiArcCat = reader.GetTernaryString("EPIAntiArcCAT");
            history.HabitProtecteurEquipementDeProtection = reader.GetTernaryString("HabitProtecteur");
            history.PerimetreDeSecurityEquipementDePrevention = reader.GetTernaryString("PerimetreSecurite");

            //history.HabitCompletAntiEclaboussure = reader.Get<bool>("HabitCompletAntiEclaboussure");
            //history.HabitCouvreToutJetable = reader.Get<bool>("HabitCouvreToutJetable");
            history.EpiAntiChoc = reader.Get<bool>("EPIAntiChoc");
            //history.SystemeDAdductionDAir = reader.Get<bool>("SystemeDAdductionDAir");
            history.EcranDeflecteur = reader.Get<bool>("EcranDeflecteur");
            history.MaltDesEquipements = reader.Get<bool>("MALTDesEquipements");
            history.Rallonges = reader.Get<bool>("Rallonges");
            history.ApprobationPourEquipDeLevage = reader.Get<bool>("ApprobationPourEquipDeLevage");
            history.BarricadeRigide = reader.Get<bool>("BarricadeRigide");
            history.AutresE = reader.GetTernaryString("AutresE");
            history.AlarmeDcs = reader.GetTernaryString("AlarmeDCS");
            history.EchelleSecurisee = reader.Get<bool>("EchelleSecurisee");
            history.EchafaudageApprouve = reader.Get<bool>("EchafaudageApprouve");
            history.OutilDeLaiton = reader.Get<bool>("OutilDeLaiton");
            //history.PerimetreSecurite = reader.Get<bool>("PerimetreSecurite");
            //history.PerimetreSecuriteValue = reader.Get<bool>("PerimetreSecuriteValue");
            history.Radio = reader.Get<bool>("Radio");
            history.Signaleur = reader.Get<bool>("Signaleur");

            history.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");

            // Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.
            history.MudsAnswerTextBox = reader.Get<string>("MudsAnswerTextBox");
            history.MudsQuestionlabel = reader.Get<string>("MudsQuestionlabel");

            history.SignatureOperateurSurLeTerrain = reader.Get<bool>("SignatureOperateurSurLeTerrain");
            history.DetectionDesGazs = reader.Get<bool>("DetectionDesGazs");
            history.SignatureContremaitre = reader.Get<bool>("SignatureContremaitre");
            history.SignatureAutorise = reader.Get<bool>("SignatureAutorise");
            history.NettoyageTransfertHorsSite = reader.Get<bool>("NettoyageTransfertHorsSite");
            
            history.Soudage= reader.Get<bool>("Soudage");
            history.Traitement= reader.Get<bool>("Traitement");
            history.Cuissons= reader.Get<bool>("Cuissons");
            history.Perçage= reader.Get<bool>("Percage");
            history.Chaufferette= reader.Get<bool>("Chaufferette");
            history.Meulage= reader.Get<bool>("Meulage");
            history.Nettoyage= reader.Get<bool>("Nettoyage");
            history.AutresTravaux = reader.GetTernaryString("AutresTravaux");

            history.TravauxDansZone= reader.Get<bool>("TravauxDansZone");
            history.Combustibles= reader.Get<bool>("Combustibles");
            history.Ecran= reader.Get<bool>("Ecran");
            history.Boyau= reader.Get<bool>("Boyau");
            history.BoyauDe= reader.Get<bool>("BoyauDe");
            history.Couverture= reader.Get<bool>("Couverture");
            history.Extincteur= reader.Get<bool>("Extincteur");
            history.Bouche= reader.Get<bool>("Bouche");
            history.RadioS= reader.Get<bool>("RadioS");
            history.Surveillant= reader.Get<bool>("Surveillant");
            history.UtilisationMoteur= reader.Get<bool>("UtilisationMoteur");
            history.NettoyageAu= reader.Get<bool>("NettoyageAU");
            history.UtilisationElectronics= reader.Get<bool>("UtilisationElectronics");
            history.Radiographie= reader.Get<bool>("Radiographie");
            history.UtilisationOutlis= reader.Get<bool>("UtilisationOutlis");
            history.UtilisationEquipments= reader.Get<bool>("UtilisationEquipments");
            history.Demolition= reader.Get<bool>("Demolition");
            history.AutresInstruction = reader.GetTernaryString("AutresInstruction");

            history.DocumentLinks = reader.Get<string>("DocumentLinks");
            history.RequestedByGroup = reader.Get<string>("RequestedByGroup");

         //  history.FirstResultTime= reader.Get<Time>("GasTestFirstResultTime");
         //  history.FirstResultTime = reader.Get<Time>("GasTestSecondResultTime");
         //  history.FirstResultTime = reader.Get<Time>("GasTestThirdResultTime");
         //  history.FirstResultTime = reader.Get<Time>("GasTestFourthResultTime");

           history.GasTestElements = reader.Get<string>("GasTestElements");

            return history;
        }
       
 

        public void Insert(WorkPermitMudsHistory workPermitMudsHistory)
        {
            ManagedCommand.Insert(workPermitMudsHistory, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(WorkPermitMudsHistory history, SqlCommand command)
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
            //Added by ppanigrahi
            command.AddParameter("@WorkPermitCloseComments", history.WorkPermitCloseComments);
            command.AddParameter("@WorkpermitClosedById", history.WorkpermitClosedById);
            command.AddParameter("@ActionItemCloseById", history.ActionItemCloseById);
            command.AddParameter("@PermitCloseDateTime", history.PermitCloseDateTime);
            command.AddParameter("@ActionItemCloseDateTime", history.ActionItemCloseDateTime);
            command.AddParameter("@ActionItemCheckboxchecked", history.ActionItemCheckboxchecked);

            command.AddParameter("@LastModifiedDateTime", history.LastModifiedDate);
            command.AddParameter("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.AddParameter("@IssuedDateTime", history.IssuedDateTime);

            command.AddParameter("RemplirLeFormulaireDeCondition", history.RemplirLeFormulaireDeCondition.StateAsBool);
            command.AddParameter("RemplirLeFormulaireDeConditionValue", history.RemplirLeFormulaireDeCondition.Text);
            command.AddParameter("AnalyseCritiqueDeLaTache", history.AnalyseCritiqueDeLaTache);
            command.AddParameter("Depressurises", history.Depressurises);
            command.AddParameter("Vides", history.Vides);
            command.AddParameter("ContournementDesGDA", history.ContournementDesGda);
            command.AddParameter("Rinces", history.Rinces);
            command.AddParameter("NettoyesLaVapeur", history.NettoyesLaVapeur);
            command.AddParameter("Purges", history.Purges);
            command.AddParameter("Ventiles", history.Ventiles);
            command.AddParameter("Aeres", history.Aeres);
            command.AddParameter("Energies", history.Energies); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            command.AddParameter("Procedure", history.ProcedureEntretien.StateAsBool);
            command.AddParameter("ProcedureValue", history.ProcedureEntretien.Text);
            command.AddParameter("AutresCondition", history.AutresConditions.StateAsBool);//Autres
            command.AddParameter("AutresConditionValue", history.AutresConditions.Text);
            command.AddParameter("InterrupteursEtVannesCadenasses", history.InterrupteursEtVannesCadenasses.StateAsBool);
            command.AddParameter("InterrupteursEtVannesCadenassesValue", history.InterrupteursEtVannesCadenasses.Text);
            command.AddParameter("VerrouillagesParTravailleurs", history.VerrouillagesParTravailleurs);
            command.AddParameter("SourcesDesenergisees", history.SourcesDesenergisees);
            command.AddParameter("DepartsLocauxTestes", history.DepartsLocauxTestes);
            command.AddParameter("ConduitesDesaccouplees", history.ConduitesDesaccouplees);
            command.AddParameter("ObturateursInstallees", history.ObturateursInstallees);
            command.AddParameter("Etiquette", history.EtiquettObturateur.StateAsBool);
            command.AddParameter("EtiquetteValue", history.EtiquettObturateur.Text);
            command.AddParameter("PVCISuncorEffectuee", history.PvciSuncorEffectuee);
            command.AddParameter("PVCIEntExtEffectuee", history.PvciEntExtEffectuee);
            command.AddParameter("Amiante", history.Amiante);
            command.AddParameter("AcideSulfurique", history.AcideSulfurique);
            command.AddParameter("Azote", history.Azote);
            command.AddParameter("Caustique", history.Caustique);
            command.AddParameter("DioxydeDeSoufre", history.DioxydeDeSoufre);
            command.AddParameter("SBS", history.Sbs);
            command.AddParameter("Soufre", history.Soufre);
            command.AddParameter("EquipementsNonRinces", history.EquipementsNonRinces);
            command.AddParameter("Hydrocarbures", history.Hydrocarbures);
            command.AddParameter("HydrogeneSulfure", history.HydrogeneSulfure);
            command.AddParameter("MonoxydeCarbone", history.MonoxydeCarbone);
            command.AddParameter("Reflux", history.Reflux);
            command.AddParameter("ProduitsVolatilsUtilises", history.ProduitsVolatilsUtilises);
            command.AddParameter("Bacteries", history.Bacteries);
            command.AddParameter("Appareil", history.Appareil.StateAsBool);
            command.AddParameter("AppareilValue", history.Appareil.Text);
            command.AddParameter("InterferencesEntreTravaux", history.InterferencesEntreTravaux);
            command.AddParameter("PiecesEnRotation", history.PiecesEnRotation);
            command.AddParameter("IncendieExplosion", history.IncendieExplosion);
            command.AddParameter("ContrainteThermique", history.ContrainteThermique);
            command.AddParameter("Radiations", history.Radiations);
            command.AddParameter("Silice", history.Silice);
            command.AddParameter("Vanadium", history.Vanadium);
            command.AddParameter("AsphyxieIntoxication", history.AsphyxieIntoxication);
            command.AddParameter("AutresRisques", history.AutresRisques.StateAsBool);
            command.AddParameter("AutresRisquesValue", history.AutresRisques.Text);
            command.AddParameter("ElectriciteVolt", history.ElectriciteVolt.StateAsBool);
            command.AddParameter("ElectriciteVoltValue", history.ElectriciteVolt.Text);
            command.AddParameter("OutillageElectrique", history.OutilDeLaiton);
            command.AddParameter("TravailEnHauteur6EtPlus", history.TravailEnHauteur6EtPlus);
            command.AddParameter("VapeurCondensat", history.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            command.AddParameter("FeSValue", history.FeSValue);

            command.AddParameter("Electrisation", history.Electrisation);
            command.AddParameter("LunettesMonocoques", history.LunettesMonocoques);
            command.AddParameter("Visiere", history.Visiere);
            command.AddParameter("ProtectionAuditive", history.ProtectionAuditive);
            command.AddParameter("CagouleIgnifuge", history.CagouleIgnifuge);
            command.AddParameter("Harnais2LiensDeRetenue", history.Harnais2LiensDeRetenue);
            command.AddParameter("Gants", history.Gants.StateAsBool);
            command.AddParameter("GantsValue", history.Gants.Text);
            command.AddParameter("MasqueACartouches", history.MasqueACartouches.StateAsBool);
            command.AddParameter("MasqueACartouchesValue", history.MasqueACartouches.Text);
            command.AddParameter("EPIAntiArcCAT", history.EpiAntiArcCat.StateAsBool);
            command.AddParameter("EPIAntiArcCATValue", history.EpiAntiArcCat.Text);
            command.AddParameter("EPIAntiChoc", history.EpiAntiChoc);
            command.AddParameter("HabitProtecteur", history.HabitProtecteurEquipementDeProtection.StateAsBool);
            command.AddParameter("HabitProtecteurValue", history.HabitProtecteurEquipementDeProtection.Text);
            command.AddParameter("EcranDeflecteur", history.EcranDeflecteur);
            command.AddParameter("MALTDesEquipements", history.MaltDesEquipements);
            command.AddParameter("Rallonges", history.Rallonges);
            command.AddParameter("ApprobationPourEquipDeLevage", history.ApprobationPourEquipDeLevage);
            command.AddParameter("BarricadeRigide", history.BarricadeRigide);
            command.AddParameter("AutresE", history.AutresE.StateAsBool);
            command.AddParameter("AutresEValue", history.AutresE.Text);
            command.AddParameter("AlarmeDCS", history.AlarmeDcs.StateAsBool);
            command.AddParameter("AlarmeDCSValue", history.AlarmeDcs.Text);
            command.AddParameter("EchelleSecurisee", history.EchelleSecurisee);
            command.AddParameter("EchafaudageApprouve", history.EchafaudageApprouve);

            command.AddParameter("OutilDeLaiton", history.OutilDeLaiton);
            command.AddParameter("OutilDeLaitonManel", history.OutilDeLaitonManel.StateAsBool);
            command.AddParameter("outilDeLaitonManelValue", history.OutilDeLaitonManel.Text);

            command.AddParameter("PerimetreSecurite", history.PerimetreDeSecurityEquipementDePrevention.StateAsBool);
            command.AddParameter("PerimetreSecuriteValue", history.PerimetreDeSecurityEquipementDePrevention.Text);
            command.AddParameter("Radio", history.Radio);
            command.AddParameter("Signaleur", history.Signaleur);
            command.AddParameter("InstructionsSpeciales", history.InstructionsSpeciales);

            // Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.
            
            command.AddParameter("MudsAnswerTextBox", history.MudsAnswerTextBox);
            command.AddParameter("MudsQuestionlabel", history.MudsQuestionlabel);

            command.AddParameter("SignatureOperateurSurLeTerrain", history.SignatureOperateurSurLeTerrain);
            command.AddParameter("DetectionDesGazs", history.DetectionDesGazs);
            command.AddParameter("SignatureContremaitre", history.SignatureContremaitre);
            command.AddParameter("SignatureAutorise", history.SignatureAutorise);
            command.AddParameter("NettoyageTransfertHorsSite", history.NettoyageTransfertHorsSite);
            command.AddParameter("Soudage", history.Soudage);
            command.AddParameter("Traitement", history.Traitement);
            command.AddParameter("Cuissons", history.Cuissons);
            command.AddParameter("Percage", history.Perçage);
            command.AddParameter("Chaufferette", history.Chaufferette);
            command.AddParameter("Meulage", history.Meulage);
            command.AddParameter("Nettoyage", history.Nettoyage);
            command.AddParameter("AutresTravaux", history.AutresTravaux.StateAsBool);
            command.AddParameter("AutresTravauxValue", history.AutresTravaux.Text);
            command.AddParameter("TravauxDansZone", history.TravauxDansZone);
            command.AddParameter("Combustibles", history.Combustibles);
            command.AddParameter("Ecran", history.Ecran);
            command.AddParameter("Boyau", history.Boyau);
            command.AddParameter("BoyauDe", history.BoyauDe);
            command.AddParameter("Couverture", history.Couverture);
            command.AddParameter("Extincteur", history.Extincteur);
            command.AddParameter("Bouche", history.Bouche);
            command.AddParameter("RadioS", history.RadioS);
            command.AddParameter("Surveillant", history.Surveillant);
            command.AddParameter("UtilisationMoteur", history.UtilisationMoteur);
            command.AddParameter("NettoyageAU", history.NettoyageAu);
            command.AddParameter("UtilisationElectronics", history.UtilisationElectronics);
            command.AddParameter("Radiographie", history.Radiographie);
            command.AddParameter("UtilisationOutlis", history.UtilisationOutlis);
            command.AddParameter("UtilisationEquipments", history.UtilisationEquipments);
            command.AddParameter("Demolition", history.Demolition);
            command.AddParameter("AutresInstruction", history.AutresInstruction.StateAsBool);
            command.AddParameter("AutresInstructionValue", history.AutresInstruction.Text);

            command.AddParameter("@DocumentLinks", history.DocumentLinks);
            command.AddParameter("@RequestedByGroup", history.RequestedByGroup);

           // command.AddParameter("@GasTestFirstResultTime", history.FirstResultTime);
           // command.AddParameter("@GasTestSecondResultTime", history.SecondResultTime);
           // command.AddParameter("@GasTestThirdResultTime", history.ThirdResultTime);
           // command.AddParameter("@GasTestFourthResultTime", history.FourthResultTime);
            command.AddParameter("@GasTestElements", history.GasTestElements);
        }

        public List<WorkPermitMudsSignHistory> GetBySignId(string id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId", id);
            // command.AddParameter("@SiteId", SiteId);
            return command.QueryForListResult<WorkPermitMudsSignHistory>(PopulateWorkPermitSign, "GETWORKPERMITMUDSIGN_HISTORY");

        }

        public static WorkPermitMudsSignHistory PopulateWorkPermitSign(SqlDataReader reader)
        {
            WorkPermitMudsSignHistory objWorkPermitSign = new WorkPermitMudsSignHistory();


            objWorkPermitSign.WorkPermitId = reader.Get<string>("WorkPermitId");

            objWorkPermitSign.VERIFICATEUR = Convert.ToString(reader.Get<string>("Verifier_FNAME")) + " " + Convert.ToString(reader.Get<string>("Verifier_LNAME"));

            objWorkPermitSign.VERIFICATEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("Verifier_BADGENUMBER"));

            objWorkPermitSign.VERIFICATEUR_SOURCE = Convert.ToString(reader.Get<string>("Verifier_SOURCE"));


            objWorkPermitSign.DETENTEUR_NAME = Convert.ToString(reader.Get<string>("DETENTEUR_FNAME")) + " " + Convert.ToString(reader.Get<string>("DETENTEUR_LNAME")); ;
            objWorkPermitSign.DETENTEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("DETENTEUR_BADGENUMBER"));
            objWorkPermitSign.DETENTEUR_SOURCE = Convert.ToString(reader.Get<string>("DETENTEUR_SOURCE"));


            objWorkPermitSign.EMETTEUR_NAME = Convert.ToString(reader.Get<string>("EMETTEUR_FNAME")) + " " + Convert.ToString(reader.Get<string>("EMETTEUR_LNAME"));
            objWorkPermitSign.EMETTEUR_BADGENUMBER = Convert.ToString(reader.Get<string>("EMETTEUR_BADGENUMBER"));
            objWorkPermitSign.EMETTEUR_SOURCE = Convert.ToString(reader.Get<string>("EMETTEUR_SOURCE"));


            objWorkPermitSign.FirstResult_Name = Convert.ToString(reader.Get<string>("FirstNameFirstResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameFirstResult"));
            objWorkPermitSign.SecondResult_Name = Convert.ToString(reader.Get<string>("FirstNameSecondResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameSecondResult"));
            objWorkPermitSign.ThirdResult_Name = Convert.ToString(reader.Get<string>("FirstNameThirdResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameThirdResult"));
            objWorkPermitSign.FourthResult_Name = Convert.ToString(reader.Get<string>("FirstNameFourthResult")) + " " + Convert.ToString(reader.Get<string>("LasttNameFourthResult"));

            objWorkPermitSign.FirstResult_Source = reader.Get<string>("SourceFirstResult");


            objWorkPermitSign.SecondResult_Source = reader.Get<string>("SourceSecondResult");


            objWorkPermitSign.ThirdResult_Source = reader.Get<string>("SourceThirdResult");

            objWorkPermitSign.FourthResult_Source = reader.Get<string>("SourceFourthResult");
            
            

           

            objWorkPermitSign.UpdatedBy = reader.Get<int>("UpdatedBy");

           
            IUserDao userDao = DaoRegistry.GetDao<IUserDao>();
            objWorkPermitSign.LastModifiedBy = objWorkPermitSign.UpdatedBy != null ? userDao.QueryById(objWorkPermitSign.UpdatedBy) : null;
            objWorkPermitSign.LastModifiedDate = reader.Get<DateTime>("UpdatedDate");

           
            return objWorkPermitSign;
        }

    }
}