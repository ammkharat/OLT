using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FakeDomainObjectFixture
    {
        public class FakeDomainObject : DomainObject
        {
            public FakeDomainObject(long? id)
            {
                this.id = id;
            }

            public DateTime LastModifiedDate
            {
                get { return new DateTime(2006, 01, 01, 8, 0, 0); }
            }
        }

        public static FakeDomainObject Create()
        {
            return new FakeDomainObject(1);
        }

        public static FakeDomainObject CreateWithId(long? id)
        {
            return new FakeDomainObject(id);
        }
    }
}