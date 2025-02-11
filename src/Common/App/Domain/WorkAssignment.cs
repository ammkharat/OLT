using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class WorkAssignment : DomainObject, ICacheBySiteId
    {
        public const int NoneWorkAssignmentId = -999;

        public static readonly WorkAssignment NoneWorkAssignment = new WorkAssignment(
            NoneWorkAssignmentId, StringResources.None, null, null, -999, null, true, true, null, null, null, false,false);

        private readonly List<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups =
            new List<WorkAssignmentVisibilityGroup>();

        private List<FunctionalLocation> functionalLocations = new List<FunctionalLocation>();

        public WorkAssignment(long? id, string name, string description, string category, long siteId, Role role,
            bool useWorkAssignmentForActionItemHandoverDisplay, bool copyTargetAlertResponseToLog,
            List<FunctionalLocation> functionalLocations,
            List<WorkAssignmentVisibilityGroup> workAssignmentVisibilityGroups, long? autoInsertLogTemplateId,
            bool showLubesCsdOnShiftHandoverReport,
            bool showEventExcursionsOnShiftHandoverReport)
        {
            this.id = id;
            Name = name;
            Description = description;
            Category = category;
            SiteId = siteId;
            Role = role;
            UseWorkAssignmentForActionItemHandoverDisplay = useWorkAssignmentForActionItemHandoverDisplay;
            CopyTargetAlertResponseToLog = copyTargetAlertResponseToLog;
            AutoInsertLogTemplateId = autoInsertLogTemplateId;
            ShowLubesCsdOnShiftHandoverReport = showLubesCsdOnShiftHandoverReport;
            ShowEventExcursionsOnShiftHandoverReport = showEventExcursionsOnShiftHandoverReport;

            if (functionalLocations != null)
            {
                this.functionalLocations = functionalLocations;
            }

            if (workAssignmentVisibilityGroups != null)
            {
                this.workAssignmentVisibilityGroups = workAssignmentVisibilityGroups;
            }
        }

        public WorkAssignment(string name, string description, string category, long siteId, Role role)
            : this(null, name, description, category, siteId, role, true, true, null, null, null, false,false)
        {
        }
        public WorkAssignment(string category) //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        {
            Category = category;
        }

        public override long? Id
        {
            get { return base.Id; }
            set
            {
                base.Id = value;
                workAssignmentVisibilityGroups.ForEach(vg => vg.WorkAssignmentId = value);
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string RoleName
        {
            get { return Role.Name; }
        }

        public Role Role { get; set; }

        public bool UseWorkAssignmentForActionItemHandoverDisplay { get; set; }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocations; }
            set { functionalLocations = value; }
        }

        public string DisplayName
        {
            get { return GetDisplayName(Name, Description); }
        }

        public bool CopyTargetAlertResponseToLog { get; set; }

        public long? AutoInsertLogTemplateId { get; set; }

        public List<WorkAssignmentVisibilityGroup> WriteWorkAssignmentVisibilityGroups
        {
            get { return workAssignmentVisibilityGroups.FindAll(wavg => wavg.VisibilityType == VisibilityType.Write); }
        }

        public List<WorkAssignmentVisibilityGroup> ReadWorkAssignmentVisibilityGroups
        {
            get { return workAssignmentVisibilityGroups.FindAll(wavg => wavg.VisibilityType == VisibilityType.Read); }
        }

        public ReadOnlyCollection<WorkAssignmentVisibilityGroup> WorkAssignmentVisibilityGroups
        {
            get { return new ReadOnlyCollection<WorkAssignmentVisibilityGroup>(workAssignmentVisibilityGroups); }
        }

        public bool ShowLubesCsdOnShiftHandoverReport { get; set; }

        public long SiteId { get; private set; }

        public bool ShowEventExcursionsOnShiftHandoverReport { get; set; }

        public static string GetDisplayName(string name, string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return name;
            }
            return string.Format("{0} - {1}", name, description);
        }

        public override string ToString()
        {
            var descriptionString = string.IsNullOrEmpty(Description) ? "" : string.Format(" ({0})", Description);
            return string.Format("{0}{1}", Name, descriptionString);
        }

        public static int CompareByToStringValue(WorkAssignment x, WorkAssignment y)
        {
            var xString = x != null ? x.ToString() : null;
            var yString = y != null ? y.ToString() : null;

            return string.Compare(xString, yString, StringComparison.CurrentCulture);
        }

        public bool HasAtLeastOneFunctionalLocationThatIsPartOfPlant(long plantId)
        {
            return HasAtLeastOneFunctionalLocationThatIsPartOfAnyOfThesePlants(new List<long> {plantId});
        }

        public bool HasAtLeastOneFunctionalLocationThatIsPartOfAnyOfThesePlants(List<long> plantIds)
        {
            return functionalLocations.Exists(floc => plantIds.Contains(floc.PlantId));
        }

        public bool CanRead(VisibilityGroup visibilityGroup)
        {
            return
                workAssignmentVisibilityGroups.Exists(
                    vg => vg.VisibilityGroupId == visibilityGroup.IdValue && vg.VisibilityType == VisibilityType.Read);
        }

        public bool CanWrite(VisibilityGroup visibilityGroup)
        {
            return
                workAssignmentVisibilityGroups.Exists(
                    vg => vg.VisibilityGroupId == visibilityGroup.IdValue && vg.VisibilityType == VisibilityType.Write);
        }

        public void AddVisibilityGroup(WorkAssignmentVisibilityGroup group)
        {
            group.WorkAssignmentId = Id;
            workAssignmentVisibilityGroups.Add(group);
        }

        public void SetVisibilityGroups(List<WorkAssignmentVisibilityGroup> groups)
        {
            workAssignmentVisibilityGroups.Clear();
            foreach (var group in groups)
            {
                AddVisibilityGroup(group);
            }
        }

        public bool HasSameFunctionalLocations(string functionalLocationNames)
        {
            var fullHierarchies = functionalLocations.ConvertAll(fl => fl.FullHierarchy);
            fullHierarchies.Sort();
            return string.Equals(fullHierarchies.ToCommaSeparatedString(), functionalLocationNames,
                StringComparison.Ordinal);
        }

        public override bool Equals(object objectToBeCompared)
        {
            if (ReferenceEquals(this, objectToBeCompared))
            {
                return true;
            }

            var assignmentToBeCompared = objectToBeCompared as WorkAssignment;

            if (assignmentToBeCompared == null)
            {
                return false;
            }

            if (Id == null || assignmentToBeCompared.Id == null)
            {
                return base.Equals(assignmentToBeCompared);
            }

            return IdValue == assignmentToBeCompared.IdValue;
        }
    }
}