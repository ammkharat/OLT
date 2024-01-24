using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LogCommentControl : UserControl
    {
        public event EventHandler GuidelineLinkClick;

        public LogCommentControl()
        {            
            InitializeComponent();            
            guidelineLinkLabel.Click += guidelineLinkLabel_Click;          
            expandLinkLabel.Click += expandLinkLabel_Click;
        }

        private void guidelineLinkLabel_Click(object sender, EventArgs e)
        {
            if (GuidelineLinkClick != null)
            {
                GuidelineLinkClick(sender, e);
            }            
        }
       
        public void ShowLogGuidelineForm(List<LogGuideline> logGuidelines)
        {
            string guidelineText = GuidelineUtilities.BuildGuidelineText(logGuidelines);

            LogGuidelineForm logGuidelineForm = new LogGuidelineForm(guidelineText);
            logGuidelineForm.ShowDialog(this);
        }

        private void expandLinkLabel_Click(object sender, EventArgs eventArgs)
        {
            ExpandedLogCommentForm expandedLogCommentForm = new ExpandedLogCommentForm(Text, false);
            expandedLogCommentForm.ShowDialog(this);
            Text = expandedLogCommentForm.TextEditorText;
        }
              
        public override string Text
        {
            get
            {
                return textEditor.Text;
            }
            set
            {
                textEditor.Text = value;
            }
        }
        
        public string PlainText
        {
            get { return textEditor.PlainText; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            textEditor.Width = groupBox.Width - 15;          
        }

        public void SetError(string message)
        {
            textEditor.Width = groupBox.Width - 35;
            errorProvider.SetError(textEditor, message);
        }

        public bool IsEmpty
        {
            get { return textEditor.IsEmpty; }
        }

        public bool TextBoxReadOnly
        {
            set { textEditor.ReadOnly = value; }
            get { return textEditor.ReadOnly; }
        }

        public void AppendText(string textToAppend)
        {
            textEditor.AppendText(textToAppend);
        }
    }
}
