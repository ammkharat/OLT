using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class PermitRequestEdmontonTemplatePage : AbstractPage<PermitRequestEdmontonDTO, IPermitRequestEdmontonDetails>, IPermitRequestEdmontonPage
    {
        private readonly PageKey pageKey;

        public PermitRequestEdmontonTemplatePage(PageKey pageKey)
            : base(
            new DomainSummaryGrid<PermitRequestEdmontonDTO>(
                new PermitRequestEdmontonTemplateGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, "permitRequestEdmontonTemplateGrid", false), new PermitRequestEdmontonDetails())
        {
            this.pageKey = pageKey;
        }

        public override PageKey PageKey
        {
            get { return pageKey; }
        }

        protected override bool IsCreatedByCurrentUser(PermitRequestEdmontonDTO dto)
        {
            return false; //(dto != null && dto.CreatedByUserId == ClientSession.GetUserContext().User.Id);  
        }

        protected override bool IsUpdatedByCurrentUser(PermitRequestEdmontonDTO dto)
        {
            return false;// (dto != null && dto.LastModifiedByFullnameWithUserName.Equals(ClientSession.GetUserContext().User.FullNameWithUserName));
        }

        public override void ExportAll()
        {
            OltExcelExporter exporter = new OltExcelExporter();
            exporter.InitializeColumn += InitializeExcelColumn;
            exporter.Export(grid);
        }

        private void InitializeExcelColumn(object sender, InitializeColumnEventArgs e)
        {
            if (e.Column.Key == PermitRequestEdmontonGridRenderer.END_DATE_COLUMN_KEY)
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ShortDatePattern;
            }
        }
    }
}
