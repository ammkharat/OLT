using System;
using System.Windows.Forms;
using RoleReport;

namespace TestTool
{
    public partial class RoleReportControl : UserControl
    {
        public RoleReportControl()
        {
            InitializeComponent();

            submitButton.Click += SubmitButton_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            domainTextBox.Text = "network.lan";
            pathTextBox.Text = "LDAP://network.lan/DC=network,DC=lan";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            Builder builder = new Builder(userNameTextBox.Text, passwordTextBox.Text, domainTextBox.Text, pathTextBox.Text);

            if (allRadioButton.Checked)
            {
                builder.Build();
                MessageBox.Show(this, "Success!");
            }
            else
            {
                string results = builder.Build(singleUserNameTextBox.Text);
                outputTextBox.Text = results;
            }
        }
    }
}
