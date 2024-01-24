using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NMock2.Monitoring;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    // NOTE: there are tests in the WorkOrderAdapterTest that should probably be here.
    [TestFixture]
    public class WorkPermitWorkAssignmentDeterminatorTest
    {
        private readonly Mockery mocks = new Mockery();

        private readonly Site sarniaSite = SiteFixture.Sarnia();
        private IFunctionalLocationService mockFunctionalLocationService;

        [SetUp]
        public void SetUp()
        {
            mockFunctionalLocationService = mocks.NewMock<IFunctionalLocationService>();
        }

        [Test]
        public void ShouldKnowIfAFLOCFallsWithinAWorkAssignment_exactMatch()
        {
            var floc1 = FunctionalLocationFixture.CreateNew(1, "SR1-A-B-C-D");
            var floc2 = FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-E");

            var assignment1 =
                WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
            assignment1.FunctionalLocations.Clear();
            assignment1.FunctionalLocations.Add(floc1);


            var configuration1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    new List<FunctionalLocation> {floc1});

            var configuration2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {floc2});

            var allWorkAssignmentsForSite = new List<AssignmentFlocConfiguration> {configuration1, configuration2};

            var determinator = new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite,
                mockFunctionalLocationService);

            var isWithinAssignment = determinator.IsFunctionalLocationOrParentWithinWorkAssignment(assignment1, floc1);

            Assert.IsTrue(isWithinAssignment);
        }

        [Test]
        public void ShouldMatchExactWorkAssignments()
        {
            var floc1 = FunctionalLocationFixture.CreateNew(1, "SR1-A-B-C-D");
            var floc2 = FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-E");

            var asg1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    new List<FunctionalLocation> {floc1});

            var asg2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {floc2});

            var allWorkAssignmentsForSite =
                new List<AssignmentFlocConfiguration> {asg1, asg2};

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(floc1);

            Assert.AreEqual(asg1, resultingWorkAssignment);
        }

        [Test]
        public void ShouldReturnHigherFlocIfThereIsNoLowerMatch()
        {
            var workPermitFloc = FunctionalLocationFixture.CreateNew(4, "SR1-A-B-C-F");
            var floc1 = FunctionalLocationFixture.CreateNew(1, "SR1-A-B-C-D");
            var floc2 = FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-E");
            var floc3 = FunctionalLocationFixture.CreateNew(3, "SR1-A-B-C");

            var asg1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    new List<FunctionalLocation> {floc1});

            var asg2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {floc2, floc3});

            var allWorkAssignmentsForSite =
                new List<AssignmentFlocConfiguration> {asg1, asg2};

            Expect.Once.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                "SR1-A-B-C", sarniaSite.IdValue).Will(Return.Value(floc3));

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(workPermitFloc);

            Assert.AreEqual(asg2, resultingWorkAssignment);
        }

        [Test]
        public void ShouldReturnHighestFlocIfThereIsNoLowerMatchAndItGoesThatFar()
        {
            var workPermitFloc = FunctionalLocationFixture.CreateNew(1, "SR1-Z-B-C-F");

            var hierarchyToFlocMap = new Dictionary<string, FunctionalLocation>();

            // This map is for the test. It's to help fake out the QueryByFullHierarchy call on the service
            hierarchyToFlocMap.Add("SR1-A-B-C-F", FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-F"));
            hierarchyToFlocMap.Add("SR1-A-B-C-D", FunctionalLocationFixture.CreateNew(3, "SR1-A-B-C-D"));
            hierarchyToFlocMap.Add("SR1-A-B-C-E", FunctionalLocationFixture.CreateNew(4, "SR1-A-B-C-E"));
            hierarchyToFlocMap.Add("SR1-A-B-C", FunctionalLocationFixture.CreateNew(5, "SR1-A-B-C"));
            hierarchyToFlocMap.Add("SR1-A-B", FunctionalLocationFixture.CreateNew(6, "SR1-A-B"));
            hierarchyToFlocMap.Add("SR1-A", FunctionalLocationFixture.CreateNew(7, "SR1-A"));
            hierarchyToFlocMap.Add("SR1", FunctionalLocationFixture.CreateNew(8, "SR1"));
            hierarchyToFlocMap.Add("SR1-Z-B-C-F", FunctionalLocationFixture.CreateNew(9, "SR1-Z-B-C-F"));
            hierarchyToFlocMap.Add("SR1-Z-B-C", FunctionalLocationFixture.CreateNew(10, "SR1-Z-B-C"));
            hierarchyToFlocMap.Add("SR1-Z-B", FunctionalLocationFixture.CreateNew(11, "SR1-Z-B"));
            hierarchyToFlocMap.Add("SR1-Z", FunctionalLocationFixture.CreateNew(12, "SR1-Z"));

            var functionalLocationAction = new GetFunctionalLocationAction(hierarchyToFlocMap);

            var flocListForAsg1 = new List<FunctionalLocation>
            {
                hierarchyToFlocMap["SR1-A-B-C-D"],
                hierarchyToFlocMap["SR1-A-B-C"],
                hierarchyToFlocMap["SR1-A-B"],
                hierarchyToFlocMap["SR1-A"],
                hierarchyToFlocMap["SR1"]
            };

            var asg1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    flocListForAsg1);

            var asg2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {hierarchyToFlocMap["SR1-A-B-C-E"]});

            var allWorkAssignmentsForSite =
                new List<AssignmentFlocConfiguration> {asg1, asg2};

            Expect.AtLeastOnce.On(
                mockFunctionalLocationService)
                .Method("QueryByFullHierarchy")
                .WithAnyArguments()
                .Will(functionalLocationAction);

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(workPermitFloc);

            Assert.AreEqual(asg1, resultingWorkAssignment);
        }

        [Test]
        public void ShouldReturnNullIfMultipleAssignmentsAreFoundForHigherFLOC()
        {
            var workPermitFloc = FunctionalLocationFixture.CreateNew(4, "SR1-A-B-C-F");
            var floc1 = FunctionalLocationFixture.CreateNew(1, "SR1-A-B-C-D");
            var floc2 = FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-E");
            var floc3 = FunctionalLocationFixture.CreateNew(3, "SR1-A-B-C");


            var asg1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    new List<FunctionalLocation> {floc1, floc3});

            var asg2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {floc2, floc3});

            var allWorkAssignmentsForSite =
                new List<AssignmentFlocConfiguration> {asg1, asg2};

            Expect.Once.On(mockFunctionalLocationService).Method("QueryByFullHierarchy").With(
                "SR1-A-B-C", sarniaSite.IdValue).Will(Return.Value(floc3));

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(workPermitFloc);

            Assert.IsNull(resultingWorkAssignment);
        }

        [Test]
        public void ShouldReturnNullIfMultipleMatch()
        {
            var floc1 = FunctionalLocationFixture.CreateNew(1, "SR1-A-B-C-D");
            var floc2 = FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-E");

            var asg1 =
                WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
                    new List<FunctionalLocation> {floc1});

            var asg2 =
                WorkPermitAutoAssignmentConfigurationFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData
                    (
                        new List<FunctionalLocation> {floc1, floc2});

            var allWorkAssignmentsForSite =
                new List<AssignmentFlocConfiguration> {asg1, asg2};

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(floc1);

            Assert.IsNull(resultingWorkAssignment);
        }

        [Test]
        public void ShouldWorkWithNoWorkAssignmentFoundForADivision()
        {
            var workPermitFloc = FunctionalLocationFixture.CreateNew(4, "SR1");

            var allWorkAssignmentsForSite = new List<AssignmentFlocConfiguration>();

            var determinator =
                new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForSite, mockFunctionalLocationService);

            var resultingWorkAssignment = determinator.GetWorkAssignment(workPermitFloc);

            Assert.IsNull(resultingWorkAssignment);
        }

        //[Test]
        //public void ShouldKnowIfAFLOCFallsWithinAWorkAssignment_flocNotFoundOnSameLevelButDifferentTree()
        //{
        //    FunctionalLocation workPermitFloc = FunctionalLocationFixture.CreateNew(1, "SR1-Z-B-C-F");

        //    Dictionary<string, FunctionalLocation> hierarchyToFlocMap = new Dictionary<string, FunctionalLocation>();

        //    // This map is for the test. It's to help fake out the QueryByFullHierarchy call on the service
        //    hierarchyToFlocMap.Add("SR1-A-B-C-F", FunctionalLocationFixture.CreateNew(2, "SR1-A-B-C-F"));
        //    hierarchyToFlocMap.Add("SR1-A-B-C-D", FunctionalLocationFixture.CreateNew(3, "SR1-A-B-C-D"));
        //    hierarchyToFlocMap.Add("SR1-A-B-C-E", FunctionalLocationFixture.CreateNew(4, "SR1-A-B-C-E"));
        //    hierarchyToFlocMap.Add("SR1-A-B-C", FunctionalLocationFixture.CreateNew(5, "SR1-A-B-C"));
        //    hierarchyToFlocMap.Add("SR1-A-B", FunctionalLocationFixture.CreateNew(6, "SR1-A-B"));
        //    hierarchyToFlocMap.Add("SR1-A", FunctionalLocationFixture.CreateNew(7, "SR1-A"));
        //    hierarchyToFlocMap.Add("SR1", FunctionalLocationFixture.CreateNew(8, "SR1"));
        //    hierarchyToFlocMap.Add("SR1-A-F-G-H", FunctionalLocationFixture.CreateNew(9, "SR1-A-F-G-H"));
        //    hierarchyToFlocMap.Add("SR1-A-F-G", FunctionalLocationFixture.CreateNew(10, "SR1-A-F-G"));
        //    hierarchyToFlocMap.Add("SR1-A-F", FunctionalLocationFixture.CreateNew(11, "SR1-A-F"));

        //    GetFunctionalLocationAction functionalLocationAction = new GetFunctionalLocationAction(hierarchyToFlocMap);

        //    WorkPermitAutoAssignmentConfiguration asg1 = 
        //        WorkPermitAutoAssignmentConfigurationFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(
        //            new List<FunctionalLocation> { hierarchyToFlocMap["SR1-A-B-C-D"] });            

        //    //WorkAssignment asg2 = WorkAssignmentFixture.GetAnotherSarniaAssignmentThatIsReallyInTheDatabaseTestData();
        //    //asg2.FunctionalLocations = new List<FunctionalLocation> { hierarchyToFlocMap["SR1-A-B-C-E"] };

        //    List<WorkPermitAutoAssignmentConfiguration> allWorkAssignmentsForUser = new List<WorkPermitAutoAssignmentConfiguration> { asg1 };

        //    Expect.AtLeastOnce.On(
        //        mockFunctionalLocationService).Method("QueryByFullHierarchy").WithAnyArguments().Will(functionalLocationAction);

        //    WorkPermitWorkAssignmentDeterminator determinator =
        //        new WorkPermitWorkAssignmentDeterminator(allWorkAssignmentsForUser, mockFunctionalLocationService);

        //    {
        //        // From story #864:
        //        // Show warning: User logs in under FLOC A-B-C & A-F-G, Work Assignment 1 is on FLOCs A-B-C-D, 
        //        // User selects FLOC A-F-G-H & Work Assignment 1

        //        bool isWithinWorkAssignment =
        //            determinator.IsFunctionalLocationOrParentWithinWorkAssignment(asg1, hierarchyToFlocMap["SR1-A-F-G-H"]);
        //        Assert.IsFalse(isWithinWorkAssignment);
        //    }

        //    {
        //        // From story #864:
        //        // No warning: User logs in under FLOC A-B-C & A-F-G, Work Assignment 1 is on FLOCs A-B-C-D, 
        //        // User selects FLOC A-B-C-D-E & Work Assignment 1

        //        asg1.FunctionalLocations = new List<FunctionalLocation>
        //                                   {
        //                                       hierarchyToFlocMap["SR1-A-B-C"]                                               
        //                                   };

        //        bool isWithinWorkAssignment =
        //            determinator.IsFunctionalLocationOrParentWithinWorkAssignment(asg1, hierarchyToFlocMap["SR1-A-B-C-D"]);
        //        Assert.IsTrue(isWithinWorkAssignment);
        //    }

        //    {
        //        // This is an interesting case. SR1-A-B doesn't fall under the Work Assignment with FLOC SR1-A-B-C because 
        //        // it's above it. We decided to warn in this case but we aren't entirely sure.
        //        asg1.FunctionalLocations = new List<FunctionalLocation>
        //                                   {
        //                                       hierarchyToFlocMap["SR1-A-B-C"]                                               
        //                                   };

        //        bool isWithinWorkAssignment =
        //            determinator.IsFunctionalLocationOrParentWithinWorkAssignment(asg1, hierarchyToFlocMap["SR1-A-B"]);
        //        Assert.IsFalse(isWithinWorkAssignment);
        //    }

        //}


        private class GetFunctionalLocationAction : IAction
        {
            private readonly Dictionary<string, FunctionalLocation> hierarchyToFlocMap;

            public GetFunctionalLocationAction(Dictionary<string, FunctionalLocation> hierarchyToFlocMap)
            {
                this.hierarchyToFlocMap = hierarchyToFlocMap;
            }

            public void Invoke(Invocation invocation)
            {
                var hierarchy = (string) invocation.Parameters[0];
                invocation.Result = hierarchyToFlocMap[hierarchy];
            }

            public void DescribeTo(TextWriter writer)
            {
                writer.Write("returns a functional location for the given hierarchy");
            }
        }
    }
}