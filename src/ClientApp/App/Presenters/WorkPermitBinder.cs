using System;
using System.Collections.Generic;
using System.Reflection;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters
{
    public interface IWorkPermitBinder
    {
        void ToView(object domainObject, object view, Version viewVersion);
        void ToModel(object view, object domainObject, Version viewVersion);
    }

    public class WorkPermitBinder : IWorkPermitBinder
    {
        private readonly long siteId;

        public WorkPermitBinder(long siteId)
        {
            this.siteId = siteId;
        }

        #region IWorkPermitBinder Members

        public void ToView(object domainObject, object view, Version viewVersion)
        {
            string groupAlias = GetGroupAlias(domainObject);
            List<PropertyInfoWithAttribute> propertiesForSite = GetOrderedPropertiesForSite(domainObject, siteId);
            foreach (PropertyInfoWithAttribute propertyForSite in propertiesForSite)
            {
                if (propertyForSite.Attribute.IsGroup)
                {
                    object group = propertyForSite.PropertyInfo.GetValue(domainObject, null);
                    ToView(group, view, viewVersion);
                }
                else
                {
                    object workPermitModelPropertyValue = propertyForSite.PropertyInfo.GetValue(domainObject, null);
                    string propertyName = groupAlias + propertyForSite.PropertyInfo.Name;
                    PropertyInfo viewProperty = view.GetType().GetProperty(propertyName);
                    if (viewProperty == null)
                    {
                        if (propertyForSite.Attribute.Version == viewVersion)
                        {
                            throw new WorkPermitBinderException(String.Format("Could not find property '{0}' on '{1}'.", propertyName, view.GetType().Name));
                        }
                    }
                    else
                    {
                        viewProperty.SetValue(view, workPermitModelPropertyValue, null);
                    }
                }
            }
        }

        public void ToModel(object view, object domainObject, Version viewVersion)
        {
            string groupAlias = GetGroupAlias(domainObject);
            List<PropertyInfoWithAttribute> propertiesForSite = GetOrderedPropertiesForSite(domainObject, siteId);
            foreach (PropertyInfoWithAttribute propertyForSite in propertiesForSite)
            {
                WorkPermitAttribute workPermitAttribute = propertyForSite.Attribute;
                if (workPermitAttribute.IsGroup)
                {
                    object group = propertyForSite.PropertyInfo.GetValue(domainObject, null);
                    ToModel(view, group, viewVersion);
                }

                else
                {
                    object valueToSetOnModel = null;
                    bool shouldSetValueOnModelFromView = true;

                    if (workPermitAttribute.HasPreSetterProperty)
                    {
                        string preSetterProperty = workPermitAttribute.PreSetterProperty;
                        bool shouldNegatePreSetterCondition = false;
                        if (preSetterProperty.StartsWith("!"))
                        {
                            preSetterProperty = preSetterProperty.Substring(1);
                            shouldNegatePreSetterCondition = true;
                        }

                        PropertyInfo pInfo = domainObject.GetType().GetProperty(preSetterProperty);
                        if (pInfo == null)
                        {
                            throw new WorkPermitBinderException(
                                String.Format("Could not find pre-setter property '{0}' on '{1}'.", preSetterProperty,
                                              domainObject.GetType().Name));
                        }

                        var pValue = (bool) pInfo.GetValue(domainObject, null);
                        if (shouldNegatePreSetterCondition)
                        {
                            pValue = !pValue;
                        }

                        if (pValue == false)
                        {
                            Type domainObjectPropertyType = propertyForSite.PropertyInfo.PropertyType;
                            // Default bool to false.
                            if (typeof (bool) == domainObjectPropertyType)
                            {
                                valueToSetOnModel = false;
                            }

                            // Default nullable bool to false.
                            else if (domainObjectPropertyType.IsGenericType &&
                                     domainObjectPropertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
                            {
                                if (typeof (bool) == domainObjectPropertyType.GetGenericArguments()[0])
                                {
                                    valueToSetOnModel = false;
                                }
                            }
                            // All other types, will default to null.  This needs to be expanded to accomodate other types that are not nullable.
                            shouldSetValueOnModelFromView = false;
                        }
                    }

                    if (shouldSetValueOnModelFromView)
                    {
                        string propertyName = groupAlias + propertyForSite.PropertyInfo.Name;
                        PropertyInfo viewProperty = view.GetType().GetProperty(propertyName);
                        if (viewProperty == null)
                        {
                            if (propertyForSite.Attribute.Version == viewVersion)
                            {
                                throw new WorkPermitBinderException(String.Format(
                                    "Could not find property '{0}' on '{1}'.", propertyName, view.GetType().Name));
                            }
                        }
                        else
                        {
                            valueToSetOnModel = viewProperty.GetValue(view, null);                            
                        }
                    }
                    propertyForSite.PropertyInfo.SetValue(domainObject, valueToSetOnModel, null);
                }
            }
        }

        #endregion

        private static List<PropertyInfoWithAttribute> GetOrderedPropertiesForSite(object domainObject, long siteId)
        {
            var propertyInfoListWithAttribute = new List<PropertyInfoWithAttribute>();

            PropertyInfo[] properties = domainObject.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (object attribute in property.GetCustomAttributes(false))
                {
                    if (attribute is WorkPermitAttribute)
                    {
                        if (((WorkPermitAttribute) attribute).IsForSite(siteId))
                        {
                            propertyInfoListWithAttribute.Add(new PropertyInfoWithAttribute(property,
                                                                                            (WorkPermitAttribute)
                                                                                            attribute));
                        }
                    }
                }
            }

            propertyInfoListWithAttribute.Sort(prop => prop.Attribute, true);
            return propertyInfoListWithAttribute;
        }

        private static string GetGroupAlias(object domainObject)
        {
            AliasAttribute aliasAttribute = domainObject.GetType().GetAttribute<AliasAttribute>(false);
            return aliasAttribute == default(AliasAttribute) ? string.Empty : aliasAttribute.Alias;
        }

        #region Nested type: PropertyInfoWithAttribute

        private class PropertyInfoWithAttribute
        {
            private readonly WorkPermitAttribute attribute;
            private readonly PropertyInfo propertyInfo;

            public PropertyInfoWithAttribute(PropertyInfo propertyInfo, WorkPermitAttribute attribute)
            {
                this.propertyInfo = propertyInfo;
                this.attribute = attribute;
            }

            public WorkPermitAttribute Attribute
            {
                get { return attribute; }
            }

            public PropertyInfo PropertyInfo
            {
                get { return propertyInfo; }
            }
        }

        #endregion
    }
}