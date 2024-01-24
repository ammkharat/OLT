using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Utilities
{    
    [TestFixture]
    public class PermitRequestPersistanceProcessorTest
    {
        private IPermitRequestMontrealDao permitRequestDao;

        [Ignore] [Test]
        public void ShouldInsertIfNotFoundInDatabase()
        {
            permitRequestDao = MockRepository.GenerateStub<IPermitRequestMontrealDao>();

            // returns nothing - no matching permit request found
            permitRequestDao.Stub(
                x => x.QueryByWorkOrderNumberAndOperationAndSource(
                    Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<DataSource>.Is.Anything)).Return(
                        new List<PermitRequestMontreal>());

            permitRequestDao.Stub(x => x.QueryByDateRangeAndDataSource(Arg<Date>.Is.Anything, Arg<Date>.Is.Anything, Arg<DataSource>.Is.Anything))
                            .Return(new List<PermitRequestMontreal>(0));

            PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.GetPermitRequest(UserFixture.CreateAdmin());
            permitRequest.Id = 12345;

            List<PermitRequestMontreal> incomingRequests = new List<PermitRequestMontreal> {permitRequest};

            List<WorkOrderImportData> completeListOfIncoming = new List<WorkOrderImportData> {CreateFromPermitRequest(permitRequest)};

            MontrealPermitRequestPersistanceProcessor processor = new MontrealPermitRequestPersistanceProcessor(DateTimeFixture.DateNow, DateTimeFixture.DateNow, permitRequestDao, incomingRequests, completeListOfIncoming);
            processor.Process();

            Assert.IsEmpty(processor.UpdateList);
            Assert.IsTrue(processor.InsertList.Count == 1);
            Assert.IsTrue(processor.InsertList.Exists(x => x.Id == 12345));

        }

        [Ignore] [Test]
        public void ShouldUpdateIfFoundInDatabase()
        {
            permitRequestDao = MockRepository.GenerateStub<IPermitRequestMontrealDao>();

            PermitRequestMontreal permitRequestThatAlreadyExistsInDB = PermitRequestMontrealFixture.GetPermitRequest(UserFixture.CreateAdmin());
            permitRequestThatAlreadyExistsInDB.Id = 12345;
           
            permitRequestDao.Stub(
                x => x.QueryByWorkOrderNumberAndOperationAndSource(
                    Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<DataSource>.Is.Anything)).Return(
                        new List<PermitRequestMontreal> { permitRequestThatAlreadyExistsInDB });

            permitRequestDao.Stub(x => x.QueryByDateRangeAndDataSource(Arg<Date>.Is.Anything, Arg<Date>.Is.Anything, Arg<DataSource>.Is.Anything))
                            .Return(new List<PermitRequestMontreal>{permitRequestThatAlreadyExistsInDB});

            List<PermitRequestMontreal> incomingRequests = new List<PermitRequestMontreal> { permitRequestThatAlreadyExistsInDB };

            List<WorkOrderImportData> completeListOfIncoming = new List<WorkOrderImportData> {CreateFromPermitRequest(permitRequestThatAlreadyExistsInDB)};

            MontrealPermitRequestPersistanceProcessor processor = new MontrealPermitRequestPersistanceProcessor(DateTimeFixture.DateNow, DateTimeFixture.DateNow, permitRequestDao, incomingRequests, completeListOfIncoming);

            processor.Process();

            Assert.IsEmpty(processor.InsertList);
            Assert.IsTrue(processor.UpdateList.Count == 1);
            Assert.IsTrue(processor.UpdateList.Exists(x => x.Id == 12345));
        }

        [Ignore] [Test]
        public void ShouldUpdateIfFoundInDatabase_OnlyUpdateCertainFieldsIfExistingPermitRequestHasBeenModified()
        {
            permitRequestDao = MockRepository.GenerateStub<IPermitRequestMontrealDao>();

            PermitRequestMontreal permitFromDB = PermitRequestMontrealFixture.GetPermitRequest(UserFixture.CreateAdmin());
            permitFromDB.IsModified = true;
            {
                permitFromDB.Id = 12345;
                // make it modified
                permitFromDB.CreatedDateTime = new DateTime(1930, 1, 1, 0, 0, 0);
                permitFromDB.LastModifiedDateTime = new DateTime(1930, 1, 2, 0, 0, 0);

                permitFromDB.OperationNumber = "existing OP number";

                permitFromDB.StartDate = new Date(1901, 1, 1);
                permitFromDB.EndDate = new Date(1902, 1, 1);
                permitFromDB.LastModifiedDateTime = new DateTime(1903, 1, 1);
                permitFromDB.LastModifiedBy = UserFixture.CreateOperator(-6765745, "Old User");
            }

            PermitRequestMontreal incomingPermit = PermitRequestMontrealFixture.GetPermitRequest(UserFixture.CreateAdmin());
            {
                incomingPermit.Id = null;
                // make it modified
                incomingPermit.CreatedDateTime = new DateTime(2012, 1, 1, 0, 0, 0);
                incomingPermit.LastModifiedDateTime = new DateTime(2012, 1, 2, 0, 0, 0);

                incomingPermit.StartDate = new Date(1933, 1, 1);
                incomingPermit.EndDate = new Date(1943, 1, 1);
                incomingPermit.LastModifiedDateTime = new DateTime(1953, 1, 1);
                incomingPermit.LastModifiedBy = UserFixture.CreateOperator(-2342342, "New User");
            }

            string originalDescription = permitFromDB.Description;

            permitRequestDao.Stub(
                x => x.QueryByWorkOrderNumberAndOperationAndSource(
                    Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything, Arg<DataSource>.Is.Anything)).Return(
                        new List<PermitRequestMontreal> { permitFromDB });

            permitRequestDao.Stub(x => x.QueryByDateRangeAndDataSource(Arg<Date>.Is.Anything, Arg<Date>.Is.Anything, Arg<DataSource>.Is.Anything))
                .Return(new List<PermitRequestMontreal> { permitFromDB });

            List<PermitRequestMontreal> incomingRequests = new List<PermitRequestMontreal> { incomingPermit };

            List<WorkOrderImportData> completeListOfIncoming = new List<WorkOrderImportData> {CreateFromPermitRequest(incomingPermit)};

            MontrealPermitRequestPersistanceProcessor processor = new MontrealPermitRequestPersistanceProcessor(DateTimeFixture.DateNow, DateTimeFixture.DateNow, permitRequestDao, incomingRequests, completeListOfIncoming);

            processor.Process();

            Assert.IsEmpty(processor.InsertList);
            Assert.IsTrue(processor.UpdateList.Count == 1);
            Assert.IsTrue(processor.UpdateList.Exists(x => x.Id == 12345));

            // Should update these from the incoming permit
            PermitRequestMontreal permitRequest = (PermitRequestMontreal)processor.UpdateList[0];
            Assert.AreEqual(1933, permitRequest.StartDate.Year);
            Assert.AreEqual(1943, permitRequest.EndDate.Year);
            Assert.AreEqual(1953, permitRequest.LastModifiedDateTime.Year);
            Assert.AreEqual(new Date(1933, 1, 1), permitRequest.StartDate);

            // Other values should remain the same
            Assert.AreEqual("existing OP number", permitRequest.OperationNumber);
            Assert.AreEqual(originalDescription, permitRequest.Description);
        }

        private WorkOrderImportData CreateFromPermitRequest(BasePermitRequest permitRequest)
        {
            WorkOrderImportData workOrderImportData = new WorkOrderImportData(0, permitRequest.CreatedDateTime, permitRequest.CreatedBy)
            {
                WONumber = permitRequest.WorkOrderNumber,
                OperationNumber = permitRequest.OperationNumber,
                Suboperation = permitRequest.SubOperationNumber
            };

            return workOrderImportData;
        }

    }
}
