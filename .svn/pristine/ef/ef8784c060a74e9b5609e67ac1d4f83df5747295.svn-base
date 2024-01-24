using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public class WorkOrderPriority : SortableSimpleDomainObject
    {
        public static readonly WorkOrderPriority P0 = new WorkOrderPriority(0, 0);
        public static readonly WorkOrderPriority P1 = new WorkOrderPriority(1, 1);
        public static readonly WorkOrderPriority P2 = new WorkOrderPriority(2, 2);
        public static readonly WorkOrderPriority P3 = new WorkOrderPriority(3, 3);
        public static readonly WorkOrderPriority P4 = new WorkOrderPriority(4, 4);

        public static List<WorkOrderPriority> all = new List<WorkOrderPriority> {P0, P1, P2, P3, P4};

        protected WorkOrderPriority(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public int PriorityNumber
        {
            get { return (int) IdValue; }
        }

        public override string GetName()
        {
            return Convert.ToString(IdValue);
        }

        public WorkOrderPriority GetByImportValue(string value)
        {
            int valueAsInt;

            try
            {
                valueAsInt = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return null;
            }

            return GetById(valueAsInt, all);
        }

        public static WorkOrderPriority FindById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return GetById(id, all);
        }
    }
}