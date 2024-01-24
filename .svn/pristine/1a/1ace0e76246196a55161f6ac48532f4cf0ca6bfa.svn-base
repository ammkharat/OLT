using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FunctionalLocationSegmentDTO
    {
        private readonly string division;
        private readonly string section;
        private readonly string unit;

        public FunctionalLocationSegmentDTO(FunctionalLocationHierarchy hierarchy)
        {
            division = hierarchy.Division.NullToEmpty();
            section = hierarchy.Section.NullToEmpty();
            unit = hierarchy.Unit.NullToEmpty();
        }

        public FunctionalLocationSegmentDTO(string division, string section, string unit)
        {
            this.division = division;
            this.section = section;
            this.unit = unit;
        }

        public string Division
        {
            get { return division; }
        }

        public string Section
        {
            get { return section; }
        }

        public string Unit
        {
            get { return unit; }
        }

        public string SectionFullHierarchy
        {
            get { return String.Format("{0}-{1}", Division, Section); }
        }

        public string UnitFullHierarchyOrSectionFullHierachyIfOnlySectionExists
        {
            get
            {
                if (!string.IsNullOrEmpty(unit))
                {
                    return String.Format("{0}-{1}", SectionFullHierarchy, Unit);
                }
                return SectionFullHierarchy;
            }
        }
    }
}