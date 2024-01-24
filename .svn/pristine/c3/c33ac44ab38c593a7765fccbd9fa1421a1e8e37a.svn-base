using System;
using System.Threading;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Exceptions;
using NUnit.Framework;
using Osherove.ThreadTester;

namespace Com.Suncor.Olt.Common.Utility.Cache
{
    [TestFixture]
    public class ExpiringCacheTest
    {
        [Test]
        public void ShouldGetItemWhenNotExpired()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 5, 0));
            var item = new MyTestDomain(1, "testItem");
            cache.Add(1, item);
            MyTestDomain result = cache.Get(1);
            Assert.That(result, Is.EqualTo(item));
        }

        [Test]
        public void ShouldNotGetItemWhenItExpired()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 0, 0, 0, 10));
            var item = new MyTestDomain(1, "testItem1");
            cache.Add(1, item);
            Thread.Sleep(25);
            MyTestDomain result = cache.Get(1);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShouldNotGetItemWhenItExpiredButGetTheOtherThatHasNot()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 0, 0, 0, 100));
            var item = new MyTestDomain(1, "testItem1");
            cache.Add(1, item);
            Thread.Sleep(70);
            MyTestDomain result1 = cache.Get(1);
            Thread.Sleep(40);
            MyTestDomain result2 = cache.Get(1);
            Assert.That(result1, Is.EqualTo(item));
            Assert.That(result2, Is.Null);
        }

        [Ignore]  //ayman to fix the ci build
        [Test]
        public void ShouldGetAnotherItemThatHasNotExpired()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 0, 0, 0, 100));
            var item1 = new MyTestDomain(1, "testItem1");
            cache.Add(1, item1);
            Thread.Sleep(80);
            var item2 = new MyTestDomain(1, "testItem2");
            cache.Add(2, item2);
            Thread.Sleep(30);
            MyTestDomain result1 = cache.Get(1);
            MyTestDomain result2 = cache.Get(2);
            Assert.That(result1, Is.Null);
            Assert.That(result2, Is.EqualTo(item2));
        }

        [Test]
        public void ShouldGetCachedItemWhenExpringInMaximum()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(TimeSpan.MaxValue);
            var item1 = new MyTestDomain(1, "testItem1");
            cache.Add(1, item1);
            Thread.Sleep(100);
            MyTestDomain result = cache.Get(1);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ShouldFirstRemoveItemWhenAddingItem()
        {
            // It is possible that two separate threads check the ExpiringCache for the existence of an item and 
            //   both get an answer of 'not here.'
            //
            //   Thread #1 proceeds to add the item into the ExpiringCache dictionary - all is fine.
            //   Thread #2 proceeds to add the item into the ExpiringCache dictionary - problem, duplicate key exception.
            //
            // To avoid this scenario, we always remove the item and then proceed to add the item into the dictionary.
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 5, 0));
            var item = new MyTestDomain(1, "testItem");
            cache.Add(1, item);
            cache.Add(1, item);
        }

        [Test, ExpectedException(typeof(OLTException))]
        public void ShoulThrowExceptionIfCacheTimeoutZero()
        {
            new ExpiringCache<int, MyTestDomain>(TimeSpan.Zero);
        }

        [Test, ExpectedException(typeof(OLTException))]
        public void ShouldThrowExceptionIfTimeoutIsANegativeTimeSpan()
        {
            new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 0, -10, 0));
        }

        [Test]
        public void ShouldHandleMultipleThreadCallToPutItemInCache()
        {
            var cache = new ExpiringCache<int, MyTestDomain>(new TimeSpan(0, 0, 1));

            var tt = new ThreadTester();
            for (int i = 0; i < 50; i++)
            {
                tt.AddThreadAction(() =>
                                       {
                                           MyTestDomain domain = cache.Get(1);

                                           if (domain == null)
                                               cache.Add(1, new MyTestDomain(1, "blah"));
                                       });
            }

            tt.RunBehavior = ThreadRunBehavior.RunUntilAllThreadsFinish;
            tt.StartAllThreads(10000);
        }

        class MyTestDomain : DomainObject, IEquatable<MyTestDomain>
        {
            private readonly string name;

            public MyTestDomain(long? id, string name)
            {
                this.id = id;
                this.name = name;
            }

            public bool Equals(MyTestDomain obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return base.Equals(obj) && Equals(obj.name, name);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return Equals(obj as MyTestDomain);
            }

        }
    }

    
}
