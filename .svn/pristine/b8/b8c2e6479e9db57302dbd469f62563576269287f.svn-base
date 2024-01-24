using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitEdmontonTest
    {

        [Test]
        public void BuildPermitToSubmitShouldCopyOverTheRelevantProperties()
        {
            PermitRequestEdmonton request = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), new WorkPermitEdmontonGroup(0, "Group", new List<long> { 0 }, 0, false));
            request.DocumentLinks.Clear();
            request.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            request.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink(2));

            DateTime now = Clock.Now;
            User user = UserFixture.CreateUser();

            WorkPermitEdmonton workPermit = new WorkPermitEdmonton(DataSource.PERMIT_REQUEST, PermitRequestBasedWorkPermitStatus.Requested, request.WorkPermitType, now, user);
            workPermit.BuildPermitToSubmit(request, user, now, new Date(now), now);

            Assert.AreEqual(request.IssuedToSuncor, workPermit.IssuedToSuncor);
            Assert.AreEqual(true, workPermit.IssuedToCompany);
            Assert.AreEqual(request.Priority, workPermit.Priority);
            Assert.AreEqual(request.Company, workPermit.Company);
            Assert.AreEqual(request.Occupation, workPermit.Occupation);
            Assert.AreEqual(request.NumberOfWorkers, workPermit.NumberOfWorkers);
            Assert.AreEqual(request.Group, workPermit.Group);
            Assert.AreEqual(request.AreaLabel, workPermit.AreaLabel);
            Assert.AreEqual(request.WorkPermitType, workPermit.WorkPermitType);
            Assert.AreEqual(request.FunctionalLocation, workPermit.FunctionalLocation);
            Assert.AreEqual(request.Location, workPermit.Location);
            Assert.AreEqual(request.AlkylationEntry, workPermit.AlkylationEntry);
            Assert.AreEqual(request.AlkylationEntryClassOfClothing, workPermit.AlkylationEntryClassOfClothing);
            Assert.AreEqual(request.FlarePitEntry, workPermit.FlarePitEntry);
            Assert.AreEqual(request.FlarePitEntryType, workPermit.FlarePitEntryType);
            Assert.AreEqual(request.ConfinedSpace, workPermit.ConfinedSpace);
            Assert.AreEqual(request.ConfinedSpaceClass, workPermit.ConfinedSpaceClass);
            Assert.AreEqual(request.ConfinedSpaceCardNumber, workPermit.ConfinedSpaceCardNumber);
            Assert.AreEqual(request.RescuePlan, workPermit.RescuePlan);
            Assert.AreEqual(request.RescuePlanFormNumber, workPermit.RescuePlanFormNumber);
            Assert.AreEqual(request.SpecialWork, workPermit.SpecialWork);
            //Assert.AreEqual(request.SpecialWorkType, workPermit.SpecialWorkType);
            Assert.AreEqual(request.specialworktype, workPermit.specialworktype);//mangesh for SpecialWork
            Assert.AreEqual(request.SpecialWorkName, workPermit.SpecialWorkName);

            Assert.AreEqual(request.SpecialWorkFormNumber, workPermit.SpecialWorkFormNumber);
            Assert.AreEqual(request.VehicleEntry, workPermit.VehicleEntry);
            Assert.AreEqual(request.VehicleEntryType, workPermit.VehicleEntryType);
            Assert.AreEqual(request.VehicleEntryTotal, workPermit.VehicleEntryTotal);
            Assert.AreEqual(request.GN59, workPermit.GN59);
            Assert.AreEqual(request.FormGN59.Id, workPermit.FormGN59.Id);
            Assert.AreEqual(request.GN7, workPermit.GN7);
            Assert.AreEqual(request.FormGN7.Id, workPermit.FormGN7.Id);
            Assert.AreEqual(request.GN6, workPermit.GN6);
            Assert.AreEqual(request.GN11, workPermit.GN11);
            Assert.AreEqual(request.GN24_Deprecated, workPermit.GN24_Deprecated);
            Assert.AreEqual(request.GN27, workPermit.GN27);
            Assert.AreEqual(request.GN75_Deprecated, workPermit.GN75_Deprecated);
            Assert.AreEqual(request.GN75A, workPermit.GN75A);

            Assert.AreEqual(request.DocumentLinks.Count, workPermit.DocumentLinks.Count);
            Assert.That(workPermit.DocumentLinks, Has.Some.Property("Title").EqualTo(request.DocumentLinks[0].Title));
            Assert.That(workPermit.DocumentLinks, Has.Some.Property("Title").EqualTo(request.DocumentLinks[1].Title));
            Assert.IsTrue(workPermit.DocumentLinks.TrueForAll(link => link.Id == null));
            Assert.IsTrue(request.DocumentLinks.TrueForAll(link => link.Id != null));

            Assert.AreEqual(request.WorkOrderNumber, workPermit.WorkOrderNumber);
            Assert.AreEqual(request.OperationNumberListAsString, workPermit.OperationNumber);
            Assert.AreEqual(request.SubOperationNumberListAsString, workPermit.SubOperationNumber);
            Assert.AreEqual(request.Description, workPermit.TaskDescription);
            Assert.AreEqual(request.HazardsAndOrRequirements, workPermit.HazardsAndOrRequirements);
            Assert.AreEqual(true, workPermit.OtherAreasAndOrUnitsAffected);
            Assert.AreEqual(request.OtherAreasAndOrUnitsAffectedArea, workPermit.OtherAreasAndOrUnitsAffectedArea);
            Assert.AreEqual(request.OtherAreasAndOrUnitsAffectedPersonNotified, workPermit.OtherAreasAndOrUnitsAffectedPersonNotified);

            Assert.AreEqual(request.FaceShield, workPermit.FaceShield);
            Assert.AreEqual(request.Goggles, workPermit.Goggles);
            Assert.AreEqual(request.RubberBoots, workPermit.RubberBoots);
            Assert.AreEqual(request.RubberGloves, workPermit.RubberGloves);
            Assert.AreEqual(request.RubberSuit, workPermit.RubberSuit);
            Assert.AreEqual(request.SafetyHarnessLifeline, workPermit.SafetyHarnessLifeline);
            Assert.AreEqual(request.HighVoltagePPE, workPermit.HighVoltagePPE);
            Assert.AreEqual(true, workPermit.Other1Checked);
            Assert.AreEqual(request.Other1, workPermit.Other1);

            Assert.AreEqual(request.EquipmentGrounded, workPermit.EquipmentGrounded);
            Assert.AreEqual(request.FireBlanket, workPermit.FireBlanket);
            Assert.AreEqual(request.FireExtinguisher, workPermit.FireExtinguisher);
            Assert.AreEqual(request.FireMonitorManned, workPermit.FireMonitorManned);
            Assert.AreEqual(request.FireWatch, workPermit.FireWatch);
            Assert.AreEqual(request.SewersDrainsCovered, workPermit.SewersDrainsCovered);
            Assert.AreEqual(request.SteamHose, workPermit.SteamHose);
            Assert.AreEqual(true, workPermit.Other2Checked);
            Assert.AreEqual(request.Other2, workPermit.Other2);

            Assert.AreEqual(request.AirPurifyingRespirator, workPermit.AirPurifyingRespirator);
            Assert.AreEqual(request.BreathingAirApparatus, workPermit.BreathingAirApparatus);
            Assert.AreEqual(request.DustMask, workPermit.DustMask);
            Assert.AreEqual(request.LifeSupportSystem, workPermit.LifeSupportSystem);
            Assert.AreEqual(request.SafetyWatch, workPermit.SafetyWatch);
            Assert.AreEqual(request.ContinuousGasMonitor, workPermit.ContinuousGasMonitor);
            Assert.AreEqual(request.WorkersMonitorNumber, workPermit.WorkersMonitorNumber);
            Assert.AreEqual(request.BumpTestMonitorPriorToUse, workPermit.BumpTestMonitorPriorToUse);
            Assert.AreEqual(true, workPermit.Other3Checked);
            Assert.AreEqual(request.Other3, workPermit.Other3);

            Assert.AreEqual(request.AirMover, workPermit.AirMover);
            Assert.AreEqual(request.BarriersSigns, workPermit.BarriersSigns);
            Assert.AreEqual(request.RadioChannelNumber, workPermit.RadioChannelNumber);
            Assert.AreEqual(request.AirHorn, workPermit.AirHorn);
            Assert.AreEqual(request.MechVentilationComfortOnly, workPermit.MechVentilationComfortOnly);
            Assert.AreEqual(request.AsbestosMMCPrecautions, workPermit.AsbestosMMCPrecautions);
            Assert.AreEqual(true, workPermit.Other4Checked);
            Assert.AreEqual(request.Other4, workPermit.Other4);
        }

        [Test]
        public void ShouldDetermineIfIsDay()
        {
            Assert.IsTrue(WorkPermitEdmonton.IsDayShift(new Time(6, 30)));
            Assert.IsTrue(WorkPermitEdmonton.IsDayShift(new Time(18, 29, 59)));

            Assert.IsFalse(WorkPermitEdmonton.IsDayShift(new Time(18, 30)));
            Assert.IsFalse(WorkPermitEdmonton.IsDayShift(new Time(6, 29, 59)));
        }

        [Test]
        public void PermitCreatedFromRequestShouldHaveARequestedStartDateTimeComprisedOfTheDateFromTheUserSpecifiedDateAndTheTimeFromThePermitStartDateTime()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), new WorkPermitEdmontonGroup(0, "Group", new List<long> { 0 }, 0, false));
            WorkPermitEdmonton workPermitEdmonton = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Date userSpecifiedDate = new Date(2012, 12, 2);
            DateTime permitStartDateTime = new DateTime(2012, 11, 29, 13, 0, 0);
            workPermitEdmonton.BuildPermitToSubmit(permitRequest, UserFixture.CreateUser(), Clock.Now, userSpecifiedDate, permitStartDateTime);

            Assert.AreEqual(userSpecifiedDate.CreateDateTime(permitStartDateTime.ToTime()), workPermitEdmonton.RequestedStartDateTime);
        }

        [Test]
        public void PermitCreatedFromRequestShouldSetTheSubOperationToNullIfThereIsNone()
        {
            PermitRequestEdmonton permitRequest = PermitRequestEdmontonFixture.CreateForInsert(DataSource.MANUAL, FunctionalLocationFixture.GetReal_ED1_A001_U007(), new WorkPermitEdmontonGroup(0, "Group", new List<long> { 0 }, 0, false));
            permitRequest.ClearWorkOrderSources();
            permitRequest.AddWorkOrderSource("123456", "1000", null);
            permitRequest.AddWorkOrderSource("123456", "1001", "");

            WorkPermitEdmonton workPermitEdmonton = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Date userSpecifiedDate = new Date(2012, 12, 2);
            DateTime permitStartDateTime = new DateTime(2012, 11, 29, 13, 0, 0);
            workPermitEdmonton.BuildPermitToSubmit(permitRequest, UserFixture.CreateUser(), Clock.Now, userSpecifiedDate, permitStartDateTime);

            Assert.IsNull(workPermitEdmonton.SubOperationNumber);
        }

        [Test]
        public void CloningShouldNotCopyOverCertainProperties()
        {
            DateTime someDateTime = new DateTime(2012, 11, 11);

            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            permit.Id = 1;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            permit.LastModifiedBy = UserFixture.CreateUser();
            
            permit.RequestedStartDateTime = someDateTime;
            permit.IssuedDateTime = someDateTime;
            permit.IssuedByUser = UserFixture.CreateUser();
            permit.ExpiredDateTime = someDateTime;
            permit.ConfinedSpace = true;
            permit.ConfinedSpaceCardNumber = "something";
            permit.SpecialWork = true;
            permit.SpecialWorkFormNumber = "something";
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            permit.UseCurrentPermitNumberForZeroEnergyFormNumber = true;

            permit.ConvertToClone(new DateTime(1999, 5, 1, 1, 1, 1));
            
            Assert.IsNull(permit.Id);
            Assert.AreEqual(DataSource.CLONE, permit.DataSource);
            Assert.AreEqual(PermitRequestBasedWorkPermitStatus.Complete, permit.WorkPermitStatus);
            Assert.IsNull(permit.LastModifiedBy);
            Assert.IsNull(permit.SubmittedByUser);
            Assert.AreNotEqual(someDateTime, permit.RequestedStartDateTime);
            Assert.IsNull(permit.IssuedDateTime);
            Assert.IsNull(permit.IssuedByUser);
            Assert.AreNotEqual(someDateTime, permit.ExpiredDateTime);
            Assert.IsTrue(permit.ConfinedSpace);
            Assert.IsNotNull(permit.ConfinedSpaceCardNumber);
            Assert.IsTrue(permit.SpecialWork);
            Assert.IsNotNull(permit.SpecialWorkFormNumber);
            Assert.IsEmpty(permit.DocumentLinks);
            Assert.IsFalse(permit.UseCurrentPermitNumberForZeroEnergyFormNumber);
        }

        [Test]
        public void CopyingShouldNotCopyTheUseCurrentPermitNumberForZeroEnergyNumberProperty()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.UseCurrentPermitNumberForZeroEnergyFormNumber = true;

            WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.IsFalse(nextDayPermit.UseCurrentPermitNumberForZeroEnergyFormNumber);
        }

        [Test]
        public void CopyingShouldNotCopyTheIssuedByProperties()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.IssuedDateTime = Clock.Now;
            permit.IssuedByUser = UserFixture.CreateUser();

            WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.IsNull(nextDayPermit.IssuedByUser);
            Assert.IsNull(nextDayPermit.IssuedDateTime);
        }

        [Test]
        public void CopyingShouldNotCopyTheWorkOrderNumberOrOpsNumberOrSubOpsNumber()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.WorkOrderNumber = "won from old permit";
            permit.OperationNumber = "opnum from old permit";
            permit.SubOperationNumber = "subopnum from old permit";

            WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            nextDayPermit.WorkOrderNumber = "won";
            nextDayPermit.OperationNumber = "opnum";
            nextDayPermit.SubOperationNumber = "subopnum";

            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.AreEqual("won", nextDayPermit.WorkOrderNumber);
            Assert.AreEqual("opnum", nextDayPermit.OperationNumber);
            Assert.AreEqual("subopnum", nextDayPermit.SubOperationNumber);
        }


        [Test]
        public void CopyingShouldCopyTheDocumentLinksButNullOutTheIds()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.DocumentLinks.Clear();
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink(1));
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink(2));

            WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

            Assert.AreEqual(2, nextDayPermit.DocumentLinks.Count);
            Assert.IsTrue(nextDayPermit.DocumentLinks.TrueForAll(link => link.Id == null));
        }

        [Test]
        public void CopyingShouldCopyForms_GN1ShouldBeCopiedIfMatchesRules()
        {
            // Everything's good, it should get copied
            {
                WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

                CreateFormGN1AndAssignToPermit(permit);                

                WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
                permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

                Assert.IsNotNull(nextDayPermit.FormGN1);
                Assert.AreEqual(permit.ConfinedSpaceCardNumber, nextDayPermit.ConfinedSpaceCardNumber);
                Assert.AreEqual(permit.RescuePlanFormNumber, nextDayPermit.RescuePlanFormNumber);
            }            

            // A deleted form doesn't get copied
            {
                WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

                CreateFormGN1AndAssignToPermit(permit);
                permit.FormGN1.IsDeleted = true; // so that it won't be included in the copy

                WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
                permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

                Assert.IsNull(nextDayPermit.FormGN1);                
                Assert.IsNull(nextDayPermit.ConfinedSpaceCardNumber);
                Assert.IsNull(nextDayPermit.RescuePlanFormNumber);
            }

            // A form with dates that 
            {
                WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

                CreateFormGN1AndAssignToPermit(permit);
                permit.FormGN1.FromDateTime = permit.RequestedStartDateTime.AddMinutes(5); // Makes sure that the permit isn't fully within the time bounds of the form

                WorkPermitEdmonton nextDayPermit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
                permit.CopyContentsIntoNextDayPermit(ref nextDayPermit);

                Assert.IsNull(nextDayPermit.FormGN1);                
            }
        }

        private static void CreateFormGN1AndAssignToPermit(WorkPermitEdmonton permit)
        {
            
            FormGN1 gn1 = FormGN1Fixture.CreateForInsert(permit.FunctionalLocation, permit.RequestedStartDateTime,
                                                         permit.ExpiredDateTime, FormStatus.Approved);
            gn1.Id = 42;       
            gn1.FromDateTime = permit.RequestedStartDateTime.AddMinutes(-5);
            gn1.ToDateTime = permit.ExpiredDateTime.AddMinutes(5);
            permit.FormGN1 = gn1;
            permit.ConfinedSpace = true;
            permit.ConfinedSpaceCardNumber = "C6778";
            permit.RescuePlan = true;
            permit.RescuePlanFormNumber = "R1234";            
        }


        [Test]
        public void CloneShouldKeepGN7andGN59andGN6andGN24andRescuePlanCheckedAndKeepPlanNumberWhenGN1NotSelected()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            permit.Id = 1;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            permit.LastModifiedBy = UserFixture.CreateUser();

            permit.GN59 = true;
            permit.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            permit.GN7 = true;
            permit.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            permit.GN6 = true;
            permit.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            permit.GN24 = true;
            permit.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            permit.RescuePlan = true;
            permit.RescuePlanFormNumber = "something";

            permit.GN1 = false;

            permit.ConvertToClone(new DateTime(1999, 5, 1, 1, 1, 1));

            Assert.IsTrue(permit.GN59);
            Assert.IsNull(permit.FormGN59);
            Assert.IsTrue(permit.GN7);
            Assert.IsNull(permit.FormGN7);
            Assert.IsTrue(permit.GN24);
            Assert.IsNull(permit.FormGN24);
            Assert.IsTrue(permit.GN6);
            Assert.IsNull(permit.FormGN6);
            Assert.IsTrue(permit.RescuePlan);
            Assert.IsNotNull(permit.RescuePlanFormNumber);
            Assert.IsFalse(permit.GN1);
            Assert.IsNull(permit.FormGN1);
        }

        [Test]
        public void CloneShouldKeepGN1andRescuePlanCheckedAndKeepPlanNumberWhenGN1NumberIsKept()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            permit.Id = 1;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            permit.LastModifiedBy = UserFixture.CreateUser();
            permit.RescuePlan = true;
            permit.RescuePlanFormNumber = "something";
            permit.GN1 = true;
            FormGN1 gn1 = FormGN1Fixture.CreateForInsert();
            gn1.Id = 10;
            gn1.FormStatus = FormStatus.Approved;
            gn1.FromDateTime = permit.RequestedStartDateTime;
            gn1.ToDateTime = permit.ExpiredDateTime;
            permit.FormGN1 = gn1;

            permit.ConvertToClone(permit.RequestedStartDateTime.AddMinutes(10));

            Assert.IsTrue(permit.GN1);
            Assert.IsNotNull(permit.FormGN1);

            Assert.IsTrue(permit.RescuePlan);
            Assert.IsNotNull(permit.RescuePlanFormNumber);
        }

        [Test]
        public void CloneShouldKeepGN1CheckedButNoNumberWhenGN1IsDeleted()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            permit.Id = 1;
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Complete;
            permit.LastModifiedBy = UserFixture.CreateUser();

            permit.GN59 = true;
            permit.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
            permit.GN7 = true;
            permit.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
            permit.GN6 = true;
            permit.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
            permit.GN24 = true;
            permit.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
            permit.RescuePlan = true;
            permit.RescuePlanFormNumber = "something";
            permit.GN1 = true;
            FormGN1 gn1 = FormGN1Fixture.CreateForInsert();
            gn1.Id = 10;
            gn1.IsDeleted = true;
            permit.FormGN1 = gn1;

            permit.ConvertToClone(new DateTime(1999, 5, 1, 1, 1, 1));

            Assert.IsTrue(permit.GN59);
            Assert.IsNull(permit.FormGN59);
            Assert.IsTrue(permit.GN7);
            Assert.IsNull(permit.FormGN7);
            Assert.IsTrue(permit.GN24);
            Assert.IsNull(permit.FormGN24);
            Assert.IsTrue(permit.GN6);
            Assert.IsNull(permit.FormGN6);
            
            Assert.IsTrue(permit.RescuePlan);
            Assert.IsNull(permit.RescuePlanFormNumber);
            Assert.IsTrue(permit.GN1);
            Assert.IsNull(permit.FormGN1);
        }

        [Test]
        public void CloneShouldDefinitelyNotOverwriteStatus()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            permit.WorkPermitStatus = PermitRequestBasedWorkPermitStatus.Requested;

            permit.ConvertToClone(new DateTime(1999, 5, 1, 1, 1, 1));

            Assert.AreEqual(PermitRequestBasedWorkPermitStatus.Requested, permit.WorkPermitStatus);
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnPermitFlocsAndNotMainFlocs()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Assert.IsTrue(permit.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string> { "ED1-A001" }, null, null));
            Assert.IsFalse(permit.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string> { "ED1-A002" }, null, null));
        }

        [Test]
        public void ShouldBeFunctionalLocationRelevantBasedOnMainFlocsIfThereAreNoPermitFlocs()
        {
            WorkPermitEdmonton permit = WorkPermitEdmontonFixture.CreateForInsert(FunctionalLocationFixture.GetReal_ED1_A001_U007());

            Assert.IsTrue(permit.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A001" }, new List<string>(), null, null));
            Assert.IsFalse(permit.IsRelevantTo(Site.EDMONTON_ID, new List<string> { "ED1-A002" }, new List<string>(), null, null));
        }
    }
}
