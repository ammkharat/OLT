using Com.Suncor.Olt.Common.Domain;
using DevExpress.Utils;
using Infragistics.Win.UltraWinGrid;
using System.Collections.Generic;
using System.Drawing;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    class CustomFieldGridRenderer : AbstractSimpleGridRenderer
    {
        public const string EDIT_COLUMN = "FieldEntry";
        private readonly Color phdReadFieldHighlightColour = Color.PaleGreen;
        private readonly Color phdWriteFieldHighlightColour = Color.Plum;
        private UltraGridBand ultraGridBand1;

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 3;
            band.Columns["FieldEntry"].Nullable = Nullable.EmptyString;
            band.Columns["Comment"].Nullable = Nullable.EmptyString;

            int position = 0;

            band.Columns["CustomFieldName"].Format("Name", position++, 400);
            band.Columns["DisplayField"].Format("Last Reading", position++, 100);
            //band.Columns["CurrentValue"].Format("Last Reading", position++, 80);
            //band.Columns["CurrentValue"].Format = "#,##0.00";
            //band.Columns["CurrentValue"].Nullable = Nullable.Nothing;
            band.Columns["FieldEntry"].Format("New Reading", position++, 100);
            band.Columns["Comment"].Format("Comment", position++, 150);

            foreach (UltraGridColumn column in band.Columns)
            {
                column.CellActivation = column.Key != EDIT_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }
            band.Columns["Comment"].CellActivation = Activation.AllowEdit;
        }

        public virtual DefaultBoolean AllowNullInput { get; set; }


        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }

        public override void SetupUnboundColumns(UltraGridBand band)
        {
        }


        public void SetCustomFieldsEntryText(List<CustomFieldEntry> entries, List<CustomField> customFields)
        {
        }

        private void Grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            e.Layout.Bands[0].Columns["Int32 1"].ValueList = e.Layout.ValueLists["MyValueList"];
        }


        public override void SetupRow(UltraGridRow row)
        {

            UltraGridCell mycell = row.Cells["FieldEntry"];
            UltraGridCell mycurrentvalcell = row.Cells["DisplayField"];


            if ((byte)row.Cells["TypeId"].Value == 3)
            {
                row.Cells[10].FormatAsHeading();
                row.Cells["DisplayField"].Hidden = true;
                row.Cells["FieldEntry"].Hidden = true;
                row.Cells["DisplayField"].Activation = Activation.NoEdit;
                row.Cells["FieldEntry"].Activation = Activation.NoEdit;
                row.Cells["Comment"].Activation = Activation.NoEdit;
            }
            else if ((byte)row.Cells["TypeId"].Value == 4)
            {
                row.Hidden = true;
            }
            if ((byte)row.Cells["TypeId"].Value == 2)
            {
                UltraDropDown mycombo = new UltraDropDown();
                mycombo.DataSource = row.Cells["DropDownValues"].OriginalValue;
                mycombo.DataMember = "";
                mycombo.DisplayMember = "Value";
                mycombo.ValueMember = "Value";


                mycombo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

                mycombo.EditAreaDisplayStyle = EditAreaDisplayStyle.DisplayText;

                mycell.ValueList = mycombo;
                row.Cells["FieldEntry"].ValueList = mycombo;
                row.Cells[10].FormatAsLink();

            }
            else if ((byte)row.Cells["TypeId"].Value != 3 && (byte)row.Cells["TypeId"].Value != 2 && (byte)row.Cells["TypeId"].Value != 4)
            {

                row.Cells["FieldEntry"].Value = row.Cells["FieldEntry"].Text;
                row.Cells[10].FormatAsLink();
            }

            if ((byte)row.Cells["PhdLinkTypeId"].Value == 1)
            {
                row.Cells["FieldEntry"].Appearance.BackColor = phdReadFieldHighlightColour;
            }
            else if ((byte)row.Cells["PhdLinkTypeId"].Value == 2)
            {
                row.Cells["FieldEntry"].Appearance.BackColor = phdWriteFieldHighlightColour;
            }
        }

    }
}
