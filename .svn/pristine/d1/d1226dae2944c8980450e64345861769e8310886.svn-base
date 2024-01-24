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
    public partial class TagSearchForm : BaseForm, ITagSearchFormView
    {
        private DomainSummaryGrid<TagInfo> grid;

        public TagSearchForm(bool showReadWriteStatus, bool warnOnNotWriteable)
        {
            Initialize(showReadWriteStatus);
            var presenter = new TagSearchFormPresenter(this, showReadWriteStatus, warnOnNotWriteable);
            RegisterEventHandler(presenter);
        }

        private void RegisterEventHandler(TagSearchFormPresenter presenter)
        {
            Load += presenter.HandleFormLoad;
            selectButton.Click += presenter.SelectButtonClickEvent;
            grid.SelectedItemChanged += presenter.SelectedItemChangedEvent;
            grid.DoubleClickSelected += presenter.DoubleClickSelectedEvent;
            cancelButton.Click += presenter.CancelButtonClickEvent;
            searchButton.Click += presenter.SearchButtonClickEvent;
        }

        private void Initialize(bool showReadWriteStatus)
        {
            InitializeComponent();
            grid = new DomainSummaryGrid<TagInfo>(new TagSearchGridRenderer(), OltGridAppearance.SINGLE_SELECT, string.Empty)
                       {Dock = DockStyle.Fill};
            searchResultsPanel.Controls.Add(grid);
            readWriteStatusPanel.Visible = showReadWriteStatus;

        }

        public List<SearchField> SearchCriteria
        {
            set
            {
                if(value != null)
                {
                    List<SearchField> searchList = value.FindAll(field => field.Visible);

                    criteriaComboBox.DataSource = searchList;
                    criteriaComboBox.DisplayMember = "FriendlyName";
                }
            }
        }

        public List<TagInfo> ListData
        {
            set { grid.Items = value; }
        }

        public TagInfo SelectedTag
        {
            get { return grid.SelectedItem; }
        }

        public void ResetTagStatusImages()
        {
            tagReadStatusPictureBox.Image = null;
            tagWriteStatusPictureBox.Image = null;
        }

        public bool SelectedTagReadStatus
        {
            set
            {
                WidgetAppearance app = Constants.GetPlantHistorianReadAppearance(value);
                tagReadStatusPictureBox.Image = app.Icon;
                tagReadStatusToolTip.SetToolTip(tagReadStatusPictureBox, app.LongText);
            }
        }

        public bool SelectedTagWriteStatus
        {
            set
            {
                WidgetAppearance app = Constants.GetPlantHistorianWriteAppearance(value);
                tagWriteStatusPictureBox.Image = app.Icon;
                tagWriteStatusToolTip.SetToolTip(tagWriteStatusPictureBox, app.LongText);
            }
            get { return tagWriteStatusPictureBox.Image == Constants.GetPlantHistorianWriteAppearance(true).Icon; }
        }

        public void ShowInvalidCriteriaValueError()
        {
            criteriaValueErrorProvider.SetError(criteriaValueTextBox, StringResources.FieldEmptyError);
        }

        public void ClearErrorProviders()
        {
            criteriaValueErrorProvider.Clear();
        }

        public SearchField CriteriaField
        {
            get { return (SearchField) criteriaComboBox.SelectedItem; }
            set { criteriaComboBox.SelectedItem = value; }
        }

        public string CriteriaValue
        {
            get { return criteriaValueTextBox.Text; }
            set { criteriaValueTextBox.Text = value; }
        }

        public bool SelectButtonEnabled
        {
            set { selectButton.Enabled = value; }
        }

        public bool ConfirmCancel()
        {
            return (OltMessageBox.Show(ActiveForm,
                                       StringResources.AreYouSureCancelDialogMessage,
                                       StringResources.AreYouSureCancelDialogTitle,
                                       MessageBoxButtons.YesNo) == DialogResult.Yes);
        }

        public void CloseForm()
        {
            Close();
        }

        public void SetDialogResultOK()
        {
            DialogResult = DialogResult.OK;
        }

        public void ShowMustSelectWritableTag()
        {
            OltMessageBox.ShowError(StringResources.CustomFieldMustSelectWritableTag);
        }

        public void SetDialogResultNone()
        {
            DialogResult = DialogResult.None;
        }
    }
}