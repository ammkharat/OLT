using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Utilities
{
    [TestFixture]
    public class WorkPermitEdmontonMergeToolTest
    {
        private IFunctionalLocationService mockFlocService;

        [SetUp]
        public void Setup()
        {
            mockFlocService = MockRepository.GenerateStub<IFunctionalLocationService>();
        }

        [Test]
        public void ShouldKnowIfThereAreNoCommonFlocLevelsBelowLevel2()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal("ED1-A002-IFST");

            StubFlocService();

            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNotNull(mergedPermit);
                Assert.IsFalse(tool.HasIncompatibleFunctionalLocations);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc3);

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNull(mergedPermit);
                Assert.IsTrue(tool.HasIncompatibleFunctionalLocations);
            }
        }

        [Test]
        public void ShouldKnowWhichTypeOfWorkFieldsCannotBeMerged()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            StubFlocService();

            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.DurationPermit = true;
                permit1.AlkylationEntry = true;
                permit1.AlkylationEntryClassOfClothing = "heyo";
                permit1.FlarePitEntry = true;
                permit1.FlarePitEntryType = "fpetype";
                permit1.ConfinedSpace = true;
                permit1.ConfinedSpaceClass = "cls";
                permit1.ConfinedSpaceCardNumber = "c#";
                permit1.RescuePlan = true;
                permit1.RescuePlanFormNumber = "f#";
                permit1.VehicleEntry = true;
                permit1.VehicleEntryTotal = 2;
                permit1.VehicleEntryType = "hi";
                permit1.SpecialWork = true;
                permit1.SpecialWorkFormNumber = "fn";
                permit1.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.DurationPermit = true;
                permit2.AlkylationEntry = true;
                permit2.AlkylationEntryClassOfClothing = "heyo";
                permit2.FlarePitEntry = true;
                permit2.FlarePitEntryType = "fpetype";
                permit2.ConfinedSpace = true;
                permit2.ConfinedSpaceClass = "cls";
                permit2.ConfinedSpaceCardNumber = "c#";
                permit2.RescuePlan = true;
                permit2.RescuePlanFormNumber = "f#";
                permit2.VehicleEntry = true;
                permit2.VehicleEntryTotal = 2;
                permit2.VehicleEntryType = "hi";
                permit2.SpecialWork = true;
                permit2.SpecialWorkFormNumber = "fn";
                permit2.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

                WorkPermitEdmonton permit3 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit3.DurationPermit = false;
                permit3.AlkylationEntry = false;
                permit3.AlkylationEntryClassOfClothing = "heyo-no!";
                permit3.FlarePitEntry = false;
                permit3.FlarePitEntryType = "fpetype-bam!";
                permit3.ConfinedSpace = false;
                permit3.ConfinedSpaceClass = "cls2";
                permit3.ConfinedSpaceCardNumber = "c#2";
                permit3.RescuePlan = false;
                permit3.RescuePlanFormNumber = "f#2";
                permit3.VehicleEntry = false;
                permit3.VehicleEntryTotal = 5;
                permit3.VehicleEntryType = "hi2";
                permit3.SpecialWork = false;
                permit3.SpecialWorkFormNumber = "fn2";
                permit3.SpecialWorkType = EdmontonPermitSpecialWorkType.DivingOperations;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2, permit3 });
                Assert.IsNotNull(mergedPermit);
                Assert.IsTrue(tool.HasIncompatibleFields);

                List<string> expectedFieldNameList = new List<string>
                                                         {
                                                             "Duration Permit",
                                                             "Alkylation Entry",
                                                             "Class of Clothing (Alkylation Entry)",
                                                             "Flare Pit Entry",
                                                             "Type (Flare Pit Entry)",
                                                             "Confined Space",
                                                             "Class (Confined Space)",
                                                             "Card Number (Confined Space)",
                                                             "Rescue Plan",
                                                             "Form Number (Rescue Plan)",
                                                             "Vehicle Entry",
                                                             "Total (Vehicle Entry)",
                                                             "Type (Vehicle Entry)",
                                                             "Special Work",
                                                             "Form Number (Special Work)",
                                                             "Type (Special Work)"
                                                         };
                Assert.AreEqual(expectedFieldNameList.Join(", "), tool.IncompatibleFieldNames.Join(", "));

                Assert.IsFalse(mergedPermit.DurationPermit);
                Assert.IsFalse(mergedPermit.AlkylationEntry);
                Assert.IsNull(mergedPermit.AlkylationEntryClassOfClothing);
                Assert.IsFalse(mergedPermit.FlarePitEntry);
                Assert.IsNull(mergedPermit.FlarePitEntryType);
                Assert.IsFalse(mergedPermit.ConfinedSpace);
                Assert.IsNull(mergedPermit.ConfinedSpaceClass);
                Assert.IsNull(mergedPermit.ConfinedSpaceCardNumber);
                Assert.IsFalse(mergedPermit.RescuePlan);
                Assert.IsNull(mergedPermit.RescuePlanFormNumber);
                Assert.IsFalse(mergedPermit.VehicleEntry);
                Assert.IsNull(mergedPermit.VehicleEntryTotal);
                Assert.IsNull(mergedPermit.VehicleEntryType);
                Assert.IsFalse(mergedPermit.SpecialWork);
                Assert.IsNull(mergedPermit.SpecialWorkFormNumber);
                Assert.IsNull(mergedPermit.SpecialWorkType);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.DurationPermit = true;
                permit1.AlkylationEntry = true;
                permit1.AlkylationEntryClassOfClothing = "heyo";
                permit1.FlarePitEntry = true;
                permit1.FlarePitEntryType = "fpetype";
                permit1.ConfinedSpace = true;
                permit1.ConfinedSpaceClass = "cls";
                permit1.ConfinedSpaceCardNumber = "c#";
                permit1.RescuePlan = true;
                permit1.RescuePlanFormNumber = "f#";
                permit1.VehicleEntry = true;
                permit1.VehicleEntryTotal = 2;
                permit1.VehicleEntryType = "hi";
                permit1.SpecialWork = true;
                permit1.SpecialWorkFormNumber = "fn";
                permit1.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.DurationPermit = true;
                permit2.AlkylationEntry = true;
                permit2.AlkylationEntryClassOfClothing = "heyo";
                permit2.FlarePitEntry = true;
                permit2.FlarePitEntryType = "fpetype";
                permit2.ConfinedSpace = true;
                permit2.ConfinedSpaceClass = "cls";
                permit2.ConfinedSpaceCardNumber = "c#";
                permit2.RescuePlan = true;
                permit2.RescuePlanFormNumber = "f#";
                permit2.VehicleEntry = true;
                permit2.VehicleEntryTotal = 2;
                permit2.VehicleEntryType = "hi";
                permit2.SpecialWork = true;
                permit2.SpecialWorkFormNumber = "fn";
                permit2.SpecialWorkType = EdmontonPermitSpecialWorkType.Excavation;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNotNull(mergedPermit);
                Assert.IsFalse(tool.HasIncompatibleFields);
                Assert.IsEmpty(tool.IncompatibleFieldNames);

                Assert.IsTrue(mergedPermit.DurationPermit);
                Assert.IsTrue(mergedPermit.AlkylationEntry);
                Assert.AreEqual(permit1.AlkylationEntryClassOfClothing, mergedPermit.AlkylationEntryClassOfClothing);
                Assert.IsTrue(mergedPermit.FlarePitEntry);
                Assert.AreEqual(permit1.FlarePitEntryType, mergedPermit.FlarePitEntryType);
                Assert.IsTrue(mergedPermit.ConfinedSpace);
                Assert.AreEqual(permit1.ConfinedSpaceClass, mergedPermit.ConfinedSpaceClass);
                Assert.AreEqual(permit1.ConfinedSpaceCardNumber, mergedPermit.ConfinedSpaceCardNumber);
                Assert.IsTrue(mergedPermit.RescuePlan);
                Assert.AreEqual(permit1.RescuePlanFormNumber, mergedPermit.RescuePlanFormNumber);
                Assert.IsTrue(mergedPermit.VehicleEntry);
                Assert.AreEqual(permit1.VehicleEntryTotal, mergedPermit.VehicleEntryTotal);
                Assert.AreEqual(permit1.VehicleEntryType, mergedPermit.VehicleEntryType);
                Assert.IsTrue(mergedPermit.SpecialWork);
                Assert.AreEqual(permit1.SpecialWorkFormNumber, mergedPermit.SpecialWorkFormNumber);
                Assert.AreEqual(permit1.SpecialWorkType, mergedPermit.SpecialWorkType);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.DurationPermit = false;
                permit1.AlkylationEntry = false;
                permit1.AlkylationEntryClassOfClothing = null;
                permit1.FlarePitEntry = false;
                permit1.FlarePitEntryType = null;
                permit1.ConfinedSpace = false;
                permit1.ConfinedSpaceClass = null;
                permit1.ConfinedSpaceCardNumber = null;
                permit1.RescuePlan = false;
                permit1.RescuePlanFormNumber = null;
                permit1.VehicleEntry = false;
                permit1.VehicleEntryTotal = null;
                permit1.VehicleEntryType = null;
                permit1.SpecialWork = false;
                permit1.SpecialWorkFormNumber = null;
                permit1.SpecialWorkType = null;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.DurationPermit = false;
                permit2.AlkylationEntry = false;
                permit2.AlkylationEntryClassOfClothing = null;
                permit2.FlarePitEntry = false;
                permit2.FlarePitEntryType = null;
                permit2.ConfinedSpace = false;
                permit2.ConfinedSpaceClass = null;
                permit2.ConfinedSpaceCardNumber = null;
                permit2.RescuePlan = false;
                permit2.RescuePlanFormNumber = null;
                permit2.VehicleEntry = false;
                permit2.VehicleEntryTotal = null;
                permit2.VehicleEntryType = null;
                permit2.SpecialWork = false;
                permit2.SpecialWorkFormNumber = null;
                permit2.SpecialWorkType = null;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNotNull(mergedPermit);
                Assert.IsFalse(tool.HasIncompatibleFields);
                Assert.IsEmpty(tool.IncompatibleFieldNames);

                Assert.IsFalse(mergedPermit.DurationPermit);
                Assert.IsFalse(mergedPermit.AlkylationEntry);
                Assert.AreEqual(null, mergedPermit.AlkylationEntryClassOfClothing);
                Assert.IsFalse(mergedPermit.FlarePitEntry);
                Assert.AreEqual(null, mergedPermit.FlarePitEntryType);
                Assert.IsFalse(mergedPermit.ConfinedSpace);
                Assert.AreEqual(null, mergedPermit.ConfinedSpaceClass);
                Assert.AreEqual(null, mergedPermit.ConfinedSpaceCardNumber);
                Assert.IsFalse(mergedPermit.RescuePlan);
                Assert.AreEqual(null, mergedPermit.RescuePlanFormNumber);
                Assert.IsFalse(mergedPermit.VehicleEntry);
                Assert.AreEqual(null, mergedPermit.VehicleEntryTotal);
                Assert.AreEqual(null, mergedPermit.VehicleEntryType);
                Assert.IsFalse(mergedPermit.SpecialWork);
                Assert.AreEqual(null, mergedPermit.SpecialWorkFormNumber);
                Assert.AreEqual(null, mergedPermit.SpecialWorkType);
            }
        }

        [Test]
        public void ShouldMergeDescriptionsLikeAChamp()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.WorkOrderNumber = "555";
                permit1.TaskDescription = "Katie Cou, baby boo, you got swagger like a star.";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.WorkOrderNumber = null;
                permit2.TaskDescription = "Don't stop, we'll talk, keep on taking it to the top.";                

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNotNull(mergedPermit);

                string expectedDescription =
                    string.Format("-> WO#555 ED1-A001-U007: Katie Cou, baby boo, you got swagger like a star.{0}-> ED1-A001-U008: Don't stop, we'll talk, keep on taking it to the top.", Environment.NewLine);
                Assert.AreEqual(expectedDescription, mergedPermit.TaskDescription);
            }
        }

        [Test]
        public void ShouldMergeHazards()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.HazardsAndOrRequirements = "You can be Lady Gaga, I can be T-Pain.";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.HazardsAndOrRequirements = null;   // possible if the permit came from a permit request

                WorkPermitEdmonton permit3 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit3.HazardsAndOrRequirements = "Bringing on the boogie.";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2, permit3 });
                Assert.IsNotNull(mergedPermit);

                string expected =
                    string.Format("You can be Lady Gaga, I can be T-Pain.{0}Bringing on the boogie.", System.Environment.NewLine);
                Assert.AreEqual(expected, mergedPermit.HazardsAndOrRequirements);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.HazardsAndOrRequirements = null;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.HazardsAndOrRequirements = null;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });
                Assert.IsNotNull(mergedPermit);

                string expected = string.Empty;
                Assert.AreEqual(expected, mergedPermit.HazardsAndOrRequirements);
            }
        }

        [Test]
        public void ShouldMergeHazardsButNotDuplicateIdenticalLines()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.HazardsAndOrRequirements = "arse";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.HazardsAndOrRequirements = null;   // possible if the permit came from a permit request

                WorkPermitEdmonton permit3 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit3.HazardsAndOrRequirements = "arse";

                WorkPermitEdmonton permit4 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit4.HazardsAndOrRequirements = "fanny";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2, permit3, permit4 });
                Assert.IsNotNull(mergedPermit);

                string expected = string.Format("arse{0}fanny", System.Environment.NewLine);
                Assert.AreEqual(expected, mergedPermit.HazardsAndOrRequirements);
            }
        }

        [Test]
        public void ShouldNotBringOverGn59OrGn7OrGn24orGn6FormNumbers()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.GN6 = true;
                permit1.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
                permit1.GN7 = true;
                permit1.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
                permit1.GN59 = true;
                permit1.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
                permit1.GN24 = true;
                permit1.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.GN6 = true;
                permit2.FormGN6 = FormGN6Fixture.CreateFormWithExistingId();
                permit2.GN7 = true;
                permit2.FormGN7 = FormGN7Fixture.CreateFormWithExistingId();
                permit2.GN59 = true;
                permit2.FormGN59 = FormGN59Fixture.CreateFormWithExistingId();
                permit2.GN24 = true;
                permit2.FormGN24 = FormGN24Fixture.CreateFormWithExistingId();
                
                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.GN6);
                Assert.IsNull(mergedPermit.FormGN6);
                Assert.IsTrue(mergedPermit.GN7);
                Assert.IsNull(mergedPermit.FormGN7);
                Assert.IsTrue(mergedPermit.GN59);
                Assert.IsNull(mergedPermit.FormGN59);
                Assert.IsTrue(mergedPermit.GN24);
                Assert.IsNull(mergedPermit.FormGN24);
            }
        }

        [Test]
        public void ShouldCheckGn7andGn59AndGn24AndGn7BoxesIfAtLeastOnePermitHasThemChecked()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.GN6 = true;
                permit1.GN7 = true;
                permit1.GN59 = false;
                permit1.GN24 = true;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.GN6 = false;
                permit2.GN7 = false;
                permit2.GN59 = false;
                permit2.GN24 = false;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.GN6);
                Assert.IsTrue(mergedPermit.GN7);
                Assert.IsFalse(mergedPermit.GN59);
                Assert.IsTrue(mergedPermit.GN24);
            }
        }

        [Test]
        public void ShouldLeaveTheOperationNumbersRegionEmptyNoMatterWhat()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.WorkOrderNumber = "1";
                permit1.OperationNumber = "1";
                permit1.SubOperationNumber = "1";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.WorkOrderNumber = permit1.WorkOrderNumber;
                permit2.OperationNumber = permit1.OperationNumber;
                permit2.SubOperationNumber = permit1.SubOperationNumber;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsNull(mergedPermit.WorkOrderNumber);
                Assert.IsNull(mergedPermit.OperationNumber);
                Assert.IsNull(mergedPermit.SubOperationNumber);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.WorkOrderNumber = "1";
                permit1.OperationNumber = "1";
                permit1.SubOperationNumber = "1";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.WorkOrderNumber = "2";
                permit2.OperationNumber = "2";
                permit2.SubOperationNumber = "2";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsNull(mergedPermit.WorkOrderNumber);
                Assert.IsNull(mergedPermit.OperationNumber);
                Assert.IsNull(mergedPermit.SubOperationNumber);
            }
        }

        [Test]
        public void ShouldHandleMergingOfIssuedToSection()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.IssuedToSuncor = true;
                permit1.IssuedToCompany = true;
                permit1.Company = "heyo";
                permit1.Occupation = "occ";
                permit1.NumberOfWorkers = 1;
                permit1.Group = WorkPermitEdmontonGroupFixture.CreateForInsert(1, "heyo");

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.IssuedToSuncor = false;
                permit2.IssuedToCompany = false;
                permit2.Company = permit1.Company;
                permit2.Occupation = permit1.Occupation;
                permit2.NumberOfWorkers = permit1.NumberOfWorkers;
                permit2.Group = WorkPermitEdmontonGroupFixture.CreateForInsert(1, "heyo");  // making a second one w/ same id on purpose to make sure equality isn't just reference equality

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.IssuedToSuncor);
                Assert.IsTrue(mergedPermit.IssuedToCompany);
                Assert.AreEqual(permit1.Company, mergedPermit.Company);
                Assert.AreEqual(permit1.Occupation, mergedPermit.Occupation);
                Assert.AreEqual(permit1.NumberOfWorkers, mergedPermit.NumberOfWorkers);
                Assert.AreEqual(permit1.Group, mergedPermit.Group);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.IssuedToSuncor = false;
                permit1.IssuedToCompany = false;
                permit1.Company = "heyo";
                permit1.Occupation = "occ";
                permit1.NumberOfWorkers = 1;
                permit1.Group = WorkPermitEdmontonGroupFixture.CreateForInsert(1, "Grp1");

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.IssuedToSuncor = false;
                permit2.IssuedToCompany = false;
                permit2.Company = "heyoTWO";
                permit2.Occupation = "occTWO";
                permit1.NumberOfWorkers = 2;
                permit2.Group = WorkPermitEdmontonGroupFixture.CreateForInsert(2, "Grp2");

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsFalse(mergedPermit.IssuedToSuncor);
                Assert.IsFalse(mergedPermit.IssuedToCompany);
                Assert.IsNull(mergedPermit.Company);
                Assert.IsNull(mergedPermit.Occupation);
                Assert.IsNull(mergedPermit.NumberOfWorkers);
                Assert.IsNull(mergedPermit.Group);
            }
        }
         
        [Test]
        public void ShouldHandleMergingOfAreaLabel()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.AreaLabel = new AreaLabel(1, "AL", 8, 1, true, null);

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.AreaLabel = new AreaLabel(2, "AL2", 8, 2, true, null);

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsNull(mergedPermit.AreaLabel);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.AreaLabel = new AreaLabel(1, "AL", 8, 1, true, null);

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.AreaLabel = null;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsNull(mergedPermit.AreaLabel);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.AreaLabel = new AreaLabel(1, "AL", 8, 1, true, null);

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.AreaLabel = new AreaLabel(1, "AL", 8, 1, true, null);   // I'm purposely making a new instance of the same area label to make sure we're not relying on reference equality

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.AreEqual(new AreaLabel(1, "AL", 8, 1, true, null), mergedPermit.AreaLabel);
            }
        }

        [Test]
        public void ShouldHandleMergingOfOtherAreasSection()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.OtherAreasAndOrUnitsAffected = true;
                permit1.OtherAreasAndOrUnitsAffectedArea = "area";
                permit1.OtherAreasAndOrUnitsAffectedPersonNotified = "person";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.OtherAreasAndOrUnitsAffected = true;
                permit2.OtherAreasAndOrUnitsAffectedArea = "area";
                permit2.OtherAreasAndOrUnitsAffectedPersonNotified = "person";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.OtherAreasAndOrUnitsAffected);
                Assert.AreEqual(permit1.OtherAreasAndOrUnitsAffectedArea, mergedPermit.OtherAreasAndOrUnitsAffectedArea);
                Assert.AreEqual(permit1.OtherAreasAndOrUnitsAffectedPersonNotified, mergedPermit.OtherAreasAndOrUnitsAffectedPersonNotified);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.OtherAreasAndOrUnitsAffected = true;
                permit1.OtherAreasAndOrUnitsAffectedArea = "area";
                permit1.OtherAreasAndOrUnitsAffectedPersonNotified = "person";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.OtherAreasAndOrUnitsAffected = false;
                permit2.OtherAreasAndOrUnitsAffectedArea = "areachg";
                permit2.OtherAreasAndOrUnitsAffectedPersonNotified = "personchg";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.OtherAreasAndOrUnitsAffected);
                Assert.IsNull(mergedPermit.OtherAreasAndOrUnitsAffectedArea);
                Assert.IsNull(mergedPermit.OtherAreasAndOrUnitsAffectedPersonNotified);
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.OtherAreasAndOrUnitsAffected = false;
                permit1.OtherAreasAndOrUnitsAffectedArea = null;
                permit1.OtherAreasAndOrUnitsAffectedPersonNotified = null;

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.OtherAreasAndOrUnitsAffected = false;
                permit2.OtherAreasAndOrUnitsAffectedArea = null;
                permit2.OtherAreasAndOrUnitsAffectedPersonNotified = null;

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsFalse(mergedPermit.OtherAreasAndOrUnitsAffected);
                Assert.IsNull(mergedPermit.OtherAreasAndOrUnitsAffectedArea);
                Assert.IsNull(mergedPermit.OtherAreasAndOrUnitsAffectedPersonNotified);
            }
        }

        [Test]
        public void ShouldSetFormValuesToApprovedIfTheyAreApprovedOnAnyPermitOtherwiseLeaveThemAsNA()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_ED1_A001_U008();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.GN11 = WorkPermitSafetyFormState.NotApplicable;
                permit1.GN27 = WorkPermitSafetyFormState.NotApplicable;
                
                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.GN11 = WorkPermitSafetyFormState.Approved;
                permit2.GN27 = WorkPermitSafetyFormState.Approved;                

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.AreEqual(WorkPermitSafetyFormState.Approved, mergedPermit.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.Approved, mergedPermit.GN27);                
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.GN11 = WorkPermitSafetyFormState.NotApplicable;
                permit1.GN27 = WorkPermitSafetyFormState.NotApplicable;                

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.GN11 = WorkPermitSafetyFormState.NotApplicable;
                permit2.GN27 = WorkPermitSafetyFormState.NotApplicable;                

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergedPermit.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergedPermit.GN27);                
            }

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.GN11 = WorkPermitSafetyFormState.NotApplicable;
                permit1.GN27 = WorkPermitSafetyFormState.Approved;                

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc2);
                permit2.GN11 = WorkPermitSafetyFormState.NotApplicable;
                permit2.GN27 = WorkPermitSafetyFormState.Approved;                

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergedPermit.GN11);
                Assert.AreEqual(WorkPermitSafetyFormState.Approved, mergedPermit.GN27);                
            }
        }

        [Test]
        public void ShouldCheckMinimumSafetyRequirementsCheckboxesWhenAtLeastOnePermitChecksThemAndTextboxesWhenAllPermitsHaveTheSameValueInThem()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            WorkPermitEdmontonMergeTool tool = new WorkPermitEdmontonMergeTool(mockFlocService, null);

            StubFlocService();

            {
                WorkPermitEdmonton permit1 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit1.FaceShield = true;
                permit1.Goggles = false;
                permit1.RubberBoots = true;
                permit1.RubberGloves = true;
                permit1.RubberSuit = true;
                permit1.SafetyHarnessLifeline = true;
                permit1.HighVoltagePPE = true;
                permit1.Other1Checked = true;
                permit1.Other1 = "other1";
                
                permit1.EquipmentGrounded = true;
                permit1.FireBlanket = true;
                permit1.FireExtinguisher = true;
                permit1.FireMonitorManned = true;
                permit1.FireWatch = true;
                permit1.SewersDrainsCovered = true;
                permit1.SteamHose = true;
                permit1.Other2Checked = true;
                permit1.Other2 = "other2";

                permit1.AirPurifyingRespirator = true;
                permit1.BreathingAirApparatus = true;
                permit1.DustMask = true;
                permit1.LifeSupportSystem = true;
                permit1.SafetyWatch = true;
                permit1.ContinuousGasMonitor = true;
                permit1.WorkersMonitor = true;
                permit1.WorkersMonitorNumber = "10";
                permit1.BumpTestMonitorPriorToUse = true;
                permit1.Other3Checked = true;
                permit1.Other3 = "other3";

                permit1.AirMover = true;
                permit1.BarriersSigns = true;
                permit1.RadioChannel = true;
                permit1.RadioChannelNumber = "33";
                permit1.AirHorn = true;
                permit1.MechVentilationComfortOnly = true;
                permit1.AsbestosMMCPrecautions = true;
                permit1.Other4Checked = true;
                permit1.Other4 = "other4";

                WorkPermitEdmonton permit2 = WorkPermitEdmontonFixture.CreateForInsert(floc1);
                permit2.FaceShield = false;  // example of one where one is true and one is false
                permit2.Goggles = false;  // example of one where both are false
                permit2.RubberBoots = true;  // example of one where both are true
                permit2.RubberGloves = false;
                permit2.RubberSuit = false;
                permit2.SafetyHarnessLifeline = false;
                permit2.HighVoltagePPE = false;
                permit2.Other1Checked = false;
                permit2.Other1 = "other1";

                permit2.EquipmentGrounded = false;
                permit2.FireBlanket = false;
                permit2.FireExtinguisher = false;
                permit2.FireMonitorManned = false;
                permit2.FireWatch = false;
                permit2.SewersDrainsCovered = false;
                permit2.SteamHose = false;
                permit2.Other2Checked = false;
                permit2.Other2 = "other2";

                permit2.AirPurifyingRespirator = false;
                permit2.BreathingAirApparatus = false;
                permit2.DustMask = false;
                permit2.LifeSupportSystem = false;
                permit2.SafetyWatch = false;
                permit2.ContinuousGasMonitor = false;
                permit2.WorkersMonitor = false;
                permit2.WorkersMonitorNumber = "10";   // example of text field where both values are the same
                permit2.BumpTestMonitorPriorToUse = false;
                permit2.Other3Checked = false;
                permit2.Other3 = "other3";

                permit2.AirMover = true;   
                permit2.BarriersSigns = true;
                permit2.RadioChannel = true;
                permit2.RadioChannelNumber = "66";  // example of text field where values are different
                permit2.AirHorn = true;
                permit2.MechVentilationComfortOnly = true;
                permit2.AsbestosMMCPrecautions = true;
                permit2.Other4Checked = true;
                permit2.Other4 = "other4";

                WorkPermitEdmonton mergedPermit = tool.Merge(new List<WorkPermitEdmonton> { permit1, permit2 });

                Assert.IsTrue(mergedPermit.FaceShield);
                Assert.IsFalse(mergedPermit.Goggles);
                Assert.IsTrue(mergedPermit.RubberBoots);
                Assert.IsTrue(mergedPermit.RubberGloves);
                Assert.IsTrue(mergedPermit.RubberSuit);
                Assert.IsTrue(mergedPermit.SafetyHarnessLifeline);
                Assert.IsTrue(mergedPermit.HighVoltagePPE);
                Assert.IsTrue(mergedPermit.Other1Checked);
                Assert.AreEqual(permit2.Other1, mergedPermit.Other1);

                Assert.IsTrue(mergedPermit.EquipmentGrounded);
                Assert.IsTrue(mergedPermit.FireBlanket);
                Assert.IsTrue(mergedPermit.FireExtinguisher);
                Assert.IsTrue(mergedPermit.FireMonitorManned);
                Assert.IsTrue(mergedPermit.FireWatch);
                Assert.IsTrue(mergedPermit.SewersDrainsCovered);
                Assert.IsTrue(mergedPermit.SteamHose);
                Assert.IsTrue(mergedPermit.Other2Checked);
                Assert.AreEqual(permit2.Other2, mergedPermit.Other2);

                Assert.IsTrue(mergedPermit.AirPurifyingRespirator);
                Assert.IsTrue(mergedPermit.BreathingAirApparatus);
                Assert.IsTrue(mergedPermit.DustMask);
                Assert.IsTrue(mergedPermit.LifeSupportSystem);
                Assert.IsTrue(mergedPermit.SafetyWatch);
                Assert.IsTrue(mergedPermit.ContinuousGasMonitor);
                Assert.IsTrue(mergedPermit.WorkersMonitor);
                Assert.AreEqual(permit2.WorkersMonitorNumber, mergedPermit.WorkersMonitorNumber);
                Assert.IsTrue(mergedPermit.BumpTestMonitorPriorToUse);
                Assert.IsTrue(mergedPermit.Other3Checked);
                Assert.AreEqual(permit2.Other3, mergedPermit.Other3);

                Assert.IsTrue(mergedPermit.AirMover);
                Assert.IsTrue(mergedPermit.BarriersSigns);
                Assert.IsTrue(mergedPermit.RadioChannel);
                Assert.IsNull(mergedPermit.RadioChannelNumber);
                Assert.IsTrue(mergedPermit.AirHorn);
                Assert.IsTrue(mergedPermit.MechVentilationComfortOnly);
                Assert.IsTrue(mergedPermit.AsbestosMMCPrecautions);
                Assert.IsTrue(mergedPermit.Other4Checked);
                Assert.AreEqual(permit2.Other4, mergedPermit.Other4);
            }
        }

        private void StubFlocService()
        {
            mockFlocService.Stub(m => m.QueryByFullHierarchy(Arg<string>.Is.Anything, Arg<long>.Is.Anything)).Return(FunctionalLocationFixture.GetReal_ED1_A001_U007());
        }

    }
}
