using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltOptionalDateTimePicker : UserControl
    {
        private const int fixedWidth = 209;
        private const int fixedHeight = 21;

        public OltOptionalDateTimePicker()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            oltCheckBox.Checked = true;
            oltDatePicker.Enabled = true;
            oltTimePicker.Enabled = true;
        }

        // this locks down the size of the control (otherwise dragging the control around a form will mess things
        // up -- the alternative is to handle the resize event)
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, fixedWidth, fixedHeight, specified);
        }

        private void oltCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            oltDatePicker.Enabled = oltCheckBox.Checked;
            oltTimePicker.Enabled = oltCheckBox.Checked;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DateTime? Value
        {
            set
            {
                if (value == null)
                {
                    oltCheckBox.Checked = false;
                    oltDatePicker.Enabled = false;
                    oltTimePicker.Enabled = false;
                }
                else
                {
                    oltCheckBox.Checked = true;
                    oltDatePicker.Value = value.ToDate();
                    oltTimePicker.Value = value.ToTime();
                }
            }
        
            get
            {
                if (oltCheckBox.Checked)
                {
                    Date date = oltDatePicker.Value;
                    Time time = oltTimePicker.Value;
                    return date.CreateDateTime(time);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
