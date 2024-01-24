using System.Windows.Forms;
using Com.Suncor.Olt.Client.Utilities;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class RichTextDisplay : UserControl, IHasText
    {
        private readonly RichEditCommand richEditCommand;        
        
        public RichTextDisplay()
        {
            InitializeComponent();

            richEditControl.LayoutUnit = DocumentLayoutUnit.Pixel;
            richEditCommand = richEditControl.CreateCommand(RichEditCommandId.StartOfDocument);                      
        }

        // Note from Dustin: I'm leaving the code below commented out because we will likely want to come back to it
        // in the future. It resizes the control based on the size of the contents. It works, but I can't
        // get the detail panel to respond to the new size.

        //private void richEditCommand_TextChanged(object sender, EventArgs e)
        //{
        //    if (autoExpand)
        //    {
        //        AutoSize = true;

        //        richEditControl.Options.VerticalScrollbar.Visibility = RichEditScrollbarVisibility.Hidden;

        //        RichEditViewVerticalScrollController verticalScrollController =
        //            (RichEditViewVerticalScrollController)richEditControl.ActiveView.GetType().GetProperty(
        //                "VerticalScrollController", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(
        //                    richEditControl.ActiveView, null);

        //        while (verticalScrollController.IsScrollPossible() && richEditControl.ClientSize.Height < 65000)
        //        {
        //            richEditControl.ClientSize = new System.Drawing.Size(richEditControl.ClientSize.Width, richEditControl.ClientSize.Height + 100);
        //        }

        //        if (richEditControl.ClientSize.Height >= 65000)
        //        {
        //            richEditControl.Options.VerticalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
        //        }

        //        if (TextChangedInAutoExpandMode != null)
        //        {
        //            TextChangedInAutoExpandMode(this, e);
        //        }
        //    }
        //}
      
        public override string Text
        {
            get { return richEditControl.RtfText; }
            set
            {
                richEditControl.RtfText = RichTextUtilities.ConvertTextToRTF(value);
                ScrollToTop();
            }
        }

        public void AppendText(string textToAppend)
        {
            textToAppend = RichTextUtilities.ConvertTextToRTF(textToAppend);
            richEditControl.Document.AppendRtfText(textToAppend);        
            ScrollToTop();
        }        

        public void Clear()
        {
            richEditControl.ResetText();
        }

        public RichEditControl RichEditControl
        {
            get { return richEditControl; }
        }
        
        private void ScrollToTop()
        {
            richEditCommand.Execute();
        }       
    }
}
