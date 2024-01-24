using System;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client
{
    /// <summary>
    /// Helps with situation where a textbox is enabled only if a corresponding
    /// checkbox is checked.
    /// </summary>
    public class CheckBoxEnabledTextBoxHelper
    {
        protected readonly OltCheckBox checkBox;
        protected readonly OltTextBox textBox;

        public CheckBoxEnabledTextBoxHelper(OltCheckBox checkBox, OltTextBox textBox)
        {
            this.checkBox = checkBox;
            this.textBox = textBox;

            checkBox.CheckedChanged += HandleCheckedChanged;
        }

        protected virtual void HandleCheckedChanged(object sender, EventArgs e)
        {
            textBox.Enabled = checkBox.Checked;
            if (checkBox.Checked == false)
            {
                textBox.Text = string.Empty;
            }
        }

        public virtual string Text
        {
            get
            {
                return textBox.Enabled ? textBox.Text : null;
            }
            set
            {
                if (value.IsNullOrEmptyOrWhitespace())
                {
                    textBox.Text = string.Empty;
                    textBox.Enabled = false;
                    checkBox.Checked = false;
                }
                else
                {
                    textBox.Text = value;
                    textBox.Enabled = true;
                    checkBox.Checked = true;
                }
            }
        }

        public int MaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        public bool CheckBoxChecked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }
    }

    public class AdditionalCheckBoxEnabledTextBoxHelper : CheckBoxEnabledTextBoxHelper
    {
        public AdditionalCheckBoxEnabledTextBoxHelper(OltCheckBox checkBox, OltTextBox textBox) : base(checkBox, textBox)
        {
        }

        protected override void HandleCheckedChanged(object sender, EventArgs e)
        {
            textBox.Enabled = checkBox.Checked;
            if (checkBox.Checked == false)
            {
                textBox.Text = string.Empty;
            }
        }

        // Unlike CheckBoxEnabledTextBoxHelper, we don't want to uncheck the checkbox if the text value is null or empty.
        //   It is valid to have the the value checked without supplying textual details.
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value.HasValue())
                {
                    textBox.Text = value;
                    textBox.Enabled = true;
                }
                else if (checkBox.Checked == false )
                {
                    textBox.Enabled = false;
                }
            }
        }
    }
}