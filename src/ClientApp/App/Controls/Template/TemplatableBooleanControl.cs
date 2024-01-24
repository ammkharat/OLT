using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls.Template
{
    public partial class TemplatableBooleanControl : UserControl, ITriStateControl
    {
        private IBooleanControlMode mode;

        //DMND0010667 mangesh - UDS work permit
        //Checked changed event newly added 
        public event Action CheckedChanged; 

        public TemplatableBooleanControl()
        {
            InitializeComponent();
            mode = new BooleanControlUserMode(this);

            checkBox.CheckedChanged += CheckChanged;
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            if (CheckedChanged != null)
            {
                CheckedChanged();
            }
        }

        [Browsable(true)]
        public string Label
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool TemplateMode
        {
            set
            {
                if (value)
                {
                    mode = new BooleanControlTemplateMode(this);
                }
                else
                {
                    mode = new BooleanControlUserMode(this);
                }
            }
            get { return mode.GetType() == typeof (BooleanControlTemplateMode); }
        }

        private void picture_Click(object sender, EventArgs e)
        {
            mode.VisibleClick();
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool EnableControl
        {
            set { checkBox.Enabled = value; }    
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Visible<bool> Value
        {
            get { return mode.Value; }
            set { mode.Value = value; }
        }


    }
}
