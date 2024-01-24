using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitRequestLubesFixture
    {
        public static PermitRequestLubes Create(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            return Create(null, workOrderNumber, operationNumber, subOperationNumber);
        }
        
        public static PermitRequestLubes Create(long? id, string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            PermitRequestLubes prl = CreateForInsert(new WorkPermitLubesGroup(1, "Some Fake Group", 0));

            prl.ClearWorkOrderSources();
            prl.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);

            prl.Id = id;

            return prl;
        }

        public static PermitRequestLubes CreateForInsert(WorkPermitLubesGroup group)
        {
            return CreateForInsert(group, DataSource.MANUAL);
        }

        public static PermitRequestLubes CreateForInsert(WorkPermitLubesGroup group, DataSource dataSource)
        {
            return CreateForInsert(group, dataSource, new DateTime(2012, 2, 15, 9, 0, 0), new Date(2012, 2, 16));
        }

        public static PermitRequestLubes CreateForInsert(WorkPermitLubesGroup group, DataSource dataSource, DateTime now, Date tomorrow)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            User createdBy = UserFixture.CreateUserWithGivenId(1);
            Role createdByRole = RoleFixture.GetRealRoleA(10);

            PermitRequestLubes permitRequest = new PermitRequestLubes(null, tomorrow, "Description", "SAP Description", "Company", dataSource, createdBy, now, createdBy, now, createdBy, now, createdBy, now, createdByRole);

            permitRequest.AddWorkOrderSource("12345", "1111", "2222");

            SetSomeValues(permitRequest, createdBy, now, group, floc);

            return permitRequest;            
        }

        private static void SetSomeValues(PermitRequestLubes permitRequest, User createdBy, DateTime now, WorkPermitLubesGroup group, FunctionalLocation floc)
        {
            permitRequest.CompletionStatus = PermitRequestCompletionStatus.Complete;
            permitRequest.IssuedToSuncor = true;
            permitRequest.IssuedToCompany = true;
            permitRequest.Trade = "Trade";
            permitRequest.SAPWorkCentre = "ABC123";
            permitRequest.NumberOfWorkers = 42;
            permitRequest.RequestedByGroup = group;
            permitRequest.WorkPermitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
            permitRequest.FunctionalLocation = floc;
            permitRequest.Location = "Location";
            permitRequest.ConfinedSpace = true;
            permitRequest.ConfinedSpaceClass = "CS class";
            permitRequest.RescuePlan = true;
            permitRequest.ConfinedSpaceSafetyWatchChecklist = true;
            permitRequest.SpecialWork = true;
            permitRequest.SpecialWorkType = "SW Type";
            permitRequest.RequestedStartDate = new Date(now);
            permitRequest.RequestedStartTimeDay = new Time(now);
            permitRequest.RequestedStartTimeNight = new Time(now);           
            permitRequest.HighEnergy = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.CriticalLift = WorkPermitSafetyFormState.Required;
            permitRequest.Excavation = WorkPermitSafetyFormState.Approved;
            permitRequest.EnergyControlPlan = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.EquivalencyProc = WorkPermitSafetyFormState.Approved;
            permitRequest.TestPneumatic = WorkPermitSafetyFormState.Approved;
            permitRequest.LiveFlareWork = WorkPermitSafetyFormState.NotApplicable;
            permitRequest.EntryAndControlPlan = WorkPermitSafetyFormState.Approved;
            permitRequest.EnergizedElectrical = WorkPermitSafetyFormState.Approved;
            permitRequest.HazardHydrocarbonGas = true;
            permitRequest.HazardHydrocarbonLiquid = true;
            permitRequest.HazardHydrogenSulphide = true;
            permitRequest.HazardInertGasAtmosphere = true;
            permitRequest.HazardOxygenDeficiency = true;
            permitRequest.HazardRadioactiveSources = true;
            permitRequest.HazardUndergroundOverheadHazards = true;
            permitRequest.HazardDesignatedSubstance = true;
            permitRequest.OtherHazardsAndOrRequirements = "Other hazards";
            permitRequest.OtherAreasAndOrUnitsAffected = true;
            permitRequest.OtherAreasAndOrUnitsAffectedArea = "affected area";
            permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified = "person notified";
            permitRequest.SpecificRequirementsSectionNotApplicableToJob = true;
            permitRequest.AttendedAtAllTimes = true;
            permitRequest.EyeProtection = true;
            permitRequest.FallProtectionEquipment = true;
            permitRequest.FullBodyHarnessRetrieval = true;
            permitRequest.HearingProtection = true;
            permitRequest.ProtectiveClothing = true;
            permitRequest.Other1Checked = true;
            permitRequest.Other1Value = "other 1 val";
            permitRequest.EquipmentBondedGrounded = true;
            permitRequest.FireBlanket = true;
            permitRequest.FireFightingEquipment = true;
            permitRequest.FireWatch = true;
            permitRequest.HydrantPermit = true;
            permitRequest.WaterHose = true;
            permitRequest.SteamHose = true;
            permitRequest.Other2Checked = true;
            permitRequest.Other2Value = "Other 2 val";
            permitRequest.AirMover = true;
            permitRequest.ContinuousGasMonitor = true;
            permitRequest.DrowningProtection = true;
            permitRequest.RespiratoryProtection = true;
            permitRequest.Other3Checked = true;
            permitRequest.Other3Value = "other 3 val";
            permitRequest.AdditionalLighting = true;
            permitRequest.DesignateHotOrColdCutChecked = true;
            permitRequest.DesignateHotOrColdCutValue = "dhocc";
            permitRequest.HoistingEquipment = true;
            permitRequest.Ladder = true;
            permitRequest.MotorizedEquipment = true;
            permitRequest.Scaffold = true;
            permitRequest.ReferToTipsProcedure = true;
            permitRequest.GasDetectorBumpTested = true;            
        }

        public static PermitRequestLubes CreateEmptyPermitRequest()
        {
            return new PermitRequestLubes(null, null, null, null, null, null, null, null, null, null, null, DateTime.MinValue, null, DateTime.MinValue, null);
        }
    }
}
