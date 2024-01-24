using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class CokerCardReportAdapter : AbstractLocalizedReportAdapter
    {
        private readonly CokerCardDrumEntryDTO drumEntryDTO;
        private readonly string handoverparentId;

        private CokerCardReportAdapter(string handoverparentId, CokerCardDrumEntryDTO drumEntryDTO)
        {
            this.handoverparentId = handoverparentId;
            this.drumEntryDTO = drumEntryDTO;
        }

        public string ParentId
        {
            get { return handoverparentId; }
        }

        public string DrumName
        {
            get { return drumEntryDTO.DrumName; }
        }

        public string Hours
        {
            get
            {
                return drumEntryDTO.HoursIntoCycle == default(decimal)
                    ? string.Empty
                    : drumEntryDTO.HoursIntoCycle.ToString();
            }
        }

        public string CycleStepName
        {
            get { return drumEntryDTO.CycleStepName; }
        }

        public string Comments
        {
            get { return drumEntryDTO.Comments; }
        }

        public string CokerCardName
        {
            get { return drumEntryDTO.CokerCardName; }
        }

        public static IEnumerable<CokerCardReportAdapter> GetDrumEntries(long handoverId,
            List<CokerCardDrumEntryDTO> drumEntries)
        {
            return
                drumEntries.ConvertAll(
                    de => new CokerCardReportAdapter(handoverId.ToString(CultureInfo.InvariantCulture), de));
        }
    }
}