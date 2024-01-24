using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class EditQuestionnaireConfigurationForm : BaseForm, IEditQuestionnaireConfigurationForm
    {
        private DomainSummaryGrid<QuestionnaireSection> sectionGrid;

        public EditQuestionnaireConfigurationForm(QuestionnaireConfiguration editObject)
        {
            InitializeComponent();
            InitializePresenter(editObject);
            InitializeGrid();
        }

        public string ConfigurationName
        {
            get { return nameTextField.Text.TrimWhitespace(); }
            set { nameTextField.Text = value; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetNameMissingError()
        {
            errorProvider.SetError(nameTextField, StringResources.FieldEmptyError);
        }

        public List<QuestionnaireSection> Sections
        {
            set { sectionGrid.Items = value; }
        }

        public QuestionnaireSection SelectedSection
        {
            get { return sectionGrid.SelectedItem; }
            set { sectionGrid.SelectItemByReference(value); }
        }

        public void SetErrorForDuplicateConfigurationName()
        {
            errorProvider.SetError(nameTextField, StringResources.DuplicateQuestionnaireConfigurationName);
        }

        public void SetAtLeastOneSectionRequiredError()
        {
            errorProvider.SetError(sectionsGridPanel, StringResources.SectionRequiredError);
        }

        public void SelectFirstSection()
        {
            sectionGrid.SelectFirstRow();
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        public QuestionnaireSection LaunchAddEditSectionForm(QuestionnaireSection section)
        {
            var form = new AddEditQuestionnaireSectionForm(section);
            return form.ShowDialogAndReturnSection(this);
        }

        private void InitializePresenter(QuestionnaireConfiguration editObject)
        {
            var presenter =
                new EditQuestionnaireConfigurationFormPresenter(this, editObject);

            nameTextField.Text = (editObject != null) ? editObject.Name : string.Empty;

            Load += presenter.Load;
            saveAndCloseButton.Click += presenter.SaveAndCloseButton_Clicked;
            moveQuestionUpButton.Click += presenter.MoveSectionUpButton_Clicked;
            moveQuestionDownButton.Click += presenter.MoveSectionDownButton_Clicked;

            addSectionButton.Click += presenter.AddSectionButton_Clicked;
            editSectionButton.Click += presenter.EditSectionButton_Clicked;
            deleteSectionButton.Click += presenter.DeleteSectionButton_Clicked;
        }

        private void InitializeGrid()
        {
            sectionGrid = new DomainSummaryGrid<QuestionnaireSection>(new QuestionnaireSectionGridRenderer(),
                OltGridAppearance.NON_OUTLOOK, string.Empty) {Dock = DockStyle.Fill};

            sectionGrid.DisplayLayout.GroupByBox.Hidden = true;

            sectionGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            sectionGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            sectionsGridPanel.Controls.Add(sectionGrid);
        }
    }
}