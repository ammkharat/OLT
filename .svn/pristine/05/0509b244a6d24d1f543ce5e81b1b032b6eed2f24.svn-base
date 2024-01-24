using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.Bootstrap;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class DeviationAlertResponseReasonCodeAssignmentDaoTest : AbstractDaoTest
    {
        private IDeviationAlertResponseReasonCodeAssignmentDao dao;
        private IRestrictionReasonCodeDao reasonCodeDao;       


        protected override void TestInitialize()
        {
            Bootstrapper.BootstrapDaos();
            dao = DaoRegistry.GetDao<IDeviationAlertResponseReasonCodeAssignmentDao>();

            reasonCodeDao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldQueryByResponseId()
        {
            List<DeviationAlertResponseReasonCodeAssignment> resultList = dao.QueryByDeviationAlertResponseId(1);

            Assert.IsTrue(resultList.Count >= 2);

            DeviationAlertResponseReasonCodeAssignment assignment1 = resultList.Find(obj => obj.Id == 1);

            Assert.AreEqual(1, assignment1.RestrictionReasonCode.Id);
            Assert.AreEqual(7311, assignment1.FunctionalLocation.Id);
            Assert.AreEqual(1000, assignment1.AssignedAmount);
            Assert.AreEqual(1, assignment1.LastModifiedBy.Id);
            Assert.AreEqual(1, assignment1.CreatedDateTime.Month);
            Assert.AreEqual(2, assignment1.LastModifiedDateTime.Month);
            Assert.AreEqual("This is a reason code assignment comment", assignment1.Comments);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            RestrictionReasonCode reasonCode = reasonCodeDao.QueryById(1);

            const string comments = "I love that these have comments now";
            const int assignedAmount = 12345;

            User lastModifiedBy = UserFixture.CreateUserWithGivenId(1);
            DateTime lastModified = DateTimeFixture.DateTimeNow;
            DateTime created = DateTimeFixture.DateTimeNow;

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(floc, reasonCode);
            DeviationAlertResponseReasonCodeAssignment assignment =
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, floc, reasonCode, "Shutdown", assignedAmount, comments, lastModifiedBy, lastModified, created);

            DeviationAlertResponseReasonCodeAssignment assignmentReturnedFromInsert = dao.Insert(assignment, 1);

            List<DeviationAlertResponseReasonCodeAssignment> assignments = 
                    dao.QueryByDeviationAlertResponseId(1);

            DeviationAlertResponseReasonCodeAssignment recentlyInsertedAssignment = 
                assignments.FindById(assignmentReturnedFromInsert);

            Assert.IsNotNull(recentlyInsertedAssignment);
            Assert.AreEqual(assignedAmount, recentlyInsertedAssignment.AssignedAmount);
            Assert.AreEqual(comments, recentlyInsertedAssignment.Comments);
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            
        }
    }
}
