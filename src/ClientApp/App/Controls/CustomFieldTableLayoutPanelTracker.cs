using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraCharts;

namespace Com.Suncor.Olt.Client.Controls
{
//    public delegate void CustomFieldClickHandler(CustomField customField);

    public class CustomFieldTableLayoutPanelTracker : TableLayoutPanel
    {
        private const int spacerColumnWidth = 10;
        private const int fieldNameColumnWidth = 120;

        private readonly Dictionary<long, Control> fieldIdToControlMap = new Dictionary<long, Control>();
        private readonly Color phdReadFieldHighlightColour = Color.PaleGreen;
        private readonly Color phdWriteFieldHighlightColour = Color.Plum;

        public CustomFieldTableLayoutPanelTracker()
        {
            ColumnCount = 15;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, fieldNameColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, fieldNameColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, fieldNameColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67f));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, spacerColumnWidth));

            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            DoubleBuffered = true;
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new int ColumnCount
        {
            get { return base.ColumnCount; }
            private set { base.ColumnCount = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new TableLayoutColumnStyleCollection ColumnStyles
        {
            get { return base.ColumnStyles; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new int RowCount
        {
            get { return base.RowCount; }
            private set { base.RowCount = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public new TableLayoutRowStyleCollection RowStyles
        {
            get { return base.RowStyles; }
        }

        public event CustomFieldClickHandler CustomFieldClicked;

        protected override void Dispose(bool disposing)
        {
            fieldIdToControlMap.Clear();
            base.Dispose(disposing);
        }

        public void TurnOffHighlighting()
        {
            foreach (var control in fieldIdToControlMap.Values)
            {
                control.BackColor = Color.White;
            }
        }

        public void TurnOnHighlighting(List<CustomFieldEntry> entries)
        {
            foreach (var customFieldEntry in entries)
            {
                if (customFieldEntry.PhdLinkType == CustomFieldPhdLinkType.Read &&
                    fieldIdToControlMap.ContainsKey(customFieldEntry.CustomFieldId.Value))
                {
                    fieldIdToControlMap[customFieldEntry.CustomFieldId.Value].BackColor = phdReadFieldHighlightColour;
                }
                else if (customFieldEntry.PhdLinkType == CustomFieldPhdLinkType.Write &&
                         fieldIdToControlMap.ContainsKey(customFieldEntry.CustomFieldId.Value))
                {
                    fieldIdToControlMap[customFieldEntry.CustomFieldId.Value].BackColor =
                        phdWriteFieldHighlightColour;
                }
            }
        }

        public void SetCustomFieldEntries(List<CustomFieldEntry> entries, List<CustomField> customFields,
            bool onlyAllowedToEditDORComments)
        {
            SuspendLayout();

            var orderedFields = new List<CustomField>(customFields);
            orderedFields.Sort(field => field.DisplayOrder);

            var rowIndex = 0;
            var columnIndex = 0;
            foreach (var customField in orderedFields)
            {
                var fieldEntry = entries.Find(entry => entry.CustomFieldId == customField.Id);

                if (fieldEntry == null)
                {
                    AddField(
                        rowIndex, columnIndex,
                        customField.Name, null, onlyAllowedToEditDORComments, customField.Type, customField.PhdLinkType,
                        customField);

                }
                else
                {
                    AddField(
                        rowIndex, columnIndex,
                        fieldEntry.CustomFieldName,fieldEntry.FieldEntryForDisplay, onlyAllowedToEditDORComments,
                        fieldEntry.Type, fieldEntry.PhdLinkType, customField);

                }

                columnIndex += 4;

                if (columnIndex < ColumnCount)
                {
                    AddEmptyColumn(rowIndex, columnIndex);
                    columnIndex++;
                }

                if (columnIndex == ColumnCount)
                {
                    rowIndex++;
                    columnIndex = 0;
                    AddEmptyRow(rowIndex);
                    rowIndex++;
                }
            }

            ResumeLayout(true);
        }

        ////ayman action item reading
        //public void SetCustomFieldEntriesForTracker(List<ActionItemResponseTracker> entries, List<CustomField> customFields,
        //    bool onlyAllowedToEditDORComments)
        //{
        //    SuspendLayout();

        //    var orderedFields = new List<CustomField>(customFields);
        //    orderedFields.Sort(field => field.DisplayOrder);

        //    var rowIndex = 0;
        //    var columnIndex = 0;
        //    foreach (var customField in orderedFields)
        //    {
        //        var fieldEntry = entries.Find(entry => entry.CustomFieldId == customField.Id);

        //        if (fieldEntry == null)
        //        {
        //            //AddField(
        //            //    rowIndex, columnIndex,
        //            //    customField.Name, 0, null, onlyAllowedToEditDORComments, customField.Type, customField.PhdLinkType,
        //            //    customField);

        //            //second field
        //            AddField(
        //                rowIndex, columnIndex + 3,
        //                customField.Name, 0, null, onlyAllowedToEditDORComments, customField.Type, customField.PhdLinkType,
        //                customField);
        //        }
        //        else
        //        {
        //            AddField(
        //                rowIndex, columnIndex,
        //                fieldEntry.CustomFieldName, fieldEntry.CurrentValue,entryText , onlyAllowedToEditDORComments,
        //                fieldEntry.Type, fieldEntry.PhdLinkType, customField);

        //            //second field
        //            //AddSecondField(
        //            //    rowIndex, columnIndex+3,
        //            //    fieldEntry.FieldEntryForDisplay, onlyAllowedToEditDORComments,
        //            //    fieldEntry.Type, fieldEntry.PhdLinkType, customField);
        //        }

        //        columnIndex += 4;

        //        if (columnIndex < ColumnCount)
        //        {
        //            AddEmptyColumn(rowIndex, columnIndex);
        //            columnIndex++;
        //        }

        //        if (columnIndex == ColumnCount)
        //        {
        //            rowIndex++;
        //            columnIndex = 0;
        //            AddEmptyRow(rowIndex);
        //            rowIndex++;
        //        }
        //    }

        //    ResumeLayout(true);
        //}








        private void AddEmptyColumn(int rowIndex, int columnIndex)
        {
            var label = new OltLabel {Text = " ", Width = 10, Dock = DockStyle.Fill};
            Controls.Add(label, columnIndex, rowIndex);
        }

        private void AddEmptyRow(int rowIndex)
        {
            var label = new OltLabel {Text = " ", Height = 5, Dock = DockStyle.Fill};
            Controls.Add(label, 0, rowIndex);
        }

        private void AddField(int rowIndex, int columnIndex, string fieldName, string entryText, bool isReadOnly,
            CustomFieldType fieldEntryType, CustomFieldPhdLinkType phdLinkType, CustomField customField)
        {
            var uniqueIndentifier = (rowIndex*100) + columnIndex;


            var typeToUse = customField.Type;

            if (typeToUse == CustomFieldType.BlankSpace) return;

            var label = typeToUse != CustomFieldType.Heading ? new OltLinkLabel() : new Label();
            label.Tag = customField;
            label.Click += Label_Click;

            {
                label.Name = "label" + uniqueIndentifier;
                label.TabIndex = uniqueIndentifier;
                label.AutoSize = true;
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Anchor = AnchorStyles.Left;
                label.ResetFont();
                label.Text = fieldName;
                if (typeToUse == CustomFieldType.Heading)
                {
                    label.Font = new Font(label.Font.FontFamily, 9.5f, FontStyle.Bold);
                }
                Controls.Add(label, columnIndex, rowIndex);
            }

            if (!typeToUse.Equals(CustomFieldType.DropDownList) && !typeToUse.Equals(CustomFieldType.Heading))
            {
                //Add second textbox for new value
                TextBox textBoxNewValue = new OltTextBox();
                SetupCommonControlAttributesForNewValue(textBoxNewValue, uniqueIndentifier, phdLinkType);
                textBoxNewValue.MaxLength = typeToUse.Equals(CustomFieldType.GeneralText) ? 100 : 29;

                textBoxNewValue.Text = entryText;

                textBoxNewValue.ReadOnly = true;   // the field displays the saved value only

                Controls.Add(textBoxNewValue, columnIndex + 1, rowIndex);


                TextBox textBox = new OltTextBox();
                SetupCommonControlAttributes(textBox, uniqueIndentifier, phdLinkType);
                textBox.MaxLength = typeToUse.Equals(CustomFieldType.GeneralText) ? 100 : 29;
                textBox.Text = entryText;
                Controls.Add(textBox, columnIndex + 3, rowIndex);

                // Start Custom Field Changes By : Swapnil Patki
                if (customField.Color == "R")
                {
                    textBox.ForeColor = Color.Red;
                    fieldIdToControlMap.Add(customField.IdValue, textBox);
                }
                else
                {
                    fieldIdToControlMap.Add(customField.IdValue, textBox);
                }
                // End Custom Field Changes By : Swapnil Patki
            }
            if (typeToUse.Equals(CustomFieldType.DropDownList))
            {
                var comboBox = new ComboBox {MaxLength = 100};
                SetupCommonControlAttributes(comboBox, uniqueIndentifier, phdLinkType);

                comboBox.DataSource = new List<CustomFieldDropDownValue>(customField.DropDownValues);

                if (isReadOnly)
                {
                    comboBox.Enabled = false;
                }
                Controls.Add(comboBox, columnIndex + 1, rowIndex);


                // Setting Visible = true is a small hack. On the load of many forms we set all the controls to be invisible, set up the form, then make everything
                // visible again.  When these comboboxes were becoming visible again, winforms code was setting their SelectedIndex to 0.  This stops that.
                comboBox.Visible = true;

                // setting the text *after* adding the control is necessary (adding the control seems to wipe it out)
                comboBox.Text = entryText;

                fieldIdToControlMap.Add(customField.IdValue, comboBox);
            }
        }



        private void AddSecondField(int rowIndex, int columnIndex, string entryText, bool isReadOnly,
            CustomFieldType fieldEntryType, CustomFieldPhdLinkType phdLinkType, CustomField customField)
        {
            var uniqueIndentifier = (rowIndex * 100) + columnIndex;


            var typeToUse = customField.Type;

            if (typeToUse == CustomFieldType.BlankSpace) return;

            //var label = typeToUse != CustomFieldType.Heading ? new OltLinkLabel() : new Label();
            //label.Tag = customField;
            //label.Click += Label_Click;

            //{
            //    label.Name = "label" + uniqueIndentifier;
            //    label.TabIndex = uniqueIndentifier;
            //    label.AutoSize = true;
            //    label.TextAlign = ContentAlignment.MiddleLeft;
            //    label.Anchor = AnchorStyles.Left;
            //    label.ResetFont();
            //    //label.Text = fieldName;
            //    if (typeToUse == CustomFieldType.Heading)
            //    {
            //        label.Font = new Font(label.Font.FontFamily, 9.5f, FontStyle.Bold);
            //    }
            //    Controls.Add(label, columnIndex, rowIndex);
            //}

            if (!typeToUse.Equals(CustomFieldType.DropDownList) && !typeToUse.Equals(CustomFieldType.Heading))
            {
                TextBox textBox = new OltTextBox();

                SetupCommonControlAttributes(textBox, uniqueIndentifier, phdLinkType);
                textBox.MaxLength = typeToUse.Equals(CustomFieldType.GeneralText) ? 100 : 29;

                textBox.Text = entryText;

                if (isReadOnly)
                {
                    textBox.ReadOnly = true;
                }
                Controls.Add(textBox, columnIndex , rowIndex);
                // Start Custom Field Changes By : Swapnil Patki
                if (customField.Color == "R")
                {
                    textBox.ForeColor = Color.Red;
                    fieldIdToControlMap.Add(customField.IdValue, textBox);
                }
                else
                {
                    fieldIdToControlMap.Add(customField.IdValue, textBox);
                }
                // End Custom Field Changes By : Swapnil Patki
            }
            if (typeToUse.Equals(CustomFieldType.DropDownList))
            {
                var comboBox = new ComboBox { MaxLength = 100 };
                SetupCommonControlAttributes(comboBox, uniqueIndentifier, phdLinkType);

                comboBox.DataSource = new List<CustomFieldDropDownValue>(customField.DropDownValues);

                if (isReadOnly)
                {
                    comboBox.Enabled = false;
                }
                Controls.Add(comboBox, columnIndex , rowIndex);

                // Setting Visible = true is a small hack. On the load of many forms we set all the controls to be invisible, set up the form, then make everything
                // visible again.  When these comboboxes were becoming visible again, winforms code was setting their SelectedIndex to 0.  This stops that.
                comboBox.Visible = true;

                // setting the text *after* adding the control is necessary (adding the control seems to wipe it out)
                comboBox.Text = entryText;

                fieldIdToControlMap.Add(customField.IdValue, comboBox);
            }
        }



        private void Label_Click(object sender, EventArgs e)
        {
            if (CustomFieldClicked != null)
            {
                var label = sender as Label;
                if (label != null)
                {
                    var customField = label.Tag as CustomField;
                    CustomFieldClicked(customField);
                }
            }
        }

        private void SetupCommonControlAttributes(Control control, int uniqueIndentifier,
            CustomFieldPhdLinkType phdLinkType)
        {
            control.Name = "customFieldControlForReading" + uniqueIndentifier;
            control.TabIndex = uniqueIndentifier + 1;

            control.Size = new Size(90, 21);
            control.Dock = DockStyle.Fill;

            if (phdLinkType == CustomFieldPhdLinkType.Read)
            {
                control.BackColor = phdReadFieldHighlightColour;
            }
            else if (phdLinkType == CustomFieldPhdLinkType.Write)
            {
                control.BackColor = phdWriteFieldHighlightColour;
            }
        }

        private void SetupCommonControlAttributesForNewValue(Control control, int uniqueIndentifier,
         CustomFieldPhdLinkType phdLinkType)
        {
            control.Name = "customFieldControlNewValue" + uniqueIndentifier;
            control.TabIndex = uniqueIndentifier + 1;

            control.Size = new Size(90, 21);
            control.Dock = DockStyle.Fill;

        }



        public string GetCustomFieldEntryText(long customFieldId)
        {
            if (fieldIdToControlMap.ContainsKey(customFieldId))
            {
                return fieldIdToControlMap[customFieldId].Text;
            }
            return null;
        }

        public string GetCustomFieldEntryText(CustomFieldEntry entry)
        {
            return GetCustomFieldEntryText(entry.CustomFieldId.Value);
        }


        public void SetCustomFieldEntryText(CustomFieldEntry entry, string text)
        {
            if (fieldIdToControlMap.ContainsKey(entry.CustomFieldId.Value))
            {
                fieldIdToControlMap[entry.CustomFieldId.Value].Text = text;
                Regex rgx = new Regex(@"^[a-zA-Z]");   // to fix the crash ... ayman
                if (!rgx.IsMatch(text))
                    { 
                        if (entry.GreaterThanValue != null && entry.GreaterThanValue >= Convert.ToDecimal(text))
                        {
                            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
                        }

                        if (entry.LessThanValue != null && entry.LessThanValue <= Convert.ToDecimal(text))
                        {
                            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
                        }

                        if (entry.MaxValueofRange != null && entry.MinValueofRange != null
                            && entry.MinValueofRange > Convert.ToDecimal(text) ||
                            entry.MaxValueofRange < Convert.ToDecimal(text))
                        {
                            fieldIdToControlMap[entry.CustomFieldId.Value].ForeColor = Color.Red;
                        }
                }
            }
        }

        public void SetError(ErrorProvider errorProvider, CustomFieldEntry entry, string message)
        {
            if (fieldIdToControlMap.ContainsKey(entry.CustomFieldId.Value))
            {
                var control = fieldIdToControlMap[entry.CustomFieldId.Value];
                errorProvider.SetError(control, message);
            }
        }
    }
}