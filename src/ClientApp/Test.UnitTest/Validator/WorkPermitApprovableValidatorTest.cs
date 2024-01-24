using System.Collections.Generic;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Validator
{
    [TestFixture]
    public class WorkPermitApprovableValidatorTest
    {
        private WorkPermitApprovableValidator workPermitApprovableValidator;
        private IAuthorized mockAuthorized;
        private Mockery mockery;

        [SetUp]
        public void SetUp()
        {
            mockery = new Mockery();
            mockAuthorized = mockery.NewMock<IAuthorized>();
            Stub.On(mockAuthorized).Method("ToFullyValidateWorkPermit").WithAnyArguments().Will(Return.Value(true));
            ClientSession.GetNewInstance();
            ClientSession.GetUserContext().SetSite(SiteFixture.Sarnia(), null);
        }
        
        [Test]
        public void CannotApproveMultipleWorkPermitsIfAtLeastOneHasErrors()
        {
            WorkPermit validPermit = WorkPermitFixture.CreateValidWorkPermit(-2000);
            WorkPermit permitWithError = WorkPermitFixture.CreateWorkPermitWithError(-99);
            
            var workPermits = new List<WorkPermit> {validPermit, permitWithError};

            List<GasTestElementInfo> standardGasTestElementInfoList =
                GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;

            workPermitApprovableValidator = new WorkPermitApprovableValidator(workPermits, mockAuthorized, standardGasTestElementInfoList);

            Assert.IsFalse(workPermitApprovableValidator.PermitsAreValidEnoughToBeApproved());

            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotApproveWorkPermitWithValidSectionsAndInvalidFields()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithFieldLevelError(-99);
            var workPermits = new List<WorkPermit> {permit};

            List<GasTestElementInfo> standardGasTestElementInfoList =
                GasTestElementInfoFixture.SarniaStandardGasTestElementInfos;

            workPermitApprovableValidator = new WorkPermitApprovableValidator(workPermits, mockAuthorized, standardGasTestElementInfoList);

            Assert.IsFalse(workPermitApprovableValidator.PermitsAreValidEnoughToBeApproved());

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}