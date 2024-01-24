using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestFortHillsPage : AbstractPage<PermitRequestFortHillsDTO, IPermitRequestFortHillsDetails>, IPermitRequestFortHillsPage
    {
        private readonly PageKey pageKey;

        public PermitRequestFortHillsPage(PageKey pageKey)
            : base(
            new DomainSummaryGrid<PermitRequestFortHillsDTO>(
                new PermitRequestFortHillsGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "permitRequestFortHillsGrid", false), new PermitRequestFortHillsDetails())
        {
            this.pageKey = pageKey;
        }

        public override PageKey PageKey
        {
            get { return pageKey; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestFortHillsDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestFortHillsDTO dto)
        {
            return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        public override void ExportAll()
        {
            OltExcelExporter exporter = new OltExcelExporter();
            exporter.InitializeColumn += InitializeExcelColumn;
            exporter.Export(grid);
        }

        private void InitializeExcelColumn(object sender, InitializeColumnEventArgs e)
        {
            if (e.Column.Key == PermitRequestFortHillsGridRenderer.END_DATE_COLUMN_KEY)
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortDatePattern;
            }
        }
    }
}
