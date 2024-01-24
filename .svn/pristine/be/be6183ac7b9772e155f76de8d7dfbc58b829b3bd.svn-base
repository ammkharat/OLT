using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class GasTestElementInfoDTO : DomainObject
    {
        private readonly int decimalPlaceCount;
        private readonly bool isRangedLimit;
        private readonly string name;

        private GasTestElementInfoDTO(GasTestElementInfo info)
            : this
                (
                info.Id,
                info.Name,
                info.Unit.UnitName,
                info.ColdLimit.ToLimitString(info.IsRangedLimit, info.DecimalPlaceCount),
                info.HotLimit.ToLimitString(info.IsRangedLimit, info.DecimalPlaceCount),
                info.CSELimit.ToLimitString(info.IsRangedLimit, info.DecimalPlaceCount),
                info.InertCSELimit.ToLimitString(info.IsRangedLimit, info.DecimalPlaceCount),
                info.IsRangedLimit,
                info.DecimalPlaceCount
                )
        {
        }

        public GasTestElementInfoDTO
            (
            long? id,
            string name,
            string unitName,
            string coldLimit,
            string hotLimit,
            string cseLimit,
            string inertCSELimit,
            bool isRangedLimit,
            int decimalPlaceCount
            )
        {
            this.id = id;
            this.name = name;
            UnitName = unitName;
            ColdLimit = coldLimit;
            HotLimit = hotLimit;
            CSELimit = cseLimit;
            InertCSELimit = inertCSELimit;
            this.isRangedLimit = isRangedLimit;
            this.decimalPlaceCount = decimalPlaceCount;
        }

        public string Name
        {
            get { return name; }
        }

        public string UnitName { get; set; }

        public string ColdLimit { get; set; }

        public string HotLimit { get; set; }

        public string CSELimit { get; set; }

        public string InertCSELimit { get; set; }

        public bool IsRangedLimit
        {
            get { return isRangedLimit; }
        }

        public int DecimalPlaceCount
        {
            get { return decimalPlaceCount; }
        }

        public static List<GasTestElementInfoDTO> CreateDTOList(List<GasTestElementInfo> infoList)
        {
            return infoList.ConvertAll(i => new GasTestElementInfoDTO(i));
        }

        public GasTestElementInfoConfigurationHistory TakeSnapshot(DateTime lastModifiedDateTime, User lastModifiedUser)
        {
            return new GasTestElementInfoConfigurationHistory(this, lastModifiedDateTime, lastModifiedUser);
        }
    }
}