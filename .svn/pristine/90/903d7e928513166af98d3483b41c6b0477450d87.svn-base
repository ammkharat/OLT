using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class DeviationAlertServiceTest
    {
        private Mockery mock;

        private IDeviationAlertDTODao deviationAlertDTODao;
        private IDeviationAlertResponseDao deviationAlertResponseDao;
        private IUserService userService;
        private ITimeDao timeDao;
        private IDeviationAlertDao deviationAlertDao;
        private IPlantHistorianService historianService;
        private ISiteConfigurationDao siteConfigurationDao;
        private ITagDao tagDao;
        private IRestrictionDefinitionDao restrictionDefinitionDao;
        private IEditHistoryService historyService;

        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            deviationAlertDTODao = mock.NewMock<IDeviationAlertDTODao>();
            userService = mock.NewMock<IUserService>();
            timeDao = mock.NewMock<ITimeDao>();
            deviationAlertDao = mock.NewMock<IDeviationAlertDao>();
            historianService = mock.NewMock<IPlantHistorianService>();
            siteConfigurationDao = mock.NewMock<ISiteConfigurationDao>();
            deviationAlertResponseDao = mock.NewMock<IDeviationAlertResponseDao>();
            tagDao = mock.NewMock<ITagDao>();
            restrictionDefinitionDao = mock.NewMock<IRestrictionDefinitionDao>();
            historyService = mock.NewMock<IEditHistoryService>();

            DaoRegistry.Clear();
            DaoRegistry.RegisterDaoFor(deviationAlertDTODao);
            DaoRegistry.RegisterDaoFor(timeDao);
            DaoRegistry.RegisterDaoFor(deviationAlertDao);
            DaoRegistry.RegisterDaoFor(siteConfigurationDao);
            DaoRegistry.RegisterDaoFor(deviationAlertResponseDao);            
            DaoRegistry.RegisterDaoFor(tagDao);
            DaoRegistry.RegisterDaoFor(restrictionDefinitionDao);
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForIsWithinDaysToEditResponseIfAlertHasNotBeenRespondedToAndIsOutsideOfEditDateRange()
        {
            DateTime currentTimeAtSite = new DateTime(2099, 3, 20, 3, 40, 50);
            const int daysToEditDeviationAlerts = 10;

            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite);
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.AddMilliseconds(1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.AddMilliseconds(-1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(daysToEditDeviationAlerts));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                false, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(daysToEditDeviationAlerts).AddMilliseconds(-1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                false, DeviationAlertStatus.RequiresResponse, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(11));
        }

        [Ignore] [Test]
        public void ShouldReturnFalseForIsWithinDaysToEditResponseIfAlertHasResponseAndIsOutsideOfEditDateRange()
        {
            DateTime currentTimeAtSite = new DateTime(2099, 3, 20, 3, 40, 50);
            const int daysToEditDeviationAlerts = 10;

            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite);
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.AddMilliseconds(1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.AddMilliseconds(-1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                true, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(daysToEditDeviationAlerts));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                false, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(daysToEditDeviationAlerts).AddMilliseconds(-1));
            AssertCheckIfAlertIsWithinDaysToEditResponse(
                false, DeviationAlertStatus.Responded, daysToEditDeviationAlerts,
                currentTimeAtSite, currentTimeAtSite.SubtractDays(11));
        }

        private void AssertCheckIfAlertIsWithinDaysToEditResponse(
            bool expectedIsWithin, 
            DeviationAlertStatus status,
            int daysToEditDeviationAlerts,
            DateTime currentTimeAtSite,
            DateTime alertStartTime)
        {
            Site site = SiteFixture.Sarnia();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            siteConfiguration.DaysToEditDeviationAlerts = daysToEditDeviationAlerts;
            Stub.On(siteConfigurationDao).Method("QueryBySiteId").Will(Return.Value(siteConfiguration));

            Stub.On(timeDao).Method("GetTime").Will(Return.Value(currentTimeAtSite));

            DeviationAlertDTO alert = DeviationAlertDTOFixture.Create(status, alertStartTime);

            DeviationAlertService service = new DeviationAlertService(userService, historianService, historyService);
            bool isWithinDaysToEditResponse = service.IsWithinDaysToEditResponse(site, new List<DeviationAlertDTO> {alert});
            Assert.AreEqual(expectedIsWithin, isWithinDaysToEditResponse);
        }
    }
}
