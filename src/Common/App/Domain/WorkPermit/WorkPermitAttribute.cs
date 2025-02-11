﻿using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class WorkPermitAttribute : Attribute, IComparable, IComparable<WorkPermitAttribute>
    {
        public enum Classification
        {
            Property,
            Group
        }

        public enum Ordering
        {
            FirstSet,
            SecondSet,
            ThirdSet,
            FourthSet,
            LastSet
        }

        private readonly Classification classification;
        private readonly Ordering order;
        private readonly long siteId;
        private readonly Version version = Constants.CURRENT_VERSION;

        protected WorkPermitAttribute(long siteId, Classification classification, Ordering order,
            string preSetterProperty, Version version)
        {
            this.siteId = siteId;
            this.classification = classification;
            this.order = order;
            PreSetterProperty = preSetterProperty;
            this.version = version;
        }

        public bool IsGroup
        {
            get { return classification == Classification.Group; }
        }

        public string PreSetterProperty { get; private set; }

        public bool HasPreSetterProperty
        {
            get { return PreSetterProperty != null; }
        }

        public Version Version
        {
            get { return version; }
        }

        public int CompareTo(object obj)
        {
            if (obj is WorkPermitAttribute)
            {
                return order - ((WorkPermitAttribute) obj).order;
            }
            throw new ArgumentException(String.Format("{0} is not a WorkPermitAttribute. Not comparable.", obj));
        }

        public int CompareTo(WorkPermitAttribute other)
        {
            return order - other.order;
        }

        public bool IsForSite(long desiredSiteId)
        {
            return siteId == desiredSiteId;
        }

        public bool Equals(WorkPermitAttribute obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return base.Equals(obj) && obj.siteId == siteId && Equals(obj.classification, classification) &&
                   Equals(obj.order, order) && Equals(obj.PreSetterProperty, PreSetterProperty);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as WorkPermitAttribute);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = base.GetHashCode();
                result = (result*397) ^ siteId.GetHashCode();
                result = (result*397) ^ classification.GetHashCode();
                result = (result*397) ^ order.GetHashCode();
                result = (result*397) ^ (PreSetterProperty != null ? PreSetterProperty.GetHashCode() : 0);
                return result;
            }
        }
    }

    public class SarniaWorkPermitAttribute : WorkPermitAttribute
    {
        public SarniaWorkPermitAttribute(string preSetterProperty)
            : base(
                Site.SARNIA_ID, Classification.Property, Ordering.LastSet, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public SarniaWorkPermitAttribute(string versionString, string preSetterProperty)
            : base(
                Site.SARNIA_ID, Classification.Property, Ordering.LastSet, preSetterProperty, new Version(versionString)
                )
        {
        }

        public SarniaWorkPermitAttribute(Ordering order)
            : base(Site.SARNIA_ID, Classification.Property, order, null, Constants.CURRENT_VERSION)
        {
        }

        public SarniaWorkPermitAttribute(string versionString, Ordering order)
            : base(Site.SARNIA_ID, Classification.Property, order, null, new Version(versionString))
        {
        }

        public SarniaWorkPermitAttribute(Classification classification)
            : base(Site.SARNIA_ID, classification, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }

        public SarniaWorkPermitAttribute(Classification classification, Ordering order)
            : base(Site.SARNIA_ID, classification, order, null, Constants.CURRENT_VERSION)
        {
        }

        public SarniaWorkPermitAttribute(Ordering order, string preSetterProperty)
            : base(Site.SARNIA_ID, Classification.Property, order, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public SarniaWorkPermitAttribute()
            : base(Site.SARNIA_ID, Classification.Property, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }
    }

    //mangesh USPipeline to SELC
    public class SELCWorkPermitAttribute : WorkPermitAttribute
    {
        public SELCWorkPermitAttribute(string preSetterProperty)
            : base(
                Site.SELC_ID, Classification.Property, Ordering.LastSet, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public SELCWorkPermitAttribute(string versionString, string preSetterProperty)
            : base(
                Site.SELC_ID, Classification.Property, Ordering.LastSet, preSetterProperty, new Version(versionString)
                )
        {
        }

        public SELCWorkPermitAttribute(Ordering order)
            : base(Site.SELC_ID, Classification.Property, order, null, Constants.CURRENT_VERSION)
        {
        }

        public SELCWorkPermitAttribute(string versionString, Ordering order)
            : base(Site.SELC_ID, Classification.Property, order, null, new Version(versionString))
        {
        }

        public SELCWorkPermitAttribute(Classification classification)
            : base(Site.SELC_ID, classification, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }

        public SELCWorkPermitAttribute(Classification classification, Ordering order)
            : base(Site.SELC_ID, classification, order, null, Constants.CURRENT_VERSION)
        {
        }

        public SELCWorkPermitAttribute(Ordering order, string preSetterProperty)
            : base(Site.SELC_ID, Classification.Property, order, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public SELCWorkPermitAttribute()
            : base(Site.SELC_ID, Classification.Property, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }
    }


    //ayman USPipeline workpermit
    public class USPipelineWorkPermitAttribute : WorkPermitAttribute
    {
        public USPipelineWorkPermitAttribute(string preSetterProperty)
            : base(
                Site.USPipeline_ID, Classification.Property, Ordering.LastSet, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public USPipelineWorkPermitAttribute(string versionString, string preSetterProperty)
            : base(
                Site.USPipeline_ID, Classification.Property, Ordering.LastSet, preSetterProperty, new Version(versionString)
                )
        {
        }

        public USPipelineWorkPermitAttribute(string versionString, Ordering order)
            : base(Site.USPipeline_ID, Classification.Property, order, null, new Version(versionString))
        {
        }

        public USPipelineWorkPermitAttribute(Ordering order)
            : base(Site.USPipeline_ID, Classification.Property, order, null, Constants.CURRENT_VERSION)
        {
        }

        public USPipelineWorkPermitAttribute(Classification classification)
            : base(Site.USPipeline_ID, classification, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }

        public USPipelineWorkPermitAttribute(Classification classification, Ordering order)
            : base(Site.USPipeline_ID, classification, order, null, Constants.CURRENT_VERSION)
        {
        }

        public USPipelineWorkPermitAttribute(Ordering order, string preSetterProperty)
            : base(Site.USPipeline_ID, Classification.Property, order, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public USPipelineWorkPermitAttribute()
            : base(Site.USPipeline_ID, Classification.Property, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }
    }


    public class DenverWorkPermitAttribute : WorkPermitAttribute
    {
        public DenverWorkPermitAttribute(string preSetterProperty)
            : base(
                Site.DENVER_ID, Classification.Property, Ordering.LastSet, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public DenverWorkPermitAttribute(string versionString, string preSetterProperty)
            : base(
                Site.DENVER_ID, Classification.Property, Ordering.LastSet, preSetterProperty, new Version(versionString)
                )
        {
        }

        public DenverWorkPermitAttribute(string versionString, Ordering order)
            : base(Site.DENVER_ID, Classification.Property, order, null, new Version(versionString))
        {
        }

        public DenverWorkPermitAttribute(Ordering order)
            : base(Site.DENVER_ID, Classification.Property, order, null, Constants.CURRENT_VERSION)
        {
        }

        public DenverWorkPermitAttribute(Classification classification)
            : base(Site.DENVER_ID, classification, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }

        public DenverWorkPermitAttribute(Classification classification, Ordering order)
            : base(Site.DENVER_ID, classification, order, null, Constants.CURRENT_VERSION)
        {
        }

        public DenverWorkPermitAttribute(Ordering order, string preSetterProperty)
            : base(Site.DENVER_ID, Classification.Property, order, preSetterProperty, Constants.CURRENT_VERSION)
        {
        }

        public DenverWorkPermitAttribute()
            : base(Site.DENVER_ID, Classification.Property, Ordering.LastSet, null, Constants.CURRENT_VERSION)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        private readonly string alias;

        public AliasAttribute(string alias)
        {
            this.alias = alias;
        }

        public string Alias
        {
            get { return alias; }
        }
    }
}