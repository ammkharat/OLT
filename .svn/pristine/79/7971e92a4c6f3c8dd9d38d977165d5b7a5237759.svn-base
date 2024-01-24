using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class WorkPermitMontrealTemplateServiceTest
    {
        private Mockery mocks;
        private EventQueueTestWrapper eventQueue;
        private IWorkPermitMontrealTemplateDao mockDao;
        private IWorkPermitMontrealTemplateService service;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockDao = mocks.NewMock<IWorkPermitMontrealTemplateDao>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(mockDao);

            service = new WorkPermitMontrealTemplateService();

            eventQueue = new EventQueueTestWrapper();
        }

        [TearDown]
        public void TearDown()
        {
            eventQueue.Cleanup();
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            WorkPermitMontrealTemplate workPermitMontrealTemplate = new WorkPermitMontrealTemplate("Suncor Test", WorkPermitMontrealType.COLD, true, false, 0);
            Expect.Once.On(mockDao).Method("Insert").With(workPermitMontrealTemplate).Will(Return.Value(workPermitMontrealTemplate));
            service.Insert(workPermitMontrealTemplate);
        }

        [Ignore] [Test]
        public void ShouldQueryAllNotDeleted()
        {
            List<WorkPermitMontrealTemplate> listOfTemplates = new List<WorkPermitMontrealTemplate>();
            Expect.Once.On(mockDao).Method("QueryAllNotDeleted").WithNoArguments().Will(Return.Value(listOfTemplates));
            service.QueryAllNotDeleted();
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            WorkPermitMontrealTemplate workPermitMontrealTemplate = new WorkPermitMontrealTemplate("Suncor Test", WorkPermitMontrealType.COLD, true, false, 0);
            Expect.Once.On(mockDao).Method("Delete").With(workPermitMontrealTemplate);
            service.Delete(workPermitMontrealTemplate);
        }
    }
}
