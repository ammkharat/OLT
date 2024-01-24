using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestEdmontonSAPImportDataDao : AbstractManagedDao, IPermitRequestEdmontonSAPImportDataDao
    {
        private const string INSERT_STORED_PROC = "InsertPermitRequestEdmontonSAPImportData";
        private const string QUERY_BY_WORK_ORDER_INFO_STORED_PROC = "QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields";
        private const string DELETE_STORED_PROC = "DeletePermitRequestEdmontonSAPImportData";
        private const string GET_BATCH_ID = "GetNewSeqVal_PermitRequestEdmontonBatchIdSequence";
        private const string QUERY_BY_BATCH_ID = "QueryPermitRequestEdmontonSAPImportDataByBatchId";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IWorkPermitEdmontonGroupDao groupDao;
        private readonly IAreaLabelDao areaLabelDao;

        public PermitRequestEdmontonSAPImportDataDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitEdmontonGroupDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        public PermitRequestEdmontonSAPImportData Insert(PermitRequestEdmontonSAPImportData permitRequest)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(permitRequest, AddInsertParameters, INSERT_STORED_PROC);
            permitRequest.Id = (long?) idParameter.Value;
            
            return permitRequest;                
        }

        public PermitRequestEdmontonSAPImportData QueryByWorkOrderInformation(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);
            return command.QueryForSingleResult<PermitRequestEdmontonSAPImportData>(PopulateInstance, QUERY_BY_WORK_ORDER_INFO_STORED_PROC);
        }

        public void Delete(long batchId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@BatchId", batchId);
            command.ExecuteNonQuery(DELETE_STORED_PROC);
        }

        public long GetBatchId()
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.ExecuteNonQuery(GET_BATCH_ID);

            long batchId = (long) idParameter.Value;

            return batchId;
        }

        public List<PermitRequestEdmontonSAPImportData> QueryByBatchId(long batchId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@BatchId", batchId);
            return command.QueryForListResult<PermitRequestEdmontonSAPImportData>(PopulateInstance, QUERY_BY_BATCH_ID);
        }

        private void AddInsertParameters(PermitRequestEdmontonSAPImportData permitRequest, SqlCommand command)
        {
            command.AddParameter("@BatchId", permitRequest.BatchId);
            command.AddParameter("@BatchItemCreatedAt", permitRequest.BatchItemCreatedAt);

            command.AddParameter("@PriorityId", permitRequest.Priority.IdValue);
            command.AddParameter("@WorkOrderNumber", permitRequest.WorkOrderNumber);
            command.AddParameter("@OperationNumber", permitRequest.OperationNumber);
            command.AddParameter("@SubOperationNumber", permitRequest.SubOperationNumber);
            command.AddParameter("@EndDate", permitRequest.EndDate.ToDateTimeAtStartOfDay());
            command.AddParameter("@Description", permitRequest.Description);            
            command.AddParameter("@Company", permitRequest.Company);
            command.AddParameter("@Occupation", permitRequest.Occupation);            
            command.AddParameter("@SAPWorkCentre", permitRequest.SAPWorkCentre);
            command.AddParameter("@NumberOfWorkers", permitRequest.NumberOfWorkers);
            command.AddParameter("@GroupId", permitRequest.Group.IdValue);
            command.AddParameter("@WorkPermitTypeId", permitRequest.WorkPermitType.IdValue);
            command.AddParameter("@FunctionalLocationId", permitRequest.FunctionalLocation.IdValue);
            command.AddParameter("@Location", permitRequest.Location);
            command.AddParameter("@AreaLabelId", permitRequest.AreaLabel == null ? null : permitRequest.AreaLabel.Id);

            command.AddParameter("@SpecialWorkType", permitRequest.SpecialWorkType != null ? permitRequest.SpecialWorkType.Id : null);
            command.AddParameter("@GN59", permitRequest.GN59);
            command.AddParameter("@GN6", permitRequest.GN6);
            command.AddParameter("@GN7", permitRequest.GN7);
            command.AddParameter("@GN24", permitRequest.GN24);
            command.AddParameter("@GN75A", permitRequest.GN75A);

            command.AddParameter("@GN11", permitRequest.GN11.IdValue);
            command.AddParameter("@GN27", permitRequest.GN27.IdValue);            

            command.AddParameter("@WorkersMinimumSafetyRequirementsSectionNotApplicableToJob", permitRequest.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);

            command.AddParameter("@AlkylationEntry", permitRequest.AlkylationEntry);
            command.AddParameter("@FlarePitEntry", permitRequest.FlarePitEntry);

            command.AddParameter("@ConfinedSpace", permitRequest.ConfinedSpace);
            command.AddParameter("@ConfinedSpaceClass", permitRequest.ConfinedSpaceClass);

            command.AddParameter("@RescuePlan", permitRequest.RescuePlan);
            command.AddParameter("@VehicleEntry", permitRequest.VehicleEntry);
            command.AddParameter("@SpecialWork", permitRequest.SpecialWork);

            command.AddParameter("@RequestedStartDate", permitRequest.RequestedStartDate.ToDateTimeAtStartOfDay());

            command.AddParameter("@FaceShield", permitRequest.FaceShield);
            command.AddParameter("@Goggles", permitRequest.Goggles);
            command.AddParameter("@RubberBoots", permitRequest.RubberBoots);
            command.AddParameter("@RubberGloves", permitRequest.RubberGloves);
            command.AddParameter("@RubberSuit", permitRequest.RubberSuit);
            command.AddParameter("@SafetyHarnessLifeline", permitRequest.SafetyHarnessLifeline);
            command.AddParameter("@HighVoltagePPE", permitRequest.HighVoltagePPE);            

            command.AddParameter("@EquipmentGrounded", permitRequest.EquipmentGrounded);
            command.AddParameter("@FireBlanket", permitRequest.FireBlanket);
            command.AddParameter("@FireExtinguisher", permitRequest.FireExtinguisher);
            command.AddParameter("@FireMonitorManned", permitRequest.FireMonitorManned);
            command.AddParameter("@FireWatch", permitRequest.FireWatch);
            command.AddParameter("@SewersDrainsCovered", permitRequest.SewersDrainsCovered);
            command.AddParameter("@SteamHose", permitRequest.SteamHose);            

            command.AddParameter("@AirPurifyingRespirator", permitRequest.AirPurifyingRespirator);
            command.AddParameter("@BreathingAirApparatus", permitRequest.BreathingAirApparatus);
            command.AddParameter("@DustMask", permitRequest.DustMask);
            command.AddParameter("@LifeSupportSystem", permitRequest.LifeSupportSystem);
            command.AddParameter("@SafetyWatch", permitRequest.SafetyWatch);
            command.AddParameter("@ContinuousGasMonitor", permitRequest.ContinuousGasMonitor);
            command.AddParameter("@WorkersMonitor", permitRequest.WorkersMonitor);
            command.AddParameter("@WorkersMonitorNumber", permitRequest.WorkersMonitorNumber);
            command.AddParameter("@BumpTestMonitorPriorToUse", permitRequest.BumpTestMonitorPriorToUse);            

            command.AddParameter("@AirMover", permitRequest.AirMover);
            command.AddParameter("@BarriersSigns", permitRequest.BarriersSigns);
            command.AddParameter("@RadioChannel", permitRequest.RadioChannel);
            command.AddParameter("@RadioChannelNumber", permitRequest.RadioChannelNumber);
            command.AddParameter("@AirHorn", permitRequest.AirHorn);
            command.AddParameter("@MechVentilationComfortOnly", permitRequest.MechVentilationComfortOnly);
            command.AddParameter("@AsbestosMMCPrecautions", permitRequest.AsbestosMMCPrecautions);

            command.AddParameter("@DoNotMerge", permitRequest.DoNotMerge);
        }

        protected PermitRequestEdmontonSAPImportData PopulateInstance(SqlDataReader reader)
        {
            PermitRequestEdmontonSAPImportData result = BuildResult(reader);            
            return result;
        }

        private PermitRequestEdmontonSAPImportData BuildResult(SqlDataReader reader)
        {
            PermitRequestEdmontonSAPImportData result = new PermitRequestEdmontonSAPImportData(
                reader.Get<long>("BatchId"),
                reader.Get<DateTime>("BatchItemCreatedAt"),
                reader.Get<long>("Id"),
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("TaskDescription"),
                reader.Get<string>("Company"));

            result.Priority = Priority.GetById(reader.Get<int>("PriorityId"));
            result.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            result.OperationNumber = reader.Get<string>("OperationNumber");
            result.SubOperationNumber = reader.Get<string>("SubOperationNumber");
            result.Occupation = reader.Get<string>("Occupation");
            result.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");

            result.WorkPermitType = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId"));
            result.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            result.Location = reader.Get<string>("Location");
            result.SpecialWorkType = EdmontonPermitSpecialWorkType.FindById(reader.Get<int?>("SpecialWorkType"));
            result.RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            long? areaLabelId = reader.Get<long?>("AreaLabelId");
            result.AreaLabel = areaLabelId == null ? null : areaLabelDao.QueryById(areaLabelId.Value);

            result.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<bool>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");

            result.FaceShield = reader.Get<bool>("FaceShield");
            result.Goggles = reader.Get<bool>("Goggles");
            result.RubberBoots = reader.Get<bool>("RubberBoots");
            result.RubberGloves = reader.Get<bool>("RubberGloves");
            result.RubberSuit = reader.Get<bool>("RubberSuit");

            result.SafetyHarnessLifeline = reader.Get<bool>("SafetyHarnessLifeline");
            result.HighVoltagePPE = reader.Get<bool>("HighVoltagePPE");
            result.EquipmentGrounded = reader.Get<bool>("EquipmentGrounded");
            result.FireBlanket = reader.Get<bool>("FireBlanket");
            result.FireExtinguisher = reader.Get<bool>("FireExtinguisher");

            result.FireMonitorManned = reader.Get<bool>("FireMonitorManned");
            result.FireWatch = reader.Get<bool>("FireWatch");
            result.SewersDrainsCovered = reader.Get<bool>("SewersDrainsCovered");
            result.SteamHose = reader.Get<bool>("SteamHose");
            result.AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator");

            result.BreathingAirApparatus = reader.Get<bool>("BreathingAirApparatus");
            result.DustMask = reader.Get<bool>("DustMask");
            result.LifeSupportSystem = reader.Get<bool>("LifeSupportSystem");
            result.SafetyWatch = reader.Get<bool>("SafetyWatch");
            result.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");

            result.BumpTestMonitorPriorToUse = reader.Get<bool>("BumpTestMonitorPriorToUse");
            result.AirMover = reader.Get<bool>("AirMover");
            result.BarriersSigns = reader.Get<bool>("BarriersSigns");
            result.AirHorn = reader.Get<bool>("AirHorn");
            result.MechVentilationComfortOnly = reader.Get<bool>("MechVentilationComfortOnly");

            result.AsbestosMMCPrecautions = reader.Get<bool>("AsbestosMMCPrecautions");
            result.Group = groupDao.QueryById(reader.Get<long>("GroupId"));

            result.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            result.FlarePitEntry = reader.Get<bool>("FlarePitEntry");

            result.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            result.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");

            result.RescuePlan = reader.Get<bool>("RescuePlan");
            result.VehicleEntry = reader.Get<bool>("VehicleEntry");
            result.SpecialWork = reader.Get<bool>("SpecialWork");

            result.GN59 = reader.Get<bool>("GN59");
            result.GN7 = reader.Get<bool>("GN7");
            result.GN24 = reader.Get<bool>("GN24");
            result.GN6 = reader.Get<bool>("GN6");
            result.GN75A = reader.Get<bool>("GN75A");

            result.GN11 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN11"));
            result.GN27 = WorkPermitSafetyFormState.GetById(reader.Get<int>("GN27"));            

            result.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            result.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            result.RadioChannel = reader.Get<bool>("RadioChannel");
            result.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            result.SAPWorkCentre = reader.Get<string>("SAPWorkCentre");

            result.DoNotMerge = reader.Get<bool>("DoNotMerge");

            return result;
        }

        public void Delete(PermitRequestEdmontonSAPImportData foundData)
        {
            ;
        }
    }
}
