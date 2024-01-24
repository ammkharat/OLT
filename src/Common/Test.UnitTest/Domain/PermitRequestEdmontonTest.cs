using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitRequestEdmontonTest
    {

        [Test]
        public void ShouldUpdateExistingAndReevaluateIsCompleteWhenNotUserModified()
        {            
            PermitRequestEdmonton validPermitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            validPermitRequest.FireBlanket = true;
            validPermitRequest.AreaLabel = AreaLabelFixture.CreateWithExistingId();

            PermitRequestEdmonton emptyPermitRequest = PermitRequestEdmontonFixture.GetEmptyPermitRequest();
            emptyPermitRequest.UpdateFrom(validPermitRequest);

            PermitRequestValidator validator = new PermitRequestValidator(new PermitRequestEdmontonValidationDomainAdapter(emptyPermitRequest), DataSource.SAP);            
            validator.Validate();
            Assert.AreEqual(PermitRequestCompletionStatus.Complete, validator.CompletionStatus);

            PermitRequestEdmonton newlyUpdatedPermitRequest = emptyPermitRequest;

            // Some random checks.
            Assert.AreEqual(validPermitRequest.FunctionalLocation, newlyUpdatedPermitRequest.FunctionalLocation);
            Assert.AreEqual(validPermitRequest.SteamHose, newlyUpdatedPermitRequest.SteamHose);
            Assert.AreEqual(validPermitRequest.GN24_Deprecated, newlyUpdatedPermitRequest.GN24_Deprecated);
            Assert.AreEqual(validPermitRequest.BarriersSigns, newlyUpdatedPermitRequest.BarriersSigns);
            Assert.AreEqual(validPermitRequest.BumpTestMonitorPriorToUse, newlyUpdatedPermitRequest.BumpTestMonitorPriorToUse);
            Assert.AreEqual(validPermitRequest.FaceShield, newlyUpdatedPermitRequest.FaceShield);
            Assert.AreEqual(validPermitRequest.FireBlanket, newlyUpdatedPermitRequest.FireBlanket);
            Assert.AreEqual(validPermitRequest.Description, newlyUpdatedPermitRequest.Description);
            Assert.AreEqual(validPermitRequest.HazardsAndOrRequirements, newlyUpdatedPermitRequest.HazardsAndOrRequirements);            
            Assert.AreEqual(validPermitRequest.AreaLabel.IdValue, newlyUpdatedPermitRequest.AreaLabel.IdValue);
        }

        [Test]
        public void ShouldNotReplaceLastSubmittedByAndLastSubmittedDateWhenUpdatingFromAnotherPermitRequest()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            DateTime dateTime = DateTime.Now;

            PermitRequestEdmonton validPermitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();            
            validPermitRequest.LastSubmittedByUser = user;            
            validPermitRequest.LastSubmittedDateTime = dateTime;

            PermitRequestEdmonton anotherPermitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            anotherPermitRequest.LastSubmittedByUser = null;
            anotherPermitRequest.LastSubmittedDateTime = null;
            validPermitRequest.UpdateFrom(anotherPermitRequest);

            Assert.AreEqual(user, validPermitRequest.LastSubmittedByUser);
            Assert.AreEqual(dateTime, validPermitRequest.LastSubmittedDateTime);
        }

        private PermitRequestEdmonton CreatePermitRequest(string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            PermitRequestEdmonton emptyPermitRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());
            emptyPermitRequest.ClearWorkOrderSources();
            emptyPermitRequest.AddWorkOrderSource(workOrderNumber, operationNumber, subOperationNumber);

            return emptyPermitRequest;
        }

        [Test]
        public void ShouldDetermineIfAtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionIsSelected()
        {
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());
                ClearWorkersMinimumSafetyRequirementsSectionValues(request);
                Assert.IsFalse(request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected());
            }
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());
                ClearWorkersMinimumSafetyRequirementsSectionValues(request);
                request.Goggles = true;
                Assert.IsTrue(request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected());
            }
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());
                ClearWorkersMinimumSafetyRequirementsSectionValues(request);
                request.EquipmentGrounded = true;
                request.BumpTestMonitorPriorToUse = true;
                Assert.IsTrue(request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected());
            }
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.SAP, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateForInsert());
                ClearWorkersMinimumSafetyRequirementsSectionValues(request);
                request.Other3 = "Hello";
                Assert.IsTrue(request.AtLeastOneAttributeInTheWorkersMinimumSafetyRequirementsSectionSectionIsSelected());
            }
        }

        private static void ClearWorkersMinimumSafetyRequirementsSectionValues(PermitRequestEdmonton request)
        {
            request.FaceShield = false;
            request.Goggles = false;
            request.RubberBoots = false;
            request.RubberGloves = false;
            request.RubberSuit = false;
            request.SafetyHarnessLifeline = false;
            request.HighVoltagePPE = false;
            request.Other1 = null;

            request.EquipmentGrounded = false;
            request.FireBlanket = false;
            request.FireExtinguisher = false;
            request.FireMonitorManned = false;
            request.FireWatch = false;
            request.SewersDrainsCovered = false;
            request.SteamHose = false;
            request.Other2 = null;

            request.AirPurifyingRespirator = false;
            request.BreathingAirApparatus = false;
            request.DustMask = false;
            request.LifeSupportSystem = false;
            request.SafetyWatch = false;
            request.ContinuousGasMonitor = false;
            request.WorkersMonitor = false;
            request.WorkersMonitorNumber = null;
            request.BumpTestMonitorPriorToUse = false;
            request.Other3 = null;

            request.AirMover = false;
            request.BarriersSigns = false;
            request.RadioChannel = false;
            request.RadioChannelNumber = null;
            request.AirHorn = false;
            request.MechVentilationComfortOnly = false;
            request.AsbestosMMCPrecautions = false;
            request.Other4 = null;

        }

        [Test]
        public void ShouldGenerateTheCorrectShiftForThePermit()
        {
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartDate = new Date(2012, 10, 26);
                permitRequest.RequestedStartTimeDay = new Time(3);

                Date submitDate = new Date(2012, 10, 26);

                DateTime requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                Assert.That(requestedStartDateTime, Is.EqualTo(new DateTime(2012, 10, 26, 3, 0, 0)));

                UserShift userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);

                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 10, 25, 18, 30, 0)));
                Assert.That(userShift.EndDateTime, Is.EqualTo(new DateTime(2012, 10, 26, 6, 30, 0)));
            }

            // Set Requested Time to 8am
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartDate = new Date(2012, 10, 31);
                permitRequest.RequestedStartTimeDay = new Time(8);

                Date submitDate = new Date(2012, 11, 01);

                DateTime requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                Assert.That(requestedStartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 8, 0, 0)));

                UserShift userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);

                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 6, 30, 0)));
                Assert.That(userShift.EndDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 18, 30, 0)));

                // Now get submit Date to one day ahead.
                submitDate = submitDate.AddDays(1);
                requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);
                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 11, 02, 6, 30, 0)));
            }

            // Set Requested Time to 1am
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartDate = new Date(2012, 10, 31);
                permitRequest.RequestedStartTimeDay = new Time(1);

                Date submitDate = new Date(2012, 11, 01);

                DateTime requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                Assert.That(requestedStartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 1, 0, 0)));

                UserShift userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);

                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 10, 31, 18, 30, 0)));
                Assert.That(userShift.EndDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 6, 30, 0)));

                // Now get submit Date to one day ahead.
                submitDate = submitDate.AddDays(1);
                requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);
                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 18, 30, 0)));
            }

            // Set Requested Time to 8pm
            {
                PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                permitRequest.RequestedStartDate = new Date(2012, 10, 31);
                permitRequest.RequestedStartTimeDay = new Time(20);

                Date submitDate = new Date(2012, 11, 01);

                DateTime requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                Assert.That(requestedStartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 20, 0, 0)));

                UserShift userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);

                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 11, 01, 18, 30, 0)));
                Assert.That(userShift.EndDateTime, Is.EqualTo(new DateTime(2012, 11, 02, 6, 30, 0)));

                // Now get submit Date to one day ahead.
                submitDate = submitDate.AddDays(1);
                requestedStartDateTime = submitDate.CreateDateTime(permitRequest.RequestedStartTimeDay);
                userShift = WorkPermitEdmonton.UserShift(requestedStartDateTime);
                Assert.That(userShift.StartDateTime, Is.EqualTo(new DateTime(2012, 11, 02, 18, 30, 0)));
            }

        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnPermitFlocsAndNotMainFlocs()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            Assert.IsTrue(request.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string> { "ED1-A001" },null, null));
            Assert.IsFalse(request.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string> { "ED1-A002" },null, null));
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnMainFlocsWhenThereAreNoPermitFlocs()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            request.FunctionalLocation = FunctionalLocationFixture.GetReal_ED1_A001_U007();

            Assert.IsFalse(request.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string>(), null,null));
            Assert.IsTrue(request.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string>(), null,null));
        }

        [Test]
        public void ShouldNotDuplicateWorkOrderInfoInStringLists()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                     
            request.ClearWorkOrderSources();
            request.AddWorkOrderSource("12345", "0010", null);
            request.AddWorkOrderSource("12345", "0010", "001");
            request.AddWorkOrderSource("12345", "0010", "002");
            request.AddWorkOrderSource("12345", "0020", null);
            
            Assert.AreEqual("0010, 0020", request.OperationNumberListAsString);
            Assert.AreEqual("0010-001, 0010-002", request.SubOperationNumberListAsString);
        }

        [Test]        
        public void ShouldNotBeAbleToAddInvalidSource()
        {            
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                request.ClearWorkOrderSources();
                request.AddWorkOrderSource("12345", "0010", "0001");
                Assert.Throws<ArgumentException>(() => request.AddWorkOrderSource("56789", "0010", "0002"));                
            }
            {
                PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
                request.ClearWorkOrderSources();
                request.AddWorkOrderSource("12345", "0010", "0001");
                Assert.DoesNotThrow(() => request.AddWorkOrderSource("12345", "0010", "0002"));                
            }
        }

        [Test]
        public void ShouldDisplaySubOperationNumbersWithTheirOperationNumbers()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateValidCompletePermitRequest();
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("555", "1000", "0002");
            permitRequest.AddWorkOrderSource("555", "1001", "0001");
            permitRequest.AddWorkOrderSource("555", "1000", "0001");
            permitRequest.AddWorkOrderSource("555", "1001", "0002");

            Assert.AreEqual("1000-0001, 1000-0002, 1001-0001, 1001-0002", permitRequest.SubOperationNumberListAsString);
        }

        [Test]
        public void ShouldFindRemovalListForImportsButNotRemoveStuffThatWasImportedButFailedValidation_CaseWhereEverythingFailsValidation()
        {
            List<PermitRequestEdmonton> existingDataList = new List<PermitRequestEdmonton>();
            existingDataList.Add(CreatePermitRequest("1111", "ABCD", "HAHA")); // Incoming, passed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("2222", "POOP", null));  // Incoming, failed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("3333", null, null)); // Incoming, failed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("4444", null, null)); // existing but not incoming, should be removed

            List<IHasPermitKey> incomingRequests = new List<IHasPermitKey>();

            List<IHasPermitKey> thingsThatFailedValidation = new List<IHasPermitKey>()
                                                                 {
                                                                     new ValidationFailure("1111", "ABCD", "HAHA"), 
                                                                     new ValidationFailure("2222", "POOP", null), 
                                                                     new ValidationFailure("3333", null, null),
                                                                     new ValidationFailure("4444", null, null)
                                                                 };

            List<PermitRequestEdmonton> removalList = PermitRequestEdmonton.BuildImportRemovalList(existingDataList, incomingRequests, thingsThatFailedValidation);

            Assert.IsTrue(removalList.Count == 0);
        }

        [Test]      
        public void ShouldFindRemovalListForImports()
        {
            List<PermitRequestEdmonton> existingDataList = new List<PermitRequestEdmonton>();
            existingDataList.Add(CreatePermitRequest("1111", null, null));
            existingDataList.Add(CreatePermitRequest("2222", null, null));
            existingDataList.Add(CreatePermitRequest("3333", null, null));

            List<IHasPermitKey> incomingRequests = new List<IHasPermitKey>();
            incomingRequests.Add(new PermitKeyData("1111", null, null));
            incomingRequests.Add(new PermitKeyData("3333", null, null));

            List<PermitRequestEdmonton> removalList = PermitRequestEdmonton.BuildImportRemovalList(existingDataList, incomingRequests, new List<IHasPermitKey>());

            Assert.IsTrue(removalList.Count == 1);
            Assert.IsTrue(removalList.Exists(r => r.WorkOrderNumber == "2222"));            
        }

        [Test]      
        public void ShouldFindRemovalListForImportsButNotRemoveStuffThatWasImportedButFailedValidation()
        {
            List<PermitRequestEdmonton> existingDataList = new List<PermitRequestEdmonton>();
            existingDataList.Add(CreatePermitRequest("1111", "ABCD", "HAHA")); // Incoming, passed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("2222", "POOP", null));  // Incoming, failed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("3333", null, null)); // Incoming, failed validation, should not be removed
            existingDataList.Add(CreatePermitRequest("4444", null, null)); // existing but not incoming, should be removed

            List<IHasPermitKey> incomingRequests = new List<IHasPermitKey>();
            incomingRequests.Add(new PermitKeyData("1111", "ABCD", "HAHA")); // Incoming, passed validation          

            List<IHasPermitKey> thingsThatFailedValidation =
                new List<IHasPermitKey>() { new ValidationFailure("2222", "POOP", null), new ValidationFailure("3333", null, null) };

            List<PermitRequestEdmonton> removalList = PermitRequestEdmonton.BuildImportRemovalList(existingDataList, incomingRequests, thingsThatFailedValidation);

            Assert.IsTrue(removalList.Exists(r => Matches(r, "4444", null, null)));
            Assert.IsFalse(removalList.Exists(r => Matches(r, "1111", "ABCD", "HAHA")));
            Assert.IsFalse(removalList.Exists(r => Matches(r, "2222", "POOP", null)));
            Assert.IsFalse(removalList.Exists(r => Matches(r, "3333", null, null)));
            Assert.IsTrue(removalList.Count == 1);                                   
        }

        [Test]
        public void CloneShouldKeepGN7andGN59andGN6andGN24CheckedButGetRidOfTheAssociatedDetails()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), WorkPermitEdmontonGroupFixture.CreateP1());

            request.Id = 1;

            request.GN59 = true;
            request.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            request.GN7 = true;
            request.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            request.GN6 = true;
            request.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            request.GN24 = true;
            request.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();

            request.ConvertToClone(UserFixture.CreateAdmin());

            Assert.IsTrue(request.GN59);
            Assert.IsNull(request.FormGN59);
            Assert.IsTrue(request.GN7);
            Assert.IsNull(request.FormGN7);
            Assert.IsTrue(request.GN24);
            Assert.IsNull(request.FormGN24);
            Assert.IsTrue(request.GN6);
            Assert.IsNull(request.FormGN6);
            Assert.IsTrue(request.RescuePlan);
            Assert.IsNull(request.RescuePlanFormNumber);
        }

        private class ValidationFailure : IHasPermitKey
        {
            public ValidationFailure(string workOrderNumber, string operationNumber, string subOperationNumber)
            {
                WorkOrderNumber = workOrderNumber;
                OperationNumber = operationNumber;
                SubOperationNumber = subOperationNumber;
            }

            public string WorkOrderNumber { get; private set; }
            public string OperationNumber { get; private set; }
            public string SubOperationNumber { get; private set; }

            public bool MatchesByPermitKey(IHasPermitKey item)
            {
                return PermitKeyData.MatchesByPermitKey(this, item);
            }
        }

        private bool Matches(PermitRequestEdmonton a, string workOrderNumber, string operationNumber, string subOperationNumber)
        {
            return a.ContainsWorkOrderSource(new PermitKeyData(workOrderNumber, operationNumber, subOperationNumber));            
        }       
    }
}
