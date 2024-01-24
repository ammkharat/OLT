using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardConfigurationCycleStep : DomainObject, IHasDisplayOrder
    {
        private int displayOrder;
        private string name;

        public CokerCardConfigurationCycleStep(long? id, string name, int displayOrder)
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