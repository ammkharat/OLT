using System.Drawing;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class AdministratorListConfigurationGridRenderer : AbstractSimpleGridRenderer
    {
        private const string Site = "SiteName";
        private const string Group = "Group";
        private const string SiteRepresentative = "SiteRepresentative";
        private const string SiteAdmin = "SiteAdmin";
        private const string BEA = "BEA";
        
        protected override void SetUpColumns(UltraGridBand band)
        {
            int position = 0;

            band.HideAllColumns();

            band.Columns[Site].Format(RendererStringResources.Site, position++, 200);
            band.Columns[Group].Format(RendererStringResources.Group, position++, 230);
            band.Columns[SiteRepresentative].Format(RendererStringResources.SiteRepresentative, position++, 250);
            band.Columns[SiteAdmin].Format(RendererStringResources.SiteAdmin, position++, 250);
            band.Columns[BEA].Format(RendererStringResources.BEA, position++, 230);
        }

        private static void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            e.Layout.Override.MergedCellStyle = MergedCellStyle.Always;

            //column.Header.Appearance.ForeColorDisabled = Color.Black;
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(Site, false);
            sortedColumns.Add(Group, false);
            sortedColumns.Add(SiteRepresentative, false);
            sortedColumns.Add(SiteAdmin, false);
            sortedColumns.Add(BEA, false);            
        }
    }
}