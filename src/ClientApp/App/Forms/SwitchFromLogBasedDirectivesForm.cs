using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SwitchFromLogBasedDirectivesForm : BaseForm, ISwitchFromLogBasedDirectivesView
    {
        public event Action FormLoad;
        public event Action AcceptCheckboxChanged;
        public event Action ContinueClicked;

        public SwitchFromLogBasedDirectivesForm()
        {
            InitializeComponent();

            acceptCheckBox.CheckedChanged += (sender, args) => AcceptCheckboxChanged();
            continueButton.Click += (sender, args) => ContinueClicked();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FormLoad();
        }

        public string SiteName
        {
            set { explanationLabel.Text = String.Format(explanationLabel.Text, value); }
        }

        public bool ContinueButtonEnabled
        {
            set { continueButton.Enabled = value; }
        }

        public bool AcceptChecked
        {
            get { return acceptCheckBox.Checked; }
        }

        
    }
}
