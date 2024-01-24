using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraSpellChecker;
using log4net;
using PopupMenuShowingEventArgs = DevExpress.XtraRichEdit.PopupMenuShowingEventArgs;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class RichTextEditor : UserControl, IHasText
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(RichTextEditor));

        public RichTextEditor()
        {
            InitializeComponent();

            richEditControl.LayoutUnit = DocumentLayoutUnit.Pixel;

            changeFontNameItem1.EditValue = UIConstants.CONTROL_FONT.Name;
            richEditControl.Options.SpellChecker.AutoDetectDocumentCulture = false;
            richEditControl.FontFormShowing += richEditControl_FontFormShowing;
            richEditControl.PopupMenuShowing += richEditControl_PopupMenuShowing;

            richEditControl.Font = new Font(UIConstants.CONTROL_FONT.Name, UIConstants.RichTextDefaultFontSize);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            spellChecker.BeforeCheck += spellChecker_BeforeCheck;
            spellChecker.UnhandledException += HandleUnhandledException;
            spellChecker.Culture = Culture.CultureInfo;
        }

        private static void richEditControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowFontForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowParagraphForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowNumberingListForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowBookmarkForm);
            e.Menu.RemoveMenuItem(RichEditCommandId.CreateBookmark);
            e.Menu.RemoveMenuItem(RichEditCommandId.ShowHyperlinkForm);            
            e.Menu.RemoveMenuItem(RichEditCommandId.CreateHyperlink);            
        }

        private static void richEditControl_FontFormShowing(object sender, FontFormShowingEventArgs e)
        {
            e.Handled = true;
        }
             
        private void spellChecker_BeforeCheck(object sender, BeforeCheckEventArgs e)
        {
            if (ReadOnly)
            {
                e.Cancel = true;
            }
        }

        private void HandleUnhandledException(object sender, SpellCheckerUnhandledExceptionEventArgs e)
        {
            logger.Error("There was an error with the spellchecker.", e.Exception);
            e.Handled = true;            
        }

        public override string Text
        {
            get { return richEditControl.RtfText; }
            set
            {
                // This is because, for some reason, if you set the text to null it ignores the font we want. If you set it to an empty string it works. We've been handling it in all the presenters
                string text = value ?? string.Empty;

                // In some circumstances (see card 1909), setting the font (as we do in the constructor) causes the last line of the text to take on this font.
                // Resetting the font here fixes that.
                richEditControl.ResetFont();
                richEditControl.RtfText = RichTextUtilities.ConvertTextToRTF(text);
            }
        }

        public string PlainText
        {
            get { return richEditControl.Text; }
        }

        public bool IsEmpty
        {
            get { return richEditControl.Document.IsEmpty || richEditControl.Text.IsNullOrEmptyOrWhitespace(); }
        }

        public bool ReadOnly
        {
            get { return richEditControl.ReadOnly; }
            set { richEditControl.ReadOnly = value; }
        }

        public void AppendText(string textToAppend)
        {
            textToAppend = RichTextUtilities.ConvertTextToRTF(textToAppend);
            richEditControl.Document.AppendRtfText(textToAppend);                     
        }        
    }
}
