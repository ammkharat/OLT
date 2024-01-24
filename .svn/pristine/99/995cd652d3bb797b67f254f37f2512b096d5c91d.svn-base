using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    public class GasTestElementResultDTO : DomainObject
    {
        // TODO: Remove this constructor as they should use the one with all the params, just a first step.
        public GasTestElementResultDTO(string name, string limit, bool required,
            double? firstTestResult,
            double? confinedSpaceTestResult)
        {
            Name = name;
            Limit = limit;
            Required = required;
            FirstTestResult = firstTestResult;
            ConfinedSpaceTestResult = confinedSpaceTestResult;
        }

        public GasTestElementResultDTO(string name, string limit, bool required,
            double? firstTestResult, double? confinedSpaceTestResult, double? systemEntryTestResult)
            : this(name, limit, required, firstTestResult, confinedSpaceTestResult)
        {
            SystemEntryTestResult = systemEntryTestResult;
        }

        public string Name { get; private set; }
        public string Limit { get; private set; }
        public bool Required { get; private set; }
        public double? FirstTestResult { get; private set; }
        public double? ConfinedSpaceTestResult { get; private set; }
        public double? SystemEntryTestResult { get; private set; }
    }
}