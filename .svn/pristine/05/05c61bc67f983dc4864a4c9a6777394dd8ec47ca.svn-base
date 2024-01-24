using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class ShiftHandoverEmailConfigurationGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;

            int position = 0;

            band.Columns["ShiftPattern"].Format(RendererStringResources.Shift, position++, 50);
            band.Columns["EmailSendTime"].Format(RendererStringResources.SendTime, position++, 75);
            band.Columns["EmailAddressesAsDelimitedString"].Format(RendererStringResources.EmailAddresses, position++, 200);
            band.Columns["WorkAssignmentsAsDelimitedString"].Format(RendererStringResources.WorkAssignments, position++, 250);            
        }
    }
}
