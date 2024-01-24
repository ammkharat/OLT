using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ExpandedLogCommentForm : BaseForm
    {
        private readonly string text;

        public ExpandedLogCommentForm(string text, bool readOnly)
        {
            InitializeComponent();

            if (readOnly)
            {
                RichTextDisplay richTextDisplay = new RichTextDisplay();
                richTextDisplay.Dock = DockStyle.Fill;
                
                textPanel.Controls.Add(richTextDisplay);
            }
            else
            {
                RichTextEditor richTextEditor = new RichTextEditor();
                richTextEditor.Dock = DockStyle.Fill;
                
                textPanel.Controls.Add(richTextEditor);
            }

            this.text = text;
            closeButton.Click += CloseButtonOnClick;
        }

        private void CloseButtonOnClick(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private IHasText TextControl
        {
            get { return (IHasText) textPanel.Controls[0]; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TextControl.Text = text;
        }

        public string TextEditorText
        {
            get { return TextControl.Text; }
        }
    }
}
