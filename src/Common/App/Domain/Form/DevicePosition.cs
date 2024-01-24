using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
   [Serializable]
    public class DevicePosition : DomainObject, IHasDisplayOrder
    {
          public DevicePosition(long? id, long? formGN75BId, int displayOrder, string devicePosition)
        {
            this.id = id;
            FormGn75BId = formGN75BId;
            DisplayOrder = displayOrder;
            DevicePositionDesc = devicePosition;
        }

        public long? FormGn75BId { get; set; }
        public string DevicePositionDesc { get; set; }
        public int DisplayOrder { get; set; }
    }
}
