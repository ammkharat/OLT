using System;
using System.ComponentModel;
using Infragistics.Win.UltraWinEditors;

namespace Com.Suncor.Olt.Client.OltControls
{
    public partial class OltUltraNumericEditor : UltraNumericEditor
    {
        public OltUltraNumericEditor()
        {
            InitializeComponent();
        }

        public OltUltraNumericEditor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public decimal? DecimalValueOrNull
        {
            get
            {
                object value = Value;
                if (value == DBNull.Value)
                {
                    return null;
                }
                double? doubleValue = (double?) value;
                if (!doubleValue.HasValue)
                {
                    return null;
                }
                return new decimal(doubleValue.Value);
            }
        }
    }
}