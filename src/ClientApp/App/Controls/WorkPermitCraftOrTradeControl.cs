using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitCraftOrTradeControl : UserControl
    {
        public WorkPermitCraftOrTradeControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        public List<CraftOrTrade> SystemCraftOrTradeChoices
        {
            get { return (List<CraftOrTrade>) systemCraftOrTradeComboBox.DataSource;}
            set
            {
                systemCraftOrTradeComboBox.DisplayMember = "Name";
                systemCraftOrTradeComboBox.DataSource = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ICraftOrTrade WorkPermitCraftOrTrade
        {
            get
            {
                if (userSpecifiedTypeRadioButton.Checked)
                    return new UserSpecifiedCraftOrTrade(userSpecifiedCraftOrTradeTextBox.Text.Trim());
                
                return (ICraftOrTrade) systemCraftOrTradeComboBox.SelectedItem;
            }
            set
            {
                value.PerformAction(() =>
                                        {
                                            ToggleInputBoxEnabled = false;
                                            systemTypeRadioButton.Checked = true;
                                            systemCraftOrTradeComboBox.SelectedItem = value;
                                            userSpecifiedCraftOrTradeTextBox.Text = string.Empty;
                                        },
                                    () =>
                                        {
                                            ToggleInputBoxEnabled = true;
                                            userSpecifiedTypeRadioButton.Checked = true;
                                            userSpecifiedCraftOrTradeTextBox.Text = value.Name;
                                            systemCraftOrTradeComboBox.SelectedItem = CraftOrTrade.EMPTY;
                                        });
            }
        }

        public int MaxLength
        {
            get { return userSpecifiedCraftOrTradeTextBox.MaxLength; }
            set { userSpecifiedCraftOrTradeTextBox.MaxLength = value; }
        }

        // TODO: Remove this when we can search for controls by name.
        public OltTextBox UserSpecifiedTextBox
        {
            get
            {
                return userSpecifiedCraftOrTradeTextBox;
            }
        }

        private void typeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ToggleInputBoxEnabled = userSpecifiedTypeRadioButton.Checked;
        }

        public bool ToggleInputBoxEnabled
        {
            set
            {
                systemCraftOrTradeComboBox.Enabled = !value;
                userSpecifiedCraftOrTradeTextBox.Enabled = value;
            }
        }

        public bool EnableRadio
        {
            set
            {
                userSpecifiedTypeRadioButton.Enabled = value;
                systemTypeRadioButton.Enabled = value;
            }
        }
    }
}