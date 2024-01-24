using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitLubesFixture
    {
        public static WorkPermitLubes CreateForInsert(WorkPermitLubesGroup group)
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            User createdBy = UserFixture.CreateUserWithGivenId(1);
            DateTime now = new DateTime(2012, 2, 15, 9, 0, 0);

            WorkPermitLubes permit = new WorkPermitLubes(now, createdBy);

            SetSomeValues(permit, createdBy, now, group, floc);

            return permit;
        }

        public static void SetSomeValues(WorkPermitLubes permit, User createdBy, DateTime now, WorkPermitLubesGroup group, FunctionalLocation floc)
        {
            permit.LastModifiedBy = createdBy;
            permit.LastModifiedDateTime = now;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;
            permit.DataSource = DataSource.MANUAL;

            permit.IssuedToSuncor = true;
            permit.IssuedToCompany = true;
            permit.Company = "company";

            permit.PermitRequestSubmittedByUser = createdBy;

            permit.Trade = "trade";
            permit.NumberOfWorkers = 3;
            permit.RequestedByGroup = group;
            permit.WorkPermitType = WorkPermitLubesType.HOT_WORK;
            permit.IsVehicleEntry = true;
            permit.FunctionalLocation = floc;
            permit.Location = "location";

            permit.WorkOrderNumber = "33";
            permit.OperationNumber = "44";
            permit.SubOperationNumber = "55";

            permit.StartDateTime = now;
            permit.ExpireDateTime = now.AddHours(8);

            permit.ConfinedSpace = true;
            permit.ConfinedSpaceClass = "csc";
            permit.RescuePlan = true;
            permit.ConfinedSpaceSafetyWatchChecklist = true;
            permit.SpecialWork = true;
            permit.SpecialWorkType = "special";
            permit.HazardousWorkApproverAdvised = true;
            permit.AdditionalFollowupRequired = true;

            permit.HighEnergy = WorkPermitSafetyFormState.Approved;
            permit.CriticalLift = WorkPermitSafetyFormState.Approved;
            permit.Excavation = WorkPermitSafetyFormState.Approved;
            permit.EnergyControlPlanFormRequirement = WorkPermitSafetyFormState.Approved;
            permit.EquivalencyProc = WorkPermitSafetyFormState.Approved;
            permit.TestPneumatic = WorkPermitSafetyFormState.Approved;
            permit.LiveFlareWork = WorkPermitSafetyFormState.Approved;
            permit.EntryAndControlPlan = WorkPermitSafetyFormState.Approved;
            permit.EnergizedElectrical = WorkPermitSafetyFormState.Approved;

            permit.TaskDescription = "Desc";

            permit.HazardHydrocarbonGas = true;
            permit.HazardHydrocarbonLiquid = true;
            permit.HazardHydrogenSulphide = true;
            permit.HazardInertGasAtmosphere = true;
            permit.HazardOxygenDeficiency = true;
            permit.HazardRadioactiveSources = true;
            permit.HazardUndergroundOverheadHazards = true;
            permit.HazardDesignatedSubstance = true;

            permit.OtherHazardsAndOrRequirements = "other haz";

            permit.OtherAreasAndOrUnitsAffected = true;
            permit.OtherAreasAndOrUnitsAffectedArea = "area";
            permit.OtherAreasAndOrUnitsAffectedPersonNotified = "pnot";

            permit.ProductNormallyInPipingEquipment = "wat";

            permit.DepressuredDrained = YesNoNotApplicable.YES;
            permit.WaterWashed = YesNoNotApplicable.YES;
            permit.ChemicallyWashed = YesNoNotApplicable.YES;
            permit.Steamed = YesNoNotApplicable.YES;
            permit.Purged = YesNoNotApplicable.YES;
            permit.Disconnected = YesNoNotApplicable.YES;

            permit.DepressuredAndVented = YesNoNotApplicable.YES;
            permit.Ventilated = YesNoNotApplicable.YES;
            permit.Blanked = YesNoNotApplicable.YES;
            permit.DrainsCovered = YesNoNotApplicable.YES;
            permit.AreaBarricaded = YesNoNotApplicable.YES;

            permit.EnergySourcesLockedOutTaggedOut = YesNoNotApplicable.YES;
            permit.EnergyControlPlan = "ecp";
            permit.LockBoxNumber = "lbn";
            permit.OtherPreparations = "othprep";

            permit.SpecificRequirementsSectionNotApplicableToJob = true;

            permit.AttendedAtAllTimes = true;
            permit.EyeProtection = true;
            permit.FallProtectionEquipment = true;
            permit.FullBodyHarnessRetrieval = true;
            permit.HearingProtection = true;
            permit.ProtectiveClothing = true;
            permit.Other1Checked = true;
            permit.Other1Value = "oth1";

            permit.EquipmentBondedGrounded = true;
            permit.FireBlanket = true;
            permit.FireFightingEquipment = true;
            permit.FireWatch = true;
            permit.HydrantPermit = true;
            permit.WaterHose = true;
            permit.SteamHose = true;
            permit.Other2Checked = true;
            permit.Other2Value = "oth2";

            permit.AirMover = true;
            permit.ContinuousGasMonitor = true;
            permit.DrowningProtection = true;
            permit.RespiratoryProtection = true;
            permit.Other3Checked = true;
            permit.Other3Value = "oth3";

            permit.AdditionalLighting = true;
            permit.DesignateHotOrColdCutChecked = true;
            permit.DesignateHotOrColdCutValue = "desig";
            permit.HoistingEquipment = true;
            permit.Ladder = true;
            permit.MotorizedEquipment = true;
            permit.Scaffold = true;
            permit.ReferToTipsProcedure = true;

            permit.GasDetectorBumpTested = true;
            permit.AtmosphericGasTestRequired = true;

            permit.UsePreviousPermitAnswered = false;
        }

    }
}
