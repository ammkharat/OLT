using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class SaveUpdateDomainObjectContainer<T> where T : DomainObject
    {
        public SaveUpdateDomainObjectContainer(T item)
        {
            Item = item;
        }

        public T Item { get; private set; }
    }

    public class SaveUpdateMultiDomainObjectContainer<T> : SaveUpdateDomainObjectContainer<T> where T : DomainObject
    {
        public List<T> Items { get; private set; } 

        public SaveUpdateMultiDomainObjectContainer(List<T> items) : base(null)
        {
            Items = items;
        }
    }

    public class SaveDomainObjectContainerWithUserContextInfo<T> : SaveUpdateDomainObjectContainer<T>where T : DomainObject
    {
        public UserContext UserContext { get; private set; }

        public SaveDomainObjectContainerWithUserContextInfo(T item, UserContext userContext) : base(item)
        {
            UserContext = userContext;
        }
    }
}
