using System;
using System.Linq;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureHoneywellPhdForm : BaseForm, IConfigureHoneywellPhdView
    {
        public ConfigureHoneywellPhdForm()
        {
            InitializeComponent();
            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;
        }

        public event Action SaveButtonClick;
        public event Action CancelButtonClick;

        public bool IsSqlServer
        {
            get { return sqlServerRadioButton.Checked; }
            set { sqlServerRadioButton.Checked = value; }
        }

        public bool IsOracle
        {
            get { return oracleRadioButton.Checked; }
            set { oracleRadioButton.Checked = value; }
        }

        public string OracleUsername
        {
            get { return oracleUserTextBox.Text; }
            set { oracleUserTextBox.Text = value; }
        }

        public string OraclePassword
        {
            get { return oraclePasswordTextBox.Text; }
            set { oraclePasswordTextBox.Text = value; }
        }

        public string OracleHost
        {
            get { return oracleHostTextBox.Text; }
            set { oracleHostTextBox.Text = value; }
        }

        public string OracleServiceName
        {
            get { return oracleServiceNameTextBox.Text; }
            set { oracleServiceNameTextBox.Text = value; }
        }

        public string SqlServerUsername
        {
            get { return sqlServerUserTextBox.Text; }
            set { sqlServerUserTextBox.Text = value; }
        }

        public string SqlServerPassword
        {
            get { return sqlServerPasswordTextBox.Text; }
            set { sqlServerPasswordTextBox.Text = value; }
        }

        public string SqlServerHost
        {
            get { return sqlServerDataSourceTextBox.Text; }
            set { sqlServerDataSourceTextBox.Text = value; }
        }

        public string SqlServerInstance
        {
            get { return sqlServerInitialCatalogTextBox.Text; }
            set { sqlServerInitialCatalogTextBox.Text = value; }
        }

        public bool UseWindowsAuthentication
        {
            get { return authenticationWindowsRadioButton.Checked; }
            set
            {
                if (value)
                {
                    authenticationWindowsRadioButton.Checked = true;
                }
                else
                {
                    authenticationExplicitRadioButton.Checked = true;
                }
            }
        }

        public string PhdUsername
        {
            get { return phdUsernameTextBox.Text; }
            set { phdUsernameTextBox.Text = value; }
        }

        public string PhdPassword
        {
            get { return phdPasswordTextBox.Text; }
            set { phdPasswordTextBox.Text = value; }
        }

        public string PhdServer
        {
            get { return phdServerTextBox.Text; }
            set { phdServerTextBox.Text = value; }
        }

        public string ApiVersion
        {
            get { return (string) phdApiVersionComboBox.SelectedItem; }
            set { phdApiVersionComboBox.SelectedItem = value; }
        }

        public int? StartTimeOffset
        {
            get { return startTimeNumericBox.IntegerValue; }
            set { startTimeNumericBox.IntegerValue = value; }
        }

        public int? EndTimeOffset
        {
            get { return endTimeNumericBox.IntegerValue; }
            set { endTimeNumericBox.IntegerValue = value; }
        }

        public string DataSamplingType
        {
            get { return (string) dataSamplingTypeComboBox.SelectedItem; }
            set { dataSamplingTypeComboBox.SelectedItem = value; }
        }

        public int? DataSamplingFrequency
        {
            get { return dataSamplingFrequencyNumericBox.IntegerValue; }
            set { dataSamplingFrequencyNumericBox.IntegerValue = value; }
        }

        public string DataReductionType
        {
            get { return (string) dataReductionTypeComboBox.SelectedItem; }
            set { dataReductionTypeComboBox.SelectedItem = value; }
        }

        public int? DataReductionFrequency
        {
            get { return dataReductionFrequencyNumericBox.IntegerValue; }
            set { dataReductionFrequencyNumericBox.IntegerValue = value; }
        }

        public string DataReductionOffset
        {
            get { return (string) dataReductionOffsetComboBox.SelectedItem; }
            set { dataReductionOffsetComboBox.SelectedItem = value; }
        }

        public int MinimimConfidence
        {
            get { return minimumConfidenceNumericBox.IntegerValue.GetValueOrDefault(0); }
            set { minimumConfidenceNumericBox.IntegerValue = value; }
        }

        public string PiUsername
        {
            get { return piUsernameTextBox.Text; }
            set { piUsernameTextBox.Text = value; }
        }

        public string PiPassword
        {
            get { return piPasswordTextBox.Text; }
            set { piPasswordTextBox.Text = value; }
        }

        public string PiServer
        {
            get { return piServerTextBox.Text; }
            set { piServerTextBox.Text = value; }
        }

        public void ShowPiElements()
        {
            piDbConnectionInfoGroupBox.Visible = true;
            PhdConnectionInfoGroupBox.Visible = false;
            phdFetchSettingsGroupBox.Visible = true;                       //ayman Pi change
            plantHistorianConnectionInfoGroupBox.Visible = false;
            testConfigurationGroupBox.Visible = false;

            //ayman pi disable some controls
            startTimeNumericBox.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label19.Visible = false;
            endTimeNumericBox.Visible = false;
            dataSamplingFrequencyNumericBox.Visible = false;
            label25.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label26.Visible = false;
            dataReductionTypeComboBox.Visible = false;
            dataReductionFrequencyNumericBox.Visible = false;
            dataReductionOffsetComboBox.Visible = false;
            minimumConfidenceNumericBox.Visible = false;
            phdFetchSettingsGroupBox.Height = 123;

            dataSamplingTypeComboBox.Top = dataSamplingTypeComboBox.Top - 30;
            label18.Top = label18.Top - 30;
            label24.Top = label24.Top - 30;
            phdFetchSettingsGroupBox.Text = "PI Fetch Settings";
            this.dataSamplingTypeComboBox.Items.Clear();
            this.dataSamplingTypeComboBox.Items.AddRange(new object[] {
            "Average",
            "Mean",
            "Snapshot"});
            this.dataSamplingTypeComboBox.SelectedText = dataSamplingTypeComboBox.Items[0].ToString();
        }

        public void ShowPhdElements()
        {
            piDbConnectionInfoGroupBox.Visible = false;
            PhdConnectionInfoGroupBox.Visible = true;
            phdFetchSettingsGroupBox.Visible = true;
            plantHistorianConnectionInfoGroupBox.Visible = true;
            testConfigurationGroupBox.Visible = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveButtonClick != null)
            {
                SaveButtonClick();
            }
        }


        private void dbTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (oracleRadioButton.Checked)
            {
                oraclePanel.Visible = true;
                sqlServerPanel.Visible = false;
            }
            if (sqlServerRadioButton.Checked)
            {
                oraclePanel.Visible = false;
                sqlServerPanel.Visible = true;
            }
        }

        private void dataSamplingTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isRawDataSampling = Equals(dataSamplingTypeComboBox.SelectedItem, "Raw");

            dataSamplingFrequencyNumericBox.Enabled = !isRawDataSampling;
            dataReductionFrequencyNumericBox.Enabled = !isRawDataSampling;
            dataReductionOffsetComboBox.Enabled = !isRawDataSampling;
            dataReductionTypeComboBox.Enabled = !isRawDataSampling;

            if (isRawDataSampling)
            {
                dataReductionTypeComboBox.SelectedItem = "None";
            }
        }

        private void dataReductionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isNoneDataReduction = Equals(dataReductionTypeComboBox.SelectedItem, "None");

            dataReductionFrequencyNumericBox.Enabled = !isNoneDataReduction;
            dataReductionOffsetComboBox.Enabled = !isNoneDataReduction;
        }
    }
}