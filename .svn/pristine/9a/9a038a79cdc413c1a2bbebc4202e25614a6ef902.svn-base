using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class CustomFieldGroupConfigurationForm : BaseForm, ICustomFieldGroupConfigurationView
    {
        private DomainSummaryGrid<CustomFieldGroup> grid;

        public CustomFieldGroupConfigurationForm()
        {
            CustomFieldGroupConfigurationFormPresenter presenter = new CustomFieldGroupConfigurationFormPresenter(this);

            InitializeComponent();
            InitializeGrid();
            RegisterEventHandler(presenter);
        }

        private void InitializeGrid()
        {
            grid = new DomainSummaryGrid<CustomFieldGroup>(new CustomFieldGroupGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            grid.MaximumBands = 1;
            gridPanel.Controls.Add(grid);
        }

        private void RegisterEventHandler(CustomFieldGroupConfigurationFormPresenter presenter)
        {
            Load += presenter.HandleLoad;
            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            deleteButton.Click += presenter.DeleteButton_Click;
            closeButton.Click += presenter.CloseButton_Click;
        }

        public DialogResultAndOutput<CustomFieldGroup> ShowAddEditForm(CustomFieldGroup editObject, List<CustomFieldGroup> allGroupsForSite)
        {
            AddEditCustomFieldGroupForm addEditForm = new AddEditCustomFieldGroupForm(editObject, allGroupsForSite);
            return addEditForm.ShowDialogAndReturnEditObject(this);
        }

        public CustomFieldGroup SelectedGroup
        {
            get { return grid.SelectedItem; }
            set { grid.SelectItemById(value.IdValue); }
        }

        public bool UserReallyWantsToDelete()
        {
            DialogResult result = OltMessageBox.Show(this,
                                                     StringResources.AreYouSureDeleteCustomFieldGroupMessageBoxText,
                                                     StringResources.AreYouSureDeleteCustomFieldGroupMessageBoxCaption,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        public List<CustomFieldGroup> CustomFields
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

        public void RemoveGroup(CustomFieldGroup group)
        {
            grid.RemoveItemByReferenceAndSelectFirstRow(group);
        }

        public void RefreshView()
        {
            grid.Refresh();
        }
    }
}
