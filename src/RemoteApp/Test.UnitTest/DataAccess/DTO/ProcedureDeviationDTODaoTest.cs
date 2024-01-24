using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class ProcedureDeviationDTODaoTest : AbstractDaoTest
    {
        private IProcedureDeviationDTODao procedureDeviationDTODao;
        private IProcedureDeviationDao procedureDeviationDao;

        [Ignore] [Test]
        public void QueryProcedureDeviationsByFlocShouldFullyPopulateADTO()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            Clock.Freeze();
            Clock.Now = new DateTime(2015, 7, 7);

            var startDate = new DateTime(2015, 7, 7);
            var endDate = new DateTime(2015, 7, 8);

            var insertedProcedureDeviation =
                CreateAndInsertProcedureDeviation(new List<FunctionalLocation> {floc1, floc2}, startDate,
                    endDate, FormStatus.RevisionInProgress);

            var procedureDeviationDTO =
                procedureDeviationDTODao.QueryProcedureDeviationDtos(new RootFlocSet(floc1, floc2),
                    new DateRange(startDate.ToDate(), endDate.ToDate()),
                    insertedProcedureDeviation.CreatedBy.IdValue).First();

            Assert.AreEqual(insertedProcedureDeviation.Id, procedureDeviationDTO.Id);
            Assert.AreEqual(insertedProcedureDeviation.FormStatus, procedureDeviationDTO.Status);

            Assert.AreEqual(insertedProcedureDeviation.CreatedBy.IdValue, procedureDeviationDTO.CreatedByUserId);
            Assert.AreEqual(insertedProcedureDeviation.CreatedDateTime, procedureDeviationDTO.CreatedDateTime);

            Assert.AreEqual(insertedProcedureDeviation.LastModifiedBy.IdValue,
                procedureDeviationDTO.LastModifiedByUserId);
            Assert.AreEqual(insertedProcedureDeviation.LastModifiedDateTime, procedureDeviationDTO.LastModified);

            Assert.AreEqual(insertedProcedureDeviation.FromDateTime, procedureDeviationDTO.ValidFrom);
            Assert.AreEqual(insertedProcedureDeviation.ToDateTime, procedureDeviationDTO.ValidTo);

            Assert.AreEqual(insertedProcedureDeviation.NumberOfExtensions,
                procedureDeviationDTO.NumberOfExtensions);
            Assert.AreEqual(insertedProcedureDeviation.Type, procedureDeviationDTO.Type);

            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureNumber,
                procedureDeviationDTO.OperatingProcedureNumber);
            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureTitle,
                procedureDeviationDTO.OperatingProcedureTitle);
            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureLevel,
                procedureDeviationDTO.OperatingProcedureLevel);

            Assert.AreEqual(insertedProcedureDeviation.Description, procedureDeviationDTO.Description);

            Assert.AreEqual(insertedProcedureDeviation.CauseDeterminationCategory, procedureDeviationDTO.CauseDeterminationCategory);

            Assert.AreEqual(insertedProcedureDeviation.CancelledBy, procedureDeviationDTO.CancelledBy);
            Assert.AreEqual(insertedProcedureDeviation.CancelledDateTime, procedureDeviationDTO.CancelledDateTime);
            Assert.AreEqual(insertedProcedureDeviation.CancelledReason, procedureDeviationDTO.CancelledReason);

            Assert.IsTrue(procedureDeviationDTO.FunctionalLocationNames.Contains(floc1.FullHierarchy));
            Assert.IsTrue(procedureDeviationDTO.FunctionalLocationNames.Contains(floc2.FullHierarchy));

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryProcedureDeviationsByFlocShouldOnlyBringBackFormsThatAreNotDeleted()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            var floc3 = FunctionalLocationFixture.GetReal_UP1();
            var floc4 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            Clock.Freeze();
            Clock.Now = new DateTime(2015, 7, 7);

            var firstProcedureDeviation = CreateAndInsertProcedureDeviation(
                new List<FunctionalLocation> {floc1, floc2}, new DateTime(2015, 7, 7),
                new DateTime(2015, 7, 8), FormStatus.RevisionInProgress);
            var secondProcedureDeviation = CreateAndInsertProcedureDeviation(floc2, new DateTime(2015, 7, 8),
                new DateTime(2015, 7, 10), FormStatus.Approved);
            var thirdProcedureDeviation = CreateAndInsertProcedureDeviation(floc3, new DateTime(2015, 7, 12),
                new DateTime(2015, 7, 15), FormStatus.Cancelled);
            var fourthProcedureDeviation = CreateAndInsertProcedureDeviation(floc4, new DateTime(2015, 7, 8),
                new DateTime(2015, 7, 14), FormStatus.Complete);

            // Delete one of the forms
            procedureDeviationDao.Remove(fourthProcedureDeviation);

            var results =
                procedureDeviationDTODao.QueryProcedureDeviationDtos(new RootFlocSet(floc1, floc2, floc3, floc4),
                    new DateRange(new Date(2015, 7, 7), new Date(2015, 7, 15)),
                    firstProcedureDeviation.CreatedBy.IdValue);

            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.Exists(form => form.Id == firstProcedureDeviation.Id));
            Assert.IsTrue(results.Exists(form => form.Id == secondProcedureDeviation.Id));
            Assert.IsTrue(results.Exists(form => form.Id == thirdProcedureDeviation.Id));
            Assert.IsFalse(results.Exists(form => form.Id == fourthProcedureDeviation.Id));

            Clock.UnFreeze();
        }

        private ProcedureDeviation CreateAndInsertProcedureDeviation(List<FunctionalLocation> flocs,
            DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var procedureDeviation = ProcedureDeviationFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Draft, UserFixture.CreateOilSandsUserWithUserPrintPreference());

            procedureDeviation.FormStatus = status;

            return procedureDeviationDao.Insert(procedureDeviation);
        }

        private ProcedureDeviation CreateAndInsertProcedureDeviation(FunctionalLocation floc, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var flocs = new List<FunctionalLocation> {floc};

            return CreateAndInsertProcedureDeviation(flocs, validFromDateTime, validToDateTime, status);
        }

        protected override void TestInitialize()
        {
            procedureDeviationDao = DaoRegistry.GetDao<IProcedureDeviationDao>();
            procedureDeviationDTODao = DaoRegistry.GetDao<IProcedureDeviationDTODao>();
        }

        protected override void Cleanup()
        {
        }
    }
}