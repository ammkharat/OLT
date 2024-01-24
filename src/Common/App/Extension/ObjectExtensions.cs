using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class ObjectExtensions
    {
        private static bool Compare(Type type, object o1, object o2)
        {
            if (type.BaseType != null)
            {
                return Compare(type.BaseType, o1, o2) && CompareFields(type, o1, o2);
            }

            return CompareFields(type, o1, o2);
        }

        private static bool CompareFields(Type typeToCompare, object o1, object o2)
        {
            if (typeof (IList).IsInstanceOfType(o1))
                return ListsAreEqual((IList) o1, (IList) o2);

            foreach (
                var thisFieldInfo in
                    typeToCompare.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance |
                                            BindingFlags.FlattenHierarchy))
            {
                if (!thisFieldInfo.IsStatic && !IsIgnored(thisFieldInfo))
                {
                    var obj1FieldValue = thisFieldInfo.GetValue(o1);
                    var obj2FieldValue = thisFieldInfo.GetValue(o2);

                    if (obj1FieldValue is IList)
                    {
                        var listsAreEqual = ListsAreEqual((IList) obj1FieldValue, (IList) obj2FieldValue);
                        if (!listsAreEqual)
                            return false;
                    }
                    else if (!AreEqual(obj1FieldValue, obj2FieldValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool ReflectionEquals(this object o1, object o2)
        {
            var o1Null = ReferenceEquals(o1, null);
            var o2Null = ReferenceEquals(o2, null);
            if (o1Null && o2Null) return true;
            if (o1Null || o2Null) return false;

            if (o1.GetType() != o2.GetType())
                return false;

            if (ReferenceEquals(o1, o2))
                return true;

            return Compare(o1.GetType(), o1, o2);
        }

        internal static bool AreEqual(this object o1, object o2)
        {
            var o1Null = ReferenceEquals(o1, null);
            var o2Null = ReferenceEquals(o2, null);
            if (o1Null && o2Null) return true;
            if (o1Null || o2Null) return false;

            if (o1.GetType() != o2.GetType()) return false;

            if (ReferenceEquals(o1, o2))
                return true;

            if (o1.Equals(o2))
                return true;
            return false;
        }

        public static bool AreNotEqualOperator<T>(this T x, T y)
        {
            var xnull = ReferenceEquals(x, null);
            var ynull = ReferenceEquals(y, null);
            if (xnull && ynull) return false;
            if (xnull || ynull) return true;

            return !x.Equals(y);
        }

        public static bool AreEqualOperator<T>(this T x, T y)
        {
            var xnull = ReferenceEquals(x, null);
            var ynull = ReferenceEquals(y, null);
            if (xnull && ynull) return true;
            if (xnull || ynull) return false;

            return x.Equals(y);
        }

        private static bool ListsAreEqual(IList actualList, IList expectedList)
        {
            if (actualList.Count != expectedList.Count)
                return false;

            for (var i = 0; i < actualList.Count; i++)
            {
                bool itemInListIsEqual = actualList[i].ReflectionEquals(expectedList[i]);
                if (!itemInListIsEqual)
                    return false;
            }
            return true;
        }

        private static bool IsIgnored(ICustomAttributeProvider thisFieldInfo)
        {
            var attributes = thisFieldInfo.GetCustomAttributes(false);
            return attributes.Exists(a => a is IgnoreComparingAttribute);
        }

        public static int ReflectionGetHashCode(this object obj)
        {
            var builder = new HashCodeBuilder();
            foreach (
                var thisFieldInfo in
                    obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!thisFieldInfo.IsStatic)
                {
                    var objFieldValue = thisFieldInfo.GetValue(obj);
                    builder.Append(objFieldValue);
                }
            }
            return builder.HashCode;
        }

        public static bool HasNoValue<T>(this T? item) where T : struct
        {
            return !item.HasValue;
        }

        public static bool DoesNotEqual(this object obj, object other)
        {
            return !Equals(obj, other);
        }

        public static string ReflectionToString(this object obj)
        {
            var sb = new StringBuilder();

            sb.Append(obj.GetType().Name);
            sb.Append(" ( ");

            var i = 0;
            foreach (var thisFieldInfo in obj.GetType().GetFields())
            {
                if (!thisFieldInfo.IsStatic)
                {
                    object objField = thisFieldInfo.Name;
                    var objFieldValue = thisFieldInfo.GetValue(obj);

                    if (i > 0)
                    {
                        sb.Append(", ");
                    }
                    sb.Append(objField);
                    sb.Append(" = ");
                    sb.Append(objFieldValue);
                    i++;
                }
            }

            foreach (var thisPropertyInfo in obj.GetType().GetProperties())
            {
                if (thisPropertyInfo.CanRead == false || thisPropertyInfo.HasAttribute<IgnoreToStringAttribute>(false))
                {
                    continue;
                }

                object objProperty = thisPropertyInfo.Name;
                var objPropertyValue = thisPropertyInfo.GetValue(obj, null);

                if (i > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(objProperty);
                sb.Append(" = ");
                sb.Append(objPropertyValue);
                i++;
            }

            sb.Append(" )");

            return sb.ToString();
        }

        public static T DeepClone<T>(this T source)
        {
            if (!typeof (T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }
    }

    /// <summary>
    ///     Not used in Comparing two objects.
    /// </summary>
    public class IgnoreComparingAttribute : Attribute
    {
    }
}