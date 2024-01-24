using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.Renderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigurePHTagInfoGroupsForReportForm : BaseForm, IConfigurePHTagInfoGroupsForReportFormView
    {
        private readonly DomainListView<TagInfoGroup> tagInfoGroupListView;

        public ConfigurePHTagInfoGroupsForReportForm()
        {
            InitializeComponent();
            
            ConfigurePHTagInfoGroupsForReportFormPresenter presenter = new ConfigurePHTagInfoGroupsForReportFormPresenter(this);

            Load += presenter.HandleLoad;
            newButton.Click += presenter.HandleNewButtonClick;
            editButton.Click += presenter.HandleEditButtonClick;
            deleteButton.Click += presenter.HandleDeleteButtonClick;
            closeButton.Click += presenter.HandleCloseButtonClick;

            tagInfoGroupListView = new DomainListView<TagInfoGroup>(new TagInfoGroupListViewRenderer(), true);
            tagInfoGroupListView.SelectedIndexChanged += presenter.HandleSelectedItemChanged;
            tagInfoGroupListView.DoubleClickSelected += presenter.HandleDoubleClickSelected;
            tagInfoGroupListView.Dock = DockStyle.Fill;
            tagListPanel.Controls.Add(tagInfoGroupListView);
        }       

        public string SiteName
        {
            set { siteLabelData.Text = value; }
        }

        public List<TagInfoGroup> TagInfoGroupList
        {
            get
            {
                return new List<TagInfoGroup>(tagInfoGroupListView.ItemList);
            }

            set
            {
                tagInfoGroupListView.ItemList = value;
            }
        }

        public bool EditButtonEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool DeleteButtonEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public DialogResult AddNewTagInfoGroup()
        {
            TagInfoGroupForm tagInfoGroupForm = new TagInfoGroupForm();
            return tagInfoGroupForm.ShowDialog(this);
        }

        public TagInfoGroup GetSelectedTagInfoGroup()
        {
            DomainListViewItem<TagInfoGroup> selectedItem = tagInfoGroupListView.SelectedItem;
            return selectedItem != null ? selectedItem.Item : null;
        }

        public TagInfoGroup ShowTagInfoGroupForm(TagInfoGroup tagInfoGroupToBeEdited)
        {
            TagInfoGroupForm tagInfoGroupForm = new TagInfoGroupForm(tagInfoGroupToBeEdited);
            return tagInfoGroupForm.ShowDialog(this) == DialogResult.OK ? tagInfoGroupForm.TagInfoGroup : tagInfoGroupToBeEdited;
        }

        public bool ConfirmTagInfoGroupDeletion()
        {
            return (OltMessageBox.Show(this, StringResources.AreYouSureDeleteDialogMessage,
                        StringResources.AreYouSureDeleteDialogTitle, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes);
        }

    }
}