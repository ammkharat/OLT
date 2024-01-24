using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitRequestMontrealTest
    {
        [Test]
        public void ShouldUpdateFromExisting()
        {
            PermitRequestMontreal permitRequestToUpdateFrom = PermitRequestMontrealFixture.GetFullyPopulatedPermitRequest();
            permitRequestToUpdateFrom.Id = null;
            permitRequestToUpdateFrom.LastSubmittedByUser = null;
            permitRequestToUpdateFrom.LastSubmittedDateTime = null;
            
            PermitRequestMontreal existingRequest = PermitRequestMontrealFixture.GetEmptyPermitRequest();
            User existingUser = UserFixture.CreateOperator(-2222, "Sally");
            DateTime existingDateTime = new DateTime(2001, 1, 1, 1, 0, 0);
            existingRequest.LastSubmittedByUser = existingUser;
            existingRequest.LastSubmittedDateTime = existingDateTime;
            existingRequest.Id = 12345;

            existingRequest.UpdateFrom(permitRequestToUpdateFrom);

            Assert.AreEqual(12345, existingRequest.IdValue);
            Assert.AreEqual(permitRequestToUpdateFrom.WorkPermitType, existingRequest.WorkPermitType);
            Assert.AreEqual(permitRequestToUpdateFrom.StartDate, existingRequest.StartDate);
            Assert.AreEqual(permitRequestToUpdateFrom.EndDate, existingRequest.EndDate);
            Assert.AreEqual(permitRequestToUpdateFrom.WorkOrderNumber, existingRequest.WorkOrderNumber);
            Assert.AreEqual(permitRequestToUpdateFrom.OperationNumber, existingRequest.OperationNumber);
            Assert.AreEqual(permitRequestToUpdateFrom.Trade, existingRequest.Trade);
            Assert.AreEqual(permitRequestToUpdateFrom.Description, existingRequest.Description);
            Assert.AreEqual(permitRequestToUpdateFrom.Company, existingRequest.Company);
            Assert.AreEqual(permitRequestToUpdateFrom.Supervisor, existingRequest.Supervisor);
            Assert.AreEqual(permitRequestToUpdateFrom.ExcavationNumber, existingRequest.ExcavationNumber);
            Assert.AreEqual(permitRequestToUpdateFrom.DataSource, existingRequest.DataSource);
            Assert.AreEqual(permitRequestToUpdateFrom.LastImportedByUser, existingRequest.LastImportedByUser);
            Assert.AreEqual(permitRequestToUpdateFrom.LastImportedDateTime, existingRequest.LastImportedDateTime);

            Assert.AreEqual(existingUser, existingRequest.LastSubmittedByUser);
            Assert.AreEqual(existingDateTime, existingRequest.LastSubmittedDateTime);

            Assert.AreEqual(permitRequestToUpdateFrom.CreatedBy, existingRequest.CreatedBy);
            Assert.AreEqual(permitRequestToUpdateFrom.CreatedDateTime, existingRequest.CreatedDateTime);
            Assert.AreEqual(permitRequestToUpdateFrom.LastModifiedBy, existingRequest.LastModifiedBy);
            Assert.AreEqual(permitRequestToUpdateFrom.LastModifiedDateTime, existingRequest.LastModifiedDateTime);                     
        }

        [Test]
        public void ShouldBeRelevantToFlocsThatEqualOrAreParentOfPermit()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Montreal());

            FunctionalLocation thirdLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            thirdLevelFloc.Id = 10;

            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG();
            fourthLevelFloc.Id = 11;

            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG_BPM0115();
            fifthLevelFloc.Id = 12;

            {
                PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.GetFullyPopulatedPermitRequest();
                permitRequest.FunctionalLocations.Clear();
                permitRequest.FunctionalLocations.Add(fifthLevelFloc);

                Assert.IsTrue(permitRequest.IsRelevantTo(fifthLevelFloc.Site.IdValue, new List<string> { fifthLevelFloc.FullHierarchy }, null,null, siteConfiguration));
                Assert.IsTrue(permitRequest.IsRelevantTo(fourthLevelFloc.Site.IdValue, new List<string> { fourthLevelFloc.FullHierarchy }, null, null, siteConfiguration));
                Assert.IsTrue(permitRequest.IsRelevantTo(thirdLevelFloc.Site.IdValue, new List<string> { thirdLevelFloc.FullHierarchy }, null, null, siteConfiguration));
            }

            {
                PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.GetFullyPopulatedPermitRequest();
                permitRequest.FunctionalLocations.Clear();
                permitRequest.FunctionalLocations.Add(fourthLevelFloc);

                Assert.IsFalse(permitRequest.IsRelevantTo(fifthLevelFloc.Site.IdValue, new List<string> { fifthLevelFloc.FullHierarchy }, null, null, siteConfiguration));
                Assert.IsTrue(permitRequest.IsRelevantTo(fourthLevelFloc.Site.IdValue, new List<string> { fourthLevelFloc.FullHierarchy }, null, null, siteConfiguration));
            }
        }

        [Test]
        public void ShouldKnowWhenStartAndEndDatesAreMissing()
        {
            // IMPORTTODO
            //PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            //Assert.IsFalse(permitRequest.HasMissingFieldsFromImport());

            //permitRequest.StartDate = null;
            //permitRequest.EndDate = null;

            //Assert.IsTrue(permitRequest.HasMissingFieldsFromImport());
            //string missingImportFieldList = permitRequest.GetMissingImportFieldList().BuildCommaSeparatedList();
            //Assert.AreEqual(new List<String> { StringResources.PermitRequestFieldName_EndDate, StringResources.PermitRequestFieldName_StartDate }.BuildCommaSeparatedList(), missingImportFieldList);
        }
    }


}
