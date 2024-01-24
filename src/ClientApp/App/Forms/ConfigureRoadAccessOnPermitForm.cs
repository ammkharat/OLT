using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureRoadAccessOnPermitForm : BaseForm, IConfigureCraftOrTradeView
    {
        public event EventHandler New;
        public event EventHandler Edit;
        public event EventHandler Delete;
        public event DomainGridEventHandler<CraftOrTrade> EditDoubleClick;
        private readonly DomainSummaryGrid<CraftOrTrade> craftOrTradeGrid;

        public ConfigureRoadAccessOnPermitForm()
        {
            InitializeComponent();           

            craftOrTradeGrid = new DomainSummaryGrid<CraftOrTrade>(new CraftOrTradeGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty);
            craftOrTradeGrid.DisplayLayout.GroupByBox.Hidden = true;
            craftOrTradeGrid.TabIndex = 0;
            craftOrTradeGroupBox.Controls.Add(craftOrTradeGrid);
            craftOrTradeGrid.Dock = DockStyle.Fill;

            newButton.Click += OnNew;
            editButton.Click += OnEdit;
            deleteButton.Click += OnDelete;
            closeButton.Click += OnClose;
            craftOrTradeGrid.DoubleClickSelected += craftOrTradeGrid_DoubleClickSelected;

            new ConfigureRoadAccessOnPermitPresenter(this).RegisterToViewEvents();
        }        

        public string CraftOrTradeSite
        {
            set { siteNameLabel.Text = value; }
        }

        public List<CraftOrTrade> CraftOrTrades
        {
            get { return new List<CraftOrTrade>(craftOrTradeGrid.Items); }
            set { craftOrTradeGrid.Items = value; }
        }

        public CraftOrTrade SelectedCraftOrTrade
        {
            get { return craftOrTradeGrid.SelectedItem; }
            set { craftOrTradeGrid.SelectItem(value); }
        }

        public DialogResult CreateNewCraftOrTrade()
        {
            RoadAccessOnPermitForm craftOrTradeForm = new RoadAccessOnPermitForm();
            return craftOrTradeForm.ShowDialog(this);
        }

        public DialogResult EditCraftOrTrade(CraftOrTrade craftOrTrade)
        {
            RoadAccessOnPermitForm craftOrTradeForm = new RoadAccessOnPermitForm(craftOrTrade);
            return craftOrTradeForm.ShowDialog(this);
        }

        private void OnNew(object sender, EventArgs e)
        {
            if (New != null) { New(sender, e); }
        }

        private void OnEdit(object sender, EventArgs e)
        {
            if (Edit != null) { Edit(sender, e); }
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (Delete != null) { Delete(sender, e); }
        }

        private void OnClose(object sender, EventArgs e)
        {
            Close();
        }

        private void craftOrTradeGrid_DoubleClickSelected(object sender, DomainEventArgs<CraftOrTrade> e)
        {
            if (EditDoubleClick != null)
            {
                EditDoubleClick(sender, e);
            }
        }
    }
}

