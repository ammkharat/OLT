using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class FunctionalLocationInfo
    {
        private readonly FunctionalLocation floc;
        private readonly bool hasChildren;

        public FunctionalLocationInfo(FunctionalLocation floc, bool hasChildren)
        {
            this.floc = floc;
            this.hasChildren = hasChildren;
        }

        public FunctionalLocation Floc
        {
            get { return floc; }
        }

        public bool HasChildren
        {
            get { return hasChildren; }
        }
    }
}