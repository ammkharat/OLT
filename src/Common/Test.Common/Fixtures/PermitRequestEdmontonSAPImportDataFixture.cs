using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitRequestEdmontonSAPImportDataFixture
    {
        public static PermitRequestEdmontonSAPImportData CreateForInsert(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            PermitRequestEdmontonSAPImportData item = CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateP4(), UserFixture.CreateSAPUser());
            item.ClearWorkOrderSources();
            item.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);
            return item;
        }

        public static PermitRequestEdmontonSAPImportData CreateForInsert(FunctionalLocation floc, WorkPermitEdmontonGroup group, User createdBy)
        {
            return CreateForInsert(1, floc, group, createdBy);
        }

        public static PermitRequestEdmontonSAPImportData CreateForInsert(long batchId, FunctionalLocation floc, WorkPermitEdmontonGroup group, User createdBy)
        {
            PermitRequestEdmonton pr = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, floc, @group);

            PermitRequestEdmontonSAPImportData importData =
                new PermitRequestEdmontonSAPImportData(
                    batchId,
                    Clock.Now,
                    pr.Id,
                    pr.EndDate, 
                    pr.Description, 
                    pr.Company,
                    createdBy, 
                    Clock.Now);

            importData.WorkOrderNumber = "12345";
            importData.OperationNumber = "567";
            importData.SubOperationNumber = "8910";

            importData.Priority = Priority.Normal;
            importData.WorkPermitType = pr.WorkPermitType;
            importData.FunctionalLocation = pr.FunctionalLocation;

            importData.RequestedStartDate = pr.RequestedStartDate;
            importData.RequestedStartTimeDay = pr.RequestedStartTimeDay;
            importData.RequestedStartTimeNight = pr.RequestedStartTimeNight;

            importData.IssuedToSuncor = pr.IssuedToSuncor;
            importData.Company = pr.Company;
            importData.Occupation = pr.Occupation;
            importData.SAPWorkCentre = pr.SAPWorkCentre;
            importData.NumberOfWorkers = pr.NumberOfWorkers;
            importData.Group = pr.Group;
            importData.Location = pr.Location;
            importData.AreaLabel = pr.AreaLabel;

            importData.AlkylationEntry = pr.AlkylationEntry;
            importData.FlarePitEntry = pr.FlarePitEntry;
            importData.ConfinedSpace = pr.ConfinedSpace;
            importData.SpecialWork = pr.SpecialWork;
            importData.VehicleEntry = pr.VehicleEntry;
            importData.RescuePlan = pr.RescuePlan;

            importData.ConfinedSpaceClass = pr.ConfinedSpaceClass;

            importData.GN59 = pr.GN59;
            importData.GN6 = true;
            importData.GN7 = true;
            importData.GN24 = pr.GN24;
            importData.GN75A = pr.GN75A;

            importData.GN11 = WorkPermitSafetyFormState.NotApplicable;
            importData.GN27 = WorkPermitSafetyFormState.Approved;            
            
            importData.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = true;
            importData.FaceShield = pr.FaceShield;
            importData.Goggles = pr.Goggles;
            importData.RubberBoots = pr.RubberBoots;
            importData.RubberGloves = pr.RubberGloves;
            importData.RubberSuit = pr.RubberSuit;
            importData.SafetyHarnessLifeline = pr.SafetyHarnessLifeline;
            importData.HighVoltagePPE = pr.HighVoltagePPE;
            
            importData.EquipmentGrounded = pr.EquipmentGrounded;
            importData.FireBlanket = pr.FireBlanket;
            importData.FireExtinguisher = pr.FireExtinguisher;
            importData.FireMonitorManned = pr.FireMonitorManned;
            importData.FireWatch = pr.FireWatch;
            importData.SewersDrainsCovered = pr.SewersDrainsCovered;
            importData.SteamHose = pr.SteamHose;
            
            importData.AirPurifyingRespirator = pr.AirPurifyingRespirator;
            importData.BreathingAirApparatus = pr.BreathingAirApparatus;
            importData.DustMask = pr.DustMask;
            importData.LifeSupportSystem = pr.LifeSupportSystem;
            importData.SafetyWatch = pr.SafetyWatch;
            importData.ContinuousGasMonitor = pr.ContinuousGasMonitor;
            
            importData.BumpTestMonitorPriorToUse = pr.BumpTestMonitorPriorToUse;
            
            importData.AirMover = pr.AirMover;
            importData.BarriersSigns = pr.BarriersSigns;
            
            importData.AirHorn = pr.AirHorn;
            importData.MechVentilationComfortOnly = pr.MechVentilationComfortOnly;
            importData.AsbestosMMCPrecautions = pr.AsbestosMMCPrecautions;
            
            importData.DoNotMerge = true;

            return importData;
        }
    }
}
