using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitMontrealTemplateConfigurationForm : BaseForm, IWorkPermitMontrealTemplateConfigurationView 
    {
        private readonly WorkPermitMontrealTemplateConfigurationFormPresenter presenter;
        private DomainSummaryGrid<WorkPermitMontrealTemplate> workPermitMontrealTemplateGrid;

        public WorkPermitMontrealTemplateConfigurationForm()
        {
            presenter = new WorkPermitMontrealTemplateConfigurationFormPresenter(this);

            InitializeComponent();
            InitializeTemplateGrid();
            RegisterEventHandlers();
        }

        private void InitializeTemplateGrid()
        {
            workPermitMontrealTemplateGrid = new DomainSummaryGrid<WorkPermitMontrealTemplate>(new WorkPermitMontrealTemplateGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            workPermitMontrealTemplateGrid.Dock = DockStyle.Fill;
            workPermitMontrealTemplateGrid.DisplayLayout.GroupByBox.Hidden = true;
            workPermitMontrealTemplateGrid.MaximumBands = 1;
            categoryGridPanel.Controls.Add(workPermitMontrealTemplateGrid);
        }

        private void RegisterEventHandlers()
        {
            Load += presenter.HandleLoad;
            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            closeButton.Click += presenter.CloseButton_Click;
            deleteButton.Click += presenter.DeleteButton_Click;
            activeButton.Click += presenter.ActiveButton_Click;            
        }

        public WorkPermitMontrealTemplate SelectedWorkPermitMontrealTemplate
        {
            get { return workPermitMontrealTemplateGrid.SelectedItem; }
            set { workPermitMontrealTemplateGrid.SelectItem(value);}
        }

        public void SelectFirstWorkPermitMontrealTemplate()
        {
            workPermitMontrealTemplateGrid.SelectFirstRow();
        }

        public bool UserReallyWantsToDeleteWorkPermitMontrealTemplate()
        {
            DialogResult result = OltMessageBox.Show(this,
                                                     StringResources.AreYouSureDeleteMontrealWorkPermitTemplateMessageBoxText,
                                                     StringResources.AreYouSureDeleteMontrealWorkPermitTemplateMessageBoxCaption,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        public List<WorkPermitMontrealTemplate> WorkPermitMontrealTemplateList
        {
            set { workPermitMontrealTemplateGrid.Items = value; }
        }
    }
}
