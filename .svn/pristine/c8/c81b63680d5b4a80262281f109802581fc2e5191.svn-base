using System;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.OltControls
{
    [TestFixture]
    public class OltLinkLabelTest
    {
        [Test]
        public void ShouldAddTextAndLinks()
        {
            OltLinkLabel1 linkLabel1 = new OltLinkLabel1();
            linkLabel1.Clear();

            linkLabel1.AddTextSegment("justtext ");
            Assert.AreEqual("justtext ", linkLabel1.Text);
            Assert.AreEqual(0, linkLabel1.Links.Count);

            linkLabel1.AddLink("link", DummyLinkClickedHandler);
            Assert.AreEqual("justtext link", linkLabel1.Text);
            Assert.AreEqual(1, linkLabel1.Links.Count);

            // justtext link
            //          ^^^^
            // 0123456789-12
            Assert.AreEqual(9, linkLabel1.Links[0].Start);
            Assert.AreEqual("link".Length, linkLabel1.Links[0].Length);
        }

        private void DummyLinkClickedHandler(object sender, EventArgs e)
        {
        }
    }
}
