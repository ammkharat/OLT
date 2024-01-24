using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class EventServiceTest
    {
        private Mockery mocks;
        private IEventSinkDao mockEventSinkDao;
        private EventService eventService;
        private ISiteConfigurationDao mockSiteConfigurationDao;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockEventSinkDao = mocks.NewMock<IEventSinkDao>();
            mockSiteConfigurationDao = mocks.NewMock<ISiteConfigurationDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor( mockEventSinkDao);

            eventService = new EventService(mockEventSinkDao, mockSiteConfigurationDao);

            Stub.On(mockSiteConfigurationDao).Method("QueryBySiteId").WithAnyArguments().Will(Return.Value(null));
        }
        
        [Ignore] [Test]
        public void ShouldInvokeWhenClientSiteMatchesServerEventSite()
        {
            Site sarniaSite = SiteFixture.Sarnia();
            var eventSink = new EventSink(string.Empty, new List<string> { "1", "1-2", "1-2-3" },null, null, null, sarniaSite.IdValue);

            Assert.IsTrue(eventService.ShouldNotifyClientOfEvent(eventSink, sarniaSite));
        }

        [Ignore] [Test]
        public void ShouldNotInvokeWhenClientSiteDoesNotMatchesServerEventSite()
        {
            Site sarniaSite = SiteFixture.Sarnia();
            var eventSink = new EventSink(string.Empty, new List<string> { "1", "1-2", "1-2-3" },null, null, null, sarniaSite.IdValue);

            Assert.IsFalse(eventService.ShouldNotifyClientOfEvent(eventSink, SiteFixture.Denver()));
        }

        [Ignore] [Test]
        public void ShouldInvokeWhenClientFlocsMatchesServerEventFlocs()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetAny_Unit1();
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            targetDefinition.FunctionalLocation = floc;

            var eventSink = new EventSink(string.Empty, new List<string>{floc.FullHierarchy}, null,null, null, SiteFixture.Sarnia().Id);

            Assert.IsTrue(eventService.ShouldNotifyClientOfEvent(eventSink, targetDefinition));
        }

        [Ignore] [Test]
        public void ShouldNotInvokeWhenClientFlocsDoNotMatchServerEventFlocs()
        {
            FunctionalLocation serverFLOC = FunctionalLocationFixture.GetAny_Unit2();
            FunctionalLocation clientFLOC = FunctionalLocationFixture.GetAny_Unit1();

            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(1);
            targetDefinition.FunctionalLocation = clientFLOC;

            EventSink eventSink = new EventSink(string.Empty, new List<string>{serverFLOC.FullHierarchy},null, null, null, SiteFixture.Sarnia().Id);

            Assert.IsFalse(eventService.ShouldNotifyClientOfEvent(eventSink, targetDefinition));
        }

        [Ignore] [Test]
        public void ShouldInvokeWhenClientFlocsAreZeroAndDomainObjectIsFunctionalLocationRelevant()
        {
            EventSink eventSink = new EventSink(string.Empty, new List<string>(0), null, null,null, 3);
            Assert.IsTrue(eventService.ShouldNotifyClientOfEvent(eventSink, new RestrictionDefinition()));
        }

        [Ignore] [Test]
        public void ShouldInvokeWhenDomainObjectIsSiteAndFunctionalLocationRelevant()
        {
            EventSink eventSink = new EventSink(string.Empty, new List<string>{"1", "1-2"}, null, null,null, 3);

            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObject(true, true)));
            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObject(true, false)));
            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObject(false, true)));
            Assert.AreEqual(false, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObject(false, false)));
        }

        [Ignore] [Test]
        public void ShouldInvokeBasedOnVisibilityGroupRelevance()
        {
            EventSink eventSink = new EventSink(string.Empty, new List<string> { "1", "1-2" }, null,null, new List<long> { 1, 2 }, 3);

            // case: is floc relevant and is visibility group relevant, so invoke
            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObjectWithVisibilityGroupRelevance(true, false, true)));

            // case: is floc relevant but is not visibility group relevant, so do not invoke
            Assert.AreEqual(false, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObjectWithVisibilityGroupRelevance(true, false, false)));
            
            // case: is site relevant but is not visibility group relevant, so do not invoke
            Assert.AreEqual(false, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObjectWithVisibilityGroupRelevance(false, true, false)));

            // case: is site relevant and is visibility group relevant, so do invoke
            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObjectWithVisibilityGroupRelevance(false, true, true)));

            // case: is not floc relevant or site relevant, so ignore the fact that it is visibility group relevant
            Assert.AreEqual(false, eventService.ShouldNotifyClientOfEvent(eventSink, new TestDomainObjectWithVisibilityGroupRelevance(false, false, true)));

            // case: the visibility group id list is null or empty and this forces the item to be relevant visibility-group-wise
            EventSink eventSinkWithNoVisibilityGroupIds = new EventSink(string.Empty, new List<string> { "1", "1-2" },null, null, new List<long>(), 3);
            Assert.AreEqual(true, eventService.ShouldNotifyClientOfEvent(eventSinkWithNoVisibilityGroupIds, new TestDomainObjectWithVisibilityGroupRelevance(true, false, false)));
        }

        private class TestDomainObject : DomainObject, IFunctionalLocationRelevant, ISiteRelevant
        {
            private bool IsFunctionalLocationRelevant { get; set; }
            private bool IsSiteRelevant { get; set; }

            public TestDomainObject(bool isFunctionalLocationRelevant, bool isSiteRelevant)
            {
                IsFunctionalLocationRelevant = isFunctionalLocationRelevant;
                IsSiteRelevant = isSiteRelevant;
            }

            public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
            {
                return IsFunctionalLocationRelevant;
            }

            public bool IsRelevantTo(long siteId)
            {
                return IsSiteRelevant;
            }
        }

        private class TestDomainObjectWithVisibilityGroupRelevance : DomainObject, IFunctionalLocationRelevant, ISiteRelevant, IVisibilityGroupRelevant
        {
            private bool IsFunctionalLocationRelevant { get; set; }
            private bool IsSiteRelevant { get; set; }
            private bool IsVisibilityGroupRelevant { get; set; }

            public TestDomainObjectWithVisibilityGroupRelevance(bool isFunctionalLocationRelevant, bool isSiteRelevant, bool isVisibilityGroupRelevant)
            {
                IsFunctionalLocationRelevant = isFunctionalLocationRelevant;
                IsSiteRelevant = isSiteRelevant;
                IsVisibilityGroupRelevant = isVisibilityGroupRelevant;
            }

            public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies, SiteConfiguration siteConfiguration)
            {
                return IsFunctionalLocationRelevant;
            }

            public bool IsRelevantTo(long siteId)
            {
                return IsSiteRelevant;
            }

            public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
            {
                return IsVisibilityGroupRelevant;
            }
        }
    }
}