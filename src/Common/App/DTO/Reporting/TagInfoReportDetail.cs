using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class TagInfoReportDetail : DomainObject
    {
        public TagInfoReportDetail(string name, string description, string unitName, decimal? value)
        {
            Name = name;
            Description = description;
            UnitName = unitName;
            Value = value;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string UnitName { get; private set; }

        public decimal? Value { get; private set; }

        public bool InvalidRead
        {
            get { return Value.HasValue; }
        }
    }
}