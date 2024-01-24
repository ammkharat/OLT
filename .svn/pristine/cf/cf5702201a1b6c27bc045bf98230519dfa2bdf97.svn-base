using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Resources;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public partial class BasePage : UserControl
    {
        public BasePage()
        {
            InitializeComponent();
            searchButton.Click += HandleSearchButtonClick;
            searchButton.Paint += HandleSearchButtonPaint;

            cancelSearchButton.Click += HandleCancelSearchButtonClick;
            cancelSearchButton.Paint += HandleCancelSearchButtonPaint;

            searchTextBox.KeyPress += HandleTextBoxKeyPress;
        }

        public string PageTitle
        {
            set
            {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        pageTitle.Text = value;
                        Text = value;
                    }));
                }
                else
                {
                    pageTitle.Text = value;
                    Text = value;
                }
            }
        }

        public int SplitterDistance
        {
            set { splitContainer.SplitterDistance = value; }
        }

        public event Action<string> SearchButtonClicked;
        public event Action CancelSearchButtonClicked;

        private void HandleTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                HandleSearchButtonClick(null, EventArgs.Empty);
            }
        }

        private void HandleSearchButtonPaint(object sender, PaintEventArgs e)
        {
            DrawTransparentImage(e, ResourceUtils.MAGNIFYING_GLASS);
        }

        private void HandleCancelSearchButtonPaint(object sender, PaintEventArgs e)
        {
            DrawTransparentImage(e, ResourceUtils.X);
        }

        private void DrawTransparentImage(PaintEventArgs e, Bitmap bmp)
        {
            bmp.MakeTransparent(Color.White);
            var x = (searchButton.Width - bmp.Width)/2;
            var y = (searchButton.Height - bmp.Height)/2;
            e.Graphics.DrawImage(bmp, x, y);
        }

        protected void AddComponents(Control grid, IDetails details)
        {
            grid.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(grid);

            details.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add((Control) details);
        }
        
        private void HandleSearchButtonClick(object sender, EventArgs e)
        {
            searchTextBox.BackColor = Color.LightBlue;

            if (SearchButtonClicked != null)
            {
                SearchButtonClicked(searchTextBox.Text);
            }
        }

        private void HandleCancelSearchButtonClick(object sender, EventArgs e)
        {
            ResetSearchTextBox();

            if (CancelSearchButtonClicked != null)
            {
                CancelSearchButtonClicked();
            }
        }

        public void ResetSearchTextBox()
        {
            searchTextBox.BackColor = Color.White;
            searchTextBox.Clear();
        }
    }
}