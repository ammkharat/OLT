using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Value object describing the hierarchy of a functional location.
    /// </summary>
    [Serializable]
    public class FunctionalLocationHierarchy
    {
        private readonly string fullHierarchy;

        public FunctionalLocationHierarchy(FunctionalLocation floc) :
            this(floc.FullHierarchy)
        {
        }

        public FunctionalLocationHierarchy(string fullHierarchy)
        {
            this.fullHierarchy = fullHierarchy;

            if (fullHierarchy == null)
                throw new ArgumentException("FullHierarchy cannot be null");

            PopulateParts(fullHierarchy);
        }

        public string Division { get; private set; }
        public string Section { get; private set; }
        public string Unit { get; private set; }
        public string Equipment1 { get; private set; }
        public string Equipment2 { get; private set; }
        public int Level { get; private set; }

        public FunctionalLocationHierarchy ParentHierarchy
        {
            get { return GetAncestorOrSelf(Level - 1); }
        }

        public string LastSegment
        {
            get
            {
                var segments = Split(fullHierarchy);
                return segments[segments.Length - 1];
            }
        }

        public FunctionalLocationType Type
        {
            get { return Level.ToEnum<FunctionalLocationType>(); }
        }

        private void PopulateParts(string fullhierarchy)
        {
            var hierarchySegments = Split(fullhierarchy);
            Level = hierarchySegments.Length;

            if (hierarchySegments.Length > 0)
                Division = hierarchySegments[0].TrimOrEmpty();

            if (hierarchySegments.Length > 1)
                Section = hierarchySegments[1].TrimOrEmpty();

            if (hierarchySegments.Length > 2)
                Unit = hierarchySegments[2].TrimOrEmpty();

            if (hierarchySegments.Length > 3)
                Equipment1 = hierarchySegments[3].TrimOrEmpty();

            if (hierarchySegments.Length > 4)
                Equipment2 = hierarchySegments[4].TrimOrEmpty();
        }

        private static string[] Split(string fullhierarchy)
        {
            return fullhierarchy.Split('-');
        }

        public FunctionalLocationHierarchy ReplaceSegment(int levelToReplaceAt, string replacementValue)
        {
            if (Level < levelToReplaceAt)
                throw new OLTException(string.Format("cannot replace a segment at Level {0} for Floc {1}",
                    levelToReplaceAt, fullHierarchy));

            var flocParts = Split(fullHierarchy);
            flocParts[levelToReplaceAt - 1] = replacementValue;
            var newFullHierarchy = string.Join("-", flocParts);
            return new FunctionalLocationHierarchy(newFullHierarchy);
        }

        public FunctionalLocationHierarchy AppendSegment(string segment)
        {
            var newFullHierarchy = fullHierarchy.IsNullOrEmptyOrWhitespace() ? segment : fullHierarchy + "-" + segment;

            return new FunctionalLocationHierarchy(newFullHierarchy);
        }

        public FunctionalLocationHierarchy GetAncestorOrSelf(int level)
        {
            if (level > Level)
                throw new ArgumentException(string.Format("Cannot get ancestor or self at Level {0} for Floc {1}.",
                    level, fullHierarchy));

            if (level == Level)
                return this.DeepClone();


            var segments = Split(fullHierarchy);
            var ancestorSegments = segments.Take(level);
            var newFullHierarchy = string.Join("-", ancestorSegments.ToArray());

            return new FunctionalLocationHierarchy(newFullHierarchy);
        }

        public static FunctionalLocationHierarchy LongestMatchingHierarchy(List<FunctionalLocationHierarchy> hierarchies)
        {
            var splitHierarchies = hierarchies.ConvertAll(hierarchy => Split(hierarchy.ToString()));

            FunctionalLocationHierarchy newHierarchy = null;
            var minLength = splitHierarchies.Min(x => x.Length);
            string[] firstSplitHierarchy = null;
            if (minLength > 0)
            {
                firstSplitHierarchy = splitHierarchies[0];
            }

            for (var i = 0; i < minLength; i++)
            {
                if (splitHierarchies.TrueForAll(splitHierarchy => splitHierarchy[i] == firstSplitHierarchy[i]))
                {
                    if (newHierarchy == null)
                    {
                        newHierarchy = new FunctionalLocationHierarchy(firstSplitHierarchy[i]);
                    }
                    else
                    {
                        newHierarchy = newHierarchy.AppendSegment(firstSplitHierarchy[i]);
                    }
                }
                else
                {
                    break;
                }
            }

            return newHierarchy;
        }

        public override bool Equals(object obj)
        {
            var that = (FunctionalLocationHierarchy) obj;

            return fullHierarchy == that.fullHierarchy;
        }

        public override int GetHashCode()
        {
            return fullHierarchy.GetHashCode();
        }

        public override string ToString()
        {
            return fullHierarchy;
        }
    }
}