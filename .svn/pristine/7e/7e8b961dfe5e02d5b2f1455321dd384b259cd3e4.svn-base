using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PreviewRoleElementChangesForm : BaseForm
    {
        private readonly List<RoleElementChange> changes;

        public PreviewRoleElementChangesForm()
        {
            InitializeComponent();

            okButton.Click += HandleOkButtonClick;
        }

        public PreviewRoleElementChangesForm(List<RoleElementChange> changes) : this()
        {
            this.changes = changes;

            roleElementChangeGrid.InitializeRow += HandleInitializeGridRow;
        }

        private void HandleInitializeGridRow(object sender, InitializeRowEventArgs e)
        {
            UltraGridCell cell = e.Row.Cells[RoleElementChangeDisplayAdapter.ChangeTypeGridKey];

            string value = (string) cell.Value;
            if (value == RoleElementChangeType.Add.ToString())
            {
                cell.Appearance.ForeColor = Color.Green;
            }
            else
            {
                cell.Appearance.ForeColor = Color.Red;
            }
        }

        public List<RoleElementChange> SelectedChanges
        {
            get
            {
                List<RoleElementChangeDisplayAdapter> adapters = bindingSource.DataSource as List<RoleElementChangeDisplayAdapter>;

                if (adapters == null)
                {
                    adapters = new List<RoleElementChangeDisplayAdapter>();
                }

                return adapters.FindAll(adapter => adapter.Selected).ConvertAll(adapter => adapter.RoleElementChange);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<RoleElementChangeDisplayAdapter> displayAdapters = changes.ConvertAll(change => new RoleElementChangeDisplayAdapter(change));
            bindingSource.DataSource = displayAdapters;
        }

        private void HandleOkButtonClick(object sender, EventArgs eventArgs)
        {
            if (SelectedChanges.IsEmpty())
            {
                OltMessageBox.Show(this, StringResources.NoChangeSelected, StringResources.NoChangeSelectedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
