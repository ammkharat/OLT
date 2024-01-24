using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class PermitRequestLubesMergeToolTest
    {
        [Ignore] [Test]
        public void ShouldMergeDescriptions()
        {                        
            PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "0110", "0001");
            PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "0220", "0002");

            List<WorkOrderImportData> workOrderImportDataList = GetWorkOrderDataList();

            Assert.IsTrue(pr1.ContainsWorkOrderSource(workOrderImportDataList[0]));
            Assert.IsTrue(pr2.ContainsWorkOrderSource(workOrderImportDataList[1]));

            PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(workOrderImportDataList);

            PermitRequestLubes mergeOutput = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2 });

            string description = mergeOutput.Description;

            StringReader stringReader = new StringReader(description);
            string line1 = stringReader.ReadLine();
            Assert.AreEqual("This is header text", line1);

            string line2 = stringReader.ReadLine();
            Assert.AreEqual("This is op line text 1", line2);

            string line3 = stringReader.ReadLine();
            Assert.AreEqual("This is op line text 2", line3);
        }

        private List<WorkOrderImportData> GetWorkOrderDataList()
        {
            WorkOrderImportData woid1 = WorkOrderImportDataFixture.Create("1234", "0110", "0001");
            woid1.ShortText = "This is header text";
            woid1.LongText = "This is op line text 1";

            WorkOrderImportData woid2 = WorkOrderImportDataFixture.Create("1234", "0220", "0002");
            woid2.ShortText = "This is header text";
            woid2.LongText = "This is op line text 2";

            return new List<WorkOrderImportData> { woid1, woid2 };        
        }

        [Ignore] [Test]
        public void ShouldMergeFormStates()
        {
            PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "1111", null);
            PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "2222", null);
            PermitRequestLubes pr3 = PermitRequestLubesFixture.Create("1234", "3333", null);

            {
                pr1.HighEnergy = WorkPermitSafetyFormState.NotApplicable;
                pr2.HighEnergy = WorkPermitSafetyFormState.Required;
                pr3.HighEnergy = WorkPermitSafetyFormState.NotApplicable;

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(GetWorkOrderDataList());

                PermitRequestLubes mergeResult1 = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });
                Assert.AreEqual(WorkPermitSafetyFormState.Required, mergeResult1.HighEnergy);                
            }

            {
                pr1.HighEnergy = WorkPermitSafetyFormState.NotApplicable;
                pr2.HighEnergy = WorkPermitSafetyFormState.NotApplicable;
                pr3.HighEnergy = WorkPermitSafetyFormState.NotApplicable;

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(GetWorkOrderDataList());

                PermitRequestLubes mergeResult1 = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });
                Assert.AreEqual(WorkPermitSafetyFormState.NotApplicable, mergeResult1.HighEnergy);                                
            }
        }

        [Ignore] [Test]
        public void ShouldFindEarliestStartDateTime()
        {
            // basic case
            {
                PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "1111", null);
                pr1.RequestedStartDate = new Date(2014, 4, 1);
                pr1.RequestedStartTimeDay = new Time(8);

                PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "2222", null);
                pr2.RequestedStartDate = new Date(2014, 2, 1);
                pr2.RequestedStartTimeDay = new Time(10);
            
                PermitRequestLubes pr3 = PermitRequestLubesFixture.Create("1234", "3333", null);
                pr3.RequestedStartDate = new Date(2014, 3, 1);
                pr3.RequestedStartTimeDay = new Time(14);

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(new List<WorkOrderImportData>());
                PermitRequestLubes permitRequestLubes = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });

                Assert.IsFalse(pr1.RequestedByGroup.IsConstructionOrTurnaround);
                Assert.AreEqual(new Date(2014, 2, 1), permitRequestLubes.RequestedStartDate);
                Assert.AreEqual(new Time(10), permitRequestLubes.RequestedStartTimeDay);                
            }

            // 3 of the same day, choose the earliest time
            {
                PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "1111", null);
                pr1.RequestedStartDate = new Date(2014, 2, 1);
                pr1.RequestedStartTimeDay = new Time(15);

                PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "2222", null);
                pr2.RequestedStartDate = new Date(2014, 2, 1);
                pr2.RequestedStartTimeDay = new Time(10);

                PermitRequestLubes pr3 = PermitRequestLubesFixture.Create("1234", "3333", null);
                pr3.RequestedStartDate = new Date(2014, 2, 1);
                pr3.RequestedStartTimeDay = new Time(9);

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(new List<WorkOrderImportData>());
                PermitRequestLubes permitRequestLubes = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });

                Assert.AreEqual(new Date(2014, 2, 1), permitRequestLubes.RequestedStartDate);
                Assert.AreEqual(new Time(9), permitRequestLubes.RequestedStartTimeDay);
            }

            // Make the earliest time the night shift
            {
                PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "1111", null);
                pr1.RequestedStartDate = new Date(2014, 2, 1);
                pr1.RequestedStartTimeDay = new Time(2);

                PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "2222", null);
                pr2.RequestedStartDate = new Date(2014, 2, 1);
                pr2.RequestedStartTimeDay = new Time(10);

                PermitRequestLubes pr3 = PermitRequestLubesFixture.Create("1234", "3333", null);
                pr3.RequestedStartDate = new Date(2014, 2, 1);
                pr3.RequestedStartTimeDay = new Time(9);

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(new List<WorkOrderImportData>());
                PermitRequestLubes permitRequestLubes = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });

                Assert.AreEqual(new Date(2014, 2, 1), permitRequestLubes.RequestedStartDate);
                Assert.AreEqual(new Time(2), permitRequestLubes.RequestedStartTimeNight);
            }

            // it should be 7am for non-maintenance
            {
                WorkPermitLubesGroup group = new WorkPermitLubesGroup(1, "Test group", 0);
                group.AddSAPImportPriority(3);
                Assert.IsTrue(group.IsConstructionOrTurnaround);

                PermitRequestLubes pr1 = PermitRequestLubesFixture.Create("1234", "1111", null);
                pr1.RequestedByGroup = group;
                pr1.RequestedStartDate = new Date(2014, 2, 1);
                pr1.RequestedStartTimeDay = new Time(2);

                PermitRequestLubes pr2 = PermitRequestLubesFixture.Create("1234", "2222", null);
                pr2.RequestedByGroup = group;
                pr2.RequestedStartDate = new Date(2014, 2, 1);
                pr2.RequestedStartTimeDay = new Time(10);

                PermitRequestLubes pr3 = PermitRequestLubesFixture.Create("1234", "3333", null);
                pr3.RequestedByGroup = group;
                pr3.RequestedStartDate = new Date(2014, 2, 1);
                pr3.RequestedStartTimeDay = new Time(9);

                PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(new List<WorkOrderImportData>());
                PermitRequestLubes permitRequestLubes = mergeTool.Merge(new List<PermitRequestLubes> { pr1, pr2, pr3 });

                Assert.AreEqual(new Date(2014, 2, 1), permitRequestLubes.RequestedStartDate);
                Assert.IsNull(permitRequestLubes.RequestedStartTimeNight);
                Assert.AreEqual(PermitRequestLubes.DefaultStartTimeForConstructionOrTurnaround, permitRequestLubes.RequestedStartTimeDay);
            }
        }
    }
}
