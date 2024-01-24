using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class GridAndDetailsForm : BaseForm, IGridAndDetailsView
    {
        public event Action AcceptButtonClicked;
        public event Action NewButtonClicked;

        public GridAndDetailsForm()
        {
            InitializeComponent();
            ButtonsVisible = false;

            newButton.Visible = false;

            cancelButton.Click += CancelButton_Click;
            acceptButton.Click += AcceptButton_Click;
            newButton.Click += NewButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (AcceptButtonClicked != null)
            {
                AcceptButtonClicked();
            }
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            if (NewButtonClicked != null)
            {
                NewButtonClicked();
            }
        }

        public string Title
        {
            get { return Text; }           //ayman Sarnia eip DMND0008992
            set { Text = value; }
        }

        public bool NewButtonVisible
        {
            set { newButton.Visible = value; }
        }

        public bool ButtonsVisible
        {
            set { buttonsPanel.Visible = value; }
        }

        public string AcceptButtonText
        {
            set { acceptButton.Text = value; }
        }

        public IDetails Details
        {
            set
            {
                Control control = (Control) value;
                mainPanel.Controls.Add(control);
                value.Dock = DockStyle.Fill;
            }
        }

        public Control GridAndDetails
        {
            set
            {
                mainPanel.Controls.Add(value);
                value.Dock = DockStyle.Fill;
            }
        }
    }
}