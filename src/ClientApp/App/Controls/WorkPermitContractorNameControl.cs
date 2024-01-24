using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitContractorNameControl : UserControl
    {
        private List<string> contractorNameList;
        private static readonly List<string> disabledList = new List<string>{ StringResources.Other };
        private static readonly string DEFAULT_CONTRACTOR = StringResources.NotApplicable;

        public WorkPermitContractorNameControl()
        {
            InitializeComponent();
            contractorListRadioButton.Click += HandleContractorListSelected;
            contractorTextFieldRadioButton.Click += HandleManualInputSelected;
        }

        private void HandleContractorListSelected(object sender, EventArgs args)
        {
            NameFieldEnabled = false;
            NameComboBoxEnabled = true;
            contractorNameTextBox.Text = string.Empty;
            contractorNameComboBox.DataSource = contractorNameList;
        }

        private void HandleManualInputSelected(object sender, EventArgs args)
        {
            contractorNameComboBox.DataSource = disabledList;
            NameComboBoxEnabled = false;
            NameFieldEnabled = true;
        }

        public List<Contractor> Contractors
        {
            set
            {
                contractorNameList = BuildContractorNameList(value);
                contractorNameList.Insert(0, DEFAULT_CONTRACTOR);
                contractorNameComboBox.DataSource = contractorNameList;
            }
        }

        private static List<string> BuildContractorNameList(List<Contractor> value)
        {            
            return value.ConvertAll(c => c.CompanyName);
        }

        public bool NameComboBoxEnabled
        {
            set { contractorNameComboBox.Enabled = value; }
        }

        public bool NameFieldEnabled
        {
            set { contractorNameTextBox.Enabled = value; }
        }

        public bool NameFieldIsSelected()
        {
            contractorNameComboBox.Enabled = false;

            return contractorTextFieldRadioButton.Checked;
        }

        public void SelectComboBoxForInput()
        {
            contractorNameTextBox.Enabled = false;
            contractorListRadioButton.Select();
        }

        public void SelectTextFieldForInput()
        {
            contractorNameComboBox.Enabled = false;
            contractorTextFieldRadioButton.Select();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string ContractorName
        {
            get
            {
                return GetName();
            }
            set
            {
                SetName(value);                                  
            }
        }

        private void SetName(string name)
        {
            if (name == null)
            {
                InitializeToDefaultState();
                return;
            }

            if (contractorNameComboBox.Items.Contains(name))
            {
                contractorNameComboBox.SelectedItem = name;
                SelectComboBoxForInput();
            }
            else
            {
                contractorNameTextBox.Text = name;
                SelectTextFieldForInput();
            }
        }

        private string GetName()
        {
            if (!contractorListRadioButton.Checked && !contractorTextFieldRadioButton.Checked)
                return null;
            
            if (contractorListRadioButton.Checked)
                return contractorNameComboBox.SelectedItem.ToString();

            return contractorNameTextBox.Text;
        }

        public void InitializeToDefaultState()
        {
            SelectComboBoxForInput();
        }
    }
}
