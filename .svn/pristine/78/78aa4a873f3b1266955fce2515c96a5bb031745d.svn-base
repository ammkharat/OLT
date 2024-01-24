using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    public static class WorkOrderWorkPermitAttribute
    {
        public const string IsConfinedSpaceEntry = "A";
        public const string IsBurnOrOpenFlame = "B";
        public const string IsSystemEntry = "C";
        public const string IsBreathingAirOrSCBA = "D";
        public const string IsVehicleEntry = "E";
        public const string IsExcavation = "F";
        public const string IsHotTap = "G";
        public const string IsAsbestos = "H";
        public const string IsCriticalLift = "I";
        public const string IsRadiationSealed = "J";
        public const string IsRadiationRadiography = "K";
        public const string Is_ElectricalWork_Via_ElectricSwitching = "L";
        public const string Is_ElectricalWork_Via_EnergizedElectrical = "M";
        public const string IsInertConfinedSpaceEntry = "N";
        public const string IsLeadAbatement = "O";

        public const string NotSpecified = "X";

        public static readonly string[] ALL =
        {
            IsConfinedSpaceEntry,
            IsBurnOrOpenFlame,
            IsSystemEntry,
            IsBreathingAirOrSCBA,
            IsVehicleEntry,
            IsExcavation,
            IsHotTap,
            IsAsbestos,
            IsCriticalLift,
            IsRadiationSealed,
            IsRadiationRadiography,
            Is_ElectricalWork_Via_ElectricSwitching,
            Is_ElectricalWork_Via_EnergizedElectrical,
            IsInertConfinedSpaceEntry,
            IsLeadAbatement
        };


        public static WorkPermitAttributes FromString(string attributeString)
        {
            var attributes = new WorkPermitAttributes();

            var attribsStringArray = WorkPermitAttributesParseUtility.ConvertSAPAttributeStringToArray(attributeString);

            foreach (var attrib in attribsStringArray)
            {
                switch (attrib)
                {
                    case IsConfinedSpaceEntry:
                        attributes.IsConfinedSpaceEntry = true;
                        break;

                    case IsBurnOrOpenFlame:
                        attributes.IsBurnOrOpenFlame = true;
                        break;

                    case IsSystemEntry:
                        attributes.IsSystemEntry = true;
                        break;

                    case IsBreathingAirOrSCBA:
                        attributes.IsBreathingAirOrSCBA = true;
                        break;

                    case IsVehicleEntry:
                        attributes.IsVehicleEntry = true;
                        break;

                    case IsExcavation:
                        attributes.IsExcavation = true;
                        break;

                    case IsHotTap:
                        attributes.IsHotTap = true;
                        break;

                    case IsAsbestos:
                        attributes.IsAsbestos = true;
                        break;

                    case IsCriticalLift:
                        attributes.IsCriticalLift = true;
                        break;

                    case IsRadiationSealed:
                        attributes.IsRadiationSealed = true;
                        break;

                    case IsRadiationRadiography:
                        attributes.IsRadiationRadiography = true;
                        break;

                    case Is_ElectricalWork_Via_ElectricSwitching:
                        attributes.IsElectricalWork = true;
                        break;

                    case Is_ElectricalWork_Via_EnergizedElectrical:
                        attributes.IsElectricalWork = true;
                        break;

                    case IsInertConfinedSpaceEntry:
                        attributes.IsInertConfinedSpaceEntry = true;
                        break;

                    case IsLeadAbatement:
                        attributes.IsLeadAbatement = true;
                        break;
                }
            }
            return attributes;
        }
    }
}