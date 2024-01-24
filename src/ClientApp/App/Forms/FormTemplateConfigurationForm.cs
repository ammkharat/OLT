using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class FormTemplateConfigurationForm : BaseForm, IFormTemplateConfigurationView
    {
        public event Action<FormTemplate> EditButtonClicked;

        private DomainSummaryGrid<FormTemplate> grid;

        public FormTemplateConfigurationForm()
        {
            InitializeComponent();

            InitializeGrid();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            editButton.Click += HandleEditButtonClick;
            grid.DoubleClickSelected += HandleGridDoubleClick;
        }

        private void HandleGridDoubleClick(object sender, DomainEventArgs<FormTemplate> e)
        {
            HandleEditButtonClick(sender, EventArgs.Empty);
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (EditButtonClicked != null)
            {
                FormTemplate template = grid.SelectedItem;
                EditButtonClicked(template);
            }
        }

        private void InitializeGrid()
        {
            var localizedTemplateName = StringResources.Template;
            if (ClientSession.GetUserContext().IsSarniaSite)
            { // mail referance from Mike " DMND0010610 : Sarnia Safe Work Permit  - Document of understanding" point 'Admin Form Template config – still shows reference to OP14.' removing OP14 for sarnia site
                EdmontonFormTypeName.EdmontonFormTypeSite = ClientSession.GetUserContext().SiteId;
            }
            grid = new DomainSummaryGrid<FormTemplate>(new SingleColumnGridRenderer(localizedTemplateName, "DisplayName"), OltGridAppearance.NON_OUTLOOK, string.Empty);

            grid.Dock = DockStyle.Fill;
            grid.DisplayLayout.GroupByBox.Hidden = true;

            grid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select;
            gridPanel.Controls.Add(grid);
        }

        public List<FormTemplate> FormTemplates
        {
            set
            {
                grid.Items = value;
            }
        }

        public void SelectFirstRow()
        {
            grid.SelectFirstRow();
        }

        public FormTemplate SelectedTemplate
        {
            set
            {
                List<FormTemplate> formTemplates = new List<FormTemplate>(grid.Items);
                FormTemplate formTemplate = formTemplates.Find(template => template.Name == value.Name);
                if (formTemplate != null)
                {
                    grid.SelectItemByReference(formTemplate);
                }
            }
        }

    }
}
