using Castle.DynamicProxy;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Caching
{
    [TestFixture]
    public class CacheInsertOrUpdateInterceptorTest
    {
        private ICache mockCache;
        private ProxyGenerator proxyGenerator;

        [SetUp]
        public void SetUp()
        {
            mockCache = MockRepository.GenerateMock<ICache>();
            proxyGenerator = new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));
        }

        [Ignore] [Test]
        public void ShouldClearQueryBySiteIdCacheWhenDoingAnUpdate()
        {
            CacheInsertOrUpdateInterceptor interceptor = new CacheInsertOrUpdateInterceptor(mockCache);

            TestInterface testClass = new TestClass();
            TestInterface testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, interceptor);
            
            TestDomainObject testDomainObject = new TestDomainObject(9);

            string updateCacheKey = CacheKeyGenerator.GenerateQueryByIdKey(testDomainObject);
            string queryAllBySiteIdCacheKey = CacheKeyGenerator.GenerateQueryAllBySiteIdCachingKey(testDomainObject.GetType(), testDomainObject.SiteId);

            mockCache.Expect(m => m.Update(updateCacheKey, testDomainObject));
            mockCache.Expect(m => m.Remove(queryAllBySiteIdCacheKey));

            testclassProxy.Update(testDomainObject);

            mockCache.VerifyAllExpectations();
            Assert.True(true);
        }

        [Ignore] [Test]
        public void ShouldRemoveRelatedItemsWhenDoingAnUpdate()
        {
            CacheInsertOrUpdateInterceptor insertOrUpdateInterceptor = new CacheInsertOrUpdateInterceptor(mockCache);
            TestInterfaceWithNoRelatedCachesToExpire testService = new TestClasswithNoReleatedCachesToExpire();
            TestInterfaceWithNoRelatedCachesToExpire testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testService, insertOrUpdateInterceptor);

            TestDomainObject domainObject = new TestDomainObject(100);

            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(domainObject);

            mockCache.Expect(m => m.Update(cachingKey, domainObject));
            
            mockCache.Expect(m => m.Get(cachingKey + ":REL")).Return("SomeOtherObject:100,AnotherObject:200");
            
            mockCache.Expect(m => m.Remove("SomeOtherObject:100"));
            mockCache.Expect(m => m.Remove("AnotherObject:200"));
            mockCache.Expect(m => m.Remove("SomeOtherObject:100,AnotherObject:200"));
            
            testclassProxy.Update(domainObject);

            mockCache.VerifyAllExpectations();
            Assert.True(true);
        }

        [Ignore] [Test]
        public void ShouldCreateRelationshipsWhenDoingAnUpdate()
        {
            CacheInsertOrUpdateInterceptor insertOrUpdateInterceptor = new CacheInsertOrUpdateInterceptor(mockCache);
            TestInterface2 testService = new TestInterface2Impl();
            TestInterface2 testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testService, insertOrUpdateInterceptor);

            TestDomainObject domainObject2 = new TestDomainObject(100);
            TestDomainObjectContainingTestDomainObject domainObject = new TestDomainObjectContainingTestDomainObject(1, domainObject2);

            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(domainObject);

            string cachingKeyOfRelatedItem = CacheKeyGenerator.GenerateQueryByIdKey(domainObject2);

            mockCache.Expect(m => m.Update(cachingKey, domainObject));

            mockCache.Expect(m => m.Get(cachingKey + ":REL")).Return(null);

            mockCache.Expect(m => m.Get(cachingKeyOfRelatedItem + ":REL")).Return(null);
            mockCache.Expect(m => m.Update(cachingKeyOfRelatedItem + ":REL", cachingKey));

            testclassProxy.Update(domainObject);

            mockCache.VerifyAllExpectations();
            Assert.True(true);
        }

        [Ignore] [Test]
        public void ShouldAppendToExistingRelationshipsWhenDoingAnUpdate()
        {
            CacheInsertOrUpdateInterceptor insertOrUpdateInterceptor = new CacheInsertOrUpdateInterceptor(mockCache);
            TestInterface2 testService = new TestInterface2Impl();
            TestInterface2 testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testService, insertOrUpdateInterceptor);

            TestDomainObject domainObject2 = new TestDomainObject(100);
            TestDomainObjectContainingTestDomainObject domainObject = new TestDomainObjectContainingTestDomainObject(1, domainObject2);

            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(domainObject);

            string cachingKeyOfRelatedItem = CacheKeyGenerator.GenerateQueryByIdKey(domainObject2);

            mockCache.Expect(m => m.Update(cachingKey, domainObject));

            mockCache.Expect(m => m.Get(cachingKey + ":REL")).Return(null);

            mockCache.Expect(m => m.Get(cachingKeyOfRelatedItem + ":REL")).Return("Someotheritem:100");
            mockCache.Expect(m => m.AppendToExistingItem(cachingKeyOfRelatedItem + ":REL", cachingKey));

            testclassProxy.Update(domainObject);

            mockCache.VerifyAllExpectations();
            Assert.True(true);
        }

    }
}