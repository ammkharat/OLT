using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitRequestEdmontonSAPImportDataTest
    {
        [Test]
        public void ShouldRemoveDuplicates()
        {
            {
                PermitRequestEdmontonSAPImportData item1 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0010", "0001");
                PermitRequestEdmontonSAPImportData item2 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0011", "0001");
                PermitRequestEdmontonSAPImportData item3 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0012", null);

                List<PermitRequestEdmontonSAPImportData> dataList = new List<PermitRequestEdmontonSAPImportData> { item1, item2, item3 };

                List<PermitRequestEdmontonSAPImportData> result = PermitRequestEdmontonSAPImportData.RemoveDuplicateTurnaroundImports(dataList);

                Assert.AreEqual(3, result.Count);

                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0010", "0001")));
                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0011", "0001")));
                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0012", null)));                
            }

            {
                PermitRequestEdmontonSAPImportData item1 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0010", "0001");
                PermitRequestEdmontonSAPImportData item2 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0011", "0001");
                PermitRequestEdmontonSAPImportData item3 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0012", null);
                PermitRequestEdmontonSAPImportData item4 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0012", null);
                PermitRequestEdmontonSAPImportData item5 = PermitRequestEdmontonSAPImportDataFixture.CreateForInsert("1234", "0012", null);

                List<PermitRequestEdmontonSAPImportData> dataList = new List<PermitRequestEdmontonSAPImportData> { item1, item2, item3, item4, item5 };

                List<PermitRequestEdmontonSAPImportData> result = PermitRequestEdmontonSAPImportData.RemoveDuplicateTurnaroundImports(dataList);

                Assert.AreEqual(3, result.Count);

                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0010", "0001")));
                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0011", "0001")));
                Assert.IsTrue(result.Exists(t => t.ContainsWorkOrderSource("1234", "0012", null)));                
            }

            {               
                List<PermitRequestEdmontonSAPImportData> dataList = new List<PermitRequestEdmontonSAPImportData>();
                List<PermitRequestEdmontonSAPImportData> result = PermitRequestEdmontonSAPImportData.RemoveDuplicateTurnaroundImports(dataList);
                Assert.AreEqual(0, result.Count);                
            }
        }
    }
}
