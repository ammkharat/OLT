using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Resources;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    // This shares code with BasePage. Common functionality should be shared somehow if possible.
    public partial class BaseMultiGridPage : UserControl
    {
        public event Action<string> SearchButtonClicked;
        public event Action CancelSearchButtonClicked;
        public event Action<IMultiGridContextSelection> SelectedGridChanged;

        public BaseMultiGridPage()
        {
            InitializeComponent();
            searchButton.Click += HandleSearchButtonClick;
            searchButton.Paint += HandleSearchButtonPaint;

            cancelSearchButton.Click += HandleCancelSearchButtonClick;
            cancelSearchButton.Paint += HandleCancelSearchButtonPaint;

            searchTextBox.KeyPress += HandleTextBoxKeyPress;
            
            gridSelectionComboBox.SelectedIndexChanged += HandleGridSelectionComboBoxSelectedIndexChanged;
            gridSelectionComboBox.KeyDown += HandleArrowKeyUpAndDown;
        }

        private void HandleArrowKeyUpAndDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void HandleGridSelectionComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedGridChanged((IMultiGridContextSelection)gridSelectionComboBox.SelectedItem);
        }
       
        public void AddNodeToSelectionList(IMultiGridContextSelection selection)
        {
            gridSelectionComboBox.Items.Add(selection);
            gridSelectionComboBox.DisplayMember = "Name";           
        }

        public void SetSelectedGridSelectionListNode(IMultiGridContextSelection selection)
        {
            gridSelectionComboBox.SelectedIndexChanged -= HandleGridSelectionComboBoxSelectedIndexChanged;
            gridSelectionComboBox.SelectedItem = selection;
            gridSelectionComboBox.SelectedIndexChanged += HandleGridSelectionComboBoxSelectedIndexChanged;         
        }
        
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
            int x = (searchButton.Width - bmp.Width) / 2;
            int y = (searchButton.Height - bmp.Height) / 2;
            e.Graphics.DrawImage(bmp, x, y);
        }

        protected void SetComponents(IDomainSummaryGrid grid, IDetails details)
        {
            Control gridControl = (Control)grid;
            gridControl.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Clear();
            splitContainer.Panel1.Controls.Add(gridControl);

            // The details shouldn't ever be null, but it was happening in early development and it doesn't hurt to leave the check in.
            if (details != null)
            {
                details.Dock = DockStyle.Fill;
                splitContainer.Panel2.Controls.Clear();
                splitContainer.Panel2.Controls.Add((Control) details);
            }
        }
     
        public string PageTitle
        {
            set
            {
                pageTitle.Text = value;
                Text = value;
            }
        }
        
        public int SplitterDistance
        {
            set { splitContainer.SplitterDistance = value; }
        }

        private void HandleSearchButtonClick(object sender, EventArgs e)
        {
            SetSearchTextBoxColourToSearchMode();

            if (SearchButtonClicked != null)
            {
                SearchButtonClicked(searchTextBox.Text);
            }
        }

        private void SetSearchTextBoxColourToSearchMode()
        {
            searchTextBox.BackColor = Color.LightBlue;
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

        public string SearchText
        {
            get { return searchTextBox.Text; }
            set
            {
                searchTextBox.Text = value;

                if (!string.IsNullOrEmpty(value))
                {
                    SetSearchTextBoxColourToSearchMode();
                }
            }
        }
        /*RITM0265746 - Sarnia CSD marked as read start*/
        public bool gridSelectionComboBoxVisible
        {
            set { gridSelectionComboBox.Visible = value; }
        }
        /*RITM0265746 - Sarnia CSD marked as read end*/
    }
}
