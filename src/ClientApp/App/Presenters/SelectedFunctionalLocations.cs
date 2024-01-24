using System.Collections.Generic;
using System.Collections.ObjectModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility.Comparer;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SelectedFunctionalLocations
    {
        private readonly HashSet<FunctionalLocation> selectedFlocs;

        public SelectedFunctionalLocations()
            : this(new List<FunctionalLocation>(0))
        {
        }

        public SelectedFunctionalLocations(IEnumerable<FunctionalLocation> functionalLocations)
        {
            selectedFlocs = new HashSet<FunctionalLocation>(functionalLocations, new DomainObjectIdEqualityComparer<FunctionalLocation>());
        }

        public ReadOnlyCollection<FunctionalLocation> ToReadOnlyList
        {
            get { return new List<FunctionalLocation>(selectedFlocs).AsReadOnly(); }
        }

        public void AddSelectedFunctionalLocation(FunctionalLocation functionalLocation)
        {
            selectedFlocs.RemoveWhere(functionalLocation.IsParentOf);
            selectedFlocs.Add(functionalLocation);
        }

        public void RemoveSelectedFunctionalLocation(FunctionalLocation floc)
        {
            selectedFlocs.Remove(floc);
        }

        public bool Has(FunctionalLocation floc)
        {
            return selectedFlocs.Contains(floc);
        }
    }
}