using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class CheckableFunctionalLocationGridDisplayAdapter
    {
        private readonly FunctionalLocation functionalLocation;

        public CheckableFunctionalLocationGridDisplayAdapter(FunctionalLocation functionalLocation)
        {
            this.functionalLocation = functionalLocation;
        }

        public string FunctionalLocationName
        {
            get { return functionalLocation.FullHierarchyWithDescription; }
        }

        public bool Checked { get; set; }

        // this is a method instead of property so that grid doesn't pick it up
        public FunctionalLocation GetFunctionalLocation()
        {
            return functionalLocation;
        }
    }
}
