using System.Globalization;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Reports.Adapters
{
    public class FunctionalLocationReportAdapter
    {
        private readonly string functionalLocationName;
        private readonly long parentId;

        public FunctionalLocationReportAdapter(FunctionalLocation functionalLocation) : this(-1, functionalLocation)
        {
        }

        public FunctionalLocationReportAdapter(long parentId, FunctionalLocation functionalLocation)
        {
            this.parentId = parentId;
            functionalLocationName = functionalLocation.FullHierarchyWithDescription;
        }

        public FunctionalLocationReportAdapter(long parentId, string functionalLocationName)
        {
            this.parentId = parentId;
            this.functionalLocationName = functionalLocationName;
        }

        public string ParentId
        {
            get { return parentId.ToString(CultureInfo.InvariantCulture); }
        }

        public long ParentIdAsNumber
        {
            get { return parentId; }
        }

        public string FunctionalLocation
        {
            get { return functionalLocationName; }
        }
    }
}