using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common
{
    [Serializable]
    public class SchedulingList<TDomainObject, TException> where TDomainObject : DomainObject
    {
        private readonly List<TDomainObject> domainObjectList;
        private readonly List<TException> exceptionList;

        public SchedulingList(List<TDomainObject> domainObjectList, List<TException> exceptionList)
        {
            this.domainObjectList = domainObjectList;
            this.exceptionList = exceptionList;
        }

        public List<TDomainObject> DomainObjectList
        {
            get { return domainObjectList; }
        }

        public List<TException> ExceptionList
        {
            get { return exceptionList; }
        }
    }
}