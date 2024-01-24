using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public class TargetAlertPage : AbstractPage<TargetAlertDTO, ITargetAlertDetails>, ITargetAlertPage
    {

        public TargetAlertPage()
            : base(new DomainSummaryGrid<TargetAlertDTO>(new TargetAlertGridRenderer(), OltGridAppearance.MULTI_SELECT_WRAPPED_TEXT, string.Empty), new TargetAlertDetails())
        {
        }

        public override PageKey PageKey
        {
            get { return PageKey.TARGET_ALERT_PAGE; }
        }

        protected override bool IsCreatedByCurrentUser(TargetAlertDTO targetAlertDTO)
        {
            // TODO:  This should actually be the Created User
            return targetAlertDTO != null
                   && targetAlertDTO.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

        protected override bool IsUpdatedByCurrentUser(TargetAlertDTO targetAlertDTO)
        {
            return targetAlertDTO != null
                   && targetAlertDTO.LastModifiedUserId == ClientSession.GetUserContext().User.Id;
        }

        public override void ExportAll()
        {
            OltExcelExporter exporter = new OltExcelExporter(); 
            exporter.InitializeColumn += InitializeExcelColumn;
            exporter.Export(grid);
        }

        private void InitializeExcelColumn(object sender, InitializeColumnEventArgs e)
        {
            if (e.Column.Key == TargetAlertGridRenderer.LOSSES_COLUMN_KEY)
            {
                e.ExcelFormatStr = LocaleSpecificFormatPatternResources.ExcelCurrencyFormat;
            }
        }

        public void ShowAssociatedLogForm(List<LogDTO> logDtos)
        {
            ReferencedLogForm form = new ReferencedLogForm(logDtos, MainParentForm);
            form.SetTitle(StringResources.AssociatedLogsPageTitle);
            form.ShowDialog(this);
        }
    }
}