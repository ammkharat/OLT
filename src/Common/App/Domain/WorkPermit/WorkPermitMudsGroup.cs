using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMudsGroup : DomainObject, IWorkPermitGroup, IHasDisplayOrder
    {
        public static readonly WorkPermitMudsGroup EMPTY = new WorkPermitMudsGroup(string.Empty, 0);

        public WorkPermitMudsGroup(string name, int displayOrder)
        {
            Name = name;
            DisplayOrder = displayOrder;
        }

        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}