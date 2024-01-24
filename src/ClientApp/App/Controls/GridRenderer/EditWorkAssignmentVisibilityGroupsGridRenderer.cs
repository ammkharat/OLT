using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class EditWorkAssignmentVisibilityGroupsGridRenderer : AbstractSimpleGridRenderer
    {
        private const string READ_COLUMN = "CanRead";
        private const string WRITE_COLUMN = "CanWrite";
        public const string GROUP_NAME_COLUMN = "GroupName";

        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            int position = 0;

            band.Columns[READ_COLUMN].Format(RendererStringResources.View, position++, 100);
            band.Columns[WRITE_COLUMN].Format(RendererStringResources.AssignedTo, position++, 100);
            band.Columns[GROUP_NAME_COLUMN].Format(RendererStringResources.Group, position++);

            foreach (UltraGridColumn column in band.Columns)
            {
                column.CellActivation = column.Key == GROUP_NAME_COLUMN ? Activation.NoEdit : Activation.AllowEdit;
            }
        }
    }

    public class VisibilityGroupsGridRenderer : AbstractSimpleGridRenderer
    {
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 1;

            int position = 0;
            band.Columns["Name"].Format(RendererStringResources.Group, position++);
        }
    }
}