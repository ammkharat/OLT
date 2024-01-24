using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.OltControls
{
    /// <summary>
    /// Olt specific TextBox
    /// </summary>
    public class OltTextBox : TextBox
    {
        private bool oltAcceptsReturn = true;
        private bool oltTrimWhitespace = true;

        public OltTextBox()
        {
            TextChanged += HandleTextChanged;
            KeyDown += HandleKeyDown;
        }

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public decimal? ExtractNullableDecimalValue()
        {
            return Text.IsNullOrEmptyOrWhitespace() ? (decimal?)null : Convert.ToDecimal(Text.Trim());
        }

        [Category("OLT")]
        public bool OltAcceptsReturn
        {
            get { return oltAcceptsReturn; }
            set { oltAcceptsReturn = value; }
        }

        [Category("OLT")]
        public bool OltTrimWhitespace
        {
            get { return oltTrimWhitespace; }
            set { oltTrimWhitespace = value; }
        }

        private void HandleTextChanged(object sender, EventArgs e)
        {
            if (!oltAcceptsReturn && Text.Contains(Environment.NewLine))
            {
                Text = Text.Replace(Environment.NewLine, "");
                SelectionStart = Text.Length;
            }
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (!oltAcceptsReturn && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        public override string Text
        {
            get
            {
                if (oltTrimWhitespace)
                {
                    return base.Text.TrimWhitespace();
                }

                return base.Text;
            }
            set { base.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string TextWithEllipsis
        {
            set { Text = TextWithEllipsisIfNecessary(this, value); }            
        }

        private string TextWithEllipsisIfNecessary(TextBox textBox, string text)
        {
            Size candidateStringSize = TextRenderer.MeasureText(text, textBox.Font);

            if (candidateStringSize.Width < textBox.Width)
            {
                return text;
            }

            const string ellipsis = "...";

            int len = 0;
            int seg = text.Length;
            string aStringThatFits = "";

            while (seg > 1)
            {
                seg -= seg / 2;

                int candidateStringLength = len + seg;

                if (candidateStringLength > text.Length)
                    continue;

                // build and measure a candidate string with ellipsis
                string candidateString = text.Substring(0, candidateStringLength) + ellipsis;
                candidateStringSize = TextRenderer.MeasureText(candidateString, textBox.Font);

                // if this candidate fits, try a bigger one
                if (candidateStringSize.Width <= textBox.Width)
                {
                    len += seg;
                    aStringThatFits = candidateString;
                }
            }

            if (len == 0) // string can't fit into control
            {
                return ellipsis;
            }

            return aStringThatFits;
        }
    }
}