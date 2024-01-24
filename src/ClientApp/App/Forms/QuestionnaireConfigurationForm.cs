using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class QuestionnaireConfigurationForm : BaseForm, IQuestionnaireConfigurationForm
    {
        private readonly DomainSummaryGrid<QuestionnaireConfigurationDTO> grid;

        public QuestionnaireConfigurationForm()
        {
            InitializeComponent();
            InitializePresenter();

            grid = new DomainSummaryGrid<QuestionnaireConfigurationDTO>(
                new QuestionnaireConfigurationDTOGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;
            gridPanel.Controls.Add(grid);
        }

        public List<QuestionnaireConfigurationDTO> QuestionnaireConfigurationDTOs
        {
            set { grid.Items = value; }
        }

        public QuestionnaireConfigurationDTO SelectedItem
        {
            get { return grid.SelectedItem; }
        }

        public void LaunchEditQuestionnaireConfigurationForm(QuestionnaireConfiguration selected)
        {
            var form = new EditQuestionnaireConfigurationForm(selected);
            form.ShowDialog(this);
            SelectFirstRow();
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public bool UserIsSure()
        {
            return UIUtils.ConfirmDeleteDialog();
        }

        private void InitializePresenter()
        {
            var presenter = new QuestionnaireConfigurationPresenter(this);
            Load += presenter.Load;

            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            removeButton.Click += presenter.RemoveButton_Click;
            closeButton.Click += presenter.CloseButton_Clicked;
        }
    }
}