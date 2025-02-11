﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Template;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Utilities
{
    public class PermitFormHelper
    {
        public static List<string> GetABCDSelectionList()
        {
            return new List<string>
            {
                WorkPermitEdmonton.A,
                WorkPermitEdmonton.B,
                WorkPermitEdmonton.C,
                WorkPermitEdmonton.C1, //Added By Vibhor : RITM0556615 - OLT Edmonton Work Permit Change
                WorkPermitEdmonton.D
                
            };
        }

        public static List<string> GetConfinedSpaceClassSelectionList()
        {
            return new List<string>
            {
                WorkPermitEdmonton.ConfinedSpaceLevel1,
                WorkPermitEdmonton.ConfinedSpaceLevel2,
                WorkPermitEdmonton.ConfinedSpaceLevel3
            };
        }

        public static List<string> Get12SelectionList()
        {
            return new List<string> {"1", "2"};
        }

        public static List<string> GetAreasAffectedList()
        {
            return new List<string> {"Heavy Oils", "Light Oils", "Synthetic Oils", "Utilities", "Pumping & Shipping"};
        }

        public static List<string> GetLubesConfinedSpaceClassList()
        {
            return new List<string> {"Acceptable Atmospheric Levels", "Containing Atmospheric Hazards"};
        }

        public static string GetTextBoxValue(TextBox textBox, CheckBox checkBox)
        {
            if (!checkBox.Checked)
            {
                return null;
            }

            return textBox.Text.EmptyToNull();
        }

        public static void SetTextBoxValue(string value, TextBox textBox, CheckBox checkBox)
        {
            if (value != null)
            {
                checkBox.Checked = true;
            }

            textBox.Text = value;
        }

        public static int? GetIntegerTextBoxValue(OltIntegerBox textBox, CheckBox checkBox)
        {
            if (!checkBox.Checked)
            {
                return null;
            }

            return textBox.IntegerValue;
        }

        public static void SetIntegerTextBoxValue(int? value, OltIntegerBox textBox, CheckBox checkBox)
        {
            if (value != null)
            {
                checkBox.Checked = true;
            }

            textBox.IntegerValue = value;
        }

        public static string GetTextComboBoxValue(ComboBox comboBox, CheckBox checkBox)
        {
            if (!checkBox.Checked)
            {
                return null;
            }

            return comboBox.Text.EmptyToNull();
        }

        public static void SetTextComboBoxValue(string value, ComboBox comboBox, CheckBox checkBox)
        {
            if (value != null)
            {
                checkBox.Checked = true;
            }

            comboBox.Text = value;
        }

        public static EdmontonPermitSpecialWorkType GetSpecialWorkTypeComboBoxValue(ComboBox comboBox, CheckBox checkBox)
        {
            if (!checkBox.Checked)
            {
                return null;
            }

            return (EdmontonPermitSpecialWorkType) comboBox.SelectedItem;
        }

        public static void SetSpecialWorkTypeComboBoxValue(EdmontonPermitSpecialWorkType value, ComboBox comboBox,
            CheckBox checkBox)
        {
            if (value != null)
            {
                checkBox.Checked = true;
            }

            comboBox.SelectedItem = value;
        }

        public static Time GetTimePickerValue(OltTimePicker timePicker, CheckBox checkBox)
        {
            if (!checkBox.Checked)
            {
                return null;
            }

            return timePicker.Value;
        }

        public static void SetTimePickerValue(Time value, OltTimePicker timePicker, CheckBox checkBox)
        {
            checkBox.Checked = value != null;
            timePicker.Value = value;
        }

        public static void SetTimePickerValue(Time value, Time defaultIfNull, OltTimePicker timePicker,
            CheckBox checkBox)
        {
            if (value == null)
            {
                checkBox.Checked = false;
                timePicker.Value = defaultIfNull;
            }
            else
            {
                checkBox.Checked = true;
                timePicker.Value = value;
            }
        }

        public static void CheckBoxCheckChanged(object sender, EventArgs e)
        {
            var checkBox = (OltCheckBox) sender;
            var panel = (Panel) checkBox.Parent;
            SetEnabledOnChildComboAndTextBoxes(panel, checkBox.Checked);
        }

        private static void SetEnabledOnChildComboAndTextBoxes(Panel panel, bool isEnabled)
        {
            foreach (Control childControl in panel.Controls)
            {
                var comboBox = childControl as ComboBox;
                var textBox = childControl as TextBox;

                if (comboBox != null)
                {
                    comboBox.Enabled = isEnabled;
                }
                else if (textBox != null)
                {
                    textBox.ReadOnly = !isEnabled;
                }
            }
        }

        public static void SetupSectionNotApplicableToJob(CheckBox checkBox, Control parentControl)
        {
            checkBox.Checked = false;
            checkBox.CheckedChanged += (sender, args) => parentControl.SetEnableOnAllChildControls(!checkBox.Checked);
        }

        public static bool GetCheckBoxValueForSection(CheckBox checkBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return false;
            }
            return checkBox.Checked;
        }

        public static void SetCheckBoxValueForSection(bool value, CheckBox checkBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            checkBox.Checked = value;
            if (value)
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        public static string GetTextBoxValueForSection(TextBox textBox, CheckBox checkBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return null;
            }

            return GetTextBoxValue(textBox, checkBox);
        }

        public static void SetTextBoxValueForSection(string value, TextBox textBox, CheckBox checkBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            SetTextBoxValue(value, textBox, checkBox);
            if (checkBox.Checked)
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        public static TernaryString GetTernaryStringValueForSection(TemplatableStringControl templatableStringControl,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return new TernaryString(false, null);
            }
            return templatableStringControl.Value.Value;
        }

        public static void SetTernaryStringValueForSection(TernaryString value,
            TemplatableStringControl templatableStringControl, CheckBox sectionNotApplicableToJobCheckBox)
        {
            templatableStringControl.Value = new Visible<TernaryString>(VisibleState.Visible, value);
            if (value.StateAsBool)
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        public static void HandlePermitTypeSelectedValueChanged(OltComboBox permitTypeComboBox, OltCheckBox gn59CheckBox,
            OltTextBox gn59FormNumberTextBox, OltComboBox groupComboBox)
        {
            var selectedValue = (WorkPermitEdmontonType) permitTypeComboBox.SelectedValue;
            var selectedGroup = (WorkPermitEdmontonGroup) groupComboBox.SelectedValue;
            if (selectedValue != null && selectedValue.Equals(WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK) &&
              (selectedGroup!=null &&  !selectedGroup.Name.ToLower().Contains("turnaround")))
            {
                gn59CheckBox.Checked = true;
                gn59CheckBox.Enabled = false;
            }
            else
            {
                gn59CheckBox.Enabled = true;
            }
        }

        public static void SetOtherAreasAndOrUnitsAffected(string area, string personNotified,
            OltRadioButton noButton, OltRadioButton yesButton, Control areaTextBox, Control personNotifiedTextBox)
        {
            if (area == null && personNotified == null)
            {
                noButton.Checked = true;
                yesButton.Checked = false;
                areaTextBox.Text = string.Empty;
                personNotifiedTextBox.Text = string.Empty;
            }
            else
            {
                yesButton.Checked = true;
                noButton.Checked = false;
                areaTextBox.Text = area;
                personNotifiedTextBox.Text = personNotified;
            }
        }

        public static YesNoNotApplicable GetYesNoNotApplicableComboBoxValueForSection(ComboBox comboBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return YesNoNotApplicable.FindForValue(null);
            }
            var selectedItem = (YesNoNotApplicable) comboBox.SelectedItem;
            return selectedItem;
        }

        public static void SetYesNoNotApplicableComboBoxValueForSection(YesNoNotApplicable value, ComboBox comboBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            comboBox.SelectedItem = value;
            if (!YesNoNotApplicable.NOT_APPLICABLE.Equals(comboBox.SelectedItem))
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        public static string GetTextBoxValueForSection(TextBox textBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return null;
            }
            return textBox.Text.EmptyToNull();
        }

        public static void SetTextBoxValueForSection(string value, TextBox textBox,
            CheckBox sectionNotApplicableToJobCheckBox)
        {
            textBox.Text = value;
            if (!value.IsNullOrEmptyOrWhitespace())
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        public static void SortCraftOrTrades(List<CraftOrTrade> craftOrTrades)
        {
            craftOrTrades.Sort(delegate(CraftOrTrade craftOrTradeA, CraftOrTrade craftOrTradeB)
            {
                var a = craftOrTradeA.Name ?? string.Empty;
                var b = craftOrTradeB.Name ?? string.Empty;
                return a.CompareTo(b);
            });
        }
        public static string GetTextBoxValueForSection(OltSpellCheckTextBox textBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return null;
            }
            return textBox.Text.EmptyToNull();
        }
        public static void SetTextBoxValueForSection(string value, OltSpellCheckTextBox textBox,
           CheckBox sectionNotApplicableToJobCheckBox)
        {
            textBox.Text = value;
            if (!value.IsNullOrEmptyOrWhitespace())
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }
        public static string GetTextComboBoxValueIfNotChecked(ComboBox comboBox, CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                return null;
            }

            return comboBox.Text.EmptyToNull();
        }

        public static void HandleLockBoxNumberOnCheckedChanged(OltCheckBox LockBoxNubmer, OltCheckBox PartEWorkSectionNotApplicableToJobCheckBox)
        {
            var selectedValue = (bool)LockBoxNubmer.Checked;

            if (selectedValue)
            {
                PartEWorkSectionNotApplicableToJobCheckBox.Checked = false;
                PartEWorkSectionNotApplicableToJobCheckBox.Enabled = false;

            }
            else
            {
                PartEWorkSectionNotApplicableToJobCheckBox.Enabled = true; 
            }
        }
       
    }
}