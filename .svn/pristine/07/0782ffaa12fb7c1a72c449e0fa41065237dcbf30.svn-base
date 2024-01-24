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
    public partial class LogTemplateConfigurationForm : BaseForm, ILogTemplateConfigurationView
    {
        private readonly LogTemplateConfigurationFormPresenter presenter;
        private DomainSummaryGrid<LogTemplate> logTemplateGrid;

        public LogTemplateConfigurationForm()
        {
            presenter = new LogTemplateConfigurationFormPresenter(this);

            InitializeComponent();
            InitializeCategoryGrid();
            RegisterEventHandlers();
        }

        private void InitializeCategoryGrid()
        {
            logTemplateGrid = new DomainSummaryGrid<LogTemplate>(new LogTemplateGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            logTemplateGrid.Dock = DockStyle.Fill;
            logTemplateGrid.DisplayLayout.GroupByBox.Hidden = true;
            logTemplateGrid.MaximumBands = 1;
            categoryGridPanel.Controls.Add(logTemplateGrid);
        }

        private void RegisterEventHandlers()
        {
            Load += presenter.HandleLoad;
            addButton.Click += presenter.AddButton_Click;
            editButton.Click += presenter.EditButton_Click;
            closeButton.Click += presenter.CloseButton_Click;
            deleteButton.Click += presenter.DeleteButton_Click;            
        }

        public LogTemplate ShowAddEditForm(LogTemplate editObject, List<LogTemplate> logTemplatesForSite)
        {
            AddEditLogTemplateForm addEditLogTemplateForm =
                new AddEditLogTemplateForm(editObject, logTemplatesForSite);
            return addEditLogTemplateForm.ShowDialogAndReturnLogTemplate(this);           
        }

        public LogTemplate SelectedLogTemplate
        {
            get { return logTemplateGrid.SelectedItem; }
        }

        public void SelectFirstLogTemplate()
        {
            logTemplateGrid.SelectFirstRow();
        }

        public bool UserReallyWantsToDeleteLogTemplate()
        {
            DialogResult result = OltMessageBox.Show(this,
                                                     StringResources.AreYouSureDeleteLogTemplateMessageBoxText,
                                                     StringResources.AreYouSureDeleteLogTemplateMessageBoxCaption,
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }
       
        public List<LogTemplate> LogTemplateList
        {
            set { logTemplateGrid.Items = value; }
        }
    }
}
