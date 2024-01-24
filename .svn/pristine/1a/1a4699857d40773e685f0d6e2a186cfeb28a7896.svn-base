using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Remote.Caching
{
    public interface TestInterface
    {
        TestDomainObject QueryById(long id);

        TestDomainObject MethodWithNoAttributes(long id);

        [CachedQueryById]
        TestDomainObject QueryByIdWithAttribute(long id);

        [CachedQueryById]
        TestDomainObject QueryByIdWithTooManyArgs(long id, string secondArgThatMakesInterceptingFail);

        [CachedQueryBySiteId]
        List<TestDomainObject> QueryAllBySite(long siteId);

        [CachedInsertOrUpdate(true, false)]
        void Update(TestDomainObject testDomainObject);

        [CachedQueryList("whocares")]
        List<TestDomainObject> QueryListById(long someId);

        [CachedQueryBySiteId]
        List<TestDomainObjectWithNoSiteId> QueryAllBySiteBad(long siteId);

        [CachedQueryAll]
        List<TestDomainObject> QueryAll();

        [CachedQueryList("TestDomainObjectRoleSite")]
        List<TestDomainObject> QueryListBy(Site site, Role role);
    }

    public class TestClass : TestInterface
    {
        public TestDomainObject QueryById(long id)
        {
            return new TestDomainObject(id);
        }

        public TestDomainObject MethodWithNoAttributes(long id)
        {
            return new TestDomainObject(id) {OtherData = "Test class"};
        }

        public TestDomainObject QueryByIdWithAttribute(long id)
        {
            return new TestDomainObject(id);
        }

        public TestDomainObject QueryByIdWithTooManyArgs(long id, string secondArgThatMakesInterceptingFail)
        {
            return new TestDomainObject(id);
        }

        public List<TestDomainObject> QueryAllBySite(long siteId)
        {
            return new List<TestDomainObject> {new TestDomainObject(4), new TestDomainObject(5)};
        }

        public List<TestDomainObjectWithNoSiteId> QueryAllBySiteBad(long siteId)
        {
            return new List<TestDomainObjectWithNoSiteId>(0);
        }

        public List<TestDomainObject> QueryAll()
        {
            return new List<TestDomainObject>(0);
        }

        public List<TestDomainObject> QueryListBy(Site site, Role role)
        {
            return new List<TestDomainObject>(0);
        }

        public void Update(TestDomainObject testDomainObject)
        {
            
        }

        public List<TestDomainObject> QueryListById(long someId)
        {
            return new List<TestDomainObject>(0);
        }
    }

    public interface TestInterfaceWithNoRelatedCachesToExpire
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(TestDomainObject domainObject);
        [CachedInsertOrUpdate(false, false)]
        void Update(TestDomainObject domainObject);
        [CachedRemove(false, false)]
        void Remove(TestDomainObject domainObject);

        [CachedQuery("ItemByUsername")]
        void QueryByUsername(string username);

    }

    public  class TestClasswithNoReleatedCachesToExpire : TestInterfaceWithNoRelatedCachesToExpire
    {
        public void Insert(TestDomainObject domainObject)
        {
        }

        public void Update(TestDomainObject domainObject)
        {
        }

        public void Remove(TestDomainObject domainObject)
        {
        }

        public void QueryByUsername(string username)
        {
            
        }
    }

    public class TestDomainObjectWithNoSiteId : DomainObject
    {
            
    }

    [Serializable]
    public class TestDomainObject : DomainObject, ICacheBySiteId
    {
        public string OtherData { get; set; }

        public TestDomainObject(long id)
            : base(id)
        {
        }

        public long SiteId { get { return -99; } }
    }

    public interface TestInterface2
    {
        [CachedInsertOrUpdate(false, false)]
        void Insert(TestDomainObjectContainingTestDomainObject domainObject);
        [CachedInsertOrUpdate(false, false)]
        void Update(TestDomainObjectContainingTestDomainObject domainObject);
        [CachedRemove(false, false)]
        void Remove(TestDomainObjectContainingTestDomainObject domainObject);

        [CachedQueryById]
        TestDomainObjectContainingTestDomainObject QueryById(long id);

    }

    public class TestInterface2Impl : TestInterface2
    {
        public void Insert(TestDomainObjectContainingTestDomainObject domainObject)
        {
            
        }

        public void Update(TestDomainObjectContainingTestDomainObject domainObject)
        {
            
        }

        public void Remove(TestDomainObjectContainingTestDomainObject domainObject)
        {
            
        }

        public TestDomainObjectContainingTestDomainObject QueryById(long id)
        {
            return new TestDomainObjectContainingTestDomainObject(id, new TestDomainObject(id*100));
        }
    }

    [Serializable]
    public class TestDomainObjectContainingTestDomainObject : DomainObject
    {
        [CachedRelationship]
        public TestDomainObject TestDomainObject { get; private set; }

        public TestDomainObjectContainingTestDomainObject(long id, TestDomainObject otherItem): base(id)
        {
            TestDomainObject = otherItem;
        }
    }

    [CachePrefix("Schedule")]
    public interface ITestDao
    {
        [CachedQueryById]
        ITestInterface QueryById(long id);
        void Insert(ITestInterface item);
        void Update(ITestInterface item);
    }

    public class TestDao : ITestDao
    {
        public ITestInterface QueryById(long id)
        {
            return new TestClassImpl(id);
        }

        public void Insert(ITestInterface item)
        {
        }

        public void Update(ITestInterface item)
        {
        }
    }

    public interface ITestInterface
    {
        long Id { get; }
    }

    public class TestClassImpl : ITestInterface
    {
        public TestClassImpl(long id)
        {
            this.Id = id;
        }

        public long Id { get; private set; }
    }
}