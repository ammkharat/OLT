using System;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class CokerCardDrumEntryDTO
    {
        public CokerCardDrumEntryDTO(long cokerCardConfigurationId, string cokerCardName, string drumName,
            string cycleStepName, decimal hoursIntoCycle, string comments)
        {
            CokerCardConfigurationId = cokerCardConfigurationId;
            CokerCardName = cokerCardName;
            DrumName = drumName;
            CycleStepName = cycleStepName ?? string.Empty;
            HoursIntoCycle = hoursIntoCycle;
            Comments = comments ?? string.Empty;
        }

        public long CokerCardConfigurationId { get; private set; }
        public string CokerCardName { get; private set; }
        public string DrumName { get; private set; }
        public string CycleStepName { get; private set; }
        public decimal HoursIntoCycle { get; private set; }
        public string Comments { get; private set; }
    }
}