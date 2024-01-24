using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltDropDownTextEditor : OltTextEditor
    {
        private readonly OltTextBox popupEditorEditor;
        private readonly DropDownEditorButton editorButton;

        private readonly int widthDelta;

        public OltDropDownTextEditor(int widthDelta, int height)
        {
            this.widthDelta = widthDelta;

            popupEditorEditor = new OltTextBox();
            popupEditorEditor.Multiline = true;
            popupEditorEditor.Height = height;
            popupEditorEditor.ScrollBars = ScrollBars.Vertical;
            popupEditorEditor.KeyDown += PopupEditor_KeyDown;

            editorButton = new DropDownEditorButton();
            editorButton.Control = popupEditorEditor;

            ButtonsRight.Add(editorButton);
            BeforeEditorButtonDropDown += This_BeforeEditorButtonDropDown;
            AfterEditorButtonCloseUp += This_AfterEditorButtonCloseUp;
        }

        private void PopupEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                CloseEditorButtonDropDowns();
            }
        }

        private void This_BeforeEditorButtonDropDown(object sender, BeforeEditorButtonDropDownEventArgs e)
        {
            UltraGridCell cell = e.Context as UltraGridCell;
            if (cell != null)
            {
                popupEditorEditor.Text = cell.Text;
                popupEditorEditor.SelectionStart = popupEditorEditor.TextLength;
                popupEditorEditor.MaxLength = cell.Column.MaxLength;
                popupEditorEditor.Width = cell.Column.Width + widthDelta;

                DropDownEditorButton button = e.Button as DropDownEditorButton;
                if (button != null)
                {
                    button.DropDownResizeHandleStyle = DropDownResizeHandleStyle.DiagonalResize;
                }
            }
        }

        private void This_AfterEditorButtonCloseUp(object sender, EditorButtonEventArgs e)
        {
            UltraGridCell cell = e.Context as UltraGridCell;
            if (cell != null)
            {
                cell.Value = popupEditorEditor.Text;
            }
        }
    }
}
