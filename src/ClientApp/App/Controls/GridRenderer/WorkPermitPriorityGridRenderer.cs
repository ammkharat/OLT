using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class WorkPermitPriorityGridRenderer : WorkPermitGridRenderer
    {
        protected override void LoadDefaultColumnLayout(UltraGridBand band)
        {
            band.Columns[typeImageColumn.ColumnKey].Format(typeImageColumn.ColumnCaption, 1);
            band.Columns[statusImageColumn.ColumnKey].Format(statusImageColumn.ColumnCaption, 2);
            band.Columns[sourceImageColumn.ColumnKey].Format(sourceImageColumn.ColumnCaption, 3);

            band.Columns["FunctionalLocationName"].Format(RendererStringResources.Floc, 5);
            band.Columns["CraftOrTradeName"].Format(RendererStringResources.CraftTrade, 6);

            band.Columns["WorkOrderDescription"].Format(RendererStringResources.WODescription, 7);
            band.Columns["WorkOrderDescription"].Width = 140;

            band.Columns["JobStepsDescription"].Format(RendererStringResources.JobSteps, 8);
            band.Columns["JobStepsDescription"].Width = 140;

            band.Columns["WorkOrderNumber"].Format(RendererStringResources.WONumber, 9);

            band.Columns["CreatedByFullNameWithUserName"].Format(RendererStringResources.InitiatedBy, 10);
            band.Columns["ApprovedByFullNameWithUserName"].Format(RendererStringResources.ApprovedBy, 11);

            band.Columns["PermitNumber"].Format(RendererStringResources.PermitNumber, 12);
            band.Columns["PermitNumber"].Width = 80;
        }

    }
}
