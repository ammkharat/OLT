using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetCategory : SimpleDomainObject
    {
        public static TargetCategory PROCESS = new TargetCategory(1);
        public static TargetCategory PRODUCTION = new TargetCategory(2);
        public static TargetCategory ENV_SAFTEY = new TargetCategory(3);
        public static TargetCategory PRODUCTSPECIFICATION = new TargetCategory(4);
        public static TargetCategory ENERGY_MANAGEMENT = new TargetCategory(5);
        public static TargetCategory REGULATORY = new TargetCategory(6);
        public static TargetCategory KEY_PERFORMANCE_INDICATOR = new TargetCategory(7);

        private static readonly TargetCategory[] all =
        {
            PROCESS, PRODUCTION, ENV_SAFTEY, PRODUCTSPECIFICATION,
            ENERGY_MANAGEMENT, REGULATORY, KEY_PERFORMANCE_INDICATOR
        };

        private TargetCategory(long id) : base(id)
        {
        }

        public static TargetCategory[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.TargetCategory_Process;
            }
            if (IdValue == 2)
            {
                return StringResources.TargetCategory_Production;
            }
            if (IdValue == 3)
            {
                return StringResources.TargetCategory_EnvironmentalSafety;
            }
            if (IdValue == 4)
            {
                return StringResources.TargetCategory_ProductSpecification;
            }
            if (IdValue == 5)
            {
                return StringResources.TargetCategory_EnergyManagement;
            }
            if (IdValue == 6)
            {
                return StringResources.TargetCategory_Regulatory;
            }
            if (IdValue == 7)
            {
                return StringResources.TargetCategory_KeyPerformanceIndicator;
            }
            return null;
        }

        public static TargetCategory GetTargetCategory(long targetCategoryId)
        {
            var targetCategory = GetById(targetCategoryId, all);
            if (default(TargetCategory) == targetCategory)
            {
                //if you get here then we have an unknown target 
                //raise an error?
                throw new Exception("Target Category ID does not exist in application");
            }
            return targetCategory;
        }

        public static bool IsValidFullCategoryName(string categoryName)
        {
            return Array.Exists(All, category => categoryName == category.Name);
        }
    }
}