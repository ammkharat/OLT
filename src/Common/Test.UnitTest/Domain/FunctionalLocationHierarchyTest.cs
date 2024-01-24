using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class FunctionalLocationHierarchyTest
    {
        [Test]
        public void ShouldProvideMeaningfulStringRepresentation()
        {
            Assert.AreEqual("A-B-C-D-E", new FunctionalLocationHierarchy("A-B-C-D-E").ToString());
            Assert.AreEqual("A", new FunctionalLocationHierarchy("A").ToString());
        }

        [Test]
        public void TwoObjectsWithSameHierarchyShouldBeEqualAndHaveSameHashCode()
        {
            FunctionalLocationHierarchy one = new FunctionalLocationHierarchy("A-B-C-D-E");
            FunctionalLocationHierarchy two = new FunctionalLocationHierarchy("A-B-C-D-E");

            Assert.AreEqual(one, two);
            Assert.AreEqual(one.GetHashCode(), two.GetHashCode());

            FunctionalLocationHierarchy three = new FunctionalLocationHierarchy("A");
            FunctionalLocationHierarchy four = new FunctionalLocationHierarchy("A");
            Assert.AreEqual(three, four);
            Assert.AreEqual(three.GetHashCode(), four.GetHashCode());
        }

        [Test]
        public void ShouldGetAncestorAtLevel2()
        {
            FunctionalLocationHierarchy functionalLocationHierarchy = new FunctionalLocationHierarchy("A-B-C-D");
            Assert.AreEqual("A-B", functionalLocationHierarchy.GetAncestorOrSelf(2).ToString());
        }

        [Test]
        public void ShouldGetSelfWhenLevelsAreTheSame()
        {
            FunctionalLocationHierarchy h = new FunctionalLocationHierarchy("A-B-C-D");
            Assert.AreEqual(h, h.GetAncestorOrSelf(4));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenGettingAncestorAtHigherLevelThanFloc()
        {
            FunctionalLocationHierarchy h = new FunctionalLocationHierarchy("A-B-C");
            h.GetAncestorOrSelf(4);
        }

        [Test]
        public void ShouldFigureOutParentHierarchy()
        {
            Assert.AreEqual(new FunctionalLocationHierarchy("A-B-C-D"),
                new FunctionalLocationHierarchy("A-B-C-D-E").ParentHierarchy);
            Assert.AreEqual(new FunctionalLocationHierarchy("A"),
                new FunctionalLocationHierarchy("A-B").ParentHierarchy);
        }

        [Test]
        public void ShouldReplaceSegments()
        {
            FunctionalLocationHierarchy item = new FunctionalLocationHierarchy("A-B-C-D");
            FunctionalLocationHierarchy result = item.ReplaceSegment(2, "BB");
            Assert.That(result.ToString(), Is.EqualTo("A-BB-C-D"));
        }

        [Test]
        public void ShouldAppendSegment()
        {
            FunctionalLocationHierarchy item = new FunctionalLocationHierarchy("A-B");
            FunctionalLocationHierarchy result = item.AppendSegment("C");
            Assert.That(result.ToString(), Is.EqualTo("A-B-C"));
            Assert.That(result.Level, Is.EqualTo(3));
        }

        [Test]
        public void ShouldGetLastSegment()
        {
            FunctionalLocationHierarchy item = new FunctionalLocationHierarchy("A-B-C-ABCDE");
            Assert.That(item.LastSegment, Is.EqualTo("ABCDE"));
        }

        [Test]
        public void ShouldGetLevelSix()
        {
            FunctionalLocationHierarchy h = new FunctionalLocationHierarchy("A-B-C-D-E-F");
            Assert.That(h.Level, Is.EqualTo(6));
        }

        [Test]
        public void ShouldGetLongestMatchingHierarchy()
        {
            {
                FunctionalLocationHierarchy h1 = new FunctionalLocationHierarchy("A-B-C-D-E-F");
                FunctionalLocationHierarchy h2 = new FunctionalLocationHierarchy("A-B-C-X");
                FunctionalLocationHierarchy longestMatchingHierarchy = FunctionalLocationHierarchy.LongestMatchingHierarchy(new List<FunctionalLocationHierarchy> {h1, h2});
                Assert.AreEqual("A-B-C", longestMatchingHierarchy.ToString());
            }

            {
                FunctionalLocationHierarchy h1 = new FunctionalLocationHierarchy("A-B-C-X-Y-Z");
                FunctionalLocationHierarchy h2 = new FunctionalLocationHierarchy("X-Y-Z");
                FunctionalLocationHierarchy longestMatchingHierarchy = FunctionalLocationHierarchy.LongestMatchingHierarchy(new List<FunctionalLocationHierarchy> { h1, h2 });
                Assert.IsNull(longestMatchingHierarchy);
            }

            {
                FunctionalLocationHierarchy h1 = new FunctionalLocationHierarchy("A-B-R");
                FunctionalLocationHierarchy h2 = new FunctionalLocationHierarchy("A-B-C-D-E-F");
                FunctionalLocationHierarchy h3 = new FunctionalLocationHierarchy("A-B-C-X");
                FunctionalLocationHierarchy longestMatchingHierarchy = FunctionalLocationHierarchy.LongestMatchingHierarchy(new List<FunctionalLocationHierarchy> { h1, h2, h3 });
                Assert.AreEqual("A-B", longestMatchingHierarchy.ToString());
            }


        }

    }
}
