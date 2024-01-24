using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class PermitAttributesControl : UserControl
    {
        private readonly Dictionary<long, AttributeCheckBox> attributeCheckBoxes = new Dictionary<long, AttributeCheckBox>();
        private bool readOnly;

        public PermitAttributesControl()
        {
            InitializeComponent();
            Disposed += Control_Disposed;
            SizeChanged += Control_SizeChanged;
        }

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            UpdateColumnWidths();
        }

        private void UpdateColumnWidths()
        {
            if (attributesTableLayoutPanel.ColumnStyles.Count == 6)
            {
                int labelColumnWidth = (Size.Width - 3*20 - 10)/3;
                if (labelColumnWidth < 50)
                {
                    labelColumnWidth = 50;
                }
                attributesTableLayoutPanel.ColumnStyles[1].Width = labelColumnWidth;
                attributesTableLayoutPanel.ColumnStyles[3].Width = labelColumnWidth;
                attributesTableLayoutPanel.ColumnStyles[5].Width = labelColumnWidth;
            }
            else if (attributesTableLayoutPanel.ColumnStyles.Count == 3)
            {
                int labelColumnWidth = (Size.Width - 10) / 3;
                if (labelColumnWidth < 50)
                {
                    labelColumnWidth = 50;
                }
                attributesTableLayoutPanel.ColumnStyles[0].Width = labelColumnWidth;
                attributesTableLayoutPanel.ColumnStyles[1].Width = labelColumnWidth;
                attributesTableLayoutPanel.ColumnStyles[2].Width = labelColumnWidth;
            }
        }

        private void Control_Disposed(object sender, EventArgs e)
        {
            attributeCheckBoxes.Clear();
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<PermitAttribute> SelectedAttributes
        {
            get
            {
                List<PermitAttribute> attributes = new List<PermitAttribute>();
                foreach (AttributeCheckBox attributeCheckBox in attributeCheckBoxes.Values)
                {
                    if (attributeCheckBox.CheckBox.Checked)
                    {
                        attributes.Add(attributeCheckBox.Attribute);
                    }
                }
                return attributes;
            }
            set
            {
                foreach (PermitAttribute attribute in value)
                {
                    long key = attribute.IdValue;
                    if (attributeCheckBoxes.ContainsKey(key))
                    {
                        attributeCheckBoxes[key].CheckBox.Checked = true;
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List<PermitAttribute> AllAttributes
        {
            set
            {
                attributesTableLayoutPanel.SuspendLayout();

                attributesTableLayoutPanel.Controls.Clear();
                attributeCheckBoxes.Clear();
                attributesTableLayoutPanel.RowCount = 0;
                attributesTableLayoutPanel.RowStyles.Clear();
                SetupColumns();

                value.Sort(attribute => attribute.Name);
                List<PermitAttribute> sortedAttributes = value.SortByColumnsGoingDownEachColumn(3);
                for (int i = 0; i < sortedAttributes.Count; i++)
                {
                    PermitAttribute attribute = sortedAttributes[i];

                    if (!readOnly)
                    {
                        OltCheckBox checkBox = new OltCheckBox();
                        attributesTableLayoutPanel.Controls.Add(checkBox);
                        attributeCheckBoxes.Add(attribute.IdValue, new AttributeCheckBox(checkBox, attribute));
                        checkBox.Name = "checkbox" + i;
                        checkBox.TabIndex = i;
                        checkBox.Margin = new Padding(3);
                        checkBox.AutoSize = true;
                    }

                    Label label = new Label();
                    attributesTableLayoutPanel.Controls.Add(label);
                    label.Name = "label" + i;
                    label.Margin = new Padding(0, 3, 3, 3);
                    label.AutoSize = true;
                    label.Text = attribute.Name;

                    label.Tag = attribute.IdValue;
                    label.Click += AttributeLabel_Click;
                }

                for(int i = 0; i < attributesTableLayoutPanel.RowCount; i++)
                {
                    attributesTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                // TODO: this is a workaround that resolves details control resize issue #3738
                this.Height += 500;

                attributesTableLayoutPanel.ResumeLayout(false);
                attributesTableLayoutPanel.PerformLayout();
            }
        }

        private void SetupColumns()
        {
            if (readOnly && attributesTableLayoutPanel.ColumnCount != 3)
            {
                attributesTableLayoutPanel.ColumnStyles.Clear();
                attributesTableLayoutPanel.ColumnCount = 3;
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                UpdateColumnWidths();
            }
            else if (!readOnly && attributesTableLayoutPanel.ColumnCount != 6)
            {
                attributesTableLayoutPanel.ColumnStyles.Clear();
                attributesTableLayoutPanel.ColumnCount = 6;
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
                attributesTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                UpdateColumnWidths();
            }
        }

        private void AttributeLabel_Click(object sender, EventArgs e)
        {
            if (!readOnly)
            {
                Label label = (Label) sender;
                if (label.Tag is long)
                {
                    long key = (long) label.Tag;
                    if (attributeCheckBoxes.ContainsKey(key))
                    {
                        attributeCheckBoxes[key].CheckBox.Checked = !attributeCheckBoxes[key].CheckBox.Checked;
                    }
                }
            }
        }

        private class AttributeCheckBox
        {
            public AttributeCheckBox(OltCheckBox checkBox, PermitAttribute attribute)
            {
                CheckBox = checkBox;
                Attribute = attribute;
            }

            public OltCheckBox CheckBox { get; private set; }
            public PermitAttribute Attribute { get; private set; }
        }
    }
}
