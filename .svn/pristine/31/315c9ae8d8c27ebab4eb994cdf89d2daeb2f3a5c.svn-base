using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltListMessageBox : Form
    {
        private readonly List<string> listItems;
        private TableLayoutPanel tableLayoutPanel;
        private readonly int originalMessageOneHeight;

        private OltListMessageBox()
        {
            InitializeComponent();
        }

        private OltListMessageBox(Form owner, string messageOne, string messageTwo, List<string> listItems, string title, MessageBoxIcon icon, bool showOkButtonInsteadOfYesNo) : this()
        {
            Disposed += HandleDisposed;

            ChooseIconForFormFromEnum(icon);
            this.listItems = listItems;
            Owner = owner;
            Text = title;

            originalMessageOneHeight = messageOneLabel.Height;
            messageOneLabel.Text = messageOne;
            messageTwoLabel.Text = messageTwo;

            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tableLayoutPanel.RowCount = listItems.Count;

            panelForTable.Controls.Add(tableLayoutPanel);

            mainPanel.Paint += HandleMainPanelPaint;

            if (showOkButtonInsteadOfYesNo)
            {
                okButton.Visible = true;
                yesButton.Visible = false;
                noButton.Visible = false;
            }
            else
            {
                okButton.Visible = false;
                yesButton.Visible = true;
                noButton.Visible = true;
            }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            tableLayoutPanel = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            int rowIndex = 0;
            listItems.ForEach(item =>
            {
                OltLabel label = new OltLabel();
                label.AutoSize = false;
                label.Width = tableLayoutPanel.Width;
                label.Text = string.Format("\u2022   {0}", item);

                Size size = TextRenderer.MeasureText(label.Text, label.Font, new Size(label.Width, Int32.MaxValue), TextFormatFlags.WordBreak);
                label.Height = size.Height;

                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, label.Height));
                tableLayoutPanel.Controls.Add(label, 0, rowIndex);

                panelForTable.Height += label.Height;
                messageTwoLabel.Location = new Point(messageTwoLabel.Location.X, messageTwoLabel.Location.Y + label.Height);
                this.Height += label.Height;

                rowIndex += 1;
            });

            MoveItemsDownIfMessageOneIsTall();
        }

        private void MoveItemsDownIfMessageOneIsTall()
        {
            Size messageOneSize = TextRenderer.MeasureText(messageOneLabel.Text, messageOneLabel.Font, new Size(messageOneLabel.Width, Int32.MaxValue), TextFormatFlags.WordBreak);

            if (messageOneSize.Height > originalMessageOneHeight)
            {
                int difference = messageOneSize.Height - originalMessageOneHeight;
                difference += 10;
                this.Height += difference;
                messageTwoLabel.Location = new Point(messageTwoLabel.Location.X, messageTwoLabel.Location.Y + difference);
                panelForTable.Location = new Point(panelForTable.Location.X, panelForTable.Location.Y + difference);
            }
        }

        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public static DialogResult Show(Form owner, string messageOne, string messageTwo, List<string> listItems, string title, MessageBoxIcon icon, bool showOkButtonInsteadOfYesNo)
        {
            OltListMessageBox msgBox = new OltListMessageBox(owner, messageOne, messageTwo, listItems, title, icon, showOkButtonInsteadOfYesNo);
            return ShowMessageBox(msgBox);
        }

        private static DialogResult ShowMessageBox(OltListMessageBox msgBox)
        {
            DialogResult result = msgBox.ShowDialog();
            msgBox.Dispose();
            return result;
        }

        private void ChooseIconForFormFromEnum(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    {
                        Icon = SystemIcons.Error;
                        break;
                    }
                case MessageBoxIcon.Information:
                    {
                        Icon = SystemIcons.Information;
                        break;
                    }
                case MessageBoxIcon.Question:
                    {
                        Icon = SystemIcons.Question;
                        break;
                    }
                case MessageBoxIcon.Warning:
                    {
                        Icon = SystemIcons.Warning;
                        break;
                    }
                default:
                    {
                        Icon = SystemIcons.WinLogo;
                        break;
                    }
            }
        }

        private void HandleMainPanelPaint(object sender, PaintEventArgs e)
        {
            if (Icon != null)
            {
                e.Graphics.DrawIcon(Icon, new Rectangle(panelIcon.Location, new Size(32, 32)));
            }
        }

    }
}
