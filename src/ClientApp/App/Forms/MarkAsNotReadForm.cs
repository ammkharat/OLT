using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class MarkAsNotReadForm : BaseForm, IMarkedAsNotReadForm
    {
        private DomainListView<ItemNotReadBy> markasNotReadGrid;
        public MarkAsNotReadForm(long directiveid)
        { 
            InitializeComponent();
            markasNotReadGrid = new DomainListView<ItemNotReadBy>(new LogNotReadByListViewRenderer(), false)
            {
                Dock = DockStyle.Fill
            };
            markedAsNotReadByPanel.Controls.Add(markasNotReadGrid);
            markedAsNotReadByPanel.Visible = true;
            MarkAsNotReadFormPresenter presenter = new MarkAsNotReadFormPresenter(directiveid, this);
            this.Load += presenter.Form_Load;
        }
        public List<ItemNotReadBy> MarkedAsNotReadBy
        {
            set { markasNotReadGrid.ItemList = value; }
        }
    }
}
