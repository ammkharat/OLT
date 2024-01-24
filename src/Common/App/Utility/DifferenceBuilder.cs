using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public class DifferenceBuilder
    {
        private readonly object changedObject;
        private readonly List<PropertyChange> changes = new List<PropertyChange>();
        private readonly Type historyType;
        private readonly Set<string> ignoredProperties = new Set<string>();
        private readonly object originalObject;

        public DifferenceBuilder(object originalObject, object changedObject)
        {
            if (originalObject.GetType() != changedObject.GetType())
            {
                throw new ApplicationException("Both objects must be of the same type.");
            }
            historyType = originalObject.GetType();

            this.originalObject = originalObject;
            this.changedObject = changedObject;
        }

        public List<PropertyChange> Changes
        {
            get
            {
                changes.RemoveAll(change => ignoredProperties.Contains(change.PropertyName));
                return changes;
            }
        }

        public DifferenceBuilder ReflectionAppendAll()
        {
            return ReflectionAppendAll(string.Empty);
        }

        public DifferenceBuilder ReflectionAppendAll(string propertyLabel)
        {
            var properties = GetPropertyInfos(originalObject.GetType());

            var sortedProperties = new List<PropertyInfo>(properties);
            sortedProperties.Sort((x, y) => String.CompareOrdinal(x.Name, y.Name));

            foreach (var propertyInfo in sortedProperties)
            {
                var obj1PropertyValue = propertyInfo.GetValue(originalObject, null);
                var obj2PropertyValue = propertyInfo.GetValue(changedObject, null);
                var propertyName = propertyInfo.Name;

                if (IsImage(propertyInfo))
                {
                    AppendImage(propertyName, propertyLabel, (byte[]) obj1PropertyValue, (byte[]) obj2PropertyValue);
                }
                else if (IsGenericList(propertyInfo))
                {
                    AppendListDifferences(propertyName, propertyInfo.PropertyType.GetGenericArguments(),
                        (IList) obj1PropertyValue, (IList) obj2PropertyValue);
                }
                else if (IsDateTime(propertyInfo))
                {
                    Append(propertyName, propertyLabel,
                        FormatDateTime(obj1PropertyValue),
                        FormatDateTime(obj2PropertyValue));
                }
                else if (IsBool(propertyInfo))
                {
                    Append(propertyName, propertyLabel,
                        ((bool) obj1PropertyValue).ToLocalizedString(),
                        ((bool) obj2PropertyValue).ToLocalizedString());
                }
                else if (IsBoolNullable(propertyInfo))
                {
                    Append(propertyName, propertyLabel,
                        ((bool?) obj1PropertyValue).ToLocalizedString(),
                        ((bool?) obj2PropertyValue).ToLocalizedString());
                }
                else
                {
                    Append(propertyName, propertyLabel, obj1PropertyValue, obj2PropertyValue);
                }
            }
            return this;
        }

        private void AppendImage(string propertyName, string propertyLabel, byte[] obj1PropertyValue,
            byte[] obj2PropertyValue)
        {
            if (obj1PropertyValue == null && obj2PropertyValue == null)
            {
                return;
            }
            if (obj1PropertyValue == null)
            {
                changes.Add(new LocalizedPropertyChange(historyType, propertyName, propertyLabel, "No image",
                    "Image added"));
            }
            else if (obj2PropertyValue == null)
            {
                changes.Add(new LocalizedPropertyChange(historyType, propertyName, propertyLabel, "Image",
                    "Image removed"));
            }
            else if (!obj1PropertyValue.SequenceEqual(obj2PropertyValue))
            {
                changes.Add(new LocalizedPropertyChange(historyType, propertyName, propertyLabel, "Image",
                    "New version of image"));
            }
        }

        private void Append(string propertyName, string propertyLabel, object originalValue, object changedValue)
        {
            if (!originalValue.AreEqual(changedValue))
            {
                changes.Add(new LocalizedPropertyChange(historyType, propertyName, propertyLabel, originalValue,
                    changedValue));
            }
        }

        private static string FormatDateTime(object propertyValue)
        {
            return propertyValue == null ? string.Empty : ((DateTime) propertyValue).ToShortDateAndTimeString();
        }

        public static IEnumerable<PropertyInfo> GetPropertyInfos(Type type)
        {
            var propertyInfos = type.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            return Array.FindAll(propertyInfos, obj => !obj.HasAttribute<IgnoreDifferenceAttribute>(false));
        }

        private static bool IsImage(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof (byte[]) &&
                   propertyInfo.HasAttribute<ImageDifferenceAttribute>(false);
        }

        private static bool IsDateTime(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof (DateTime)
                   || propertyInfo.PropertyType == typeof (DateTime?);
        }

        private static bool IsBool(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof (bool);
        }

        private static bool IsBoolNullable(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType == typeof (bool?);
        }

        private static bool IsGenericList(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.IsGenericType &&
                   propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof (List<>);
        }

        private void AppendListDifferences(string propertyName, Type[] genericArguments, IList list1, IList list2)
        {
            if (list1.Count != list2.Count)
            {
                changes.Add(new ListSizeChange(propertyName, list1, list2));
            }
            else
            {
                var differenceLabelPropertyInfo = GetDifferenceLabelPropertyInfo(genericArguments);

                // This assumes that the lists are ordered to match.  Will need to extend
                // functionality when needed.
                for (var i = 0; i < list1.Count; i++)
                {
                    var item1 = list1[i];
                    var item2 = list2[i];

                    var label = string.Empty;
                    if (differenceLabelPropertyInfo != null)
                    {
                        if (item1 != null)
                        {
                            var labelObject = differenceLabelPropertyInfo.GetValue(item1, null);
                            if (labelObject != null)
                            {
                                label = labelObject.ToString();
                            }
                        }
                        else if (item2 != null)
                        {
                            var labelObject = differenceLabelPropertyInfo.GetValue(item2, null);
                            if (labelObject != null)
                            {
                                label = labelObject.ToString();
                            }
                        }
                    }

                    var builder = new DifferenceBuilder(item1, item2);
                    builder.ReflectionAppendAll(label);
                    changes.AddRange(builder.changes);
                }
            }
        }

        private static PropertyInfo GetDifferenceLabelPropertyInfo(Type[] genericArguments)
        {
            if (genericArguments.Length > 0)
            {
                var type = genericArguments[0];
                var propertyInfos = GetPropertyInfos(type);
                foreach (var propertyInfo in propertyInfos)
                {
                    if (propertyInfo.HasAttribute<DifferenceLabelAttribute>(false))
                    {
                        return propertyInfo;
                    }
                }
            }
            return null;
        }

        public DifferenceBuilder Ignore(string propertyName)
        {
            ignoredProperties.Add(propertyName);
            return this;
        }
    }
}