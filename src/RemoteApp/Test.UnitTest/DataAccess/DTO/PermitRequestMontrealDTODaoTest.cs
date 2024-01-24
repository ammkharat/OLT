using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class PermitRequestMontrealDTODaoTest : AbstractDaoTest
    {
        private IPermitRequestMontrealDTODao dtoDao;
        private IPermitRequestMontrealDao permitRequestDao;
        private IUserDao userDao;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IPermitRequestMontrealDTODao>();
            permitRequestDao = DaoRegistry.GetDao<IPermitRequestMontrealDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        protected override void Cleanup()
        {
        }

        private static PermitRequestMontreal CreatePermitRequest(User user)
        {
            return CreatePermitRequest(FunctionalLocationFixture.GetReal_MT1_A001_U010(), new Date(2001, 2, 3), new Date(2001, 4, 5), user);
        }

        private static PermitRequestMontreal CreatePermitRequest(List<FunctionalLocation> flocs, Date start, Date end)
        {
            return CreatePermitRequest(flocs, start, end, UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB());
        }

        private static PermitRequestMontreal CreatePermitRequest(FunctionalLocation floc, Date start, Date end, User user)
        {
            return CreatePermitRequest(new List<FunctionalLocation> { floc }, start, end, user);
        }

        private static PermitRequestMontreal CreatePermitRequest(List<FunctionalLocation> flocs, Date start, Date end, User user)
        {
            
            return new PermitRequestMontreal(
                null,
                WorkPermitMontrealType.MODERATE_HOT,
                flocs,
                start,
                end,
                "112233",
                "030",
                "0110",                
                "trade ABC",
                "permit request description",
                "permit request description (SAP)",
                null, null, null,
                DataSource.MANUAL,
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite(),
                new DateTime(2001, 10, 11),
                UserFixture.CreateAdmin(),
                new DateTime(2001, 12, 13),
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2002, 6, 7),
                user,
                new DateTime(2002, 8, 9),
                WorkPermitMontrealGroupFixture.CreateWithExistingId(),
                PermitRequestCompletionStatus.Complete);
        }

        [Ignore] [Test]
        public void ShouldReturnPopulated()
        {
            User lastModifiedUser = UserFixture.CreateOperator(0, "ModifiedName");
            lastModifiedUser.FirstName = "ModifiedFirst";
            lastModifiedUser.LastName = "ModifiedLast";
            lastModifiedUser = userDao.Insert(lastModifiedUser);

            User lastImportedByUser = UserFixture.CreateOperator(0, "ImportedName");
            lastImportedByUser.FirstName = "ImportedFirst";
            lastImportedByUser.LastName = "ImportedLast";
            lastImportedByUser = userDao.Insert(lastImportedByUser);

            User lastSubmittedByUser = UserFixture.CreateOperator(0, "SubmittedName");
            lastSubmittedByUser.FirstName = "SubmittedFirst";
            lastSubmittedByUser.LastName = "SubmittedLast";
            lastSubmittedByUser = userDao.Insert(lastSubmittedByUser);

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_MT1_A002_U430();

            PermitRequestMontreal permitRequest = CreatePermitRequest(lastModifiedUser);
            permitRequest.LastImportedByUser = lastImportedByUser;
            permitRequest.LastImportedDateTime = new DateTime(2003, 5, 1);
            permitRequest.LastSubmittedByUser = lastSubmittedByUser;
            permitRequest.LastSubmittedDateTime = new DateTime(2003, 5, 2);
            permitRequest.FunctionalLocations.Clear();
            permitRequest.FunctionalLocations.Add(floc1);
            permitRequest.FunctionalLocations.Add(floc2);
            permitRequest = permitRequestDao.Insert(permitRequest);

            List<FunctionalLocation> functionalLocations = permitRequest.FunctionalLocations;
            List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));

            PermitRequestMontrealDTO result = results.Find(obj => obj.Id == permitRequest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(WorkPermitMontrealType.MODERATE_HOT, result.WorkPermitType);
                        
            Assert.AreEqual(2, permitRequest.FunctionalLocations.Count);
            Assert.IsTrue(permitRequest.FunctionalLocations.Exists(floc => floc.FullHierarchy == floc1.FullHierarchy));
            Assert.IsTrue(permitRequest.FunctionalLocations.Exists(floc => floc.FullHierarchy == floc2.FullHierarchy));

            Assert.AreEqual(permitRequest.StartDate, result.StartDate);
            Assert.AreEqual(permitRequest.EndDate, result.EndDate);
            Assert.AreEqual(permitRequest.WorkOrderNumber, result.WorkOrderNumber);
            Assert.AreEqual(permitRequest.OperationNumber, result.OperationNumber);
            Assert.AreEqual(permitRequest.Trade, result.Trade);
            Assert.AreEqual(permitRequest.Description, result.Description);
            Assert.AreEqual(permitRequest.DataSource, result.DataSource);
            Assert.AreEqual(permitRequest.LastImportedByUser.FullNameWithUserName, result.LastImportedByFullnameWithUserName);
            Assert.AreEqual(permitRequest.LastImportedDateTime, result.LastImportedDateTime);
            Assert.AreEqual(permitRequest.LastSubmittedByUser.FullNameWithUserName, result.LastSubmittedByFullnameWithUserName);
            Assert.AreEqual(permitRequest.LastSubmittedDateTime, result.LastSubmittedDateTime);
            Assert.AreEqual(permitRequest.CreatedBy.Id, result.CreatedByUserId);
            Assert.AreEqual(permitRequest.LastModifiedDateTime, result.LastModifiedDateTime);
            Assert.AreEqual(permitRequest.LastModifiedBy.FullNameWithUserName, result.LastModifiedByFullnameWithUserName);
        }

        [Ignore] [Test]
        public void ShouldReturnNullFields()
        {
            PermitRequestMontreal permitRequest = CreatePermitRequest(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB());
            permitRequest.WorkOrderNumber = null;
            permitRequest.OperationNumber = null;
            permitRequest.LastImportedByUser = null;
            permitRequest.LastImportedDateTime = null;
            permitRequest.LastSubmittedByUser = null;
            permitRequest.LastSubmittedDateTime = null;
            permitRequest = permitRequestDao.Insert(permitRequest);

            List<FunctionalLocation> functionalLocations = permitRequest.FunctionalLocations;
            List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));

            PermitRequestMontrealDTO result = results.Find(obj => obj.Id == permitRequest.Id);
            Assert.IsNotNull(result);
            Assert.IsNull(result.WorkOrderNumber);
            Assert.IsNull(result.OperationNumber);
            Assert.True(string.IsNullOrEmpty(result.LastImportedByFullnameWithUserName));
            Assert.IsNull(result.LastImportedDateTime);
            Assert.True(string.IsNullOrEmpty(result.LastSubmittedByFullnameWithUserName));
            Assert.IsNull(result.LastSubmittedDateTime);
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeleted()
        {
            PermitRequestMontreal permitRequest = CreatePermitRequest(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB());
            permitRequest = permitRequestDao.Insert(permitRequest);

            List<FunctionalLocation> functionalLocations = permitRequest.FunctionalLocations;

            {
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest.Id));
            }

            permitRequestDao.Remove(permitRequest);

            {
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == permitRequest.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            PermitRequestMontreal permitRequest1 = permitRequestDao.Insert(CreatePermitRequest(
                new List<FunctionalLocation> { floc }, new Date(2010, 1, 2), new Date(2010, 1, 4)));
            PermitRequestMontreal permitRequest2 = permitRequestDao.Insert(CreatePermitRequest(
                new List<FunctionalLocation> { floc }, new Date(2010, 1, 2), new Date(2010, 1, 2)));

            AssertQueryByDateRange(true, null, null, permitRequest1);

            AssertQueryByDateRange(false, new Date(2010, 1, 1), new Date(2010, 1, 1), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 2), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 3), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 4), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 5), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 2), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 3), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 4), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 5), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 3), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 4), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 3), new Date(2010, 1, 5), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 4), new Date(2010, 1, 4), permitRequest1);
            AssertQueryByDateRange(true, new Date(2010, 1, 4), new Date(2010, 1, 5), permitRequest1);
            AssertQueryByDateRange(false, new Date(2010, 1, 5), new Date(2010, 1, 5), permitRequest1);

            AssertQueryByDateRange(true, null, null, permitRequest2);

            AssertQueryByDateRange(false, new Date(2010, 1, 1), new Date(2010, 1, 1), permitRequest2);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 2), permitRequest2);
            AssertQueryByDateRange(true, new Date(2010, 1, 1), new Date(2010, 1, 3), permitRequest2);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 2), permitRequest2);
            AssertQueryByDateRange(true, new Date(2010, 1, 2), new Date(2010, 1, 3), permitRequest2);
            AssertQueryByDateRange(false, new Date(2010, 1, 3), new Date(2010, 1, 3), permitRequest2);
        }

        private void AssertQueryByDateRange(bool permitExists, Date from, Date to, PermitRequestMontreal permitRequest)
        {
            List<FunctionalLocation> functionalLocations = permitRequest.FunctionalLocations;
            List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(from, to));
            Assert.AreEqual(permitExists, results.Exists(obj => obj.Id == permitRequest.Id));
        }

        [Ignore] [Test]
        public void ShouldQueryByFloc()
        {
            Date someDate = new Date(2010, 6, 3);

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            FunctionalLocation floc4 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SCH_33CR001();

            PermitRequestMontreal permitRequest1 = permitRequestDao.Insert(CreatePermitRequest(new List<FunctionalLocation> { floc3 }, someDate, someDate));
            PermitRequestMontreal permitRequest2 = permitRequestDao.Insert(CreatePermitRequest(new List<FunctionalLocation> { floc4 }, someDate, someDate));

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc4 };
                List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == permitRequest1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == permitRequest2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldOnlyReturnOneDtoPerPermitRequestEvenIfThePermitRequestHasMultipleFlocs()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_MT1_A002_U430();
            
            PermitRequestMontreal permitRequestMontreal = CreatePermitRequest(new List<FunctionalLocation> {floc1, floc2}, new Date(2001, 2, 3), new Date(2001, 4, 5));
            permitRequestMontreal = permitRequestDao.Insert(permitRequestMontreal);

            List<PermitRequestMontrealDTO> results = dtoDao.QueryByFlocUnitAndBelow(new RootFlocSet(floc1), new DateRange(null, null));
            Assert.AreEqual(1, results.FindAll(result => result.Id == permitRequestMontreal.Id).Count);
            PermitRequestMontrealDTO queriedPermit = results.Find(result => result.Id == permitRequestMontreal.Id);
            Assert.AreEqual("MT1-A001-U010, MT1-A002-U430", queriedPermit.FunctionalLocationNamesAsString);
        }
    }
}
