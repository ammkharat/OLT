using System;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class EventExcursionReportAdapter : AbstractLocalizedReportAdapter
    {
        private readonly OpmExcursionResponseDTO excursionResponseDTO;
        private readonly string parentId;

        public EventExcursionReportAdapter(string parentId, OpmExcursionResponseDTO excursionResponseDTO)
        {
            this.parentId = parentId;
            this.excursionResponseDTO = excursionResponseDTO;
        }

        public string ParentId
        {
            get { return parentId; }
        }

        public string ToeName
        {
            get { return excursionResponseDTO.ToeName; }
        }

        public string Status
        {
            get { return excursionResponseDTO.Status.GetName(); }
        }

        public string FunctionalLocation
        {
            get { return excursionResponseDTO.FunctionalLocation; }
        }


        public string StartTime
        {
            get { return string.Format("{0}", excursionResponseDTO.StartDateTime.ToShortDateAndTimeString()); }

        }
        public DateTime StartDateTime
        {
            get { return  excursionResponseDTO.StartDateTime; }
        }

        public string Type
        {
            get { return excursionResponseDTO.ToeType.GetName(); }
        }

        public string CauseActionRoadblock
        {
            get { return excursionResponseDTO.OltOperatorResponse; }
        }
    }
}