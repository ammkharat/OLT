using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class AbstractWorkPermitCloseComentPresenterTest
    {
        private Mockery mocks;
        private IWorkPermitCloseFormView mockView;
        private ConcreteWorkPermitCloseCommentPresenter presenter;
        private WorkPermit workPermit;
        private IWorkPermitService mockService;
        private ISiteConfigurationService mockSiteConfigurationService;
        
        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            mocks = new Mockery();
            mockService = mocks.NewMock<IWorkPermitService>();
            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();
            
            mockView = mocks.NewMock<IWorkPermitCloseFormView>();
            SetUpExpectationsForRegisterForEvents();
            workPermit = WorkPermitFixture.CreateWorkPermit();
            presenter = new ConcreteWorkPermitCloseCommentPresenter(
                mockView, 
                new List<WorkPermit>(new [] {workPermit}),
                mockService, 
                mockSiteConfigurationService);
        }

        [TearDown]
        public void TearDown()
        {
        }              
        
        [Test]
        public void SubmitShouldInvokeSaveAndDisplaySaveFailedMessageIfSaveThrowsException()
        {
            Expect.Once.On(mockService).Method("Update").Will(Throw.Exception(new Exception("Save Failed.")));
            Expect.Once.On(mockView).Method("SaveFailedMessage");
            presenter.Submit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();           
        }

        [Test]
        public void SubmitShouldInvokeSaveAndDisplaySaveSuccessfulMessageIfSaveSuccessful()
        {
            Expect.Once.On(mockService).Method("Update").With(Is.EqualTo(workPermit)).Will(Return.Value(new List<NotifiedEvent>()));
            Expect.Once.On(mockView).Method("SaveSucceededMessage");
            presenter.Submit(null, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void SetUpExpectationsForRegisterForEvents()
        {
            Expect.Once.On(mockView).EventAdd("FormClosing", Is.Anything);
            Expect.Once.On(mockView).EventAdd("Load", Is.Anything);
            Expect.Once.On(mockView).EventAdd("SubmitButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CancelButtonClick", Is.Anything);
            Expect.Once.On(mockView).EventAdd("CreateLogCheckedChanged", Is.Anything);
        }
        
        private class ConcreteWorkPermitCloseCommentPresenter : AbstractWorkPermitCloseCommentPresenter
        {
            public ConcreteWorkPermitCloseCommentPresenter(IWorkPermitCloseFormView view, List<WorkPermit> workPermits,
                IWorkPermitService workPermitService,
                ISiteConfigurationService siteConfigurationService) :
                base(view, workPermits, workPermitService)
            {
            }

            protected override void Save(WorkPermit workPermit)
            {
                workPermitService.Update(workPermit);
            }
        }
    }
}