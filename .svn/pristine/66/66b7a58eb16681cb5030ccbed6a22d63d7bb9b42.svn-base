using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.XtraPrinting.Native;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureRoleMatrixForm : BaseForm, IConfigureRoleMatrixView
    {
        public event Action PreviewChanges;
        public event Action GenerateSql;
        public event Action<InitializeLayoutEventArgs> InitializeGridLayout;

        public ConfigureRoleMatrixForm()
        {
            InitializeComponent();

            previewChangesButton.Click += HandlePreviewChangesButtonClick;
            generateSqlButton.Click += HandleGenerateSqlButtonClick;

            grid.InitializeLayout += GridInitializeLayout;
            grid.CellChange += GridCellChange;
            grid.InitializeRow += GridInitializeRow; 
        }

        private void GridInitializeRow(object sender, InitializeRowEventArgs e)
        {
            RoleMatrixDisplayAdapter roleMatrixDisplayAdapter = (RoleMatrixDisplayAdapter) e.Row.ListObject;

            // I know it's dumb to set column widths once for each row but I don't know where else to put this
            //this.ultraGrid1.DisplayLayout.Bands[0].Columns[0].MinWidth = 60;
            e.Row.Cells["FunctionalArea"].Column.MinWidth = 150;
            e.Row.Cells["FunctionalArea"].Column.MaxWidth = 150;            //ayman rolematrix
            e.Row.Cells["FunctionalArea"].Column.Width = 150;
            e.Row.Cells["Name"].Column.MinWidth = 300;
            e.Row.Cells["Name"].Column.MaxWidth = 300;                   //ayman rolematrix
            e.Row.Cells["Name"].Column.Width = 300;
            
            //e.Row.Cells["FunctionalArea"].Column.Header.Fixed = true;
            //e.Row.Cells["Name"].Column.Header.Fixed = true;
            foreach (UltraGridCell cell in e.Row.Cells)
            {
                if (cell.Column.Key.StartsWith(RoleMatrixDisplayAdapter.KeyPrefix))
                {
                    bool value = roleMatrixDisplayAdapter.GetValue(cell.Column.Key);
                    cell.SetValue(value, false);
                    cell.Column.MinWidth = 50;
                }
            }
        }

        private void GridCellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key.StartsWith(RoleMatrixDisplayAdapter.KeyPrefix))
            {
                RoleMatrixDisplayAdapter displayAdapter = (RoleMatrixDisplayAdapter)e.Cell.Row.ListObject;
                bool value = bool.Parse(e.Cell.Text);
                displayAdapter.SetValue(e.Cell.Column.Key, value);
            }
        }
        private void GridInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (InitializeGridLayout != null)
            {
                InitializeGridLayout(e);
            }

            e.Layout.Override.SelectTypeRow = SelectType.None;
            e.Layout.Override.SelectTypeCell = SelectType.None;
            e.Layout.Override.SelectTypeCol = SelectType.None;
            
            e.Layout.UseFixedHeaders = true;
                        
            e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
        }

        public void ShowNoChangesMessage()
        {
            OltMessageBox.Show(this, StringResources.NoChanges, StringResources.NoChangesTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccessMessageAndCloseForm()
        {
            OltMessageBox.Show(this, StringResources.UpdateSuccessful, StringResources.UpdateSuccessfulTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        public void AddCheckColumn(Role role, InitializeLayoutEventArgs e)
        {
            string columnKey = RoleMatrixDisplayAdapter.Key(role);

            UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add(columnKey, role.Name);
            checkColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            checkColumn.CellActivation = Activation.AllowEdit;
            
            checkColumn.Header.TextOrientation = new TextOrientationInfo(90, TextFlowDirection.Horizontal);
            checkColumn.Width = 40;
        }

        private void HandlePreviewChangesButtonClick(object sender, EventArgs e)
        {
                if (PreviewChanges != null)
                {
                    PreviewChanges();
                }
        }

        private void HandleGenerateSqlButtonClick(object sender, EventArgs e)
        {
            if (GenerateSql != null)
            {
                GenerateSql();
            }
        }

        public List<RoleMatrixDisplayAdapter> RoleMatrixDisplayAdapters
        {
            set
            {
                bindingSource.DataSource = value;
                bindingSource.ResetBindings(false);
                grid.SetDataBinding(bindingSource, bindingSource.DataMember);
            }

            get { return (List<RoleMatrixDisplayAdapter>) bindingSource.DataSource; }
        }

        //ayman rolematrix
        private void grid_MouseEnterElement(object sender, UIElementEventArgs e)
        {
            UltraGrid grid = (UltraGrid)sender;
            UltraGridRow row = grid.DisplayLayout.UIElement.LastElementEntered.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                row.Appearance.BackColor = System.Drawing.Color.Gray;
                row.Appearance.ForeColor = System.Drawing.Color.White;
            }
        }

        private void grid_MouseLeaveElement(object sender, UIElementEventArgs e)
        {
            UltraGrid grid = (UltraGrid)sender;
            UltraGridRow row = grid.DisplayLayout.UIElement.LastElementEntered.GetContext(typeof(UltraGridRow)) as UltraGridRow;

            if (row != null)
            {
                row.Appearance.BackColor = System.Drawing.Color.White;
                row.Appearance.ForeColor = System.Drawing.Color.Black;
            }
        }
    }
}
