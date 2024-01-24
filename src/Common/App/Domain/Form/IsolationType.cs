using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class IsolationType : SortableSimpleDomainObject
    {
        public static IsolationType SingleValue = new IsolationType(1, 1, "Single Value");
        public static IsolationType DBAndB = new IsolationType(2, 2, "DB & B");
        public static IsolationType AirGap = new IsolationType(3, 3, "Air Gap");
        public static IsolationType Breaker = new IsolationType(4, 4, "Breaker");

        private static readonly IsolationType[] all = {SingleValue, DBAndB, AirGap, Breaker};
        private readonly string name;

        private IsolationType(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public static List<IsolationType> All
        {
            get { return new List<IsolationType>(all); }
        }

        public override string GetName()
        {
            return name;
        }

        public static IsolationType GetById(long id)
        {
            return GetById(id, all);
        }
    }
}