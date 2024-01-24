using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Com.Suncor.Olt.Client.Controls.GridRenderer
{
    public class UserMultiSelectGridRenderer : AbstractSimpleGridRenderer
    {       
        private const string EDIT_COLUMN_KEY = "Selected";
        private const string NAME_COLUMN_KEY = "Name";      
                
        public UserMultiSelectGridRenderer()
        {   
        }
      
        protected override void SetUpColumns(UltraGridBand band)
        {
            band.Override.RowSelectors = DefaultableBoolean.False;

            int i = 0;

            band.HideAllColumns();
           
            band.Columns[EDIT_COLUMN_KEY].Format("", i++, 30);
            band.Columns[EDIT_COLUMN_KEY].AllowRowFiltering = DefaultableBoolean.False;
            band.Columns[EDIT_COLUMN_KEY].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns[EDIT_COLUMN_KEY].SortIndicator = SortIndicator.Disabled;
            band.Columns[EDIT_COLUMN_KEY].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            band.Columns[EDIT_COLUMN_KEY].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;

            band.Columns[NAME_COLUMN_KEY].Format(RendererStringResources.Name, i++, 200);
                       
            foreach (UltraGridColumn column in band.Columns)
            {
                if (column.Key != EDIT_COLUMN_KEY)
                {
                    column.CellActivation = Activation.NoEdit;
                }
                else
                {
                    column.CellActivation = Activation.AllowEdit;
                }
            }
        }

        public override void SetDefaultSortColumns(SortedColumnsCollection sortedColumns)
        {
            sortedColumns.Add(NAME_COLUMN_KEY, false);            
        }

        public class DisplayAdapter
        {
            private readonly UserDTO user;

            public DisplayAdapter(UserDTO user)
            {
                this.user = user;
            }

            public DisplayAdapter(UserDTO user, bool selected)
            {
                this.user = user;
                Selected = selected;
            }

            public bool Selected { get; set; }

            public string Name
            {
                get { return user.FullName; }
            }

            public UserDTO GetUser()
            {
                return user;
            }
        }
    }
}
