using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMontrealGroup : DomainObject, IWorkPermitGroup, IHasDisplayOrder
    {
        public static readonly WorkPermitMontrealGroup EMPTY = new WorkPermitMontrealGroup(string.Empty, 0);

        public WorkPermitMontrealGroup(string name, int displayOrder)
        {
            Name = name;
            DisplayOrder = displayOrder;
        }

        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}