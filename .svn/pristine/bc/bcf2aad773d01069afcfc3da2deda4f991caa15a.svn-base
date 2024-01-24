using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetAlertResponseDaoTest : AbstractDaoTest
    {
        private ITargetAlertResponseDao responseDao;
        private ITargetAlertDao targetAlertDao;
        private ICommentDao commentDao;
        private IFunctionalLocationDao functionalLocationDao;

        protected override void TestInitialize()
        {
            targetAlertDao = DaoRegistry.GetDao<ITargetAlertDao>();
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            responseDao = DaoRegistry.GetDao<ITargetAlertResponseDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertShiftPattern()
        {
            TargetAlertResponse response = TargetAlertResponseFixture.CreateNewResponse();
            TargetAlertResponse insertedResponse = responseDao.Insert(response);
            
            string query = string.Format("select CreatedShiftPatternId from TargetAlertResponse where id = {0}", 
                                         insertedResponse.Id);

            long shiftPatternId = TestDataAccessUtil.ExecuteScalarExpression<long>(query);
            
            Assert.AreEqual(response.CreatedInShiftPattern.Id, shiftPatternId);
        }      
        
        [Ignore] [Test]
        public void QueryForShiftGapReasonReportDataShouldReturnBasicData()
        {
            DateTime fromDate = new DateTime(2006, 1, 1);
            DateTime toDate = new DateTime(2006, 2, 1);
            List<FunctionalLocation> flocList =
                new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF() };
            ShiftPattern testDataShiftPattern = ShiftPatternFixture.CreateShiftPattern(null, null, DateTimeFixture.DateTimeNow, SiteFixture.Sarnia());

            List<ShiftGapReasonReportDTO> results = 
                responseDao.QueryGapReasonsByShiftAndDateRange(new RootFlocSet(flocList), testDataShiftPattern, 
                                                             fromDate, toDate);
            Assert.IsNotNull(results);
            CollectionAssert.IsNotEmpty(results);
        }
        
        [Ignore] [Test]
        public void QueryForShiftGapReasonReportDataShouldReturnDataForNextDayOfNightShift()
        {
            FunctionalLocation unitFloc = InsertUnitFunctionalLocation();
            FunctionalLocation floc = InsertEquipment1FunctionalLocation(unitFloc);

            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();
            DateTime createdDateTime = new DateTime(2006, 08, 31, 04, 00, 00);
            
            // Create a response in the "next day" of the 08/30 18:00 to 08/31 06:00 shift:
            TargetAlertResponse response = 
                TargetAlertResponseFixture.CreateNewResponse(nightShift, createdDateTime, "Get me!");
            response.Alert.FunctionalLocation = floc;

            InsertTargetAlertResponseAndReturnComment(response);

            List<ShiftGapReasonReportDTO> results =
                responseDao.QueryGapReasonsByShiftAndDateRange(new RootFlocSet(unitFloc),
                                                             nightShift,
                                                             new DateTime(2006, 08, 30, 18, 00, 00),
                                                             new DateTime(2006, 08, 31, 06, 00, 00));
            Assert.AreEqual(1, results.Count);
//            Assert.AreEqual(insertedComment.Text, results[0].Description);
        }

        [Ignore] [Test]
        public void QueryForShiftGapReasonReportDataShouldReturnResponsesWithoutResponsibleFloc()
        {
            FunctionalLocation unitFloc = InsertUnitFunctionalLocation();
            FunctionalLocation floc = InsertEquipment1FunctionalLocation(unitFloc);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            DateTime createdDateTime = new DateTime(2006, 08, 30, 20, 00, 00);
            
            TargetAlertResponse response = 
                TargetAlertResponseFixture.CreateNewResponse(shiftPattern, createdDateTime, "text");
            response.ResponsibleForGap = null;
            response.Alert.FunctionalLocation = floc;

            InsertTargetAlertResponseAndReturnComment(response);

            List<ShiftGapReasonReportDTO> results =
                responseDao.QueryGapReasonsByShiftAndDateRange(new RootFlocSet(unitFloc),
                                                             shiftPattern,
                                                             new DateTime(2006, 08, 30, 18, 00, 00),
                                                             new DateTime(2006, 08, 31, 06, 00, 00));
            Assert.AreEqual(1, results.Count);
//            Assert.AreEqual(insertedComment.Text, results[0].Description);
        }

        [Ignore] [Test]
        public void QueryByTargetAlertShouldReturnResponsesForTargetAlert()
        {
            TargetAlertResponse response = TargetAlertResponseFixture.CreateNewResponse();
            TargetAlert alert = targetAlertDao.Insert(response.Alert);
            Comment insertedComment = commentDao.InsertComment(response.ResponseComment);
            TargetAlertResponse insertedResponse = responseDao.Insert(response);

            List<TargetAlertResponse> retrievedResponses = responseDao.QueryByTargetAlert(alert);
            Assert.AreEqual(1, retrievedResponses.Count);
            
            Assert.AreEqual(insertedResponse.Id, retrievedResponses[0].Id);
            Assert.AreEqual(insertedComment.Id, retrievedResponses[0].ResponseComment.Id);
        }

        [Ignore] [Test]
        public void EveningShiftStartDateShouldRemainInPreviousDateIfResponseCreatedInTheFollowingDay()
        {
            FunctionalLocation unitFloc = InsertUnitFunctionalLocation();
            FunctionalLocation floc = InsertEquipment1FunctionalLocation(unitFloc);

            ShiftPattern nightShift_8PM_To_8AM = ShiftPatternFixture.CreateNightShift();
            DateTime createdDateTime7PM = new DateTime(2006, 08, 31, 1, 00, 00);

            TargetAlertResponse responseBeforeOverLappingShiftDate = TargetAlertResponseFixture.CreateNewResponse(nightShift_8PM_To_8AM, createdDateTime7PM, "text");
            responseBeforeOverLappingShiftDate.ResponsibleForGap = null;
            responseBeforeOverLappingShiftDate.Alert.FunctionalLocation = floc;

            InsertTargetAlertResponseAndReturnComment(responseBeforeOverLappingShiftDate);

            List<ShiftGapReasonReportDTO> results =
                responseDao.QueryGapReasonsByShiftAndDateRange(new RootFlocSet(unitFloc),
                                                             nightShift_8PM_To_8AM,
                                                             new DateTime(2006, 08, 30, 18, 00, 00),
                                                             new DateTime(2006, 08, 31, 06, 00, 00));

            Date expectedShiftStartDate = new Date(2006, 8, 30);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expectedShiftStartDate, results[0].ShiftStartDate.ToDate());
        }

        private void InsertTargetAlertResponseAndReturnComment(TargetAlertResponse response)
        {
            targetAlertDao.Insert(response.Alert);
            commentDao.InsertComment(response.ResponseComment);
            responseDao.Insert(response);
        }

        private FunctionalLocation InsertUnitFunctionalLocation()
        {
            FunctionalLocation unitFloc = FunctionalLocationFixture.CreateNew("SR1-OFFS-NEW");
            functionalLocationDao.Insert(unitFloc);
            return unitFloc;
        }

        private FunctionalLocation InsertEquipment1FunctionalLocation(FunctionalLocation unitFloc)
        {
            FunctionalLocation equip1 = FunctionalLocationFixture.CreateNewEquipment1UnderAGivenUnit(unitFloc, "PRINTER");
            functionalLocationDao.Insert(equip1);
            return equip1;
        }
    }
}