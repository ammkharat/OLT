using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureLinkRootsForm : BaseForm, IConfigureLinkRootsView
    {
        private readonly DomainSummaryGrid<DocumentRootUncPath> grid;
        private readonly ConfigureLinkRootsFormPresenter presenter;

        public ConfigureLinkRootsForm()
        {
            InitializeComponent();
            grid = new DomainSummaryGrid<DocumentRootUncPath>(new DocumentLinkConfigurationGridRenderer(),
                                                              OltGridAppearance.SINGLE_SELECT, "Links Grid")
                       {Dock = DockStyle.Fill};
            grid.DisplayLayout.GroupByBox.Hidden = true;  
            gridGroupBox.Controls.Add(grid);

            presenter = new ConfigureLinkRootsFormPresenter(this);
            Load += presenter.LoadForm;
            newButton.Click += presenter.HandleNew;
            editButton.Click += presenter.HandleEdit;
            deleteButton.Click += presenter.HandleDelete;
            closeButton.Click += OnClose;
        }

        public List<DocumentRootUncPath> Items
        {
            set { grid.Items = value; }
        }

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public DocumentRootUncPath SelectedItem
        {
            get { return grid.SelectedItem; }    
        }

        public bool CreateNewUncRoot()
        {
            AddEditDocumentLinkRootForm addEditDocumentLinkRootForm = new AddEditDocumentLinkRootForm(null);
            DialogResult result = addEditDocumentLinkRootForm.ShowDialog();
            return result == DialogResult.OK;
        }

        public bool EditUncRoot(DocumentRootUncPath selectedItem)
        {
            AddEditDocumentLinkRootForm addEditDocumentLinkRootForm = new AddEditDocumentLinkRootForm(selectedItem);
            DialogResult result = addEditDocumentLinkRootForm.ShowDialog();
            return result == DialogResult.OK;
        }

        private void OnClose(object sender, EventArgs e)
        {
            Close();
        }

    }

}
