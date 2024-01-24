using System;
using Com.Suncor.Olt.Common.Domain;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitGasTestsFixture
    {
        public static WorkPermitGasTests CreateWorkPermitGasTestsWith2EmptyElements()
        {
            WorkPermitGasTests gasTests = new WorkPermitGasTests();

            gasTests.Elements.Add(new GasTestElement());
            gasTests.Elements.Add(new GasTestElement());

            return gasTests;
        }

        public static WorkPermitGasTests CreateGasTestsWithData(Site site)
        {
            WorkPermitGasTests gasTests = new WorkPermitGasTests();
            gasTests.FrequencyOrDuration = "Sample Frequency Or Duration Data";
            gasTests.ImmediateAreaTestTime = new Time(DateTimeFixture.DateTimeNow);
            gasTests.ConfinedSpaceTestTime = new Time(DateTimeFixture.DateTimeNow);
            gasTests.ConstantMonitoringRequired = true;

            gasTests.Elements.Clear();
            List<GasTestElementInfo> standardElementInfoList = GasTestElementInfoFixture.CreateSampleStandardGasTestElementInfoList(site);
            foreach (GasTestElementInfo info in standardElementInfoList)
            {
                GasTestElement element = GasTestElementFixture.CreateGasTestElementWithData(info);
                gasTests.Elements.Add(element);
            }

            long? randomOtherElementInfoId = 100;
            GasTestElementInfo otherInfo = GasTestElementInfoFixture.CreateOtherElementInfo(randomOtherElementInfoId, site);
            GasTestElement otherElement = GasTestElementFixture.CreateGasTestElementWithData(otherInfo);
            gasTests.Elements.Add(otherElement);

            return gasTests;
        }
    }
}