using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureSpecialWorkForm : BaseForm, IConfigureSpecialWorkView
    {
        public event EventHandler ContractorInformationChanged;
        public event EventHandler AddOrUpdate;
        public event EventHandler Delete;
        public event EventHandler Clear;
        public event EventHandler ContractorSelected;
        public event EventHandler Save;
        public event FormClosingEventHandler ViewClosing;

        private readonly DomainSummaryGrid<SpecialWork> contractorGrid;

        public ConfigureSpecialWorkForm()
        {
            InitializeComponent();

            contractorGrid = new DomainSummaryGrid<SpecialWork>(new SpecialWorkGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            contractorGrid.DisplayLayout.GroupByBox.Hidden = true;
            contractorGrid.TabIndex = 0;
            contractorsGroupBox.Controls.Add(contractorGrid);
            contractorGrid.Dock = DockStyle.Fill;
            contractorGrid.SelectedItemChanged += OnContractorSelected;

            new ConfigureSpecialWorkPresenter(this).RegisterToViewEvents();
        }
       
        public Site ContractorSite
        {
            set { siteNameLabel.Text = value.Name; }
        }

        public IList<SpecialWork> Contractors
        {
            // The grid has a Readonly list
            get { return new List<SpecialWork>(contractorGrid.Items); }
            set { contractorGrid.Items = value; }
        }

        public bool AddOrUpdateEnabled
        {
            set { addOrUpdateButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool ClearEnabled
        {
            set { clearButton.Enabled = value; }
        }

        public string AddUpdateText
        {
            set { addOrUpdateButton.Text = value; }
        }

        public string ContractorName
        {
            get { return contractorNameTextBox.Text; }
            set { contractorNameTextBox.Text = value; }
        }

        public SpecialWork SelectedContractor
        {
            get { return contractorGrid.SelectedItem; }
        }

        public void ClearSelectedContractor()
        {
            contractorGrid.ClearSelections();
        }

        public void ShowWarningMessage(string message, string title)
        {
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OnContractorInformationChanged(object sender, EventArgs e)
        {
            if (ContractorInformationChanged != null) { ContractorInformationChanged(sender, e); }
        }

        private void OnAddOrUpdate(object sender, EventArgs e)
        {
            if (AddOrUpdate != null) { AddOrUpdate(sender, e); }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (Delete != null) { Delete(sender, e); }
        }

        private void OnClear(object sender, EventArgs e)
        {
            if (Clear != null) { Clear(sender, e); }
        }

        private void OnContractorSelected(object sender, DomainEventArgs<SpecialWork> e)
        {
            if (ContractorSelected != null) { ContractorSelected(sender, e); }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (Save != null) { Save(sender, e); }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();  // Treat clicking the cancel button as the same as closing the form.
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (ViewClosing != null) { ViewClosing(sender, e); }
        }
    }
}