using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLubesGroup : SortableSimpleDomainObject, IWorkPermitGroup
    {
        private readonly string name;

        public WorkPermitLubesGroup(long id, string name, int displayOrder)
            : this(id, name, displayOrder, new List<int>(), new List<string>())
        {
        }

        public WorkPermitLubesGroup(long id, string name, int displayOrder, List<int> sapImportPriorityList,
            List<string> sapImportPlanningGroupList)
            : base(id, displayOrder)
        {
            this.name = name;
            SAPImportPriorityList = sapImportPriorityList;
            SAPImportPlanningGroupList = sapImportPlanningGroupList;
        }

        public List<int> SAPImportPriorityList { get; private set; }
        public List<string> SAPImportPlanningGroupList { get; private set; }

        public bool IsConstructionOrTurnaround
        {
            get { return HasPriority(3) || HasPlannerGroup("PE1"); }
        }

        public override string GetName()
        {
            return name;
        }

        public void AddSAPImportPriority(int sapImportPriority)
        {
            SAPImportPriorityList.Add(sapImportPriority);
        }

        public void AddSAPPlannerGroup(string sapPlannerGroup)
        {
            SAPImportPlanningGroupList.Add(sapPlannerGroup);
        }

        public static WorkPermitLubesGroup FindByPriority(string priorityString, List<WorkPermitLubesGroup> groups)
        {
            if (priorityString == null)
            {
                return null;
            }

            try
            {
                var priority = Convert.ToInt32(priorityString);
                return groups.Find(g => g.HasPriority(priority));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool HasPriority(int priority)
        {
            if (SAPImportPriorityList == null)
            {
                return false;
            }

            return SAPImportPriorityList.Exists(p => p.Equals(priority));
        }

        public static WorkPermitLubesGroup FindByPlannerGroup(string plannerGroup, List<WorkPermitLubesGroup> groups)
        {
            if (plannerGroup == null)
            {
                return null;
            }

            return groups.Find(g => g.HasPlannerGroup(plannerGroup));
        }

        public bool HasPlannerGroup(string plannerGroup)
        {
            if (SAPImportPlanningGroupList == null)
            {
                return false;
            }

            return SAPImportPlanningGroupList.Exists(plannerGroup.Equals);
        }
    }
}