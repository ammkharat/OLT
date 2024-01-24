using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    [TestFixture]
    public class PermitRequestEdmontonValidatorForDomainTest
    {       
        [Test]
        public void ShouldValidateValidPermitRequestAsValid()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

            validator.Validate();
            Assert.IsFalse(validator.HasErrors);
            Assert.IsFalse(validator.HasWarnings);
        }

        [Test]
        public void ShouldDetectCompletionStatus()
        {
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel1;
                permitRequest.ConfinedSpaceCardNumber = null;

                permitRequest.Group = new WorkPermitEdmontonGroup(1, "heyo", new List<long> { WorkOrderPriority.P1.IdValue }, 1, false);

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsTrue(validator.HasWarnings);

                Assert.AreEqual(PermitRequestCompletionStatus.Incomplete, validator.CompletionStatus);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel1;
                permitRequest.ConfinedSpaceCardNumber = null;

                permitRequest.Group = new WorkPermitEdmontonGroup(1, "heyo", new List<long> { WorkOrderPriority.P3.IdValue }, 1, false);

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsTrue(validator.HasWarnings);

                Assert.AreEqual(PermitRequestCompletionStatus.ForReview, validator.CompletionStatus);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.Group = new WorkPermitEdmontonGroup(1, "heyo", new List<long> { WorkOrderPriority.P1.IdValue }, 1, false);

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsFalse(validator.HasWarnings);

                Assert.AreEqual(PermitRequestCompletionStatus.Complete, validator.CompletionStatus);
            }
        }

        [Test]
        public void ShouldBeAllowedToCheckAlkylationEntryWithoutNeedingAClassOfClothing()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.AlkylationEntry = true;
            permitRequest.AlkylationEntryClassOfClothing = null;

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

            validator.Validate();
            Assert.IsFalse(validator.HasErrors);
            Assert.IsFalse(validator.HasWarnings);
        }

        [Test]
        public void ShouldBeAllowedToCheckFlarePitEntryWithoutNeedingAFlarePitEntryType()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.FlarePitEntry = true;
            permitRequest.FlarePitEntryType = null;

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

            validator.Validate();
            Assert.IsFalse(validator.HasErrors);
            Assert.IsFalse(validator.HasWarnings);
        }
                
        [Test]
        public void ShouldValidateStartAndEndDates()
        {
            // has no start time
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartTimeDay = null;
                permitRequest.RequestedStartTimeNight = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
                validator.Validate();

                AssertValidator(validator, true, false);               
            }

            // Has a day start time
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartTimeDay = new Time(14);
                permitRequest.RequestedStartTimeNight = null;

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
                validator.Validate();

                AssertValidator(validator, false, false);                
            }

            // Has a night start time
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartTimeDay = null;
                permitRequest.RequestedStartTimeNight = new Time(15);

                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
                validator.Validate();

                AssertValidator(validator, false, false);                
            }

        }

        [Test]
        public void ShouldValidateThatNumberOfWorkersIsPostive()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.NumberOfWorkers = -2;

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
            validator.Validate();

            AssertValidator(validator, true, false);                
        }

        [Test]
        public void ShouldValidateExistanceOfFields()
        {
            ValidateThatMissingFieldCausesError(pr => pr.Group = null);                     
            ValidateThatMissingFieldCausesError(pr => pr.FunctionalLocation = null);                     
            ValidateThatMissingFieldCausesError(pr => pr.WorkPermitType = null);                     
            ValidateThatMissingFieldCausesError(pr => pr.WorkPermitType = WorkPermitEdmontonType.NULL);                     
            ValidateThatMissingFieldCausesError(pr => pr.Description = null);                     
            ValidateThatMissingFieldCausesError(pr => pr.Occupation = null);                     
            ValidateThatMissingFieldCausesError(pr => pr.Location = null);                     
        }

        [Test]
        public void ShouldValidateConfinedSpaceCardNumber()
        {
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsFalse(validator.HasWarnings);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel1;
                permitRequest.ConfinedSpaceCardNumber = null;

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsTrue(validator.HasWarnings);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
                permitRequest.ConfinedSpaceCardNumber = null;

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsTrue(validator.HasWarnings);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel3;
                permitRequest.ConfinedSpaceCardNumber = null;

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsFalse(validator.HasWarnings);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel2;
                permitRequest.ConfinedSpaceCardNumber = "12345";

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsFalse(validator.HasWarnings);
            }

            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);

                permitRequest.ConfinedSpace = true;
                permitRequest.ConfinedSpaceClass = WorkPermitEdmonton.ConfinedSpaceLevel3;
                permitRequest.ConfinedSpaceCardNumber = "12345";

                validator.Validate();
                Assert.IsFalse(validator.HasErrors);
                Assert.IsFalse(validator.HasWarnings);
            }
        }
       
        public void ValidateThatMissingFieldCausesError(Action<PermitRequestEdmonton> nullificationAction)
        {
            PermitRequestEdmonton permitRequest1 = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            PermitRequestEdmonton permitRequest = permitRequest1;
            nullificationAction(permitRequest);

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(permitRequest), DataSource.SAP);
            validator.Validate();

            AssertValidator(validator, true, false);      
        }

        private static void AssertValidator(PermitRequestValidator validator, bool hasErrors, bool hasWarnings)
        {
            Assert.IsTrue(validator.HasErrors == hasErrors);
            Assert.IsTrue(validator.HasWarnings == hasWarnings);
        }
    }
}
