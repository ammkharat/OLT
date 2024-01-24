using System.Drawing;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Controls.GridRenderer.GridColumn;
using Com.Suncor.Olt.Client.Localization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class TargetAlertGridRendererTest
    {
        private TargetAlertGridRenderer renderer;
        private UltraGridBand band;

        [SetUp]
        public void SetUp()
        {
            renderer = new TargetAlertGridRenderer();
            band = new UltraGridBand(string.Empty, 1);
        }

        [Test]
        public void ShouldAllowFilteringOnStatusImageColumn()
        {
            UltraGridColumn statusImageColumn = RenderStatusImageColumn();
            BeforeRowFilterDropDownPopulateEventArgs e = CreateEventArgs(statusImageColumn);

            // Execute:
            renderer.BeforeFilterDropDownPopulate(null, e);

            Assert.IsTrue(e.Handled, "Event should be handled by this renderer.");
            Assert.AreEqual(1 + TargetAlertStatus.AllNeedingAttention.Count, 
                e.ValueList.ValueListItems.Count,
                "If there were TWO target alert statuses that need attention, " 
                + "then we would expect THREE filter choices: (All), Status1, Status2");

            Assert.AreEqual(InfragisticsStringResources.RowFilterDropDownAllItem, e.ValueList.ValueListItems[0].DisplayText);
        }

        [Test]
        public void ShouldAllowFilteringOnPriorityImageColumn()
        {
            UltraGridColumn priorityImageColumn = RenderPriorityImageColumn();
            BeforeRowFilterDropDownPopulateEventArgs e = CreateEventArgs(priorityImageColumn);

            // Execute:
            renderer.BeforeFilterDropDownPopulate(null, e);

            Assert.IsTrue(e.Handled, "Event should be handled by this renderer.");
            Assert.AreEqual(1 + TargetDefinition.Priorities.Length, e.ValueList.ValueListItems.Count);
            Assert.AreEqual(InfragisticsStringResources.RowFilterDropDownAllItem, e.ValueList.ValueListItems[0].DisplayText);
        }

        private UltraGridColumn RenderStatusImageColumn()
        {
            renderer.SetupUnboundColumns(band);


            UltraGridColumn statusImageColumn = band.Columns[new TargetAlertStatusImageColumn().ColumnKey];
            Assert.AreEqual(typeof(Image), statusImageColumn.DataType);
            return statusImageColumn;
        }

        private UltraGridColumn RenderPriorityImageColumn()
        {
            renderer.SetupUnboundColumns(band);

            UltraGridColumn statusImageColumn = band.Columns[new TargetAlertStatusImageColumn().ColumnKey];
            Assert.AreEqual(typeof(Image), statusImageColumn.DataType);
            return statusImageColumn;
        }

        private static BeforeRowFilterDropDownPopulateEventArgs CreateEventArgs(UltraGridColumn column)
        {
            return new BeforeRowFilterDropDownPopulateEventArgs(column, null, new ValueList());
        }
    }
}
