using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public enum FunctionalLocationType
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Level6 = 6,
        Level7 = 7
    }

    [Serializable]
    public enum FunctionalLocationSource
    {
        SAP = 1,
        OLT = 2
    }

    [Serializable]
    public class FunctionalLocation : DomainObject
    {
        private static readonly List<FunctionalLocationType> typesHighestToLowest =
            new List<FunctionalLocationType>
            {
                FunctionalLocationType.Level1,
                FunctionalLocationType.Level2,
                FunctionalLocationType.Level3,
                FunctionalLocationType.Level4,
                FunctionalLocationType.Level5,
                FunctionalLocationType.Level6,
                FunctionalLocationType.Level7
            };

        private FunctionalLocationHierarchy hierarchy;

        public FunctionalLocation(FunctionalLocation floc) : this(
            floc.Id,
            floc.Site,
            floc.FullHierarchy,
            floc.Description,
            floc.Deleted,
            floc.OutOfService,
            floc.PlantId,
            floc.Culture,
            floc.Source)
        {
        }

        public FunctionalLocation(long? id, Site site, string fullHierarchy, string description, bool deleted,
            bool outOfService, long plantId, string culture,
            FunctionalLocationSource source)
        {
            this.id = id;
            Site = site;
            hierarchy = new FunctionalLocationHierarchy(fullHierarchy);

            Description = description;
            Deleted = deleted;
            OutOfService = outOfService;
            PlantId = plantId;
            Culture = culture;
            Source = source;
        }

        public FunctionalLocation(Site site, string fullHierarchy, long plantId, string description, string culture)
        {
            Site = site;
            hierarchy = new FunctionalLocationHierarchy(fullHierarchy);
            PlantId = plantId;
            Description = description;

            Deleted = false;
            OutOfService = false;

            Culture = culture;

            Source = FunctionalLocationSource.SAP;
        }


        public Site Site { get; set; }

        public string Division
        {
            get { return hierarchy.Division; }
        }

        public string Section
        {
            get { return hierarchy.Section; }
        }

        public string Unit
        {
            get { return hierarchy.Unit; }
        }

        public string Equipment1
        {
            get { return hierarchy.Equipment1; }
        }

        public string Equipment2
        {
            get { return hierarchy.Equipment2; }
        }

        public long PlantId { get; private set; }

        public FunctionalLocationSource Source { get; private set; }

        public string FullHierarchyWithDescription
        {
            get { return GetFullHierarchyWithDescription(FullHierarchy, Description); }
        }

        public string FullHierarchy
        {
            get { return hierarchy.ToString(); }
            set { hierarchy = new FunctionalLocationHierarchy(value); }
        }

        public string ParentSectionFullHeirarchy
        {
            get
            {
                if (IsDivision)
                {
                    throw new Exception("A division does not have a parent section.");
                }
                return string.Format("{0}-{1}", Division, Section);
            }
        }

        public string Description { get; set; }

        public string Culture { get; set; }

        public bool Deleted { get; set; }

        public bool OutOfService { get; set; }

        public FunctionalLocationType Type
        {
            get { return hierarchy.Type; }
        }

        public bool IsDivision
        {
            get { return Type.Equals(FunctionalLocationType.Level1); }
        }

        public bool IsSection
        {
            get { return Type.Equals(FunctionalLocationType.Level2); }
        }

        public bool IsUnit
        {
            get { return Type.Equals(FunctionalLocationType.Level3); }
        }

        public FunctionalLocationHierarchy FunctionalLocationHierarchy
        {
            get { return hierarchy; }
        }

        public int Level
        {
            get { return hierarchy.Level; }
        }

        public static string GetFullHierarchyWithDescription(string fullHierarchy, string description)
        {
            return string.Format("{0} ({1})", fullHierarchy, description);
        }

        public static List<FunctionalLocationType> RangeOfTypes(FunctionalLocationType highest,
            FunctionalLocationType lowest)
        {
            var start = typesHighestToLowest.FindIndex(t => t == highest);
            var end = typesHighestToLowest.FindIndex(t => t == lowest);
            var count = (end - start) + 1;

            if (count < 0)
            {
                throw new ArgumentException(
                    string.Format("Cannot find a valid highest-to-lowest type range between:<{0}> and:<{1}>", highest,
                        lowest));
            }

            return typesHighestToLowest.GetRange(start, count);
        }

        public bool IsPartOfUnit(FunctionalLocation location)
        {
            if (location.Type != FunctionalLocationType.Level3)
            {
                throw new ArgumentException("Expected unit-level functional location but was:" + location.Type);
            }

            return Nullable.Equals(Site.Id, location.Site.Id) &&
                   string.Equals(Division, location.Division, StringComparison.Ordinal) &&
                   string.Equals(Section, location.Section, StringComparison.Ordinal) &&
                   string.Equals(Unit, location.Unit, StringComparison.Ordinal);
        }

        /// <summary>
        ///     Checks if another FunctionalLocation could be a child of this FunctionalLocation
        /// </summary>
        /// <param name="potentialChild"></param>
        /// <returns></returns>
        public bool IsParentOf(FunctionalLocation potentialChild)
        {
            return Level < potentialChild.Level &&
                   potentialChild.FullHierarchy.StartsWith(FullHierarchy, StringComparison.Ordinal);
        }

        public bool IsParentOf(string fullHierarchyOfPotentialChild, long siteIdOfPotentialChild)
        {
            if (Site.IdValue != siteIdOfPotentialChild)
                return false;

            return IsParentOf(FullHierarchy, fullHierarchyOfPotentialChild);
        }

        public bool IsParentOf(FunctionalLocationDTO dto, Site siteIdOfDto)
        {
            var fullHierarcy = dto.FullHierarcy;
            return IsParentOf(fullHierarcy, siteIdOfDto.IdValue);
        }

        public bool IsChildOf(FunctionalLocation potentialParent)
        {
            return IsChildOf(potentialParent.FullHierarchy, potentialParent.Site.IdValue);
        }

        public bool IsChildOf(string fullHierarchyOfPotentialParentFloc, long siteIdOfPotentialParentFloc)
        {
            if (Site.IdValue != siteIdOfPotentialParentFloc)
                return false;
            return IsParentOf(fullHierarchyOfPotentialParentFloc, FullHierarchy);
        }

        private bool IsParentOf(string fullHierarchy, string fullHierarchyOfPotentialChild)
        {
            var levelOfFloc = new FunctionalLocationHierarchy(fullHierarchy).Level;
            var levelOfPotentialChild = new FunctionalLocationHierarchy(fullHierarchyOfPotentialChild).Level;

            return levelOfFloc < levelOfPotentialChild &&
                   fullHierarchyOfPotentialChild.Length > fullHierarchy.Length &&
                   fullHierarchyOfPotentialChild.StartsWith(fullHierarchy, StringComparison.Ordinal);
        }

        public bool IsOrIsAncestorOfOrIsDescendantOf(FunctionalLocation otherFloc)
        {
            return Id == otherFloc.id ||
                   IsParentOf(otherFloc) ||
                   otherFloc.IsParentOf(this);
        }

        public override string ToString()
        {
            return FullHierarchyWithDescription;
        }
    }
}