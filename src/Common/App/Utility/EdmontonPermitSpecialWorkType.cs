using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class EdmontonPermitSpecialWorkType : SimpleDomainObject
    {
        public static EdmontonPermitSpecialWorkType RadiographyInspections = new EdmontonPermitSpecialWorkType(0,
            "Radiography Inspections", PermitRequestEdmontonAttributes.SpecialWorkRadiographyInspections);

        public static EdmontonPermitSpecialWorkType DivingOperations = new EdmontonPermitSpecialWorkType(1,
            "Diving Operations", PermitRequestEdmontonAttributes.SpecialWorkDivingOperations);

        public static EdmontonPermitSpecialWorkType Excavation = new EdmontonPermitSpecialWorkType(2, "Excavation",
            PermitRequestEdmontonAttributes.SpecialWorkExcavation);

        public static EdmontonPermitSpecialWorkType HighVoltageElectricalWork = new EdmontonPermitSpecialWorkType(3,
            "High Voltage Electrical Work", PermitRequestEdmontonAttributes.SpecialWorkHighVoltageElectricalWork);

        public static EdmontonPermitSpecialWorkType HotTapping = new EdmontonPermitSpecialWorkType(4, "Hot Tapping",
            PermitRequestEdmontonAttributes.SpecialWorkHotTapping);

        public static EdmontonPermitSpecialWorkType OnstreamLeakSealing = new EdmontonPermitSpecialWorkType(5,
            "On-Stream Leak Sealing", PermitRequestEdmontonAttributes.SpecialWorkOnStreamLeakSealing);

        public static EdmontonPermitSpecialWorkType TransaltaUtilityWork = new EdmontonPermitSpecialWorkType(6,
            "TransAlta Utility Work", PermitRequestEdmontonAttributes.SpecialWorkTransAltaUtilityWork);

        public static EdmontonPermitSpecialWorkType FreezePlug = new EdmontonPermitSpecialWorkType(7, "Freeze Plug",
            PermitRequestEdmontonAttributes.SpecialWorkFreezePlugGN27);

        public static EdmontonPermitSpecialWorkType PowderActuatedTool = new EdmontonPermitSpecialWorkType(8,
            "Powder Actuated Tool Use in Operating Unit",
            PermitRequestEdmontonAttributes.SpecialWorkPowderActuatedToolUseInOperatingUnit);

        private static readonly List<EdmontonPermitSpecialWorkType> allInOrderedList = new List
            <EdmontonPermitSpecialWorkType>
        {
            RadiographyInspections,
            DivingOperations,
            Excavation,
            HighVoltageElectricalWork,
            HotTapping,
            OnstreamLeakSealing,
            TransaltaUtilityWork,
            FreezePlug,
            PowderActuatedTool
        };

        private readonly string name;
        private readonly string sapAttribute;

        private EdmontonPermitSpecialWorkType(long id, string name, string sapAttribute) : base(id)
        {
            this.name = name;
            this.sapAttribute = sapAttribute;
        }

        public static string DisplayMemberField
        {
            get { return "Name"; }
        }

        public override string GetName()
        {
            return name;
        }

        public static List<EdmontonPermitSpecialWorkType> GetAllAsList()
        {
            return allInOrderedList;
        }

        public static EdmontonPermitSpecialWorkType FindById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return GetById(id, allInOrderedList);
        }

        public static bool ContinuousGasMonitorIsRequired(EdmontonPermitSpecialWorkType value)
        {
            return HotTapping.Equals(value) || PowderActuatedTool.Equals(value) || OnstreamLeakSealing.Equals(value) ||
                   HighVoltageElectricalWork.Equals(value);
        }

        public static EdmontonPermitSpecialWorkType FindBySAPAttribute(string attribute)
        {
            return allInOrderedList.Find(a => a.sapAttribute.Equals(attribute));
        }
    }
}