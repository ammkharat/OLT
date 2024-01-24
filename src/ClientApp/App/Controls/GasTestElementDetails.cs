using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementDetails : UserControl, IGasTestElementDetails
    {
        private bool isStandard;
        private bool isImmediateAreaActive;
        private bool isConfinedSpaceActive;

        public event EventHandler ImmediateAreaRequiredTestChanged;
        public event EventHandler ConfinedSpaceTestRequiredChanged;

        internal GasTestElementDetails()
        {
            InitializeComponent();
            IsStandard = false;
            ImmediateAreaTestRequired = false;
            GasTestElementInfoId = null;
            requiredCheckBox.CheckedChanged += requiredCheckBox_CheckedChanged;
            confinedSpaceRequiredCheckBox.CheckedChanged += confinedSpaceRequiredCheckBox_CheckedChanged;
        }

        public GasTestElementDetails(GasTestElementInfo info): this()
        {
            IsStandard = info.IsStandard;
            ElementName = info.Name;
            ElementNameOther = info.Name; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            GasTestElementInfoId = info.Id;
            Limits = string.Empty;
            Name = info.Name + "Details";
            LimitsMaxLength = 50;
            NameMaxLength = 50;
        }

        private void requiredCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnImmediateAreaTestRequiredChanged(requiredCheckBox.Checked);
        }

        private void confinedSpaceRequiredCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnConfinedSpaceTestRequiredChanged(confinedSpaceRequiredCheckBox.Checked);
        }

        public long? GasTestElementInfoId { get; set; }

        public int NameMaxLength
        {
            get { return elementNameTextBox.MaxLength; }
            set { elementNameTextBox.MaxLength = value; }
        }

        private int LimitsMaxLength
        {
            set { limitsTextBox.MaxLength = value; }
        }
        
        public void ClearWarningMessages()
        {
            immediateAreaResultWarningProvider.Clear();
            confinedSpaceResultWarningProvider.Clear();
            confinedSpaceResultAlertProvider.Clear();
            immediateAreaResulAlertProvider.Clear();
        }
        
        public void SetImmediateAreaResultWarningMessage(string warningMessage)
        {
            immediateAreaResultWarningProvider.SetError(immediateAreaTestResultNumericBox, warningMessage);
        }
        
        public void SetConfinedSpaceTestResultWarningMessage(string warningMessage)
        {
            confinedSpaceResultWarningProvider.SetError(confinedSpaceTestResultNumericBox, warningMessage);
        }
        public void SetConfinedSpaceTestResultAlertMessage(string alertMessage)     // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            confinedSpaceResultAlertProvider.SetError(confinedSpaceTestResultNumericBox, alertMessage);
        }

        public void SetImmediateAreaResultAlertMessage(string alertMessage)     // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            immediateAreaResulAlertProvider.SetError(immediateAreaTestResultNumericBox, alertMessage);
        }
        
        public bool IsStandard
        {
            get { return isStandard; }
            set
            {
                isStandard = value;
                limitsTextBox.Enabled = !isStandard;

                elementNameLabel.Dock = DockStyle.Left;
                elementNameTextBox.Visible = !isStandard;
            }
        }

        private bool IsActive
        {
            get { return isImmediateAreaActive || isConfinedSpaceActive; }
        }

        public string ElementName
        {
            get
            {
                return isStandard == false ? elementNameTextBox.Text : elementNameLabel.Text;
            }
            set
            {
                if (isStandard)
                {                    
                    elementNameLabel.Text = value;
                }
                else
                {
                    elementNameTextBox.Text = value;
                    elementNameLabel.Text = StringResources.Other;
                    
                }
                
            }
        }

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        public string ElementNameOther
        {
            get
            {
                return isStandard == false ? elementNameTextBox.Text : elementNameLabel.Text;
            }
            set
            {
                if (isStandard)
                {
                    elementNameLabel.Text = value;
                }
                else
                {
                    elementNameTextBox.Text = value;
                    elementNameLabel.Text = StringResources.Other;
                }
            }
        }
        //END

        public string Limits
        {
            get { return limitsTextBox.Text; }
            set { limitsTextBox.Text = value;}
        }

        public bool ImmediateAreaTestRequired
        {
            get { return requiredCheckBox.Checked; }
            set
            {
                requiredCheckBox.Checked = value;
                OnImmediateAreaTestRequiredChanged(value);
            }
        }

        public bool ImmediateAreaTestRequiredEnabledDisabled       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return requiredCheckBox.Enabled; }
            set
            {
                requiredCheckBox.Enabled = value;
                
            }
        }

        public bool ConfinedSpaceTestRequired
        {
            get { return confinedSpaceRequiredCheckBox.Checked; }
            set
            {
                confinedSpaceRequiredCheckBox.Checked = value;
                OnConfinedSpaceTestRequiredChanged(value);
            }
        }

        public bool ConfinedSpaceTestRequiredEnabledDisabled    // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
        {
            get { return confinedSpaceRequiredCheckBox.Enabled; }
            set
            {
                confinedSpaceRequiredCheckBox.Enabled = value;
                
            }
        }

        private void OnImmediateAreaTestRequiredChanged(bool value)
        {
            isImmediateAreaActive = value;
            SetGenericControlState();

            immediateAreaTestResultNumericBox.Enabled = value;
            if (value == false)
            {
                ImmediateAreaTestResult = null;
            }

            RaiseImmediateAreaTestChangedEvent();
        }

        private void OnConfinedSpaceTestRequiredChanged(bool value)
        {
            isConfinedSpaceActive = value;
            SetGenericControlState();

            confinedSpaceTestResultNumericBox.Enabled = value;
            if (value == false)
            {
                ConfinedSpaceTestResult = null;
            }

            RaiseConfinedSpaceTestRequiredEvent();
        }

        public double? ImmediateAreaTestResult
        {
            get
            {
                if (immediateAreaTestResultNumericBox.Value == DBNull.Value) return null;
                return (double?)immediateAreaTestResultNumericBox.Value;           
            }
            set
            {
                immediateAreaTestResultNumericBox.Value = value;
            }
        }

        public double? ConfinedSpaceTestResult
        {
            get
            {
                if (confinedSpaceTestResultNumericBox.Value == DBNull.Value) return null;
                return (double?)confinedSpaceTestResultNumericBox.Value;
            }
            set
            {
                confinedSpaceTestResultNumericBox.Value = value;
            }
        }

        private void SetGenericControlState()
        {
            if (!isStandard)
            {
                elementNameTextBox.Enabled = IsActive;
                limitsTextBox.Enabled = IsActive;
            }
            else
            {
                limitsTextBox.Enabled = false;
            }
        }

        protected void RaiseImmediateAreaTestChangedEvent()
        {
            if (ImmediateAreaRequiredTestChanged != null)
            {
                ImmediateAreaRequiredTestChanged(this, EventArgs.Empty);
            }
        }

        protected void RaiseConfinedSpaceTestRequiredEvent()
        {
            if (ConfinedSpaceTestRequiredChanged != null)
            {
                ConfinedSpaceTestRequiredChanged(this, EventArgs.Empty);
            }
        }

        public double? SystemEntryTestResult
        {
            get { return null; }
            set { }
        }

        public bool SystemEntryTestNotApplicable
        {
            get { return true; }
            set { }
        }

        public void SetSystemEntryTestResultWarningMessage(string range)
        {
            // Not applicable for Sarnia.        
        }


        private void limitsTextBox_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (!isStandard && elementNameLabel.Text == StringResources.Other && ImmediateAreaTestRequired == true && limitsTextBox.Text != "" ) 
            {
                
                const string maxTwoDecimalPlaceNumberPattern = @"^-{0,1}\d+\.{0,1}\d*$";
                Regex r = new Regex(maxTwoDecimalPlaceNumberPattern);
                Match m = r.Match(limitsTextBox.Text);
                if (m.Success)
                {
                    
                }
                else
                {
                    OltMessageBox.Show(Form.ActiveForm, "Characters are not allowed to Enter in the Limit Box.","Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                    limitsTextBox.Clear();
                    flag = true;

                }
            }

            if (!isStandard && elementNameLabel.Text == StringResources.Other && ConfinedSpaceTestRequired == true && limitsTextBox.Text != "" && flag != true)
            {
                const string maxTwoDecimalPlaceNumberPattern = @"^-{0,1}\d+\.{0,1}\d*$";
                Regex r = new Regex(maxTwoDecimalPlaceNumberPattern);
                Match m = r.Match(limitsTextBox.Text);
                if (m.Success)
                {
                    
                }
                else
                {
                    OltMessageBox.Show(Form.ActiveForm, "Characters are not allowed to Enter in the Limit Box.","Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

                    limitsTextBox.Clear();

                }
            }

        }


        
    }
}
