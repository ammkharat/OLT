using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PermitRequestFortHillsHistoryDao : AbstractManagedDao, IPermitRequestFortHillsHistoryDao
    {
        private const string QUERY_BY_ID = "QueryPermitRequestFortHillsHistoriesById";
        private const string INSERT = "InsertPermitRequestFortHillsHistory";

        private readonly IUserDao userDao;

        public PermitRequestFortHillsHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<PermitRequestFortHillsHistory> GetById(long id)
        {
            SqlCommand command = ManagedCommand;
            command.Parameters.AddWithValue("@Id", id);
            return command.QueryForListResult < PermitRequestFortHillsHistory>(PopulateInstance, QUERY_BY_ID);
        }

        public void Insert(PermitRequestFortHillsHistory history)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(history, AddInsertParameters, INSERT);
        }

        private PermitRequestFortHillsHistory PopulateInstance(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");
            User lastModifiedBy = GetUser(reader, "LastModifiedByUserId");
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            
            PermitRequestFortHillsHistory history = new PermitRequestFortHillsHistory(id, lastModifiedBy, lastModifiedDate)
            {
                WorkPermitType = WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId")),
                FunctionalLocation = reader.Get<string>("FunctionalLocation"),
                RequestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate")),
                RequestedStartTime = (reader.Get<Time>("RequestedStartTime")),
                EndDate = new Date(reader.Get<DateTime>("EndDate")),
                RequestedEndTime = (reader.Get<Time>("RequestedEndTime")),
               
                Priority = Priority.GetById(reader.Get<int>("PriorityId")),
               
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
            history.WorkPermitType = WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId"));
            history.Location = reader.Get<String>("Location");
            history.DocumentLinks = reader.Get<String>("DocumentLinks");
            //history.AlkylationEntryClassOfClothing = reader.Get<String>("AlkylationEntryClassOfClothing");
            //history.FlarePitEntryType = reader.Get<String>("FlarePitEntryType");
            //history.ConfinedSpaceCardNumber = reader.Get<String>("ConfinedSpaceCardNumber");
            history.ConfinedSpaceClass = reader.Get<String>("ConfinedSpaceClass");
            //history.RescuePlanFormNumber = reader.Get<String>("RescuePlanFormNumber");
            //history.VehicleEntryTotal = reader.Get<int?>("VehicleEntryTotal");
            //history.VehicleEntryType = reader.Get<String>("VehicleEntryType");
            //history.SpecialWorkFormNumber = reader.Get<String>("SpecialWorkFormNumber");
            //history.SpecialWorkType = reader.Get<String>("SpecialWorkType");
            //history.FormGN59Id = reader.Get<long?>("FormGN59Id");
            //history.FormGN7Id = reader.Get<long?>("FormGN7Id");
            //history.FormGN24Id = reader.Get<long?>("FormGN24Id");
            //history.FormGN6Id = reader.Get<long?>("FormGN6Id");
            //history.FormGN75AId = reader.Get<long?>("FormGN75AId");
            //history.FormGN1TradeChecklistDisplayNumber = reader.Get<string>("FormGN1TradeChecklistDisplayNumber");

            //history.GN59 = reader.Get<bool>("GN59");
            //history.GN7 = reader.Get<bool>("GN7");
            //history.GN24 = reader.Get<bool>("GN24");
            //history.GN6 = reader.Get<bool>("GN6");
            //history.GN75A = reader.Get<bool>("GN75A");
            //history.GN1 = reader.Get<bool>("GN1");

            //history.GN11 = reader.Get<string>("GN11");
            //history.GN24_Deprecated = reader.Get<string>("GN24_Deprecated");
            //history.GN6_Deprecated = reader.Get<string>("GN6_Deprecated");
            //history.GN27 = reader.Get<string>("GN27");
            //history.GN75_Deprecated = reader.Get<string>("GN75_Deprecated");
            history.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            history.VehicleEntry = reader.Get<bool>("VehicleEntry");

            //history.AlkylationEntry = reader.Get<bool>("AlkylationEntry");
            //history.FlarePitEntry = reader.Get<bool>("FlarePitEntry");
            //history.RescuePlan = reader.Get<bool>("RescuePlan");
            //history.SpecialWork = reader.Get<bool>("SpecialWork");

            history.HazardsAndOrRequirements = reader.Get<String>("HazardsAndOrRequirements");
            //history.OtherAreasAndOrUnitsAffectedArea = reader.Get<String>("OtherAreasAndOrUnitsAffectedArea");
            //history.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<String>("OtherAreasAndOrUnitsAffectedPersonNotified");
            //history.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = reader.Get<Boolean>("WorkersMinimumSafetyRequirementsSectionNotApplicableToJob");
            history.FaceShield = reader.Get<Boolean>("FaceShield");
            history.ChemicalSuit = reader.Get<Boolean>("ChemicalSuit");
            history.BottleWatch = reader.Get<Boolean>("BottleWatch");
            history.ConfinedSpaceMoniter = reader.Get<Boolean>("ConfinedSpaceMoniter");
            history.SuppliedBreathingAir = reader.Get<Boolean>("SuppliedBreathingAir");
            history.Other1 = reader.Get<string>("Other1");
            history.FireWatch = reader.Get<Boolean>("FireWatch");
            history.FireBlanket = reader.Get<Boolean>("FireBlanket");
            history.FireExtinguisher = reader.Get<Boolean>("FireExtinguisher");
            history.Other2 = reader.Get<string>("Other2");
            history.AirPurifyingRespirator = reader.Get<Boolean>("AirPurifyingRespirator");
             history.Other3 = reader.Get<string>("Other3");
            history.AirMover = reader.Get<Boolean>("AirMover");
             history.CompletionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            //mangesh - RoadAccess on Permit
            history.RoadAccessOnPermit = reader.Get<bool>("RoadAccessOnPermit1");
            history.RoadAccessOnPermitFormNumber = reader.Get<string>("RoadAccessOnPermitFormNumber1");
            history.RoadAccessOnPermitType = reader.Get<string>("RoadAccessOnPermitType1");
            history.OthersPartE = reader.Get<string>("OthersPartE");

            //history.HighVoltagePPE = reader.Get<Boolean>("HighVoltagePPE");
            //history.EquipmentGrounded = reader.Get<Boolean>("EquipmentGrounded");
            
            //history.FireMonitorManned = reader.Get<Boolean>("FireMonitorManned");
            //history.SewersDrainsCovered = reader.Get<Boolean>("SewersDrainsCovered");
            //history.SteamHose = reader.Get<Boolean>("SteamHose");
            
            //history.BreathingAirApparatus = reader.Get<Boolean>("BreathingAirApparatus");
            //history.DustMask = reader.Get<Boolean>("DustMask");
            //history.LifeSupportSystem = reader.Get<Boolean>("LifeSupportSystem");
            //history.SafetyWatch = reader.Get<Boolean>("SafetyWatch");
            //history.ContinuousGasMonitor = reader.Get<Boolean>("ContinuousGasMonitor");
            //history.WorkersMonitor = reader.Get<bool>("WorkersMonitor");
            //history.WorkersMonitorNumber = reader.Get<string>("WorkersMonitorNumber");
            //history.BumpTestMonitorPriorToUse = reader.Get<Boolean>("BumpTestMonitorPriorToUse");
           
            //history.BarriersSigns = reader.Get<Boolean>("BarriersSigns");
            //history.RadioChannel = reader.Get<bool>("RadioChannel");
            //history.RadioChannelNumber = reader.Get<string>("RadioChannelNumber");
            //history.AirHorn = reader.Get<Boolean>("AirHorn");
            //history.MechVentilationComfortOnly = reader.Get<Boolean>("MechVentilationComfortOnly");
            //history.AsbestosMMCPrecautions = reader.Get<Boolean>("AsbestosMMCPrecautions");
            

           

            return history;
        }

        private static void AddInsertParameters(PermitRequestFortHillsHistory history, SqlCommand command)
        {
            command.Parameters.AddWithValue("@Id", history.IdValue);
            command.AddParameter("@IssuedToSuncor", history.IssuedToSuncor);
            command.AddParameter("@IssuedToCompany", history.IssuedToContractor);
            command.AddParameter("@Company", history.Company);
            command.AddParameter("@Occupation", history.Occupation);
            command.AddParameter("@NumberOfWorkers", history.NumberOfWorkers != null ? (int?)history.NumberOfWorkers : null);
            command.AddParameter("@GroupId", history.Group);
            command.AddParameter("@WorkOrderNumber", history.WorkOrderNumber);
            command.AddParameter("@WorkPermitTypeId", history.WorkPermitType.IdValue);
            command.AddParameter("@PriorityId", history.Priority.IdValue);
            command.AddParameter("@FunctionalLocation", history.FunctionalLocation);
            command.AddParameter("@Location", history.Location);

            command.AddParameter("@RequestedStartDate", history.RequestedStartDate.CreateDateTime(history.RequestedStartTime));
            command.AddParameter("@RequestedEndDate", (history.EndDate != null && history.RequestedEndTime != null) ? (DateTime?)history.EndDate.ToDateTimeAtStartOfDay() : null);
            //command.AddParameter("@RevalidationDate", (history.RevalidationDate != null && history.RevalidationDate != DateTime.MinValue.ToDate()) ? (DateTime?)history.RevalidationDate.ToDateTimeAtStartOfDay() : null);
            //command.AddParameter("@ExtensionDate", (history.ExtensionDate != null && history.ExtensionDate != DateTime.MinValue.ToDate()) ? (DateTime?)history.ExtensionDate.ToDateTimeAtStartOfDay() : null);
            
            //command.AddParameter("@RequestedStartTime", history.RequestedStartTime != null ? (DateTime?)history.RequestedStartTime.ToDateTime() : null);
            //command.AddParameter("@RequestedEndTime", history.RequestedEndTime != null ? (DateTime?)history.RequestedEndTime.ToDateTime() : null);
            //command.AddParameter("@RevalidationTime", history.RevalidationTime != null ? (DateTime?)history.RevalidationTime.ToDateTime() : null);
            //command.AddParameter("@ExtensionTime", history.ExtensionTime != null ? (DateTime?)history.ExtensionTime.ToDateTime() : null);

            command.AddParameter("@EquipmentNo", history.EquipmentNo != null ? history.EquipmentNo : null);
            //command.AddParameter("@Craft",history.Craft != null ? history.Craft :null );
            //command.AddParameter("@CrewSize", history.CrewSize);
            command.AddParameter("@JobCoordinator", history.JobCoordinator);
            command.AddParameter("@CoOrdContactNumber", history.CoOrdContactNumber);
            //command.AddParameter("@EmergencyMeetingPoint", history.EmergencyMeetingPoint);
            //command.AddParameter("@EmergencyContactNumber", history.EmergencyContactNo);
           // command.AddParameter("@Locknumber", history.LockBoxNumber);
            command.AddParameter("@LockBoxnumberChecked", history.LockBoxnumberChecked);
           // command.AddParameter("@IsolationNumber", history.IsolationNo);

            command.AddParameter("@FlameResistantWorkWear", history.FlameResistantWorkWear);
            command.AddParameter("@ChemicalSuit", history.ChemicalSuit);
            command.AddParameter("@FireWatch", history.FireWatch);
            command.AddParameter("@FireBlanket", history.FireBlanket);
            command.AddParameter("@SuppliedBreathingAir", history.SuppliedBreathingAir);
            command.AddParameter("@AirMover", history.AirMover);
            command.AddParameter("@PersonalFlotationDevice", history.PersonalFlotationDevice);
            command.AddParameter("@HearingProtection", history.HearingProtection);
            command.AddParameter("@Other1", history.Other1);
            command.AddParameter("@MonoGoggles", history.MonoGoggles);
            command.AddParameter("@ConfinedSpaceMoniter", history.ConfinedSpaceMoniter);
            command.AddParameter("@FireExtinguisher", history.FireExtinguisher);
            command.AddParameter("@SparkContainment", history.SparkContainment);
            command.AddParameter("@BottleWatch", history.BottleWatch);
            command.AddParameter("@StandbyPerson", history.StandbyPerson);
            command.AddParameter("@WorkingAlone", history.WorkingAlone);
            command.AddParameter("@SafetyGloves", history.SafetyGloves);
            command.AddParameter("@Other2", history.Other2);

            command.AddParameter("@FaceShield", history.FaceShield);
            command.AddParameter("@FallProtection", history.FallProtection);
            command.AddParameter("@ChargedFireHouse", history.ChargedFireHouse);
            command.AddParameter("@CoveredSewer", history.CoveredSewer);
            command.AddParameter("@AirPurifyingRespirator", history.AirPurifyingRespirator);
            command.AddParameter("@SingalPerson", history.SingalPerson);
            
            command.AddParameter("@CommunicationDevice", history.CommunicationDevice);
            command.AddParameter("@ReflectiveStrips", history.ReflectiveStrips);
            command.AddParameter("@Other3", history.Other3);
            
            command.AddParameter("@HazardsAndOrRequirements", history.HazardsAndOrRequirements);
            command.AddParameter("@ConfinedSpace", history.ConfinedSpace);
            command.AddParameter("@ConfinedSpaceClass", history.ConfinedSpaceClass);
            command.AddParameter("@GoundDisturbance", history.GoundDisturbance);
            command.AddParameter("@FireProtectionAuthorization", history.FireProtectionAuthorization);
            command.AddParameter("@CriticalOrSeriousLifts", history.CriticalOrSeriousLifts);
            command.AddParameter("@VehicleEntry", history.VehicleEntry);
            command.AddParameter("@IndustrialRadiography", history.IndustrialRadiography);
            command.AddParameter("@ElectricalEncroachment", history.ElectricalEncroachment);
            command.AddParameter("@MSDS", history.MSDS);
            command.AddParameter("@OthersPartE", history.OthersPartE);

            command.AddParameter("@MechanicallyIsolated", history.MechanicallyIsolated);
            command.AddParameter("@BlindedOrBlanked", history.BlindedOrBlanked);
            command.AddParameter("@DoubleBlockedandBled", history.DoubleBlockedandBled);
            command.AddParameter("@DrainedAndDepressurised", history.DrainedAndDepressurised);
            command.AddParameter("@PurgedorNeutralised", history.PurgedorNeutralised);


            command.AddParameter("@ElectricallyIsolated", history.ElectricallyIsolated);
            command.AddParameter("@TestBumped", history.TestBumped);
            command.AddParameter("@NuclearSource", history.NuclearSource);
            command.AddParameter("@ReceiverStafingRequirements", history.ReceiverStafingRequirements);
            
            command.AddParameter("@CompletionStatusId", history.CompletionStatus.IdValue);           
            

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
