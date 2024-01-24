using Com.Suncor.Olt.Common.Domain;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class WorkPermitListViewRendererTest
    {
        IDomainListViewRenderer<WorkPermit> renderer;

        [SetUp]
        public void SetUp()
        {
            renderer = new WorkPermitListViewRenderer();
        }

        [Test]
        public void ShouldRenderWorkPermit()
        {
            WorkPermit workPermit = WorkPermitFixture.CreateWorkPermitWithGivenId(1);
            ListViewItem lvi = renderer.RenderItem(workPermit);

            Assert.AreEqual(workPermit.PermitNumber, lvi.Text);
            Assert.AreEqual(6, lvi.SubItems.Count);

            int i = 0;
            Assert.AreEqual(workPermit.PermitNumber, lvi.SubItems[i++].Text);
            Assert.AreEqual(workPermit.Specifics.WorkOrderNumber, lvi.SubItems[i++].Text);
            Assert.AreEqual(workPermit.Specifics.FunctionalLocation.FullHierarchy, lvi.SubItems[i++].Text);
            Assert.AreEqual(workPermit.Specifics.StartDateTime.ToLongDateAndTimeString(), lvi.SubItems[i++].Text);
            Assert.AreEqual(workPermit.Specifics.WorkOrderDescription, lvi.SubItems[i++].Text);
            Assert.AreEqual(workPermit.Specifics.CraftOrTradeName, lvi.SubItems[i++].Text);
        }

        [Test]
        public void ShouldRenderWorkPermitColumns()
        {
            DomainListViewColumn[] columns = renderer.Columns.ToDomainListViewColumns();
            Assert.AreEqual(6, columns.Length);

            int i = 0;
            Assert.AreEqual("Permit#", columns[i++].Text);
            Assert.AreEqual("Work Order #", columns[i++].Text);
            Assert.AreEqual("FLOC", columns[i++].Text);
            Assert.AreEqual("Start Date", columns[i++].Text);
            Assert.AreEqual("Description", columns[i++].Text);
            Assert.AreEqual("Trade", columns[i++].Text);
        }

        [Test]
        public void AllColumnHeaderNamesMustLinkToAPropertyInTheDomainObjectBeingDisplayed()
        {
            WorkPermit permit = WorkPermitFixture.CreateWorkPermitWithGivenId(1);
            DomainListView<WorkPermit> listView = new DomainListView<WorkPermit>(renderer, false);
            foreach (ColumnHeader header in listView.Columns)
            {
                if (!TestRendererUtils.ColumnHeaderNameExistsAsPropertyInObject(header.Name, permit))
                {
                    Assert.Fail("The Column name must match a property on the domain object being rendered. If it doesn't sorting the column fails"
                                + "The Column name " + header.Name + " Does not exist as a property in " + permit.GetType());
                }
            }
        }

    }
}
