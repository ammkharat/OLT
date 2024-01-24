using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Extension
{
    /// <summary>
    ///     All static methods that have to do with Lists of FunctionalLocations should go here.
    /// </summary>
    public static class FunctionalLocationListExtensions
    {
        private static readonly FunctionalLocationFullHierarchyComparer comparer =
            new FunctionalLocationFullHierarchyComparer();

        public static List<string> FullHierarchyList(this IList<FunctionalLocation> flocList, bool sortedByFullHierarchy)
        {
            var result = flocList.ConvertAll(floc => floc.FullHierarchy);
            if (sortedByFullHierarchy)
            {
                result.Sort((a, b) => string.Compare(a, b, StringComparison.InvariantCultureIgnoreCase));
            }
            return result;
        }

        public static string FullHierarchyListToString(this List<FunctionalLocation> flocs, bool sortedByFullHierarchy,
            bool includeDescription)
        {
            if (sortedByFullHierarchy)
            {
                flocs.Sort(comparer);
            }

            var flocsAsStrings = includeDescription
                ? flocs.ConvertAll(f => f.ToString())
                : flocs.ConvertAll(f => f.FullHierarchy);
            return flocsAsStrings.BuildCommaSeparatedList();
        }

        public static void SortByFullHierarchy(this List<FunctionalLocation> flocs)
        {
            flocs.Sort(comparer);
        }

        public static List<FunctionalLocation> CreateNewListSortedByFullHierarchy(this List<FunctionalLocation> flocs)
        {
            var sortedFlocs = new List<FunctionalLocation>(flocs);
            sortedFlocs.SortByFullHierarchy();
            return sortedFlocs;
        }

        public static List<FunctionalLocation> GetRoots(this List<FunctionalLocation> flocs)
        {
            var roots = new List<FunctionalLocation>();
            if (flocs == null)
            {
                return roots;
            }

            // finding potential parents and storing them in a dictionary is for performance purposes
            var potentialParentsDictionary = new Dictionary<FunctionalLocationType, List<FunctionalLocation>>();

            foreach (var potentialRoot in flocs)
            {
                List<FunctionalLocation> potentialParents;
                if (potentialParentsDictionary.ContainsKey(potentialRoot.Type))
                {
                    potentialParents = potentialParentsDictionary[potentialRoot.Type];
                }
                else
                {
                    potentialParents = flocs.FindAll(floc => floc.Type < potentialRoot.Type);
                    potentialParentsDictionary.Add(potentialRoot.Type, potentialParents);
                }

                // first make sure one of our known roots isn't the parent -- this is a performance boost
                if (!roots.Exists(floc => floc.IsParentOf(potentialRoot)))
                {
                    // if the floc doesn't have another floc as its parent
                    if (
                        potentialParents.DoesNotHave(
                            otherFloc => potentialRoot != otherFloc && otherFloc.IsParentOf(potentialRoot)))
                    {
                        roots.Add(potentialRoot);
                    }
                }
            }

            return roots;
        }

        public static List<string> DivisionFullHierarchies(this List<FunctionalLocation> functionalLocations)
        {
            return functionalLocations.ConvertAll(f => f.Division).Unique();
        }

        public static string FullHierarchyOfClosestAncestor(this List<FunctionalLocation> flocs)
        {
            var longestMatchingHierarchy =
                FunctionalLocationHierarchy.LongestMatchingHierarchy(
                    flocs.ConvertAll(floc => floc.FunctionalLocationHierarchy));
            return longestMatchingHierarchy == null ? null : longestMatchingHierarchy.ToString();
        }

        private class FunctionalLocationFullHierarchyComparer : IComparer<FunctionalLocation>
        {
            public int Compare(FunctionalLocation x, FunctionalLocation y)
            {
                var fullHierarchyX = x != null ? x.FullHierarchy : null;
                var fullHierarchyY = y != null ? y.FullHierarchy : null;

                return String.Compare(fullHierarchyX, fullHierarchyY, StringComparison.InvariantCultureIgnoreCase);
            }
        }
    }
}