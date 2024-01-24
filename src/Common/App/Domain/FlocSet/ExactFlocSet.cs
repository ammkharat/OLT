using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.FlocSet
{
    [Serializable]
    public class ExactFlocSet : IFlocSet
    {
        private readonly List<FunctionalLocation> functionalLocations;

        public ExactFlocSet(List<FunctionalLocation> functionalLocations)
        {
            this.functionalLocations = functionalLocations;
        }

        public ExactFlocSet(FunctionalLocation functionalLocation)
            : this(new List<FunctionalLocation> {functionalLocation})
        {
        }

        public Site Site
        {
            get { return functionalLocations.Count > 0 ? functionalLocations[0].Site : null; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocations; }
        }

        public override string ToString()
        {
            return functionalLocations.FullHierarchyListToString(false, false);
        }
    }
}