using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class WorkPermitRequestDetailsControl : UserControl
    {
        public WorkPermitRequestDetailsControl()
        {
            InitializeComponent();
        }

        public void SetFields(
            DateTime? requestedDateTime, string requestedByUser,
            string company, string supervisor, string excavationNumber,
            List<PermitAttribute> attributes)
        {
            string formatString;
            if (!string.IsNullOrEmpty(company) ||
                !string.IsNullOrEmpty(supervisor) ||
                !string.IsNullOrEmpty(excavationNumber) ||
                attributes.Count > 0)
            {
                formatString = StringResources.PermitRequestedByOnWithDetails;
            }
            else
            {
                formatString = StringResources.PermitRequestedByOn;
            }
            headerLabel.Text = String.Format(
                formatString,
                requestedByUser,
                requestedDateTime.HasValue ? requestedDateTime.Value.ToLongDateAndTimeString() : "");

            DisplayForNullableString(company, companyLabel, companyTextBox);
            DisplayForNullableString(supervisor, supervisorLabel, supervisorTextBox);
            DisplayForNullableString(excavationNumber, excavationNumberLabel, excavationNumberTextBox);

            attributesLabel.Visible = attributes != null && attributes.Count > 0;
            permitAttributesControl.Visible = attributes != null && attributes.Count > 0;
            permitAttributesControl.AllAttributes = attributes ?? new List<PermitAttribute>();
        }

        private static void DisplayForNullableString(string text, Label label, TextBox textBox)
        {
            label.Visible = !string.IsNullOrEmpty(text);
            textBox.Visible = !string.IsNullOrEmpty(text);
            textBox.Text = text;
        }

        public Color TextBoxBackColor
        {
            get { return companyTextBox.BackColor; }
            set
            {
                companyTextBox.BackColor = value;
                supervisorTextBox.BackColor = value;
                excavationNumberTextBox.BackColor = value;
            }
        }
    }
}
