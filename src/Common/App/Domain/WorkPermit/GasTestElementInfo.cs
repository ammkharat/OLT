using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GasTestElementInfo : DomainObject, ICacheBySiteId
    {
        private const int DISPLAY_ORDER_NOT_APPLICABLE = -1;
        public const int DECIMAL_PLACE_COUNT_NOT_APPLICABLE = -1;

        public const int OXYGEN_DECIMAL_PLACE_COUNT = 1;
        public const int NON_OXYGEN_DECIMAL_PLACE_COUNT = 2;

        private readonly int decimalPlaceCount;
        private readonly int displayOrder;
        private readonly bool isRangedLimit;
        private readonly bool isStandard;

        private GasLimitRange coldLimit;
        private GasLimitRange cseLimit;
        private GasLimitRange hotLimit;
        private GasLimitRange inertCSELimit;
        private string name;
        private string otherLimits;

        public GasTestElementInfo
            (
            long? id,
            string name,
            Site site,
            bool isStandard,
            int displayOrder,
            GasLimitRange coldLimit,
            GasLimitRange hotLimit,
            GasLimitRange cseLimit,
            GasLimitRange inertCSELimit,
            string otherLimits,
            GasLimitUnit unit,
            bool isRangedLimit,
            int decimalPlaceCount
            )
        {
            this.id = id;
            this.name = name;
            Site = site;
            this.isStandard = isStandard;
            this.displayOrder = displayOrder;

            this.coldLimit = coldLimit;
            this.hotLimit = hotLimit;
            this.cseLimit = cseLimit;
            this.inertCSELimit = inertCSELimit;
            this.otherLimits = otherLimits;

            Unit = unit;
            this.isRangedLimit = isRangedLimit;
            this.decimalPlaceCount = decimalPlaceCount;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        ///     Tests whether this is a standard element (like oxygen, ammonia, etc...).
        /// </summary>
        public bool IsStandard
        {
            get { return isStandard; }
        }

        public Site Site { get; set; }

        public int DisplayOrder
        {
            get { return displayOrder; }
        }

        public GasLimitRange ColdLimit
        {
            get { return coldLimit; }
            set { coldLimit = value; }
        }

        public GasLimitRange HotLimit
        {
            get { return hotLimit; }
            set { hotLimit = value; }
        }

        public GasLimitRange CSELimit
        {
            get { return cseLimit; }
            set { cseLimit = value; }
        }

        public GasLimitRange InertCSELimit
        {
            get { return inertCSELimit; }
            set { inertCSELimit = value; }
        }

        public string OtherLimits
        {
            get { return otherLimits; }
            set { otherLimits = value; }
        }

        public GasLimitUnit Unit { get; set; }

        public bool IsRangedLimit
        {
            get { return isRangedLimit; }
        }

        public int DecimalPlaceCount
        {
            get { return decimalPlaceCount; }
        }

        [IgnoreToString]
        public long SiteId
        {
            get { return Site.IdValue; }
        }

        public static GasTestElementInfo CreateOtherGasTestElementInfo(Site site)
        {
            return new GasTestElementInfo
                (
                null,
                string.Empty,
                site,
                false,
                DISPLAY_ORDER_NOT_APPLICABLE,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                string.Empty,
                GasLimitUnit.UNKNOWN,
                false,
                DECIMAL_PLACE_COUNT_NOT_APPLICABLE
                );
        }

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

        public static GasTestElementInfo CreateOtherGasTestElementInfo_Other(Site site)
        {
            return new GasTestElementInfo
                (
                null,
                string.Empty,
                site,
                false,
                DISPLAY_ORDER_NOT_APPLICABLE,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                GasLimitRange.EmptyLimitRange,
                string.Empty,
                GasLimitUnit.UNKNOWN,
                false,
                DECIMAL_PLACE_COUNT_NOT_APPLICABLE
                );
        }

        //END

        public GasLimitRange GetLimitRange(WorkPermitType workPermitType, WorkPermitAttributes attributes)
        {
            GasLimitRange permitBasedRange;
            if (workPermitType == WorkPermitType.HOT)
            {
                permitBasedRange = HotLimit;
            }
            else if (workPermitType == WorkPermitType.COLD)
            {
                permitBasedRange = ColdLimit;
            }
            else if (workPermitType == null)
            {
                permitBasedRange = GasLimitRange.EmptyLimitRange;
            }
            else
            {
                throw new ArgumentException("Unrecognized work permit type", workPermitType.Name);
            }

            permitBasedRange = attributes.IsConfinedSpaceEntry ? permitBasedRange.LowerOf(CSELimit) : permitBasedRange;
            permitBasedRange = attributes.IsInertConfinedSpaceEntry
                ? permitBasedRange.LowerOf(inertCSELimit)
                : permitBasedRange;

            return permitBasedRange;
        }

        /// <summary>
        ///     Makes a new copy (no ID) of this info if non-global;
        ///     otherwise, just returns this standard element info.
        /// </summary>
        public GasTestElementInfo Copy()
        {
            if (IsStandard)
            {
                return this;
            }

            var copy = (GasTestElementInfo) Clone();
            copy.Id = null;
            return copy;
        }

        /// <summary>
        ///     Tests if this part of the work permit has data (has been "filled out").
        /// </summary>
        public bool HasData()
        {
            if (isStandard == false &&
                (name.HasValue() || otherLimits.HasValue())
                )
            {
                return true;
            }

            return coldLimit != GasLimitRange.EmptyLimitRange ||
                   hotLimit != GasLimitRange.EmptyLimitRange ||
                   cseLimit != GasLimitRange.EmptyLimitRange ||
                   inertCSELimit != GasLimitRange.EmptyLimitRange;
        }
    }
}