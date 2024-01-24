using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DocumentRootUncPath : DomainObject
    {
        public DocumentRootUncPath(string pathName, string uncPath, List<FunctionalLocation> firstLevelFlocs)
        {
            PathName = pathName;
            Path = uncPath;
            FirstLevelFunctionalLocations = firstLevelFlocs;
        }

        public List<FunctionalLocation> FirstLevelFunctionalLocations { get; set; }

        public string Path { get; set; }

        public string PathName { get; set; }

        // Used by Grid Renderer.
        public string FirstLevelFunctionalLocationsAsString
        {
            get { return FirstLevelFunctionalLocations.FullHierarchyListToString(false, true); }
        }
    }
}