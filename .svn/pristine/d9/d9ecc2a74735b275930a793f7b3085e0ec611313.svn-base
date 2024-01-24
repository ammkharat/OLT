using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestEdmontonHistoryDao : AbstractManagedDao, IPermitRequestEdmontonHistoryDao
    {
        private const string QUERY_BY_ID = "QueryPermitRequestEdmontonHistoriesById";
        private const string INSERT = "InsertPermitRequestEdmontonHistory";

        private readonly IUserDao userDao;

        public PermitRequestEdmontonHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<PermitRequestEdmontonHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.AddWithValue("@Id", id);
            return command.QueryForListResult < PermitRequestEdmontonHistory>(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(PermitRequestEdmontonHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private PermitRequestEdmontonHistory PopulateInstance(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");
            User lastModifiedBy = GetUser(reader, "LastModifiedByUserId");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            
            PermitRequestEdmontonHistory history = new PermitRequestEdmontonHistory(id, lastModifiedBy, lastModifiedDate)
            {
                WorkPermitType = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId")),
                FunctionalLocation = reader.Get<string>("FunctionalLocation"),
                RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate")),
                RequestedStartTimeDay = (reader.Get<DateTime?>("RequestedStartTimeDay")).ToTime(),
                RequestedStartTimeNight = (reader.Get<DateTime?>("RequestedStartTimeNight")).ToTime(),
                Priority = Priority.GetById(reader.Get<int>("PriorityId")),
                EndDate = new Date(reader.Get<DateTime>("EndDate")),
                WorkOrderNumber = reader.Get<string>("WorkOrderNumber"),
                OperationNumber = reader.Get<string>("OperationNumber"),
                SubOperationNumber = reader.Get<string>("SubOperationNumber"),
                Description = reader.Get<string>("TaskDescription"),
                SapDescription = reader.Get<string>("SapDescription"),
                Company = reader.Get<string>("Company"),
                AreaLabel = reader.Get<string>("AreaLabel"),
                LastImportedByUser = GetUser(reader, "LastImportedByUserId"),
                LastImportedDateTime = reader.Get<DateTime?>("LastImportedDateTime"),
                LastSubmittedByUser = GetUser(reader, "LastSubmittedByUserId"),
                LastSubmittedDateTime = reader.Get<DateTime?>("LastSubmittedDateTime"),
                IssuedToSuncor = reader.Get<bool>("IssuedToSuncor")
            };

            history.Company = reader.Get<string>("Company");
            history.Occupation = reader.Get<String>("Occupation");
            history.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            history.Group = reader.Get<string>("Group");
            history.WorkPermitType = WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.Location = reader.Get<String>("Location");
            history.DocumentLinks = reader.Get<String>("DocumentLinks");
            history.AlkylationEntryClassOfClothing = reader.Get<String>("AlkylationEntryClassOfClothing");
            history.FlarePitEntryType = reader.Get<String>("FlarePitEntryType");
            history.ConfinedSpaceCardNumber = reader.Get<String>("ConfinedSpaceCardNumber");
            history.ConfinedSpaceClass = reader.Get<String>("ConfinedSpaceClass");
            history.RescuePlanFormNumber = reader.Get<String>("RescuePlanFormNumber");
            history.VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal");
            history.VehicleEntryType = reader.Get<String>("VehicleEntryType");
            history.SpecialWorkFormNumber = reader.Get<String>("SpecialWorkFormNumber");
            history.SpecialWorkType = reader.Get<String>("SpecialWorkType");
            history.FormGN59Id = reader.Get<long?>("FormGN59Id");
            history.FormGN7Id = reader.Get<long?>("FormGN7Id");
            history.FormGN24Id = reader.Get<long?>("FormGN24Id");
            history.FormGN6Id = reader.Get<long?>("FormGN6Id");
            history.FormGN75AId = reader.Get<long?>("FormGN75AId");
            history.FormGN1TradeChecklistDisplayNumber = reader.Get<string>("FormGN1TradeChecklistDisplayNumber");

            history.GN59 = reader.Get<bool>("GN59");
            history.GN7 = reader.Get<bool>("GN7");
            history.GN24 = reader.Get<bool>("GN24");
            history.GN6 = reader.Get<bool>("GN6");
            history.GN75A = reader.Get<bool>("GN75A");
            history.GN1 = reader.Get<bool>("GN1");

            history.GN11 = reader.Get<string>("GN11");
            history.GN24_Deprecated = reader.Get<string>("GN24_Deprecated");
            history.GN6_Deprecated = reader.Get<string>("GN6_Deprecated");
            history.GN27 = reader.Get<string>("GN27");
            history.GN75_Deprecated = reader.Get<string>("GN75_Deprecated");

            history.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            history.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            history.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            history.RescuePlan = reader.Get<bool>("RescuePlan");
            history.VehicleEntry = reader.Get<bool>("VehicleEntry");
            history.SpecialWork = reader.Get<bool>("SpecialWork");

            history.HazardsAndOrRequirements = reader.Get<String>("HazardsAndOrRequirements");
            history.OtherAreasAndOrUnitsAffectedArea = reader.Get<String>("OtherAreasAndOrUnitsAffectedArea");
            history.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<String>("OtherAreasAndOrUnitsAffectedPersonNotified");
            history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<Boolean>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            history.FaceShield = reader.Get<Boolean>("FaceShield");
            history.Goggles = reader.Get<Boolean>("Goggles");
            history.RubberBoots = reader.Get<Boolean>("RubberBoots");
            history.RubberGloves = reader.Get<Boolean>("RubberGloves");
            history.RubberSuit = reader.Get<Boolean>("RubberSuit");
            history.SafetyHarnessLifeline = reader.Get<Boolean>("SafetyHarnessLifeline");
            history.HighVoltagePPE = reader.Get<Boolean>("HighVoltagePPE");
            history.Other1 = reader.Get<string>("Other1");
            history.EquipmentGrounded = reader.Get<Boolean>("EquipmentGrounded");
            history.FireBlanket = reader.Get<Boolean>("FireBlanket");
            history.FireExtinguisher = reader.Get<Boolean>("FireExtinguisher");
            history.FireMonitorManned = reader.Get<Boolean>("FireMonitorManned");
            history.FireWatch = reader.Get<Boolean>("FireWatch");
            history.SewersDrainsCovered = reader.Get<Boolean>("SewersDrainsCovered");
            history.SteamHose = reader.Get<Boolean>("SteamHose");
            history.Other2 = reader.Get<string>("Other2");
            history.AirPurifyingRespirator = reader.Get<Boolean>("AirPurifyingRespirator");
            history.BreathingAirApparatus = reader.Get<Boolean>("BreathingAirApparatus");
            history.DustMask = reader.Get<Boolean>("DustMask");
            history.LifeSupportSystem = reader.Get<Boolean>("LifeSupportSystem");
            history.SafetyWatch = reader.Get<Boolean>("SafetyWatch");
            history.ContinuousGasMonitor = reader.Get<Boolean>("ContinuousGasMonitor");
            history.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            history.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            history.BumpTestMonitorPriorToUse = reader.Get<Boolean>("BumpTestMonitorPriorToUse");
            history.Other3 = reader.Get<string>("Other3");
            history.AirMover = reader.Get<Boolean>("AirMover");
            history.BarriersSigns = reader.Get<Boolean>("BarriersSigns");
            history.RadioChannel = reader.Get<bool>("RadioChannel");
            history.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            history.AirHorn = reader.Get<Boolean>("AirHorn");
            history.MechVentilationComfortOnly = reader.Get<Boolean>("MechVentilationComfortOnly");
            history.AsbestosMMCPrecautions = reader.Get<Boolean>("AsbestosMMCPrecautions");
            history.Other4 = reader.Get<string>("Other4");

            history.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            //mangesh - RoadAccess on Permit
            history.RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1");
            history.RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1");
            history.RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1");

            return history;
        }

        private static void AddInsertParameters(PermitRequestEdmontonHistory history, SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", history.IdValue);

            command.Parameters.AddWithValue("@PriorityId", history.Priority.IdValue);
            command.Parameters.AddWithValue("@IssuedToSuncor", history.IssuedToSuncor);
            command.Parameters.AddWithValue("@Occupation", history.Occupation);
            command.Parameters.AddWithValue("@NumberOfWorkers", history.NumberOfWorkers);
            command.Parameters.AddWithValue("@Group", history.Group);
            command.Parameters.AddWithValue("@WorkPermitTypeId", history.WorkPermitType.IdValue);            
            command.Parameters.AddWithValue("@FunctionalLocation", history.FunctionalLocation);
            command.Parameters.AddWithValue("@Location", history.Location);
            command.Parameters.AddWithValue("@Description", history.Description);
            command.Parameters.AddWithValue("@SAPDescription", history.SapDescription);
            command.Parameters.AddWithValue("@WorkOrderNumber", history.WorkOrderNumber);
            command.Parameters.AddWithValue("@OperationNumber", history.OperationNumber);
            command.Parameters.AddWithValue("@SubOperationNumber", history.SubOperationNumber);
            command.Parameters.AddWithValue("@Company", history.Company);
            command.Parameters.AddWithValue("@DocumentLinks", history.DocumentLinks);
            command.Parameters.AddWithValue("@AreaLabel", history.AreaLabel);

            command.Parameters.AddWithValue("@EndDate", history.EndDate.ToDateTimeAtStartOfDay());
            command.Parameters.AddWithValue("@RequestedStartDate", history.RequestedStartDate.ToDateTimeAtStartOfDay());

            DateTime? startTimeDay = history.RequestedStartTimeDay != null
                                      ? (DateTime?)history.RequestedStartTimeDay.ToDateTime()
                                      : null;

            DateTime? startTimeNight = history.RequestedStartTimeNight != null
                                      ? (DateTime?)history.RequestedStartTimeNight.ToDateTime()
                                      : null;

            command.Parameters.AddWithValue("@RequestedStartTimeDay", startTimeDay);
            command.Parameters.AddWithValue("@RequestedStartTimeNight", startTimeNight);

            command.Parameters.AddWithValue("@AlkylationEntryClassOfClothing", history.AlkylationEntryClassOfClothing);
            command.Parameters.AddWithValue("@FlarePitEntryType", history.FlarePitEntryType);
            command.Parameters.AddWithValue("@ConfinedSpaceCardNumber", history.ConfinedSpaceCardNumber);
            command.Parameters.AddWithValue("@ConfinedSpaceClass", history.ConfinedSpaceClass);
            command.Parameters.AddWithValue("@SpecialWorkFormNumber", history.SpecialWorkFormNumber);
            command.Parameters.AddWithValue("@SpecialWorkType", history.SpecialWorkType);
            command.Parameters.AddWithValue("@VehicleEntryTotal", history.VehicleEntryTotal);
            command.Parameters.AddWithValue("@VehicleEntryType", history.VehicleEntryType);
            command.Parameters.AddWithValue("@RescuePlanFormNumber", history.RescuePlanFormNumber);
            command.Parameters.AddWithValue("@FormGN59Id", history.FormGN59Id);
            command.Parameters.AddWithValue("@FormGN7Id", history.FormGN7Id);
            command.Parameters.AddWithValue("@FormGN6Id", history.FormGN6Id);
            command.Parameters.AddWithValue("@FormGN24Id", history.FormGN24Id);
            command.Parameters.AddWithValue("@FormGN75AId", history.FormGN75AId);
            command.Parameters.AddWithValue("@FormGN1TradeChecklistDisplayNumber", history.FormGN1TradeChecklistDisplayNumber);

            command.Parameters.AddWithValue("@GN59", history.GN59);
            command.Parameters.AddWithValue("@GN7", history.GN7);
            command.Parameters.AddWithValue("@GN24", history.GN24);
            command.Parameters.AddWithValue("@GN6", history.GN6);
            command.Parameters.AddWithValue("@GN75A", history.GN75A);
            command.Parameters.AddWithValue("@GN1", history.GN1);

            command.Parameters.AddWithValue("@GN11", history.GN11);
            command.Parameters.AddWithValue("@GN6_Deprecated", history.GN6_Deprecated);
            command.Parameters.AddWithValue("@GN24_Deprecated", history.GN24_Deprecated);
            command.Parameters.AddWithValue("@GN27", history.GN27);
            command.Parameters.AddWithValue("@GN75_Deprecated", history.GN75_Deprecated);

            command.Parameters.AddWithValue("@AlkylationEntry", history.AlkylationEntry);
            command.Parameters.AddWithValue("@FlarePitEntry", history.FlarePitEntry);
            command.Parameters.AddWithValue("@ConfinedSpace", history.ConfinedSpace);
            command.Parameters.AddWithValue("@RescuePlan", history.RescuePlan);
            command.Parameters.AddWithValue("@VehicleEntry", history.VehicleEntry);
            command.Parameters.AddWithValue("@SpecialWork", history.SpecialWork);

            command.Parameters.AddWithValue("@HazardsAndOrRequirements", history.HazardsAndOrRequirements);

            command.Parameters.AddWithValue("@OtherAreasAndOrUnitsAffectedArea", history.OtherAreasAndOrUnitsAffectedArea);
            command.Parameters.AddWithValue("@OtherAreasAndOrUnitsAffectedPersonNotified", history.OtherAreasAndOrUnitsAffectedPersonNotified);

            command.Parameters.AddWithValue("@WorkersMinimumSafetyRequirementsSectionNotApplicableToJob", history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob);
            command.Parameters.AddWithValue("@FaceShield", history.FaceShield);
            command.Parameters.AddWithValue("@Goggles", history.Goggles);
            command.Parameters.AddWithValue("@RubberBoots", history.RubberBoots);
            command.Parameters.AddWithValue("@RubberGloves", history.RubberGloves);
            command.Parameters.AddWithValue("@RubberSuit", history.RubberSuit);
            command.Parameters.AddWithValue("@SafetyHarnessLifeline", history.SafetyHarnessLifeline);
            command.Parameters.AddWithValue("@HighVoltagePPE", history.HighVoltagePPE);            
            command.Parameters.AddWithValue("@Other1", history.Other1);

            command.Parameters.AddWithValue("@EquipmentGrounded", history.EquipmentGrounded);
            command.Parameters.AddWithValue("@FireBlanket", history.FireBlanket);
            command.Parameters.AddWithValue("@FireExtinguisher", history.FireExtinguisher);
            command.Parameters.AddWithValue("@FireMonitorManned", history.FireMonitorManned);
            command.Parameters.AddWithValue("@FireWatch", history.FireWatch);
            command.Parameters.AddWithValue("@SewersDrainsCovered", history.SewersDrainsCovered);
            command.Parameters.AddWithValue("@SteamHose", history.SteamHose);            
            command.Parameters.AddWithValue("@Other2", history.Other2);

            command.Parameters.AddWithValue("@AirPurifyingRespirator", history.AirPurifyingRespirator);
            command.Parameters.AddWithValue("@BreathingAirApparatus", history.BreathingAirApparatus);
            command.Parameters.AddWithValue("@DustMask", history.DustMask);
            command.Parameters.AddWithValue("@LifeSupportSystem", history.LifeSupportSystem);
            command.Parameters.AddWithValue("@SafetyWatch", history.SafetyWatch);
            command.Parameters.AddWithValue("@ContinuousGasMonitor", history.ContinuousGasMonitor);
            command.Parameters.AddWithValue("@WorkersMonitor", history.WorkersMonitor);
            command.Parameters.AddWithValue("@WorkersMonitorNumber", history.WorkersMonitorNumber);
            command.Parameters.AddWithValue("@BumpTestMonitorPriorToUse", history.BumpTestMonitorPriorToUse);            
            command.Parameters.AddWithValue("@Other3", history.Other3);

            command.Parameters.AddWithValue("@AirMover", history.AirMover);
            command.Parameters.AddWithValue("@BarriersSigns", history.BarriersSigns);
            command.Parameters.AddWithValue("@RadioChannel", history.RadioChannel);
            command.Parameters.AddWithValue("@RadioChannelNumber", history.RadioChannelNumber);
            command.Parameters.AddWithValue("@AirHorn", history.AirHorn);
            command.Parameters.AddWithValue("@MechVentilationComfortOnly", history.MechVentilationComfortOnly);
            command.Parameters.AddWithValue("@AsbestosMMCPrecautions", history.AsbestosMMCPrecautions);            
            command.Parameters.AddWithValue("@Other4", history.Other4);            

            if (history.LastImportedByUser != null)
            {
                command.Parameters.AddWithValue("@LastImportedByUserId", history.LastImportedByUser.IdValue);
            }
            if (history.LastImportedDateTime.HasValue)
            {
                command.Parameters.AddWithValue("@LastImportedDateTime", history.LastImportedDateTime);
            }
            if (history.LastSubmittedByUser != null)
            {
                command.Parameters.AddWithValue("@LastSubmittedByUserId", history.LastSubmittedByUser.IdValue);
            }
            if (history.LastSubmittedDateTime.HasValue)
            {
                command.Parameters.AddWithValue("@LastSubmittedDateTime", history.LastSubmittedDateTime);
            }

            command.Parameters.AddWithValue("@LastModifiedByUserId", history.LastModifiedBy.Id);
            command.Parameters.AddWithValue("@LastModifiedDateTime", history.LastModifiedDate);

            command.Parameters.AddWithValue("@CompletionStatusId", history.CompletionStatus.IdValue);
            //mangesh for RoadAccessOnPermit and SpecialWork
            command.AddParameter("RoadAccessOnPermit", history.RoadAccessOnPermit);
            command.AddParameter("RoadAccessOnPermitFormNumber", history.RoadAccessOnPermitFormNumber);
            command.AddParameter("RoadAccessOnPermitType", history.RoadAccessOnPermitType);

            command.AddParameter("SpecialWorkName", history.SpecialWorkName);
        }

        private User GetUser(SqlDataReader reader, string userIdColumn)
        {
            User user = null;
            {
                long? userid = reader.Get<long?>(userIdColumn);
                if (userid.HasValue)
                {
                    user = userDao.QueryById(userid.Value);
                }
            }
            return user;
        }
    }
}
