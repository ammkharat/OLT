using System;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class GasTestElementInfoConfigurationHistory : GasTestElementInfoDTO, IHistorySnapshot
    {
        public GasTestElementInfoConfigurationHistory(long? id, string name, string coldLimit,
            string hotLimit, string cseLimit, string inertCSELimit,
            string unitName, bool isRangedLimit, int decimalPlaceCount,
            DateTime lastModifiedDateTime,
            User lastModifiedUser)
            : base(id, name, unitName, coldLimit, hotLimit, cseLimit, inertCSELimit, isRangedLimit, decimalPlaceCount)

        {
            LastModifiedDate = lastModifiedDateTime;
            LastModifiedBy = lastModifiedUser;
        }

        public GasTestElementInfoConfigurationHistory(string name, string coldLimit, string hotLimit, string cseLimit,
            string inertCSELimit, string unitName, bool isRangedLimit,
            int decimalPlaceCount, DateTime lastModifiedDateTime,
            User lastModifiedUser)
            : this(null, name, coldLimit, hotLimit, cseLimit, inertCSELimit, unitName,
                isRangedLimit, decimalPlaceCount, lastModifiedDateTime, lastModifiedUser)
        {
        }

        public GasTestElementInfoConfigurationHistory(GasTestElementInfoDTO dto, DateTime lastModifiedDateTime,
            User lastModifiedUser)
            : this(
                dto.Id, dto.Name, dto.ColdLimit, dto.HotLimit, dto.CSELimit, dto.InertCSELimit, dto.UnitName,
                dto.IsRangedLimit, dto.DecimalPlaceCount, lastModifiedDateTime, lastModifiedUser)
        {
        }

        public DateTime LastModifiedDate { get; set; }

        public User LastModifiedBy { get; set; }
    }
}