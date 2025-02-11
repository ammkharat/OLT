﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitMudsTemplateDao : AbstractManagedDao, IWorkPermitMudsTemplateDao
    {
        private const string QUERY_ALL_NOT_DELETED_STORED_PROCEDURE = "QueryAllWorkPermitMudsTemplatesNotDeleted";
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllWorkPermitMudsTemplates";
        private const string INSERT_STORED_PROCEDURE = "InsertWorkPermitMudsTemplate";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryWorkPermitMudsTemplateById";
        private const string DELETE_STORED_PROCEDURE = "DeleteWorkPermitMudsTemplate";
        private const string UPDATE_STORED_PROCEDURE = "UpdateWorkPermitMudsTemplate";
        private const string QUERY_BY_ID_STORED_PROCEDURE_MapPermitRequest = "QueryWorkPermitMudsTemplateById";

        public WorkPermitMudsTemplate Insert(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            SqlParameter templateNumberParameter = command.AddInputOutputParameter("@TemplateNumber", SqlDbType.Int, workPermitMudsTemplate.TemplateNumber);

            command.Insert(workPermitMudsTemplate, AddInsertOrUpdateParameters, INSERT_STORED_PROCEDURE);
            
            workPermitMudsTemplate.Id = long.Parse(idParameter.Value.ToString());
            workPermitMudsTemplate.TemplateNumber = int.Parse((templateNumberParameter.Value.ToString()));

            return workPermitMudsTemplate;
        }

        public WorkPermitMudsTemplate QueryById(long id)
        {
            return ManagedCommand.QueryById<WorkPermitMudsTemplate>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public WorkPermitMudsTemplate QueryByIdToMapPermit(long templateId, long permitId)
        {
            //return ManagedCommand.QueryById<WorkPermitMudsTemplate>(templateId, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE_MapPermitRequest);

            SqlCommand command = ManagedCommand;
            command.AddParameter("@templateId", templateId);
            command.AddParameter("@permitId", permitId);
            return command.QueryForSingleResult<WorkPermitMudsTemplate>(PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE_MapPermitRequest);
        }

        public List<WorkPermitMudsTemplate> QueryAllNotDeleted()
        {
            return ManagedCommand.QueryForListResult<WorkPermitMudsTemplate>(PopulateInstance, QUERY_ALL_NOT_DELETED_STORED_PROCEDURE);
        }

        public List<WorkPermitMudsTemplate> QueryAll()
        {
            return ManagedCommand.QueryForListResult<WorkPermitMudsTemplate>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public void Delete(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermitMudsTemplate.Id);
            command.ExecuteNonQuery(DELETE_STORED_PROCEDURE);
        }

        public void Update(WorkPermitMudsTemplate workPermitMudsTemplate)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermitMudsTemplate.Id);
            command.ExecuteNonQuery(workPermitMudsTemplate, UPDATE_STORED_PROCEDURE, AddInsertOrUpdateParameters);
        }

        private static void AddInsertOrUpdateParameters(WorkPermitMudsTemplate workPermitMudsTemplate, SqlCommand command)
        {
            command.AddParameter("@Name", workPermitMudsTemplate.Name);
            command.AddParameter("@TypeId", workPermitMudsTemplate.WorkPermitType.Id);
            command.AddParameter("@Active", workPermitMudsTemplate.IsActive);
            command.AddParameter("@Deleted", workPermitMudsTemplate.IsDeleted);

            command.AddParameter("@RemplirLeFormulaireDeCondition", workPermitMudsTemplate.RemplirLeFormulaireDeCondition);
            command.AddParameter("@RemplirLeFormulaireDeConditionValue", workPermitMudsTemplate.RemplirLeFormulaireDeConditionValue);
            command.AddParameter("@AnalyseCritiqueDeLaTache", workPermitMudsTemplate.AnalyseCritiqueDeLaTache);
            command.AddParameter("@Depressurises", workPermitMudsTemplate.Depressurises);
            command.AddParameter("@Vides", workPermitMudsTemplate.Vides);
            command.AddParameter("@ContournementDesGda", workPermitMudsTemplate.ContournementDesGda);
            command.AddParameter("@Rinces", workPermitMudsTemplate.Rinces);
            command.AddParameter("@NettoyesLaVapeur", workPermitMudsTemplate.NettoyesLaVapeur);
            command.AddParameter("@Purges", workPermitMudsTemplate.Purges);
            command.AddParameter("@Ventiles", workPermitMudsTemplate.Ventiles);
            command.AddParameter("@Aeres", workPermitMudsTemplate.Aeres);
            command.AddParameter("@Energies", workPermitMudsTemplate.Energies); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            command.AddParameter("@Procedure", workPermitMudsTemplate.ProcedureEntretien);
            command.AddParameter("@ProcedureValue", workPermitMudsTemplate.ProcedureEntretienValue);
            command.AddParameter("@AutresCondition", workPermitMudsTemplate.AutresConditions);
            command.AddParameter("@AutresConditionValue", workPermitMudsTemplate.AutresConditionsValue);
            command.AddParameter("@InterrupteursEtVannesCadenasses", workPermitMudsTemplate.InterrupteursEtVannesCadenasses);
            command.AddParameter("@InterrupteursEtVannesCadenassesValue", workPermitMudsTemplate.InterrupteursEtVannesCadenassesValue);
            command.AddParameter("@VerrouillagesParTravailleurs", workPermitMudsTemplate.VerrouillagesParTravailleurs);
            command.AddParameter("@SourcesDesenergisees", workPermitMudsTemplate.SourcesDesenergisees);
            command.AddParameter("@DepartsLocauxTestes", workPermitMudsTemplate.DepartsLocauxTestes);
            command.AddParameter("@ConduitesDesaccouplees", workPermitMudsTemplate.ConduitesDesaccouplees);
            command.AddParameter("@ObturateursInstallees", workPermitMudsTemplate.ObturateursInstallees);
            command.AddParameter("@Etiquette", workPermitMudsTemplate.EtiquettObturateur);
            command.AddParameter("@EtiquetteValue", workPermitMudsTemplate.EtiquettObturateurValue);
            command.AddParameter("@PvciSuncorEffectuee", workPermitMudsTemplate.PvciSuncorEffectuee);
            command.AddParameter("@PvciEntExtEffectuee", workPermitMudsTemplate.PvciEntExtEffectuee);
            command.AddParameter("@Amiante", workPermitMudsTemplate.Amiante);
            command.AddParameter("@AcideSulfurique", workPermitMudsTemplate.AcideSulfurique);
            command.AddParameter("@Azote", workPermitMudsTemplate.Azote);
            command.AddParameter("@Caustique", workPermitMudsTemplate.Caustique);
            command.AddParameter("@DioxydeDeSoufre", workPermitMudsTemplate.DioxydeDeSoufre);
            command.AddParameter("@Sbs", workPermitMudsTemplate.Sbs);
            command.AddParameter("@Soufre", workPermitMudsTemplate.Soufre);
            command.AddParameter("@EquipementsNonRinces", workPermitMudsTemplate.EquipementsNonRinces);
            command.AddParameter("@Hydrocarbures", workPermitMudsTemplate.Hydrocarbures);
            command.AddParameter("@HydrogeneSulfure", workPermitMudsTemplate.HydrogeneSulfure);
            command.AddParameter("@MonoxydeCarbone", workPermitMudsTemplate.MonoxydeCarbone);
            command.AddParameter("@Reflux", workPermitMudsTemplate.Reflux);
            command.AddParameter("@ProduitsVolatilsUtilises", workPermitMudsTemplate.ProduitsVolatilsUtilises);
            command.AddParameter("@Bacteries", workPermitMudsTemplate.Bacteries);
            command.AddParameter("@Appareil", workPermitMudsTemplate.AppareilProtecteurEquipementDeProtection);
            command.AddParameter("@AppareilValue", workPermitMudsTemplate.AppareilProtecteurEquipementDeProtectionValue);
            command.AddParameter("@InterferencesEntreTravaux", workPermitMudsTemplate.InterferencesEntreTravaux);
            command.AddParameter("@PiecesEnRotation", workPermitMudsTemplate.PiecesEnRotation);
            command.AddParameter("@IncendieExplosion", workPermitMudsTemplate.IncendieExplosion);
            command.AddParameter("@EffondrementEnsevelissement", workPermitMudsTemplate.EffondrementEnsevelissement);
            command.AddParameter("@ContrainteThermique", workPermitMudsTemplate.ContrainteThermique);
            command.AddParameter("@Radiations", workPermitMudsTemplate.Radiations);
            command.AddParameter("@Silice", workPermitMudsTemplate.Silice);
            command.AddParameter("@Vanadium", workPermitMudsTemplate.Vanadium);
            command.AddParameter("@AsphyxieIntoxication", workPermitMudsTemplate.AsphyxieIntoxication);
            command.AddParameter("@AutresRisques", workPermitMudsTemplate.AutresRisques);
            command.AddParameter("@AutresRisquesValue", workPermitMudsTemplate.AutresRisquesValue);
            command.AddParameter("@ElectriciteVolt", workPermitMudsTemplate.ElectronicVoltRisques);
            command.AddParameter("@ElectriciteVoltValue", workPermitMudsTemplate.ElectronicVoltRisquesValue);
            command.AddParameter("@OutillageElectrique", workPermitMudsTemplate.OutillageElectrique);
            command.AddParameter("@TravailEnHauteur6EtPlus", workPermitMudsTemplate.TravailEnHauteur6EtPlus);
            command.AddParameter("@VapeurCondensat", workPermitMudsTemplate.VapeurCondensat); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            command.AddParameter("@FeSValue", workPermitMudsTemplate.FeSValue); 
            

            command.AddParameter("@Electrisation", workPermitMudsTemplate.Electrisation);
            command.AddParameter("@LunettesMonocoques", workPermitMudsTemplate.LunettesMonocoques);
            command.AddParameter("@Visiere", workPermitMudsTemplate.Visiere);
            command.AddParameter("@ProtectionAuditive", workPermitMudsTemplate.ProtectionAuditive);
            command.AddParameter("@CagouleIgnifuge", workPermitMudsTemplate.CagouleIgnifuge);
            command.AddParameter("@Harnais2LiensDeRetenue", workPermitMudsTemplate.Harnais2LiensDeRetenue);
            command.AddParameter("@AppareilEquipementDePrevention", workPermitMudsTemplate.AppareilEquipementDePrevention);
            command.AddParameter("@AppareilEquipementDePreventionValue", workPermitMudsTemplate.AppareilEquipementDePreventionValue);
            command.AddParameter("@Gants", workPermitMudsTemplate.GantsEquipementDeProtection);
            command.AddParameter("@GantsValue", workPermitMudsTemplate.GantsEquipementDeProtectionValue);
            command.AddParameter("@MasqueACartouches", workPermitMudsTemplate.MasqueACartouches);
            command.AddParameter("@MasqueACartouchesValue", workPermitMudsTemplate.MasqueACartouchesValue);
            command.AddParameter("@MasqueSoudeur", workPermitMudsTemplate.MasqueSoudeur);
            command.AddParameter("@EpiAntiArcCat", workPermitMudsTemplate.EpiAntiArcCatProtecteurEquipementDeProtection);
            command.AddParameter("@EpiAntiArcCatValue", workPermitMudsTemplate.EpiAntiArcCatProtecteurEquipementDeProtectionValue);
            command.AddParameter("@EpiAntiChoc", workPermitMudsTemplate.EpiAntiChoc);
            command.AddParameter("@HabitProtecteur", workPermitMudsTemplate.HabitProtecteurEquipementDeProtection);
            command.AddParameter("@HabitProtecteurValue", workPermitMudsTemplate.HabitProtecteurEquipementDeProtectionValue);
            command.AddParameter("@EcranDeflecteur", workPermitMudsTemplate.EcranDeflecteur);
            command.AddParameter("@MaltDesEquipements", workPermitMudsTemplate.MaltDesEquipements);
            command.AddParameter("@Rallonges", workPermitMudsTemplate.Rallonges);
            command.AddParameter("@ApprobationPourEquipDeLevage", workPermitMudsTemplate.ApprobationPourEquipDeLevage);
            command.AddParameter("@BarricadeRigide", workPermitMudsTemplate.BarricadeRigide);
            command.AddParameter("@AutresE", workPermitMudsTemplate.AutresE);
            command.AddParameter("@AutresEValue", workPermitMudsTemplate.AutresEValue);
            command.AddParameter("@AlarmeDcs", workPermitMudsTemplate.AlarmeDcs);
            command.AddParameter("@AlarmeDcsValue", workPermitMudsTemplate.AlarmeDcsValue);
            command.AddParameter("@EchelleSecurisee", workPermitMudsTemplate.EchelleSecurisee);
            command.AddParameter("@EchafaudageApprouve", workPermitMudsTemplate.EchafaudageApprouve);
            command.AddParameter("@OutilDeLaiton", workPermitMudsTemplate.OutilDeLaiton);
            command.AddParameter("@OutilDeLaitonManel", workPermitMudsTemplate.OutilManuelEquipementDePrevention);
            command.AddParameter("@OutilDeLaitonManelValue", workPermitMudsTemplate.OutilManuelEquipementDePreventionValue);
            command.AddParameter("@PerimetreSecurite", workPermitMudsTemplate.PerimetreDeSecurityEquipementDePrevention);
            command.AddParameter("@PerimetreSecuriteValue", workPermitMudsTemplate.PerimetreDeSecurityEquipementDePreventionValue);
            command.AddParameter("@Radio", workPermitMudsTemplate.Radio);
            command.AddParameter("@AutresEquipementDePrevention", workPermitMudsTemplate.AutresEquipementDePrevention);
            command.AddParameter("@AutresEquipementDePreventionValue", workPermitMudsTemplate.AutresEquipementDePreventionValue);
            command.AddParameter("@Signaleur", workPermitMudsTemplate.Signaleur);
            command.AddParameter("@InstructionsSpeciales", workPermitMudsTemplate.InstructionsSpeciales);
            command.AddParameter("@SignatureOperateurSurLeTerrain", workPermitMudsTemplate.SignatureOperateurSurLeTerrain);
            command.AddParameter("@DetectionDesGazs", workPermitMudsTemplate.DetectionDesGazs);
            command.AddParameter("@SignatureContremaitre", workPermitMudsTemplate.SignatureContremaitre);
            command.AddParameter("@SignatureAutorise", workPermitMudsTemplate.SignatureAutorise);
            command.AddParameter("@NettoyageTransfertHorsSite", workPermitMudsTemplate.NettoyageTransfertHorsSite);
            command.AddParameter("@Soudage", workPermitMudsTemplate.Soudage);
            command.AddParameter("@Traitement", workPermitMudsTemplate.Traitement);
            command.AddParameter("@Cuissons", workPermitMudsTemplate.Cuissons);
            command.AddParameter("@Perçage", workPermitMudsTemplate.Perçage);
            command.AddParameter("@Chaufferette", workPermitMudsTemplate.Chaufferette);
            command.AddParameter("@Meulage", workPermitMudsTemplate.Meulage);
            command.AddParameter("@Nettoyage", workPermitMudsTemplate.Nettoyage);
            command.AddParameter("@AutresTravaux", workPermitMudsTemplate.AutresTravaux);
            command.AddParameter("@AutresTravauxValue", workPermitMudsTemplate.AutresTravauxValue);
            command.AddParameter("@TravauxDansZone", workPermitMudsTemplate.TravauxDansZone);
            command.AddParameter("@Combustibles", workPermitMudsTemplate.Combustibles);
            command.AddParameter("@Ecran", workPermitMudsTemplate.Ecran);
            command.AddParameter("@Boyau", workPermitMudsTemplate.Boyau);
            command.AddParameter("@BoyauDe", workPermitMudsTemplate.BoyauDe);
            command.AddParameter("@Couverture", workPermitMudsTemplate.Couverture);
            command.AddParameter("@Extincteur", workPermitMudsTemplate.Extincteur);
            command.AddParameter("@Bouche", workPermitMudsTemplate.Bouche);
            command.AddParameter("@RadioS", workPermitMudsTemplate.RadioS);
            command.AddParameter("@Surveillant", workPermitMudsTemplate.Surveillant);
            command.AddParameter("@UtilisationMoteur", workPermitMudsTemplate.UtilisationMoteur);
            command.AddParameter("@NettoyageAu", workPermitMudsTemplate.NettoyageAu);
            command.AddParameter("@UtilisationElectronics", workPermitMudsTemplate.UtilisationElectronics);
            command.AddParameter("@Radiographie", workPermitMudsTemplate.Radiographie);
            command.AddParameter("@UtilisationOutlis", workPermitMudsTemplate.UtilisationOutlis);
            command.AddParameter("@UtilisationEquipments", workPermitMudsTemplate.UtilisationEquipments);
            command.AddParameter("@Demolition", workPermitMudsTemplate.Demolition);
            command.AddParameter("@AutresInstruction", workPermitMudsTemplate.AutresInstruction);
            command.AddParameter("@AutresInstructionValue", workPermitMudsTemplate.AutresInstructionValue);
        
        }

        private WorkPermitMudsTemplate PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            int typeId = reader.Get<int>("TypeId");
            bool isActive = reader.Get<bool>("Active");
            bool isDeleted = reader.Get<bool>("Deleted");
            int templateNumber = reader.Get<int>("TemplateNumber");

            WorkPermitMudsTemplate workPermitMudsTemplate =
                new WorkPermitMudsTemplate(id,name,
                                               WorkPermitMudsType.Get(typeId),
                                               isActive, isDeleted, templateNumber);

            workPermitMudsTemplate.Id = id;
            
            workPermitMudsTemplate.RemplirLeFormulaireDeCondition = reader.Get<byte>("RemplirLeFormulaireDeCondition").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.RemplirLeFormulaireDeConditionValue = reader.Get<string>("RemplirLeFormulaireDeConditionValue");
            workPermitMudsTemplate.AnalyseCritiqueDeLaTache = reader.Get<byte>("AnalyseCritiqueDeLaTache").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Depressurises = reader.Get<byte>("Depressurises").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Vides = reader.Get<byte>("Vides").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ContournementDesGda = reader.Get<byte>("ContournementDesGDA").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Rinces = reader.Get<byte>("Rinces").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.NettoyesLaVapeur = reader.Get<byte>("NettoyesLaVapeur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Purges = reader.Get<byte>("Purges").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Ventiles = reader.Get<byte>("Ventiles").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Aeres = reader.Get<byte>("Aeres").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Energies = reader.Get<byte>("Energies").ToEnum<TemplateStateMuds>(); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit
            
            workPermitMudsTemplate.ProcedureEntretien = reader.Get<byte>("Procedure").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ProcedureEntretienValue = reader.Get<string>("ProcedureValue");
            workPermitMudsTemplate.AutresConditions = reader.Get<byte>("AutresCondition").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresConditionsValue = reader.Get<string>("AutresConditionValue");
            workPermitMudsTemplate.InterrupteursEtVannesCadenasses = reader.Get<byte>("InterrupteursEtVannesCadenasses").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.InterrupteursEtVannesCadenassesValue = reader.Get<string>("InterrupteursEtVannesCadenassesValue");
            workPermitMudsTemplate.VerrouillagesParTravailleurs = reader.Get<byte>("VerrouillagesParTravailleurs").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.SourcesDesenergisees = reader.Get<byte>("SourcesDesenergisees").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.DepartsLocauxTestes = reader.Get<byte>("DepartsLocauxTestes").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ConduitesDesaccouplees = reader.Get<byte>("ConduitesDesaccouplees").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ObturateursInstallees = reader.Get<byte>("ObturateursInstallees").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EtiquettObturateur = reader.Get<byte>("Etiquette").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EtiquettObturateurValue = reader.Get<string>("EtiquetteValue");
            workPermitMudsTemplate.PvciSuncorEffectuee = reader.Get<byte>("PVCISuncorEffectuee").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.PvciEntExtEffectuee = reader.Get<byte>("PVCIEntExtEffectuee").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Amiante = reader.Get<byte>("Amiante").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AcideSulfurique = reader.Get<byte>("AcideSulfurique").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Azote = reader.Get<byte>("Azote").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Caustique = reader.Get<byte>("Caustique").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.DioxydeDeSoufre = reader.Get<byte>("DioxydeDeSoufre").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Sbs = reader.Get<byte>("SBS").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Soufre = reader.Get<byte>("Soufre").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EquipementsNonRinces = reader.Get<byte>("EquipementsNonRinces").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Hydrocarbures = reader.Get<byte>("Hydrocarbures").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.HydrogeneSulfure = reader.Get<byte>("HydrogeneSulfure").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.MonoxydeCarbone = reader.Get<byte>("MonoxydeCarbone").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Reflux = reader.Get<byte>("Reflux").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ProduitsVolatilsUtilises = reader.Get<byte>("ProduitsVolatilsUtilises").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Bacteries = reader.Get<byte>("Bacteries").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Appareil = reader.Get<byte>("Appareil").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AppareilValue = reader.Get<string>("AppareilValue");
            workPermitMudsTemplate.InterferencesEntreTravaux = reader.Get<byte>("InterferencesEntreTravaux").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.PiecesEnRotation = reader.Get<byte>("PiecesEnRotation").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.IncendieExplosion = reader.Get<byte>("IncendieExplosion").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EffondrementEnsevelissement = reader.Get<byte>("EffondrementEnsevelissement").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ContrainteThermique = reader.Get<byte>("ContrainteThermique").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Radiations = reader.Get<byte>("Radiations").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Silice = reader.Get<byte>("Silice").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Vanadium = reader.Get<byte>("Vanadium").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AsphyxieIntoxication = reader.Get<byte>("AsphyxieIntoxication").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresRisques = reader.Get<byte>("AutresRisques").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresRisquesValue = reader.Get<string>("AutresRisquesValue");
            workPermitMudsTemplate.ElectriciteVolt = reader.Get<byte>("ElectriciteVolt").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ElectriciteVoltValue = reader.Get<string>("ElectriciteVoltValue");
            workPermitMudsTemplate.OutillageElectrique = reader.Get<byte>("OutillageElectrique").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.TravailEnHauteur6EtPlus = reader.Get<byte>("TravailEnHauteur6EtPlus").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.VapeurCondensat = reader.Get<byte>("VapeurCondensat").ToEnum<TemplateStateMuds>(); // Added By Vibhor : DMND0010816 -MUDS - Implement OLT Work permit

            workPermitMudsTemplate.FeSValue = reader.Get<byte>("FeSValue").ToEnum<TemplateStateMuds>(); 
            

            workPermitMudsTemplate.Electrisation = reader.Get<byte>("Electrisation").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.LunettesMonocoques = reader.Get<byte>("LunettesMonocoques").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Visiere = reader.Get<byte>("Visiere").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ProtectionAuditive = reader.Get<byte>("ProtectionAuditive").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.CagouleIgnifuge = reader.Get<byte>("CagouleIgnifuge").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Harnais2LiensDeRetenue = reader.Get<byte>("Harnais2LiensDeRetenue").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AppareilEquipementDePrevention = reader.Get<byte>("AppareilEquipementDePrevention").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AppareilEquipementDePreventionValue = reader.Get<string>("AppareilEquipementDePreventionValue");
            workPermitMudsTemplate.GantsEquipementDeProtection = reader.Get<byte>("Gants").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.GantsEquipementDeProtectionValue = reader.Get<string>("GantsValue");
            workPermitMudsTemplate.MasqueACartouches = reader.Get<byte>("MasqueACartouches").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.MasqueACartouchesValue = reader.Get<string>("MasqueACartouchesValue");
            workPermitMudsTemplate.MasqueSoudeur = reader.Get<byte>("MasqueSoudeur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EpiAntiArcCatProtecteurEquipementDeProtection = reader.Get<byte>("EPIAntiArcCAT").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EpiAntiArcCatProtecteurEquipementDeProtectionValue = reader.Get<string>("EPIAntiArcCATValue");
            workPermitMudsTemplate.EpiAntiChoc = reader.Get<byte>("EPIAntiChoc").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.HabitProtecteurEquipementDeProtection = reader.Get<byte>("HabitProtecteur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.HabitProtecteurEquipementDeProtectionValue = reader.Get<string>("HabitProtecteurValue");
            workPermitMudsTemplate.EcranDeflecteur = reader.Get<byte>("EcranDeflecteur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.MaltDesEquipements = reader.Get<byte>("MALTDesEquipements").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Rallonges = reader.Get<byte>("Rallonges").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.ApprobationPourEquipDeLevage = reader.Get<byte>("ApprobationPourEquipDeLevage").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.BarricadeRigide = reader.Get<byte>("BarricadeRigide").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresE = reader.Get<byte>("AutresE").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresEValue = reader.Get<string>("AutresEValue");
            workPermitMudsTemplate.AlarmeDcs = reader.Get<byte>("AlarmeDCS").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AlarmeDcsValue = reader.Get<string>("AlarmeDCSValue");
            workPermitMudsTemplate.EchelleSecurisee = reader.Get<byte>("EchelleSecurisee").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.EchafaudageApprouve = reader.Get<byte>("EchafaudageApprouve").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.OutilDeLaiton = reader.Get<byte>("OutilDeLaiton").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.OutilDeLaitonManel = reader.Get<byte>("OutilDeLaitonManel").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.OutilDeLaitonManelValue = reader.Get<string>("OutilDeLaitonManelValue");
            workPermitMudsTemplate.PerimetreDeSecurityEquipementDePrevention = reader.Get<byte>("PerimetreSecurite").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.PerimetreDeSecurityEquipementDePreventionValue = reader.Get<string>("PerimetreSecuriteValue");
            workPermitMudsTemplate.Radio = reader.Get<byte>("Radio").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresEquipementDePrevention = reader.Get<byte>("AutresEquipementDePrevention").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresEquipementDePreventionValue = reader.Get<string>("AutresEquipementDePreventionValue");
            workPermitMudsTemplate.Signaleur = reader.Get<byte>("Signaleur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.InstructionsSpeciales = reader.Get<string>("InstructionsSpeciales");
            workPermitMudsTemplate.SignatureOperateurSurLeTerrain = reader.Get<byte>("SignatureOperateurSurLeTerrain").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.DetectionDesGazs = reader.Get<byte>("DetectionDesGazs").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.SignatureContremaitre = reader.Get<byte>("SignatureContremaitre").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.SignatureAutorise = reader.Get<byte>("SignatureAutorise").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.NettoyageTransfertHorsSite = reader.Get<byte>("NettoyageTransfertHorsSite").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Soudage = reader.Get<byte>("Soudage").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Traitement = reader.Get<byte>("Traitement").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Cuissons = reader.Get<byte>("Cuissons").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Perçage = reader.Get<byte>("Perçage").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Chaufferette = reader.Get<byte>("Chaufferette").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Meulage = reader.Get<byte>("Meulage").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Nettoyage = reader.Get<byte>("Nettoyage").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresTravaux = reader.Get<byte>("AutresTravaux").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresTravauxValue = reader.Get<string>("AutresTravauxValue");
            workPermitMudsTemplate.TravauxDansZone = reader.Get<byte>("TravauxDansZone").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Combustibles = reader.Get<byte>("Combustibles").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Ecran = reader.Get<byte>("Ecran").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Boyau = reader.Get<byte>("Boyau").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.BoyauDe = reader.Get<byte>("BoyauDe").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Couverture = reader.Get<byte>("Couverture").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Extincteur = reader.Get<byte>("Extincteur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Bouche = reader.Get<byte>("Bouche").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.RadioS = reader.Get<byte>("RadioS").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Surveillant = reader.Get<byte>("Surveillant").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.UtilisationMoteur = reader.Get<byte>("UtilisationMoteur").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.NettoyageAu = reader.Get<byte>("NettoyageAU").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.UtilisationElectronics = reader.Get<byte>("UtilisationElectronics").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Radiographie = reader.Get<byte>("Radiographie").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.UtilisationOutlis = reader.Get<byte>("UtilisationOutlis").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.UtilisationEquipments = reader.Get<byte>("UtilisationEquipments").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.Demolition = reader.Get<byte>("Demolition").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresInstruction = reader.Get<byte>("AutresInstruction").ToEnum<TemplateStateMuds>();
            workPermitMudsTemplate.AutresInstructionValue = reader.Get<string>("AutresInstructionValue");
            
            return workPermitMudsTemplate;
        }

    }
}
