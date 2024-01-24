using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Domain.CokerCard;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CokerCardForm : BaseForm, ICokerCardFormView
    {
        private readonly CokerCardFormPresenter presenter;
        private readonly CokerCardRowGridRenderer gridRenderer;
        private readonly SummaryGrid<CokerCardRow> grid;
        private CokerCardDisplayAdapter displayAdapter;

        public CokerCardForm(CokerCard cokerCard) : this(cokerCard.ConfigurationId, cokerCard)
        {
            
        }

        public CokerCardForm(long configurationId, CokerCard cokerCard)
        {
            InitializeComponent();

            gridRenderer = new CokerCardRowGridRenderer(false);
            grid = new SummaryGrid<CokerCardRow>(gridRenderer, OltGridAppearance.EDIT_CELL_SELECT);
            gridRenderer.InitializeGrid(grid);
            grid.Dock = DockStyle.Fill;
          
            gridPanel.Controls.Add(grid);

            presenter = new CokerCardFormPresenter(this, configurationId, cokerCard);
            RegisterEventHandlersOnPresenter();
        }

        private void RegisterEventHandlersOnPresenter()
        {
            Load += presenter.HandleFormLoad;
            FormClosing += presenter.HandleFormClosing;

            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;

            viewEditHistoryButton.Click += presenter.HandleViewEditHistoryButtonClick;
        }

        public string Shift
        {
            set { shiftLabelData.Text = value; }
        }

        public User Author
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public DateTime CreateDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public CokerCardDisplayAdapter DisplayAdapter
        {
            get { return displayAdapter; }
            set
            {
                displayAdapter = value;

                // need to set column keys before setting Items
                gridRenderer.CycleStepEntryColumnKeys = displayAdapter.ColumnKeys;

                grid.Items = displayAdapter.Rows;
            }
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public void ShowErrors()
        {
            grid.Refresh();
        }

        public string ConfigurationName
        {
            set { cokerCardConfigurationName.Text = value; }
        }
    }   
}