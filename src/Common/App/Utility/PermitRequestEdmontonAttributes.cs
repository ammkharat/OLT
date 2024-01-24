using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Utility
{
    public class PermitRequestEdmontonAttributes
    {
        public const string AirHorn = "EA";
        public const string AirMover = "EB";
        public const string AirPurifyingRespirator = "EC";
        public const string AlkylationEntry = "ED";
        public const string AsbestosMMFPrecautions = "EE";
        public const string BarriersSigns = "EF";
        public const string BreathingAirApparatus = "EG";
        public const string BumpTestMonitorPriortoUse = "EI";
        public const string ConfinedSpaceGN1 = "EJ";
        public const string ContinuousGasMonitor = "EK";
        public const string DustMask = "EL";
        public const string EquipmentGrounded = "EM";
        public const string FaceShield = "EN";
        public const string FireBlanket = "EO";
        public const string FireExtinguisher = "EP";
        public const string FireMonitorManned = "EQ";
        public const string FireWatch = "ER";
        public const string FlarePitEntry = "ES";
        public const string GN11 = "ET";
        public const string GN24 = "EU";
        public const string GN27 = "EV";
        public const string GN59 = "EW";
        public const string GN6 = "EX";
        public const string GN7 = "EY";
        public const string GN75 = "EZ";
        public const string Goggle = "FA";
        public const string HighVoltagePPE = "FB";
        public const string LifeSupportSystem = "FC";
        public const string MechVentilationComfortOnly = "FD";
        public const string Radio = "FE";
        public const string RescuePlan = "FF";
        public const string RubberBoots = "FG";
        public const string RubberGloves = "FH";
        public const string RubberSuit = "FI";
        public const string SafetyHarnessLifeline = "FJ";
        public const string SafetyWatch = "FK";
        public const string SewersDrainsCovered = "FL";
        public const string SpecialWorkDivingOperations = "FM";
        public const string SpecialWorkExcavation = "FN";
        public const string SpecialWorkFreezePlugGN27 = "FO";
        public const string SpecialWorkHighVoltageElectricalWork = "FP";
        public const string SpecialWorkHotTapping = "FQ";
        public const string SpecialWorkOnStreamLeakSealing = "FR";
        public const string SpecialWorkPowderActuatedToolUseInOperatingUnit = "FS";
        public const string SpecialWorkRadiographyInspections = "FT";
        public const string SpecialWorkTransAltaUtilityWork = "FU";
        public const string SteamHose = "FV";
        public const string VehicleEntry = "FW";
        public const string WorkersMonitor = "FX";
        public const string DoNotMerge = "FY";
        public const string CriticalPath = "FZ";
        public const string ConfinedSpaceLevel1 = "GA";
        public const string ConfinedSpaceLevel2 = "GB";
        public const string ConfinedSpaceLevel3 = "GC";

        private readonly HashSet<string> attributes = new HashSet<string>();

        private readonly HashSet<string> specialWorkAttributeCodes = new HashSet<string>
        {
            SpecialWorkDivingOperations,
            SpecialWorkExcavation,
            SpecialWorkFreezePlugGN27,
            SpecialWorkHighVoltageElectricalWork,
            SpecialWorkHotTapping,
            SpecialWorkOnStreamLeakSealing,
            SpecialWorkPowderActuatedToolUseInOperatingUnit,
            SpecialWorkRadiographyInspections,
            SpecialWorkTransAltaUtilityWork
        };

        public PermitRequestEdmontonAttributes(IEnumerable<string> attributes)
        {
            this.attributes.UnionWith(attributes);
        }

        public void SetAttributesOnPermitRequest(PermitRequestEdmonton permitRequest)
        {
            permitRequest.AirHorn = GetBooleanValue(AirHorn);
            permitRequest.AirMover = GetBooleanValue(AirMover);
            permitRequest.AirPurifyingRespirator = GetBooleanValue(AirPurifyingRespirator);
            permitRequest.AlkylationEntry = GetBooleanValue(AlkylationEntry);
            permitRequest.AsbestosMMCPrecautions = GetBooleanValue(AsbestosMMFPrecautions);
            permitRequest.BarriersSigns = GetBooleanValue(BarriersSigns);
            permitRequest.BreathingAirApparatus = GetBooleanValue(BreathingAirApparatus);
            permitRequest.BumpTestMonitorPriorToUse = GetBooleanValue(BumpTestMonitorPriortoUse);
            permitRequest.ContinuousGasMonitor = GetBooleanValue(ContinuousGasMonitor);
            permitRequest.DustMask = GetBooleanValue(DustMask);
            permitRequest.EquipmentGrounded = GetBooleanValue(EquipmentGrounded);
            permitRequest.FaceShield = GetBooleanValue(FaceShield);
            permitRequest.FireBlanket = GetBooleanValue(FireBlanket);
            permitRequest.FireExtinguisher = GetBooleanValue(FireExtinguisher);
            permitRequest.FireMonitorManned = GetBooleanValue(FireMonitorManned);
            permitRequest.FireWatch = GetBooleanValue(FireWatch);
            permitRequest.FlarePitEntry = GetBooleanValue(FlarePitEntry);

            permitRequest.GN59 = GetBooleanValue(GN59);
            permitRequest.GN6 = GetBooleanValue(GN6);
            permitRequest.GN7 = GetBooleanValue(GN7);
            permitRequest.GN24 = GetBooleanValue(GN24);
            permitRequest.GN75A = GetBooleanValue(GN75);

            permitRequest.GN11 = GetFormState(GN11);
            permitRequest.GN27 = GetFormState(GN27);

            permitRequest.Goggles = GetBooleanValue(Goggle);
            permitRequest.HighVoltagePPE = GetBooleanValue(HighVoltagePPE);
            permitRequest.LifeSupportSystem = GetBooleanValue(LifeSupportSystem);
            permitRequest.MechVentilationComfortOnly = GetBooleanValue(MechVentilationComfortOnly);
            permitRequest.RadioChannel = GetBooleanValue(Radio);
            permitRequest.RescuePlan = GetBooleanValue(RescuePlan);
            permitRequest.RubberBoots = GetBooleanValue(RubberBoots);
            permitRequest.RubberGloves = GetBooleanValue(RubberGloves);
            permitRequest.RubberSuit = GetBooleanValue(RubberSuit);
            permitRequest.SafetyHarnessLifeline = GetBooleanValue(SafetyHarnessLifeline);
            permitRequest.SafetyWatch = GetBooleanValue(SafetyWatch);
            permitRequest.SewersDrainsCovered = GetBooleanValue(SewersDrainsCovered);

            permitRequest.SpecialWorkType = GetSpecialWorkType();
            permitRequest.SpecialWork = permitRequest.SpecialWorkType != null;

            permitRequest.SteamHose = GetBooleanValue(SteamHose);
            permitRequest.VehicleEntry = GetBooleanValue(VehicleEntry);
            permitRequest.WorkersMonitor = GetBooleanValue(WorkersMonitor);

            permitRequest.DoNotMerge = GetBooleanValue(DoNotMerge);

            permitRequest.ConfinedSpace = GetBooleanValue(ConfinedSpaceLevel1) || GetBooleanValue(ConfinedSpaceLevel2) ||
                                          GetBooleanValue(ConfinedSpaceLevel3) || GetBooleanValue(ConfinedSpaceGN1);
            permitRequest.ConfinedSpaceClass = GetConfinedSpaceLevel();

            permitRequest.Priority = GetPriority();
        }

        private Priority GetPriority()
        {
            return GetBooleanValue(CriticalPath) ? Priority.CriticalPath : Priority.Normal;
        }

        private bool GetBooleanValue(string attribute)
        {
            return attributes.Contains(attribute);
        }

        private WorkPermitSafetyFormState GetFormState(string attribute)
        {
            return attributes.Contains(attribute)
                ? WorkPermitSafetyFormState.Required
                : WorkPermitSafetyFormState.NotApplicable;
        }

        private EdmontonPermitSpecialWorkType GetSpecialWorkType()
        {
            foreach (var code in specialWorkAttributeCodes)
            {
                if (GetBooleanValue(code))
                {
                    return EdmontonPermitSpecialWorkType.FindBySAPAttribute(code);
                }
            }

            return null;
        }

        private string GetConfinedSpaceLevel()
        {
            if (GetBooleanValue(ConfinedSpaceLevel1))
            {
                return WorkPermitEdmonton.ConfinedSpaceLevel1;
            }

            if (GetBooleanValue(ConfinedSpaceLevel2))
            {
                return WorkPermitEdmonton.ConfinedSpaceLevel2;
            }

            if (GetBooleanValue(ConfinedSpaceLevel3))
            {
                return WorkPermitEdmonton.ConfinedSpaceLevel3;
            }

            return null;
        }
    }
}