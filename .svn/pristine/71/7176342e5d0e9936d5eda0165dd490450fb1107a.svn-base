using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class OnPremisePersonnelShiftReportDTO : DomainObject
    {
        public OnPremisePersonnelShiftReportDTO(Range<DateTime> reportingPeriod,
            List<ShiftPattern> siteShifts,
            IList<OnPremisePersonnelShiftReportDetailDTO> onPremisePersonnelShiftReportDetailDtOs)
        {
            ReportingPeriod = reportingPeriod;
            SiteShifts = siteShifts;
            OnPremisePersonnelShiftReportDetailDTOs = onPremisePersonnelShiftReportDetailDtOs;
        }

        public Range<DateTime> ReportingPeriod { get; private set; }
        public List<ShiftPattern> SiteShifts { get; private set; }

        public IList<OnPremisePersonnelShiftReportDetailDTO> OnPremisePersonnelShiftReportDetailDTOs { get; private set;
        }
    }
}