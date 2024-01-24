using System;
using System.Reflection;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class MemberInfoExtensions
    {
        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
        {
            return memberInfo.GetCustomAttributes(typeof (T), inherit).Length > 0;
        }

        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
        {
            var customAttributes = memberInfo.GetCustomAttributes(typeof (T), inherit);

            if (customAttributes.Length == 0)
                return default(T);

            var customAttribute = (T) customAttributes[0];
            return customAttribute;
        }
    }
}