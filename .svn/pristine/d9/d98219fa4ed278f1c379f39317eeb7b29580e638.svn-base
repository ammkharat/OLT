using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    public class AssignmentSectionUnitReportGroupBy : SortableSimpleDomainObject
    {
        public static AssignmentSectionUnitReportGroupBy Assignment = new AssignmentSectionUnitReportGroupBy(1, 1);
        public static AssignmentSectionUnitReportGroupBy Section = new AssignmentSectionUnitReportGroupBy(2, 2);
        public static AssignmentSectionUnitReportGroupBy Unit = new AssignmentSectionUnitReportGroupBy(3, 3);
        public static AssignmentSectionUnitReportGroupBy None = new AssignmentSectionUnitReportGroupBy(4, 4);

        public static readonly AssignmentSectionUnitReportGroupBy[] All = {Assignment, Section, Unit, None};

        public AssignmentSectionUnitReportGroupBy(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == Assignment.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByName_Assignment;
            }
            if (IdValue == Section.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByName_Section;
            }
            if (IdValue == Unit.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByName_Unit;
            }
            if (IdValue == None.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByName_None;
            }
            return null;
        }

        public string GetShortName()
        {
            if (IdValue == Assignment.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByShortName_Assignment;
            }
            if (IdValue == Section.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByShortName_Section;
            }
            if (IdValue == Unit.IdValue)
            {
                return StringResources.AssignmentSectionUnitReportGroupByShortName_Unit;
            }
            if (IdValue == None.IdValue)
            {
                return "";
            }
            return "";
        }

        public static AssignmentSectionUnitReportGroupBy GetById(int id)
        {
            return GetById(id, All);
        }
    }
}