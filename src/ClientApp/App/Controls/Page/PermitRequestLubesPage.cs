using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestLubesPage : AbstractPage<PermitRequestLubesDTO, IPermitRequestLubesDetails>, IPermitRequestLubesPage
    {
        public PermitRequestLubesPage()
            : base(
            new DomainSummaryGrid<PermitRequestLubesDTO>(
                new PermitRequestLubesGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "permitRequestLubesGrid", false), new PermitRequestLubesDetails())
        {
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestLubesDTO dto)
        {
            return (dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestLubesDTO dto)
        {
            return (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        public override PageKey PageKey
        {
            get { return PageKey.PERMIT_REQUEST_PAGE; }
        }

        public override void ExportAll()
        {
            OltExcelExporter exporter = new OltExcelExporter();
            exporter.InitializeColumn += InitializeExcelColumn;
            exporter.Export(grid);
        }

        private void InitializeExcelColumn(object sender, InitializeColumnEventArgs e)
        {
            if (e.Column.Key == PermitRequestLubesGridRenderer.END_DATE_COLUMN_KEY)
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortDatePattern;
            }
        }
    }
}
