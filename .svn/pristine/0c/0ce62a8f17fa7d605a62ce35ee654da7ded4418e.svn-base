using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for AbstractValueObjectTest
    /// </summary>
    [TestFixture]
    public class SortableDomainObjectStatusTest
    {       
        [Test]
        public void ShouldReturnValueById()
        {
            TeamMembers teamMember = TeamMembers.GetById(2);
            Assert.AreEqual(TeamMembers.Razor, teamMember);
        }

        [Test]
        public void EqualsOnTwoInstancesWithSameIdShouldReturnTrue()
        {
            TeamMembers eric = TeamMembers.Eric;
            TeamMembers otherEric = new TeamMembers(eric.IdValue, 22312312);

            Assert.IsTrue(eric.Equals(otherEric));
        }

        private class TeamMembers : SortableSimpleDomainObject
        {
            public static readonly TeamMembers Eric = new TeamMembers(0, 0);
            public static readonly TeamMembers Troy = new TeamMembers(1, 1);
            public static readonly TeamMembers Razor = new TeamMembers(2, 2);

            private static readonly TeamMembers[] ALL = new[] { Eric, Troy, Razor };

            public TeamMembers(long id, int displayPriority)
                : base(id, displayPriority)
            {
            }

            public override string GetName()
            {
                if (IdValue == 0) { return "Eric Liu"; }
                if (IdValue == 1) { return "Troy Gould"; }
                if (IdValue == 2) { return "Raymond Maung"; }
                return null;
            }

            public static TeamMembers GetById(int id)
            {
                return GetById(id, ALL);
            }           
        }
    }
}