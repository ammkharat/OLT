using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.FlocSet
{
    [Serializable]
    public class RootFlocSet : IFlocSet
    {
        private readonly List<FunctionalLocation> flocs;

        public RootFlocSet(List<FunctionalLocation> functionalLocations)
        {
            flocs = functionalLocations.GetRoots();
        }

        public RootFlocSet(params FunctionalLocation[] flocs) : this(new List<FunctionalLocation>(flocs))
        {
        }

        public RootFlocSet(FunctionalLocation functionalLocation)
            : this(new List<FunctionalLocation> {functionalLocation})
        {
        }

        public List<FunctionalLocation> Flocs
        {
            get { return flocs; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return Flocs; }
        }

        public Site Site
        {
            get { return flocs.Count > 0 ? flocs[0].Site : null; }
        }

        public override string ToString()
        {
            return flocs.FullHierarchyListToString(false, false);
        }
    }
}