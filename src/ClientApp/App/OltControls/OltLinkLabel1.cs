using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltLinkLabel1 : LinkLabel
    {
        private readonly Dictionary<Link, EventHandler> linkClickedHandlers = new Dictionary<Link, EventHandler>();

        public OltLinkLabel1()
        {
            LinkClicked += LinkLabelClicked;
        }

        public void Clear()
        {
            Links.Clear();
            Text = string.Empty;
        }

        public void AddTextSegment(string textSegment)
        {
            Text = Text + textSegment;
        }

        public void AddLink(string linkText, EventHandler linkClickedHandler)
        {
            Link newLink = new Link(Text.Length, linkText.Length);
            linkClickedHandlers[newLink] = linkClickedHandler;

            AddTextSegment(linkText);
            Links.Add(newLink);
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        private void LinkLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandler linkClickedHandler = linkClickedHandlers[e.Link];
            if (linkClickedHandler == null)
            {
                throw new ApplicationException("Unrecognized link clicked:<" + e.Link + ">");
            }

            linkClickedHandler(this, EventArgs.Empty);
        }
    }
}