using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    [TestFixture]
    public class FlocAdapterTest
    {
        private FlocAdapter adapter;
        private FunctionalLocationDetails functionalLocationDetails;
        private ILog logger;
        private IFunctionalLocationOperationalModeService mockFunctionalLocationOperationalModeService;
        private IFunctionalLocationService mockFunctionalLocationService;
        private ISiteConfigurationService mockSiteConfigurationService;
        private ISiteService mockSiteService;
        private IUserService mockUserService;
        private Mockery mocks;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();
            mockFunctionalLocationService = mocks.NewMock<IFunctionalLocationService>();
            mockSiteService = mocks.NewMock<ISiteService>();
            mockSiteConfigurationService = mocks.NewMock<ISiteConfigurationService>();
            mockFunctionalLocationOperationalModeService = mocks.NewMock<IFunctionalLocationOperationalModeService>();
            mockUserService = mocks.NewMock<IUserService>();

            functionalLocationDetails = new FunctionalLocationDetails
            {
                Action = "Add",
                Description = "Test Floc",
                FullHierarchy = "SR1-PL3-HYDU-SMP-33P007B",
                OldFLOC = string.Empty,
                PlantId = "1",
                LanguageCode = LanguageCode.English.SapCode
            };

            logger = GenericLogManager.GetLogger<FunctionalLocationMessageHandler>();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void CallingDeleteTypeFlocObjectToOperatorLogToolShouldCallDelete()
        {
            functionalLocationDetails.Action = "Delete";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId),
                functionalLocationDetails.Description,
                Culture.DEFAULT_CULTURE_NAME);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Once.On(mockFunctionalLocationService).Method("RemoveByFullHierarchy").With(functionalLocation);
            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingInsertTypeFlocObjectToOperatorLogToolShouldCallInsert()
        {
            var functionalLocation = new FunctionalLocation(
                SiteFixture.Sarnia(), functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), functionalLocationDetails.Description,
                Culture.DEFAULT_CULTURE_NAME);


            var flocAfterInsert = functionalLocation.Clone() as FunctionalLocation;
            if (flocAfterInsert != null)
            {
                flocAfterInsert.Id = 9990;
            }

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Expect
                .AtLeastOnce
                .On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .With(functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(null));
            Expect
                .AtLeastOnce
                .On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchyIncludeDeleted")
                .With(functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(null));


            Expect.Once.On(mockFunctionalLocationService)
                .Method("Insert")
                .With(functionalLocation)
                .Will(Return.Value(flocAfterInsert));

            adapter = new FlocAdapter(functionalLocationDetails, logger, mockFunctionalLocationService, mockSiteService,
                mockSiteConfigurationService, mockFunctionalLocationOperationalModeService, mockUserService);

            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingInsertTypeFlocObjectToOperatorLogToolShouldCallInsertAndAlsoInsertOperatingMode()
        {
            functionalLocationDetails.Action = "Add";
            functionalLocationDetails.Description = "Test Floc";
            functionalLocationDetails.FullHierarchy = "SR1-PL3-HYDU";
            functionalLocationDetails.OldFLOC = string.Empty;
            functionalLocationDetails.PlantId = "1";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                1, functionalLocationDetails.Description,
                Culture.DEFAULT_CULTURE_NAME);


            var flocAfterInsert = functionalLocation.Clone() as FunctionalLocation;
            if (flocAfterInsert != null) flocAfterInsert.Id = 999;

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Expect.AtLeastOnce.On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .With(functionalLocationDetails.FullHierarchy,
                    SiteFixture.Sarnia().IdValue).Will(
                        Return.Value(null));
            Expect.AtLeastOnce.On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchyIncludeDeleted")
                .With(functionalLocationDetails.FullHierarchy,
                    SiteFixture.Sarnia().IdValue).Will(
                        Return.Value(null));

            Expect.Once.On(mockFunctionalLocationService)
                .Method("Insert")
                .With(functionalLocation)
                .Will(Return.Value(flocAfterInsert));

            var sapUser = UserFixture.CreateSAPUser();
            Expect.Once.On(mockUserService).Method("GetSAPUser").Will(Return.Value(sapUser));

            Expect.Once.On(mockFunctionalLocationOperationalModeService).Method("InsertDefault");

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingUpdateTypeFlocObjectToOperatorLogToolShouldCallUpdate()
        {
            functionalLocationDetails.Action = "Change";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), string.Empty,
                Culture.DEFAULT_CULTURE_NAME);

            var randomString = new Guid().ToString();
            if (randomString.Length > 40)
            {
                randomString = randomString.Substring(0, 40);
            }

            functionalLocation.Description = randomString;

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .With(functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));
            Expect.Once.On(mockFunctionalLocationService).Method("Update").With(functionalLocation);

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void
            CallingUpdateTypeFlocObjectToOperatorLogToolShouldUpdateIfLanguageCodeIsDifferentFromSiteDefaultButSameAsFLOCInOLT
            ()
        {
            // in this case, an update comes in that has the same language code as the existing FLOC but is different
            // than the site default. It should update the FLOC.

            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.LanguageCode = LanguageCode.English.SapCode;

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), string.Empty,
                Culture.DEFAULT_CULTURE_NAME) {Description = "New FLOC description"};


            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.FrenchCultureName;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Once.On(mockFunctionalLocationService).Method("Update").With(functionalLocation);

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void
            CallingUpdateTypeFlocObjectToOperatorLogToolShouldUpdateTheLanguageCodeIfTheDescriptionIsTheSameAndTheCodeMatchesTheSiteDefault
            ()
        {
            // in this case, an update comes in that has the same language code as the existing FLOC but is different
            // than the site default. It should update the FLOC.

            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.LanguageCode = LanguageCode.English.SapCode;
            functionalLocationDetails.Description = "The FLOC description";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), "The FLOC description",
                Culture.FrenchCultureName);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Once.On(mockFunctionalLocationService).Method("Update").WithAnyArguments();

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingUpdateTypeFlocObjectToOperatorLogTool_ShouldNotUpdateIfFlocIsAnOltSourcedFloc()
        {
            // in this case, an update comes in that has a different language code than the existing FLOC as well as different
            // from the site default. It should not update the FLOC.

            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.LanguageCode = LanguageCode.English.SapCode;

            var functionalLocation = new FunctionalLocation(1000, SiteFixture.Lab(),
                functionalLocationDetails.FullHierarchy, "New FLOC description", false, false,
                long.Parse(functionalLocationDetails.PlantId), Culture.DEFAULT_CULTURE_NAME,
                FunctionalLocationSource.OLT);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Lab()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Lab());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Expect.Once.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Lab().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Never.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Lab().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Never.On(mockFunctionalLocationService).Method("Update");

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void
            CallingUpdateTypeFlocObjectToOperatorLogTool_ShouldNotUpdateIfLanguageCodeIsDifferentThanFLOCandSiteDefault()
        {
            // in this case, an update comes in that has a different language code than the existing FLOC as well as different
            // from the site default. It should not update the FLOC.

            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.LanguageCode = LanguageCode.French.SapCode;

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), string.Empty,
                Culture.DEFAULT_CULTURE_NAME) {Description = "New FLOC description"};


            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Never.On(mockFunctionalLocationService).Method("Update");

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void CallingUpdateTypeFlocObjectWithOlderFlocToOperatorLogToolShouldCallUpdate()
        {
            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.OldFLOC = "SR1-PL3-HYDU-SMP-33P007B";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId),
                functionalLocationDetails.Description,
                Culture.DEFAULT_CULTURE_NAME);

            var oldFunctionalLocation = FunctionalLocationFixture.CreateNew("SR1-PL3-HYDU-SMP-33P007B");

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .With(functionalLocationDetails.OldFLOC,
                    SiteFixture.Sarnia().IdValue).Will(
                        Return.Value(oldFunctionalLocation));
            Expect.Once.On(mockFunctionalLocationService).Method("Update").With(oldFunctionalLocation);

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCreateFullHierarchyFromBoth()
        {
            var flocId = "HIHI-252";
            var superiorFlocId = "EX1-P001";

            var fullHierarchy = FlocAdapter.CreateFullHierarchyIncludingSuperior(flocId, superiorFlocId);
            Assert.That(fullHierarchy, Is.EqualTo("EX1-P001-HIHI-252"));
        }

        [Test]
        public void ShouldCreateFullHierarchyFromFlocIdWhenSuperiorFlocIsEmpty()
        {
            var flocId = "EX1-P001-HIHI-252";
            var superiorFlocId = string.Empty;

            var fullHierarchy = FlocAdapter.CreateFullHierarchyIncludingSuperior(flocId, superiorFlocId);
            Assert.That(fullHierarchy, Is.EqualTo(flocId));
        }

        [Test]
        public void ShouldCreateFullHierarchyFromFlocIdWhenSuperiorFlocIsSame()
        {
            var flocId = "EX1-P001-HIHI-252";
            var superiorFlocId = "EX1-P001-HIHI-252";

            var fullHierarchy = FlocAdapter.CreateFullHierarchyIncludingSuperior(flocId, superiorFlocId);
            Assert.That(fullHierarchy, Is.EqualTo(flocId));
        }

        [Test]
        public void ShouldCreateFullHierarchyFromFlocIdWhenSuperiorFlocIsSameIgnoringCase()
        {
            var flocId = "EX1-P001-HIHI-252";
            var superiorFlocId = "EX1-P001-hihi-252";

            var fullHierarchy = FlocAdapter.CreateFullHierarchyIncludingSuperior(flocId, superiorFlocId);
            Assert.That(fullHierarchy, Is.EqualTo(flocId));
        }

        [Test]
        public void ShouldDeleteTheFLOCIfTheMessagesLanguageCodeMatches()
        {
            functionalLocationDetails.Action = "Delete";
            functionalLocationDetails.LanguageCode = LanguageCode.French.SapCode;
            functionalLocationDetails.Description = "The FLOC description";

            var existingFloc = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), "The FLOC description",
                Culture.FrenchCultureName);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue).Will(Return.Value(existingFloc));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue).Will(Return.Value(existingFloc));

            Expect.Once.On(mockFunctionalLocationService).Method("RemoveByFullHierarchy").WithAnyArguments();

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldIgnoreSuperiorFlocIfItStartsTheSameAsFloc()
        {
            var flocId = "EX1-P001-HIHI-252";
            var superiorFlocId = "EX1-P001-HIHI";

            var fullHierarchy = FlocAdapter.CreateFullHierarchyIncludingSuperior(flocId, superiorFlocId);
            Assert.That(fullHierarchy, Is.EqualTo(flocId));
        }

        [Test]
        public void ShouldNotDeleteTheFLOCIfTheMessagesLanguageCodeDoesntMatch()
        {
            functionalLocationDetails.Action = "Delete";
            functionalLocationDetails.LanguageCode = LanguageCode.English.SapCode;
            functionalLocationDetails.Description = "The FLOC description";

            var existingFloc = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), "The FLOC description",
                Culture.FrenchCultureName);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue).Will(Return.Value(existingFloc));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue).Will(Return.Value(existingFloc));

            Expect.Never.On(mockFunctionalLocationService).Method("RemoveByFullHierarchy").WithAnyArguments();

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldUpdateTheLanguageCodeIfTheDescriptionIsTheSameAndTheCodeMatchesTheSiteDefault()
        {
            // in this case, an update comes in that has the same language code as the existing FLOC but is different
            // than the site default. It should update the FLOC.

            functionalLocationDetails.Action = "Change";
            functionalLocationDetails.LanguageCode = LanguageCode.English.SapCode;
            functionalLocationDetails.Description = "The FLOC description";

            var functionalLocation = new FunctionalLocation(SiteFixture.Sarnia(),
                functionalLocationDetails.FullHierarchy,
                long.Parse(functionalLocationDetails.PlantId), "The FLOC description",
                Culture.FrenchCultureName);

            Expect.Once.On(mockSiteService).Method("QueryByPlantId").With(functionalLocationDetails.PlantId).Will(
                Return.Value(SiteFixture.Sarnia()));

            var configuration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Sarnia());
            configuration.Culture = Culture.DEFAULT_CULTURE_NAME;
            Stub.On(mockSiteConfigurationService)
                .Method("QueryBySiteId")
                .WithAnyArguments()
                .Will(Return.Value(configuration));

            Stub.On(mockFunctionalLocationService).Method("QueryByFullHierarchyIncludeDeleted").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.AtLeastOnce.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                functionalLocationDetails.FullHierarchy, SiteFixture.Sarnia().IdValue)
                .Will(Return.Value(functionalLocation));

            Expect.Once.On(mockFunctionalLocationService).Method("Update").WithAnyArguments();

            adapter = new FlocAdapter(
                functionalLocationDetails,
                logger,
                mockFunctionalLocationService,
                mockSiteService,
                mockSiteConfigurationService,
                mockFunctionalLocationOperationalModeService,
                mockUserService);
            adapter.IntegrateFlocObjectToOperatorLogTool();

            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}