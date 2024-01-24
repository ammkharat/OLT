using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.Excursions
{
    [Serializable]
    public class OpmTagValueDTO : DomainObject
    {
        public OpmTagValueDTO(long id, string description, string quality, DateTime? timeStamp, string units,
            decimal? value) : base(id)
        {
            Description = description;
            Quality = quality;
            TimeStamp = timeStamp;
            Units = units;
            Value = value;
        }

        public string Description { get; set; }
        public string Quality { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Units { get; set; }
        public decimal? Value { get; set; }
    }
}