using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class RestrictionLocationListConfigurationForm : BaseForm, IRestrictionLocationListConfigurationView
    {
        public RestrictionLocationListConfigurationForm()
        {
            InitializeComponent();
            RestrictionLocationListConfigurationFormPresenter presenter = new RestrictionLocationListConfigurationFormPresenter(this);
            RegisterEventHandlersOnPresenter(presenter);

        }

        private void RegisterEventHandlersOnPresenter(RestrictionLocationListConfigurationFormPresenter presenter)
        {
            addListButton.Click += (sender, args) => presenter.AddList();
            removeListButton.Click += (sender, args) => presenter.RemoveList();
            renameListButton.Click += (sender, args) => presenter.RenameList();
            editListButton.Click += (sender, args) => presenter.EditList();
            locationListNamesListBox.SelectedIndexChanged += locationListNamesListBox_SelectedIndexChanged;
            Load += (sender, args) => presenter.HandleLoad();
        }

        void locationListNamesListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool itemSelected = locationListNamesListBox.SelectedIndex != -1;

            editListButton.Enabled = itemSelected;
            removeListButton.Enabled = itemSelected;
            renameListButton.Enabled = itemSelected;
        }

        public List<RestrictionLocation> RestrictionLocationList
        {
            set
            {
                locationListNamesListBox.DataSource = value;

                locationListNamesListBox.ClearSelected();
            }
        }

        public RestrictionLocation SelectedRestrictionLocation
        {
            get { return locationListNamesListBox.SelectedItem as RestrictionLocation; }
            set
            {
                locationListNamesListBox.SelectedItem = value;
            }
        }
    }
}