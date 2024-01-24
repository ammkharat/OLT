using Com.Suncor.Olt.Common.Domain;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.OltControls
{
    public delegate void OltGridItemEventHandler(object item);

    public class OltGrid : UltraGrid
    {                
        protected override void OnBeginInit()
        {
            DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn;
        }

        public object ActiveItem
        {
            get
            {
                object item = null;
                UltraGridRow ultraGridRow = ActiveRow;

                if (ultraGridRow != null)
                {
                    item = ultraGridRow.ListObject;
                }

                return item;
            }
        }
        
        public object ActiveItemByReference
        {           
            set
            {
                UltraGridRow row = FindRowByReference(value);
                if (row != null)
                {
                    ActiveRow = row;
                }
            }
        }

        public void ActivateFirstRow()
        {
            if (Rows.Count > 0)
            {
                UltraGridRow ultraGridRow = Rows[0];
                ActiveRow = ultraGridRow;
            }
        }

        private UltraGridRow FindRowByReference(object itemToSelect)
        {
            foreach (UltraGridRow ultraGridRow in Rows)
            {
                object listObject = (object)ultraGridRow.ListObject;

                if (listObject == itemToSelect)
                {
                    return ultraGridRow;
                }
            }

            return null;
        }
    }
}