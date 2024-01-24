using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Client.Validator
{
    [TestFixture]
    public class WorkPermitValidatorTest
    {

        private Mockery mockery;
        private IAuthorized mockAuthorized;

        [SetUp]
        public void Setup()
        {
            mockery = new Mockery();
            mockAuthorized = mockery.NewMock<IAuthorized>();
            Stub.On(mockAuthorized).Method("ToFullyValidateWorkPermit").WithAnyArguments().Will(Return.Value(true));
            User user = UserFixture.CreateOperator();
            user.AvailableSites.Clear();
            user.AvailableSites.Add(SiteFixture.Sarnia());
            ClientSession.GetUserContext().User = user;
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
        }

        [Test]
        public void ValidWorkPermitShouldNotHaveAnyItemsReturnsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();
            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);

            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.RequiredForSave));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.RequiredForApproval));

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidHotWorkPermitShouldHaveSomeRequiredItemsReturnsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();
            workPermit.WorkPermitType = WorkPermitType.HOT;
            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(2));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidHotWorkAndSystemEntryPermitShouldHaveSomeRequiredAndOptionalItemsReturnsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();
            workPermit.WorkPermitType = WorkPermitType.HOT;
            workPermit.Attributes.IsSystemEntry = true;
            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.AtLeast(1));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(2));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidSystemEntryAsbestosPermitShouldHaveSomeOptionalItemsReturnsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsSystemEntry = true;
            workPermit.Attributes.IsAsbestos = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.AtLeast(1));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidConfinedSpaceItemsShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsConfinedSpaceEntry = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(3));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidSystemEntryItemsShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsSystemEntry = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(3));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void InvalidBreathingAirOrSCBAItemsShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsBreathingAirOrSCBA  = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(1));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidCriticalLiftItemsShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsCriticalLift = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(2));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

//        [Test]
//        public void InvalidElectricalSwitchingShouldReturnNoItemsThroughValidator()
//        {
//            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();
//
//            workPermit.Attributes.IsElectricalWork = true;
//
//            workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
//            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();
//
//            Assert.AreEqual(0, workPermitSectionsValidator.MissingOptionalSections.Count);
//            Assert.AreEqual(0, workPermitSectionsValidator.MissingRequiredSections.Count);
//        }

//        [Test]
//        public void InvalidEnergizedElectricalShouldReturnItemsThroughValidator()
//        {
//            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();
//
//            workPermit.Attributes.IsEnergizedElectrical = true;
//
//            workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
//            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();
//
//            Assert.AreEqual(1, workPermitSectionsValidator.MissingOptionalSections.Count);
//            Assert.AreEqual(0, workPermitSectionsValidator.MissingRequiredSections.Count);
//        }

        [Test]
        public void InvalidVehicalEntryShouldReturnItemsThroughValidatorSarnia()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsVehicleEntry = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(1));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidVehicalEntryShouldReturnItemsThroughValidator_Denver()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Denver(), null);
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsVehicleEntry = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(2));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidExcavationShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsExcavation = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(1));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidHotTapShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsHotTap = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(2));

            mockery.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void InvalidAsbestosShouldReturnItemsThroughValidator()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsAsbestos = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(3));
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidBurnOrOpenFlameShouldReturnWarnings()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsBurnOrOpenFlame = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.FindAll(issue => issue.ProblemLevel == ProblemLevel.Warning).Count, Is.EqualTo(2));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(1));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidRadiographyShouldReturnItemsThroughValidator_Sarnia()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsRadiationRadiography = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(0));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidSealedRadiationShouldReturnItemsThroughValidator_Denver()
        {
            ClientSession.GetUserContext().SetSite(SiteFixture.Denver(), null);
            WorkPermit workPermit = WorkPermitFixture.CreateValidWorkPermitForValidator();

            workPermit.Attributes.IsRadiationSealed  = true;

            var workPermitSectionsValidator = new WorkPermitSectionsValidator(workPermit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();

            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            Assert.That(issues.FindAll(issue => issue.ProblemLevel > ProblemLevel.Warning).Count, Is.EqualTo(1));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void HasMissingOptionalSectionsShouldReturnTrueWhenPermitHasMissingOptionalSections()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithWarning(-99);
            var workPermitSectionsValidator = new WorkPermitSectionsValidator(permit, mockAuthorized);
            List<IValidationIssue> issues = workPermitSectionsValidator.Validate();
            Assert.That(issues.Exists(issue => issue.ProblemLevel == ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void HasMissingOptionalSectionsShouldReturnFalseWhenPermitHasNoMissingOptionalSections()
        {
            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermitForValidator();
            var sectionsValidator = new WorkPermitSectionsValidator(permit, mockAuthorized);
            List<IValidationIssue> issues = sectionsValidator.Validate();
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel == ProblemLevel.Warning));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void HasMissingRequiredSectionsShouldReturnTrueWhenPermitHasMissingRequiredSections()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithError(-99);
            var sectionsValidator = new WorkPermitSectionsValidator(permit, mockAuthorized);
            var issues = sectionsValidator.Validate();
            Assert.That(issues.Exists(issue => issue.ProblemLevel > ProblemLevel.Warning));
            
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void HasMissingRequiredSectionsShouldReturnFalseWhenPermitHasNoMissingRequiredSections()
        {
            WorkPermit permit = WorkPermitFixture.CreateValidWorkPermitForValidator();
            var sectionsValidator = new WorkPermitSectionsValidator(permit, mockAuthorized);
            var issues = sectionsValidator.Validate();
            Assert.That(issues.DoesNotHave(issue => issue.ProblemLevel > ProblemLevel.Warning));
        }
    }
}