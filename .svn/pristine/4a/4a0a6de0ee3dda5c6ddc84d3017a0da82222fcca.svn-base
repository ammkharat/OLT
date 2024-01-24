using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Extension
{
    [TestFixture]
    public class CollectionExtensionsTest
    {
        private static readonly Random random = new Random((int) DateTime.Now.Ticks); //thanks to McAden

        [Test]
        public void MapEqualityTest()
        {
            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                Assert.IsTrue(map1.ValueEquals(map2));
            }

            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                LoadMapsForEqualityTest(map1, map2);

                Assert.IsTrue(map1.ValueEquals(map2));
            }

            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                LoadMapsForEqualityTest(map1, map2);

                map1[1] = 2;
                map1[2] = 1;

                map2[1] = 2;
                map2[2] = 1;

                Assert.IsTrue(map1.ValueEquals(map2));
            }

            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                LoadMapsForEqualityTest(map1, map2);

                map1[1] = 2;
                map1[2] = 1;

                map2[1] = 2;
                map2[2] = 5;

                Assert.IsFalse(map1.ValueEquals(map2));
            }

            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                LoadMapsForEqualityTest(map1, map2);

                map2.Add(42, 0);

                Assert.IsFalse(map1.ValueEquals(map2));
            }

            {
                var map1 = new Dictionary<long, int>();
                var map2 = new Dictionary<long, int>();

                LoadMapsForEqualityTest(map1, map2);

                map1.Add(42, 0);

                Assert.IsFalse(map1.ValueEquals(map2));
            }
        }

        [Test]
        public void PerformanceOfConverterSortVersusComparableSort()
        {
            var listOfFlocs = CreateListOfFlocs();

            var flocsA = new List<FunctionalLocation>(listOfFlocs);
            flocsA.Sort((a, b) => string.Compare(a.FullHierarchy, b.FullHierarchy, StringComparison.CurrentCulture));

            var flocsB = new List<FunctionalLocation>(listOfFlocs);
            flocsB.Sort(floc => floc.FullHierarchy);

            CollectionAssert.AreEqual(flocsA, flocsB);
        }

        [Test]
        public void ShouldAddIfNotNull()
        {
            var list = new List<DomainObjectSample>();
            var item = new DomainObjectSample(1);
            list.AddIfNotNull(item);
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void ShouldAddItemThatDoesNotExist()
        {
            var items = new List<string> {"A", "C", "D"};
            items.AddAndSort("B");
            Assert.That(items.Count, Is.EqualTo(4));
            Assert.That(items[1], Is.EqualTo("B"));
        }

        [Test]
        public void ShouldAddItemsSinceNoneExist()
        {
            var list = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listToAdd = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(11),
                FunctionalLocationFixture.CreateNew(12),
                FunctionalLocationFixture.CreateNew(13),
                FunctionalLocationFixture.CreateNew(14)
            };

            list.AddNonDuplicatesById(listToAdd);
            Assert.That(list.Count, Is.EqualTo(8));
        }


        [Test]
        public void ShouldBeAbleToSortFirstNameAndLastNameWithCommasProperly()
        {
            var items = new List<TestSort>
            {
                new TestSort("Arc, Adam", 2),
                new TestSort("Archy, Aaron", 3),
                new TestSort("Arc, Aaron", 1)
            };

            items.Sort(i => i.Name, true);

            Assert.That(items[0].SortResult, Is.EqualTo(1));
            Assert.That(items[1].SortResult, Is.EqualTo(2));
            Assert.That(items[2].SortResult, Is.EqualTo(3));
        }

        [Test]
        public void ShouldBeSameById()
        {
            var listA = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listB = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4),
                FunctionalLocationFixture.CreateNew(1)
            };

            Assert.That(listA.AreSameById(listB), Is.True);
        }

        [Test]
        public void ShouldCheckEqualsByElement()
        {
            {
                var list1 = new List<string> {"a", "b"};
                var list2 = new List<string> {"a", "b"};
                Assert.IsTrue(list1.EqualsByElement(list2));
                Assert.IsTrue(list2.EqualsByElement(list1));
            }
            {
                var list1 = new List<string> {"a", "b"};
                var list2 = new List<string> {"b", "a"};
                Assert.IsTrue(list1.EqualsByElement(list2));
                Assert.IsTrue(list2.EqualsByElement(list1));
            }
            {
                var list1 = new List<string> {"a", "b", "c"};
                var list2 = new List<string> {"b", "a"};
                Assert.IsFalse(list1.EqualsByElement(list2));
                Assert.IsFalse(list2.EqualsByElement(list1));
            }
            {
                var list1 = new List<string>();
                var list2 = new List<string> {"b", "a"};
                Assert.IsFalse(list1.EqualsByElement(list2));
                Assert.IsFalse(list2.EqualsByElement(list1));
            }
            {
                List<string> list1 = null;
                var list2 = new List<string> {"b", "a"};
                Assert.IsFalse(list1.EqualsByElement(list2));
                Assert.IsFalse(list2.EqualsByElement(list1));
            }
            {
                List<string> list1 = null;
                List<string> list2 = null;
                Assert.IsFalse(list1.EqualsByElement(list2));
                Assert.IsFalse(list2.EqualsByElement(list1));
            }
        }

        [Test]
        public void ShouldChunkListIntoBatches()
        {
            var list = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            var chunks5 = list.Chunkify(2);
            Assert.AreEqual(chunks5.Select(ints => ints.ToArray()).Count(), 5);

            var chunks4 = list.Chunkify(3);
            Assert.AreEqual(chunks4.Select(ints => ints.ToArray()).Count(), 4);

            var chunks3 = list.Chunkify(4);
            Assert.AreEqual(chunks3.Select(ints => ints.ToArray()).Count(), 3);

            var chunks2 = list.Chunkify(5);
            Assert.AreEqual(chunks2.Select(ints => ints.ToArray()).Count(), 2);

            var chunks1 = list.Chunkify(22);
            Assert.AreEqual(chunks1.Select(ints => ints.ToArray()).Count(), 1);
        }

        [Test]
        public void ShouldClassify()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var three = new DomainObjectSample(3);
            var four = new DomainObjectSample(4);
            var five = new DomainObjectSample(5);

            var list = new List<DomainObjectSample> {three, five, one, two, four};
            var trueList = new List<DomainObjectSample>();
            var falseList = new List<DomainObjectSample>();

            list.Classify(trueList, falseList, item => item.IdValue%2 == 0);
            Assert.That(trueList.Count, Is.EqualTo(2));
            Assert.That(falseList.Count, Is.EqualTo(3));

            Assert.That(trueList, Has.Member(two));
            Assert.That(trueList, Has.Member(four));
        }

        [Test]
        public void ShouldConvertAll()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var three = new DomainObjectSample(null);
            ICollection list = new List<DomainObjectSample> {one, two, three};

            var result = list.ConvertAll<long?, DomainObjectSample>(item => item.Id);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.Member(null));
            Assert.That(result, Has.Member(1));
            Assert.That(result, Has.Member(2));
        }

        [Test]
        public void ShouldCountAllThingsInTheListMatchingTheCondition()
        {
            var numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Assert.AreEqual(5, numbers.Count(i => i%2 == 0));
            Assert.AreEqual(1, numbers.Count(i => i == 9));
            Assert.AreEqual(3, numbers.Count(i => i > 7));
        }

        [Test]
        public void ShouldDetermineIfAllItemsAreEqual()
        {
            {
                var strings = new List<string>();
                strings.Add("item");
                strings.Add("item");
                strings.Add("item");
                strings.Add("item");
                strings.Add("item");
                Assert.IsTrue(strings.AllMembersAreEqual());
            }

            {
                var strings = new List<string>();
                strings.Add("item");
                strings.Add("item");
                strings.Add("different item");
                strings.Add("item");
                strings.Add("item");
                Assert.IsFalse(strings.AllMembersAreEqual());
            }

            {
                var strings = new List<object>();
                strings.Add(1338);
                strings.Add(null);
                strings.Add("1338");
                strings.Add(strings);
                Assert.IsFalse(strings.AllMembersAreEqual());
            }

            {
                var strings = new List<object>();
                strings.Add(1338);
                strings.Add(null);
                strings.Add("1338");
                strings.Add(strings);
                Assert.IsFalse(strings.AllMembersAreEqual());
            }

            {
                var strings = new List<string>();
                strings.Add("item");
                strings.Add("item");
                strings.Add(null);
                strings.Add("item");
                strings.Add("item");
                Assert.IsFalse(strings.AllMembersAreEqual());
            }

            {
                var strings = new List<string>();
                strings.Add(null);
                strings.Add(null);
                strings.Add(null);
                Assert.IsTrue(strings.AllMembersAreEqual());
            }
        }

        [Test]
        public void ShouldDetermineIfExistsByIdForIdList()
        {
            var idList = new List<long> {1, 2, 3, 4, 5, 12345, 64, 27};

            var someLog = LogFixture.CreateLog(false);
            someLog.Id = 12345;

            var anotherLog = LogFixture.CreateLog(false);
            anotherLog.Id = 42;

            Assert.IsTrue(idList.IdIsInList(someLog));
            Assert.IsFalse(idList.IdIsInList(anotherLog));
        }

        [Test]
        public void ShouldFindOneOf()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var three = new DomainObjectSample(3);

            {
                var list = new List<DomainObjectSample> {one, three};
                Assert.That(one.IsOneOf(list), Is.True);
            }

            {
                var list = new List<DomainObjectSample> {one, three};
                Assert.That(two.IsOneOf(list), Is.False);
            }

            {
                var list = new List<DomainObjectSample> {one, three};
                Assert.That(one.IsOneOf(two, one, three), Is.True);
            }

            {
                Assert.That(two.IsOneOf(one, three), Is.False);
            }

            {
                var hashSet = new HashSet<DomainObjectSample> {one, three};
                Assert.That(one.IsOneOf(hashSet), Is.True);
            }

            {
                var hashSet = new HashSet<DomainObjectSample> {one, three};
                Assert.That(two.IsOneOf(hashSet), Is.False);
            }

            {
                var a = new TestSimpleDomainObject(1, "a");
                var b = new TestSimpleDomainObject(2, "b");

                var hashSet = new HashSet<TestSimpleDomainObject> {a, b};

                var testObj = new TestSimpleDomainObject(1, "AAAA");
                Assert.That(testObj.IsOneOf(hashSet), Is.True);

                testObj = new TestSimpleDomainObject(5, "a");
                Assert.That(testObj.IsOneOf(hashSet), Is.False);
            }

            {
                var a = new TestSimpleDomainObject(1, "a");
                var b = new TestSimpleDomainObject(2, "b");

                var hashSet = new HashSet<TestSimpleDomainObject>(new TestSimpleDomainObjectNameComparer()) {a, b};

                var testObj = new TestSimpleDomainObject(1, "AAAA");
                Assert.That(testObj.IsOneOf(hashSet), Is.False);

                testObj = new TestSimpleDomainObject(5, "a");
                Assert.That(testObj.IsOneOf(hashSet), Is.True);
            }
        }

        [Test]
        public void ShouldFindUniqueElements()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var three = new DomainObjectSample(3);
            var anotherThree = new DomainObjectSample(3);
            var anotherTwo = new DomainObjectSample(2);

            var list = new List<DomainObjectSample> {three, one, anotherTwo, two, anotherThree};

            {
                var resultingList = list.Unique(dos => dos.Id);
                Assert.AreEqual(3, resultingList.Count);
                Assert.IsTrue(resultingList.Exists(dos => dos.Id == 1));
                Assert.IsTrue(resultingList.Exists(dos => dos.Id == 2));
                Assert.IsTrue(resultingList.Exists(dos => dos.Id == 3));
            }

            var numberList = new List<long> {3, 1, 2, 2, 3};
            {
                var resultingList = numberList.Unique();
                Assert.AreEqual(3, resultingList.Count);
                Assert.IsTrue(resultingList.Contains(1));
                Assert.IsTrue(resultingList.Contains(2));
                Assert.IsTrue(resultingList.Contains(3));
            }
        }

        [Test]
        public void ShouldFlattenListOfLists()
        {
            var list1 = new List<string> {"a", "b", "c"};
            var list2 = new List<string> {"d", "e", "f"};

            var listOfLists = new List<List<string>> {list1, list2};
            var flattenedList = listOfLists.Flatten();

            Assert.AreEqual(new List<string> {"a", "b", "c", "d", "e", "f"}, flattenedList);
        }

        [Test]
        public void ShouldGetItemsInListOneNotInListTwo()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var three = new DomainObjectSample(3);

            var listOne = new List<DomainObjectSample> {one, three, two};
            var listTwo = new List<DomainObjectSample> {two, one};

            var notInListTwo = listOne.ItemsNotIn(listTwo);
            Assert.That(notInListTwo.Count, Is.EqualTo(1));
            Assert.That(notInListTwo[0], Is.EqualTo(three));
        }

        [Test]
        public void ShouldGetLastItemFromList()
        {
            var items = new List<int> {21, 56, 57, 25, 1, 11, 2};

            Assert.That(items.Last(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetLastTwoItemsFromList()
        {
            var items = new List<int> {21, 56, 57, 25, 1, 11, 2};

            CollectionAssert.AreEquivalent(items.Last(2), new List<int> {11, 2});
        }

        [Test]
        public void ShouldGroupByFirstLetter()
        {
            var items = new List<string>
            {
                "A" + RandomString(3),
                "A" + RandomString(2),
                "A" + RandomString(6),
                "A" + RandomString(9),
                "Z" + RandomString(30),
                "B",
                "B" + RandomString(1),
                "B" + RandomString(3)
            };


            var groupBy = items.GroupUsing(item => item.Substring(0, 1));
            Assert.That(groupBy.Keys.Count, Is.EqualTo(3));
            Assert.That(groupBy["Z"].Count, Is.EqualTo(1));
            Assert.That(groupBy["B"].Count, Is.EqualTo(3));
            Assert.That(groupBy["B"].Contains("B"), Is.True);
        }

        [Test]
        public void ShouldNotAddIfNotNull()
        {
            var list = new List<DomainObjectSample>();
            DomainObjectSample item = null;
            list.AddIfNotNull(item);
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShouldNotAddItemThatExistsAlready()
        {
            var items = new List<string> {"A", "C", "D"};
            items.AddAndSort("C");
            Assert.That(items.Count, Is.EqualTo(3));
            Assert.That(items[1], Is.EqualTo("C"));
        }

        [Test]
        public void ShouldNotAddItemsSinceAllExist()
        {
            var list = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listToAdd = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            list.AddNonDuplicatesById(listToAdd);
            Assert.That(list.Count, Is.EqualTo(4));
        }

        [Test]
        public void ShouldNotBeSameById()
        {
            var listA = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listB = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(5),
                FunctionalLocationFixture.CreateNew(1)
            };

            Assert.That(listA.AreSameById(listB), Is.False);
        }

        [Test]
        public void ShouldOnlyAddItemOnceThatDoNotExist()
        {
            var list = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listToAdd = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(12),
                FunctionalLocationFixture.CreateNew(12)
            };

            list.AddNonDuplicatesById(listToAdd);
            Assert.That(list.Count, Is.EqualTo(5));
        }

        [Test]
        public void ShouldOnlyAddItemsThatDoNotExist()
        {
            var list = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var listToAdd = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(12),
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(14)
            };

            list.AddNonDuplicatesById(listToAdd);
            Assert.That(list.Count, Is.EqualTo(6));
        }

        [Test]
        public void ShouldRemoveARangeOfItems()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            var four = new DomainObjectSample(4);
            var five = new DomainObjectSample(5);
            var list = new List<DomainObjectSample> {one, two, four, five};
            var itemsToRemove = new List<DomainObjectSample> {four, one};

            list.RemoveRange(itemsToRemove);
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list, Has.Member(two));
            Assert.That(list, Has.Member(five));
            Assert.That(list, Has.No.Member(one));
            Assert.That(list, Has.No.Member(four));
        }


        [Test]
        public void ShouldReturnAll()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            ICollection list = new List<DomainObjectSample> {one, two};

            list.ForEach<DomainObjectSample>(item => item.Id = item.Id + 10);
            Assert.That(list, Has.Some.Property("IdValue").EqualTo(11));
            Assert.That(list, Has.Some.Property("IdValue").EqualTo(12));
        }

        [Test]
        public void ShouldReturnFalseWhenSecondListDoesNotHaveAtLeastOneItemInTheFirstList()
        {
            var firstList = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2)
            };

            var secondList = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(3),
                FunctionalLocationFixture.CreateNew(4)
            };

            var result = firstList.Overlap(secondList);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldReturnTrueWhenSecondListHasAtLeastOneItemInTheFirstList()
        {
            var firstList = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(1),
                FunctionalLocationFixture.CreateNew(2)
            };

            var secondList = new List<FunctionalLocation>
            {
                FunctionalLocationFixture.CreateNew(2),
                FunctionalLocationFixture.CreateNew(3)
            };

            var result = firstList.Overlap(secondList);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ShouldSliceListIntoBatches()
        {
            var list = new List<string> {"a", "b", "c", "d", "e"};

            {
                var slices = new List<List<string>>();
                list.ForEachSlice(3, slices.Add);

                Assert.AreEqual(2, slices.Count);

                Assert.AreEqual(3, slices[0].Count);
                Assert.Contains("a", slices[0]);
                Assert.Contains("b", slices[0]);
                Assert.Contains("c", slices[0]);

                Assert.AreEqual(2, slices[1].Count);
                Assert.Contains("d", slices[1]);
                Assert.Contains("e", slices[1]);
            }

            {
                var slices = new List<List<string>>();
                list.ForEachSlice(10, slices.Add);

                Assert.AreEqual(1, slices.Count);

                Assert.AreEqual(5, slices[0].Count);
                Assert.Contains("a", slices[0]);
                Assert.Contains("b", slices[0]);
                Assert.Contains("c", slices[0]);
                Assert.Contains("d", slices[0]);
                Assert.Contains("e", slices[0]);
            }
        }

        [Test]
        public void ShouldSortByColumnsGoingDownEachColumn()
        {
            var list = new List<string> {"A", "B", "C", "D", "E"};
            var result = list.SortByColumnsGoingDownEachColumn(3);

            Assert.That(result[0], Is.EqualTo("A"));
            Assert.That(result[3], Is.EqualTo("B"));

            Assert.That(result[1], Is.EqualTo("C"));
            Assert.That(result[4], Is.EqualTo("D"));

            Assert.That(result[2], Is.EqualTo("E"));
        }

        [Test]
        public void TrueForAllShouldBeTrue()
        {
            var one = new DomainObjectSample(1);
            var two = new DomainObjectSample(2);
            IList<DomainObjectSample> list = new List<DomainObjectSample> {one, two};

            {
                Assert.That(list.TrueForAll(i => i.Id < 3), Is.True);
            }

            {
                Assert.That(list.TrueForAll(i => i.Id == 1), Is.False);
            }
        }

        private List<FunctionalLocation> CreateListOfFlocs()
        {
            var flocs = new List<FunctionalLocation>(1875);

            var id = 1;
            for (var i = 0; i < 3; i++)
            {
                var level1 = RandomString(3);
                flocs.Add(FunctionalLocationFixture.CreateNew(id++, level1));

                for (var j = 0; j < 5; j++)
                {
                    var level2 = RandomString(4);
                    flocs.Add(FunctionalLocationFixture.CreateNew(id++, string.Format("{0}-{1}", level1, level2)));

                    for (var k = 0; k < 5; k++)
                    {
                        var level3 = RandomString(4);
                        flocs.Add(FunctionalLocationFixture.CreateNew(id++,
                            string.Format("{0}-{1}-{2}", level1, level2, level3)));

                        for (var l = 0; l < 5; l++)
                        {
                            var level4 = RandomString(5);
                            flocs.Add(FunctionalLocationFixture.CreateNew(id++,
                                string.Format("{0}-{1}-{2}-{3}", level1, level2, level3, level4)));

                            for (var m = 0; m < 5; m++)
                            {
                                var level5 = RandomString(5);
                                flocs.Add(FunctionalLocationFixture.CreateNew(id++,
                                    string.Format("{0}-{1}-{2}-{3}-{4}", level1, level2, level3, level4, level5)));
                            }
                        }
                    }
                }
            }

            return flocs;
        }

        private string RandomString(int size)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26*random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        private class TestSimpleDomainObject : SimpleDomainObject
        {
            private readonly string name;

            public TestSimpleDomainObject(long id, string name) : base(id)
            {
                this.name = name;
            }

            public override string GetName()
            {
                return name;
            }
        }

        private class TestSimpleDomainObjectNameComparer : IEqualityComparer<TestSimpleDomainObject>
        {
            public bool Equals(TestSimpleDomainObject x, TestSimpleDomainObject y)
            {
                // This is not complete enough for anything other than the test it is being used for. Doesn't check for nulls or anything like that.
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(TestSimpleDomainObject obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        private class DomainObjectSample : DomainObject
        {
            public DomainObjectSample(long? id)
            {
                Id = id;
            }
        }

        private void LoadMapsForEqualityTest(Dictionary<long, int> map1, Dictionary<long, int> map2)
        {
            map1.Add(1, 1);
            map1.Add(2, 2);
            map1.Add(3, 3);

            map2.Add(1, 1);
            map2.Add(2, 2);
            map2.Add(3, 3);
        }
    }

    public class TestSort
    {
        public TestSort(string name, int sortResult)
        {
            Name = name;
            SortResult = sortResult;
        }

        public int SortResult { get; set; }

        public string Name { get; set; }
    }
}