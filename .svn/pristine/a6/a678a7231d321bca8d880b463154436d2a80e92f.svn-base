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
    public partial class WorkPermitMudsTemplateConfigurationForm : BaseForm, IWorkPermitMudsTemplateConfigurationView 
    {
        private readonly WorkPermitMudsTemplateConfigurationFormPresenter presenter;
        private DomainSummaryGrid<WorkPermitMudsTemplate> workPermitMudsTemplateGrid;

        public WorkPermitMudsTemplateConfigurationForm()
        {
            presenter = new WorkPermitMudsTemplateConfigurationFormPresenter(this);

            InitializeComponent();
            InitializeTemplateGrid();
            RegisterEventHandlers();
        }

        private void InitializeTemplateGrid()
        {
            workPermitMudsTemplateGrid = new DomainSummaryGrid<WorkPermitMudsTemplate>(new WorkPermitMudsTemplateGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            workPermitMudsTemplateGrid.Dock = DockStyle.Fill;
            workPermitMudsTemplateGrid.DisplayLayout.GroupByBox.Hidden = true;
            workPermitMudsTemplateGrid.MaximumBands = 1;
            categoryGridPanel.Controls.Add(workPermitMudsTemplateGrid);
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

        public WorkPermitMudsTemplate SelectedWorkPermitMudsTemplate
        {
            get { return workPermitMudsTemplateGrid.SelectedItem; }
            set { workPermitMudsTemplateGrid.SelectItem(value);}
        }

        public void SelectFirstWorkPermitMudsTemplate()
        {
            workPermitMudsTemplateGrid.SelectFirstRow();
        }

        public bool UserReallyWantsToDeleteWorkPermitMudsTemplate()
        {
            DialogResult result = OltMessageBox.Show(this,
                                                     StringResources.AreYouSureDeleteMontrealWorkPermitTemplateMessageBoxText, //TODO : Message 
                                                     StringResources.AreYouSureDeleteMontrealWorkPermitTemplateMessageBoxCaption,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        public List<WorkPermitMudsTemplate> WorkPermitMudsTemplateList
        {
            set { workPermitMudsTemplateGrid.Items = value; }
        }
    }
}
