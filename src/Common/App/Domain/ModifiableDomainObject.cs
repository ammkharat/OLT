using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public abstract class ModifiableDomainObject : DomainObject
    {
        //TODO:  All objects extending the ModifiableDomainObject should use the constructor below.  Once they do, get rid of this no-arg constructor.
        protected ModifiableDomainObject()
        {
        }

        protected ModifiableDomainObject(User lastModifiedBy, DateTime lastModifiedDateTime)
        {
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public User LastModifiedBy { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}