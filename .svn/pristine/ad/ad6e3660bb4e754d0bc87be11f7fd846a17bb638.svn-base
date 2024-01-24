using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class TargetAlertReportDetailDTOTest
    {
        [Test]
        public void ReportDetailShouldBeSerializable()
        {
            TargetAlertReportDetailDTO alertReportDetail = TargetAlertReportDetailDTOFixture.CreateTargetAlertReportDetailDTO();
            TestUtil.SerializeAndDeSerialize<TargetAlertReportDetailDTO>(alertReportDetail);
        }
    }
}
