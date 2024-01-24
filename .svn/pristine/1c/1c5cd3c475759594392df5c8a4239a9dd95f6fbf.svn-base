using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class SummaryLogFormPresenterTest
    {
        private ISummaryLogFormView viewMock;
        private ILogService logService;
        private ISummaryLogService summaryLogServiceMock;
        private ICustomFieldService customFieldServiceMock;
        private IFunctionalLocationService functionalLocationServiceMock;
        private ILogTemplateService logTemplateServiceMock;
        private IAuthorized authorizedMock;

        private readonly Mockery mock = new Mockery();

        [SetUp]
        public void SetUp()
        {
            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

            viewMock = mock.NewMock<ISummaryLogFormView>();
            summaryLogServiceMock = mock.NewMock<ISummaryLogService>();
            logService = mock.NewMock<ILogService>();
            customFieldServiceMock = mock.NewMock<ICustomFieldService>();
            functionalLocationServiceMock = mock.NewMock<IFunctionalLocationService>();
            logTemplateServiceMock = mock.NewMock<ILogTemplateService>();

            ClientSession.GetNewInstance();
            UserContext userContext = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateOperatorOltUser1InFortMcMurrySite(userContext);
            
            UserShift userShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            userContext.UserShift = userShift;

            authorizedMock = mock.NewMock<IAuthorized>();

            Stub.On(customFieldServiceMock).Method("QueryOrderedFieldsByWorkAssignmentForSummaryLogs").WithAnyArguments().Will(Return.Value(new List<CustomField>()));

            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

        }

        [TearDown]
        public void TearDown()
        {
            mock.VerifyAllExpectationsHaveBeenMet();
            Clock.UnFreeze();
        }
      
        [Test]
        public void ShouldNotUpdateShiftWhenUpdatingSummaryLog()
        {
            Clock.Now = new DateTime(2011, 1, 15, 10, 15, 00);
            DateTime now = Clock.Now;
            DateTime logDateTime = now.AddMinutes(-10);

            Stub.On(viewMock).Method("ClearErrorProviders");

            Stub.On(viewMock).GetProperty("SelectedFunctionalLocation").Will(Return.Value(FunctionalLocationFixture.GetAny_Equip1()));

            Stub.On(viewMock).GetProperty("InspectionFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("ProcessControlFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("OperationsFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("SupervisionFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("EHSFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("OtherFollowUp").Will(Return.Value(false));
            Stub.On(viewMock).GetProperty("AssociatedDocumentLinks").Will(Return.Value(new List<DocumentLink>()));
            Stub.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(logDateTime));
            Stub.On(viewMock).GetProperty("IsCommentEmpty").Will(Return.Value(false));

            // For validation
            Stub.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(new Time(logDateTime)));            

            // Make a night shift for the summary log to edit that can be compared afterwards. It should NOT be updated
            // to the user shift in the ClientSession
            UserShift nightUserShift = ShiftPatternFixture.CreateUserShiftDuringNightShift();
            Assert.AreNotEqual(nightUserShift, ClientSession.GetUserContext().UserShift.ShiftPattern);

            Stub.On(summaryLogServiceMock).Method("Update").Will(Return.Value(new List<NotifiedEvent>()));
            Stub.On(summaryLogServiceMock).Method("LogIsMarkedAsRead").Will(Return.Value(false));

            Stub.On(authorizedMock).Method(new AlwaysTrueMatcher()).Will(Return.Value(true));

            SummaryLog summaryLogToEdit = SummaryLogFixture.CreateSummaryLogItemGoofySarnia(nightUserShift.ShiftPattern);

            Stub.On(viewMock).GetProperty("AssociatedFunctionalLocations").Will(Return.Value(summaryLogToEdit.FunctionalLocations));
            Stub.On(viewMock);

            SummaryLogFormPresenter presenter = new SummaryLogFormPresenter(
                viewMock, 
                summaryLogToEdit,
                false,
                summaryLogServiceMock,
                logService,
                customFieldServiceMock,
                authorizedMock,
                null,
                functionalLocationServiceMock,
                logTemplateServiceMock);
            
            presenter.HandleSaveClick(null, EventArgs.Empty);

            Assert.AreEqual(nightUserShift.ShiftPattern, summaryLogToEdit.CreatedShiftPattern);
        }

    }
}
