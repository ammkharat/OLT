using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class WorkOrderWorkPermitLubesTypeConverterTest
    {
        [Ignore] [Test]
        public void ShouldSetWorkPermitTypeInformation()
        {
            // cold
            {
                PermitRequestLubes pr = PermitRequestLubesFixture.CreateEmptyPermitRequest();
                WorkOrderWorkPermitLubesTypeConverter.SetWorkPermitTypeInformation("11", pr);     
                Assert.AreEqual(WorkPermitLubesType.HAZARDOUS_COLD_WORK, pr.WorkPermitType);
                Assert.IsFalse(pr.IsVehicleEntry);
            }

            // hot
            {
                PermitRequestLubes pr = PermitRequestLubesFixture.CreateEmptyPermitRequest();
                WorkOrderWorkPermitLubesTypeConverter.SetWorkPermitTypeInformation("12", pr);     
                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, pr.WorkPermitType);
                Assert.IsFalse(pr.IsVehicleEntry);
            }

            // vehicle entry
            {
                PermitRequestLubes pr = PermitRequestLubesFixture.CreateEmptyPermitRequest();
                WorkOrderWorkPermitLubesTypeConverter.SetWorkPermitTypeInformation("13", pr);     
                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, pr.WorkPermitType);
                Assert.IsTrue(pr.IsVehicleEntry);
            }
            // vehicle entry with bad backspace that we seem to get from SAP
            {
                PermitRequestLubes pr = PermitRequestLubesFixture.CreateEmptyPermitRequest();
                WorkOrderWorkPermitLubesTypeConverter.SetWorkPermitTypeInformation(@"13\", pr);
                Assert.AreEqual(WorkPermitLubesType.HOT_WORK, pr.WorkPermitType);
                Assert.IsTrue(pr.IsVehicleEntry);
            }

        }
    }
}
