using System;
using System.Reflection;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Reports.Adapters;
using NUnit.Framework;

namespace Reports.Tests.Adapters
{
    [TestFixture]
    public class WorkPermitLubesReportAdapterTest
    {
        [Test]
        public void ShouldNotCrashWithEmptyWorkPermit()
        {
            WorkPermitLubes permit = new WorkPermitLubes(DateTime.Now, null);
            WorkPermitLubesReportAdapter adapter = new WorkPermitLubesReportAdapter(permit, false, false, true);

            PropertyInfo[] propertyInfos = typeof (WorkPermitLubesReportAdapter).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //if (propertyInfo.Name == "IdValue")
                //{
                //    continue;
                //}

                MethodInfo methodInfo = propertyInfo.GetGetMethod(false);

                if (methodInfo != null)
                {
                    object value = propertyInfo.GetValue(adapter, null);
                }
            }
        }

        [Test]
        public void ShouldTruncateTheContractorAndTradeValues()
        {
            WorkPermitLubes permit = new WorkPermitLubes(DateTime.Now, null);
            permit.Company = "abcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyz";
            permit.Trade = "abcdefghijklmnopqrstuvwxyzAbcdefghijklmnopqrstuvwxyz";

            WorkPermitLubesReportAdapter adapter = new WorkPermitLubesReportAdapter(permit, false, false, true);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyzAbcdef", adapter.Company);
            Assert.AreEqual("abcdefghijklmnopqrstuvwxyzA", adapter.Occupation);
        }
    }
}
