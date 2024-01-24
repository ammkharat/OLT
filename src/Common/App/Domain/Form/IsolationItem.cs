using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class IsolationItem : DomainObject, IHasDisplayOrder
    {
        public IsolationItem(long? id, long? formGN75BId, int displayOrder, string isolationType,
            string locationOfEnergyIsolation, string devicePosition, long siteid)                        //ayman Sarnia eip DMND0008992
        {
            this.id = id;
            FormGn75BId = formGN75BId;
            DisplayOrder = displayOrder;
            IsolationType = isolationType;
            LocationOfEnergyIsolation = locationOfEnergyIsolation;
            if(siteid == 1)
            DevicePosition = devicePosition;                        //ayman Sarnia eip DMND0008992

            SiteId = siteid;                                     //ayman Sarnia eip DMND0008992
        }

        public long? FormGn75BId { get; set; }
        public string IsolationType { get; set; }
        public string LocationOfEnergyIsolation { get; set; }
        public string DevicePosition { get; set; }                 //ayman Sarnia eip DMND0008992
        public long SiteId { get; set; }                           //ayman Sarnia eip DMND0008992
        public int DisplayOrder { get; set; }
    }
}