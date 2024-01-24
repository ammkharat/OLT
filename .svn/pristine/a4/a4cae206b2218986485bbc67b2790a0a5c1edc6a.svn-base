using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ApprovalsGridControl : UserControl
    {
        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        private SummaryGrid<FormApprovalGridDisplayAdapter> approvalGrid;

        public ApprovalsGridControl()
        {
            InitializeComponent();
            InitializeApprovalGrid();
        }

        public string GroupBoxLabel
        {
            set { approvalsGroupBox.Text = value; }
            get { return approvalsGroupBox.Text; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<FormApprovalGridDisplayAdapter> Items
        {
            get { return approvalGrid.Items; }
            set 
            {
                approvalGrid.Items = value ?? new List<FormApprovalGridDisplayAdapter>();
            }
        }

        public int MaxLines
        {
            set { approvalGrid.DisplayLayout.Override.RowSizingAutoMaxLines = value; }
        }

        private void InitializeApprovalGrid()
        {
            approvalGrid = new SummaryGrid<FormApprovalGridDisplayAdapter>(new FormApprovalGridRenderer(), OltGridAppearance.EDIT_ROW_SELECT_WRAPPED_TEXT)
            {
                Dock = DockStyle.Fill
            };

            approvalsGroupBox.Controls.Add(approvalGrid);

            approvalGrid.CellChange += HandleApprovalGridCellChange;
            approvalGrid.InitializeRow += HandleInitialize;
            approvalGrid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
            approvalGrid.DisplayLayout.Override.SelectedAppearancesEnabled = DefaultableBoolean.False;
        }

        private void HandleInitialize(object sender, InitializeRowEventArgs e)
        {
            e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            if (e.Row.Cells[approvalGrid.DisplayLayout.Bands[0].Columns["DisableEdit"]].Value != null && (bool)e.Row.Cells[approvalGrid.DisplayLayout.Bands[0].Columns["DisableEdit"]].Value)
                e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
        }

        private void HandleApprovalGridCellChange(object sender, CellEventArgs e)
        {
            UltraGridCell cell = e.Cell;

            if (cell != null)
            {
                CheckEditor checkEditor = cell.EditorResolved as CheckEditor;

                if (checkEditor != null)
                {
                    FormApprovalGridDisplayAdapter item = (FormApprovalGridDisplayAdapter)cell.Row.ListObject;

                    if (CheckState.Checked.Equals(checkEditor.CheckState) && ApprovalSelected != null)
                    {
                        ApprovalSelected(item.GetApproval());
                    }
                    else if (CheckState.Unchecked.Equals(checkEditor.CheckState) && ApprovalUnselected != null)
                    {
                        ApprovalUnselected(item.GetApproval());
                    }

                    cell.Row.Refresh();
                }
            }
        }
    }
}
