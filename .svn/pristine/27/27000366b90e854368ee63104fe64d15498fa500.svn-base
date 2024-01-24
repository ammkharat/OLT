using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class HashCodeBuilderTest
    {
        [Test]
        public void GeneratesAUniqueHashCodeForClassesWithSimpleProperties()
        {
            Assert.AreEqual(1674268608, new SimpleObjectForHashCodeTest(1, "one").ReflectionGetHashCode());
        }

        [Test]
        public void AnotherTestToGenerateAUniqueHashCodeForClassesWithSimpleProperties()
        {
            Assert.AreEqual(2145399217, new SimpleObjectForHashCodeTest(2, "two").ReflectionGetHashCode());
        }

        [Test]
        public void YetAnotherTestToGenerateAUniqueHashCodeForClassesWithSimpleProperties()
        {
            Assert.AreEqual(1628855668, new SimpleObjectForHashCodeTest(3, "three").ReflectionGetHashCode());
        }

        [Test]
        public void TwoObjectsWithIdenticalValuesShouldHaveTheSameHashCode()
        {
            Assert.AreEqual(new SimpleObjectForHashCodeTest(3, "three").ReflectionGetHashCode(), new SimpleObjectForHashCodeTest(3, "three").ReflectionGetHashCode());
        }

        [Test]
        public void TwoObjectsWithDifferentValuesShouldProbablyHaveDifferentHashCodes()
        {
            Assert.AreNotEqual(new SimpleObjectForHashCodeTest(10, "abc").ReflectionGetHashCode(), new SimpleObjectForHashCodeTest(11, "abc").ReflectionGetHashCode());
        }

        [Test]
        public void TwoObjectsWithIdenticalValuesIncludingListsShouldProbablyHaveTheSameHashCodes()
        {
            ObjectWithListForTestingHashCode obj1 = new ObjectWithListForTestingHashCode();
            obj1.s = "abc";
            obj1.list.Add("one");
            obj1.list.Add("two");

            ObjectWithListForTestingHashCode obj2 = new ObjectWithListForTestingHashCode();
            obj2.s = "abc";
            obj2.list.Add("one");
            obj2.list.Add("two");

            Assert.AreEqual(obj1.ReflectionGetHashCode(), obj2.ReflectionGetHashCode());
        }

        [Test]
        public void ShouldBeAbleToGenerateHashCodeWithoutUsingReflection()
        {
            int hashCode = new HashCodeBuilder().Append("hi").Append(3).HashCode;
            Assert.AreEqual(996433669, hashCode);
        }

    }

    class SimpleObjectForHashCodeTest
    {
        public int i;
        public string s;

        public SimpleObjectForHashCodeTest(int i, string s)
        {
            this.i = i;
            this.s = s;
        }
    }

    class ObjectWithListForTestingHashCode
    {
        public List<string> list = new List<string>();
        public string s;
    }
}
