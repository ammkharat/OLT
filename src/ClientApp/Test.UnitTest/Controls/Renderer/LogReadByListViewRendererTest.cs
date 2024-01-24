using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Controls.Renderer
{
    [TestFixture]
    public class LogReadByListViewRendererTest
    {
        IDomainListViewRenderer<ItemReadBy> renderer;

        [SetUp]
        public void SetUp()
        {
            renderer = new LogReadByListViewRenderer();
        }

        [Test]
        public void ShouldRenderUserWhomHaveReadTheLog()
        {
            ItemReadBy itemReadBy = new ItemReadBy("Simpson, Bart [oltuser2]", DateTimeFixture.DateTimeNow);
            ListViewItem lvi = renderer.RenderItem(itemReadBy);
            Assert.AreEqual(itemReadBy.DateTime.ToLongDateAndTimeString(), lvi.Text);
            Assert.AreEqual(2, lvi.SubItems.Count);
            Assert.AreEqual(itemReadBy.UserFullNameWithUserName, lvi.SubItems[1].Text);
        }

        [Test]
        public void ShouldRenderColumns()
        {
            DomainListViewColumn[] columns = renderer.Columns.ToDomainListViewColumns();
            Assert.AreEqual(2, columns.Length);
            Assert.AreEqual("Date/Time", columns[0].Text);
            Assert.AreEqual("User Name", columns[1].Text);
        }
    }
}
