using System.ComponentModel;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Controls
{
    /// <summary>
    /// Simple control to encapsulate an other checkbox and associated textbox
    /// Setting the text value will re-enable 
    /// </summary>
    public partial class AdditionalCheckBoxTextBox : UserControl
    {
        private readonly CheckBoxEnabledTextBoxHelper helper;

        public AdditionalCheckBoxTextBox()
        {
            InitializeComponent();
            helper = new AdditionalCheckBoxEnabledTextBoxHelper(otherCheckBox, otherDescriptionTextBox);
        }

        public override string Text
        {
            get { return helper.Text; }
            set { helper.Text = value; }
        }

        public bool CheckBoxChecked
        {
            get { return helper.CheckBoxChecked; }
            set { helper.CheckBoxChecked = value; }
        }

        public int MaxLength
        {
            get { return helper.MaxLength; }
            set { helper.MaxLength = value; }
        }

        [Category("Appearance")]
        [Description("Sets the text beside the checkbox")]
        public string CheckBoxText
        {
            set { otherCheckBox.Text = value; }
            get { return otherCheckBox.Text; }
        }

        public CheckBox CheckBox { get { return otherCheckBox; } }
    }
}
