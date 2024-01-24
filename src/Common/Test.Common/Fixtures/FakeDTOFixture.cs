using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FakeDTOFixture
    {
        public static FakeDTO Create()
        {
            return CreateWithId(1);
        }

        public static FakeDTO CreateWithId(long? id)
        {
            return new FakeDTO(id);
        }


        public class FakeDTO : DomainObject
        {
            private Date startDate;
            private Time startTime;

            public FakeDTO(long? id)
            {
                this.id = id;
            }

            public FakeDTO(FakeDomainObjectFixture.FakeDomainObject domainObject)
            {
                this.id = id;
                startDate = new Date(domainObject.LastModifiedDate);
                startTime = new Time(domainObject.LastModifiedDate);
            }

            public Date StartDate
            {
                get { return startDate; }
                set { startDate = value; }
            }

            public Time StartTime
            {
                get { return startTime; }
                set { startTime = value; }
            }

        }
    }
}