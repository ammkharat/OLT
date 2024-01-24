using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogGuidelineConfigurationSelectionForm : BaseForm, ILogGuidelineConfigurationSelectionView
    {       
        private DomainSummaryGrid<FunctionalLocation> functionalLocationGrid;

        public event EventHandler EditButtonClicked;
        public event EventHandler CloseButtonClicked;

        public LogGuidelineConfigurationSelectionForm()
        {           
            InitializeComponent();
            InitializeFunctionalLocationGrid();

            editButton.Click += EditButton_Clicked;
            closeButton.Click += CloseButton_Clicked;
        }

        private void InitializeFunctionalLocationGrid()
        {
            functionalLocationGrid = new DomainSummaryGrid<FunctionalLocation>(
                new LogGuidelineFunctionalLocationGridRenderer(), OltGridAppearance.NON_OUTLOOK, string.Empty);
            functionalLocationGrid.Dock = DockStyle.Fill;
            functionalLocationGrid.DisplayLayout.GroupByBox.Hidden = true;
            functionalLocationGrid.MaximumBands = 1;
            flocGridPanel.Controls.Add(functionalLocationGrid);
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            if (EditButtonClicked != null)
            {
                EditButtonClicked(sender, e);
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            if (CloseButtonClicked != null)
            {
                CloseButtonClicked(sender, e);
            }
        }

        public FunctionalLocation SelectedFunctionalLocation
        {
            get { return functionalLocationGrid.SelectedItem; }
        }

        public void SelectFirstFunctionalLocation()
        {
            functionalLocationGrid.SelectFirstRow();
        }
       
        public List<FunctionalLocation> FunctionalLocationList
        {
            set { functionalLocationGrid.Items = value; }
        }
    }
}
