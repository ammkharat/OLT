using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Collection of functional locations, providing fast access to functional locations by
    ///     hierarchy type (eg. a unit), or by parent functional location.
    /// </summary>
    public class FunctionalLocationCollection
    {
        private readonly FlocsByParent flocsByParent = new FlocsByParent();
        private readonly FlocsByType flocsByType = new FlocsByType();

        public FunctionalLocationCollection(IEnumerable<FunctionalLocation> flocs)
            : this(new List<FunctionalLocation>(flocs))
        {
        }

        public FunctionalLocationCollection(List<FunctionalLocation> flocs)
        {
            flocs.ForEach(floc =>
            {
                flocsByType.Add(floc);
                flocsByParent.Add(floc);
            });
        }

        public List<FunctionalLocation> this[FunctionalLocationType type]
        {
            get { return flocsByType.GetByType(type); }
        }

        public List<FunctionalLocation> GetChildren(FunctionalLocation parentFloc)
        {
            return flocsByParent.GetChildren(parentFloc);
        }

        /// <summary>
        ///     Groups functional locations by their parent functional locations.
        /// </summary>
        private class FlocsByParent
        {
            private readonly IDictionary<FunctionalLocationHierarchy, List<FunctionalLocation>> flocsByParent =
                new Dictionary<FunctionalLocationHierarchy, List<FunctionalLocation>>();

            public void Add(FunctionalLocation functionalLocation)
            {
                var parentHierarchy = functionalLocation.FunctionalLocationHierarchy.ParentHierarchy;

                if (flocsByParent.ContainsKey(parentHierarchy) == false)
                {
                    flocsByParent[parentHierarchy] = new List<FunctionalLocation>();
                }

                flocsByParent[parentHierarchy].Add(functionalLocation);
            }

            public List<FunctionalLocation> GetChildren(FunctionalLocation parentFloc)
            {
                var parentHierarchy = parentFloc.FunctionalLocationHierarchy;

                return flocsByParent.ContainsKey(parentHierarchy)
                    ? flocsByParent[parentHierarchy]
                    : new List<FunctionalLocation>(0);
            }
        }

        /// <summary>
        ///     Groups functional locations by their types.
        /// </summary>
        private class FlocsByType
        {
            private readonly IDictionary<FunctionalLocationType, List<FunctionalLocation>> flocsByType;

            public FlocsByType()
            {
                flocsByType = new Dictionary<FunctionalLocationType, List<FunctionalLocation>>();

                ForEachEnumValue((FunctionalLocationType type) => flocsByType[type] = new List<FunctionalLocation>());
            }

            public void Add(FunctionalLocation functionalLocation)
            {
                flocsByType[functionalLocation.Type].Add(functionalLocation);
            }

            public List<FunctionalLocation> GetByType(FunctionalLocationType type)
            {
                return flocsByType[type];
            }

            private static void ForEachEnumValue<T>(Action<T> action)
            {
                Array.ForEach((T[]) Enum.GetValues(typeof (T)), action);
            }
        }
    }
}