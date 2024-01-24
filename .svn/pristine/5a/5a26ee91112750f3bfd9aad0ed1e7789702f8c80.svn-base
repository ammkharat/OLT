using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// UnitTest for Comment Domain Object
    /// </summary>
    [TestFixture]
    public class CommentTest
    {
        private Comment comment;

        [SetUp]
        public void SetUp()
        {
            comment = CommentFixture.CreateComment();
        }

        [Test]
        public void MustBeSerializeable()
        {
            Assert.IsTrue(typeof(Comment).IsSerializable);
        }

        [Test]
        public void MustBeDerivedFromDomanObject()
        {
            Assert.IsInstanceOf(typeof (DomainObject), comment);
        }
    }
}
