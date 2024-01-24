using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle;
using ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ProcedureDeviationApprovalsGridControl : UserControl
    {
        private const string EditColumnKey = "IsApproved";
        private const string ObtainedViaColumnKey = "ObtainedVia";
        private const string DisableEditColumnKey = "DisableEdit";

        private SummaryGrid<ProcedureDeviationFormApprovalGridDisplayAdapter> temporaryApprovalGrid;

        public ProcedureDeviationApprovalsGridControl()
        {
            InitializeComponent();

            InitializeImmediateApprovalGrid();
            InitializeTemporaryApprovalGrid();
        }

        public string GroupBoxLabel
        {
            set { approvalsGroupBox.Text = value; }
            get { return approvalsGroupBox.Text; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<ProcedureDeviationFormApprovalGridDisplayAdapter> ImmediateApprovalItems
        {
            get
            {
                var items = immediateApprovalGrid.DataSource as List<ProcedureDeviationFormApprovalGridDisplayAdapter>;
                return items;
            }
            set
            {
                var items = new List<ProcedureDeviationFormApprovalGridDisplayAdapter>();

                if (value != null)
                {
                    items.AddRange(value);
                }

                immediateApprovalGrid.DataSource = items;
                immediateApprovalGrid.ResetBindings();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<ProcedureDeviationFormApprovalGridDisplayAdapter> TemporaryApprovalItems
        {
            get { return temporaryApprovalGrid.Items; }
            set { temporaryApprovalGrid.Items = value ?? new List<ProcedureDeviationFormApprovalGridDisplayAdapter>(); }
        }

        public List<string> ImmediateApprovalsObtainedViaList
        {
            set
            {
                var valueList =
                    (ValueList) immediateApprovalGrid.DisplayLayout.Bands[0].Columns[ObtainedViaColumnKey].ValueList ??
                    immediateApprovalGrid.DisplayLayout.ValueLists.Add(ObtainedViaColumnKey);

                valueList.ValueListItems.Clear();
                foreach (var obtainedVia in value)
                {
                    valueList.ValueListItems.Add(obtainedVia);
                }
                immediateApprovalGrid.DisplayLayout.Bands[0].Columns[ObtainedViaColumnKey].ValueList = valueList;
            }
        }

        public event Action<ProcedureDeviationFormApproval> ImmediateApprovalSelected;
        public event Action<ProcedureDeviationFormApproval> ImmediateApprovalUnselected;

        public event Action<ProcedureDeviationFormApproval> TemporaryApprovalSelected;
        public event Action<ProcedureDeviationFormApproval> TemporaryApprovalUnselected;

        private void InitializeImmediateApprovalGrid()
        {
            immediateApprovalGrid.InitializeLayout += HandleImmediateApprovalGridInitializeLayoutEditMode;
            immediateApprovalGrid.CellChange += HandleImmediateApprovalGridCellChange;
            immediateApprovalGrid.InitializeRow += HandleImmediateApprovalGridInitializeRow;
            immediateApprovalGrid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
            immediateApprovalGrid.DisplayLayout.Override.SelectedAppearancesEnabled = DefaultableBoolean.False;
        }

        private void HandleImmediateApprovalGridInitializeLayoutEditMode(object sender, InitializeLayoutEventArgs e)
        {
            var layout = e.Layout;
            var band = layout.Bands[0];

            foreach (var column in band.Columns)
            {
                column.CellActivation = column.Key != EditColumnKey && column.Key != ObtainedViaColumnKey
                    ? Activation.NoEdit
                    : Activation.AllowEdit;
            }
        }

        private void HandleImmediateApprovalGridInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            const string immediateApprovalsObtainedViaListKey = "ImmediateApprovalsObtainedViaValueList";

            var layout = e.Layout;
            var band = layout.Bands[0];
            var column = band.Columns[ObtainedViaColumnKey];

            var obtainedViaList = new ValueList();

            if (layout.ValueLists.Exists(immediateApprovalsObtainedViaListKey) == false)
            {
                obtainedViaList = layout.ValueLists.Add(immediateApprovalsObtainedViaListKey);
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Email,
                    ProcedureDeviationApprovalObtainedVia.Email.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Radio,
                    ProcedureDeviationApprovalObtainedVia.Radio.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Phone,
                    ProcedureDeviationApprovalObtainedVia.Phone.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.InPerson,
                    ProcedureDeviationApprovalObtainedVia.InPerson.GetName());
            }

            column.Style = ColumnStyle.DropDownList;
            column.ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
            column.ValueList = obtainedViaList;
        }

        private void HandleImmediateApprovalGridInitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Activation = Activation.AllowEdit;
            var band = immediateApprovalGrid.DisplayLayout.Bands[0];
            band.Override.CellClickAction = CellClickAction.Default;
            var disableEditValue = e.Row.Cells[band.Columns[DisableEditColumnKey]].Value;
            var editCell = e.Row.Cells[band.Columns[EditColumnKey]];
            editCell.Activation = Activation.AllowEdit;

            if (disableEditValue != null && (bool) disableEditValue)
            {
                e.Row.Activation = Activation.NoEdit;
                band.Override.CellClickAction = CellClickAction.RowSelect;

                e.Row.Appearance.BackColor = SystemColors.Control;
                e.Row.Appearance.ForeColor = SystemColors.GrayText;

                // Color the checkbox to match the text
                editCell.Activation = Activation.Disabled;
            }
        }

        private void HandleImmediateApprovalGridCellChange(object sender, CellEventArgs e)
        {
            var cell = e.Cell;

            if (cell != null)
            {
                var checkEditor = cell.EditorResolved as CheckEditor;

                if (checkEditor != null)
                {
                    var item = (ProcedureDeviationFormApprovalGridDisplayAdapter) cell.Row.ListObject;

                    if (CheckState.Checked.Equals(checkEditor.CheckState) && ImmediateApprovalSelected != null)
                    {
                        ImmediateApprovalSelected(item.GetApproval());
                    }
                    else if (CheckState.Unchecked.Equals(checkEditor.CheckState) && ImmediateApprovalUnselected != null)
                    {
                        ImmediateApprovalUnselected(item.GetApproval());
                    }

                    cell.Row.Refresh();
                }
            }
        }

        private void InitializeTemporaryApprovalGrid()
        {
            temporaryApprovalGrid =
                new SummaryGrid<ProcedureDeviationFormApprovalGridDisplayAdapter>(
                    new ProcedureDeviationFormApprovalGridRenderer(), OltGridAppearance.EDIT_ROW_SELECT_WRAPPED_TEXT)
                {
                    Dock = DockStyle.Fill
                };

            temporaryApprovalsGridPanel.Controls.Add(temporaryApprovalGrid);

            temporaryApprovalGrid.InitializeLayout += HandleTemporaryApprovalGridInitializeLayout;
            temporaryApprovalGrid.CellChange += HandleTemporaryApprovalGridCellChange;
            temporaryApprovalGrid.InitializeRow += HandleTemporaryApprovalGridInitializeRow;
            temporaryApprovalGrid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
            temporaryApprovalGrid.DisplayLayout.Override.SelectedAppearancesEnabled = DefaultableBoolean.False;
        }

        private void HandleTemporaryApprovalGridInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            const string temporaryApprovalsObtainedViaListKey = "TemporaryApprovalsObtainedViaValueList";

            var layout = e.Layout;
            var band = layout.Bands[0];
            var column = band.Columns[ObtainedViaColumnKey];

            if (layout.ValueLists.Exists(temporaryApprovalsObtainedViaListKey) == false)
            {
                var obtainedViaList = layout.ValueLists.Add(temporaryApprovalsObtainedViaListKey);
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Email,
                    ProcedureDeviationApprovalObtainedVia.Email.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Radio,
                    ProcedureDeviationApprovalObtainedVia.Radio.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.Phone,
                    ProcedureDeviationApprovalObtainedVia.Phone.GetName());
                obtainedViaList.ValueListItems.Add(ProcedureDeviationApprovalObtainedVia.InPerson,
                    ProcedureDeviationApprovalObtainedVia.InPerson.GetName());
            }

            column.Style = ColumnStyle.DropDownList;
            column.ButtonDisplayStyle = ButtonDisplayStyle.OnMouseEnter;
            column.ValueList = layout.ValueLists[temporaryApprovalsObtainedViaListKey];
        }

        private void HandleTemporaryApprovalGridInitializeRow(object sender, InitializeRowEventArgs e)
        {
            e.Row.Activation = Activation.AllowEdit;
            var band = temporaryApprovalGrid.DisplayLayout.Bands[0];
            band.Override.CellClickAction = CellClickAction.Default;
            var disableEditValue = e.Row.Cells[band.Columns[DisableEditColumnKey]].Value;
            var editCell = e.Row.Cells[band.Columns[EditColumnKey]];
            editCell.Activation = Activation.AllowEdit;

            if (disableEditValue != null && (bool) disableEditValue)
            {
                e.Row.Activation = Activation.NoEdit;
                band.Override.CellClickAction = CellClickAction.RowSelect;

                e.Row.Appearance.BackColor = SystemColors.Control;
                e.Row.Appearance.ForeColor = SystemColors.GrayText;

                // Color the checkbox to match the text
                editCell.Activation = Activation.Disabled;
            }
        }

        private void HandleTemporaryApprovalGridCellChange(object sender, CellEventArgs e)
        {
            var cell = e.Cell;

            if (cell != null)
            {
                var checkEditor = cell.EditorResolved as CheckEditor;

                if (checkEditor != null)
                {
                    var item = (ProcedureDeviationFormApprovalGridDisplayAdapter) cell.Row.ListObject;

                    if (CheckState.Checked.Equals(checkEditor.CheckState) && TemporaryApprovalSelected != null)
                    {
                        TemporaryApprovalSelected(item.GetApproval());
                    }
                    else if (CheckState.Unchecked.Equals(checkEditor.CheckState) && TemporaryApprovalUnselected != null)
                    {
                        TemporaryApprovalUnselected(item.GetApproval());
                    }

                    cell.Row.Refresh();
                }
            }
        }
    }
}