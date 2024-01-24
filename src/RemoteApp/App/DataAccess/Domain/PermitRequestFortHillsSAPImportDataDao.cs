using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestFortHillsSAPImportDataDao : AbstractManagedDao, IPermitRequestFortHillsSAPImportDataDao
    {
        private const string INSERT_STORED_PROC = "InsertPermitRequestFortHillsSAPImportData";
        private const string QUERY_BY_WORK_ORDER_INFO_STORED_PROC = "QueryPermitRequestEdmontonSAPImportDataByWorkOrderFields";
        private const string DELETE_STORED_PROC = "DeletePermitRequestEdmontonSAPImportData";
        private const string GET_BATCH_ID = "GetNewSeqVal_PermitRequestFortHillsBatchIdSequence";
        private const string QUERY_BY_BATCH_ID = "QueryPermitRequestFortHillsSAPImportDataByBatchId";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IWorkPermitFortHillsGroupDao groupDao;
        private readonly IAreaLabelDao areaLabelDao;

        public PermitRequestFortHillsSAPImportDataDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitFortHillsGroupDao>();
            areaLabelDao = DaoRegistry.GetDao<IAreaLabelDao>();
        }

        public PermitRequestFortHillsSAPImportData Insert(PermitRequestFortHillsSAPImportData permitRequest)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(permitRequest, AddInsertParameters, INSERT_STORED_PROC);
            permitRequest.Id = (long?) idParameter.Value;
            
            return permitRequest;                
        }

        public PermitRequestFortHillsSAPImportData QueryByWorkOrderInformation(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkOrderNumber", workOrderNumber);
            command.AddParameter("@OperationNumber", operationNumber);
            command.AddParameter("@SubOperationNumber", subOperationNumber);
            return command.QueryForSingleResult<PermitRequestFortHillsSAPImportData>(PopulateInstance, QUERY_BY_WORK_ORDER_INFO_STORED_PROC);
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

        public List<PermitRequestFortHillsSAPImportData> QueryByBatchId(long batchId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@BatchId", batchId);
            return command.QueryForListResult<PermitRequestFortHillsSAPImportData>(PopulateInstance, QUERY_BY_BATCH_ID);
        }

        private void AddInsertParameters(PermitRequestFortHillsSAPImportData permitRequest, SqlCommand command)
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
            command.AddParameter("@ConfinedSpace", permitRequest.ConfinedSpace);
            command.AddParameter("@ConfinedSpaceClass", permitRequest.ConfinedSpaceClass);


            /*
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
            command.AddParameter("@RescuePlan", permitRequest.RescuePlan);
            command.AddParameter("@SpecialWork", permitRequest.SpecialWork);
             */
            command.AddParameter("@VehicleEntry", permitRequest.VehicleEntry);
            command.AddParameter("@RequestedStartDate", permitRequest.RequestedStartDate.ToDateTimeAtStartOfDay());

            command.AddParameter("@FaceShield", permitRequest.FaceShield);
            command.AddParameter("@Goggles", permitRequest.ChemicalSuit);
            command.AddParameter("@RubberBoots", permitRequest.BottleWatch);
            command.AddParameter("@RubberGloves", permitRequest.ConfinedSpaceMoniter);//**
            command.AddParameter("@RubberSuit", permitRequest.SuppliedBreathingAir);
            command.AddParameter("@SafetyHarnessLifeline", permitRequest.AirMover);
            command.AddParameter("@HighVoltagePPE", permitRequest.PersonalFlotationDevice);

            command.AddParameter("@EquipmentGrounded", permitRequest.MonoGoggles);
            command.AddParameter("@FireBlanket", permitRequest.FireBlanket);
            command.AddParameter("@FireExtinguisher", permitRequest.FireExtinguisher);
            command.AddParameter("@FireMonitorManned", permitRequest.SparkContainment);
            command.AddParameter("@FireWatch", permitRequest.FireWatch);
            command.AddParameter("@SewersDrainsCovered", permitRequest.StandbyPerson);
            command.AddParameter("@SteamHose", permitRequest.WorkingAlone);            

            command.AddParameter("@AirPurifyingRespirator", permitRequest.AirPurifyingRespirator);
            command.AddParameter("@BreathingAirApparatus", permitRequest.FallProtection);
            command.AddParameter("@DustMask", permitRequest.ChargedFireHouse);
            command.AddParameter("@LifeSupportSystem", permitRequest.CoveredSewer);
            command.AddParameter("@SafetyWatch", permitRequest.AirPurifyingRespirator);
            command.AddParameter("@ContinuousGasMonitor", permitRequest.SingalPerson);
            command.AddParameter("@WorkersMonitor", permitRequest.CommunicationDevice);
            //command.AddParameter("@WorkersMonitorNumber", permitRequest.WorkersMonitorNumber);
            command.AddParameter("@BumpTestMonitorPriorToUse", permitRequest.ReflectiveStrips);            

            command.AddParameter("@AirMover", permitRequest.AirMover);
            command.AddParameter("@BarriersSigns", permitRequest.GroundDisturbance);
            command.AddParameter("@RadioChannel", permitRequest.FireProtectionAuthorization);
            //command.AddParameter("@RadioChannelNumber", permitRequest.RadioChannelNumber);
            command.AddParameter("@AirHorn", permitRequest.CriticalOrSeriousLifts);
            command.AddParameter("@MechVentilationComfortOnly", permitRequest.VehicleEntry);
            command.AddParameter("@AsbestosMMCPrecautions", permitRequest.IndustrialRadiography);

            command.AddParameter("@DoNotMerge", permitRequest.DoNotMerge);
        }

        protected PermitRequestFortHillsSAPImportData PopulateInstance(SqlDataReader reader)
        {
            PermitRequestFortHillsSAPImportData result = BuildResult(reader);            
            return result;
        }

        private PermitRequestFortHillsSAPImportData BuildResult(SqlDataReader reader)
        {
            PermitRequestFortHillsSAPImportData result = new PermitRequestFortHillsSAPImportData(
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

            result.WorkPermitType = WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId"));
            result.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            result.Location = reader.Get<string>("Location");
           
            result.RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            long? areaLabelId = reader.Get<long?>("AreaLabelId");
            //result.SpecialWorkType = FortHillsPermitSpecialWorkType.FindById(reader.Get<int?>("SpecialWorkType"));
            //result.AreaLabel = areaLabelId == null ? null : areaLabelDao.QueryById(areaLabelId.Value);
            //result.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<bool>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");

            result.FaceShield = reader.Get<bool>("FaceShield"); //**
            result.ChemicalSuit = reader.Get<bool>("Goggles");//**
           // result.RubberBoots = reader.Get<bool>("RubberBoots");
            result.ConfinedSpaceMoniter = reader.Get<bool>("RubberGloves");//**
            result.SuppliedBreathingAir = reader.Get<bool>("RubberSuit");

            result.AirMover = reader.Get<bool>("SafetyHarnessLifeline");
            result.PersonalFlotationDevice = reader.Get<bool>("HighVoltagePPE");
            result.MonoGoggles = reader.Get<bool>("EquipmentGrounded");
            result.FireBlanket = reader.Get<bool>("FireBlanket");
            result.FireExtinguisher = reader.Get<bool>("FireExtinguisher");

            result.SparkContainment = reader.Get<bool>("FireMonitorManned");
            result.FireWatch = reader.Get<bool>("FireWatch");
            result.StandbyPerson = reader.Get<bool>("SewersDrainsCovered");
            result.WorkingAlone = reader.Get<bool>("SteamHose");
            result.AirPurifyingRespirator = reader.Get<bool>("AirPurifyingRespirator");

            //result.BreathingAirApparatus = reader.Get<bool>("BreathingAirApparatus");
            //result.DustMask = reader.Get<bool>("DustMask");
            //result.LifeSupportSystem = reader.Get<bool>("LifeSupportSystem");
            //result.SafetyWatch = reader.Get<bool>("SafetyWatch");
            //result.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");

            //result.BumpTestMonitorPriorToUse = reader.Get<bool>("BumpTestMonitorPriorToUse");
            //result.AirMover = reader.Get<bool>("AirMover");
            //result.GoundDisturbance = reader.Get<bool>("BarriersSigns");
            //result.AirHorn = reader.Get<bool>("AirHorn");
            //result.MechVentilationComfortOnly = reader.Get<bool>("MechVentilationComfortOnly");

            //result.AsbestosMMCPrecautions = reader.Get<bool>("AsbestosMMCPrecautions");
            result.Group = groupDao.QueryById(reader.Get<long>("GroupId"));

           

            result.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            result.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            result.VehicleEntry = reader.Get<bool>("VehicleEntry");

            //result.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            //result.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            //result.RescuePlan = reader.Get<bool>("RescuePlan");
            //result.SpecialWork = reader.Get<bool>("SpecialWork");
            /*
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
            */
            result.SAPWorkCentre = reader.Get<string>("SAPWorkCentre");

            result.DoNotMerge = reader.Get<bool>("DoNotMerge");

            return result;
        }

        public void Delete(PermitRequestFortHillsSAPImportData foundData)
        {
            ;
        }
    }
}
