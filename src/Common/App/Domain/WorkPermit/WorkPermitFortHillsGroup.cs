using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitFortHillsGroup : SortableSimpleDomainObject, IWorkPermitGroup
    {
        private readonly string name;

        public WorkPermitFortHillsGroup(long id, string name, List<long> sapImportPriorityList, int displayOrder,
            bool defaultToDayShiftOnSapImport) : base(id, displayOrder)
        {
            this.name = name;
            SAPImportPriorityList = sapImportPriorityList ?? new List<long>();
            DefaultToDayShiftOnSapImport = defaultToDayShiftOnSapImport;
        }

        public bool DefaultToDayShiftOnSapImport { get; private set; }

        public bool IsTurnaround
        {
            get { return HasPriority(WorkOrderPriority.P3) || HasPriority(WorkOrderPriority.P4); }
        }

        public List<long> SAPImportPriorityList { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public override string GetName()
        {
            return name;
        }

        public static WorkPermitFortHillsGroup FindByPriority(string priorityString,
            List<WorkPermitFortHillsGroup> WorkPermitFortHillsGroup)
        {
            if (priorityString == null)
            {
                return null;
            }

            try
            {
                var priority = Convert.ToInt32(priorityString);
                return WorkPermitFortHillsGroup.Find(g => g.HasPriority(priority));
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool HasPriority(int priority)
        {
            if (SAPImportPriorityList == null)
            {
                return false;
            }

            return SAPImportPriorityList.Exists(p => p.Equals(priority));
        }

        public bool HasPriority(WorkOrderPriority priority)
        {
            return HasPriority(priority.PriorityNumber);
        }

        public void AddSAPImportPriority(int sapImportPriority)
        {
            SAPImportPriorityList.Add(sapImportPriority);
        }
    }
}