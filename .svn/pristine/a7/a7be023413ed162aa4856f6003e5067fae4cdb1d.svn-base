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
    public partial class TagInfoGroupForm : BaseForm, ITagInfoGroupFormView
    {
        private readonly TagInfoGroupFormPresenter presenter;
        private readonly DomainSummaryGrid<TagInfoWithError> tagInfoGrid;

        public TagInfoGroupForm(TagInfoGroup tagInfoGroup)
        {
            InitializeComponent();
            tagInfoGrid = new DomainSummaryGrid<TagInfoWithError>(new TagInfoGroupGridRender(), OltGridAppearance.SINGLE_SELECT, string.Empty)
                              {Dock = DockStyle.Fill};
            phTagListPanel.Controls.Add(tagInfoGrid);
            presenter = new TagInfoGroupFormPresenter(this, tagInfoGroup);
            Load += presenter.HandleLoad;
            addButton.Click += presenter.HandleAddTagInfo;
            removeButton.Click += presenter.HandleRemoveTagInfo;
            clearButton.Click += presenter.HandleClearTagInfoList;
            saveButton.Click += presenter.HandleSaveAndCloseButtonClick;
            cancelButton.Click += presenter.HandleCancelTagInfoGroupEditing;
            tagInfoGrid.SelectedItemChanged += presenter.HandleTagInfoListSelectedItemChanged;
        }

        public TagInfoGroupForm()
                : this(new TagInfoGroup(null, string.Empty, ClientSession.GetUserContext().Site)) {}

        public TagInfoGroup TagInfoGroup
        {
            get { return presenter.TagInfoGroup; }
        }

        public void ClearErrorProviders()
        {
            phTagListNameErrorProvider.Clear();
        }

        public void ShowTagInfoGroupNameIsEmptyError()
        {
            phTagListNameErrorProvider.SetError(phTagListNameTextBox, StringResources.NameEmptyError);
        }

        public void ShowTagInfoGroupNameIsDuplicateError()
        {
            phTagListNameErrorProvider.SetError(phTagListNameTextBox, StringResources.DuplicateTagInfoGroupName);
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public DialogResult ShowTagReadWarningMessage()
        {
            return OltMessageBox.Show(ActiveForm,
                                      StringResources.TagInfoGroupForm_ListContainsTagsThatCannotBeReadMessageBoxText,
                                      StringResources.TagInfoGroupForm_ListContainsTagsThatCannotBeReadMessageBoxCaption,
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Warning);
        }

        public string TagInfoGroupName
        {
            set { phTagListNameTextBox.Text = value; }
            get { return phTagListNameTextBox.Text; }
        }

        public List<TagInfoWithError> TagInfoList
        {
            set { tagInfoGrid.Items = value; }
        }

        private const string FormatString = "{0} ";

        public void UpdateTitleAsCreateOrEdit(bool isEdit)
        {
            string edit = string.Format(FormatString, StringResources.FormTitlePrefix_Edit);
            string create = string.Format(FormatString, StringResources.FormTitlePrefix_Create);

            string preFix = isEdit ? edit : create;
            Text = preFix + Text;
        }

        public TagInfo GetTagInfoToBeAdded()
        {
            TagSearchForm tagSearchForm = new TagSearchForm(true, false);
            return tagSearchForm.ShowDialog(this) == DialogResult.OK
                           ? tagSearchForm.SelectedTag
                           : null;
        }

        public TagInfoWithError GetTagInfoToBeRemoved()
        {
            return tagInfoGrid.SelectedItem;
        }

        public bool RemoveButtonEnabled
        {
            set { removeButton.Enabled = value; }
        }

        public bool ClearButtonEnabled
        {
            set { clearButton.Enabled = value; }
        }
    }
}