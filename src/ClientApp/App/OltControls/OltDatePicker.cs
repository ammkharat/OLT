using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltDatePicker : UserControl
    {
        private DateTimePicker internalPicker;
        public event EventHandler<EventArgs> ValueChanged;

        public OltDatePicker()
        {
            InitializeComponent();
            internalPicker.CustomFormat = LocaleSpecificFormatPatternResources.LongDatePattern;
        }

        private void InitializeComponent()
        {
            internalPicker = new DateTimePicker();
            SuspendLayout();
            // 
            // internalPicker
            // 
            internalPicker.Dock = DockStyle.Fill;
            internalPicker.Format = DateTimePickerFormat.Custom;
            internalPicker.Location = new Point(0, 0);
            internalPicker.Name = "internalPicker";
            internalPicker.Size = new Size(60, 20);
            internalPicker.TabIndex = 0;
            internalPicker.Font = UIConstants.CONTROL_FONT;
            internalPicker.ValueChanged += InternalPicker_ValueChanged;
            // 
            // OltTimePicker
            // 
            Controls.Add(internalPicker);
            Margin = new Padding(0);
            Name = "oltDatePicker";
            Size = new Size(60, 21);
            ResumeLayout(false);

        }

        private void InternalPicker_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Date Value
        {
            set
            {
                if (value == null)
                {
                    if (internalPicker.ShowCheckBox)
                    {
                        internalPicker.Value = Clock.NextHour;
                        internalPicker.Checked = false;
                    }
                    else
                    {
                        internalPicker.Value = Clock.Now;
                        internalPicker.Checked = false;
                    }
                }
                else
                {
                    internalPicker.Value = Date.ToDateTimeOrMaxValue(value);
                    internalPicker.Checked = true;
                }
            }

            get
            {
                return internalPicker.Checked ? new Date(internalPicker.Value) : null;
            }
        }

        public int Year
        {
            get { return Value.Year; }
        }

        public int Month
        {
            get { return Value.Month; }
        }

        public int Day
        {
            get { return Value.Day; }
        }

        /// <summary>
        /// Fixed font for Olt Label
        /// </summary>
        public override Font Font
        {
            get { return UIConstants.CONTROL_FONT; }
        }

        public DateTime MinDate
        {
            get { return internalPicker.MinDate; }
            set { internalPicker.MinDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public bool PickerEnabled
        {
            get { return internalPicker.Enabled; }
            set { internalPicker.Enabled = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public string CustomFormat
        {
            get { return internalPicker.CustomFormat; }
            set { internalPicker.CustomFormat = value; }
        }
    }
}