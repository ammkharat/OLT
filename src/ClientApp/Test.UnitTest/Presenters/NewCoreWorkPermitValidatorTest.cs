using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class NewCoreWorkPermitValidatorTest
    {

        [Test]
        public void ShouldReturnEmptyListWhenAllRulesPass()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermit(1);

            var validator = new NewCoreWorkPermitValidator(workPermit);
            List<IValidationIssue> errorList = validator.Validate();

            CollectionAssert.IsEmpty(errorList);
        }

        [Test]
        public void ShouldReturnErrorListWhenWorkPermitTypeIsNull()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermit(1);
            workPermit.WorkPermitType = null;

            var validator = new NewCoreWorkPermitValidator(workPermit);
            List<IValidationIssue> errorList = validator.Validate();

            Assert.That(errorList, Has.Count.EqualTo(1));
        }


        [Test]
        public void ShouldReturnErrorListIfBothJobStepDescAndWorkOrderDescAreEmpty()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermit(1);
            workPermit.Specifics.JobStepDescription = string.Empty;
            workPermit.Specifics.WorkOrderDescription = null;

            var validator = new NewCoreWorkPermitValidator(workPermit);
            List<IValidationIssue> errorList = validator.Validate();

            Assert.That(errorList, Has.Count.EqualTo(1));
        }

        [Test]
        public void ShouldReturnErrorListWithTwoItemsWhenTwoValidationsFail()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermit(1);
            workPermit.WorkPermitType = null;
            workPermit.Specifics.FunctionalLocation = null;

            var validator = new NewCoreWorkPermitValidator(workPermit);
            List<IValidationIssue> errorList = validator.Validate();

            Assert.That(errorList, Has.Count.EqualTo(2));
        }

    }
}
