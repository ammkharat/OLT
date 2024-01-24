using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class SetTest
    {
        [Test]
        public void EqualsShouldReturnTrueForTwoIdenticalSets()
        {
            Set<string> s1 = new Set<string> {"one", "two"};
            Set<string> s2 = new Set<string> {"one", "two"};
            Assert.AreEqual(true, s1.Equals(s2));
            Assert.AreEqual(true, s2.Equals(s1));
        }

        [Test]
        public void EqualsShouldReturnTrueForTwoSetsWithItemsAddedInDifferentOrder()
        {
            Set<string> s1 = new Set<string> {"one", "two"};
            Set<string> s2 = new Set<string> {"two", "one"};
            // Assert.AreEqual(s1, s2); // claims to call s1.Equals(s2) but obviously doesn't.
            Assert.AreEqual(true, s1.Equals(s2));
            Assert.AreEqual(true, s2.Equals(s1));
        }

        [Test]
        public void ShouldCopyToAnArray()
        {
            Set<string> s1 = new Set<string> { "one", "two", "3", "4", "five" };
            string[] array = new string[5];
            s1.CopyTo(array, 0);
            Assert.That(array[2], Is.EqualTo("3"));
        }

        [Test]
        public void ShouldRemoveItem()
        {
            string stringToRemove = "3";
            Set<string> s1 = new Set<string> { "one", "two", stringToRemove, "4", "five" };
            Assert.That(s1.Contains(stringToRemove));
            s1.Remove(stringToRemove);
            Assert.That(s1.Contains(stringToRemove), Is.False);
        }

        [Test]
        public void ShouldGetUnionOfItems()
        {
            Set<string> s1 = new Set<string>{"one", "two", "3", "five"};
            Set<string> s2 = new Set<string>{"one", "1", "2", "four", "5"};

            Set<string> result = s1.Union(s2);

            Assert.That(result.Count, Is.EqualTo(8));
        }

        [Test]
        public void ShouldGetIntersectionOfItems()
        {
            Set<string> s1 = new Set<string> { "one", "two", "3", "five" };
            Set<string> s2 = new Set<string> { "one", "1", "2", "four", "5", "five" };

            Set<string> result = s1.Intersection(s2);

            Assert.That(result.Count, Is.EqualTo(2));
        }

    }
}
