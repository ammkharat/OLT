using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public partial class TemplatableStringControl : UserControl, ITriStateTextControl
    {
        private IStringControlMode mode;

        public TemplatableStringControl()
        {
            InitializeComponent();
            mode = new StringControlUserMode(this);
            textBox.TextChanged += TextBoxTextChanged;
            checkBox.CheckedChanged += CheckBoxCheckChanged;
        }

        [Browsable(true)]
        public string Label
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        [Browsable(true)]
        public int TextBoxWidth
        {
            get { return textBox.Width; }
            set { textBox.Width = value; }
        }

        [Browsable(true)]
        public int TextBoxMaxLength
        {
            get { return textBox.MaxLength; }
            set { textBox.MaxLength = value; }
        }

        void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text) && !checkBox.Checked)
            {
                checkBox.Checked = true;
            }
            else if (string.IsNullOrEmpty(textBox.Text) && checkBox.Checked)
            {
                checkBox.Checked = false;
            }
        }

        private void CheckBoxCheckChanged(object sender, EventArgs e)
        {
            if(!checkBox.Checked)
            {
                ClearText();
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool TemplateMode
        {
            set
            {
                if (value)
                {
                    mode = new StringControlTemplateMode(this);
                }
                else
                {
                    mode = new StringControlUserMode(this);
                }
            }
            get
            {
                return mode.GetType() == typeof(StringControlTemplateMode);
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            mode.VisibleClick();
        }

        public void ShowTemplateIcon(bool show)
        {
            pictureBox.Visible = show;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool Checked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }

        public void ClearText()
        {
            textBox.TextChanged -= TextBoxTextChanged;
            textBox.Clear();
            textBox.TextChanged += TextBoxTextChanged;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Image TemplateIcon
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Visible<TernaryString> Value
        {
            get { return mode.Value; }
            set { mode.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool EnableControl
        {
            set
            {
                checkBox.Enabled = value;
                textBox.Enabled = value;
            }
        }

        public override string Text
        {
            get { return textBox.Text; }
            set
            {
                textBox.TextChanged -= TextBoxTextChanged;
                textBox.Text = value;
                textBox.TextChanged += TextBoxTextChanged;
            }
        }

        public void SetError(ErrorProvider errorProvider, string errorMessage)
        {
            errorProvider.SetIconAlignment(textBox, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetError(textBox, errorMessage);
        }
    }
}
