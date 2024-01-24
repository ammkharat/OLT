using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    /// <summary>
    ///     Describes a section of a work permit (a work permit is a form with many sections).
    /// </summary>
    [Serializable]
    public class WorkPermitSection : ComparableObject
    {
        public static WorkPermitSection PermitType = new WorkPermitSection(
            StringResources.WorkPermitSection_PermitType, "PermitType");

        public static WorkPermitSection PermitAttributes =
            new WorkPermitSection(StringResources.WorkPermitSection_PermitAttributes, "PermitAttributes");

        public static WorkPermitSection PermitTypeAndAttributes =
            new WorkPermitSection(StringResources.WorkPermitSection_PermitTypeAndAttributes, "PermitTypeAndAttributes");

        public static WorkPermitSection AdditionalForms =
            new WorkPermitSection(StringResources.WorkPermitSection_AdditionalForms, "AdditionalItemsRequired");

        public static WorkPermitSection LocationJobSpecificsScope =
            new WorkPermitSection(StringResources.WorkPermitSection_LocationJobSpecificsScope,
                "LocationJobSpecificsScope");

        public static WorkPermitSection Tools = new WorkPermitSection(StringResources.WorkPermitSection_Tools, "Tools");

        public static WorkPermitSection EquipmentPreparationCondition =
            new WorkPermitSection(StringResources.WorkPermitSection_EquipmentPreparationCondition,
                "EquipmentPreparationAndCondition");

        public static WorkPermitSection JobWorksitePreparation =
            new WorkPermitSection(StringResources.WorkPermitSection_JobWorksitePreparation, "JobWorksitePreparation");

        public static WorkPermitSection RadiationInformation =
            new WorkPermitSection(StringResources.WorkPermitSection_RadiationInformation, "Radiation");

        public static WorkPermitSection CommunicationMethod =
            new WorkPermitSection(StringResources.WorkPermitSection_CommunicationMethod, "CommunicationMethod");

        public static WorkPermitSection FireConfinedSpaceRequirements =
            new WorkPermitSection(StringResources.WorkPermitSection_FireConfinedSpaceRequirements,
                "FireConfinedSpaceProtection");

        public static WorkPermitSection RespiratoryProtectionRequirements =
            new WorkPermitSection(StringResources.WorkPermitSection_RespiratoryProtectionRequirements,
                "RespiratoryProtection");

        public static WorkPermitSection SpecialPPERequirements =
            new WorkPermitSection(StringResources.WorkPermitSection_SpecialPPERequirements, "SpecialPPE");

        public static WorkPermitSection SpecialPrecautionsOrConsiderations =
            new WorkPermitSection(StringResources.WorkPermitSection_SpecialPrecautionsOrConsiderations,
                "SpecialPrecautionsConsiderations");

        public static WorkPermitSection GasTests = new WorkPermitSection(StringResources.WorkPermitSection_GasTests,
            "GasTests");

        public static WorkPermitSection NotificationAuthorization =
            new WorkPermitSection(StringResources.WorkPermitSection_NotificationAuthorization,
                "NotificationsAuthorizations");

        public static WorkPermitSection Miscellaneous =
            new WorkPermitSection(StringResources.WorkPermitSection_Miscellaneous, "Misc");

        public static WorkPermitSection Asbestos = new WorkPermitSection(StringResources.WorkPermitSection_Asbestos,
            "Asbestos");

        private static readonly WorkPermitSection[] allAvailableForCopying =
        {
            Tools,
            EquipmentPreparationCondition,
            JobWorksitePreparation,
            RadiationInformation,
            FireConfinedSpaceRequirements,
            RespiratoryProtectionRequirements,
            SpecialPPERequirements,
            SpecialPrecautionsOrConsiderations,
            GasTests,
            NotificationAuthorization,
            AdditionalForms,
            Miscellaneous,
            Asbestos
        };

        private WorkPermitSection(string sectionName, string groupKey)
        {
            Name = sectionName;
            GroupKey = groupKey;
        }

        public string Name { get; set; }

        public string GroupKey { get; set; }

        public static WorkPermitSection[] AllAvailableForCopying
        {
            get { return allAvailableForCopying; }
        }
    }
}