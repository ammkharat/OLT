using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Fixtures;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using UserFixture = Com.Suncor.Olt.Common.Fixtures.UserFixture;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class WorkPermitAuthorizationTest
    {
        private delegate bool AuthorizeCheck(UserRoleElements user, UserShift userShift, WorkPermit permit);

        private UserRoleElements operatorMickey;
        private UserRoleElements supervisorDonald;
        private UserRoleElements engineeringSupportGoofy;
        private UserRoleElements permitScreenerGoofy;
        private UserRoleElements nonOpsPermitIssuerPluto;

        private WorkPermit sourceWorkPermit;
        private WorkPermit notModifiedWorkPermit;
        private WorkPermit modifiedWorkPermitBySupervisor;
        private WorkPermit modifiedWorkPermitByNotSupervisor;
        private WorkPermit pendingWorkPermit;
        private WorkPermit approvedWorkPermit;
        private WorkPermit completedWorkPermit;
        private WorkPermit rejectedWorkPermit;
        private WorkPermit issuedWorkPermit;
        private WorkPermit nonOpsWorkPermit;

        private IAuthorized authorized;
        
        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(Clock.DateNow.Year, Clock.DateNow.Month, Clock.DateNow.Day, 11, 0, 0);

            authorized = new Authorized();

            operatorMickey = UserRoleElementsFixture.CreateRoleElementsForOperator();
            supervisorDonald = UserRoleElementsFixture.CreateRoleElementsForSupervisor();
            engineeringSupportGoofy = UserRoleElementsFixture.CreateRoleElementsForEngineeringSupport();
            permitScreenerGoofy = UserRoleElementsFixture.CreateRoleElementsForPermitScreener();
            nonOpsPermitIssuerPluto = UserRoleElementsFixture.CreateRoleElementsForNonOperationsPermitIssuer();

            notModifiedWorkPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            notModifiedWorkPermit.LastModifiedBy = null;

            modifiedWorkPermitBySupervisor = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            modifiedWorkPermitBySupervisor.LastModifiedBy = UserFixture.CreateSupervisor();

            modifiedWorkPermitByNotSupervisor = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            modifiedWorkPermitByNotSupervisor.LastModifiedBy = UserFixture.CreateEngineeringSupport();

            sourceWorkPermit = WorkPermitFixture.CreateWorkPermit(85);
            pendingWorkPermit = WorkPermitFixture.CreateManualWorkPermit(WorkPermitStatus.Pending);
            approvedWorkPermit = WorkPermitFixture.CreateManualWorkPermit(WorkPermitStatus.Approved);
            completedWorkPermit = WorkPermitFixture.CreateManualWorkPermit(WorkPermitStatus.Complete);
            rejectedWorkPermit = WorkPermitFixture.CreateManualWorkPermit(WorkPermitStatus.Rejected);
            issuedWorkPermit = WorkPermitFixture.CreateManualWorkPermit(WorkPermitStatus.Issued);

            nonOpsWorkPermit = WorkPermitFixture.CreateWorkPermit(86);
            nonOpsWorkPermit.SetCreatedBy(UserFixture.CreateNonOperationsPermitIssuer(), false);
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        #region Delete Work Permit tests

        [Test]
        public void SupervisorsAndOperatorsCanDeleteNotModifiedWorkPermits()
        {
            Assert.IsTrue(authorized.ToDeleteWorkPermit(supervisorDonald, notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToDeleteWorkPermit(operatorMickey, notModifiedWorkPermit));
        }

        [Test]
        public void SupervisorsAndOperatorsCanDeleteModifiedWorkPermits()
        {
            Assert.IsTrue(authorized.ToDeleteWorkPermit(supervisorDonald, modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToDeleteWorkPermit(operatorMickey, modifiedWorkPermitBySupervisor));
        }

        [Test]
        public void NonSupervisorsAndNonOperatorsCannotDeleteWorkPermits()
        {
            Assert.IsFalse(authorized.ToDeleteWorkPermit(engineeringSupportGoofy, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToDeleteWorkPermit(permitScreenerGoofy, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToDeleteWorkPermit(nonOpsPermitIssuerPluto, notModifiedWorkPermit));
        }

        [Test]
        public void ShouldAllowNonOperationsPermitIssuerToDeleteNonOperationsPermit()
        {
            Assert.IsTrue(authorized.ToDeleteWorkPermit(nonOpsPermitIssuerPluto, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToDeleteWorkPermit(operatorMickey, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToDeleteWorkPermit(supervisorDonald, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToDeleteWorkPermit(engineeringSupportGoofy, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToDeleteWorkPermit(permitScreenerGoofy, nonOpsWorkPermit));
        }
        
        [Test]
        public void ShouldDeleteMultipleWithBothOperationsAndNonOperationPermits()
        {
            List<WorkPermit> workPermits = CreateList(modifiedWorkPermitBySupervisor, notModifiedWorkPermit, nonOpsWorkPermit);
            
            Assert.IsTrue(authorized.ToDeleteWorkPermits(supervisorDonald, workPermits));
            Assert.IsTrue(authorized.ToDeleteWorkPermits(operatorMickey, workPermits));
            Assert.IsFalse(authorized.ToDeleteWorkPermits(nonOpsPermitIssuerPluto, workPermits));
        }

        #endregion

        #region Modify Work Permit tests

        [Test]
        public void PermitScreenerCanModifyWorkPermitsNotModifiedBySupervisorOrOperator()
        {
            Assert.IsTrue(authorized.ToEditWorkPermit(permitScreenerGoofy, modifiedWorkPermitByNotSupervisor));
        }

        [Test]
        public void SupervisorsCanModifyWorkPermits()
        {
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, modifiedWorkPermitByNotSupervisor));
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, notModifiedWorkPermit));
        }

        [Test]
        public void OperatorsCanModifyWorkPermits()
        {
            Assert.IsTrue(authorized.ToEditWorkPermit(operatorMickey, modifiedWorkPermitByNotSupervisor));
            Assert.IsTrue(authorized.ToEditWorkPermit(operatorMickey, modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToEditWorkPermit(operatorMickey, notModifiedWorkPermit));
        }

//        [Test]
//        public void PermitScreenersCannotModifyWorkPermitsWithNoRestriction()
//        {
//            Assert.IsFalse(authorized.ToEditWorkPermitWithNoRestriction(permitScreenerGoofy));
//            Assert.IsTrue(authorized.ToEditWorkPermitWithNoRestriction(supervisorDonald));
//        }

        [Test]
        public void CanOnlyModifyToPendingAndRejectedWorkPermits()
        {
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, pendingWorkPermit));
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, rejectedWorkPermit));
            Assert.IsFalse(authorized.ToEditWorkPermit(supervisorDonald, approvedWorkPermit));
            Assert.IsFalse(authorized.ToEditWorkPermit(supervisorDonald, completedWorkPermit));
            Assert.IsFalse(authorized.ToEditWorkPermit(supervisorDonald, issuedWorkPermit));
        }

        [Test]
        public void ShouldAllowNonOperationsPermitIssuerToModifyNonOperationsPermit()
        {
            Assert.IsTrue(authorized.ToEditWorkPermit(nonOpsPermitIssuerPluto, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToEditWorkPermit(supervisorDonald, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToEditWorkPermit(operatorMickey, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToEditWorkPermit(engineeringSupportGoofy, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToEditWorkPermit(permitScreenerGoofy, nonOpsWorkPermit));
        }

        [Test]
        public void NonOperationsPermitIssuerCanNotToModifyOperationsPermit()
        {
            Assert.IsFalse(authorized.ToEditWorkPermit(nonOpsPermitIssuerPluto, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToEditWorkPermit(nonOpsPermitIssuerPluto, modifiedWorkPermitBySupervisor));
            Assert.IsFalse(authorized.ToEditWorkPermit(nonOpsPermitIssuerPluto, modifiedWorkPermitByNotSupervisor));
        }
        
        #endregion

        #region Validate work permit tests

        [Test]
        public void ToFullyValidateWorkPermitForUserWithEditWithNoRestrictionsShouldReturnTrue()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
            Assert.IsTrue(authorized.ToFullyValidateWorkPermit(userRoleElements));
        }

        [Test]
        public void ToFullyValidateWorkPermitForUserWithEditWithRestrictionsShouldReturnFalse()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING);
            Assert.IsFalse(authorized.ToFullyValidateWorkPermit(userRoleElements));
        }

        [Test]
        public void ToFullyValidateWorkPermitForUserWithEditNonOpsPermitShouldReturnTrue()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.EDIT_NON_OPERATIONS_PERMIT);
            Assert.IsTrue(authorized.ToFullyValidateWorkPermit(userRoleElements));
        }

        [Test]
        public void ToFullyValidateWorkPermitForUserWhoCanCreatePermitButCannotEditPermitsOfAnyKindShouldReturnTrue()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            userRoleElements.AddRoleElement(RoleElement.CREATE_PERMIT);
            Assert.IsTrue(authorized.ToFullyValidateWorkPermit(userRoleElements));
        }

        [Test]
        public void ToFullyValidateWorkPermitForUserWhoCannotCreatePermitNorEditPermitsOfAnyKindShouldReturnFalse()
        {
            UserRoleElements userRoleElements = UserRoleElementsFixture.CreateEmpty();
            Assert.IsFalse(authorized.ToFullyValidateWorkPermit(userRoleElements));
        }

        #endregion

        #region Copy to work permit tests

        [Test]
        public void EngineeeringSupportNotAuthorizedToCopyWorkPermits()
        {
            Assert.IsFalse(authorized.ToCopyWorkPermitWithSomeRestrictions(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithNoRestriction(engineeringSupportGoofy));
        }
        
        [Test]
        public void OnlyPermitScreenerAuthorizedToCopyWorkPermitsWithSomeRestrictions()
        {
            Assert.IsTrue(authorized.ToCopyWorkPermitWithSomeRestrictions(permitScreenerGoofy));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithSomeRestrictions(supervisorDonald));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithSomeRestrictions(operatorMickey));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithSomeRestrictions(nonOpsPermitIssuerPluto));
        }

        [Test]
        public void PermitScreenerNotAuthorizedToCopyWorkPermitsWithNoRestrictions()
        {
            Assert.IsFalse(authorized.ToCopyWorkPermitWithNoRestriction(permitScreenerGoofy));
        }

        [Test]
        public void NonOperationalPermitIssuerAuthorizedToCopyNonOperationalWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(nonOpsPermitIssuerPluto));
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(supervisorDonald));
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(operatorMickey));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithNoRestriction(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCopyWorkPermitWithNoRestriction(permitScreenerGoofy));
        }

        [Test]
        public void NonOperationalPermitIssuerIsAuthorizedToCopyOperationWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(nonOpsPermitIssuerPluto));
        }

        [Test]
        public void SupervisorAndOperatorAuthorizedToCopyOperationWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(supervisorDonald));
            Assert.IsTrue(authorized.ToCopyWorkPermitWithNoRestriction(operatorMickey));
        }
        
        [Test]
        public void PermitScreenerCanCopyToWorkPermitsNotModifiedBySupervisorOrOperator()
        {
            Assert.IsTrue(authorized.ToCopyToWorkPermit(permitScreenerGoofy, modifiedWorkPermitByNotSupervisor, sourceWorkPermit));
        }

        [Test]
        public void SupervisorsCanCopyToWorkPermit()
        {
            Assert.IsTrue(authorized.ToCopyToWorkPermit(supervisorDonald, modifiedWorkPermitByNotSupervisor, sourceWorkPermit));
            Assert.IsTrue(authorized.ToCopyToWorkPermit(supervisorDonald, modifiedWorkPermitBySupervisor, sourceWorkPermit));
            Assert.IsTrue(authorized.ToCopyToWorkPermit(supervisorDonald, notModifiedWorkPermit, sourceWorkPermit));
        }

        [Test]
        public void OperatorsCanCopyToWorkPermit()
        {
            Assert.IsTrue(
                authorized.ToCopyToWorkPermit(operatorMickey, modifiedWorkPermitByNotSupervisor, sourceWorkPermit));
            Assert.IsTrue(
                authorized.ToCopyToWorkPermit(operatorMickey, modifiedWorkPermitBySupervisor, sourceWorkPermit));
            Assert.IsTrue(authorized.ToCopyToWorkPermit(operatorMickey, notModifiedWorkPermit, sourceWorkPermit));
        }

        [Test]
        public void CanOnlyCopyToPendingWorkPermits()
        {
            Assert.IsTrue(authorized.ToCopyToWorkPermit(supervisorDonald, pendingWorkPermit, sourceWorkPermit));
            Assert.IsFalse(authorized.ToCopyToWorkPermit(supervisorDonald, approvedWorkPermit, sourceWorkPermit));
            Assert.IsFalse(authorized.ToCopyToWorkPermit(supervisorDonald, completedWorkPermit, sourceWorkPermit));
            Assert.IsFalse(authorized.ToCopyToWorkPermit(supervisorDonald, issuedWorkPermit, sourceWorkPermit));
            Assert.IsFalse(authorized.ToCopyToWorkPermit(supervisorDonald, rejectedWorkPermit, sourceWorkPermit));
        }
        
        [Test]
        public void CanNotCopyAWorkPermitToItself()
        {
            Assert.IsFalse(authorized.ToCopyToWorkPermit(supervisorDonald, sourceWorkPermit, sourceWorkPermit));
        }

        #endregion

        #region Clone work permit tests

        [Test]
        public void EngineeeringSupportNotAuthorizedToCloneWorkPermits()
        {
            Assert.IsFalse(authorized.ToCloneWorkPermitWithSomeRestrictions(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithNoRestriction(engineeringSupportGoofy));
        }
        
        [Test]
        public void OnlyPermitScreenerAuthorizedToCloneWorkPermitsWithSomeRestrictions()
        {
            Assert.IsTrue(authorized.ToCloneWorkPermitWithSomeRestrictions(permitScreenerGoofy));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithSomeRestrictions(supervisorDonald));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithSomeRestrictions(operatorMickey));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithSomeRestrictions(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithSomeRestrictions(nonOpsPermitIssuerPluto));
        }

        [Test]
        public void PermitScreenerNotAuthorizedToCloneWorkPermitsWithNoRestrictions()
        {
            Assert.IsFalse(authorized.ToCloneWorkPermitWithNoRestriction(permitScreenerGoofy));
        }

        [Test]
        public void NonOperationalPermitIssuerAuthorizedToCloneNonOperationalWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(nonOpsPermitIssuerPluto));
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(supervisorDonald));
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(operatorMickey));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithNoRestriction(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCloneWorkPermitWithNoRestriction(permitScreenerGoofy));
        }

        [Test]
        public void NonOperationalPermitIssuerIsAuthorizedToCloneOperationalWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(nonOpsPermitIssuerPluto));
        }

        [Test]
        public void SupervisorAndOperatorAuthorizedToCloneOperationalWorkPermitsWithNoRestrictions()
        {
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(supervisorDonald));
            Assert.IsTrue(authorized.ToCloneWorkPermitWithNoRestriction(operatorMickey));
        }

        #endregion
        
        #region Approve work permit tests

        [Test]
        public void SupervisorsCanApproveWorkPermits()
        {
            Assert.IsTrue(authorized.ToApproveWorkPermit(supervisorDonald,
                                                         CreateUserShiftContainingPermitStartDateTime(
                                                             notModifiedWorkPermit), notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToApproveWorkPermit(supervisorDonald,
                                                         CreateUserShiftContainingPermitStartDateTime(
                                                             modifiedWorkPermitBySupervisor),
                                                         modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToApproveWorkPermit(supervisorDonald,
                                                         CreateUserShiftContainingPermitStartDateTime(
                                                             modifiedWorkPermitByNotSupervisor),
                                                         modifiedWorkPermitByNotSupervisor));
        }

        [Test]
        public void OperatorsCanApproveWorkPermits()
        {
            Assert.IsTrue(authorized.ToApproveWorkPermit(operatorMickey,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              notModifiedWorkPermit), notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToApproveWorkPermit(operatorMickey,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              modifiedWorkPermitBySupervisor),
                                                          modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToApproveWorkPermit(operatorMickey,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              modifiedWorkPermitByNotSupervisor),
                                                          modifiedWorkPermitByNotSupervisor));
        }

        [Test]
        public void SupervisorsCannotApproveNullWorkPermits()
        {
            List<WorkPermit> list = new List<WorkPermit> {null};
            Assert.IsFalse(authorized.ToApproveWorkPermits(supervisorDonald, null, list));
        }

        [Test]
        public void NonSupervisorsAndNonOperatorsCannotApproveWorkPermits()
        {

            Assert.IsFalse(authorized.ToApproveWorkPermit(engineeringSupportGoofy, null, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToApproveWorkPermit(permitScreenerGoofy, null, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToApproveWorkPermit(nonOpsPermitIssuerPluto, null, notModifiedWorkPermit));
        }

        [Test]
        public void AllowNonOperationsPermitIssuerToApproveNonOperationsPermit()
        {
            WorkPermit nonOperationsPermit =
                CreateWorkPermit(false, WorkPermitStatus.Pending);

            Assert.IsTrue(authorized.ToApproveWorkPermit(nonOpsPermitIssuerPluto,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              nonOperationsPermit),
                                                          nonOperationsPermit));

            Assert.IsTrue(authorized.ToApproveWorkPermit(supervisorDonald,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              nonOperationsPermit),
                                                          nonOperationsPermit));

            Assert.IsTrue(authorized.ToApproveWorkPermit(operatorMickey,
                                                           CreateUserShiftContainingPermitStartDateTime(
                                                               nonOperationsPermit),
                                                          nonOperationsPermit));
            
            Assert.IsFalse(authorized.ToApproveWorkPermit(engineeringSupportGoofy,
                                                          CreateUserShiftContainingPermitStartDateTime(
                                                              nonOperationsPermit),
                                                          nonOperationsPermit));

            Assert.IsFalse(authorized.ToApproveWorkPermit(permitScreenerGoofy,
                                                           CreateUserShiftContainingPermitStartDateTime(
                                                               nonOperationsPermit),
                                                          nonOperationsPermit));
        }

        [Test]
        public void AllowToApproveMultiplePermitsWithBothOperationalAndNonOperationsPermitInList()
        {
            List<WorkPermit> workPermits = CreateList(nonOpsWorkPermit, sourceWorkPermit);

            Assert.IsFalse(authorized.ToApproveWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(workPermits[0]),workPermits));
            Assert.IsTrue(authorized.ToApproveWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsTrue(authorized.ToApproveWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsFalse(authorized.ToApproveWorkPermits(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(workPermits[0]),workPermits));
            Assert.IsFalse(authorized.ToApproveWorkPermits(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(workPermits[0]),workPermits));
        }

        [Test][Ignore]
        public void ShouldApproveMultipleWorkPermits()
        {
            List<WorkPermit> workPermits = CreateList(modifiedWorkPermitBySupervisor, notModifiedWorkPermit);
            Assert.IsTrue(authorized.ToApproveWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsFalse(authorized.ToApproveWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));

            List<WorkPermit> nonOpsWorkPermits = CreateList(nonOpsWorkPermit, nonOpsWorkPermit);
            Assert.IsTrue(authorized.ToApproveWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToApproveWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
        }

        #endregion

        #region Reject Work Permit  tests

        [Test]
        public void SupervisorsCanRejectPendingWorkPermits()
        {
            Assert.IsTrue(authorized.ToRejectWorkPermit(supervisorDonald, notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToRejectWorkPermit(supervisorDonald, modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToRejectWorkPermit(supervisorDonald, modifiedWorkPermitByNotSupervisor));
        }

        [Test]
        public void OperatorsCanRejectPendingWorkPermits()
        {
            Assert.IsTrue(authorized.ToRejectWorkPermit(operatorMickey, notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToRejectWorkPermit(operatorMickey, modifiedWorkPermitBySupervisor));
            Assert.IsTrue(authorized.ToRejectWorkPermit(operatorMickey, modifiedWorkPermitByNotSupervisor));
        }

        [Test]
        public void SupervisorsCannotRejectNullWorkPermits()
        {
            List<WorkPermit> list = CreateList();
            list.Add(null);
            Assert.IsFalse(authorized.ToRejectWorkPermits(supervisorDonald, list));
        }

        [Test]
        public void NonSupervisorsAndNonOperatorsCannotRejectWorkPermits()
        {
            Assert.IsFalse(authorized.ToRejectWorkPermit(engineeringSupportGoofy, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToRejectWorkPermit(permitScreenerGoofy, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToRejectWorkPermit(nonOpsPermitIssuerPluto, notModifiedWorkPermit));
        }

        [Test]
        public void ShouldOnlyAllowNonOperationsPermitIssuerToRejectNonOperationsPermit()
        {
            Assert.IsTrue(authorized.ToRejectWorkPermit(nonOpsPermitIssuerPluto, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToRejectWorkPermit(supervisorDonald, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToRejectWorkPermit(operatorMickey, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToRejectWorkPermit(engineeringSupportGoofy, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToRejectWorkPermit(permitScreenerGoofy, nonOpsWorkPermit));
        }

        [Test]
        public void AllowToRejectMultiplePermitsWithBothOperationalAndNonOperationsPermitInList()
        {
            List<WorkPermit> workPermits = CreateList(nonOpsWorkPermit, sourceWorkPermit);

            Assert.IsFalse(authorized.ToRejectWorkPermits(nonOpsPermitIssuerPluto, workPermits));
            Assert.IsTrue(authorized.ToRejectWorkPermits(operatorMickey, workPermits));
            Assert.IsTrue(authorized.ToRejectWorkPermits(supervisorDonald, workPermits));
            Assert.IsFalse(authorized.ToRejectWorkPermits(engineeringSupportGoofy, workPermits));
            Assert.IsFalse(authorized.ToRejectWorkPermits(permitScreenerGoofy, workPermits));
        }

        [Test]
        public void ShouldRejectMultipleWorkPermits()
        {
            List<WorkPermit> workPermits = CreateList(notModifiedWorkPermit, modifiedWorkPermitBySupervisor, modifiedWorkPermitByNotSupervisor);
            Assert.IsTrue(authorized.ToRejectWorkPermits(supervisorDonald, workPermits));
            Assert.IsTrue(authorized.ToRejectWorkPermits(operatorMickey, workPermits));
            Assert.IsFalse(authorized.ToRejectWorkPermits(nonOpsPermitIssuerPluto, workPermits));

            List<WorkPermit> nonOpsWorkPermits = CreateList(nonOpsWorkPermit, nonOpsWorkPermit);
            Assert.IsTrue(authorized.ToRejectWorkPermits(nonOpsPermitIssuerPluto, nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToRejectWorkPermits(supervisorDonald, nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToRejectWorkPermits(operatorMickey, nonOpsWorkPermits));
        }

        #endregion

        #region Close Work Permit Tests

        [Test]
        public void SupervisorsAndOperatorsCanCloseWorkPermits()
        {
            notModifiedWorkPermit.SetWorkPermitStatusAndApprover(WorkPermitStatus.Approved, UserFixture.CreateSupervisor());
            
            Assert.IsTrue(authorized.ToCloseWorkPermit(supervisorDonald, notModifiedWorkPermit));
            Assert.IsTrue(authorized.ToCloseWorkPermit(operatorMickey, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToCloseWorkPermit(engineeringSupportGoofy, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToCloseWorkPermit(null, notModifiedWorkPermit));
            Assert.IsFalse(authorized.ToCloseWorkPermit(supervisorDonald, null));

            notModifiedWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Complete);
            Assert.IsFalse(authorized.ToCloseWorkPermit(supervisorDonald, notModifiedWorkPermit));
        }

        [Test]
        public void OnlyApprovedOrIssuedWorkPermitsCanBeClosed()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();

            workPermit.SetWorkPermitStatusAndApprover(WorkPermitStatus.Approved, UserFixture.CreateSupervisor());
            
            Assert.IsTrue(authorized.ToCloseWorkPermit(supervisorDonald, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            Assert.IsTrue(authorized.ToCloseWorkPermit(supervisorDonald, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Pending);
            Assert.IsFalse(authorized.ToCloseWorkPermit(supervisorDonald, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Complete);
            Assert.IsFalse(authorized.ToCloseWorkPermit(supervisorDonald, workPermit));
        }

        [Test]
        public void AllowNonOperationsPermitIssuerToCloseNonOperationsPermit()
        {
            nonOpsWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            
            Assert.IsTrue(authorized.ToCloseWorkPermit(nonOpsPermitIssuerPluto, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToCloseWorkPermit(supervisorDonald, nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToCloseWorkPermit(operatorMickey, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToCloseWorkPermit(engineeringSupportGoofy, nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToCloseWorkPermit(permitScreenerGoofy, nonOpsWorkPermit));
        }

        [Test]
        public void AllowNonOperationsPermitIssuerToCloseMultipleNonOperationsPermits()
        {
            nonOpsWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            List<WorkPermit> nonOpsWorkPermits = CreateList(nonOpsWorkPermit, nonOpsWorkPermit);

            Assert.IsTrue(authorized.ToCloseWorkPermits(nonOpsPermitIssuerPluto, nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToCloseWorkPermits(supervisorDonald, nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToCloseWorkPermits(operatorMickey, nonOpsWorkPermits));
            Assert.IsFalse(authorized.ToCloseWorkPermits(engineeringSupportGoofy, nonOpsWorkPermits));
            Assert.IsFalse(authorized.ToCloseWorkPermits(permitScreenerGoofy, nonOpsWorkPermits));
        }

        [Test]
        public void AllowToCloseMultiplePermitsWithBothOperationalAndNonOperationsPermitInList()
        {
            nonOpsWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            sourceWorkPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            
            List<WorkPermit> workPermits = CreateList(nonOpsWorkPermit, sourceWorkPermit);

            Assert.IsFalse(authorized.ToCloseWorkPermits(nonOpsPermitIssuerPluto, workPermits));
            Assert.IsTrue(authorized.ToCloseWorkPermits(supervisorDonald, workPermits));
            Assert.IsTrue(authorized.ToCloseWorkPermits(operatorMickey, workPermits));
            Assert.IsFalse(authorized.ToCloseWorkPermits(engineeringSupportGoofy, workPermits));
            Assert.IsFalse(authorized.ToCloseWorkPermits(permitScreenerGoofy, workPermits));
        }

        #endregion

        #region Print Work Permit tests

        private static List<WorkPermit> CreateList(params WorkPermit[] permits)
        {
            return new List<WorkPermit>(permits);
        }

        [Test]
        public void SupervisorsCanPrintApprovedWorkPermits()
        {
            SetToPrintAbleStatusToApproved(notModifiedWorkPermit);
            SetToPrintAbleStatusToApproved(modifiedWorkPermitBySupervisor);
            SetToPrintAbleStatusToApproved(modifiedWorkPermitByNotSupervisor);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, modifiedWorkPermitBySupervisor, modifiedWorkPermitByNotSupervisor);
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitBySupervisor), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitByNotSupervisor), list));
        }

        [Test]
        public void SupervisorsCanPrintIssuedWorkPermits()
        {
            SetToPrintAbleStatusToIssued(notModifiedWorkPermit);
            SetToPrintAbleStatusToIssued(modifiedWorkPermitBySupervisor);
            SetToPrintAbleStatusToIssued(modifiedWorkPermitByNotSupervisor);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, modifiedWorkPermitBySupervisor, modifiedWorkPermitByNotSupervisor);
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitBySupervisor), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitByNotSupervisor), list));
        }

        [Test]
        public void OperatorsCanPrintIssuedWorkPermits()
        {
            SetToPrintAbleStatusToIssued(notModifiedWorkPermit);
            SetToPrintAbleStatusToIssued(modifiedWorkPermitBySupervisor);
            SetToPrintAbleStatusToIssued(modifiedWorkPermitByNotSupervisor);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, modifiedWorkPermitBySupervisor, modifiedWorkPermitByNotSupervisor);
            Assert.IsTrue(authorized.ToPrintWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitBySupervisor), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitByNotSupervisor), list));
        }

        [Test]
        public void OperatorsCanPrintApprovedWorkPermits()
        {
            SetToPrintAbleStatusToApproved(notModifiedWorkPermit);
            SetToPrintAbleStatusToApproved(modifiedWorkPermitBySupervisor);
            SetToPrintAbleStatusToApproved(modifiedWorkPermitByNotSupervisor);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, modifiedWorkPermitBySupervisor, modifiedWorkPermitByNotSupervisor);
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitBySupervisor), list));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(modifiedWorkPermitByNotSupervisor), list));
        }

        [Test]
        public void NonSupervisorsAndNonOperatorsCannotPrintApprovedWorkPermits()
        {
            SetToPrintAbleStatusToApproved(notModifiedWorkPermit);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, notModifiedWorkPermit);
            Assert.IsFalse(authorized.ToPrintWorkPermits(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
        }

        [Test]
        public void NonSupervisorsAndNonOperatorsCannotPrintIssuedWorkPermits()
        {
            SetToPrintAbleStatusToIssued(notModifiedWorkPermit);

            List<WorkPermit> list = CreateList(notModifiedWorkPermit, notModifiedWorkPermit);
            Assert.IsFalse(authorized.ToPrintWorkPermits(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(notModifiedWorkPermit), list));
        }

        [Test]
        public void NoOneCanPrintNullWorkPermits()
        {
            List<WorkPermit> list = CreateList();
            list.Add(null);
            Assert.IsFalse(authorized.ToPrintWorkPermits(supervisorDonald, null, list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(operatorMickey, null, list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(engineeringSupportGoofy, null, list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(permitScreenerGoofy, null, list));
            Assert.IsFalse(authorized.ToPrintWorkPermits(nonOpsPermitIssuerPluto, null, list));
        }

        [Test]
        public void AllowNonOperationsPermitIssuerToPrintNonOperationsPermit()
        {
            SetToPrintAbleStatusToIssued(nonOpsWorkPermit);
            
            Assert.IsTrue(authorized.ToPrintWorkPermit(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermit), nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToPrintWorkPermit(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermit), nonOpsWorkPermit));
            Assert.IsTrue(authorized.ToPrintWorkPermit(operatorMickey, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermit), nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToPrintWorkPermit(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermit), nonOpsWorkPermit));
            Assert.IsFalse(authorized.ToPrintWorkPermit(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermit), nonOpsWorkPermit));
        }

        [Test]
        public void AllowNonOperationsPermitIssuerToPrintMultipleNonOperationsPermits()
        {
            SetToPrintAbleStatusToIssued(nonOpsWorkPermit);
            
            List<WorkPermit> nonOpsWorkPermits = CreateList(nonOpsWorkPermit, nonOpsWorkPermit);

            Assert.IsTrue(authorized.ToPrintWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
            Assert.IsTrue(authorized.ToPrintWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
            Assert.IsFalse(authorized.ToPrintWorkPermits(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
            Assert.IsFalse(authorized.ToPrintWorkPermits(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(nonOpsWorkPermits[0]), nonOpsWorkPermits));
        }

        [Test]
        public void AllowToPrintMultiplePermitsWithBothOperationalAndNonOperationsPermitInList()
        {
            SetToPrintAbleStatusToIssued(nonOpsWorkPermit);
            SetToPrintAbleStatusToIssued(sourceWorkPermit);
            
            List<WorkPermit> workPermits = CreateList(nonOpsWorkPermit, sourceWorkPermit);

            Assert.IsFalse(authorized.ToPrintWorkPermits(nonOpsPermitIssuerPluto, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsTrue(authorized.ToPrintWorkPermits(operatorMickey, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsTrue(authorized.ToPrintWorkPermits(supervisorDonald, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsFalse(authorized.ToPrintWorkPermits(engineeringSupportGoofy, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
            Assert.IsFalse(authorized.ToPrintWorkPermits(permitScreenerGoofy, CreateUserShiftContainingPermitStartDateTime(workPermits[0]), workPermits));
        }

        #endregion

        #region View Work Permit

        [Test]
        public void AnyoneCanViewWorkPermits()
        {
            Assert.IsTrue(authorized.ToViewWorkPermits(supervisorDonald));
            Assert.IsTrue(authorized.ToViewWorkPermits(operatorMickey));
            Assert.IsTrue(authorized.ToViewWorkPermits(engineeringSupportGoofy));
            Assert.IsTrue(authorized.ToViewWorkPermits(permitScreenerGoofy));
        }

        #endregion

        #region Create Work Permit

        [Test]
        public void EveryoneCanCreateWorkPermits()
        {
            Assert.IsTrue(authorized.ToCreateWorkPermits(supervisorDonald));
            Assert.IsTrue(authorized.ToCreateWorkPermits(operatorMickey));
            Assert.IsTrue(authorized.ToCreateWorkPermits(engineeringSupportGoofy));
            Assert.IsTrue(authorized.ToCreateWorkPermits(permitScreenerGoofy));
            Assert.IsTrue(authorized.ToCreateWorkPermits(nonOpsPermitIssuerPluto));
        }

//        [Test]
//        public void OnlyPermitScreenerCanCreateWorkPermitsWithSomeRestrictions()
//        {
//            Assert.IsFalse(authorized.ToCreateWorkPermitsWithSomeRestrictions(supervisorDonald));
//            Assert.IsFalse(authorized.ToCreateWorkPermitsWithSomeRestrictions(operatorMickey));
//            Assert.IsFalse(authorized.ToCreateWorkPermitsWithSomeRestrictions(engineeringSupportGoofy));
//            Assert.IsTrue(authorized.ToCreateWorkPermitsWithSomeRestrictions(permitScreenerGoofy));
//            Assert.IsFalse(authorized.ToCreateWorkPermitsWithSomeRestrictions(nonOpsPermitIssuerPluto));
//        }

        [Test]
        public void PermitScreenerCanNotCreateWorkPermitsWithNoRestriction()
        {
            Assert.IsTrue(authorized.ToCreateWorkPermitsWithNoRestriction(supervisorDonald));
            Assert.IsTrue(authorized.ToCreateWorkPermitsWithNoRestriction(operatorMickey));
            Assert.IsTrue(authorized.ToCreateWorkPermitsWithNoRestriction(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCreateWorkPermitsWithNoRestriction(permitScreenerGoofy));
            Assert.IsTrue(authorized.ToCreateWorkPermitsWithNoRestriction(nonOpsPermitIssuerPluto));
        }

        #endregion

        #region Comment WorkPermit

        [Test]
        public void SupervisiorAndOperatorCommentWorkPermit()
        {
            Assert.IsTrue(authorized.ToCommentWorkPermit(supervisorDonald));
            Assert.IsTrue(authorized.ToCommentWorkPermit(operatorMickey));
        }

        [Test]
        public void NonSupervisorAndNonOperatorCanNotCommentWorkPermit()
        {
            Assert.IsFalse(authorized.ToCommentWorkPermit(engineeringSupportGoofy));
            Assert.IsFalse(authorized.ToCommentWorkPermit(permitScreenerGoofy));
            Assert.IsFalse(authorized.ToCommentWorkPermit(nonOpsPermitIssuerPluto));
        }

        #endregion

        #region User shift dependent authorizations

        [Test]
        public void CanOnlyApproveWorkPermitIfStartingInCurrentShiftWithPadding()
        {
            CanOnlyAuthorizeWorkPermitIfStartingInCurrentShiftWithPadding(authorized.ToApproveWorkPermit);
        }

        [Test]
        public void CanOnlyPrintWorkPermitIfStartingInCurrentShiftWithPadding()
        {
            CanOnlyAuthorizeWorkPermitIfStartingInCurrentShiftWithPadding(authorized.ToPrintWorkPermit);
        }

        /// <summary>
        /// Runs tests for an authorization check that takes into account the work permit
        /// start date/time being contained in the current user shift.
        /// </summary>
        private void CanOnlyAuthorizeWorkPermitIfStartingInCurrentShiftWithPadding(AuthorizeCheck authorizeCheck)
        {
            // Shift                     Permit
            // Start                     Start             AuthorizedTo?
            // 2006/02/15 08:00 - 16:00  2006/02/15 07:29  No
            // 2006/02/15 08:00 - 16:00  2006/02/15 07:30  Yes
            // 2006/02/15 08:00 - 16:00  2006/02/15 12:00  Yes
            // 2006/02/15 08:00 - 16:00  2006/02/15 16:30  Yes
            // 2006/02/15 08:00 - 16:00  2006/02/15 16:31  No

            UserShift shift8amto4pm = CreateUserShift(new Date(2006, 2, 15), new Time(8, 0), new Time(16, 0));

            AssertAuthorization(false, shift8amto4pm, new DateTime(2006, 2, 15, 7, 29, 0), authorizeCheck);
            AssertAuthorization(true, shift8amto4pm, new DateTime(2006, 2, 15, 7, 30, 0), authorizeCheck);
            AssertAuthorization(true, shift8amto4pm, new DateTime(2006, 2, 15, 12, 0, 0), authorizeCheck);
            AssertAuthorization(true, shift8amto4pm, new DateTime(2006, 2, 15, 16, 30, 0), authorizeCheck);
            AssertAuthorization(false, shift8amto4pm, new DateTime(2006, 2, 15, 16, 31, 0), authorizeCheck);
        }

        private void AssertAuthorization(bool expectedToBeAuthorized, UserShift currentShift, DateTime permitStartDateTime, AuthorizeCheck authorizeCheck)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            workPermit.Specifics.StartDateTime = permitStartDateTime;
            if (authorizeCheck == authorized.ToPrintWorkPermit)
            {
                SetToPrintAbleStatusToApproved(workPermit);
            }

            Assert.AreEqual(expectedToBeAuthorized, authorizeCheck(supervisorDonald, currentShift, workPermit));
        }

        #endregion

        #region Authorizations based on Status

        #region Approving of Different Status

        private void AuthorizeApprovalTest(WorkPermitStatus status, bool allowApproving)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit(status);
            UserShift userShift = CreateUserShiftContainingPermitStartDateTime(workPermit);

            bool actualAuthorization = authorized.ToApproveWorkPermit(supervisorDonald, userShift, workPermit);
            Assert.AreEqual(allowApproving, actualAuthorization);
        }

        [Test]
        public void CannotApproveApprovedWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Approved, false);
        }
        
        [Test]
        public void CannotApproveIssuedWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Issued, false);
        }
        
        [Test]
        public void CannotApproveCompletedWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Complete, false);
        }

        [Test]
        public void CannotApproveArchivedWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Archived, false);
        }

        
        [Test]
        public void CanApprovePendingWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Pending, true);
        }

        [Test]
        public void CanApproveRejectedWorkPermit()
        {
            AuthorizeApprovalTest(WorkPermitStatus.Rejected, true);
        }

        [Test][Ignore]
        public void ShouldApproveIfSingleSelectedWorkPermitHasWarnings()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithWarning(-99);

            List<WorkPermit> workPermits = new List<WorkPermit> {permit};

            UserShift userShift = CreateUserShiftContainingPermitStartDateTime(permit);

            Assert.IsTrue(authorized.ToApproveWorkPermits(supervisorDonald, userShift, workPermits));
        }
        
        [Test]
        public void CanApproveMultipleWorkPermitsEvenIfOneOrMoreHasWarnings()
        {
            WorkPermit validPermit = WorkPermitFixture.CreateValidWorkPermit(-2000);
            WorkPermit permitWithWarning = WorkPermitFixture.CreateWorkPermitWithWarning(-99);

            List<WorkPermit> workPermits = new List<WorkPermit> {validPermit, permitWithWarning};

            UserShift userShift = CreateUserShiftContainingPermitStartDateTime(validPermit);

            Assert.IsTrue(authorized.ToApproveWorkPermits(supervisorDonald, userShift, workPermits));
        }

        #endregion

        #region Rejecting of Different Status

        private void AuthorizeRejectionTest(WorkPermitStatus status, bool allowRejecting)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit(status);
            bool actualAuthorization = authorized.ToRejectWorkPermit(supervisorDonald, workPermit);
            Assert.AreEqual(allowRejecting, actualAuthorization);
        }

        [Test]
        public void CannotRejectRejecteddWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Rejected, false);
        }
        [Test]
        public void CannotRejectApprovedWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Approved, false);
        }
        [Test]
        public void CannotRejectIssuedWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Issued, false);
        }
        
        [Test]
        public void CannotRejectCompletedWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Complete, false);
        }  
        [Test]
        public void CannotRejectArchivedWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Archived, false);
        }
        
        [Test]
        public void CanRejectPendingWorkPermit()
        {
            AuthorizeRejectionTest(WorkPermitStatus.Pending, true);
        }

        #endregion

        #region Deletion of Different Status

        private void AuthorizeDeletionTest(WorkPermitStatus status, bool allowDeletion)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit(status);

            bool actualAuthorization = authorized.ToDeleteWorkPermit(supervisorDonald, workPermit);
            Assert.AreEqual(allowDeletion, actualAuthorization);
        }
        [Test]
        public void CanDeletePendingWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Pending, true);
        }
        [Test]
        public void CanDeleteRejectedWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Rejected, true);
        }
        [Test]
        public void CannotDeleteApprovedWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Approved, false);
        }
        
        [Test]
        public void CannotDeleteIssuedWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Issued, false);
        }

        [Test]
        public void CannotDeleteCompletedWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Complete, false);
        }
        [Test]
        public void CannotDeleteArchivedWorkPermit()
        {
            AuthorizeDeletionTest(WorkPermitStatus.Archived, false);
        }

        #endregion

        #region Editing of Different Status

        private void AuthorizeEditingTest(WorkPermitStatus status, bool allowEditing)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit(status);
            bool actualAuthorization = authorized.ToEditWorkPermit(supervisorDonald, workPermit);
            Assert.AreEqual(allowEditing, actualAuthorization);
        }

        [Test]
        public void CannotEditCompletedWorkPermit()
        {
            AuthorizeEditingTest(WorkPermitStatus.Complete, false);
        }

        [Test]
        public void CannotEditIssuedWorkPermit()
        {
            AuthorizeEditingTest(WorkPermitStatus.Issued, false);
        }

        [Test]
        public void CanEditPendingWorkPermit()
        {
            AuthorizeEditingTest(WorkPermitStatus.Pending, true);
        }

        [Test]
        public void CannotEditApprovedWorkPermit()
        {
            AuthorizeEditingTest(WorkPermitStatus.Approved, false);
        }

        #endregion

        #region Closing of Different Status

        private void AuthorizeClosingTest(WorkPermitStatus status, bool allowClosing)
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermit(status);
            bool actualAuthorization = authorized.ToCloseWorkPermit(supervisorDonald, workPermit);
            Assert.AreEqual(allowClosing, actualAuthorization);
        }

        [Test]
        public void CanCloseApprovedWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Approved, true);
        }
        [Test]
        public void CanCloseIssuedWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Issued, true);
        }
        [Test]
        public void CannotClosePendingWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Pending, false);
        }
        [Test]
        public void CannotCloseRejectedWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Rejected, false);
        }

        [Test]
        public void CannotCloseCompletedWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Complete, false);
        }

        [Test]
        public void CannotCloseArchivedWorkPermit()
        {
            AuthorizeClosingTest(WorkPermitStatus.Archived, false);
        }

        #endregion

        #region Printing of Different Status

        
        [Test]
        public void ShouldNotBeAbleToPrintPendingOrRejectedWorkPermits()
        {
            UserShift userShift = UserShiftFixture.CreateUserShift();
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();
            Assert.IsFalse(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Rejected);
            Assert.IsFalse(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));
        }

        [Test]
        public void ShouldOnlyBeAbleToPrintApprovedWorkPermitIfInCurrentShift()
        {
            UserShift userShift = UserShiftFixture.CreateUserShift();
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID(userShift.StartDateTime.AddMinutes(5));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Approved);
            Assert.IsTrue(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));
        }

        [Test]
        public void ShouldBeAbleToPrintIssuedCompletedAndArchivedWorkPermits()
        {
            UserShift userShift = UserShiftFixture.CreateUserShift();
            WorkPermit workPermit = WorkPermitFixture.CreateABigManualWorkPermitWithNoID();

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Issued);
            Assert.IsTrue(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Complete);
            Assert.IsTrue(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));

            workPermit.SetWorkPermitStatus(WorkPermitStatus.Archived);
            Assert.IsTrue(authorized.ToPrintWorkPermit(supervisorDonald, userShift, workPermit));
        }

        #endregion

        #endregion

        private static WorkPermit CreateWorkPermit(bool isOperations, WorkPermitStatus status)
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermit();
            permit.SetWorkPermitStatus(status);
            permit.SetCreatedBy(UserFixture.CreateUser(), isOperations);
            return permit;
        }

        private static void SetToPrintAbleStatusToApproved(WorkPermit permit)
        {
            permit.SetWorkPermitStatus(WorkPermitStatus.Approved);
        }

        private static void SetToPrintAbleStatusToIssued(WorkPermit permit)
        {
            permit.SetWorkPermitStatus(WorkPermitStatus.Approved);
        }

        private static UserShift CreateUserShiftContainingPermitStartDateTime(WorkPermit permit)
        {
            Time startTime = new Time(permit.StartDateTime);
            Time start = startTime.Add(-1);
            Time end = startTime.Add(1);
            return CreateUserShift(start < startTime ? new Date(permit.StartDateTime) : new Date(permit.StartDateTime).SubtractDays(1), start, end);
        }

        private static UserShift CreateUserShift(Date day, Time start, Time end)
        {
            DateTime dateTime = day.CreateDateTime(start);
            return new UserShift(ShiftPatternFixture.CreateShiftPattern("test", start, end, dateTime, SiteFixture.Sarnia()), dateTime);
        }

    }
}