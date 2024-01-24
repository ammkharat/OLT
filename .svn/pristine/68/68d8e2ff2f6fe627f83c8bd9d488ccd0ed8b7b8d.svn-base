using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.OltControls
{
    public class OltTimePicker : UserControl
    {
        private DateTimePicker internalPicker;
        public event EventHandler<EventArgs> ValueChanged;

        private readonly string customFormat;

        public OltTimePicker()
        {
            InitializeComponent();

            customFormat = LocaleSpecificFormatPatternResources.ShortTimePattern;

            internalPicker.CustomFormat = customFormat;
            EnabledChanged += OltTimePicker_EnabledChanged;
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
            internalPicker.ShowUpDown = true;
            internalPicker.ValueChanged += InternalPicker_ValueChanged;
            // 
            // OltTimePicker
            // 
            Controls.Add(internalPicker);
            Margin = new Padding(0);
            Name = "oltTimePicker";
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
        public int Hour
        {
            get { return internalPicker.Value.TimeOfDay.Hours; }
            set
            {
                DateTime current = internalPicker.Value;
                internalPicker.Value
                    = new DateTime(current.Year, current.Month, current.Day,
                                   value, current.Minute, 0);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int Minute
        {
            get { return internalPicker.Value.TimeOfDay.Minutes; }
            set
            {
                DateTime current = internalPicker.Value;
                internalPicker.Value
                    = new DateTime(current.Year, current.Month, current.Day,
                                   current.Hour, value, 0);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Time Value
        {
            set
            {
                if (value == null && Enabled)
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
                else if (value == null && !Enabled)
                {
                    internalPicker.Format = DateTimePickerFormat.Custom;
                    internalPicker.CustomFormat = " ";
                }
                else
                {
                    internalPicker.Format = DateTimePickerFormat.Custom;
                    internalPicker.CustomFormat = LocaleSpecificFormatPatternResources.ShortTimePattern;
                    internalPicker.Value = value.ToDateTime();
                    internalPicker.Checked = true;
                }
            }

            get { return internalPicker.Checked ? new Time(internalPicker.Value) : null; }
        }

        void OltTimePicker_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled)
            {
                internalPicker.Format = DateTimePickerFormat.Custom;
                internalPicker.CustomFormat = customFormat;
            }
        }

        public string CustomFormat
        {
            get { return internalPicker.CustomFormat; }
            set { internalPicker.CustomFormat = value; }
        }

        public bool ShowCheckBox
        {
            get { return internalPicker.ShowCheckBox; }
            set { internalPicker.ShowCheckBox = value; }
        }

        public bool Checked
        {
            get { return internalPicker.Checked; }
            set { internalPicker.Checked = value; }
        }
    }
}