using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardConfigurationDrum : DomainObject, IHasDisplayOrder
    {
        public const string DISPLAY_ORDER_PROPERTY = "DisplayOrder";
        private int displayOrder;
        private string name;

        public CokerCardConfigurationDrum(long? id, string name, int displayOrder)
        {
            this.id = id;
            this.name = name;
            this.displayOrder = displayOrder;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }
    }
}