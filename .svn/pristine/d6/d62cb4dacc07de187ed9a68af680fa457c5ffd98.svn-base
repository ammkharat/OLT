using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    class ExampleObject : DomainObject
    {
        public int i;

        public int I
        {
            get { return i; }
            set { i = value; }
        }
    }

    [Serializable]
    class ExampleObjectWithObjectAsProperty : DomainObject
    {
        private DateTime dateTimeValue;

        private ExampleObject exampleObject;

        public ExampleObject ExampleObject
        {
            get { return exampleObject; }
            set { exampleObject = value; }
        }

        public DateTime DateTimeValue
        {
            get { return dateTimeValue; }
            set { dateTimeValue = value; }
        }
    }

    [Serializable]
    class ExampleObjectForTestingHashCode : DomainObject
    {
        public int a;

        public int b;
    }

    [Serializable]
    class ExampleObjectContainingASet : DomainObject
    {
        public Set<string> s = new Set<string>();
        public int i = 3;
    }

    /// <summary>
    /// Summary description for DomainObjectTest
    /// </summary>
    [TestFixture]
    public class DomainObjectTest
    {
        [Test]
        public void ShouldBeEqualWhenComparedToItself()
        {
            ExampleObject exampleObject1 = new ExampleObject();
            Assert.IsTrue(exampleObject1.Equals(exampleObject1));
        }

        [Test]
        public void ShouldBeNotEqualWhenComparedToNull()
        {
            ExampleObject exampleObject1 = new ExampleObject();
            Assert.IsFalse(exampleObject1.Equals(null));
        }

        [Test]
        public void ShouldBeNotEqualWhenComparedToDifferentObject()
        {
            ExampleObject exampleObject1 = new ExampleObject {I = 1};
            ExampleObjectWithObjectAsProperty exampleObject2 = new ExampleObjectWithObjectAsProperty();
            Assert.IsFalse(exampleObject1.Equals(exampleObject2));
        }

        [Test]
        public void ShouldBeNotEqualWhenPropertyIsNotEqual()
        {
            ExampleObject exampleObject1 = new ExampleObject {I = 1};
            ExampleObject exampleObject2 = new ExampleObject {I = 2};
            Assert.IsFalse(exampleObject1.Equals(exampleObject2));
        }

        [Test]
        public void ShouldBeNotEqualWhenFieldIsNotEqual()
        {
            ExampleObject exampleObject1 = new ExampleObject {i = 1};
            ExampleObject exampleObject2 = new ExampleObject {i = 2};
            Assert.IsFalse(exampleObject1.Equals(exampleObject2));
        }

        [Test]
        public void ShouldBeEqualWhenComparedToTheObjectWithSameContent()
        {
            ExampleObject exampleObject1 = new ExampleObject {I = 1};
            ExampleObject exampleObject2 = new ExampleObject {I = 1};

            ExampleObjectWithObjectAsProperty exampleObjectWithObjectAsProperty1 = new ExampleObjectWithObjectAsProperty
                                                                                       {
                                                                                           DateTimeValue =
                                                                                               new DateTime(1900, 1, 1),
                                                                                           ExampleObject =
                                                                                               exampleObject1
                                                                                       };

            ExampleObjectWithObjectAsProperty exampleObjectWithObjectAsProperty2 = new ExampleObjectWithObjectAsProperty
                                                                                       {
                                                                                           DateTimeValue =
                                                                                               new DateTime(1900, 1, 1),
                                                                                           ExampleObject =
                                                                                               exampleObject2
                                                                                       };

            Assert.IsTrue(exampleObjectWithObjectAsProperty1.Equals(exampleObjectWithObjectAsProperty2));
            Assert.AreEqual(exampleObjectWithObjectAsProperty1, exampleObjectWithObjectAsProperty2);
        }

        [Test]
        public void ShouldNotGetSameHasCodeForTwoDifferentObjectWithDifferentContent()
        {
            ExampleObjectForTestingHashCode o1 = new ExampleObjectForTestingHashCode {a = 1, b = 3};
            ExampleObjectForTestingHashCode o2 = new ExampleObjectForTestingHashCode {a = 3, b = 1};
            Assert.AreNotEqual(o1.GetHashCode(), o2.GetHashCode());
        }

        [Test]
        public void ShouldNotBeEqualForTwoDifferentObjectWithDifferentContent()
        {
            ExampleObjectForTestingHashCode o1 = new ExampleObjectForTestingHashCode {a = 1, b = 3};
            ExampleObjectForTestingHashCode o2 = new ExampleObjectForTestingHashCode {a = 3, b = 1};
            Assert.AreNotEqual(o1, o2);
        }

        [Test]
        public void ShouldGetSameHasCodeForTwoDifferentObjectWithSameContent()
        {
            ExampleObjectForTestingHashCode o1 = new ExampleObjectForTestingHashCode {a = 1, b = 2};
            ExampleObjectForTestingHashCode o2 = new ExampleObjectForTestingHashCode {a = 1, b = 2};
            Assert.AreEqual(o1.GetHashCode(), o2.GetHashCode());
        }

        [Test]
        public void ShouldGetSameHasCodeForSameObject()
        {
            ExampleObjectForTestingHashCode o1 = new ExampleObjectForTestingHashCode {a = 1, b = 2};
            Assert.AreEqual(o1.GetHashCode(), o1.GetHashCode());
        }

        [Test]
        public void ToStringShouldReturnANicelyFormattedStringWithCommaSeparatedPropertyValues()
        {
            ExampleObjectForTestingHashCode exampleObject = new ExampleObjectForTestingHashCode {a = 1, b = 2};

            Assert.AreEqual("ExampleObjectForTestingHashCode ( a = 1, b = 2, Id =  )", exampleObject.ToString());
        }

        [Test]
        public void TypeCheck()
        {
            ExampleObject item = new ExampleObject();
            Assert.IsTrue(item.GetType().IsSubclassOf(typeof (DomainObject)));
        }

        class ExampleObjectForTestingSearch : DomainObject
        {
            [IncludeInSearch]
            public int TheNumber { get; set; }

            [IncludeInSearch]
            public string TheString { get; set; }

            [IncludeInSearch]
            public User TheUser { get; set; }

            [IncludeInSearch]
            public bool TheBoolean { get; set; }

            public string NotIncluded { get; set; }
        }

        [Test]
        public void ShouldDetermineIfContainsSearchTerm()
        {
            ExampleObjectForTestingSearch obj = new ExampleObjectForTestingSearch();

            obj.Id = 642642;
            obj.TheNumber = 42;
            obj.TheString = "This is the string.";
            obj.TheUser = UserFixture.CreateDBInsertableUser();
            obj.TheBoolean = true;
            obj.NotIncluded = "Not included";

            Assert.IsTrue(obj.ContainsSearchTerm("42"));
            Assert.IsTrue(obj.ContainsSearchTerm("he str"));
            Assert.IsTrue(obj.ContainsSearchTerm("testuser"));
            
            Assert.IsFalse(obj.ContainsSearchTerm("642642")); 
            Assert.IsFalse(obj.ContainsSearchTerm("true")); // booleans are ignored
            Assert.IsFalse(obj.ContainsSearchTerm("included"));
            
            // check that we are doing an 'and' comparison instead of an 'or' comparison
            Assert.IsFalse(obj.ContainsSearchTerm("42 43"));
            Assert.IsFalse(obj.ContainsSearchTerm("he str whoa"));
            Assert.IsTrue(obj.ContainsSearchTerm("he str testuser"));
            Assert.IsTrue(obj.ContainsSearchTerm("testuser 42"));

        }
    }
}
