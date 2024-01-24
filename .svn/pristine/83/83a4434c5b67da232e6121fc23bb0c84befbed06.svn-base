using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class LocalizedPropertyChangeTest
    {
        [Test][Ignore]
        public void ShouldHaveLocalizedLabelsForEveryHistoryClass()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                if (assembly.FullName.ToLower().Contains("olt"))
                {
                    AssertHasLocalizedLabelsForAllProperties(assembly.GetTypes());
                }
            }
        }

        private static void AssertHasLocalizedLabelsForAllProperties(Type[] types)
        {
            List<Type> sorted = new List<Type>(types);
            sorted.Sort((x,y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (Type type in sorted)
            {
                if (typeof(IHistorySnapshot).IsAssignableFrom(type) &&
                    typeof(IHistorySnapshot) != type &&
                    type.Name != "WorkPermitHistory" &&
                    !type.Name.StartsWith("GasTest") &&
                    type.Name != "FunctionalLocationOperationalModeHistory" &&
                    !type.Name.StartsWith("Coker") &&
                    !type.Name.StartsWith("Lab") &&
                    !type.Name.StartsWith("Deviation") &&
                    !type.Name.StartsWith("Restriction") &&
                    type.Name != "BasePermitRequestHistory" &&
                    type.Name != "BaseFormHistory" &&
                    type.Name != "PermitRequestEdmontonHistory" &&
                    type.Name != "WorkPermitEdmontonHistory")
                {
                    AssertHasLocalizedLabelsForAllProperties("  ", type);
                }
            }
        }

        private static void AssertHasLocalizedLabelsForAllProperties(string level, Type type)
        {
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>(DifferenceBuilder.GetPropertyInfos(type));
            propertyInfos.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;

                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (List<>))
                {
                    AssertHasLocalizedLabelsForAllProperties(level + "      ", propertyType.GetGenericArguments()[0]);
                }
                else if (!propertyInfo.HasAttribute<DifferenceLabelAttribute>(false) &&
                         propertyInfo.Name != "LastModifiedBy" &&
                         propertyInfo.Name != "LastModifiedDate" &&
                         propertyInfo.Name != "Deleted")
                {
                    LocalizedPropertyChange change = new LocalizedPropertyChange(type, propertyInfo.Name, null, null, null);
                    string localizedLabel = change.GetLocalizedLabel();

                    Assert.IsFalse(
                        localizedLabel.IsNullOrEmptyOrWhitespace(),
                        String.Format("No localized label for {0}.{1}", type.Name, propertyInfo.Name));
                }
            }
        }
    }
}
