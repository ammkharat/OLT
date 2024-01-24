using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Scheduled_Jobs
{
    [TestFixture]
    public class TagInformationJobTest
    {
        private readonly List<string> TEST_SET_OF_ALPHANUMERIC_CHARACTERS =
            new List<string>(new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"});

        private TagInformationJob job;
        private Mockery mock;
        private ILog mockLogger;
        private IPlantHistorianService mockPlantHistorianService;
        private ITagService mockTagService;
        private Site site;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            mock = new Mockery();
            mockTagService = mock.NewMock<ITagService>();
            mockPlantHistorianService = mock.NewMock<IPlantHistorianService>();
            mockLogger = mock.NewMock<ILog>();

            Stub.On(mockLogger);
        }


        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void DeterminePrefixesForSiteShouldBuildCustomPrefixesForDenver()
        {
            site = SiteFixture.Denver();

            var dateTime = Clock.Now;
            var timeToRun = dateTime.ToTime().AddMinutes(5);
            var schedule = new RecurringDailySchedule(dateTime.ToDate(), null, timeToRun, timeToRun, 1,
                SiteFixture.Oilsands());
            job = new TagInformationJob(site, schedule, mockTagService, mockPlantHistorianService, mockLogger);

            job.DeterminePrefixesForSite(TEST_SET_OF_ALPHANUMERIC_CHARACTERS);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void DeterminePrefixesForSiteShouldBuildCustomPrefixesForFirebag()
        {
            site = SiteFixture.Firebag();

            var dateTime = Clock.Now;
            var timeToRun = dateTime.ToTime().AddMinutes(5);
            var schedule = new RecurringDailySchedule(dateTime.ToDate(), null, timeToRun, timeToRun, 1,
                SiteFixture.Oilsands());
            job = new TagInformationJob(site, schedule, mockTagService, mockPlantHistorianService, mockLogger);

            var results = job.DeterminePrefixesForSite(TEST_SET_OF_ALPHANUMERIC_CHARACTERS);
            Assert.AreEqual(new List<string>(new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"}), results);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void DeterminePrefixesForSiteShouldReturnStandardAlphanumericsForHoneywellPHD()
        {
            site = SiteFixture.Sarnia();

            var dateTime = Clock.Now;
            var timeToRun = dateTime.ToTime().AddMinutes(5);
            var schedule = new RecurringDailySchedule(dateTime.ToDate(), null, timeToRun, timeToRun, 1,
                SiteFixture.Oilsands());

            job = new TagInformationJob(site, schedule, mockTagService, mockPlantHistorianService, mockLogger);

            var results = job.DeterminePrefixesForSite(TEST_SET_OF_ALPHANUMERIC_CHARACTERS);
            Assert.AreEqual(TEST_SET_OF_ALPHANUMERIC_CHARACTERS, results);
        }

        [Test]
        public void ShouldExecuteGettingTheTagInformation()
        {
            site = SiteFixture.Denver();

            var dateTime = Clock.Now;
            var timeToRun = dateTime.ToTime().AddMinutes(5);
            var schedule = new RecurringDailySchedule(dateTime.ToDate(), null, timeToRun, timeToRun, 1,
                SiteFixture.Oilsands());
            job = new TagInformationJob(site, schedule, mockTagService, mockPlantHistorianService, mockLogger);

            Expect.AtLeastOnce.On(mockPlantHistorianService).Method("HasPlantHistorian").Will(Return.Value(true));
            Expect.AtLeastOnce.On(mockPlantHistorianService).Method("GetTagInfoList").WithAnyArguments();
            Expect.AtLeastOnce.On(mockTagService).Method("UpdatePlantHistorianTagInfoList").WithAnyArguments();
            job.Execute();

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}