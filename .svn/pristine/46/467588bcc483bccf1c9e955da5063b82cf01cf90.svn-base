using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Infragistics.Win.UltraWinGrid;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls
{
    [TestFixture]
    public class SummaryGridTest
    {
        [Test]
        public void ShouldGetUniqueNameIfNoParent()
        {
            TestGrid grid = new TestGrid();
            Assert.AreEqual("TestGrid-TestGridRenderer", grid.GetUniqueGridName());
        }

        [Test]
        public void ShouldGetUniqueNameWhenNoParentOfTheRightType()
        {
            Control parentParent = new Control();

            Control parent = new Control();
            parent.Parent = parentParent;

            TestGrid grid = new TestGrid();
            grid.Parent = parent;

            Assert.AreEqual("Control-TestGridRenderer", grid.GetUniqueGridName());
        }

        [Test]
        public void ShouldGetUniqueNameWhenParentIsForm()
        {
            Control parentParent = new Control();
            parentParent.Parent = new TestForm();

            Control parent = new Control();
            parent.Parent = parentParent;

            TestGrid grid = new TestGrid();
            grid.Parent = parent;

            Assert.AreEqual("TestForm-TestGridRenderer", grid.GetUniqueGridName());
        }

        [Test]
        public void ShouldGetUniqueNameWhenParentIsUserControl()
        {
            Control parentParent = new Control();
            parentParent.Parent = new TestUserControl();

            Control parent = new Control();
            parent.Parent = parentParent;

            TestGrid grid = new TestGrid();
            grid.Parent = parent;

            Assert.AreEqual("TestUserControl-TestGridRenderer", grid.GetUniqueGridName());
        }

        private class TestUserControl : UserControl
        {
        }

        private class TestForm : Form
        {
        }

        private class TestGrid : SummaryGrid<object>
        {
            public TestGrid() : base(new TestGridRenderer(), OltGridAppearance.SINGLE_SELECT)
            {
            }

            public string GetUniqueGridName()
            {
                return UniqueGridName;
            }
        }

        private class TestGridRenderer : AbstractSimpleGridRenderer
        {
            protected override void SetUpColumns(UltraGridBand band)
            {
            }
        }
    }
}
