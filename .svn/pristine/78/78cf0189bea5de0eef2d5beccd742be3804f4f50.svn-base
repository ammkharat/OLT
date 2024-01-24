using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class GasTestElementDaoTest : AbstractDaoTest
    {
        private IGasTestElementDao dao;
        private IGasTestElementInfoDao infoDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IGasTestElementDao>();
            infoDao = DaoRegistry.GetDao<IGasTestElementInfoDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldUpdateIdOnInsert()
        {
            const long workPermitId = 1;
            GasTestElement element = GasTestElementFixture.CreateGasTestElementWithOtherElementInfo();
            Assert.IsNull(element.Id);
            element = dao.Insert(element, workPermitId);
            Assert.IsNotNull(element.Id);
        }

        [Ignore] [Test]
        public void ShouldRemoveGasTestElement()
        {
            // Setup an element for deleting:
            const long WORK_PERMIT_ID = 1;
            GasTestElement newElement = InsertNonStandardElement(WORK_PERMIT_ID);
            // Execute:
            dao.Remove(newElement);
            // Make sure element is gone:
            List<GasTestElement> retrievedElements =
                dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(WORK_PERMIT_ID,0);

            Assert.That(retrievedElements, Has.None.Property("Id").EqualTo( newElement.Id));
        }

        [Ignore] [Test]
        public void ShouldQueryAllGasTestElementBasedOnGivenWorkPermitId()
        {
            const long workPermitId = 5;
            const int expectedNumberOfGasTestElement = 3;
            List<GasTestElement> elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(workPermitId,0);
            Assert.AreEqual(expectedNumberOfGasTestElement, elementList.Count);
        }

        [Ignore] [Test]
        public void ShouldPersistAndQueryConfinedSpaceGasTestElementValues()
        {
            const int workPermitId = 1;
            GasTestElement confinedSpaceGasTestElement = GasTestElement.CreateGasTestElement(infoDao.QueryStandardInfosBySiteId(Site.SARNIA_ID)[0]);
            confinedSpaceGasTestElement.ConfinedSpaceTestResult = 23.3;
            confinedSpaceGasTestElement.ConfinedSpaceTestRequired = true;
            confinedSpaceGasTestElement = dao.Insert(confinedSpaceGasTestElement, workPermitId);
            List<GasTestElement> list = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(workPermitId,0);

            Assert.That(list, Has.Some.EqualTo(confinedSpaceGasTestElement));
        }

        [Ignore] [Test]
        public void ShouldAlsoInsertGasTestElementInfoOnInsert()
        {
            const long workPermitId = 1;
            GasTestElement gasTestElement = GasTestElementFixture.CreateGasTestElementWithOtherElementInfo();
            Assert.IsNotNull(gasTestElement.ElementInfo);
            Assert.IsFalse(gasTestElement.ElementInfo.Id.HasValue);
            dao.Insert(gasTestElement, workPermitId);
            List<GasTestElement> elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(workPermitId,0);

            Assert.That(elementList, Has.All.Not.Null);
        }

        #region OnUpdate Tests

        [Ignore] [Test]
        public void ShouldUpdateNewFirstTestResultAndRequiredValueOnUpdate()
        {
            const long associatedWorkPermitId = 6;
            const int expectedNumberOfGasTestElement = 2;
            List<GasTestElement> elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(associatedWorkPermitId,0);
            Assert.AreEqual(expectedNumberOfGasTestElement, elementList.Count);
            GasTestElement element = elementList[0];
            const double newFirstTestResultVal = 123;
            bool newRequiredVal = !element.ImmediateAreaTestRequired;
            element.ImmediateAreaTestResult = newFirstTestResultVal;
            element.ImmediateAreaTestRequired = newRequiredVal;
            dao.Update(element);
            elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(associatedWorkPermitId,0);
            Assert.AreEqual(expectedNumberOfGasTestElement, elementList.Count);
            element = elementList[0];

            Assert.AreEqual(newFirstTestResultVal, element.ImmediateAreaTestResult);
            Assert.AreEqual(newRequiredVal, element.ImmediateAreaTestRequired);
        }

        [Ignore] [Test]
        public void ShouldAlsoUpdateNonStandardGasTestElementInfoOnUpdate()
        {
            const long associatedWorkPermitId = 6;
            const int expectedNumberOfGasTestElement = 2;
            const long expectedOtherElementInfoId = 100;
            List<GasTestElement> elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(associatedWorkPermitId,0);
            Assert.AreEqual(expectedNumberOfGasTestElement, elementList.Count);


            //
            //  Find Element with other element info
            //
            GasTestElement elementToBeUpdated = elementList.Find(element => !element.ElementInfo.IsStandard);

            Assert.That(elementToBeUpdated, Is.Not.Null, "Unable to find expected Element with other element info");

            Assert.AreEqual(expectedOtherElementInfoId, elementToBeUpdated.ElementInfo.Id);
            const string newOtherElementInfoName = "Super Other Name";
            const string newOtherElementInfoLimit = "New Other Limit";
            elementToBeUpdated.ElementInfo.Name = newOtherElementInfoName;
            elementToBeUpdated.ElementInfo.OtherLimits = newOtherElementInfoLimit;
            GasTestElementInfo expectedOtherElementInfo = elementToBeUpdated.ElementInfo;
            dao.Update(elementToBeUpdated);

            elementList = dao.QueryAllGasTestElementByWorkPermitIdAndSiteId(associatedWorkPermitId,0);
            Assert.AreEqual(expectedNumberOfGasTestElement, elementList.Count);
            
            GasTestElement actualGasTest = elementList.Find(element => !element.ElementInfo.IsStandard);

            Assert.That(actualGasTest, Is.Not.Null, "Unable to find expected quried gas test element of other element info");
            Assert.That(actualGasTest.ElementInfo, Is.EqualTo(expectedOtherElementInfo));
        }

        #endregion OnUpdate Tests

        private GasTestElement InsertNonStandardElement(long workPermitId)
        {
            GasTestElement element = GasTestElementFixture.CreateGasTestElementWithOtherElementInfo();
            element = dao.Insert(element, workPermitId);
            Assert.IsNotNull(element.Id);
            Assert.IsNotNull(element.ElementInfo.Id);
            return element;
        }
    }
}