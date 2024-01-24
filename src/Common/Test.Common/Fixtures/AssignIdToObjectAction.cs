using System.IO;
using Com.Suncor.Olt.Common.Domain;
using NMock2;
using NMock2.Monitoring;

namespace Com.Suncor.Olt.Common.Fixtures
{
    // Occasionally a method call that we are mocking with NMock has a side effect that we want to simulate in our expectations.
    // An example is setting the id on a domain object during an insert. This can be done with this custom NMock IAction class.
    //
    // Usage: Expect.Once.On(myMock).Method("Insert").With(someObject).Will(AssignIdToObject(5));
    // private IAction AssignId(int id)
    // {
    //     return new AssignIdToObjectAction<ActionItem>(id);
    // }
    public class AssignIdToObjectAction<DomainObjectType> : IAction where DomainObjectType : DomainObject
    {
        private readonly long? idToBeAssigned;

        public AssignIdToObjectAction(long? idToBeAssigned)
        {
            this.idToBeAssigned = idToBeAssigned;
        }

        public void Invoke(Invocation invocation)
        {
            DomainObjectType theObject = ((DomainObjectType) invocation.Parameters[0]);
            theObject.Id = idToBeAssigned;
        }

        public void DescribeTo(TextWriter writer)
        {
            writer.Write("assigns a new id to SomeObject");
        }
    }
}