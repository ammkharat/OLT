using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class OperatorRoundGridRender : AbstractSimpleGridRenderer
    {
       
       
        protected override void SetUpColumns(UltraGridBand band) 
        {
            band.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            band.ColHeaderLines = 2;
            band.HideAllColumns();
         
            band.Columns["UserName"].Format(RendererStringResources.UserName, 1, 100);
            band.Columns["Floc"].Format(RendererStringResources.FunctionalLocation, 2, 100);
          
            band.Columns["Source"].Format(RendererStringResources.Source, 4, 50);
            band.Columns["ShiftLogMessageStagingId"].Format("Id", 5, 50);
            band.Columns["Selected"].Format("", 0, 50);
            band.Columns["MessageTimeStamp"].Format(RendererStringResources.Created, 7, 120);
            band.Columns["MessageTimeStamp"].Format = "MM/dd/yyyy hh:mm tt"; 
            band.Columns["Selected"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
            band.Columns["Selected"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
            band.Columns["Selected"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
            band.Columns["Message"].Format(RendererStringResources.Message, 8, 300);
            foreach (UltraGridColumn column in band.Columns)
            {
               
                if (column.Key == "Selected")
                {
                    column.CellActivation = Activation.AllowEdit;
                    
                }
                else
                {
                    column.CellActivation = Activation.NoEdit;
                }
              
            }
           
        }
        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add("UserName", false);
        }
        
    }
}
