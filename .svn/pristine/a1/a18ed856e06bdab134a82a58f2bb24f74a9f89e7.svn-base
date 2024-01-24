using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using DevExpress.XtraSpellChecker;
using Infragistics.Win.IGControls;
using log4net;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltSpellCheckTextBox : UserControl
    {
        private readonly IGContextMenu menu = new IGContextMenu();

        private bool oltTrimWhitespace;
        private bool readOnly;

        public OltSpellCheckTextBox(IContainer components)
        {
            if (components != null) components.Add(this);
            InitializeComponent();
            textBox.MouseDown += textBox_MouseDown;
            textBox.KeyDown += textBox_KeyDown;
        }

        public RichTextBoxScrollBars ScrollBars
        {
            get { return textBox.ScrollBars; }
            set { textBox.ScrollBars = value; }
        }

        public int MaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        public bool AcceptsTabAndReturn
        {
            get { return textBox.AcceptsTab; }
            set { textBox.AcceptsTab = value; }
            // setting AcceptsTab to true also allows the user to hit enter on forms that have a button set as the accept key
        }

        public bool OltTrimWhitespace
        {
            get { return oltTrimWhitespace; }
            set { oltTrimWhitespace = value; }
        }

        public override string Text
        {
            get
            {
                var text = textBox.Text.Replace("\n", Environment.NewLine);

                if (oltTrimWhitespace)
                {
                    text = text.TrimWhitespace();
                }

                return text;
            }
            set { textBox.Text = value; }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                textBox.ReadOnly = value;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            spellChecker.Culture = Culture.CultureInfo;
            spellChecker.BeforeCheck += spellChecker_BeforeCheck;
            spellChecker.UnhandledException += HandleUnhandledException;
            spellChecker.Check(textBox);

            InitializeSpellCheckContextMenu();
        }

        private void InitializeSpellCheckContextMenu()
        {
            menu.Style = MenuStyle.Office2003;
            textBox.ContextMenu = menu;
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menu.MenuItems.Clear();

                if (spellChecker.SpellCheckMode == SpellCheckMode.AsYouType)
                {
                    // Create a new point for spellingError to use
                    // to get the spelling error at point. The point
                    // will be the mouse coordinates.
                    var point = new Point(e.X, e.Y);

                    // Get the spelling error at the mouse's coordinates.
                    var spellCheckErrorBase = spellChecker.CalcError(point);
                    var spellCheckerCommands = spellChecker.GetCommandsByError(spellCheckErrorBase);

                    if (spellCheckerCommands != null && spellCheckerCommands.Count != 0)
                    {
                        AppendSpellingContextMenuItems(spellCheckerCommands);
                    }
                }
                AppendBaseContextMenuItems();
            }
        }

        private void AppendBaseContextMenuItems()
        {
            if (menu.MenuItems.Count > 0)
            {
                menu.MenuItems.Add(new IGMenuItem("-"));
            }
            var copy = new IGMenuItem(StringResources.SpellCheckTextBoxContextMenu_Copy, copy_Click);
            var paste = new IGMenuItem(StringResources.SpellCheckTextBoxContextMenu_Paste, paste_Click);
            menu.MenuItems.Add(copy);
            menu.MenuItems.Add(paste);
        }

        private void AppendSpellingContextMenuItems(List<SpellCheckerCommand> commands)
        {
            if (commands != null)
            {
                foreach (var command in commands)
                {
                    var menuItem = new IGMenuItem(command.Caption, OnClick);
                    menuItem.Tag = command;
                    menu.MenuItems.Add(menuItem);
                }
            }
        }

        private void OnClick(object sender, EventArgs eventArgs)
        {
            var menuItem = (IGMenuItem) sender;
            var command = (SpellCheckerCommand) menuItem.Tag;
            command.DoCommand();
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
            var logger = LogManager.GetLogger(typeof (OltSpellCheckTextBox));
            logger.Error("There was an error with the spellchecker.", e.Exception);
            e.Handled = true;
        }

        private void copy_Click(object sender, EventArgs e)
        {
            if (textBox.SelectionLength > 0)
            {
                textBox.Copy();
            }
        }

        private void paste_Click(object sender, EventArgs e)
        {
            var dataObject = Clipboard.GetDataObject();
            if (dataObject != null && dataObject.GetDataPresent(DataFormats.Text))
            {
                textBox.Paste(GetClipFormat());
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                textBox.Paste(GetClipFormat());
                e.Handled = true;
            }
        }

        private static DataFormats.Format GetClipFormat()
        {
            return DataFormats.GetFormat(DataFormats.Text);
        }
    }
}