using Castle.DynamicProxy;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Caching
{
    [TestFixture]
    public class CacheInterceptorSelectorTest
    {
        private ICache strictMockCache;
        private ProxyGenerator proxyGenerator;
        private ProxyGenerationOptions options;

        [SetUp]
        public void SetUp()
        {
            proxyGenerator = new ProxyGenerator(new DefaultProxyBuilder(new ModuleScope(false, true)));

            CacheInterceptorSelector selector = new CacheInterceptorSelector();
            options = new ProxyGenerationOptions { Selector = selector };

            strictMockCache = MockRepository.GenerateStrictMock<ICache>();
        }

        [Ignore] [Test]
        public void ShouldInterceptWithOnlyDummyInterceptor()
        {

            TestInterface testClass = new TestClass();

            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            IInterceptor[] interceptors =
                {
                    new CacheQueryByIdInterceptor(strictMockCache), 
                    new CacheInsertOrUpdateInterceptor(strictMockCache), 
                    new CacheRemoveInterceptor(strictMockCache), 
                    dummyInterceptor
                };

            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            
            proxy.MethodWithNoAttributes(10L);
            Assert.True(dummyInterceptor.InterceptorCalled);

            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldInterceptWithOnlyDummyInterceptorBecauseMethodHasMoreThanOneArgumentEvenThoughAttributedWithQueryById()
        {
            TestInterface testClass = new TestClass();

            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            IInterceptor[] interceptors =
                {
                    new CacheQueryByIdInterceptor(strictMockCache), 
                    new CacheInsertOrUpdateInterceptor(strictMockCache), 
                    new CacheRemoveInterceptor(strictMockCache), 
                    dummyInterceptor
                };

            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);

            proxy.QueryByIdWithTooManyArgs(10L, "who cares");
            Assert.True(dummyInterceptor.InterceptorCalled);

            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldInterceptWithDummyInterceptorAndQueryByIdInterceptor()
        {
            TestInterface testClass = new TestClass();

            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheQueryByIdInterceptor(strictMockCache), 
                    new CacheInsertOrUpdateInterceptor(strictMockCache), 
                    new CacheRemoveInterceptor(strictMockCache)
                };

            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);

            TestDomainObject testDomainObjectFromCache = new TestDomainObject(10L);
            strictMockCache.Expect(m => m.Get(CacheKeyGenerator.GenerateQueryByIdKey(testDomainObjectFromCache))).Return(testDomainObjectFromCache);

            TestDomainObject result = proxy.QueryByIdWithAttribute(10L);
            Assert.That(result.IdValue, Is.EqualTo(10L));
            Assert.True(dummyInterceptor.InterceptorCalled);

            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldOnlyPassBackNonCachingInterceptorsWhenIsADaoTest()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheQueryByIdInterceptor(strictMockCache),
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();

            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            CacheInterceptorSelector.IsDaoTest = true;
            proxy.QueryAllBySite(10L);
            
            Assert.True(dummyInterceptor.InterceptorCalled);
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetQueryBySiteIdCachingInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryAllBySiteIdInterceptor mockQueryAllBySiteIdInterceptor = MockRepository.GenerateStrictMock<ICacheQueryAllBySiteIdInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    mockQueryAllBySiteIdInterceptor,
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();
            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            mockQueryAllBySiteIdInterceptor.Expect(m => m.Intercept(null)).IgnoreArguments();
            proxy.QueryAllBySite(9L);
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockQueryAllBySiteIdInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
            
        }

        [Ignore] [Test]
        public void ShouldGetNonCachingInterceptorsWhenObjectDoesNotImplementICacheBySiteId()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryAllBySiteIdInterceptor mockQueryAllBySiteIdInterceptor = MockRepository.GenerateStrictMock<ICacheQueryAllBySiteIdInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    mockQueryAllBySiteIdInterceptor,
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();
            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            
            proxy.QueryAllBySiteBad(9L);
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockQueryAllBySiteIdInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();

        }

        [Ignore] [Test]
        public void ShouldGetQueryAllCachingInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryAllInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryAllInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    mockInterceptor,
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();
            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            mockInterceptor.Expect(m => m.Intercept(null)).IgnoreArguments();
            proxy.QueryAll();
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetQueryListByIdCachingInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListByIdInterceptor mockQueryListByidInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListByIdInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    mockQueryListByidInterceptor,
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();
            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            mockQueryListByidInterceptor.Expect(m => m.Intercept(null)).IgnoreArguments();
            proxy.QueryListById(9L);
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockQueryListByidInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetQueryListInterceptorWhenMultipleArgsPassed()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                    mockInterceptor,
                    new CacheRemoveInterceptor(strictMockCache)
                };
            TestInterface testClass = new TestClass();
            TestInterface proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            mockInterceptor.Expect(m => m.Intercept(null)).IgnoreArguments();
            proxy.QueryListBy(SiteFixture.Denver(), RoleFixture.CreateOperatorRole());
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetInsertOrUpdateInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    mockInterceptor,
                    new CacheInsertOrUpdateInterceptor(strictMockCache),
                };
            TestInterfaceWithNoRelatedCachesToExpire testClass = new TestClasswithNoReleatedCachesToExpire();
            TestInterfaceWithNoRelatedCachesToExpire proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);
            
            TestDomainObject testDomainObject = new TestDomainObject(78);
            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(testDomainObject);

            strictMockCache.Expect(m => m.Update(cachingKey, testDomainObject));
            strictMockCache.Expect(m => m.Get(cachingKey + ":REL")).Return(null);
            
            proxy.Update(testDomainObject);
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetCacheRemovedInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    mockInterceptor,
                    new CacheRemoveInterceptor(strictMockCache), 
                };
            TestInterfaceWithNoRelatedCachesToExpire testClass = new TestClasswithNoReleatedCachesToExpire();
            TestInterfaceWithNoRelatedCachesToExpire proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);

            TestDomainObject testDomainObject = new TestDomainObject(78);
            string cachingKey = CacheKeyGenerator.GenerateQueryByIdKey(testDomainObject);

            strictMockCache.Expect(m => m.Remove(cachingKey));
            strictMockCache.Expect(m => m.Get(cachingKey + ":REL")).Return(null);

            proxy.Remove(testDomainObject);

            Assert.True(dummyInterceptor.InterceptorCalled);

            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        [Ignore] [Test]
        public void ShouldGetCacheQueryThatIsNotQueryById()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListInterceptor>();

            IInterceptor[] interceptors =
                {
                    dummyInterceptor,
                    mockInterceptor,
                    new CacheQueryInterceptor(strictMockCache), 
                };
            TestInterfaceWithNoRelatedCachesToExpire testClass = new TestClasswithNoReleatedCachesToExpire();
            TestInterfaceWithNoRelatedCachesToExpire proxy = proxyGenerator.CreateInterfaceProxyWithTarget(testClass, options, interceptors);

            TestDomainObject testDomainObject = new TestDomainObject(78);
            object[] args = {"hsimpson"};
            string cachingKey = CacheKeyGenerator.GenerateQueryKey("ItemByUsername", args);

            strictMockCache.Expect(m => m.Get(cachingKey));

            proxy.QueryByUsername("hsimpson");
            Assert.True(dummyInterceptor.InterceptorCalled);

            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
            
        }

        [Ignore] [Test]
        public void ShouldGetInterceptor()
        {
            DummyInterceptor dummyInterceptor = new DummyInterceptor();
            ICacheQueryListInterceptor mockInterceptor = MockRepository.GenerateStrictMock<ICacheQueryListInterceptor>();

            IInterceptor[] interceptors =
            {
                dummyInterceptor,
                mockInterceptor,
                new CacheQueryByIdInterceptor(strictMockCache),
            };
            ITestDao dao = new TestDao();
            ITestDao proxy = proxyGenerator.CreateInterfaceProxyWithTarget(dao, options, interceptors);
            long id = 100;

            string cachingKey = "Schedule:100";

            strictMockCache.Expect(m => m.Get(cachingKey)).Return(new TestClassImpl(id));

            ITestInterface result = proxy.QueryById(id);
            Assert.That(result.Id, Is.EqualTo(id));

            Assert.True(dummyInterceptor.InterceptorCalled);
            mockInterceptor.VerifyAllExpectations();
            strictMockCache.VerifyAllExpectations();
        }

        private class DummyInterceptor : IInterceptor
        {
            public bool InterceptorCalled { get; private set; }

            public void Intercept(IInvocation invocation)
            {
                InterceptorCalled = true;
                invocation.Proceed();
            }
        }
    }
}