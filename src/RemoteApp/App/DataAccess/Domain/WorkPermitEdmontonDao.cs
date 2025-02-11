﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitEdmontonDao : AbstractManagedDao, IWorkPermitEdmontonDao
    {
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IWorkPermitEdmontonGroupDao groupDao;
        private readonly IFormGN59Dao formGN59Dao;
        private readonly IFormGN7Dao formGN7Dao;
        private readonly IFormGN24Dao formGN24Dao;
        private readonly IFormGN6Dao formGN6Dao;
        private readonly IFormGN75ADao formGN75ADao;
        private readonly IFormGN1Dao formGN1Dao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IAreaLabelDao areaLabelDao;
        private bool IsEdmontonSite = false;

        private const string QueryByIdStoredProcedure = "QueryWorkPermitEdmontonById";        
        private const string QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestIdStoredProcedure = "QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestId";
        private const string InsertStoredProcedure = "InsertWorkPermitEdmonton";
        private const string UpdateStoredProcedure = "UpdateWorkPermitEdmonton";
        private const string RemoveStoredProcedure = "RemoveWorkPermitEdmonton";
        private const string QueryDoesPermitRequestEdmontonAssociationExist = "QueryDoesPermitRequestEdmontonAssociationExist";
        private const string QueryByFormGn59Id = "QueryWorkPermitEdmontonByFormGN59Id";
        private const string QueryByFormGn7Id = "QueryWorkPermitEdmontonByFormGN7Id";
        private const string QueryByFormGn24Id = "QueryWorkPermitEdmontonByFormGN24Id";
        private const string QueryByFormGn6Id = "QueryWorkPermitEdmontonByFormGN6Id";
        private const string QueryByFormGn75AId = "QueryWorkPermitEdmontonByFormGN75AId";
        private const string QueryByFormGn1Id = "QueryWorkPermitEdmontonByFormGN1Id";

        public WorkPermitEdmontonDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            formGN59Dao = DaoRegistry.GetDao<IFormGN59Dao>();
            formGN7Dao = DaoRegistry.GetDao<IFormGN7Dao>();
            formGN24Dao = DaoRegistry.GetDao<IFormGN24Dao>();
            formGN6Dao = DaoRegistry.GetDao<IFormGN6Dao>();
            formGN75ADao = DaoRegistry.GetDao<IFormGN75ADao>();
            formGN1Dao = DaoRegistry.GetDao<IFormGN1Dao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        public WorkPermitEdmonton QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitEdmonton>(id, PopulateInstance, QueryByIdStoredProcedure);
        }

        public DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PermitRequestId", permitRequestId);
            DateTime? latestExpiryDateTime = command.QueryForSingleResult<DateTime?>(PopulateLatestExpiryDateTime, QueryWorkPermitEdmontonLatestExpirationDateByPermitRequestIdStoredProcedure);
            return latestExpiryDateTime;
        }

        private DateTime? PopulateLatestExpiryDateTime(SqlDataReader reader)
        {
            return reader.Get<DateTime?>("LatestExpiryDateTime");
        }

        public WorkPermitEdmonton Insert(WorkPermitEdmonton workPermit, long? permitRequestId)
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
            MaybeSetZeroEnergyFormNumber(workPermit);
            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            return workPermit;
        }

        public WorkPermitEdmonton InsertTemplate(WorkPermitEdmonton workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, AddInsertParametersForTemplate, "InsertWorkPermitTemplate");
            //InserttTemplateCategory(workPermit);
            return workPermit;
        }
        private static void AddInsertParametersForTemplate(WorkPermitEdmonton workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.IdValue);
            command.AddParameter("@PermitNumber", workPermit.PermitNumber);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@IsTemplate", workPermit.IsTemplate);
            command.AddParameter("@CreatedByUser", workPermit.TemplateCreatedBy);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@WorkPermitType", workPermit.WorkPermitType.Name);
            command.AddParameter("@Description", workPermit.TaskDescription);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@SiteId", workPermit.FunctionalLocation.Site.Id);

        }

        private void InserttTemplateCategory(WorkPermitEdmonton workpermit)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertTemplateCategory";
            command.AddParameter("@Id", workpermit.IdValue);
            command.AddParameter("@SiteId", workpermit.FunctionalLocation.Site.Id);
            command.AddParameter("@Categories", workpermit.Categories);
            command.ExecuteNonQuery();
        }

        public WorkPermitEdmonton QueryByIdTemplate(long id, string templateName, string categories)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryByIdTemplate<WorkPermitEdmonton>(id, templateName, categories, PopulateInstanceWpTemplate, "QueryWorkPermitTemplateNameandCategory");
        }
        private WorkPermitEdmonton PopulateInstanceWpTemplate(SqlDataReader reader)
        {
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            WorkPermitEdmonton workPermit = new WorkPermitEdmonton(templateName, categories);

            return workPermit;

        }

        public void Update(WorkPermitEdmonton workPermit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermit.Id);
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            command.Update(workPermit, AddUpdateParameters, UpdateStoredProcedure);
            SetPermitNumber(workPermit, permitNumberParameter);
            MaybeSetZeroEnergyFormNumber(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
       
        }

        public void Remove(WorkPermitEdmonton workPermit)
        {
            ManagedCommand.Remove(workPermit, RemoveStoredProcedure);
        }

//Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        public void RemoveTemplate(WorkPermitEdmonton workPermit)
        {
            string spname = "RemoveWorkPermitTemplate";

            ManagedCommand.ExecuteNonQuery(workPermit, spname, AddRemoveTemplateParameters);
        }

        private static void AddRemoveTemplateParameters(WorkPermitEdmonton workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);
        }

        //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        public WorkPermitEdmonton UpdateTemplate(WorkPermitEdmonton workPermit)
        {
            SqlCommand command = ManagedCommand;

            command.Insert(workPermit, UpdateParametersForTemplate, "UpdateWorkPermitTemplate");

            return workPermit;
        }

        private static void UpdateParametersForTemplate(WorkPermitEdmonton workPermit, SqlCommand command)
        {
            command.AddParameter("@Id", workPermit.TemplateId);
            command.AddParameter("@TemplateName", workPermit.TemplateName);
            command.AddParameter("@Categories", workPermit.Categories);
            command.AddParameter("@Global", workPermit.Global);
            command.AddParameter("@Individual", workPermit.Individual);
            command.AddParameter("@LastModifiedUserId", workPermit.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", workPermit.LastModifiedDateTime);

        }

        public List<WorkPermitEdmonton> QueryByFormGN59Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN59Id", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn59Id);
        }

        public List<WorkPermitEdmonton> QueryByFormGN7Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN7Id", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn7Id);
        }

        public List<WorkPermitEdmonton> QueryByFormGN24Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN24Id", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn24Id);        
        }

        public List<WorkPermitEdmonton> QueryByFormGN6Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN6Id", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn6Id);        
        }

        public List<WorkPermitEdmonton> QueryByFormGN75AId(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN75AId", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn75AId);
        }

        public List<WorkPermitEdmonton> QueryByFormGN1Id(long id)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@FormGN1Id", id);
            return command.QueryForListResult<WorkPermitEdmonton>(PopulateInstance, QueryByFormGn1Id);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByWorkPermitEdmontonId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedWorkPermitEdmonton);
        }

        private void AddUpdateParameters(WorkPermitEdmonton workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", workPermit.WorkPermitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id && workPermit.PermitNumber == null);

            if (workPermit.IssuedByUser != null)
            {
                command.AddParameter("IssuedByUserId", workPermit.IssuedByUser.IdValue);
            }
            //command.AddParameter("@TemplateName", workPermit.TemplateName);
            //command.AddParameter("@IsTemplate", workPermit.IsTemplate);
            //command.AddParameter("@IsActiveTemplate", workPermit.IsActiveTemplate);

            AddInsertOrUpdateParameters(workPermit, command);
        }

       

        private void AddInsertParameters(WorkPermitEdmonton workPermit, SqlCommand command)
        {            
            command.AddParameter("ShouldCreatePermitNumber", workPermit.WorkPermitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id);
            command.AddParameter("DataSourceId", workPermit.DataSource.IdValue);
            
            command.AddParameter("CreatedDateTime", workPermit.CreatedDateTime);
            command.AddParameter("CreatedByUserId", workPermit.CreatedBy.IdValue);
            command.AddParameter("ClonedFormDetailEdmonton", workPermit.ClonedFormDetailEdmonton); // Added by Vibhor : DMND0011077 - Work Permit Clone History

            if (workPermit.PermitRequestCreatedByUser != null)
            {
                command.AddParameter("PermitRequestCreatedByUserId", workPermit.PermitRequestCreatedByUser.IdValue);
            }

            AddInsertOrUpdateParameters(workPermit, command);
        }

        private void AddInsertOrUpdateParameters(WorkPermitEdmonton workPermit, SqlCommand command)
        {            
            command.AddParameter("WorkPermitStatusId", workPermit.WorkPermitStatus.IdValue);

            command.AddParameter("WorkPermitTypeId", workPermit.WorkPermitType.IdValue);
            command.AddParameter("DurationPermit", workPermit.DurationPermit);
            command.AddParameter("IssuedToSuncor", workPermit.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", workPermit.IssuedToCompany);
            command.AddParameter("Company", workPermit.Company);
            command.AddParameter("Occupation", workPermit.Occupation);
            command.AddParameter("GroupId", workPermit.Group == null ? null : workPermit.Group.Id);
            command.AddParameter("NumberOfWorkers", workPermit.NumberOfWorkers);            
            command.AddParameter("FunctionalLocationId", workPermit.FunctionalLocation.IdValue);
            command.AddParameter("Location", workPermit.Location);
            command.AddParameter("AreaLabelId", workPermit.AreaLabel == null ? null : workPermit.AreaLabel.Id);
            command.AddParameter("OtherAreasAndOrUnitsAffected", workPermit.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", workPermit.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", workPermit.OtherAreasAndOrUnitsAffectedPersonNotified);
            command.AddParameter("SpecialWork", workPermit.SpecialWork);
            command.AddParameter("SpecialWorkFormNumber", workPermit.SpecialWorkFormNumber);
            //command.AddParameter("SpecialWorkType", workPermit.SpecialWorkType != null ? workPermit.SpecialWorkType.Id : null);
            command.AddParameter("SpecialWorkType", workPermit.specialworktype != null ? workPermit.specialworktype.Id : null);//mangesh for SpecialWork
            command.AddParameter("VehicleEntry", workPermit.VehicleEntry);
            command.AddParameter("VehicleEntryTotal", workPermit.VehicleEntryTotal);
            command.AddParameter("VehicleEntryType", workPermit.VehicleEntryType);
            command.AddParameter("RescuePlan", workPermit.RescuePlan);
            command.AddParameter("RescuePlanFormNumber", workPermit.RescuePlanFormNumber);
            command.AddParameter("GN59", workPermit.GN59);
            command.AddParameter("FormGN59Id", workPermit.FormGN59 == null ? null : workPermit.FormGN59.Id);
            command.AddParameter("GN6", workPermit.GN6);
            command.AddParameter("FormGN6Id", workPermit.FormGN6 == null ? null : workPermit.FormGN6.Id);
            command.AddParameter("GN7", workPermit.GN7);
            command.AddParameter("FormGN7Id", workPermit.FormGN7 == null ? null : workPermit.FormGN7.Id);
            command.AddParameter("GN24", workPermit.GN24);
            command.AddParameter("FormGN24Id", workPermit.FormGN24 == null ? null : workPermit.FormGN24.Id);
            command.AddParameter("GN75A", workPermit.GN75A);
            command.AddParameter("FormGN75AId", workPermit.FormGN75A == null ? null : workPermit.FormGN75A.Id);
            command.AddParameter("GN6_Deprecated", workPermit.GN6_Deprecated.IdValue);
            command.AddParameter("GN11", workPermit.GN11.IdValue);
            command.AddParameter("GN24_Deprecated", workPermit.GN24_Deprecated.IdValue);
            command.AddParameter("GN27", workPermit.GN27.IdValue);
            command.AddParameter("GN75_Deprecated", workPermit.GN75_Deprecated.IdValue);

            command.AddParameter("GN1", workPermit.GN1);
            command.AddParameter("FormGN1Id", workPermit.FormGN1 == null ? null : workPermit.FormGN1.Id);
            command.AddParameter("FormGN1TradeChecklistId", workPermit.FormGN1TradeChecklistId);
            command.AddParameter("FormGN1TradeChecklistDisplayNumber", workPermit.FormGN1TradeChecklistDisplayNumber);

            command.AddParameter("RequestedStartDateTime", workPermit.RequestedStartDateTime);
            command.AddParameter("IssuedDateTime", workPermit.IssuedDateTime);
            command.AddParameter("ExpiredDateTime", workPermit.ExpiredDateTime);
            command.AddParameter("WorkOrderNumber", workPermit.WorkOrderNumber);
            command.AddParameter("OperationNumber", workPermit.OperationNumber);
            command.AddParameter("SubOperationNumber", workPermit.SubOperationNumber);
            command.AddParameter("TaskDescription", workPermit.TaskDescription);
            command.AddParameter("HazardsAndOrRequirements", workPermit.HazardsAndOrRequirements);

            command.AddParameter("StatusOfPipingEquipmentSectionNotApplicableToJob", workPermit.StatusOfPipingEquipmentSectionNotApplicableToJob);
            command.AddParameter("ProductNormallyInPipingEquipment", workPermit.ProductNormallyInPipingEquipment);
            command.AddParameter("IsolationValvesLocked", YesNoNotApplicableToBoolean(workPermit.IsolationValvesLocked));
            command.AddParameter("DepressuredDrained", YesNoNotApplicableToBoolean(workPermit.DepressuredDrained));
            command.AddParameter("Ventilated", YesNoNotApplicableToBoolean(workPermit.Ventilated));
            command.AddParameter("Purged", YesNoNotApplicableToBoolean(workPermit.Purged));
            command.AddParameter("BlindedAndTagged", YesNoNotApplicableToBoolean(workPermit.BlindedAndTagged));
            command.AddParameter("DoubleBlockAndBleed", YesNoNotApplicableToBoolean(workPermit.DoubleBlockAndBleed));
            command.AddParameter("ElectricalLockout", YesNoNotApplicableToBoolean(workPermit.ElectricalLockout));
            command.AddParameter("MechanicalLockout", YesNoNotApplicableToBoolean(workPermit.MechanicalLockout));
            command.AddParameter("BlindSchematicAvailable", YesNoNotApplicableToBoolean(workPermit.BlindSchematicAvailable));

            command.AddParameter("ZeroEnergyFormNumber", workPermit.ZeroEnergyFormNumber);
            command.AddParameter("LockBoxNumber", workPermit.LockBoxNumber);
            command.AddParameter("JobsiteEquipmentInspected", workPermit.JobsiteEquipmentInspected);
            command.AddParameter("ConfinedSpaceWorkSectionNotApplicableToJob", workPermit.ConfinedSpaceWorkSectionNotApplicableToJob);

            command.AddParameter("QuestionOneResponse", YesNoNotApplicableToBoolean(workPermit.QuestionOneResponse));
            command.AddParameter("QuestionTwoResponse", YesNoNotApplicableToBoolean(workPermit.QuestionTwoResponse));
            command.AddParameter("QuestionTwoAResponse", YesNoNotApplicableToBoolean(workPermit.QuestionTwoAResponse));
            command.AddParameter("QuestionTwoBResponse", YesNoNotApplicableToBoolean(workPermit.QuestionTwoBResponse));
            command.AddParameter("QuestionThreeResponse", YesNoNotApplicableToBoolean(workPermit.QuestionThreeResponse));
            command.AddParameter("QuestionFourResponse", YesNoNotApplicableToBoolean(workPermit.QuestionFourResponse));

            command.AddParameter("GasTestsSectionNotApplicableToJob", workPermit.GasTestsSectionNotApplicableToJob);
            command.AddParameter("WorkerToProvideGasTestData", workPermit.WorkerToProvideGasTestData);
            command.AddParameter("OperatorGasDetectorNumber", workPermit.OperatorGasDetectorNumber);
            command.AddParameter("GasTestDataLine1CombustibleGas", workPermit.GasTestDataLine1CombustibleGas);
            command.AddParameter("GasTestDataLine1Oxygen", workPermit.GasTestDataLine1Oxygen);
            command.AddParameter("GasTestDataLine1ToxicGas", workPermit.GasTestDataLine1ToxicGas);
            command.AddParameter("GasTestDataLine1Time", ConvertTimeToDateTimeOrNull(workPermit.GasTestDataLine1Time));
            command.AddParameter("GasTestDataLine2CombustibleGas", workPermit.GasTestDataLine2CombustibleGas);
            command.AddParameter("GasTestDataLine2Oxygen", workPermit.GasTestDataLine2Oxygen);
            command.AddParameter("GasTestDataLine2ToxicGas", workPermit.GasTestDataLine2ToxicGas);
            command.AddParameter("GasTestDataLine2Time", ConvertTimeToDateTimeOrNull(workPermit.GasTestDataLine2Time));
            command.AddParameter("GasTestDataLine3CombustibleGas", workPermit.GasTestDataLine3CombustibleGas);
            command.AddParameter("GasTestDataLine3Oxygen", workPermit.GasTestDataLine3Oxygen);
            command.AddParameter("GasTestDataLine3ToxicGas", workPermit.GasTestDataLine3ToxicGas);
            command.AddParameter("GasTestDataLine3Time", ConvertTimeToDateTimeOrNull(workPermit.GasTestDataLine3Time));
            command.AddParameter("GasTestDataLine4CombustibleGas", workPermit.GasTestDataLine4CombustibleGas);
            command.AddParameter("GasTestDataLine4Oxygen", workPermit.GasTestDataLine4Oxygen);
            command.AddParameter("GasTestDataLine4ToxicGas", workPermit.GasTestDataLine4ToxicGas);
            command.AddParameter("GasTestDataLine4Time", ConvertTimeToDateTimeOrNull(workPermit.GasTestDataLine4Time));
            command.AddParameter("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob", workPermit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            command.AddParameter("FaceShield", workPermit.FaceShield);
            command.AddParameter("Goggles", workPermit.Goggles);
            command.AddParameter("RubberBoots", workPermit.RubberBoots);
            command.AddParameter("RubberGloves", workPermit.RubberGloves);
            command.AddParameter("RubberSuit", workPermit.RubberSuit);

            command.AddParameter("SafetyHarnessLifeline", workPermit.SafetyHarnessLifeline);
            command.AddParameter("HighVoltagePPE", workPermit.HighVoltagePPE);
            command.AddParameter("Other1Checked", workPermit.Other1Checked);
            command.AddParameter("Other1", workPermit.Other1);
            command.AddParameter("EquipmentGrounded", workPermit.EquipmentGrounded);

            command.AddParameter("FireBlanket", workPermit.FireBlanket);
            command.AddParameter("FireExtinguisher", workPermit.FireExtinguisher);
            command.AddParameter("FireMonitorManned", workPermit.FireMonitorManned);
            command.AddParameter("FireWatch", workPermit.FireWatch);
            command.AddParameter("SewersDrainsCovered", workPermit.SewersDrainsCovered);

            command.AddParameter("SteamHose", workPermit.SteamHose);
            command.AddParameter("Other2Checked", workPermit.Other2Checked);
            command.AddParameter("Other2", workPermit.Other2);
            command.AddParameter("AirPurifyingRespirator", workPermit.AirPurifyingRespirator);
            command.AddParameter("BreathingAirApparatus", workPermit.BreathingAirApparatus);

            command.AddParameter("DustMask", workPermit.DustMask);
            command.AddParameter("LifeSupportSystem", workPermit.LifeSupportSystem);
            command.AddParameter("SafetyWatch", workPermit.SafetyWatch);
            command.AddParameter("ContinuousGasMonitor", workPermit.ContinuousGasMonitor);
            command.AddParameter("WorkersMonitor", workPermit.WorkersMonitor);
            command.AddParameter("WorkersMonitorNumber", workPermit.WorkersMonitorNumber);

            command.AddParameter("BumpTestMonitorPriorToUse", workPermit.BumpTestMonitorPriorToUse);
            command.AddParameter("Other3Checked", workPermit.Other3Checked);
            command.AddParameter("Other3", workPermit.Other3);
            command.AddParameter("AirMover", workPermit.AirMover);
            command.AddParameter("BarriersSigns", workPermit.BarriersSigns);

            command.AddParameter("RadioChannel", workPermit.RadioChannel);
            command.AddParameter("RadioChannelNumber", workPermit.RadioChannelNumber);
            command.AddParameter("AirHorn", workPermit.AirHorn);
            command.AddParameter("MechVentilationComfortOnly", workPermit.MechVentilationComfortOnly);
            command.AddParameter("AsbestosMMCPrecautions", workPermit.AsbestosMMCPrecautions);
            command.AddParameter("Other4Checked", workPermit.Other4Checked);
            command.AddParameter("Other4", workPermit.Other4);
            
            command.AddParameter("AlkylationEntry", workPermit.AlkylationEntry);
            command.AddParameter("AlkylationEntryClassOfClothing", workPermit.AlkylationEntryClassOfClothing);
            command.AddParameter("FlarePitEntry", workPermit.FlarePitEntry);
            command.AddParameter("FlarePitEntryType", workPermit.FlarePitEntryType);
            command.AddParameter("ConfinedSpace", workPermit.ConfinedSpace);
            command.AddParameter("ConfinedSpaceCardNumber", workPermit.ConfinedSpaceCardNumber);
            command.AddParameter("ConfinedSpaceClass", workPermit.ConfinedSpaceClass);

            command.AddParameter("LastModifiedByUserId", workPermit.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", workPermit.LastModifiedDateTime);

            command.AddParameter("PermitAcceptor", workPermit.PermitAcceptor);
            command.AddParameter("ShiftSupervisor", workPermit.ShiftSupervisor);
            command.AddParameter("UseCurrentPermitNumberForZeroEnergyFormNumber", workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber);
            command.AddParameter("UsePreviousPermitAnswered", workPermit.UsePreviousPermitAnswered);

            command.AddParameter("PriorityId", workPermit.Priority.IdValue);
            //mangesh for RoadAccessOnPermit & SpecialWork
            command.AddParameter("RoadAccessOnPermit", workPermit.RoadAccessOnPermit);
            command.AddParameter("RoadAccessOnPermitFormNumber", workPermit.RoadAccessOnPermitFormNumber);
            command.AddParameter("RoadAccessOnPermitType", workPermit.RoadAccessOnPermitType);

            command.AddParameter("SpecialWorkName", workPermit.SpecialWorkName);
        }

        private bool? YesNoNotApplicableToBoolean(YesNoNotApplicable value)
        {
            if (value == null)
            {
                return null;
            }

            return value.BoolValue;
        }

        private DateTime? ConvertTimeToDateTimeOrNull(Time time)
        {
            if (time == null)
            {
                return null;
            }

            return time.ToDateTime();
        }

        private WorkPermitEdmonton PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");

            DataSource dataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));
            PermitRequestBasedWorkPermitStatus status = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatusId"));
            WorkPermitEdmontonType type = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId"));
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            WorkPermitEdmontonGroup group = groupDao.QueryById(reader.Get<long>("GroupId"));

            WorkPermitEdmonton permit = new WorkPermitEdmonton(dataSource, status, type, createdDateTime, createdBy)
                {
                    Id = id,
                    UsePreviousPermitAnswered = reader.Get<bool>("UsePreviousPermitAnswered"),
                    Priority = Priority.GetById(reader.Get<int>("PriorityId")),
                    DurationPermit = reader.Get<bool>("DurationPermit"),
                    PermitNumber = reader.Get<long?>("PermitNumber"),
                    IssuedToSuncor = reader.Get<bool>("IssuedToSuncor"),
                    IssuedToCompany = reader.Get<bool>("IssuedToCompany"),
                    Company = reader.Get<string>("Company"),
                    Occupation = reader.Get<string>("Occupation"),
                    Group = @group,
                    NumberOfWorkers = reader.Get<int?>("NumberOfWorkers"),
                    FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId")),
                    Location = reader.Get<string>("Location"),
                    OtherAreasAndOrUnitsAffected = reader.Get<bool>("OtherAreasAndOrUnitsAffected"),
                    OtherAreasAndOrUnitsAffectedArea = reader.Get<string>("OtherAreasAndOrUnitsAffectedArea"),
                    OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<string>("OtherAreasAndOrUnitsAffectedPersonNotified"),
                    SpecialWork = reader.Get<bool>("SpecialWork"),
                    SpecialWorkFormNumber = reader.Get<string>("SpecialWorkFormNumber"),
                    SpecialWorkType = EdmontonPermitSpecialWorkType.FindById(reader.Get<int?>("SpecialWorkType")),
                    VehicleEntry = reader.Get<bool>("VehicleEntry"),
                    VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal"),
                    VehicleEntryType = reader.Get<string>("VehicleEntryType"),
                    RescuePlan = reader.Get<bool>("RescuePlan"),
                    //mangesh for RoadAccessOnPermit & SpecialWork
                    RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1"),
                    RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1"),
                    RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1"),
                    ClonedFormDetailEdmonton = reader.Get<string>("ClonedFormDetailEdmonton"), // Added by Vibhor : DMND0011077 - Work Permit Clone History

                    //TemplateName = reader.Get<string>("TemplateName"),
                    //IsTemplate = reader.Get<bool>("IsTemplate"),
                    //IsActiveTemplate = reader.Get<bool>("IsActiveTemplate"),

                    SpecialWorkName =IsColumnExists(reader, "SpecialWorkName") ? reader.Get<string>("SpecialWorkName") : null,
                };

            long? areaLabelId = reader.Get<long?>("AreaLabelId");
            if (areaLabelId != null)
            {
                permit.AreaLabel = areaLabelDao.QueryById(areaLabelId.Value);
            }

            permit.GN59 = reader.Get<bool>("GN59");
            long? formGN59Id = reader.Get<long?>("FormGN59Id");
            if (formGN59Id != null)
            {
                permit.FormGN59 = formGN59Dao.QueryById(formGN59Id.Value);
            }

            permit.GN7 = reader.Get<bool>("GN7");
            long? formGN7Id = reader.Get<long?>("FormGN7Id");
            if (formGN7Id != null)
            {
                permit.FormGN7 = formGN7Dao.QueryById(formGN7Id.Value);
            }

            permit.GN24 = reader.Get<bool>("GN24");
            long? formGN24Id = reader.Get<long?>("FormGN24Id");
            if (formGN24Id != null)
            {
                permit.FormGN24 = formGN24Dao.QueryById(formGN24Id.Value);
            }

            permit.GN6 = reader.Get<bool>("GN6");
            long? formGN6Id = reader.Get<long?>("FormGN6Id");
            if (formGN6Id != null)
            {
                permit.FormGN6 = formGN6Dao.QueryById(formGN6Id.Value);
            }

            permit.GN75A = reader.Get<bool>("GN75A");
            long? formGN75AId = reader.Get<long?>("FormGN75AId");
            if (formGN75AId != null)
            {
                permit.FormGN75A = formGN75ADao.QueryById(formGN75AId.Value);
            }

            permit.GN1 = reader.Get<bool>("GN1");
            long? formGN1Id = reader.Get<long?>("FormGN1Id");
            if (formGN1Id != null)
            {
                permit.FormGN1 = formGN1Dao.QueryById(formGN1Id.Value);
            }

            permit.FormGN1TradeChecklistId = reader.Get<long?>("FormGN1TradeChecklistId");
            permit.FormGN1TradeChecklistDisplayNumber = reader.Get<string>("FormGN1TradeChecklistDisplayNumber");

            permit.GN11 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN11"));
            permit.GN6_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN6_Deprecated"));
            permit.GN24_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN24_Deprecated"));
            permit.GN27 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN27"));
            permit.GN75_Deprecated = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN75_Deprecated"));

            permit.RequestedStartDateTime = reader.Get<DateTime>("RequestedStartDateTime");
            permit.IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime");
            permit.ExpiredDateTime = reader.Get<DateTime>("ExpiredDateTime");
            permit.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            permit.OperationNumber = reader.Get<string>("OperationNumber");
            permit.SubOperationNumber = reader.Get<string>("SubOperationNumber");
            permit.TaskDescription = reader.Get<string>("TaskDescription");
            permit.HazardsAndOrRequirements = reader.Get<string>("HazardsAndOrRequirements");
            permit.StatusOfPipingEquipmentSectionNotApplicableToJob = reader.Get<bool>("StatusOfPipingEquipmentSectionNotApplicableToJob");
            permit.ProductNormallyInPipingEquipment = reader.Get<string>("ProductNormallyInPipingEquipment");
            permit.IsolationValvesLocked = YesNoNotApplicable.FindForValue(reader.Get<bool?>("IsolationValvesLocked"));
            permit.DepressuredDrained = YesNoNotApplicable.FindForValue(reader.Get<bool?>("DepressuredDrained"));
            permit.Ventilated = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Ventilated"));
            permit.Purged = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Purged"));
            permit.BlindedAndTagged = YesNoNotApplicable.FindForValue(reader.Get<bool?>("BlindedAndTagged"));
            permit.DoubleBlockAndBleed = YesNoNotApplicable.FindForValue(reader.Get<bool?>("DoubleBlockAndBleed"));
            permit.ElectricalLockout = YesNoNotApplicable.FindForValue(reader.Get<bool?>("ElectricalLockout"));
            permit.MechanicalLockout = YesNoNotApplicable.FindForValue(reader.Get<bool?>("MechanicalLockout"));
            permit.BlindSchematicAvailable = YesNoNotApplicable.FindForValue(reader.Get<bool?>("BlindSchematicAvailable"));
            permit.ZeroEnergyFormNumber = reader.Get<string>("ZeroEnergyFormNumber");
            permit.LockBoxNumber = reader.Get<string>("LockBoxNumber");
            permit.JobsiteEquipmentInspected = reader.Get<bool>("JobsiteEquipmentInspected");
            permit.ConfinedSpaceWorkSectionNotApplicableToJob = reader.Get<bool>("ConfinedSpaceWorkSectionNotApplicableToJob");

            permit.DocumentLinks = documentLinkDao.QueryByWorkPermitEdmontonId(id);

            permit.QuestionOneResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionOneResponse"));
            permit.QuestionTwoResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionTwoResponse"));
            permit.QuestionTwoAResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionTwoAResponse"));
            permit.QuestionTwoBResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionTwoBResponse"));
            permit.QuestionThreeResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionThreeResponse"));
            permit.QuestionFourResponse = YesNoNotApplicable.FindForValue(reader.Get<bool?>("QuestionFourResponse"));

            permit.GasTestsSectionNotApplicableToJob = reader.Get<bool>("GasTestsSectionNotApplicableToJob");
            permit.WorkerToProvideGasTestData = reader.Get<bool>("WorkerToProvideGasTestData");
            permit.OperatorGasDetectorNumber = reader.Get<string>("OperatorGasDetectorNumber");
            permit.GasTestDataLine1CombustibleGas = reader.Get<string>("GasTestDataLine1CombustibleGas");
            permit.GasTestDataLine1Oxygen = reader.Get<string>("GasTestDataLine1Oxygen");
            permit.GasTestDataLine1ToxicGas = reader.Get<string>("GasTestDataLine1ToxicGas");
            permit.GasTestDataLine1Time = GetTime(reader.Get<DateTime?>("GasTestDataLine1Time"));
            permit.GasTestDataLine2CombustibleGas = reader.Get<string>("GasTestDataLine2CombustibleGas");
            permit.GasTestDataLine2Oxygen = reader.Get<string>("GasTestDataLine2Oxygen");
            permit.GasTestDataLine2ToxicGas = reader.Get<string>("GasTestDataLine2ToxicGas");
            permit.GasTestDataLine2Time = GetTime(reader.Get<DateTime?>("GasTestDataLine2Time"));
            permit.GasTestDataLine3CombustibleGas = reader.Get<string>("GasTestDataLine3CombustibleGas");
            permit.GasTestDataLine3Oxygen = reader.Get<string>("GasTestDataLine3Oxygen");
            permit.GasTestDataLine3ToxicGas = reader.Get<string>("GasTestDataLine3ToxicGas");
            permit.GasTestDataLine3Time = GetTime(reader.Get<DateTime?>("GasTestDataLine3Time"));
            permit.GasTestDataLine4CombustibleGas = reader.Get<string>("GasTestDataLine4CombustibleGas");
            permit.GasTestDataLine4Oxygen = reader.Get<string>("GasTestDataLine4Oxygen");
            permit.GasTestDataLine4ToxicGas = reader.Get<string>("GasTestDataLine4ToxicGas");
            permit.GasTestDataLine4Time = GetTime(reader.Get<DateTime?>("GasTestDataLine4Time"));
            permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<bool>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            permit.FaceShield = reader.Get<bool>("FaceShield");
            permit.Goggles = reader.Get<bool>("Goggles");
            permit.RubberBoots = reader.Get<bool>("RubberBoots");
            permit.RubberGloves = reader.Get<bool>("RubberGloves");
            permit.RubberSuit = reader.Get<bool>("RubberSuit");
            permit.SafetyHarnessLifeline = reader.Get<bool>("SafetyHarnessLifeline");
            permit.HighVoltagePPE = reader.Get<bool>("HighVoltagePPE");
            permit.Other1Checked = reader.Get<bool>("Other1Checked");
            permit.Other1 = reader.Get<string>("Other1");
            permit.EquipmentGrounded = reader.Get<bool>("EquipmentGrounded");
            permit.FireBlanket = reader.Get<bool>("FireBlanket");
            permit.FireExtinguisher = reader.Get<bool>("FireExtinguisher");
            permit.FireMonitorManned = reader.Get<bool>("FireMonitorManned");
            permit.FireWatch = reader.Get<bool>("FireWatch");
            permit.SewersDrainsCovered = reader.Get<bool>("SewersDrainsCovered");
            permit.SteamHose = reader.Get<bool>("SteamHose");
            permit.Other2Checked = reader.Get<bool>("Other2Checked");
            permit.Other2 = reader.Get<string>("Other2");
            permit.AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator");
            permit.BreathingAirApparatus = reader.Get<bool>("BreathingAirApparatus");
            permit.DustMask = reader.Get<bool>("DustMask");
            permit.LifeSupportSystem = reader.Get<bool>("LifeSupportSystem");
            permit.SafetyWatch = reader.Get<bool>("SafetyWatch");
            permit.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");
            permit.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            permit.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            permit.BumpTestMonitorPriorToUse = reader.Get<bool>("BumpTestMonitorPriorToUse");
            permit.Other3Checked = reader.Get<bool>("Other3Checked");
            permit.Other3 = reader.Get<string>("Other3");
            permit.AirMover = reader.Get<bool>("AirMover");
            permit.BarriersSigns = reader.Get<bool>("BarriersSigns");
            permit.RadioChannel = reader.Get<bool>("RadioChannel");
            permit.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            permit.AirHorn = reader.Get<bool>("AirHorn");
            permit.MechVentilationComfortOnly = reader.Get<bool>("MechVentilationComfortOnly");
            permit.AsbestosMMCPrecautions = reader.Get<bool>("AsbestosMMCPrecautions");
            permit.Other4Checked = reader.Get<bool>("Other4Checked");
            permit.Other4 = reader.Get<string>("Other4");

            permit.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            permit.AlkylationEntryClassOfClothing = reader.Get<string>("AlkylationEntryClassOfClothing");
            permit.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            permit.FlarePitEntryType = reader.Get<string>("FlarePitEntryType");
            permit.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            permit.ConfinedSpaceCardNumber = reader.Get<string>("ConfinedSpaceCardNumber");
            permit.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");

            long? permitRequestCreatedByUserId = reader.Get<long?>("PermitRequestCreatedByUserId");
            permit.PermitRequestCreatedByUser = permitRequestCreatedByUserId != null ? userDao.QueryById(permitRequestCreatedByUserId.Value) : null;
            
            permit.LastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            permit.LastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            permit.UseCurrentPermitNumberForZeroEnergyFormNumber = reader.Get<bool>("UseCurrentPermitNumberForZeroEnergyFormNumber");

            permit.PermitAcceptor = reader.Get<string>("PermitAcceptor");
            permit.ShiftSupervisor = reader.Get<string>("ShiftSupervisor");

            long? issuedByUserId = reader.Get<long?>("IssuedByUserId");
            permit.IssuedByUser = issuedByUserId != null ? userDao.QueryById(issuedByUserId.Value) : null;

            return permit;
        }

        private Time GetTime(DateTime? value)
        {
            if (value == null)
            {
                return null;
            }

            return new Time(value.Value);
        }

        private static void SetPermitNumber(WorkPermitEdmonton workPermit, SqlParameter permitNumberParameter)
        {
            if (permitNumberParameter.Value == DBNull.Value)
            {
                workPermit.PermitNumber = null;
            }
            else
            {
                workPermit.PermitNumber = (long) permitNumberParameter.Value;
            }
        }

        private static void MaybeSetZeroEnergyFormNumber(WorkPermitEdmonton workPermit)
        {
            if (workPermit.ZeroEnergyFormNumber.IsNullOrEmptyOrWhitespace() && workPermit.UseCurrentPermitNumberForZeroEnergyFormNumber && workPermit.PermitNumber != null)
            {
                workPermit.ZeroEnergyFormNumber = workPermit.PermitNumber.ToString();
            }
        }

        public WorkPermitEdmonton QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitEdmonton permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", permit.IdValue);
            return command.QueryForSingleResult<WorkPermitEdmonton>(PopulateInstance, "QueryWorkPermitEdmontonForReuse");
        }

        public bool DoesPermitRequestEdmontonAssociationExist(List<long> permitRequests, Range<DateTime> rangeOfExistingPermits)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStartDateTime", rangeOfExistingPermits.LowerBound);
            command.AddParameter("@WorkPermitEndDateTime", rangeOfExistingPermits.UpperBound);

            string permitRequestIds = permitRequests.ToCommaSeparatedString();
            command.AddParameter("@PermitRequestIds", permitRequestIds);

            int count = command.GetCount(QueryDoesPermitRequestEdmontonAssociationExist);

            return count > 0;
        }
        private static bool IsColumnExists(System.Data.IDataReader dr, string columnName)
        {
            bool retVal = false;

            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                retVal = true;
            }
            return retVal;
        }





        //Mukesh -DMND0010609-OLT - Work permit Scan and Index
       public void InsertWorkpermitScan(WorkpermitScan Scan)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "InsertWorkPermitDocument";
            command.AddParameter("@WorkPermitId", Scan.WorkPermitId);
            command.AddParameter("@DocumentPath", Scan.DocumentPath);
            command.AddParameter("@CreatedBy", Scan.CreatedBy.Id);
            command.AddParameter("@CreatedDate", Scan.CreatedDate);
            command.AddParameter("@SiteId", Scan.SiteId);
            command.AddParameter("@UploadedDocumentType",Scan.UploadedDocumentType);
            command.AddParameter("@Comment", Scan.Comment);

            command.Insert("InsertWorkPermitDocument");
          // ExecuteNonQuery();
        }
       
       public List<WorkpermitScan> GetWorkpermitScan(string WorkPermitId, int siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitId",WorkPermitId );
            command.AddParameter("@SiteId", siteId);
           // command.CommandText = "GetWorkPermitDocument";
            return command.QueryForListResult<WorkpermitScan>(WorkpermitScan,"GetWorkPermitDocument");
            
        }

       public WorkpermitScan WorkpermitScan(SqlDataReader reader)
       {
          // List<WorkpermitScan> lst = new List<WorkpermitScan>();
               WorkpermitScan Scan = new WorkpermitScan();           
               Scan.Id = reader.Get<long>("ID");
               Scan.WorkPermitId = reader.Get<string>("WorkPermitId");
               Scan.DocumentPath = reader.Get<string>("DocumentPath");
               Scan.Comment = reader.Get<string>("Comment");
               Scan.UploadedDocumentType = reader.Get<string>("UploadedDocumentType"); ;
               Scan.SiteId = reader.Get<int>("SiteId"); ;
               Scan.UserName = reader.Get<string>("Username");
               Scan.CreatedDate = reader.Get<DateTime>("CreatedDate");
                return Scan;
       }

       public List<ScanDocumentType> GetWorkPermitDocumentType(long siteId)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@SiteId", siteId);
          // command.CommandText = "GetWorkPermitDocumentType";
           return command.QueryForListResult<ScanDocumentType>(WorkpermitDocumentType, "GetWorkPermitDocumentType");
          
       }

       public ScanDocumentType WorkpermitDocumentType(SqlDataReader reader)
       {
           ScanDocumentType PermityCopyType = new ScanDocumentType();
               PermityCopyType.Text = reader.Get<string>("DocumentType");
               PermityCopyType.Tag = reader.Get<string>("DocumentTypeAttribution");
              return PermityCopyType;
           
       }
       public ScanCOnfiguration GetScanConfiguration(long siteId,string userlogin)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@SiteId", siteId);
           command.AddParameter("@UserLogin", userlogin);
           // command.CommandText = "GetWorkPermitDocumentType";
           return command.QueryForSingleResult<ScanCOnfiguration>(ScanConfiguration, "GetScanConfiguration");

       }
       public ScanCOnfiguration ScanConfiguration(SqlDataReader reader)
       {
           ScanCOnfiguration scanCOnfiguration = new ScanCOnfiguration();
           scanCOnfiguration.Environment = reader.Get<string>("Environment");
           scanCOnfiguration.LocalScanPath = reader.Get<string>("LocalScanPath");
           scanCOnfiguration.ScanExeName = reader.Get<string>("ScanExeName");
           scanCOnfiguration.ScanExePath = reader.Get<string>("ScanExePath");
           scanCOnfiguration.SharedPath = reader.Get<string>("SharedPath");
           return scanCOnfiguration;
           
       }
       public int isPermitnumberExist(long siteId,string @PermitNumber)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@SiteId", siteId);
           command.AddParameter("@PermitNumber", PermitNumber);
           command.CommandText = "CheckWorkPermitExist";
           object result = command.ExecuteScalar();
           result = (result == DBNull.Value) ? null : result;
           int countDis = Convert.ToInt32(result);
           return countDis;
         
       }

       public List<string> GetAutoSearchWorkpermit(long siteId)
       {
           SqlCommand command = ManagedCommand;
           command.AddParameter("@SiteId", siteId);
           return command.QueryForListResult<string>(AutoSearchWorkpermit, "GetSearchPermitNumber");

       }
       public string AutoSearchWorkpermit(SqlDataReader reader)
       {                

           return Convert.ToString(reader.Get<object>("PermitNumber"));
         

       }
    }
}
