using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Utility
{
    public class PermitRequestFortHillsAttributes
    {
        public const string FlameResistantWorkWear = "AA";
        public const string ChemicalSuit = "AB";
        public const string FireWatch = "AC";
        public const string FireBlanket = "AD";
        public const string SuppliedBreathingAir = "AE";
        public const string AirMover = "AF";
        public const string PersonalFlotationDevice = "AG";
        public const string HearingProtection = "AH";
        public const string Other1 = "AI";
        public const string MonoGoggles = "AJ";
        public const string ConfinedSpaceMoniter = "AK";
        public const string FireExtinguisher = "AL";
        public const string SparkContainment = "AM";
        public const string BottleWatch = "AN";
        public const string StandbyPerson = "AO";
        public const string WorkingAlone = "AP";
        public const string SafetyGloves = "AQ";
        public const string Other2 = "AR";
        public const string FaceShield = "AS";
        public const string FallProtection = "AT";
        public const string ChargedFireHouse = "AU";
        public const string CoveredSewer = "AV";
        public const string AirPurifyingRespirator = "AW";
        public const string SingalPerson = "AX";
        public const string CommunicationDevice = "AY";
        public const string ReflectiveStrips = "AZ";
        public const string Other3 = "BA";
        public const string ConfinedSpace = "BB";
        public const string ConfinedSpaceClass = "BC";
        public const string GroundDisturbance = "BD";
        public const string FireProtectionAuthorization = "BE";
        public const string CriticalOrSeriousLifts = "BF";
        public const string VehicleEntry = "BG";
        public const string IndustrialRadiography = "BH";
        public const string ElectricalEncroachment = "BI";
        public const string MSDS = "BJ";
        public const string OthersPartE = "BK";
        public const string MechanicallyIsolated = "BL";
        public const string BlindedOrBlanked = "BM";
        public const string DoubleBlockedandBled = "BN";
        public const string DrainedAndDepressurised = "BO";
        public const string PurgedorNeutralised = "BP";
        public const string ElectricallyIsolated = "BQ";
        public const string TestBumped = "BR";
        public const string NuclearSource = "BS";
        public const string ReceiverStafingRequirements = "BT";
        public const string DoNotMerge = "FY";
        public const string CriticalPath = "FZ";
        public const string ConfinedSpaceLevel1 = "GA";
        public const string ConfinedSpaceLevel2 = "GB";
        public const string ConfinedSpaceLevel3 = "GC";
     //   public const string AirHorn = "EA";
     //   public const string AirMover = "EB";
     //   public const string AirPurifyingRespirator = "EC";
     //   public const string AlkylationEntry = "ED";
     //   public const string AsbestosMMFPrecautions = "EE";
     //   public const string BarriersSigns = "EF";
     //   public const string BreathingAirApparatus = "EG";
     //   public const string BumpTestMonitorPriortoUse = "EI";
     //   public const string ConfinedSpaceGN1 = "EJ";
     //   public const string ContinuousGasMonitor = "EK";
     //   public const string DustMask = "EL";
     ////   public const string EquipmentGrounded = "EM";
     //   public const string MonoGoggles = "EM";
     //   public const string FaceShield = "EN";
     //   public const string FireBlanket = "EO";
     //   public const string FireExtinguisher = "EP";
     //   public const string FireMonitorManned = "EQ";
     //   public const string FireWatch = "ER";
     //   public const string FlarePitEntry = "ES";
     //   public const string GN11 = "ET";
     //   public const string GN24 = "EU";
     //   public const string GN27 = "EV";
     //   public const string GN59 = "EW";
     //   public const string GN6 = "EX";
     //   public const string GN7 = "EY";
     //   public const string GN75 = "EZ";
     //   public const string Goggle = "FA";
     //   public const string PersonalFlotationDevice = "PF";
     //   public const string LifeSupportSystem = "FC";
     //   public const string MechVentilationComfortOnly = "FD";
     //   public const string Radio = "FE";
     //   public const string RescuePlan = "FF";
     //   public const string RubberBoots = "FG";
     //   public const string ConfinedSpaceMoniter = "FH"; //
     //   public const string RubberSuit = "FI";
     //   public const string SafetyHarnessLifeline = "FJ";
     //   public const string SafetyWatch = "FK";
     //   public const string SewersDrainsCovered = "FL";
     //   public const string SpecialWorkDivingOperations = "FM";
     //   public const string SpecialWorkExcavation = "FN";
     //   public const string SpecialWorkFreezePlugGN27 = "FO";
     //   public const string SpecialWorkHighVoltageElectricalWork = "FP";
     //   public const string SpecialWorkHotTapping = "FQ";
     //   public const string SpecialWorkOnStreamLeakSealing = "FR";
     //   public const string SpecialWorkPowderActuatedToolUseInOperatingUnit = "FS";
     //   public const string SpecialWorkRadiographyInspections = "FT";
     //   public const string SpecialWorkTransAltaUtilityWork = "FU";
     //   public const string SteamHose = "FV";
     //   public const string VehicleEntry = "FW";
     //   public const string WorkersMonitor = "FX";


        private readonly HashSet<string> attributes = new HashSet<string>();

        private readonly HashSet<string> specialWorkAttributeCodes = new HashSet<string>
        {
            //SpecialWorkDivingOperations,
            //SpecialWorkExcavation,
            //SpecialWorkFreezePlugGN27,
            //SpecialWorkHighVoltageElectricalWork,
            //SpecialWorkHotTapping,
            //SpecialWorkOnStreamLeakSealing,
            //SpecialWorkPowderActuatedToolUseInOperatingUnit,
            //SpecialWorkRadiographyInspections,
            //SpecialWorkTransAltaUtilityWork
        };

        public PermitRequestFortHillsAttributes(IEnumerable<string> attributes)
        {
            this.attributes.UnionWith(attributes);
        }

        public void SetAttributesOnPermitRequest(PermitRequestFortHills permitRequest)
        {
            permitRequest.FlameResistantWorkWear = GetBooleanValue(FlameResistantWorkWear);
            permitRequest.ChemicalSuit = GetBooleanValue(ChemicalSuit);
            permitRequest.FireWatch = GetBooleanValue(FireWatch);
            permitRequest.FireBlanket = GetBooleanValue(FireBlanket);
            permitRequest.SuppliedBreathingAir = GetBooleanValue(SuppliedBreathingAir);
            permitRequest.AirMover = GetBooleanValue(AirMover);
            permitRequest.PersonalFlotationDevice = GetBooleanValue(PersonalFlotationDevice);
            permitRequest.HearingProtection = GetBooleanValue(HearingProtection);
            //permitRequest.Other1 = GetBooleanValue(Other1);
            permitRequest.MonoGoggles = GetBooleanValue(MonoGoggles);
            permitRequest.ConfinedSpaceMoniter = GetBooleanValue(ConfinedSpaceMoniter);
            permitRequest.FireExtinguisher = GetBooleanValue(FireExtinguisher);
            permitRequest.SparkContainment = GetBooleanValue(SparkContainment);
            permitRequest.BottleWatch = GetBooleanValue(BottleWatch);
            permitRequest.StandbyPerson = GetBooleanValue(StandbyPerson);
            permitRequest.WorkingAlone = GetBooleanValue(WorkingAlone);
            permitRequest.SafetyGloves = GetBooleanValue(SafetyGloves);
            //permitRequest.Other2 = GetBooleanValue(Other2);
            permitRequest.FaceShield = GetBooleanValue(FaceShield);
            permitRequest.FallProtection = GetBooleanValue(FallProtection);
            permitRequest.ChargedFireHouse = GetBooleanValue(ChargedFireHouse);
            permitRequest.CoveredSewer = GetBooleanValue(CoveredSewer);
            permitRequest.AirPurifyingRespirator = GetBooleanValue(AirPurifyingRespirator);
            permitRequest.SingalPerson = GetBooleanValue(SingalPerson);
            permitRequest.CommunicationDevice = GetBooleanValue(CommunicationDevice);
            permitRequest.ReflectiveStrips = GetBooleanValue(ReflectiveStrips);
            //permitRequest.Other3 = GetBooleanValue(Other3);
            permitRequest.ConfinedSpace = GetBooleanValue(ConfinedSpace);
            //permitRequest.ConfinedSpaceClass = GetBooleanValue(ConfinedSpaceClass);
            permitRequest.GroundDisturbance = GetBooleanValue(GroundDisturbance);
            permitRequest.FireProtectionAuthorization = GetBooleanValue(FireProtectionAuthorization);
            permitRequest.CriticalOrSeriousLifts = GetBooleanValue(CriticalOrSeriousLifts);
            permitRequest.VehicleEntry = GetBooleanValue(VehicleEntry);
            permitRequest.IndustrialRadiography = GetBooleanValue(IndustrialRadiography);
            permitRequest.ElectricalEncroachment = GetBooleanValue(ElectricalEncroachment);
            permitRequest.MSDS = GetBooleanValue(MSDS);
           // permitRequest.OthersPartE = GetBooleanValue(OthersPartE);
            permitRequest.MechanicallyIsolated = GetBooleanValue(MechanicallyIsolated);
            permitRequest.BlindedOrBlanked = GetBooleanValue(BlindedOrBlanked);
            permitRequest.DoubleBlockedandBled = GetBooleanValue(DoubleBlockedandBled);
            permitRequest.DrainedAndDepressurised = GetBooleanValue(DrainedAndDepressurised);
            permitRequest.PurgedorNeutralised = GetBooleanValue(PurgedorNeutralised);
            permitRequest.ElectricallyIsolated = GetBooleanValue(ElectricallyIsolated);
            permitRequest.TestBumped = GetBooleanValue(TestBumped);
            permitRequest.NuclearSource = GetBooleanValue(NuclearSource);
            permitRequest.ReceiverStafingRequirements = GetBooleanValue(ReceiverStafingRequirements);

            //permitRequest.CriticalOrSeriousLifts = GetBooleanValue(AirHorn);
            //permitRequest.AirMover = GetBooleanValue(AirMover);
            //permitRequest.AirPurifyingRespirator = GetBooleanValue(AirPurifyingRespirator);
           // permitRequest.AlkylationEntry = GetBooleanValue(AlkylationEntry);
            //permitRequest.IndustrialRadiography = GetBooleanValue(AsbestosMMFPrecautions);
            //permitRequest.GroundDisturbance = GetBooleanValue(BarriersSigns);
            //permitRequest.BreathingAirApparatus = GetBooleanValue(BreathingAirApparatus);
            //permitRequest.BumpTestMonitorPriorToUse = GetBooleanValue(BumpTestMonitorPriortoUse);
            //permitRequest.ContinuousGasMonitor = GetBooleanValue(ContinuousGasMonitor);
            //permitRequest.DustMask = GetBooleanValue(DustMask);
            //permitRequest.EquipmentGrounded = GetBooleanValue(EquipmentGrounded);
            //permitRequest.MonoGoggles = GetBooleanValue(MonoGoggles);
            //permitRequest.FaceShield = GetBooleanValue(FaceShield);
            //permitRequest.FireBlanket = GetBooleanValue(FireBlanket);
            //permitRequest.FireExtinguisher = GetBooleanValue(FireExtinguisher);
            //permitRequest.FireMonitorManned = GetBooleanValue(FireMonitorManned);
            //permitRequest.FireWatch = GetBooleanValue(FireWatch);
            //permitRequest.FlarePitEntry = GetBooleanValue(FlarePitEntry);
            //permitRequest.GN59 = GetBooleanValue(GN59);
            //permitRequest.GN6 = GetBooleanValue(GN6);
            //permitRequest.GN7 = GetBooleanValue(GN7);
            //permitRequest.GN24 = GetBooleanValue(GN24);
            //permitRequest.GN75A = GetBooleanValue(GN75);
            //permitRequest.GN11 = GetFormState(GN11);
            //permitRequest.GN27 = GetFormState(GN27);
            //permitRequest.ChemicalSuit = GetBooleanValue(Goggle);
            //permitRequest.PersonalFlotationDevice = GetBooleanValue(PersonalFlotationDevice);
            //permitRequest.LifeSupportSystem = GetBooleanValue(LifeSupportSystem);
            //permitRequest.VehicleEntry = GetBooleanValue(MechVentilationComfortOnly);
            //permitRequest.FireProtectionAuthorization = GetBooleanValue(Radio);
            //permitRequest.RescuePlan = GetBooleanValue(RescuePlan);
            //permitRequest.RubberBoots = GetBooleanValue(RubberBoots);
            //permitRequest.ConfinedSpaceMoniter = GetBooleanValue(ConfinedSpaceMoniter);
            //permitRequest.RubberSuit = GetBooleanValue(RubberSuit);
            //permitRequest.SuppliedBreathingAir = GetBooleanValue(RubberSuit);
            //permitRequest.SafetyWatch = GetBooleanValue(SafetyWatch);
            //permitRequest.SewersDrainsCovered = GetBooleanValue(SewersDrainsCovered);
            //permitRequest.SpecialWorkType = GetSpecialWorkType();
            //permitRequest.SpecialWork = permitRequest.SpecialWorkType != null;
            //permitRequest.SteamHose = GetBooleanValue(SteamHose);
            //permitRequest.VehicleEntry = GetBooleanValue(VehicleEntry);
            //permitRequest.WorkersMonitor = GetBooleanValue(WorkersMonitor);
            //permitRequest.DoNotMerge = GetBooleanValue(DoNotMerge);
            permitRequest.ConfinedSpace = GetBooleanValue(ConfinedSpaceLevel1) || GetBooleanValue(ConfinedSpaceLevel2) ||
                                          GetBooleanValue(ConfinedSpaceLevel3);
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

        //private FortHillsPermitSpecialWorkType GetSpecialWorkType()
        //{
        //    foreach (var code in specialWorkAttributeCodes)
        //    {
        //        if (GetBooleanValue(code))
        //        {
        //            return FortHillsPermitSpecialWorkType.FindBySAPAttribute(code);
        //        }
        //    }

        //    return null;
        //}

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