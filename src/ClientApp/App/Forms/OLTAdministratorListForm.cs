using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class OLTAdministratorListForm : BaseForm, IConfigureAdministratorListView
    {
        private readonly DomainSummaryGrid<AdministratorList> grid;
        private readonly ConfigureAdministratorListFormPresenter presenter;
        private readonly AdministratorListConfigurationGridRenderer gridRenderer;
       

        public OLTAdministratorListForm()
        {
            InitializeComponent();
            grid = new DomainSummaryGrid<AdministratorList>(new AdministratorListConfigurationGridRenderer(),
                                                              OltGridAppearance.SINGLE_SELECT, "Links Grid") { Dock = DockStyle.Fill };
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridGroupBox.Controls.Add(grid);
            grid.InitializeLayout += HandleGridInitializeLayout;
            presenter = new ConfigureAdministratorListFormPresenter(this);
            Load += presenter.LoadForm;
        }

        private void HandleGridInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Appearance.BackColor = Color.White;
            e.Layout.Override.RowAppearance.TextVAlign = VAlign.Middle;
            e.Layout.Scrollbars = Scrollbars.Automatic;
            e.Layout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue;
            e.Layout.Override.DefaultRowHeight = 30;
            e.Layout.Bands[0].ColHeaderLines = 2;
            e.Layout.Override.RowSelectors = DefaultableBoolean.True;
            e.Layout.Override.RowSizing = RowSizing.AutoFree;
            e.Layout.Override.CellMultiLine = DefaultableBoolean.True;

            e.Layout.Bands[0].Columns[0].CellAppearance.ForeColor = Color.White;
            e.Layout.Bands[0].Columns[0].CellAppearance.BackColor = Color.FromArgb(51, 103, 153);
            e.Layout.Bands[0].Columns[0].CellAppearance.FontData.Bold = DefaultableBoolean.True;

            e.Layout.Bands[0].Override.HeaderAppearance.ForeColor = Color.White;
            e.Layout.Bands[0].Override.HeaderAppearance.BackColor = Color.FromArgb(51, 103, 153);
            e.Layout.Bands[0].Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
        }
       
        public List<AdministratorList> Items
        {
            set { grid.Items = value; }
        }

        public string SiteName
        {
            set {  }
        }

        public AdministratorList SelectedItem
        {
            get { return grid.SelectedItem; }    
        }

        public bool CreateNewAdministrator()
        {
            //AddEditAdministratorForm addEditAdministratorForm = new AddEditAdministratorForm(null);
            //DialogResult result = addEditAdministratorForm.ShowDialog();
            //return result == DialogResult.OK;
            return false;
        }

        public bool EditAdministrator(AdministratorList selectedItem)
        {
            //AddEditAdministratorForm addEditAdministratorForm = new AddEditAdministratorForm(selectedItem);
            //DialogResult result = addEditAdministratorForm.ShowDialog();
            //return result == DialogResult.OK;
            return false;
        }

        //private void OnClose(object sender, EventArgs e)
        //{
        //    Close();
        //}

    }

}
