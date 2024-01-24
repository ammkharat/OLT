using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TechnicalSiteConfigurationForm : BaseForm, ITechnicalSiteConfigurationView
    {
        public TechnicalSiteConfigurationForm()
        {
            InitializeComponent();

            saveButton.Click += HandleSaveButtonClick;

            siteConfigurationGrid.InitializeLayout += SiteConfigurationGridOnInitializeLayout;
        }

        public event Action Save;

        public SiteConfiguration SiteConfiguration
        {
            get { return ((List<SiteConfiguration>) bindingSource.DataSource)[0]; }
            set { bindingSource.DataSource = new List<SiteConfiguration> {value}; }
        }

        private void SiteConfigurationGridOnInitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            if (!e.Layout.ValueLists.Exists("MaximumDirectiveFlocLevelValueList"))
            {
                var valueList = e.Layout.ValueLists.Add("MaximumDirectiveFlocLevelValueList");
                valueList.ValueListItems.Add(1, "1");
                valueList.ValueListItems.Add(2, "2");
                valueList.ValueListItems.Add(3, "3");
            }
            e.Layout.Bands[0].Columns["MaximumDirectiveFlocLevel"].ValueList =
                e.Layout.ValueLists["MaximumDirectiveFlocLevelValueList"];
            // ayman site configuration
            e.Layout.Bands[0].CardView = true;
        }

        private void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save();
            }
        }
    }
}