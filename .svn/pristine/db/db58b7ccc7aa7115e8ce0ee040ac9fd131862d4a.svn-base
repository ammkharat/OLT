using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class DocumentSuggestionReadOnlyApprovalsGridControl : UserControl
    {
        private SummaryGrid<DocumentSuggestionFormApprovalGridDisplayAdapter> approvalGrid;

        public DocumentSuggestionReadOnlyApprovalsGridControl()
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
        public IList<DocumentSuggestionFormApprovalGridDisplayAdapter> Items
        {
            get { return approvalGrid.Items; }
            set { approvalGrid.Items = value ?? new List<DocumentSuggestionFormApprovalGridDisplayAdapter>(); }
        }

        public int MaxLines
        {
            set { approvalGrid.DisplayLayout.Override.RowSizingAutoMaxLines = value; }
        }

        public event Action<FormApproval> ApprovalSelected;
        public event Action<FormApproval> ApprovalUnselected;

        private void InitializeApprovalGrid()
        {
            approvalGrid =
                new SummaryGrid<DocumentSuggestionFormApprovalGridDisplayAdapter>(
                    new DocumentSuggestionFormApprovalGridRenderer(), OltGridAppearance.EDIT_ROW_SELECT_WRAPPED_TEXT)
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
            e.Row.Activation = Activation.AllowEdit;
            if (e.Row.Cells[approvalGrid.DisplayLayout.Bands[0].Columns["DisableEdit"]].Value != null &&
                (bool) e.Row.Cells[approvalGrid.DisplayLayout.Bands[0].Columns["DisableEdit"]].Value)
                e.Row.Activation = Activation.NoEdit;
        }

        private void HandleApprovalGridCellChange(object sender, CellEventArgs e)
        {
            var cell = e.Cell;

            if (cell != null)
            {
                var checkEditor = cell.EditorResolved as CheckEditor;

                if (checkEditor != null)
                {
                    var item = (DocumentSuggestionFormApprovalGridDisplayAdapter) cell.Row.ListObject;

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

        public void AutoSizeGrid()
        {
            approvalGrid.AutoSizeGridToDisplayWithNoScrollbars();
        }
    }
}