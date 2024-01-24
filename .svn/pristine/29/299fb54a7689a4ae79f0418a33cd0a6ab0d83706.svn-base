using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class ExcursionStatus : SimpleDomainObject
    {
        public static ExcursionStatus InvalidExcursionStatus = new ExcursionStatus(0, "INVALID EXCURSION STATUS");
        public static ExcursionStatus Open = new ExcursionStatus(1, "Open");
        public static ExcursionStatus Closed = new ExcursionStatus(2, "Closed");


        private static readonly ExcursionStatus[] all =
        {
            Open,Closed
        };

        private readonly string name;

        private ExcursionStatus(long id, string name)
            : base(id)
        {
            this.name = name;
        }

        public static ExcursionStatus[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            return name;
        }

        public static ExcursionStatus Get(long index)
        {
            return GetById(index, all);
        }

        // Used during import to retain actual value when invalid
        public string TagValue { get; set; }
    }
}