using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class ProcedureDeviationDaoTest : AbstractDaoTest
    {
        private IProcedureDeviationDao procedureDeviationDao;

        [Ignore] [Test]
        public void QueryByIdShouldBringBackAnInsertedProcedureDeviation()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2015, 11, 5);

            var insertedProcedureDeviation = CreateAndInsertProcedureDeviation();
            var retrievedProcedureDeviation = procedureDeviationDao.QueryById(insertedProcedureDeviation.IdValue);

            Assert.AreEqual(insertedProcedureDeviation.Id, retrievedProcedureDeviation.Id);
            Assert.AreEqual(insertedProcedureDeviation.FormStatus, retrievedProcedureDeviation.FormStatus);

            Assert.AreEqual(insertedProcedureDeviation.CreatedBy.IdValue, retrievedProcedureDeviation.CreatedBy.IdValue);
            Assert.AreEqual(insertedProcedureDeviation.CreatedDateTime, retrievedProcedureDeviation.CreatedDateTime);

            Assert.AreEqual(insertedProcedureDeviation.LastModifiedBy.IdValue,
                retrievedProcedureDeviation.LastModifiedBy.IdValue);
            Assert.AreEqual(insertedProcedureDeviation.LastModifiedDateTime,
                retrievedProcedureDeviation.LastModifiedDateTime);

            Assert.AreEqual(insertedProcedureDeviation.FunctionalLocations.Count,
                retrievedProcedureDeviation.FunctionalLocations.Count);
            Assert.AreEqual(insertedProcedureDeviation.LocationEquipmentNumber,
                retrievedProcedureDeviation.LocationEquipmentNumber);
            Assert.AreEqual(insertedProcedureDeviation.DocumentLinks.Count,
                retrievedProcedureDeviation.DocumentLinks.Count);

            Assert.AreEqual(insertedProcedureDeviation.FromDateTime, retrievedProcedureDeviation.FromDateTime);
            Assert.AreEqual(insertedProcedureDeviation.ToDateTime, retrievedProcedureDeviation.ToDateTime);

            Assert.AreEqual(insertedProcedureDeviation.NumberOfExtensions,
                retrievedProcedureDeviation.NumberOfExtensions);
            Assert.AreEqual(insertedProcedureDeviation.ReasonsForExtension.Count,
                retrievedProcedureDeviation.ReasonsForExtension.Count);

            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureNumber,
                retrievedProcedureDeviation.OperatingProcedureNumber);
            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureTitle,
                retrievedProcedureDeviation.OperatingProcedureTitle);
            Assert.AreEqual(insertedProcedureDeviation.OperatingProcedureLevel,
                retrievedProcedureDeviation.OperatingProcedureLevel);

            Assert.AreEqual(insertedProcedureDeviation.Description, retrievedProcedureDeviation.Description);
            Assert.AreEqual(insertedProcedureDeviation.RichTextDescription,
                retrievedProcedureDeviation.RichTextDescription);

            Assert.AreEqual(insertedProcedureDeviation.CauseDeterminationCauses.Count,
                retrievedProcedureDeviation.CauseDeterminationCauses.Count);
            Assert.AreEqual(insertedProcedureDeviation.CauseDeterminationCategory,
                retrievedProcedureDeviation.CauseDeterminationCategory);
            Assert.AreEqual(insertedProcedureDeviation.CauseDeterminationComments,
                retrievedProcedureDeviation.CauseDeterminationComments);

            Assert.AreEqual(insertedProcedureDeviation.FixDocumentDurationType,
                retrievedProcedureDeviation.FixDocumentDurationType);
            Assert.AreEqual(insertedProcedureDeviation.CorrectiveActionIlpNumber,
                retrievedProcedureDeviation.CorrectiveActionIlpNumber);
            Assert.AreEqual(insertedProcedureDeviation.CorrectiveActionWorkRequestNumber,
                retrievedProcedureDeviation.CorrectiveActionWorkRequestNumber);
            Assert.AreEqual(insertedProcedureDeviation.CorrectiveActionOtherComments,
                retrievedProcedureDeviation.CorrectiveActionOtherComments);

            Assert.AreEqual(insertedProcedureDeviation.AffectsToe,
                retrievedProcedureDeviation.AffectsToe);

            Assert.AreEqual(insertedProcedureDeviation.CancelledBy, retrievedProcedureDeviation.CancelledBy);
            Assert.AreEqual(insertedProcedureDeviation.CancelledDateTime,
                retrievedProcedureDeviation.CancelledDateTime);
            Assert.AreEqual(insertedProcedureDeviation.CancelledReason,
                retrievedProcedureDeviation.CancelledReason);

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldUpdateProcedureDeviation()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2015, 11, 8);

            var floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            var procedureDeviationToUpdate = CreateAndInsertProcedureDeviation();

            var user = procedureDeviationToUpdate.CreatedBy;

            procedureDeviationToUpdate.LastModifiedBy = user;
            procedureDeviationToUpdate.LastModifiedDateTime = Clock.Now;

            procedureDeviationToUpdate.FormStatus = FormStatus.RevisionInProgress;

            procedureDeviationToUpdate.FunctionalLocations.Add(floc);
            procedureDeviationToUpdate.LocationEquipmentNumber = "NEWLOCEQNUM";

            procedureDeviationToUpdate.ToDateTime =
                procedureDeviationToUpdate.ToDateTime.AddDays(5);
            procedureDeviationToUpdate.NumberOfExtensions++;
            procedureDeviationToUpdate.ReasonsForExtension.Add(new Comment(user, Clock.Now, "Yet another extension"));

            procedureDeviationToUpdate.OperatingProcedureNumber = "New OP Number";
            procedureDeviationToUpdate.OperatingProcedureTitle = "New OP Title";

            procedureDeviationToUpdate.Description = "New Description";

            procedureDeviationToUpdate.CauseDeterminationCauses.Add(CauseDeterminationWhyType.Other);
            procedureDeviationToUpdate.CauseDeterminationComments = "New Cause Determination Comments";

            procedureDeviationDao.Update(procedureDeviationToUpdate);
            var retrievedProcedureDeviation = procedureDeviationDao.QueryById(procedureDeviationToUpdate.IdValue);

            Assert.AreEqual(procedureDeviationToUpdate.Id, retrievedProcedureDeviation.Id);
            Assert.AreEqual(procedureDeviationToUpdate.FormStatus, retrievedProcedureDeviation.FormStatus);

            Assert.AreEqual(procedureDeviationToUpdate.CreatedBy.IdValue, retrievedProcedureDeviation.CreatedBy.IdValue);
            Assert.AreEqual(procedureDeviationToUpdate.CreatedDateTime, retrievedProcedureDeviation.CreatedDateTime);

            Assert.AreEqual(procedureDeviationToUpdate.LastModifiedBy.IdValue,
                retrievedProcedureDeviation.LastModifiedBy.IdValue);
            Assert.AreEqual(procedureDeviationToUpdate.LastModifiedDateTime,
                retrievedProcedureDeviation.LastModifiedDateTime);

            Assert.AreEqual(procedureDeviationToUpdate.FunctionalLocations.Count,
                retrievedProcedureDeviation.FunctionalLocations.Count);
            Assert.AreEqual(procedureDeviationToUpdate.LocationEquipmentNumber,
                retrievedProcedureDeviation.LocationEquipmentNumber);
            Assert.AreEqual(procedureDeviationToUpdate.DocumentLinks.Count,
                retrievedProcedureDeviation.DocumentLinks.Count);

            Assert.AreEqual(procedureDeviationToUpdate.FromDateTime, retrievedProcedureDeviation.FromDateTime);
            Assert.AreEqual(procedureDeviationToUpdate.ToDateTime, retrievedProcedureDeviation.ToDateTime);

            Assert.AreEqual(procedureDeviationToUpdate.NumberOfExtensions,
                retrievedProcedureDeviation.NumberOfExtensions);
            Assert.AreEqual(procedureDeviationToUpdate.ReasonsForExtension.Count,
                retrievedProcedureDeviation.ReasonsForExtension.Count);

            Assert.AreEqual(procedureDeviationToUpdate.OperatingProcedureNumber,
                retrievedProcedureDeviation.OperatingProcedureNumber);
            Assert.AreEqual(procedureDeviationToUpdate.OperatingProcedureTitle,
                retrievedProcedureDeviation.OperatingProcedureTitle);

            Assert.AreEqual(procedureDeviationToUpdate.Description, retrievedProcedureDeviation.Description);

            Assert.AreEqual(procedureDeviationToUpdate.CauseDeterminationCauses.Count,
                retrievedProcedureDeviation.CauseDeterminationCauses.Count);
            Assert.AreEqual(procedureDeviationToUpdate.CauseDeterminationCategory,
                retrievedProcedureDeviation.CauseDeterminationCategory);
            Assert.AreEqual(procedureDeviationToUpdate.CauseDeterminationComments,
                retrievedProcedureDeviation.CauseDeterminationComments);

            Clock.UnFreeze();
        }

        private ProcedureDeviation CreateAndInsertProcedureDeviation()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var validFromDateTime = new DateTime(2015, 11, 1);
            var validToDateTime = new DateTime(2015, 11, 10);

            var procedureDeviation = ProcedureDeviationFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Draft, UserFixture.CreateOilSandsUserWithUserPrintPreference());

            return procedureDeviationDao.Insert(procedureDeviation);
        }

        protected override void TestInitialize()
        {
            procedureDeviationDao = DaoRegistry.GetDao<IProcedureDeviationDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}