using System;
using System.Collections.Generic;
using System.Reflection;

namespace Com.Suncor.Olt.Common.Utility.Comparer
{
    /// <summary>
    ///     Compares two objects using a property of the object.
    ///     That property has to implement the <code>IComparable</code> interface.
    /// </summary>
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly PropertyInfo propertyInfo;

        public PropertyComparer(string propertyName)
        {
            propertyInfo = typeof (T).GetProperty(propertyName);

            if (propertyInfo == null)
            {
                throw new ApplicationException(string.Format("Type:<{0}> has no property named:<{1}>.",
                    typeof (T), propertyName));
            }

            if (Implements(GetPropertyType(propertyInfo), typeof (IComparable)) == false)
            {
                throw new ApplicationException(
                    string.Format("Type:<{0}> of property:<{1}> does not implement IComparable interface.",
                        propertyInfo.PropertyType, propertyName));
            }
        }


        public int Compare(T left, T right)
        {
            if (null == left || null == right)
            {
                return CheckForNullValues(left, right);
            }

            var leftPropertyValue = propertyInfo.GetValue(left, null) as IComparable;
            var rightPropertyValue = propertyInfo.GetValue(right, null) as IComparable;

            if (null == leftPropertyValue || null == rightPropertyValue)
            {
                return CheckForNullValues(leftPropertyValue, rightPropertyValue);
            }

            return leftPropertyValue.CompareTo(rightPropertyValue);
        }

        private static int CheckForNullValues(object left, object right)
        {
            if (null == left && null == right)
            {
                return 0;
            }
            if (null == left)
            {
                return -1;
            }
            if (null == right)
            {
                return 1;
            }

            throw new ApplicationException("This should never happen.");
        }

        private Type GetPropertyType(PropertyInfo propertyInfo)
        {
            if (IsNullableType(propertyInfo.PropertyType))
            {
                return UnboxNullableType(propertyInfo.PropertyType);
            }
            return propertyInfo.PropertyType;
        }

        private static bool IsNullableType(Type type)
        {
            if (type.IsGenericType == false)
            {
                return false;
            }

            return type.GetGenericTypeDefinition() == typeof (Nullable<>);
        }

        private static bool Implements(Type x, Type y)
        {
            return y.IsAssignableFrom(x);
        }

        private static Type UnboxNullableType(Type nullableType)
        {
            return nullableType.GetGenericArguments()[0];
        }
    }
}