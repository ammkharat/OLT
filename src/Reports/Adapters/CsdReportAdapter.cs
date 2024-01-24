using System;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class CsdReportAdapter : AbstractLocalizedReportAdapter
    {
        private readonly LubesCsdFormDTO csdDto;
        private readonly string parentId;

        public CsdReportAdapter(string parentId, LubesCsdFormDTO csdDto)
        {
            this.parentId = parentId;
            this.csdDto = csdDto;
        }

        public string ParentId
        {
            get { return parentId; }
        }

        public string FormNumber
        {
            get { return string.Format("{0}", csdDto.FormNumber); }
        }

        public string Status
        {
            get { return csdDto.Status.GetName(); }
        }

        public string FunctionalLocation
        {
            get { return csdDto.FunctionalLocationName; }
        }

        public string CriticalSystemDefeated
        {
            get { return csdDto.CriticalSystemDefeated.Truncate(300, StringResources.Truncated); }
        }

        public string SystemDefeatedDate
        {
            get { return string.Format("{0}", csdDto.ValidFrom.ToDateString()); }
        }

        public DateTime SystemDefeatedDateRawDateTime
        {
            get { return csdDto.ValidFrom; }
        }

        public string EstimatedBackInServiceDate
        {
            get { return string.Format("{0}", csdDto.ValidTo.ToDateString()); }
        }

        public DateTime EstimatedBackInServiceDateRawDateTime
        {
            get { return csdDto.ValidTo; }
        }
    }
}