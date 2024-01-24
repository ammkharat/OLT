using Com.Suncor.Olt.Common.Domain.Form;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ProcedureDeviationFormApprovalGridRenderer : AbstractSimpleGridRenderer
    {
        private const string EDIT_COLUMN = "IsApproved";
        private const string OBTAINED_VIA_COLUMN = "ObtainedVia";

        private ValueList obtainedViaValueList = new ValueList();

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            InitializeObtainedViaListItems();

            var position = 0;

            band.Columns[EDIT_COLUMN].Format(string.Empty, position++, 40);
            band.Columns["WorkAssignmentDisplayName"].Format("Approver", position++, 175);
            band.Columns["Approver"].Format("Name", position++, 225);

            band.Columns[OBTAINED_VIA_COLUMN].Format("Obtained Via", position++, 75);
            band.Columns[OBTAINED_VIA_COLUMN].Style = ColumnStyle.DropDownList;
            band.Columns[OBTAINED_VIA_COLUMN].ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
            band.Columns[OBTAINED_VIA_COLUMN].ValueList = obtainedViaValueList;

            band.Columns["ApprovalDateTime"].FormatAsDateTime("Date Approved", position++);

            band.Columns["DisableEdit"].Format("Disable Edit", position++);
            band.Columns["DisableEdit"].Hidden = true;

            foreach (var column in band.Columns)
            {
                column.CellActivation = (column.Key != EDIT_COLUMN && column.Key != OBTAINED_VIA_COLUMN)
                    ? Activation.NoEdit
                    : Activation.AllowEdit;
            }
        }

        private void InitializeObtainedViaListItems()
        {
            obtainedViaValueList = new ValueList();

            //obtainedViaValueList.ValueListItems.Add(null, "");
            obtainedViaValueList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Email,
                ProcedureDeviationApprovalObtainedVia.Email.GetName());
            obtainedViaValueList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Radio,
                ProcedureDeviationApprovalObtainedVia.Radio.GetName());
            obtainedViaValueList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Phone,
                ProcedureDeviationApprovalObtainedVia.Phone.GetName());
            obtainedViaValueList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.InPerson,
                ProcedureDeviationApprovalObtainedVia.InPerson.GetName());
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
        }
    }
}