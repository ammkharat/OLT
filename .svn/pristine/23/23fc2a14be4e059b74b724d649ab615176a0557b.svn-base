using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class TargetSummary : UserControl, ITargetSummaryView
    {
        public event EventHandler LoadView;

        public string SummaryLabel
        {
          get { return summaryLabelLine.Label; }  
          set { summaryLabelLine.Label = value; }
        }

        public string NameLabel
        {
           get { return nameGroupBox.Text; } 
           set { nameGroupBox.Text = value; }
        }

        public string TargetName
        {
            set { nameLabelData.Text = value; }
        }

        public TargetSummary()
        {
            InitializeComponent();
        }

        public string CategoryName
        {
            set { categoryLabelData.Text = value; }
        }

        public string Author
        {
            set { authorLabelData.Text = value; }
        }

        public string FunctionalLocationName
        {
            set { functionalLocationLabelData.Text = value; }
        }

        public string FunctionalLocationDescription
        {
            set { toolTip.SetToolTip(functionalLocationLabelData, value); }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
            get { return descriptionTextBox.Text; }
        }

        public string MeasurementTagName
        {
            set { tagNameLabelData.Text = value; }
        }

        public string MeasurementTagUnits
        {
            set
            {
                neverToExceedMaxUnitLabel.Text = value;
                neverToExceedMinUnitLabel.Text = value;
                maximumUnitLabel.Text = value;
                minimumUnitLabel.Text = value;
                targetUnitLabel.Text = value;
            }
        }

        public decimal? NeverToExceedMaximum
        {
            set { neverToExceedMaxValue.DecimalValue = value;}
        }

        public decimal? MaxValue
        {
            set { maxValue.DecimalValue = value; }
        }

        public decimal? MinValue
        {
            set { minValue.DecimalValue = value; }
        }

        public decimal? NeverToExceedMinimum
        {
            set { neverToExceedMinValue.DecimalValue = value; }
        }

        public string TargetValue
        {
            set { targetValue.Text = value; }
        }

        private void TargetDefinitionSummary_Load(object sender, EventArgs e)
        {
            if (LoadView != null) { LoadView(sender, e); }
        }
    }
}
