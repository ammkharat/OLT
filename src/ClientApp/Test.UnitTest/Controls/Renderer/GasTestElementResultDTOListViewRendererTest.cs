using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class GasTestElementResultDTOListViewRendererTest
    {
        private GasTestElementResulDTOListViewRenderer renderer;
        
        [SetUp]
        public void SetUp()
        {
            renderer = new GasTestElementResulDTOListViewRenderer();
        }

        [Test]
        public void ColumnNamesShouldMatchDTOProperties()
        {
            DomainListViewColumnCollection columns = renderer.Columns;
            columns.ForEach(column => AssertHasReadableProperty(typeof (GasTestElementResultDTO), column.Name));
        }

        [Test]
        public void ColumnsShouldContainElementNameColumn()
        {
            Assert.That(renderer.Columns.ToDomainListViewColumns(), Has.Some.Property("Name").EqualTo( "Name"));
        }

        [Test]
        public void ColumnsShouldContainLimitColumn()
        {
            Assert.That(renderer.Columns.ToDomainListViewColumns(), Has.Some.Property("Name").EqualTo( "Limit"));
        }

        [Test]
        public void ColumnsShouldContainFirstTestResultColumn()
        {
            Assert.That(renderer.Columns.ToDomainListViewColumns(), Has.Some.Property("Name").EqualTo( "FirstTestResult"));
        }

        [Test]
        public void ColumnsShouldContainConfinedSpaceTestResultColumn()
        {
            Assert.That(renderer.Columns.ToDomainListViewColumns(), Has.Some.Property("Name").EqualTo( "ConfinedSpaceTestResult"));
        }

        [Test]
        public void RenderItemShouldRenderName()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO("test name", null, false, null, null));
            Assert.AreEqual("test name", item.Text);
        }

        [Test]
        public void RenderItemShouldRenderLimit()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO(null, "20 ppm", false, null, null));
            Assert.AreEqual("20 ppm", item.SubItems[1].Text);
        }

        [Test]
        public void RenderItemShouldRenderFirstTestResult()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO(null, null, false, 2.34, null));
            Assert.AreEqual("2.34", item.SubItems[2].Text);
        }

        [Test]
        public void RenderItemShouldRenderConfinedSpaceTestResult()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO(null, null, false, null, 3.45));
            Assert.AreEqual("3.45", item.SubItems[3].Text);
        }

        [Test]
        public void RenderItemShouldRenderNoFirstTestResultAsEmpty()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO(null, null, false, null, null));
            Assert.AreEqual(string.Empty, item.SubItems[2].Text);
        }

        [Test]
        public void RenderItemShouldRenderNoConfinedSpaceTestResultAsEmpty()
        {
            ListViewItem item = renderer.RenderItem(new GasTestElementResultDTO(null, null, false, null, null));
            Assert.AreEqual(string.Empty, item.SubItems[3].Text);
        }

        private static void AssertHasReadableProperty(Type type, string propertyName)
        {
            Assert.IsTrue(type.GetProperty(propertyName).CanRead);
        }

        [Test]
        public void ShouldRenderSystemEntryFieldsForDenverOnly()
        {
            var denverRenderer = new GasTestElementResultDenverDTOListViewRenderer();
            ListViewItem item = denverRenderer.RenderItem(new GasTestElementResultDTO(null, null, false, null, null, 3.45));
            Assert.AreEqual("3.45", item.SubItems[4].Text);
        }
    }
}
