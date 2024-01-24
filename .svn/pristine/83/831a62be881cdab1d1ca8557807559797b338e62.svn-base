using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class PermitRequestEdmontonRawImportDataFixture
    {
        public static PermitRequestEdmontonRawImportData CreateForInsert(FunctionalLocation floc, WorkPermitEdmontonGroup group)
        {
            PermitRequestEdmonton pr = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, floc, @group);

            PermitRequestEdmontonRawImportData importData = 
                new PermitRequestEdmontonRawImportData(
                    pr.Id,
                    pr.EndDate, 
                    pr.Description, 
                    pr.Company,
                    DataSource.SAP,
                    pr.LastImportedByUser,
                    pr.LastImportedDateTime,
                    pr.LastSubmittedByUser,
                    pr.LastSubmittedDateTime,
                    pr.CreatedBy,
                    pr.CreatedDateTime,
                    pr.LastModifiedBy,
                    pr.LastModifiedDateTime);

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

            // importData.AlkylationEntryClassOfClothing = "Class of Clothing";
            // importData.FlarePitEntryType = "A";
            // importData.ConfinedSpaceCardNumber = "CardNum";
            //importData.ConfinedSpaceClass = "Class";
            //importData.SpecialWorkFormNumber = "SWFN";
            //importData.SpecialWorkType = pr.SpecialWorkType;
            // importData.VehicleEntryTotal = 43;
            // importData.VehicleEntryType = "VET";
            // importData.RescuePlanFormNumber = "RPFN";

            importData.AlkylationEntry = pr.AlkylationEntry;
            importData.FlarePitEntry = pr.FlarePitEntry;
            importData.ConfinedSpace = pr.ConfinedSpace;
            importData.SpecialWork = pr.SpecialWork;
            importData.VehicleEntry = pr.VehicleEntry;
            importData.RescuePlan = pr.RescuePlan;

            //importData.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            //importData.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            importData.GN59 = pr.GN59;
            importData.GN7 = true;
            importData.GN6 = WorkPermitSafetyFormState.Approved;
            importData.GN11 = WorkPermitSafetyFormState.NotApplicable;
            importData.GN24 = WorkPermitSafetyFormState.Required;
            importData.GN27 = WorkPermitSafetyFormState.Approved;
            importData.GN75 = WorkPermitSafetyFormState.NotApplicable;

            //importData.HazardsAndOrRequirements = "HazardsAndOrReq";

            // importData.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob = false;
            importData.FaceShield = pr.FaceShield;
            importData.Goggles = pr.Goggles;
            importData.RubberBoots = pr.RubberBoots;
            importData.RubberGloves = pr.RubberGloves;
            importData.RubberSuit = pr.RubberSuit;
            importData.SafetyHarnessLifeline = pr.SafetyHarnessLifeline;
            importData.HighVoltagePPE = pr.HighVoltagePPE;
            //importData.Other1 = pr.Other1;
            importData.EquipmentGrounded = pr.EquipmentGrounded;
            importData.FireBlanket = pr.FireBlanket;
            importData.FireExtinguisher = pr.FireExtinguisher;
            importData.FireMonitorManned = pr.FireMonitorManned;
            importData.FireWatch = pr.FireWatch;
            importData.SewersDrainsCovered = pr.SewersDrainsCovered;
            importData.SteamHose = pr.SteamHose;
            // importData.Other2 = "other2value";
            importData.AirPurifyingRespirator = pr.AirPurifyingRespirator;
            importData.BreathingAirApparatus = pr.BreathingAirApparatus;
            importData.DustMask = pr.DustMask;
            importData.LifeSupportSystem = pr.LifeSupportSystem;
            importData.SafetyWatch = pr.SafetyWatch;
            importData.ContinuousGasMonitor = pr.ContinuousGasMonitor;
            //importData.WorkersMonitorNumber = "WM1234";
            importData.BumpTestMonitorPriorToUse = pr.BumpTestMonitorPriorToUse;
            // importData.Other3 = "other3value";
            importData.AirMover = pr.AirMover;
            importData.BarriersSigns = pr.BarriersSigns;
            // importData.RadioChannelNumber = "54.123";
            importData.AirHorn = pr.AirHorn;
            importData.MechVentilationComfortOnly = pr.MechVentilationComfortOnly;
            importData.AsbestosMMCPrecautions = pr.AsbestosMMCPrecautions;
            //importData.Other4 = "Other4value";       

            return importData;
        }
    }
}
