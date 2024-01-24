using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureWorkAssignmentNotSelectedWarningForm : BaseForm, IConfigureWorkAssignmentNotSelectedWarningFormView
    {
        private readonly SummaryGrid<Role> grid;
        private ConfigureWorkAssignmentNotSelectedWarningFormPresenter presenter;

        public ConfigureWorkAssignmentNotSelectedWarningForm()
        {
            InitializeComponent();

            grid = new SummaryGrid<Role>(new RoleGridRenderer(), OltGridAppearance.EDIT_CELL_SELECT);
            grid.Dock = DockStyle.Fill;
            gridPanel.Controls.Add(grid);

            InitializePresenter();
        }

        private void InitializePresenter()
        {
            presenter = new ConfigureWorkAssignmentNotSelectedWarningFormPresenter(this);
            Load += presenter.LoadForm;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }

        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public IList<Role> Roles
        {
            get { return grid.Items; }
            set { grid.Items = value; }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configure Work Assignment Not Selected Warning Form, Site Id: " + site.IdValue);
        }
    }
}