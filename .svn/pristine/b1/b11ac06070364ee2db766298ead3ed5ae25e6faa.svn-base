using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Validation.Lubes
{
    [TestFixture]
    public class PermitRequestLubesValidatorTest
    {
        [Test]
        public void ShouldRecordMissingFieldsWhenUsingDomainAdapter()
        {
            DateTime testTime = new DateTime(2013, 6, 20, 9, 51, 0);

            PermitRequestLubes permitRequest = PermitRequestLubesFixture.CreateEmptyPermitRequest();
            PermitRequestLubesValidationDomainAdapter adapter = new PermitRequestLubesValidationDomainAdapter(permitRequest);
            PermitRequestLubesValidator validator = new PermitRequestLubesValidator(adapter);
            validator.Validate(testTime);

            Assert.IsTrue(validator.HasErrors);

            List<string> missingImportFieldList = validator.MissingImportFieldList;

            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_WorkPermitType);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_FunctionalLocation);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_Location);
            //IMPORTTODO: these aren't validated in the view, and since they should always come from the work order, maybe we don't need to validate them.
            // Or, better yet, I should validate them in the import converter tool.
            //AssertContainsString(missingImportFieldList, "Work Order Number");
            //AssertContainsString(missingImportFieldList, "Operation Number");            
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_RequestedByGroup);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_Description);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_StartDate);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_EndDate);
            AssertContainsString(missingImportFieldList, StringResources.PermitRequestFieldName_Trade);
        }

        private void AssertContainsString(List<string> missingImportFieldList, string permitType)
        {
            Assert.IsTrue(missingImportFieldList.Exists(s => s.Equals(permitType)));
        }
    }
}
