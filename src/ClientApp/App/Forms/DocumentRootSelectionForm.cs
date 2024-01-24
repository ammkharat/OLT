using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DocumentRootSelectionForm : BaseForm, ISelectLinkRootsView
    {
        private readonly DomainSummaryGrid<DocumentRootUncPath> grid;
        private readonly ViewLinkRootsFormPresenter presenter;

        public DocumentRootSelectionForm()
        {
            InitializeComponent();

            grid = new DomainSummaryGrid<DocumentRootUncPath>(new DocumentLinkSelectionGridRender(),
                                                              OltGridAppearance.SINGLE_SELECT, "Links Grid") { Dock = DockStyle.Fill };
            grid.DisplayLayout.GroupByBox.Hidden = true;
            linksGroupBox.Controls.Add(grid);

            presenter = new ViewLinkRootsFormPresenter(this);
            Load += presenter.LoadForm;
            selectButton.Click += SelectButtonClicked;
            cancelButton.Click += CancelButtonClicked;
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButtonClicked(object sender, EventArgs e)
        {
            if (grid.SelectedItem != null)
                DialogResult = DialogResult.OK;
            Close();
        }

        public List<DocumentRootUncPath> Items
        {
            set
            {
                grid.Items = value;
                if (value.Count > 0)
                {
                    grid.SelectFirstRow();
                }
            }
        }

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public DocumentRootUncPath SelectedItem
        {
            get { return grid.SelectedItem; }
        }
    }
}
