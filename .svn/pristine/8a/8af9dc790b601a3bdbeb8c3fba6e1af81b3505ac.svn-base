using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class OpmExcursionImportStatus : SimpleDomainObject
    {
        public static OpmExcursionImportStatus Available = new OpmExcursionImportStatus(1, "Available");
        public static OpmExcursionImportStatus Unavailable = new OpmExcursionImportStatus(2, "Unavailable");


        private static readonly OpmExcursionImportStatus[] all =
        {
            Available, Unavailable
        };

        private readonly string name;

        private OpmExcursionImportStatus(long id, string name)
            : base(id)
        {
            this.name = name;
        }

        public static OpmExcursionImportStatus[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            return name;
        }

        public static OpmExcursionImportStatus Get(long index)
        {
            return GetById(index, all);
        }
    }
}