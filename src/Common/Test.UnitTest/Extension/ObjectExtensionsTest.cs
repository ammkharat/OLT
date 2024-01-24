using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class ObjectExtensionsTest
    {
        [Test]
        public void ReflectionEqualsShouldReturnTrueForTwoObjectsWithIdenticalSimpleValues()
        {
            SimpleTestObject o1 = new SimpleTestObject(1, "one");
            SimpleTestObject o2 = new SimpleTestObject(1, "one");
            Assert.IsTrue(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnTrueForTwoObjectsWithIdenticalPrivateProperties()
        {
            SimpleTestObjectWithPrivateProperties o1 = new SimpleTestObjectWithPrivateProperties(1, "one");
            SimpleTestObjectWithPrivateProperties o2 = new SimpleTestObjectWithPrivateProperties(1, "one");
            Assert.IsTrue(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseForTwoObjectsWithDifferentPrivateProperties()
        {
            SimpleTestObjectWithPrivateProperties o1 = new SimpleTestObjectWithPrivateProperties(1, "one");
            SimpleTestObjectWithPrivateProperties o2 = new SimpleTestObjectWithPrivateProperties(1, "two");
            Assert.IsFalse(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseForTwoObjectsWithDifferingIntegerValues()
        {
            SimpleTestObject o1 = new SimpleTestObject(1, "one");
            SimpleTestObject o2 = new SimpleTestObject(2, "one");
            Assert.IsFalse(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseForTwoObjectsWithDifferingStringValues()
        {
            SimpleTestObject o1 = new SimpleTestObject(1, "one");
            SimpleTestObject o2 = new SimpleTestObject(1, "two");
            Assert.IsFalse(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnTrueForTwoObjectsWithEqualSets()
        {
            ExampleObjectContainingASet o1 = new ExampleObjectContainingASet {i = 1};
            o1.s.Add("one");
            o1.s.Add("two");
            ExampleObjectContainingASet o2 = new ExampleObjectContainingASet {i = 1};
            o2.s.Add("one");
            o2.s.Add("two");
            Assert.IsTrue(o1.ReflectionEquals(o2));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseIfTheFirstArgumentIsNull()
        {
            SimpleTestObject o1 = new SimpleTestObject(1, "one");
            Assert.IsFalse(ObjectExtensions.ReflectionEquals(null, o1));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseIfTheSecondArgumentIsNull()
        {
            SimpleTestObject o1 = new SimpleTestObject(1, "one");
            Assert.IsFalse(o1.ReflectionEquals(null));
        }

        [Test]
        public void ReflectionEqualsShouldReturnTrueIfBothArgumentsAreNull()
        {
            Assert.IsTrue(ObjectExtensions.ReflectionEquals(null, null));
        }

        [Test]
        public void ReflectionEqualsShouldReturnFalseIfArgumentsAreOfDifferentTypes()
        {
            Assert.IsFalse("one".ReflectionEquals(1));
        }

        [Test]
        public void ReflectionEqualsWithList()
        {
            SimpleTestObject a = new SimpleTestObject(1, "a");
            SimpleTestObject b = new SimpleTestObject(2, "b");

            SimpleTestObjectWithList expected = new SimpleTestObjectWithList(1, new List<SimpleTestObject>{a, b});
            SimpleTestObjectWithList actual = new SimpleTestObjectWithList(1, new List<SimpleTestObject> { a, b });
            Assert.IsTrue(expected.ReflectionEquals(actual));
        }

        [Test]
        public void ReflectionEqualsWithListTwoObjects()
        {
            SimpleTestObject a = new SimpleTestObject(1, "a");
            SimpleTestObject b = new SimpleTestObject(2, "b");

            SimpleTestObject c = new SimpleTestObject(1, "a");
            SimpleTestObject d = new SimpleTestObject(2, "b");

            SimpleTestObjectWithList expected = new SimpleTestObjectWithList(1, new List<SimpleTestObject> { a, b });
            SimpleTestObjectWithList actual = new SimpleTestObjectWithList(1, new List<SimpleTestObject> { c, d });
            Assert.IsTrue(expected.ReflectionEquals(actual));
        }

        [Test]
        public void TheCompleteReflectionTest()
        {
            SimpleTestObject a = new SimpleTestObject(1, "a");
            SimpleTestObject b = new SimpleTestObject(2, "b");

            SimpleTestObject c = new SimpleTestObject(1, "a");
            SimpleTestObject d = new SimpleTestObject(2, "b");

            SimpleTestObject e = new SimpleTestObject(1, "a");
            SimpleTestObject f = new SimpleTestObject(2, "b");

            SimpleTestObject g = new SimpleTestObject(1, "a");
            SimpleTestObject h = new SimpleTestObject(2, "b");

            SimpleTestObjectWithList list1 = new SimpleTestObjectWithList(1, new List<SimpleTestObject> { a, b });
            SimpleTestObjectWithList list2 = new SimpleTestObjectWithList(2, new List<SimpleTestObject> { c, d });
            SimpleTestObjectWithList list3 = new SimpleTestObjectWithList(1, new List<SimpleTestObject> { e, f });
            SimpleTestObjectWithList list4 = new SimpleTestObjectWithList(2, new List<SimpleTestObject> { g, h });

            ListWithAList listA = new ListWithAList("list", new List<SimpleTestObjectWithList> {list1, list2});
            ListWithAList listB = new ListWithAList("list", new List<SimpleTestObjectWithList> { list3, list4 });

            Assert.IsTrue(listA.ReflectionEquals(listB));
        }
        [Test]
        public void ToStringShouldReturnANicelyFormattedStringWithCommaSeparatedPropertyValues()
        {
            SimpleObjectForTesting o1 = new SimpleObjectForTesting(1, "one");
            Assert.AreEqual("SimpleObjectForTesting ( i = 1, s = one )", o1.ReflectionToString());
        }

        [Test]
        public void ToStringShouldNotIncludeWriteOnlyProperties()
        {
            Assert.AreEqual("ObjectWithWriteOnlyProperty (  )", new ObjectWithWriteOnlyProperty().ReflectionToString());
        }
        
    }

    class ListWithAList
    {
        private List<SimpleTestObjectWithList> list;
        private string s;
        public ListWithAList(string s, List<SimpleTestObjectWithList> list)
        {
            this.list = list;
            this.s = s;
        }
    }

    class SimpleTestObjectWithList
    {
        private int i;
        private List<SimpleTestObject> list;

        public SimpleTestObjectWithList(int i, List<SimpleTestObject> list)
        {
            this.i = i;
            this.list = list;
        }
    }
    class SimpleTestObject
    {
        private int i;
        private string s;

        public SimpleTestObject(int i, string s)
        {
            this.i = i;
            this.s = s;
        }

        public int I
        {
            get { return i; }
        }

        public string S
        {
            get { return s; }
        }
    }

    class ExampleObjectContainingASet
    {
        public Set<string> s = new Set<string>();
        public int i;
    }

    class SimpleTestObjectWithPrivateProperties
    {
        private int i;
        private string s;

        public SimpleTestObjectWithPrivateProperties(int i, string s)
        {
            this.i = i;
            this.s = s;
        }

        public int I
        {
            get { return i; }
            set { i = value; }
        }

        public string S
        {
            get { return s; }
            set { s = value; }
        }
    }

    class SimpleObjectForTesting
    {
        public int i;
        public string s;

        public SimpleObjectForTesting(int i, string s)
        {
            this.i = i;
            this.s = s;
        }
    }

    class ObjectWithWriteOnlyProperty
    {
        public int Value
        {
            set { }
        }

    }

}
