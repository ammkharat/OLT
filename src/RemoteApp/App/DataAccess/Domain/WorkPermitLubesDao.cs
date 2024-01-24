using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitLubesDao : AbstractManagedDao, IWorkPermitLubesDao
    {
        private const string InsertStoredProcedure = "InsertWorkPermitLubes";
        private const string UpdateStoredProcedure = "UpdateWorkPermitLubes";
        private const string RemoveStoredProcedure = "RemoveWorkPermitLubes";
        private const string DoesPermitRequestAssociationExistStoredProcedure = "QueryDoesPermitRequestLubesAssociationExist";

        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkPermitLubesGroupDao groupDao;
        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;

        public WorkPermitLubesDao()
        {
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            groupDao = DaoRegistry.GetDao<IWorkPermitLubesGroupDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        public WorkPermitLubes QueryById(long id)
        {
            SqlCommand command = ManagedCommand;
            return command.QueryById<WorkPermitLubes>(id, PopulateInstance, "QueryWorkPermitLubesById");
        }

        public WorkPermitLubes Insert(WorkPermitLubes workPermit, long? permitRequestId)
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
            InsertNewDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            return workPermit;
        }

        private void AddInsertParameters(WorkPermitLubes workPermit, SqlCommand command)
        {
            command.AddParameter("DataSourceId", workPermit.DataSource.IdValue);

            command.AddParameter("PermitRequestSubmittedByUserId", workPermit.PermitRequestSubmittedByUser != null ? workPermit.PermitRequestSubmittedByUser.Id : null);

            command.AddParameter("CreatedDateTime", workPermit.CreatedDateTime);
            command.AddParameter("Version", workPermit.Version.ToString());
            command.AddParameter("CreatedByUserId", workPermit.CreatedBy.IdValue);

            AddInsertOrUpdateParameters(workPermit, command);
        }

        private void AddInsertOrUpdateParameters(WorkPermitLubes workPermit, SqlCommand command)
        {
            command.AddParameter("ShouldCreatePermitNumber", workPermit.PermitNumber.HasNoValue() && workPermit.WorkPermitStatus != PermitRequestBasedWorkPermitStatus.Requested);

            command.AddParameter("WorkPermitStatus", workPermit.WorkPermitStatus.IdValue);

            command.AddParameter("IssuedToSuncor", workPermit.IssuedToSuncor);
            command.AddParameter("IssuedToCompany", workPermit.IssuedToCompany);
            command.AddParameter("Company", workPermit.Company);
            command.AddParameter("Trade", workPermit.Trade);
            command.AddParameter("NumberOfWorkers", workPermit.NumberOfWorkers);
            command.AddParameter("RequestedByGroupId", workPermit.RequestedByGroup == null ? null : workPermit.RequestedByGroup.Id);

            command.AddParameter("WorkPermitTypeId", workPermit.WorkPermitType.IdValue);
            command.AddParameter("IsVehicleEntry", workPermit.IsVehicleEntry);

            command.AddParameter("FunctionalLocationId", workPermit.FunctionalLocation.IdValue);
            command.AddParameter("Location", workPermit.Location);

            command.AddParameter("ConfinedSpace", workPermit.ConfinedSpace);
            command.AddParameter("ConfinedSpaceClass", workPermit.ConfinedSpaceClass);
            command.AddParameter("RescuePlan", workPermit.RescuePlan);
            command.AddParameter("ConfinedSpaceSafetyWatchChecklist", workPermit.ConfinedSpaceSafetyWatchChecklist);

            command.AddParameter("SpecialWork", workPermit.SpecialWork);
            command.AddParameter("SpecialWorkType", workPermit.SpecialWorkType);
            command.AddParameter("HazardousWorkApproverAdvised", workPermit.HazardousWorkApproverAdvised);
            command.AddParameter("AdditionalFollowupRequired", workPermit.AdditionalFollowupRequired);

            command.AddParameter("OtherAreasAndOrUnitsAffected", workPermit.OtherAreasAndOrUnitsAffected);
            command.AddParameter("OtherAreasAndOrUnitsAffectedArea", workPermit.OtherAreasAndOrUnitsAffectedArea);
            command.AddParameter("OtherAreasAndOrUnitsAffectedPersonNotified", workPermit.OtherAreasAndOrUnitsAffectedPersonNotified);

            command.AddParameter("LastModifiedByUserId", workPermit.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", workPermit.LastModifiedDateTime);

            command.AddParameter("HighEnergy", workPermit.HighEnergy.IdValue);
            command.AddParameter("CriticalLift", workPermit.CriticalLift.IdValue);
            command.AddParameter("Excavation", workPermit.Excavation.IdValue);
            command.AddParameter("EnergyControlPlanFormRequirement", workPermit.EnergyControlPlanFormRequirement.IdValue);
            command.AddParameter("EquivalencyProc", workPermit.EquivalencyProc.IdValue);
            command.AddParameter("TestPneumatic", workPermit.TestPneumatic.IdValue);
            command.AddParameter("LiveFlareWork", workPermit.LiveFlareWork.IdValue);
            command.AddParameter("EntryAndControlPlan", workPermit.EntryAndControlPlan.IdValue);
            command.AddParameter("EnergizedElectrical", workPermit.EnergizedElectrical.IdValue);

            command.AddParameter("HazardHydrocarbonGas", workPermit.HazardHydrocarbonGas);
            command.AddParameter("HazardHydrocarbonLiquid", workPermit.HazardHydrocarbonLiquid);
            command.AddParameter("HazardHydrogenSulphide", workPermit.HazardHydrogenSulphide);
            command.AddParameter("HazardInertGasAtmosphere", workPermit.HazardInertGasAtmosphere);
            command.AddParameter("HazardOxygenDeficiency", workPermit.HazardOxygenDeficiency);
            command.AddParameter("HazardRadioactiveSources", workPermit.HazardRadioactiveSources);
            command.AddParameter("HazardUndergroundOverheadHazards", workPermit.HazardUndergroundOverheadHazards);
            command.AddParameter("HazardDesignatedSubstance", workPermit.HazardDesignatedSubstance);

            command.AddParameter("StartDateTime", workPermit.StartDateTime);
            command.AddParameter("ExpireDateTime", workPermit.ExpireDateTime);
            command.AddParameter("WorkOrderNumber", workPermit.WorkOrderNumber);
            command.AddParameter("OperationNumber", workPermit.OperationNumber);
            command.AddParameter("SubOperationNumber", workPermit.SubOperationNumber);
            command.AddParameter("TaskDescription", workPermit.TaskDescription);
            command.AddParameter("OtherHazardsAndOrRequirements", workPermit.OtherHazardsAndOrRequirements);

            command.AddParameter("WorkPreparationsCompletedSectionNotApplicableToJob", workPermit.WorkPreparationsCompletedSectionNotApplicableToJob);
            command.AddParameter("ProductNormallyInPipingEquipment", workPermit.ProductNormallyInPipingEquipment);
            command.AddParameter("DepressuredDrained", YesNoNotApplicableToBoolean(workPermit.DepressuredDrained));
            command.AddParameter("WaterWashed", YesNoNotApplicableToBoolean(workPermit.WaterWashed));
            command.AddParameter("ChemicallyWashed", YesNoNotApplicableToBoolean(workPermit.ChemicallyWashed));
            command.AddParameter("Steamed", YesNoNotApplicableToBoolean(workPermit.Steamed));
            command.AddParameter("Purged", YesNoNotApplicableToBoolean(workPermit.Purged));
            command.AddParameter("Disconnected", YesNoNotApplicableToBoolean(workPermit.Disconnected));
            command.AddParameter("DepressuredAndVented", YesNoNotApplicableToBoolean(workPermit.DepressuredAndVented));
            command.AddParameter("Ventilated", YesNoNotApplicableToBoolean(workPermit.Ventilated));
            command.AddParameter("Blanked", YesNoNotApplicableToBoolean(workPermit.Blanked));
            command.AddParameter("DrainsCovered", YesNoNotApplicableToBoolean(workPermit.DrainsCovered));
            command.AddParameter("AreaBarricated", YesNoNotApplicableToBoolean(workPermit.AreaBarricaded));
            command.AddParameter("EnergySourcesLockedOutTaggedOut", YesNoNotApplicableToBoolean(workPermit.EnergySourcesLockedOutTaggedOut));
            command.AddParameter("EnergyControlPlan", workPermit.EnergyControlPlan);
            command.AddParameter("LockBoxNumber", workPermit.LockBoxNumber);
            command.AddParameter("OtherPreparations", workPermit.OtherPreparations);

            command.AddParameter("SpecificRequirementsSectionNotApplicableToJob", workPermit.SpecificRequirementsSectionNotApplicableToJob);
            command.AddParameter("AttendedAtAllTimes", workPermit.AttendedAtAllTimes);
            command.AddParameter("EyeProtection", workPermit.EyeProtection);
            command.AddParameter("FallProtectionEquipment", workPermit.FallProtectionEquipment);
            command.AddParameter("FullBodyHarnessRetrieval", workPermit.FullBodyHarnessRetrieval);
            command.AddParameter("HearingProtection", workPermit.HearingProtection);
            command.AddParameter("ProtectiveClothing", workPermit.ProtectiveClothing);
            command.AddParameter("Other1Checked", workPermit.Other1Checked);
            command.AddParameter("Other1Value", workPermit.Other1Value);

            command.AddParameter("EquipmentBondedGrounded", workPermit.EquipmentBondedGrounded);
            command.AddParameter("FireBlanket", workPermit.FireBlanket);
            command.AddParameter("FireFightingEquipment", workPermit.FireFightingEquipment);
            command.AddParameter("FireWatch", workPermit.FireWatch);
            command.AddParameter("HydrantPermit", workPermit.HydrantPermit);
            command.AddParameter("WaterHose", workPermit.WaterHose);
            command.AddParameter("SteamHose", workPermit.SteamHose);
            command.AddParameter("Other2Checked", workPermit.Other2Checked);
            command.AddParameter("Other2Value", workPermit.Other2Value);

            command.AddParameter("AirMover", workPermit.AirMover);
            command.AddParameter("ContinuousGasMonitor", workPermit.ContinuousGasMonitor);
            command.AddParameter("DrowningProtection", workPermit.DrowningProtection);
            command.AddParameter("RespiratoryProtection", workPermit.RespiratoryProtection);
            command.AddParameter("Other3Checked", workPermit.Other3Checked);
            command.AddParameter("Other3Value", workPermit.Other3Value);

            command.AddParameter("AdditionalLighting", workPermit.AdditionalLighting);
            command.AddParameter("DesignateHotOrColdCutChecked", workPermit.DesignateHotOrColdCutChecked);
            command.AddParameter("DesignateHotOrColdCutValue", workPermit.DesignateHotOrColdCutValue);
            command.AddParameter("HoistingEquipment", workPermit.HoistingEquipment);
            command.AddParameter("Ladder", workPermit.Ladder);
            command.AddParameter("MotorizedEquipment", workPermit.MotorizedEquipment);
            command.AddParameter("Scaffold", workPermit.Scaffold);
            command.AddParameter("ReferToTipsProcedure", workPermit.ReferToTipsProcedure);

            command.AddParameter("GasDetectorBumpTested", workPermit.GasDetectorBumpTested);
            command.AddParameter("AtmosphericGasTestRequired", workPermit.AtmosphericGasTestRequired);

            command.AddParameter("UsePreviousPermitAnswered", workPermit.UsePreviousPermitAnswered);
        }

        private static void SetPermitNumber(WorkPermitLubes workPermit, SqlParameter permitNumberParameter)
        {
            if (permitNumberParameter.Value == DBNull.Value)
            {
                workPermit.PermitNumber = null;
            }
            else
            {
                workPermit.PermitNumber = permitNumberParameter.GetValue<long>();
            }
        }

        public void Update(WorkPermitLubes workPermit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("Id", workPermit.Id);
            SqlParameter permitNumberParameter = command.AddOutputParameter("@PermitNumber", SqlDbType.BigInt);

            command.Update(workPermit, AddUpdateParameters, UpdateStoredProcedure);
            
            SetPermitNumber(workPermit, permitNumberParameter);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(workPermit);
            InsertNewDocumentLinks(workPermit);
            RemoveDeletedDocumentLinks(workPermit);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

        }


        private void AddUpdateParameters(WorkPermitLubes workPermit, SqlCommand command)
        {
            command.AddParameter("IssuedDateTime", workPermit.IssuedDateTime);
            command.AddParameter("IssuedByUserId", workPermit.IssuedBy == null ? null : workPermit.IssuedBy.Id);
            AddInsertOrUpdateParameters(workPermit, command);
        }

        public void Remove(WorkPermitLubes workPermit)
        {
            ManagedCommand.Remove(workPermit, RemoveStoredProcedure);
        }

        public bool DoesPermitRequestLubesAssociationExist(List<long> permitRequests, Range<DateTime> rangeOfExistingPermits)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitStartDateTime", rangeOfExistingPermits.LowerBound);
            command.AddParameter("@WorkPermitEndDateTime", rangeOfExistingPermits.UpperBound);

            string permitRequestIds = permitRequests.ToCommaSeparatedString();
            command.AddParameter("@PermitRequestIds", permitRequestIds);

            int count = command.GetCount(DoesPermitRequestAssociationExistStoredProcedure);

            return count > 0;
        }

        public WorkPermitLubes QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitLubes permit)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@Id", permit.IdValue);
            return command.QueryForSingleResult<WorkPermitLubes>(PopulateInstance, "QueryWorkPermitLubesForReuse");
        }

        private WorkPermitLubes PopulateInstance(SqlDataReader reader)
        {
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            User createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            
            WorkPermitLubes permit = new WorkPermitLubes(createdDateTime, createdBy);

            permit.Id = reader.Get<long>("Id");
            permit.DataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Get(reader.Get<int>("WorkPermitStatus"));
            permit.IssuedDateTime = reader.Get<DateTime?>("IssuedDateTime");            
            permit.PermitNumber = reader.Get<long?>("PermitNumber");
            permit.Version = new Version(reader.Get<string>("Version"));
            long? issuedByUserId = reader.Get<long?>("IssuedByUserId");
            if (issuedByUserId != null)
            {
                permit.IssuedBy = userDao.QueryById(issuedByUserId.Value);
            }

            long? permitRequestSubmittedByUserId = reader.Get<long?>("PermitRequestSubmittedByUserId");
            if (permitRequestSubmittedByUserId != null)
            {
                permit.PermitRequestSubmittedByUser = userDao.QueryById(permitRequestSubmittedByUserId.Value);
            }

            long? permitRequestCreatedByUserId = reader.Get<long?>("PermitRequestCreatedByUserId");
            if (permitRequestCreatedByUserId != null)
            {
                permit.PermitRequestCreatedByUser = userDao.QueryById(permitRequestCreatedByUserId.Value);
            }

            int? permitRequestDataSourceId = reader.Get<int?>("PermitRequestDataSourceId");
            if (permitRequestDataSourceId != null)
            {
                permit.PermitRequestDataSource = DataSource.GetById(permitRequestDataSourceId.Value);
            }

            permit.IssuedToSuncor = reader.Get<bool>("IssuedToSuncor");
            permit.IssuedToCompany = reader.Get<bool>("IssuedToCompany");
            permit.Company = reader.Get<string>("Company");
            permit.Trade = reader.Get<string>("Trade");
            permit.NumberOfWorkers = reader.Get<int?>("NumberOfWorkers");
            permit.RequestedByGroup = groupDao.QueryById(reader.Get<long>("RequestedByGroupId"));

            permit.WorkPermitType = WorkPermitLubesType.Get(reader.Get<int>("WorkPermitTypeId"));
            permit.IsVehicleEntry = reader.Get<bool>("IsVehicleEntry");

            permit.FunctionalLocation = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));
            permit.Location = reader.Get<string>("Location");

            permit.DocumentLinks = documentLinkDao.QueryByWorkPermitLubesId(permit.IdValue);

            permit.ConfinedSpace = reader.Get<bool>("ConfinedSpace");
            permit.ConfinedSpaceClass = reader.Get<string>("ConfinedSpaceClass");
            permit.RescuePlan = reader.Get<bool>("RescuePlan");
            permit.ConfinedSpaceSafetyWatchChecklist = reader.Get<bool>("ConfinedSpaceSafetyWatchChecklist");

            permit.SpecialWork = reader.Get<bool>("SpecialWork");
            permit.SpecialWorkType = reader.Get<string>("SpecialWorkType");
            permit.HazardousWorkApproverAdvised = reader.Get<bool>("HazardousWorkApproverAdvised");
            permit.AdditionalFollowupRequired = reader.Get<bool>("AdditionalFollowupRequired");

            permit.StartDateTime = reader.Get<DateTime>("StartDateTime");
            permit.ExpireDateTime = reader.Get<DateTime>("ExpireDateTime");

            permit.WorkOrderNumber = reader.Get<string>("WorkOrderNumber");
            permit.OperationNumber = reader.Get<string>("OperationNumber");
            permit.SubOperationNumber = reader.Get<string>("SubOperationNumber");

            permit.HighEnergy = WorkPermitSafetyFormState.GetById(reader.Get<byte>("HighEnergy"));
            permit.CriticalLift = WorkPermitSafetyFormState.GetById(reader.Get<byte>("CriticalLift"));
            permit.Excavation = WorkPermitSafetyFormState.GetById(reader.Get<byte>("Excavation"));
            permit.EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergyControlPlanFormRequirement"));
            permit.EquivalencyProc = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EquivalencyProc"));
            permit.TestPneumatic = WorkPermitSafetyFormState.GetById(reader.Get<byte>("TestPneumatic"));
            permit.LiveFlareWork = WorkPermitSafetyFormState.GetById(reader.Get<byte>("LiveFlareWork"));
            permit.EntryAndControlPlan = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EntryAndControlPlan"));
            permit.EnergizedElectrical = WorkPermitSafetyFormState.GetById(reader.Get<byte>("EnergizedElectrical"));

            permit.TaskDescription = reader.Get<string>("TaskDescription");

            permit.HazardHydrocarbonGas = reader.Get<bool>("HazardHydrocarbonGas");
            permit.HazardHydrocarbonLiquid = reader.Get<bool>("HazardHydrocarbonLiquid");
            permit.HazardHydrogenSulphide = reader.Get<bool>("HazardHydrogenSulphide");
            permit.HazardInertGasAtmosphere = reader.Get<bool>("HazardInertGasAtmosphere");
            permit.HazardOxygenDeficiency = reader.Get<bool>("HazardOxygenDeficiency");
            permit.HazardRadioactiveSources = reader.Get<bool>("HazardRadioactiveSources");
            permit.HazardUndergroundOverheadHazards = reader.Get<bool>("HazardUndergroundOverheadHazards");
            permit.HazardDesignatedSubstance = reader.Get<bool>("HazardDesignatedSubstance");
            
            permit.OtherHazardsAndOrRequirements = reader.Get<string>("OtherHazardsAndOrRequirements");

            permit.OtherAreasAndOrUnitsAffected = reader.Get<bool>("OtherAreasAndOrUnitsAffected");
            permit.OtherAreasAndOrUnitsAffectedArea = reader.Get<string>("OtherAreasAndOrUnitsAffectedArea");
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = reader.Get<string>("OtherAreasAndOrUnitsAffectedPersonNotified");
            
            permit.WorkPreparationsCompletedSectionNotApplicableToJob = reader.Get<bool>("WorkPreparationsCompletedSectionNotApplicableToJob");
            permit.ProductNormallyInPipingEquipment = reader.Get<string>("ProductNormallyInPipingEquipment");
            permit.DepressuredDrained = YesNoNotApplicable.FindForValue(reader.Get<bool?>("DepressuredDrained"));
            permit.WaterWashed = YesNoNotApplicable.FindForValue(reader.Get<bool?>("WaterWashed"));
            permit.ChemicallyWashed = YesNoNotApplicable.FindForValue(reader.Get<bool?>("ChemicallyWashed"));
            permit.Steamed = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Steamed"));
            permit.Purged = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Purged"));
            permit.Disconnected = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Disconnected"));
            permit.DepressuredAndVented = YesNoNotApplicable.FindForValue(reader.Get<bool?>("DepressuredAndVented"));
            permit.Ventilated = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Ventilated"));
            permit.Blanked = YesNoNotApplicable.FindForValue(reader.Get<bool?>("Blanked"));
            permit.DrainsCovered = YesNoNotApplicable.FindForValue(reader.Get<bool?>("DrainsCovered"));
            permit.AreaBarricaded = YesNoNotApplicable.FindForValue(reader.Get<bool?>("AreaBarricated"));
            permit.EnergySourcesLockedOutTaggedOut = YesNoNotApplicable.FindForValue(reader.Get<bool?>("EnergySourcesLockedOutTaggedOut"));
            permit.EnergyControlPlan = reader.Get<string>("EnergyControlPlan");
            permit.LockBoxNumber = reader.Get<string>("LockBoxNumber");
            permit.OtherPreparations = reader.Get<string>("OtherPreparations");

            permit.SpecificRequirementsSectionNotApplicableToJob = reader.Get<bool>("SpecificRequirementsSectionNotApplicableToJob");
            permit.AttendedAtAllTimes = reader.Get<bool>("AttendedAtAllTimes");
            permit.EyeProtection = reader.Get<bool>("EyeProtection");
            permit.FallProtectionEquipment = reader.Get<bool>("FallProtectionEquipment");
            permit.FullBodyHarnessRetrieval = reader.Get<bool>("FullBodyHarnessRetrieval");
            permit.HearingProtection = reader.Get<bool>("HearingProtection");
            permit.ProtectiveClothing = reader.Get<bool>("ProtectiveClothing");
            permit.Other1Checked = reader.Get<bool>("Other1Checked");
            permit.Other1Value = reader.Get<string>("Other1Value");

            permit.EquipmentBondedGrounded = reader.Get<bool>("EquipmentBondedGrounded");
            permit.FireBlanket = reader.Get<bool>("FireBlanket");
            permit.FireFightingEquipment = reader.Get<bool>("FireFightingEquipment");
            permit.FireWatch = reader.Get<bool>("FireWatch");
            permit.HydrantPermit = reader.Get<bool>("HydrantPermit");
            permit.WaterHose = reader.Get<bool>("WaterHose");
            permit.SteamHose = reader.Get<bool>("SteamHose");
            permit.Other2Checked = reader.Get<bool>("Other2Checked");
            permit.Other2Value = reader.Get<string>("Other2Value");

            permit.AirMover = reader.Get<bool>("AirMover");
            permit.ContinuousGasMonitor = reader.Get<bool>("ContinuousGasMonitor");
            permit.DrowningProtection = reader.Get<bool>("DrowningProtection");
            permit.RespiratoryProtection = reader.Get<bool>("RespiratoryProtection");
            permit.Other3Checked = reader.Get<bool>("Other3Checked");
            permit.Other3Value = reader.Get<string>("Other3Value");

            permit.AdditionalLighting = reader.Get<bool>("AdditionalLighting");
            permit.FireBlanket = reader.Get<bool>("FireBlanket");
            permit.DesignateHotOrColdCutChecked = reader.Get<bool>("DesignateHotOrColdCutChecked");
            permit.DesignateHotOrColdCutValue = reader.Get<string>("DesignateHotOrColdCutValue");
            permit.HoistingEquipment = reader.Get<bool>("HoistingEquipment");
            permit.Ladder = reader.Get<bool>("Ladder");
            permit.MotorizedEquipment = reader.Get<bool>("MotorizedEquipment");
            permit.Scaffold = reader.Get<bool>("Scaffold");
            permit.ReferToTipsProcedure = reader.Get<bool>("ReferToTipsProcedure");

            permit.GasDetectorBumpTested = reader.Get<bool>("GasDetectorBumpTested");
            permit.AtmosphericGasTestRequired = reader.Get<bool>("AtmosphericGasTestRequired");
            permit.UsePreviousPermitAnswered = reader.Get<bool>("UsePreviousPermitAnswered");

            permit.LastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            permit.LastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            
            return permit;
        }

        private bool? YesNoNotApplicableToBoolean(YesNoNotApplicable value)
        {
            if (value == null)
            {
                return null;
            }

            return value.BoolValue;
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedWorkPermitLubes);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByWorkPermitLubesId);
        }
    }
}
