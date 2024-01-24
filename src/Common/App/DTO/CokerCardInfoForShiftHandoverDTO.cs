using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class CokerCardInfoForShiftHandoverDTO
    {
        public CokerCardInfoForShiftHandoverDTO(List<CokerCardDrumEntryDTO> drumEntryDtos)
        {
            DrumEntryDtos = drumEntryDtos;
        }

        public List<CokerCardDrumEntryDTO> DrumEntryDtos { get; private set; }
    }
}