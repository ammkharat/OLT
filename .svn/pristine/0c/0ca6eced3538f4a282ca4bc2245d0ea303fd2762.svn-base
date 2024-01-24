using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class DifferenceBuilderTest
    {
        readonly SimpleTestObject simpleObjectVersion1 = new SimpleTestObject(1, "one");
        readonly SimpleTestObject simpleObjectVersion2 = new SimpleTestObject(1, "two");
        readonly SimpleTestObject simpleObjectVersion3 = new SimpleTestObject(2, "two");
        readonly SimpleTestObject simpleObjectVersion4 = new SimpleTestObject(2, "two");

        [TearDown]
        public void TearDown()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();    
        }

        [Test]
        public void ChangingAStringOnASimpleObjectShouldReturnThatFieldAsAChange()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion2).ReflectionAppendAll().Changes;
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"), changes[0]);
        }

        [Test]
        public void ChangingNothingOnASimpleObjectShouldReturnAnEmptyListOfChanges()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion3, simpleObjectVersion4).ReflectionAppendAll().Changes;
            Assert.AreEqual(0, changes.Count);
        }

        [Test]
        public void ChangingTwoValuesOnASimpleObjectShouldReturnTwoChanges()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion4).ReflectionAppendAll().Changes;
            Assert.AreEqual(2, changes.Count);
            CollectionAssert.Contains(changes, new LocalizedPropertyChange(typeof(SimpleTestObject), "I", string.Empty, 1, 2));
            CollectionAssert.Contains(changes, new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"));
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void PassingTwoDifferentTypesIntoReflectionDifferenceShouldThrowAnException()
        {
            new DifferenceBuilder(simpleObjectVersion1, "Stan Schmengie");
        }


        [Test]
        public void BuildDifferenceForTwoObjectsByAppendingEachField()
        {
            List<PropertyChange> changes =
                new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion4).ReflectionAppendAll().Changes;

            Assert.AreEqual(2, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "I", string.Empty, 1, 2), changes[0]);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"), changes[1]);
        }


        [Test]
        public void BuildDifferenceForTwoObjectUsingReflectionAppend()
        {
            List<PropertyChange> changes =
                new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion4).ReflectionAppendAll().Changes;

            Assert.AreEqual(2, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "I", string.Empty, 1, 2), changes[0]);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"), changes[1]);
        }

        [Test]
        public void BuildDifferenceForSubsetOfTwoObjectsUsingReflectionAppend()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion2).ReflectionAppendAll().Changes;

            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"), changes[0]);
        }

        [Test]
        public void UseDescriptiveFieldLabelWithReflectionAppend()
        {
            List<PropertyChange> changes = new DifferenceBuilder(new Blah("one"), new Blah("two"))
                                        .ReflectionAppendAll("String Field").Changes;

            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(Blah), "FieldA", "String Field", "one", "two"), changes[0]);
        }

        private class Blah
        {
            public string FieldA { get; set; }

            public Blah(string fieldA)
            {
                FieldA = fieldA;
            }
        }

        [Test, ExpectedException(typeof(ApplicationException))]
        public void PassingTwoDifferentTypesIntoConstructorShouldThrowAnException()
        {
            new DifferenceBuilder(simpleObjectVersion1, "Stan Schmengie");
        }

        [Test]
        public void BuildDifferenceForSubsetOfTwoObjectsUsingAppend()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion2)
                                        .ReflectionAppendAll()
                                        .Changes;

            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "S", string.Empty, "one", "two"), changes[0]);
        }

        [Test]
        public void AppendAllFieldsByReflectionAndThenOmitFields()
        {
            
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion4)
                                        .ReflectionAppendAll()
                                        .Ignore("S")
                                        .Changes;

            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(SimpleTestObject), "I", string.Empty, 1, 2), changes[0]);
        }

        [Test]
        public void AppendAndIgnoreSameFieldShouldUltimatelyIgnoreTheField()
        {
            List<PropertyChange> changes = new DifferenceBuilder(simpleObjectVersion1, simpleObjectVersion2)
                                .ReflectionAppendAll()                            
                                .Ignore("S")
                            
                            .Changes;

            Assert.AreEqual(0, changes.Count);
        }

        [Test]
        public void GetDifferencesOfTwoTargetDefinitionVersions()
        {
            TargetDefinition targetDefinitionVersion1 = TargetDefinitionFixture.CreateTargetDefinition();
            TargetDefinition targetDefinitionVersion2 = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinitionVersion2.MinValue = 3;
            targetDefinitionVersion2.MaxValue = 10;

            List<PropertyChange> changes = new DifferenceBuilder(targetDefinitionVersion1, targetDefinitionVersion2)
                                            .ReflectionAppendAll()
                                        .Ignore("Name")
                                        .Changes;

            Assert.AreEqual(2, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(TargetDefinition), "MinValue", string.Empty, targetDefinitionVersion1.MinValue, targetDefinitionVersion2.MinValue), changes[1]);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(TargetDefinition), "MaxValue", string.Empty, targetDefinitionVersion1.MaxValue, targetDefinitionVersion2.MaxValue), changes[0]);
        }

        [Test]
        public void GetDifferencesOfTwoTargetDefinitionVersionsUsingDescriptiveFieldLabels()
        {
            TargetDefinition targetDefinitionVersion1 = TargetDefinitionFixture.CreateTargetDefinition();
            TargetDefinition targetDefinitionVersion2 = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinitionVersion2.MinValue = 10;
            targetDefinitionVersion2.MinValue = 3;

            List<PropertyChange> changes = new DifferenceBuilder(targetDefinitionVersion1, targetDefinitionVersion2)
                                          .ReflectionAppendAll()
                                          .Ignore("Name")
                                        .Changes;

            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(new LocalizedPropertyChange(typeof(TargetDefinition), "MinValue", string.Empty, targetDefinitionVersion1.MinValue, targetDefinitionVersion2.MinValue), changes[0]);
        }

        [Test]
        public void ShouldGetDifferenceForAListUsingSimpleAgorithm()
        {
            List<ShiftHandoverAnswerHistory> answers1 = new List<ShiftHandoverAnswerHistory>
                                                            {
                                                                new ShiftHandoverAnswerHistory(0, 0, 0, "", false, "a"),
                                                                new ShiftHandoverAnswerHistory(0, 0, 0, "", true, "b")
                                                             };

            List<ShiftHandoverAnswerHistory> answers2 = new List<ShiftHandoverAnswerHistory>
                                                            {
                                                                new ShiftHandoverAnswerHistory(0, 0, 0, "", true, "c"),
                                                                new ShiftHandoverAnswerHistory(0, 0, 0, "", false, "d")
                                                            };

            ShiftHandoverQuestionnaireHistory obj1 = new ShiftHandoverQuestionnaireHistory(0, "floc", answers1,null, new DateTime());
            ShiftHandoverQuestionnaireHistory obj2 = new ShiftHandoverQuestionnaireHistory(0, "floc", answers2,null, new DateTime());

            List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
            Assert.AreEqual(4, changes.Count);
            Assert.AreEqual("No", changes[0].OriginalValue);
            Assert.AreEqual("Yes", changes[0].ChangedValue);
            Assert.AreEqual("a", changes[1].OriginalValue);
            Assert.AreEqual("c", changes[1].ChangedValue);
            Assert.AreEqual("Yes", changes[2].OriginalValue);
            Assert.AreEqual("No", changes[2].ChangedValue);
            Assert.AreEqual("b", changes[3].OriginalValue);
            Assert.AreEqual("d", changes[3].ChangedValue);
        }

        [Test]
        public void ShouldIgnorePropertiesWithIgnoreAttribute()
        {
            TestObjectWithIgnoreAttribute obj1 = new TestObjectWithIgnoreAttribute(1, 2);
            TestObjectWithIgnoreAttribute obj2 = new TestObjectWithIgnoreAttribute(3, 4);

            List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
            Assert.AreEqual(1, changes.Count);
            Assert.AreEqual(2, changes[0].OriginalValue);
            Assert.AreEqual(4, changes[0].ChangedValue);
        }

        [Test]
        public void ShouldDealWithDateTimesProperly()
        {
            DateTime dateTime = Clock.Now;

            TestObjectWithDateTimes obj1 = new TestObjectWithDateTimes(dateTime, dateTime);
            TestObjectWithDateTimes obj2 = new TestObjectWithDateTimes(dateTime, dateTime.AddDays(1));

            List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;

            Assert.AreEqual(1, changes.Count);
        }

        [Test]
        public void ShouldDealWithDateTimesProperlyWhenContainsNull()
        {
            DateTime dateTime = Clock.Now;

            TestObjectWithDateTimes obj1 = new TestObjectWithDateTimes(dateTime, null);
            TestObjectWithDateTimes obj2 = new TestObjectWithDateTimes(dateTime, dateTime);

            List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;

            Assert.AreEqual(1, changes.Count);
        }

        [Test]
        public void ShouldSetStringValueForBooleansToLocalizedString()
        {
            CultureInfoTestHelper.SetFormatsForFrenchFromResourceFile();                    
            TestObjectWithBool obj1 = new TestObjectWithBool(1, false);
            TestObjectWithBool obj2 = new TestObjectWithBool(1, true);

            List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
            Assert.That(changes.Count, Is.EqualTo(1));
            Assert.That(changes[0].OriginalValue, Is.EqualTo("Faux"));
            Assert.That(changes[0].ChangedValue, Is.EqualTo("Vrai"));
        }

        [Test]
        public void ShouldSetImageDifference()
        {
            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, null);
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, null);

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(0));
            }

            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, new byte[] {1, 2, 3});
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, new byte[] {1, 2, 3});

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(0));
            }

            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, null);
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, new byte[] { 1, 2, 3 });

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(1));
                Assert.That(changes[0].OriginalValue, Is.EqualTo("No image"));
                Assert.That(changes[0].ChangedValue, Is.EqualTo("Image added"));
            }

            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, new byte[] { 1, 2, 3 });
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, null);

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(1));
                Assert.That(changes[0].OriginalValue, Is.EqualTo("Image"));
                Assert.That(changes[0].ChangedValue, Is.EqualTo("Image removed"));
            }

            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, new byte[] { 1, 2, 3 });
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, new byte[] { 3, 2, 1 });

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(1));
                Assert.That(changes[0].OriginalValue, Is.EqualTo("Image"));
                Assert.That(changes[0].ChangedValue, Is.EqualTo("New version of image"));
            }

            {
                TestObjectWithImageAttribute obj1 = new TestObjectWithImageAttribute(1, new byte[] { 1, 2, 3 });
                TestObjectWithImageAttribute obj2 = new TestObjectWithImageAttribute(1, new byte[] { 1, 2, 3, 4 });

                List<PropertyChange> changes = new DifferenceBuilder(obj1, obj2).ReflectionAppendAll().Changes;
                Assert.That(changes.Count, Is.EqualTo(1));
                Assert.That(changes[0].OriginalValue, Is.EqualTo("Image"));
                Assert.That(changes[0].ChangedValue, Is.EqualTo("New version of image"));
            }
        }

        private class TestObjectWithBool
        {
            private readonly int Id;
            private readonly bool someBool;

            public TestObjectWithBool(int id, bool someBool)
            {
                Id = id;
                this.someBool = someBool;
            }

            public int Id1
            {
                get { return Id; }
            }

            public bool SomeBool
            {
                get { return someBool; }
            }
        }
        private class TestObjectWithDateTimes
        {
            private readonly DateTime start;
            private readonly DateTime? end;

            public TestObjectWithDateTimes(DateTime start, DateTime? end)
            {
                this.start = start;
                this.end = end;
            }

            public DateTime Start
            {
                get { return start; }
            }

            public DateTime? End
            {
                get { return end; }
            }
        }

        private class TestObjectWithIgnoreAttribute
        {
            private readonly int a;
            private readonly int b;

            public TestObjectWithIgnoreAttribute(int a, int b)
            {
                this.a = a;
                this.b = b;
            }

            [IgnoreDifference]
            public int A
            {
                get { return a; }
            }

            public int B
            {
                get { return b; }
            }
        }

        private class TestObjectWithImageAttribute
        {
            private readonly int a;
            private readonly byte[] image;

            public TestObjectWithImageAttribute(int a, byte[] image)
            {
                this.a = a;
                this.image = image;
            }

            public int A
            {
                get { return a; }
            }

            [ImageDifference]
            public byte[] Image
            {
                get { return image; }
            }
        }
    }
}
