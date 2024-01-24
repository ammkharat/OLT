using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionBatch : DomainObject
    {
        private readonly List<OpmExcursion> excursions;

        private OpmExcursionBatch() : base(-1)
        {
        }

        public OpmExcursionBatch(List<OpmExcursion> excursions) : this()
        {
            this.excursions = excursions;
        }

        public List<OpmExcursion> Excursions
        {
            get { return excursions; }
        }
    }
}