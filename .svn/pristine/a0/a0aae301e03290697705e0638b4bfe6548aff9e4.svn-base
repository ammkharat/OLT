using System.Windows.Forms;
using System.Collections;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class DomainListViewColumnCollectionTest
    {
        private DomainListViewColumn.ResizeToHeaderSizeColumn autoColumn;
        private DomainListViewColumn.ManualColumn manualColumn;
        private DomainListViewColumnCollection columns;

        [SetUp]
        public void SetUp()
        {
            autoColumn = new DomainListViewColumn.ResizeToHeaderSizeColumn("colAuto", "Auto Column");
            manualColumn = new DomainListViewColumn.ManualColumn("colManual", "Manual Column", 75);

            columns = new DomainListViewColumnCollection();
            columns.Add(autoColumn);
            columns.Add(manualColumn);
        }

        [Test]
        public void ShouldConvertToColumnHeaders()
        {
            ColumnHeader[] columnHeaders = columns.ToColumnHeaders();
            Assert.AreEqual(2, columnHeaders.Length);
            AssertColumnHeader(autoColumn, columnHeaders[0]);
            AssertColumnHeader(manualColumn, columnHeaders[1]);
        }

        [Test]
        public void ShouldSetColumnHeaderWidths()
        {
            ColumnHeader autoColumnHeader = new ColumnHeader();
            autoColumnHeader.Name = autoColumn.Name;
            ColumnHeader manualColumnHeader = new ColumnHeader();
            manualColumnHeader.Name = manualColumn.Name;

            IList columnHeaders = new ArrayList();
            columnHeaders.Add(autoColumnHeader);
            columnHeaders.Add(manualColumnHeader);
            
            // Execute:
            columns.SetColumnHeaderWidths(columnHeaders);

            Assert.AreEqual(-2, autoColumnHeader.Width);
            Assert.AreEqual(manualColumn.Width, manualColumnHeader.Width);
        }

        private void AssertColumnHeader(DomainListViewColumn expected, ColumnHeader actual)
        {
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Text, actual.Text);

            if (expected is DomainListViewColumn.ResizeToHeaderSizeColumn)
            {
                Assert.AreEqual(-2, actual.Width);
            }
            else if (expected is DomainListViewColumn.ManualColumn)
            {
                DomainListViewColumn.ManualColumn expectedManualColumn = expected as DomainListViewColumn.ManualColumn;
                Assert.AreEqual(expectedManualColumn.Width, actual.Width);
            }
            else
            {
                Assert.Fail("Unexpected column type:<" + expected.GetType() + ">");
            }
        }
    }
}
