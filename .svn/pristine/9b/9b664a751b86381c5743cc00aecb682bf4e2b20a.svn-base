using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public partial class TemplatableDropDownControl : UserControl, ITriStateTextControl
    {
        public event Action<string> TextValueChanged;

        private IStringControlMode mode;

        public TemplatableDropDownControl()
        {
            InitializeComponent();
            mode = new StringControlUserMode(this);
            comboBox.TextChanged += ComboBoxTextChanged;
            checkBox.CheckedChanged += CheckChanged;
        }

        void ComboBoxTextChanged(object sender, EventArgs e)
        {
            string value = comboBox.Text;

            if (!string.IsNullOrEmpty(value) && !checkBox.Checked)
            {
                checkBox.Checked = true;
            }
            else if (string.IsNullOrEmpty(value) && checkBox.Checked)
            {
                checkBox.Checked = false;
            }

            if (TextValueChanged != null)
            {
                TextValueChanged(value);
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            if(!checkBox.Checked)
            {
                ClearText();
            }
        }

        [Browsable(true)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string Label
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Localizable(true), 
        Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)),
        MergableProperty(false) ]
        public new ComboBox.ObjectCollection Items
        {
            get { return comboBox.Items; }
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

        public void ShowTemplateIcon(bool show)
        {
            pictureBox.Visible = show;
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
        public bool Checked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }

        public void ClearText()
        {
            comboBox.TextChanged -= ComboBoxTextChanged;
            comboBox.Text = string.Empty;
            comboBox.TextChanged += ComboBoxTextChanged;
        }

        [Browsable(true)]
        [DefaultValue(125)]
        public int DropDownWidth
        {
            get
            {
                return comboBox.DropDownWidth;
            }
            set { 
                comboBox.DropDownWidth = value;
                Size size = comboBox.Size;
                size.Width = value;
                comboBox.Size = size;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Visible<TernaryString> Value
        {
            get { return mode.Value; }
            set
                {
                    mode.Value = value;
                }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            mode.VisibleClick();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool EnableControl
        {
            set {
                checkBox.Enabled = value;
                comboBox.Enabled = value;
            }
        }

        public override string Text
        {
            get { return comboBox.Text; }
            set
            {
                comboBox.TextChanged -= ComboBoxTextChanged;
                comboBox.Text = value;
                comboBox.TextChanged += ComboBoxTextChanged;
            }
        }

        public object DataSource
        {
            set { comboBox.DataSource = value; }
        }

        public string DisplayMember
        {
            set { comboBox.DisplayMember = value; }
        }

        public void SetError(ErrorProvider errorProvider, string errorMessage)
        {
            errorProvider.SetIconAlignment(comboBox, ErrorIconAlignment.MiddleLeft);
            errorProvider.SetError(comboBox, errorMessage);
        }
    }
}
