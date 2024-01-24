using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Remote.Integration;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class OpmTagValueToOpmTagValueDTOConverter
    {
        public OpmTagValueDTO ConvertToOpmTagValueDTO(OPMTagValue opmTagValue)
        {
            var tagValueDto = BuildOpmTagValueDto(opmTagValue);

            return tagValueDto;
        }

        private OpmTagValueDTO BuildOpmTagValueDto(OPMTagValue opmTagValue)
        {
            long id = 0;

            var tagValueDto = new OpmTagValueDTO(id,
                opmTagValue.Description,
                opmTagValue.Quality,
                opmTagValue.TimeStamp,
                opmTagValue.Units,
                opmTagValue.Value);

            return tagValueDto;
        }
    }
}