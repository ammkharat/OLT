using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NMock2;
using NUnit.Framework;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class LogFormPresenterTest
    {
        private TestableLogFormPresenter presenter;
        private ILogFormView viewMock;
        private ILogService logServiceMock;
        private ILogTemplateService logTemplateServiceMock;
        private ICustomFieldService customFieldService;
        private IPlantHistorianService plantHistorianService;
        private IFunctionalLocationService functionalLocationService;

        private Mockery mock;

        private const string FUNCTIONAL_LOCATION_DATA = "FunctionalLocations";
        private const string CLEAR_ERROR_PROVIDERS = "ClearLogValidationErrorProviders";

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();

            ClientServiceRegistry.InitializeMockedInstance(new TestRemoteEventRepeater());
            Clock.Freeze();

            viewMock = (ILogFormView) mock.NewMock(typeof (ILogFormView));

            logServiceMock = (ILogService) mock.NewMock(typeof (ILogService));
            logTemplateServiceMock = (ILogTemplateService) mock.NewMock(typeof(ILogTemplateService));
            customFieldService = (ICustomFieldService) mock.NewMock(typeof(ICustomFieldService));
            plantHistorianService = (IPlantHistorianService) mock.NewMock(typeof(IPlantHistorianService));
            functionalLocationService = (IFunctionalLocationService) mock.NewMock(typeof(IFunctionalLocationService));
            
            Stub.On(logTemplateServiceMock)
                .Method("QueryByWorkAssignmentReturnOnlyUniqueLogTemplates")
                .Will(Return.Value(new List<LogTemplateDTO>()));
            
            Stub.On(customFieldService)
                .Method("QueryOrderedFieldsByWorkAssignmentForLogs")
                .Will(Return.Value(new List<CustomField>()));

            Stub.On(viewMock).EventAdd("HandleLogTemplateButtonClick", Is.Anything);

            DateTime dateTimeNow = DateTimeFixture.DateTimeNow;
            Clock.Now = dateTimeNow;

            ClientSession.GetNewInstance();
            UserContext context = ClientSession.GetUserContext();
            Fixtures.UserFixture.CreateOperatorOltUser1InFortMcMurrySite(context);
            Site site = SiteFixture.Oilsands();
            context.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            UserShift userShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            context.UserShift = userShift;
            context.SetRole(RoleFixture.CreateOperatorRole(), new UserRoleElements(RoleFixture.CreateOperatorRole(), new List<RoleElement>()), new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            FunctionalLocation division = FunctionalLocationFixture.GetAny_Division();
            FunctionalLocation section = FunctionalLocationFixture.GetAny_Section();
            List<FunctionalLocation> all = new List<FunctionalLocation> { division, section };
            List<FunctionalLocation> divs = new List<FunctionalLocation> { division };
            List<FunctionalLocation> secs = new List<FunctionalLocation> { section };
            context.SetSelectedFunctionalLocations(all, divs, secs);

            presenter = new TestableLogFormPresenter(viewMock, null, null, logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);

            Stub.On(viewMock).GetProperty("RecommendForShiftSummary").Will(Return.Value(false));
            Stub.On(viewMock).SetProperty("RecommendForShiftSummary");
            Stub.On(viewMock).GetProperty("IsCommentEmpty").Will(Return.Value(false));
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test][Ignore]
        public void ShouldReturnTrueWhenValidLogObjectIsPassedIntoValidate()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();

            Expect.Once.On(viewMock).Method(CLEAR_ERROR_PROVIDERS).WithNoArguments();            
            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(new Time(7, 30)));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(log.CreatedDateTime));            
            Expect.Once.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_DATA).Will(Return.Value(log.FunctionalLocations));            
            Assert.IsFalse(presenter.ValidateViewHasError());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void CallingViewIsValidatedShouldSetErrorInformationAndCheckIfViewIsValid()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();

            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(new Time(7, 30)));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(log.CreatedDateTime));                        
            Expect.Once.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_DATA).Will(Return.Value(log.FunctionalLocations));
            Expect.Once.On(viewMock).Method(CLEAR_ERROR_PROVIDERS).WithNoArguments();            
            
            Assert.IsFalse(presenter.ValidateViewHasError());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldReturnFalseWhenInvalidLogObjectIsPassedIntoValidate()
        {
            Log log = LogFixture.CreateIncompleteLogItemMickeySarniaRequiresSupervisionFollowUp();

            Expect.Once.On(viewMock).Method(CLEAR_ERROR_PROVIDERS).WithNoArguments();            
            Expect.Once.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_DATA).Will(Return.Value(new List<FunctionalLocation>()));
            Expect.Once.On(viewMock).Method("SetFunctionLocationBlankError").WithNoArguments();
            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(new Time(7, 30)));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(log.CreatedDateTime));

            Assert.IsTrue(presenter.ValidateViewHasError());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldReturnFalseWhenInvalidActualLoggedDateTimePassedToValidate()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();

            Stub.On(viewMock).Method(CLEAR_ERROR_PROVIDERS).WithNoArguments();
            
            Stub.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_DATA).Will(Return.Value(log.FunctionalLocations));
                        
            Time actualTimeAfterShift = new Time(ClientSession.GetUserContext().UserShift.EndDateTimeWithPadding.AddMinutes(1));
            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(actualTimeAfterShift));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(log.CreatedDateTime));

            Expect.Once.On(viewMock).Method("SetLogDateTimeError");
            Assert.IsTrue(presenter.ValidateViewHasError());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldReturnTrueWhenValidLogDateTimePassedToValidate()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            Stub.On(viewMock).Method(CLEAR_ERROR_PROVIDERS).WithNoArguments();            
            Stub.On(viewMock).GetProperty(FUNCTIONAL_LOCATION_DATA).Will(Return.Value(log.FunctionalLocations));
            Time actualTimeWithinShift = new Time(ClientSession.GetUserContext().UserShift.StartDateTime);
            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(actualTimeWithinShift));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(log.CreatedDateTime));
            Expect.Never.On(viewMock).Method("SetLogDateTimeError");

            Assert.IsFalse(presenter.ValidateViewHasError());

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Test][Ignore]
        public void CallingCancelShouldCloseForm()
        {
            Expect.Once.On(viewMock).Method("Close");
            presenter.HandleCancelButtonClick(this, new EventArgs());

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void CallingInitializeViewShouldClearOutItems()
        {
            Clock.Freeze();
            Expect.Once.On(viewMock).SetProperty("FunctionalLocations").Equals(IsList.Equal(new List<FunctionalLocation>()));
            Expect.Once.On(viewMock).SetProperty("Author").To(ClientSession.GetUserContext().User.FullNameWithUserName);
            Expect.Once.On(viewMock).SetProperty("IsOperatingEngineerLog");            
            Expect.Once.On(viewMock).SetProperty("AssociatedDocumentLinks").Equals(IsList.Equal(new List<DocumentLink>()));
            Stub.On(viewMock);
            presenter.HandleLoadPage(null, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }


        [Test][Ignore]
        public void ShouldEnableOperatingEngineerLogButLeaveUncheckedForNonOpEngUser()
        {
            User user = UserFixture.CreateSupervisor();
            ClientSession.GetUserContext().User = user;
            ClientSession.GetUserContext().UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();

            Expect.Once.On(viewMock).SetProperty("IsOperatingEngineerLog").To(false);            

            Stub.On(viewMock);
            presenter.HandleLoadPage(null, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldDisableOperatingEngineerLogWhenSiteNotConfiguredForCreatingOperatingEngineerLogs()
        {
            Site site = SiteFixture.Denver();
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            
            Expect.Once.On(viewMock).SetProperty("IsOperatingEngineerLog").To(false);            
            Stub.On(viewMock);

            presenter.HandleLoadPage(null, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldEnableOperatingEngineerLogButLeaveUncheckedForOpEngUser()
        {
            User user = UserFixture.CreateOperatingEngineer();
            ClientSession.GetUserContext().User = user;
            ClientSession.GetUserContext().UserShift = ShiftPatternFixture.CreateUserShiftDuringDayShift();
            Site site = user.AvailableSites[0];
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));

            Expect.Once.On(viewMock).SetProperty("IsOperatingEngineerLog").To(false);            
            
            Stub.On(viewMock);
            presenter.HandleLoadPage(null, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldInitializeViewForEditingExistingLogOnLoadPage()
        {
            Clock.Freeze();

            Log existingLog = LogFixture.CreateLogItem(Clock.Now.SubtractDays(1), Clock.Now);
            existingLog.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(1));
            presenter = new TestableLogFormPresenter(
                viewMock, existingLog, null, logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);

            // Expectations on view:
            Expect.Once.On(viewMock).Method("SetupForEdit");            
            Expect.Once.On(viewMock).SetProperty("Author").To(existingLog.LastModifiedBy.FullNameWithUserName);
            Expect.Once.On(viewMock).SetProperty("Shift").To(existingLog.CreatedShiftPattern.Name);
            Expect.Once.On(viewMock).SetProperty("Comments").To(existingLog.RtfComments);
            Expect.Once.On(viewMock).SetProperty("EHSFollowUp").To(existingLog.OperationsFollowUp);
            Expect.Once.On(viewMock).SetProperty("OperationsFollowUp").To(existingLog.OperationsFollowUp);
            Expect.Once.On(viewMock).SetProperty("ProcessControlFollowUp").To(existingLog.ProcessControlFollowUp);
            Expect.Once.On(viewMock).SetProperty("InspectionFollowUp").To(existingLog.InspectionFollowUp);
            Expect.Once.On(viewMock).SetProperty("SupervisionFollowUp").To(existingLog.SupervisionFollowUp);
            Expect.Once.On(viewMock).SetProperty("OtherFollowUp").To(existingLog.OtherFollowUp);
            Expect.Once.On(viewMock).SetProperty("IsOperatingEngineerLog").To(existingLog.IsOperatingEngineerLog);            
            Expect.Once.On(viewMock).SetProperty("FunctionalLocations").To(
                IsList.Equal(existingLog.FunctionalLocations));
            Expect.Once.On(viewMock).SetProperty("AssociatedDocumentLinks").To(
                IsList.Equal(existingLog.DocumentLinks));

            Stub.On(viewMock);

            // Execute:
            presenter.HandleLoadPage(null, EventArgs.Empty);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void CallingSaveShouldGetDataFromFormAndCreateLog()
        {
            Expect.Once.On(viewMock).GetProperty("FunctionalLocations")
                .Will(
                Return.Value(
                    new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1()}));

            // Expectations for getting view values to create log:
            const string newComments = "new comments";
            Expect.Once.On(viewMock).GetProperty("CreateALogForEachFunctionalLocation").Will(Return.Value(false));
            Expect.Once.On(viewMock).GetProperty("InspectionFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("ProcessControlFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("OperationsFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("SupervisionFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("EHSFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("OtherFollowUp").Will(Return.Value(true));            
            Expect.Once.On(viewMock).GetProperty("IsOperatingEngineerLog").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(Clock.Now));
            Expect.Once.On(viewMock).GetProperty("Comments").Will(Return.Value(newComments));
            Expect.Once.On(viewMock).GetProperty("CommentsAsPlainText").Will(Return.Value(newComments));
            List<DocumentLink> links = new List<DocumentLink>();
            Expect.Once.On(viewMock).GetProperty("AssociatedDocumentLinks").Will(Return.Value(links));

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>
                                                     {
                                                         new NotifiedEvent(ApplicationEvent.LogCreate,
                                                                           LogFixture.CreateLog(false))                                                                                                                                      
                                                     };

            Expect.Once.On(logServiceMock).Method("Insert")
                .With(
                    TestUtil.IsTypeOf(typeof (Log))
                      & LogHasProperty("RtfComments", "new comments")
                      & LogHasProperty("PlainTextComments", "new comments")
                      & LogHasProperty("InspectionFollowUp", true)
                      & LogHasProperty("ProcessControlFollowUp", true)
                      & LogHasProperty("OperationsFollowUp", true)
                      & LogHasProperty("SupervisionFollowUp", true)
                      & LogHasProperty("EnvironmentalHealthSafetyFollowUp", true)
                      & LogHasProperty("OtherFollowUp", true))
                .Will(Return.Value(notifiedEvents));


            SaveUpdateDomainObjectContainer<Log> container = presenter.GetNewObjectToInsertDespiteMethodBeingProtected();
            presenter.Insert(container);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void UpdateShouldGetDataFromFormAndUpdateLog()
        {
            Log logToEdit = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            Expect.Once.On(viewMock).GetProperty("FunctionalLocations")
                .Will(
                Return.Value(
                    new List<FunctionalLocation> { FunctionalLocationFixture.GetAny_Unit1() }));

            // Expectations for getting view values to create log:
            const string newComments = "new comments";
            const string newCommentsPlainText = "new comments (plain text)";
            Expect.Once.On(viewMock).GetProperty("InspectionFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("ProcessControlFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("OperationsFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("SupervisionFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("EHSFollowUp").Will(Return.Value(true));
            Expect.Once.On(viewMock).GetProperty("OtherFollowUp").Will(Return.Value(true));            
            Expect.Once.On(viewMock).GetProperty("LogDateTime").Will(Return.Value(Clock.Now));
            Expect.Once.On(viewMock).GetProperty("IsOperatingEngineerLog").Will(Return.Value(true));
            List<DocumentLink> links = new List<DocumentLink>();
            Expect.Once.On(viewMock).GetProperty("AssociatedDocumentLinks").Will(Return.Value(links));
            Expect.Once.On(viewMock).GetProperty("Comments").Will(Return.Value(newComments));
            Expect.Once.On(viewMock).GetProperty("CommentsAsPlainText").Will(Return.Value(newCommentsPlainText));

            Expect.Once.On(logServiceMock).Method("Update")
                .With(
                      TestUtil.IsTypeOf(typeof (Log))
                      & LogHasProperty("RtfComments", newComments)
                      & LogHasProperty("PlainTextComments", newCommentsPlainText)
                      & LogHasProperty("InspectionFollowUp", true)
                      & LogHasProperty("ProcessControlFollowUp", true)
                      & LogHasProperty("OperationsFollowUp", true)
                      & LogHasProperty("SupervisionFollowUp", true)
                      & LogHasProperty("EnvironmentalHealthSafetyFollowUp", true)
                      & LogHasProperty("OtherFollowUp", true))
              .Will(Return.Value(new List<NotifiedEvent>()));

            // Execute:
            presenter = new TestableLogFormPresenter(viewMock, logToEdit, null, logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);
            SaveUpdateDomainObjectContainer<Log> container = presenter.GetPopulatedEditObjectToUpdateDespiteMethodBeingProtected();
            presenter.Update(container);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldDisableViewEditHistoryButtonWhenCreatingNewLog()
        {
            Site site = UserFixture.CreateOperatorGoofyInFortMcMurrySite().AvailableSites[0];
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(false);
            Stub.On(viewMock);

            presenter.HandleLoadPage(null, EventArgs.Empty);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldEnableViewEditHistoryButtonWhenEditingExistingLog()
        {
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(true);

            Stub.On(viewMock);

            Log replyLogItem = LogFixture.CreateReplyLogItem();
            LogFormPresenter editPresenter = new LogFormPresenter(viewMock, replyLogItem, null,
                logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);
            editPresenter.HandleLoadPage(null, EventArgs.Empty);
            TestUtil.WaitAndDoEvents();
            mock.VerifyAllExpectationsHaveBeenMet();

        }

        [Test][Ignore]
        public void ShouldDisableOperatingEngineerLogWhenSiteConfigurationSaysItShouldBeTurnedOffForNewLog()
        {
            Site site = SiteFixture.Denver();
            User user = UserFixture.CreateSupervisor(site);
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(false);
            
            Stub.On(viewMock);
            
            LogFormPresenter editPresenter = new TestableLogFormPresenter(viewMock, null, null,
                logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);
            editPresenter.HandleLoadPage(null, EventArgs.Empty);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldDisableOperatingEngineerLogWhenSiteConfigurationSaysItShouldBeTurnedOffForEditLog()
        {
            Site site = SiteFixture.Denver();
            ClientSession.GetUserContext().SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            User user = UserFixture.CreateSupervisor(site);
            Expect.Once.On(viewMock).SetProperty("ViewEditHistoryEnabled").To(true);
            
            Stub.On(viewMock);

            Log replyLogItem = LogFixture.CreateReplyLogItem();
            LogFormPresenter editPresenter = new TestableLogFormPresenter(viewMock, replyLogItem,
                null, logServiceMock, logTemplateServiceMock, customFieldService, plantHistorianService, functionalLocationService);
            editPresenter.HandleLoadPage(null, EventArgs.Empty);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldPassCurrentFLOCSelectionToFLOCSelectorOnFLOCButtonClicked()
        {
            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();

            Expect.Once.On(viewMock).GetProperty("FunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method(
                "ShowFunctionalLocationSelector").With(
                IsList.Equal(currentFLOCSelection), Is.EqualTo(FunctionalLocationType.Level3)).Will(Return.Value(
                new DialogResultAndOutput<IList<FunctionalLocation>>(DialogResult.OK, new List<FunctionalLocation>())));
    
            Expect.Once.On(viewMock).SetProperty("FunctionalLocations").To(IsList.Equal(new List<FunctionalLocation>()));
            presenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldNotChangeCurrentSelectionIfUserCancels()
        {
            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();
            Expect.Once.On(viewMock).GetProperty("FunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method("ShowFunctionalLocationSelector")
                .With(
                    IsList.Equal(currentFLOCSelection), 
                    Is.EqualTo(FunctionalLocationType.Level3)
                    ).Will(Return.Value(
                        new DialogResultAndOutput<IList<FunctionalLocation>>(DialogResult.Cancel, new List<FunctionalLocation>())));

            presenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldSetEmptyListIfUserOKsAndViewReturnNULL()
        {
            List<FunctionalLocation> currentFLOCSelection = FunctionalLocationFixture.GetListWith2Units();

            Stub.On(viewMock).GetProperty("FunctionalLocations").Will(Return.Value(currentFLOCSelection));
            Expect.Once.On(viewMock).Method("ShowFunctionalLocationSelector")
                .With(currentFLOCSelection, FunctionalLocationType.Level3).Will(Return.Value(
                new DialogResultAndOutput<IList<FunctionalLocation>>(DialogResult.OK, null)));

            List<FunctionalLocation> emptyFLOCList = new List<FunctionalLocation>();
            Expect.Once.On(viewMock).SetProperty("FunctionalLocations").To(IsList.Equal(emptyFLOCList));
            presenter.HandleFunctionalLocationButtonClick(null, EventArgs.Empty);
            mock.VerifyAllExpectationsHaveBeenMet();
        }
         
        [Test][Ignore]
        public void OnActualLoggedTimeValueChangedShouldSetTheActualLoggedDateTimeOnTheView()
        {
            DateTime shiftStartDateTime = ClientSession.GetUserContext().UserShift.StartDateTime;
            Time actualLoggedTime = new Time(shiftStartDateTime.AddMinutes(20));
            Expect.Once.On(viewMock).GetProperty("ActualLoggedTime").Will(Return.Value(actualLoggedTime));
            Expect.Once.On(viewMock).SetProperty("LogDateTime").To(
                shiftStartDateTime.ToDate().CreateDateTime(actualLoggedTime));
            presenter.LogDateTimeChanged(null, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        private static Matcher LogHasProperty(string propertyName, object expectedValue)
        {
            return TestUtil.HasProperty<Log>(propertyName, Is.EqualTo(expectedValue));
        }

        class TestableLogFormPresenter : LogFormPresenter
        {
            public TestableLogFormPresenter(ILogFormView view) : base(view)
            {
            }

            public TestableLogFormPresenter(ILogFormView view, Log editLog) : base(view, editLog)
            {
            }

            public TestableLogFormPresenter(ILogFormView view, ILogCopyStrategy logCopyStrategy) : base(view, logCopyStrategy)
            {
            }

            public TestableLogFormPresenter(ILogFormView view, Log editLog, ILogCopyStrategy logCopyStrategy, ILogService service, ILogTemplateService logTemplateService, ICustomFieldService customFieldService, IPlantHistorianService plantHistorianService, IFunctionalLocationService functionalLocationService) : base(view, editLog, logCopyStrategy, service, logTemplateService, customFieldService, plantHistorianService, functionalLocationService)
            {
            }

            public SaveUpdateDomainObjectContainer<Log> GetPopulatedEditObjectToUpdateDespiteMethodBeingProtected()
            {
                return GetPopulatedEditObjectToUpdate();
            }

            public SaveUpdateDomainObjectContainer<Log> GetNewObjectToInsertDespiteMethodBeingProtected()
            {
                return GetNewObjectToInsert();
            }

            protected override void LoadData(List<Action> loadDataDelegates)
            {
                foreach (Action loadDataDelegate in loadDataDelegates)
                {
                    loadDataDelegate();
                }

                AfterDataLoad();
            }
        }
    }
}
