using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.FlocSet
{
    [Serializable]
    public class SectionOnlyFlocSet : IFlocSet
    {
        private readonly List<FunctionalLocation> functionalLocations;

        public SectionOnlyFlocSet(List<FunctionalLocation> functionalLocations)
        {
            this.functionalLocations = functionalLocations;

            if (AssemblyUtil.IsDebugMode())
            {
                if (functionalLocations.Exists(floc => floc.Type != FunctionalLocationType.Level2))
                {
                    throw new OLTException("Expected FLOCs to be Section only.");
                }
            }
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