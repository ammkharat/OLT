using Castle.DynamicProxy;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Caching
{
    [TestFixture]
    public class CacheQueryByIdInterceptorTest
    {
        private ICache mockCache;
        private ProxyGenerator proxyGenerator;

        [SetUp]
        public void SetUp()
        {
            mockCache = MockRepository.GenerateStrictMock<ICache>();
            proxyGenerator = new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));
        }

        [Ignore] [Test]
        public void ShouldGetObjectFromCacheWhenInterceptorIsOnTestClass()
        {
            CacheQueryByIdInterceptor interceptor = new CacheQueryByIdInterceptor(mockCache);
            
            TestInterface testClass = new TestClass();
            TestInterface testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, interceptor);

            TestDomainObject testDomainObjectForInterceptor = new TestDomainObject(1L) {OtherData = "CameFromCache"};
            mockCache.Expect(m => m.Get(CacheKeyGenerator.GenerateQueryByIdKey(testDomainObjectForInterceptor))).Return(testDomainObjectForInterceptor);
            
            TestDomainObject result = testclassProxy.QueryById(1L);

            Assert.That(result.OtherData, Is.EqualTo("CameFromCache"));

            mockCache.VerifyAllExpectations();
        }


        [Ignore] [Test]
        public void ShouldGetObjectFromRealClassAndCacheResultWhenNotInitiallyInTheCache()
        {
            CacheQueryByIdInterceptor interceptor = new CacheQueryByIdInterceptor(mockCache);

            TestInterface testClass = new TestClass();
            TestInterface testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, interceptor);

            TestDomainObject testDomainObject = new TestDomainObject(1L);

            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(testDomainObject);
            mockCache.Expect(m => m.Get(cachingKey)).Return(null);
            mockCache.Expect(m => m.Update(cachingKey, testDomainObject));

            TestDomainObject result = testclassProxy.QueryById(1L);

            Assert.That(result.IdValue, Is.EqualTo(1L));

            mockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldCreateRelationshipsWhenDoingAnQueryThatGetsFromtheDbBecauseItIsNotInTheCache()
        {
            CacheQueryByIdInterceptor interceptor = new CacheQueryByIdInterceptor(mockCache);
            TestInterface2 testService = new TestInterface2Impl();
            TestInterface2 testclassProxy = proxyGenerator.CreateInterfaceProxyWithTarget(testService, interceptor);

            long id2 = 100;
            TestDomainObject domainObject2 = new TestDomainObject(id2);

            long id = 1;
            TestDomainObjectContainingTestDomainObject mainDomainObject = new TestDomainObjectContainingTestDomainObject(id, domainObject2);

            string mainCachingKey = CacheKeyGenerator.GenerateQueryByIdKey(mainDomainObject);

            string cachingKeyOfRelatedItem = CacheKeyGenerator.GenerateQueryByIdKey(domainObject2);

            mockCache.Expect(m => m.Get(mainCachingKey)).Return(null);
            
            mockCache.Expect(m => m.Update(mainCachingKey, mainDomainObject));

            mockCache.Expect(m => m.Get(cachingKeyOfRelatedItem + ":REL")).Return(null);
            mockCache.Expect(m => m.Update(cachingKeyOfRelatedItem + ":REL", mainCachingKey));

            testclassProxy.QueryById(mainDomainObject.IdValue);

            mockCache.VerifyAllExpectations();
            Assert.True(true);
        }

    }
}