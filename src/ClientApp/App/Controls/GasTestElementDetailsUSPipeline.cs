using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementDetailsUSPipeline : UserControl, IGasTestElementDetails
    {
        private bool isStandard;

        internal GasTestElementDetailsUSPipeline()
        {
            InitializeComponent();
            IsStandard = false;            
            GasTestElementInfoId = null;
        }

        public GasTestElementDetailsUSPipeline(GasTestElementInfo info): this()
        {
            IsStandard = info.IsStandard;
            ElementName = info.Name;            
            GasTestElementInfoId = info.Id;
            Limits = string.Empty;
            Name = info.Name + "Details";
            LimitsMaxLength = 50;
            NameMaxLength = 50;
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
            systemEntryResultWarningProvider.Clear();
        }
        
        public void SetImmediateAreaResultWarningMessage(string warningMessage)
        {
            immediateAreaResultWarningProvider.SetError(immediateAreaTestResultNumericBox, warningMessage);
        }
        

        public void SetConfinedSpaceTestResultWarningMessage(string warningMessage)
        {
            confinedSpaceResultWarningProvider.SetError(confinedSpaceTestResultNumericBox, warningMessage);
        }

        public void SetSystemEntryTestResultWarningMessage(string warningMessage)
        {
            systemEntryResultWarningProvider.SetError(systemEntryTestResultNumericBox, warningMessage);
        }


        public bool ConfinedSpaceTestRequired
        {
            get { return ImmediateAreaTestRequired; }
            set { /* There is no checkbox applicable for USPipeline */ }
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

        public string Limits
        {
            get { return limitsTextBox.Text; }
            set { limitsTextBox.Text = value;}
        }

        public bool ImmediateAreaTestRequired
        {
            get { return false; }
            set { }
        }
        public bool SystemEntryTestNotApplicable
        {
            get { return false; }
            set { }
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

        public double? SystemEntryTestResult
        {
            get
            {
                if (systemEntryTestResultNumericBox.Value == DBNull.Value) return null;
                return (double?)systemEntryTestResultNumericBox.Value;                
            }
            set
            {
                systemEntryTestResultNumericBox.Value = value;
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

        // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

        public bool ConfinedSpaceTestRequiredEnabledDisabled
        {
            get;
            set; 
        }

        public bool ImmediateAreaTestRequiredEnabledDisabled
        {
            get;
            set; 
        }
        
        public void SetConfinedSpaceTestResultAlertMessage(string message)
        {
            
        }
        public void SetImmediateAreaResultAlertMessage(string message)
        {
            
        }

        public string ElementNameOther
        {
            get;
            set;
        }

        //END
    }
}
